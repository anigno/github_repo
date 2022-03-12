#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

/* Put your SSID & Password */
const char* ssid = "anigno-hot";  // Enter SSID here
const char* password = "136161271";  //Enter Password here

bool state_A = false;
bool state_B = false;

ESP8266WebServer server(80);

void setup() {
  Serial.begin(115200);         // Start the Serial communication to send messages to the computer
  delay(10);
  Serial.println('\n');

  pinMode(LED_BUILTIN, OUTPUT);

  WiFi.begin(ssid, password);             // Connect to the network
  Serial.print("Connecting to ");
  Serial.print(ssid);
  Serial.println(" ...");

  int i = 0;
  while (WiFi.status() != WL_CONNECTED) { // Wait for the Wi-Fi to connect
    delay(1000);
    Serial.print(++i); Serial.print(' ');
  }

  Serial.println('\n');
  Serial.println("Connection established!");
  Serial.print("IP address:\t");
  Serial.println(WiFi.localIP());         // Send the IP address of the ESP8266 to the computer

  delay(100);

  server.on("/", handle_OnHome);
  server.on("/button_A_clicked", handle_button_A_clicked);
  server.on("/button_B_clicked", handle_button_B_clicked);
  server.onNotFound(handle_NotFound);

  server.begin();
  Serial.println();
  Serial.println("HTTP server started");
}

void loop() {
  server.handleClient();
}

void handle_OnHome() {
  server.send(200, "text/html", SendHTML());
  Serial.println("OnHome");
}

void handle_button_A_clicked() {
  state_A = !state_A;
  server.send(200, "text/html", SendHTML());
}

void handle_button_B_clicked() {
  state_B = !state_B;
  server.send(200, "text/html", SendHTML());
}

void handle_NotFound() {
  server.send(404, "text/plain", "Not found");
}

String SendHTML() {
  String ptr = "<!DOCTYPE html> <html>\n";
  ptr += "<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, user-scalable=no\">\n";
  ptr += "<title>Anignora Alarm</title>\n";
  ptr += "<style>html { font-family: Helvetica; display: inline-block; margin: 0px auto; text-align: center;}\n";
  ptr += "body{margin-top: 50px;} h1 {color: #444444;margin: 50px auto 30px;} h3 {color: #444444;margin-bottom: 50px;}\n";
  ptr += ".button {display: block;width: 80px;background-color: #1abc9c;border: none;color: white;padding: 13px 30px;text-decoration: none;font-size: 25px;margin: 0px auto 35px;cursor: pointer;border-radius: 4px;}\n";
  ptr += ".button-on {background-color: #1abc9c;}\n";
  ptr += ".button-on:active {background-color: #16a085;}\n";
  ptr += ".button-off {background-color: #34495e;}\n";
  ptr += ".button-off:active {background-color: #2c3e50;}\n";
  ptr += "p {font-size: 14px;color: #888;margin-bottom: 10px;}\n";
  ptr += "</style>\n";
  ptr += "<META http-equiv=\"refresh\" content=\"5;URL=/\">"; 
  ptr += "</head>\n";
  ptr += "<body>\n";
  ptr += "<h1>Anignora Alarm</h1>\n";

  int led = state_A || state_B ? LOW : HIGH;
  digitalWrite(LED_BUILTIN, led);

  String active_A_text = state_A ? "ON" : "OFF";
  String button_A_style = state_A ? "button-on" : "button-off";
  String active_B_text = state_B ? "ON" : "OFF";
  String button_B_style = state_B ? "button-on" : "button-off";

  ptr += "<p>Home</p> <a class=\"button button-on\" href=\"/\">Home</a> \n";

  ptr += "<p>System Status</p> <a class=\"button " + button_A_style + "\" href=\"/button_A_clicked\">" + active_A_text + "</a> \n";
  ptr += "<p>Panic</p> <a class=\"button " + button_B_style + "\" href=\"/button_B_clicked\">" + active_B_text + "</a> \n";

  ptr += "</body>\n";
  ptr += "</html>\n";
  return ptr;
}
