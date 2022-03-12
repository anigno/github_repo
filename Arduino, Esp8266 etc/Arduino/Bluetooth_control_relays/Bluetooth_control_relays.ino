
#include <SoftwareSerial.h>
int receivedval;
SoftwareSerial mySerial(10,11); // RX, TX
//RX on Bluetooth to TX on uC

void setup()
{
  pinMode(4, OUTPUT);
  pinMode(5, OUTPUT);
  mySerial.begin(57600);
  Serial.begin(9600);
  Serial.println("Starting");
}


void loop() { 
  if (mySerial.available()) {
    byte b=mySerial.read();
    Serial.println(b);
    if(b==49)digitalWrite(4,HIGH);
    if(b==50)digitalWrite(4,LOW); 
    if(b==51)digitalWrite(5,HIGH);
    if(b==52)digitalWrite(5,LOW);
    
  }
 
}


