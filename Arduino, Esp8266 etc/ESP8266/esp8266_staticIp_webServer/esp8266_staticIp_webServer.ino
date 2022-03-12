#include <ESP8266WiFi.h>
//#include <WiFiClient.h>
#include <ESP8266WebServer.h>
//#include <ESP8266mDNS.h>
//#include <WiFiUdp.h>

long counter=0;

//static IP for soft-AP
IPAddress local_IP(192,168,4,22);
IPAddress gateway(192,168,4,10);
IPAddress subnet(255,255,255,0);

//web server
ESP8266WebServer server(80);

void handleRoot() {
  String message="anignora security server\n";
  message+="sensor?id=323&status=(false|true)&sensorCnt=34567\n";
  server.send(200, "text/plain", message);
}

void handleNotFound(){
  String message="anignora security server\n";
  message+="Not found\n";
  server.send(404, "text/plain", message);
}

void handleSensor() {
  String message = "Sensor data\n";
  message += "local counter= "+String(counter);
  message += "\nURI: ";
  message += server.uri();
  message += "\nMethod: ";
  message += (server.method() == HTTP_GET) ? "GET" : "POST";
  message += "\nArguments: ";
  message += server.args();
  message += "\n";
  for (uint8_t i = 0; i < server.args(); i++) {
    message += " " + server.argName(i) + ": " + server.arg(i) + "\n";
  }
  server.send(200, "text/plain", message);
}

void setup()
{
  Serial.begin(115200);
  Serial.println();
  
  //sof-AP static IP
  Serial.print("starting soft-AP");
  WiFi.softAPConfig(local_IP, gateway, subnet);
  WiFi.softAP("ag-security","136161271",1,false,8);
  Serial.printf("Soft-AP started, web server: %s:80\n",WiFi.softAPIP().toString().c_str());

  //web server
  server.on("/", handleRoot);
  server.on("/sensor", handleSensor);
  server.onNotFound(handleNotFound);
  server.begin();
  Serial.println("HTTP server started");

  
}

void loop() 
{
  counter++;
  server.handleClient();
  delay(10);
 
}
