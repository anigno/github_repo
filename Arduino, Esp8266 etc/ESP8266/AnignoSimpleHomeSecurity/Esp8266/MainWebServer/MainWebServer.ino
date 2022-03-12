#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include "Arduino.h"
#include <SoftwareSerial.h>
#include "DFRobotDFPlayerMini.h"

const char* ssid = "anigno-hot";  // Enter SSID here
const char* password = "136161271";  //Enter Password here

SoftwareSerial mySoftwareSerial(D1, D2);
DFRobotDFPlayerMini myDFPlayer;
ESP8266WebServer server(80);

String message = "";
bool state_A = true;
bool state_B = false;
bool trigger = false;
int triggerCnt = 0;
int playCnt = 0;
int playerState = 0;
int nFiles = 0;

int resetCounter = 10 * 60 * 10; //reset every 10 minutes


void setup() {
  Serial.begin(115200);
  delay(10);
  Serial.println('\n');

  mySoftwareSerial.begin(9600);
  delay(2000);
  if (!myDFPlayer.begin(mySoftwareSerial)) {
    message += "[mp3 dfplayer error]";
    Serial.println("error in dfplayer init");
  } else {
    Serial.println(F("DFPlayer Mini online."));
    myDFPlayer.volume(15);  //max volume is 30
    nFiles = myDFPlayer.readFileCounts();
    Serial.print("mp3 files: "); Serial.println(nFiles );
    message += "[Found: " + String(nFiles) + " tracks]";
  }

  pinMode(16, OUTPUT);  //led 1
  pinMode(2, OUTPUT);   //led 2
  WiFi.begin(ssid, password);
  Serial.print("Connecting to ");
  Serial.print(ssid);
  Serial.println(" ...");

  int i = 0;
  while (WiFi.status() != WL_CONNECTED) { // Wait for the Wi-Fi to connect
    delay(1000);
    Serial.print(++i); Serial.print('.');
  }

  Serial.println('\n');
  Serial.println("Connection established!");
  Serial.print("IP address:\t");
  Serial.println(WiFi.localIP());

  delay(100);

  server.onNotFound(handle_OnHome);
  server.on("/", handle_OnHome);
  server.on("/button_A_clicked", handle_button_A_clicked);
  server.on("/button_B_clicked", handle_button_B_clicked);
  server.on("/trigger", handle_trigger);


  server.begin();
  Serial.println();
  Serial.println("HTTP server started");
}

void loop() {
  server.handleClient();
  int led1 = state_A ? LOW : HIGH;
  digitalWrite(16, led1);
  int led2 = state_B ? LOW : HIGH;
  digitalWrite(2, led2);

  if (state_B) {
    playCnt = 3;
  }
  else {
    if (state_A) {
      if (trigger) {
        trigger = false;
        playCnt = 300; //30 seconds aproximate
      }
    }
  }
  playerState = myDFPlayer.readState();
  if (playCnt > 0) {
    Serial.print("player state: "); Serial.println(playerState);
    if (playerState != 513) {
      myDFPlayer.randomAll();
    }
    playCnt--;
    delay(100);
  } else {
    myDFPlayer.stop();
    trigger = false;
  }
  
  
  Serial.printf("rstCnt: %d \n",resetCounter);
  delay(100);
  if (resetCounter-- <= 0) {
    ESP.restart();
  }
}

void handle_OnHome() {
  server.send(200, "text/html", SendHTML());
  Serial.println("OnHome");
}

void handle_button_A_clicked() {
  Serial.println("handle_button_A_clicked");
  state_A = !state_A;
  server.send(200, "text/html", SendHTML());
}

void handle_button_B_clicked() {
  Serial.println("handle_button_B_clicked");
  state_B = !state_B;
  server.send(200, "text/html", SendHTML());
}

void handle_trigger() {
  Serial.println("handle_trigger");
  trigger = true;
  triggerCnt++;
  //  message = "[URI:" + server.uri() + " Method:" + server.method() + " Args:" + server.args() + " ";
  message = "";
  for (uint8_t i = 0; i < server.args(); i++) {
    message += "[" + server.argName(i) + " : " + server.arg(i) + "]";
  }
  server.send(200, "text/html", SendHTML());
}

//void handle_NotFound() {
//  server.send(404, "text/plain", "Not found");
//}

String SendHTML() {
  String ptr = "<!DOCTYPE html> <html>\n";
  ptr += "<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, user-scalable=no\">\n";
  ptr += "<title>Anignora Alarm</title>\n";
  ptr += "<style>html { font-family: Helvetica; display: inline-block; margin: 0px auto; text-align: center;}\n";
  ptr += "body{margin-top: 20px;} h1 {color: #444444;margin: 20px auto 20px;} h3 {color: #444444;margin-bottom: 20px;}\n";
  ptr += ".button {display: block;width: 80px;background-color: #1abc9c;border: none;color: white;padding: 13px 10px;text-decoration: none;font-size: 25px;margin: 0px auto 15px;cursor: pointer;border-radius: 4px;}\n";
  ptr += ".button-on {background-color: #1abc9c;}\n";
  ptr += ".button-on:active {background-color: #16a085;}\n";
  ptr += ".button-off {background-color: #34495e;}\n";
  ptr += ".button-off:active {background-color: #2c3e50;}\n";
  ptr += "p {font-size: 12px;color: #888;margin-bottom: 2px;}\n";
  ptr += "</style>\n";
  ptr += "<META http-equiv=\"refresh\" content=\"3;URL=/\">";
  ptr += "</head>\n";
  ptr += "<body>\n";
  ptr += "<h1>Anignora Alarm</h1>";

  ptr += "[" + message + "] [trigger count: " + String(triggerCnt) + "]";

  String playingStatus = playerState == 513 ? "Playing" : "Stoped";
  ptr += "[playerState: " + playingStatus +  " " + String(playCnt / 10) + " sec";

  String active_A_text = state_A ? "ON" : "OFF";
  String button_A_style = state_A ? "button-on" : "button-off";
  String active_B_text = state_B ? "ON" : "OFF";
  String button_B_style = state_B ? "button-on" : "button-off";

  ptr += "<p><h3> </h3></p><a class=\"button button-on\" href=\"/\">Home</a> \n";
  ptr += "<p><h3>System Status</h3></p> <a class=\"button " + button_A_style + "\" href=\"/button_A_clicked\">" + active_A_text + "</a> \n";
  ptr += "<p><h3>Panic</h3></p> <a class=\"button " + button_B_style + "\" href=\"/button_B_clicked\">" + active_B_text + "</a> \n";

  ptr += "</body>\n";
  ptr += "</html>\n";
  return ptr;
}
