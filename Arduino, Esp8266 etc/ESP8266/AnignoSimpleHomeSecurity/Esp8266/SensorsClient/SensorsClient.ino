#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266HTTPClient.h>
#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266HTTPClient.h>
#include <WiFiClient.h>

//#define DISTANCE
#define PIR

const char* ssid = "anigno-hot";  // Enter SSID here
const char* password = "136161271";  //Enter Password here
const char* SERVER_IP = "192.168.1.17";

int resetCounter = 10*60*10;  //reset every 10 minutes

ESP8266WiFiMulti WiFiMulti;

void setup() {
  Serial.begin(115200);
  Serial.println();
  Serial.println("setup");

  pinMode(5, OUTPUT); //ping
  pinMode(4, INPUT);  //echo

  pinMode(D0, INPUT); //PIR

  WiFi.mode(WIFI_STA);
  WiFiMulti.addAP(ssid, password);
  while ((WiFiMulti.run() != WL_CONNECTED)) {
    Serial.print(".");
    delay(1000);
  }
  Serial.print("Connected as: "); Serial.println(WiFi.localIP());
  Serial.print("Server IP: "); Serial.println(SERVER_IP);
}

void SendTrigger(char* triggerName) {
  WiFiClient client;
  HTTPClient http;
  String url;
  url += "http://" + String(SERVER_IP) + "/trigger?Trigger=";
  url += triggerName;
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


float calcAverage(float* fa, int l)
{
  float sum = 0;
  for (int i = 0; i < l; i++)
  {
    sum += fa[i];
  }
  return sum / l;
}

float calcValue[20] = {400, 400, 400, 400, 400, 400, 400, 400, 400, 400,
                       400, 400, 400, 400, 400, 400, 400, 400, 400, 400
                      };
int calcCnt = 0;

int usPingPin = 5;
int ucEchoPin = 4;

int pirCnt = 0;


void loop() {
# ifdef DISTANCE
  //distance measure
  digitalWrite(usPingPin, LOW);
  delayMicroseconds(2);
  digitalWrite(usPingPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(usPingPin, LOW);
  pinMode(ucEchoPin, INPUT);
  int duration = pulseIn(ucEchoPin, HIGH);
  int distanceCm = duration / 29 / 2;

  calcValue[calcCnt] = distanceCm;
  calcCnt++; if (calcCnt >= 20)calcCnt = 0;
  float distanceAvg = calcAverage(calcValue, 20);

  if (distanceAvg < 200) {
    SendTrigger("Distance");
    //init distance average array
    for (int i = 0; i < 20; i++)calcValue[i] = 500;
  }
  Serial.printf("read: %d avg: %f rstCnt: %d \n", distanceCm, distanceAvg,resetCounter);
  ///////////////////
#endif

#ifdef PIR
  //PIR //////
  int pir = digitalRead(D0);
  if (pir == 1) {
    pirCnt++;
    if (pirCnt > 10) {
      SendTrigger("PIR");
      pirCnt=0;
    }
  } else {
    pirCnt = 0;
  }
  Serial.printf("PIR: %d pirCnt: %d rstCnt: %d\n", pir, pirCnt,resetCounter); 
  ////////
#endif
  delay(100);
  if (resetCounter-- <=0){
    ESP.restart();
  }

}
