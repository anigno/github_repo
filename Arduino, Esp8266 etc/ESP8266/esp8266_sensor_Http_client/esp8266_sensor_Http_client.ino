#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>

long counter=0;
const char* ssid = "ag-security";
const char* password = "136161271";
const char* SENSOR_ID="SENSOR_A";

//esp201
int adcInPin=17;
int digitalInPin=5;


void setup () {
  Serial.begin(115200);

  pinMode(adcInPin,INPUT);
  pinMode(digitalInPin,INPUT);
 
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.print("Connecting..");
  }
}
 
void loop() {
  if (WiFi.status() == WL_CONNECTED) { 
    //build sensors data
    int analog01=analogRead(adcInPin);
    bool bool02=digitalRead(digitalInPin);
    String message="http://192.168.4.22/sensor?";
    message+="ID="+String(SENSOR_ID);
    message+="&VALUE_0="+String(analog01);
    message+="&VALUE_1="+String(bool02);    
    message+="&SensorCounter="+String(counter++);
    
    HTTPClient http;
    http.begin(message);  
    int httpCode = http.GET();                                                                
    if (httpCode > 0) {
    String payload = http.getString();  
    Serial.println(payload);                    
  }
  http.end();   //Close connection
  }else{
    //reconnect?
  }
  delay(4000);   
 
}
