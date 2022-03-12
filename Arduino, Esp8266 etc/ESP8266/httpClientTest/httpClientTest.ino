#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266HTTPClient.h>
#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>

ESP8266WiFiMulti WiFiMulti;
const char* ssid = "anigno-hot";  // Enter SSID here
const char* password = "136161271";  //Enter Password here

void setup() {
  Serial.begin(115200);
  Serial.println();
  Serial.println("setup");

  pinMode(4, INPUT);
  pinMode(5, OUTPUT);

  WiFi.mode(WIFI_STA);
  WiFiMulti.addAP(ssid, password);
  while ((WiFiMulti.run() != WL_CONNECTED)) {
    Serial.print(".");
    delay(1000);
  }
  Serial.print("Connected as: "); Serial.println(WiFi.localIP());
}

void SendTrigger(char* triggerName) {
  WiFiClient client;
  HTTPClient http;
  String url;
  url+="http://192.168.1.17/trigger?Trigger=";
  url+=triggerName;
  if (http.begin(client, url)) {
    int httpCode = http.GET();
    if (httpCode < 0) {
      Serial.printf("[HTTP] GET... failed, error: %s\n", http.errorToString(httpCode).c_str());
    } else {
      Serial.printf("[HTTP] GET... code: %d\n", httpCode);
      if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
        String payload = http.getString();
        //Serial.println(payload);
      }
    }
    http.end();
  } else {
    Serial.printf("[HTTP} Unable to connect\n");
  }
}

void loop() {


//  SendTrigger("testTrigger");
//  delay(6000);


}
