#include <AnignoLibrary.h>

AnignoLibrary al;

void setup() 
{
  Serial.begin(9600);
  pinMode(2,OUTPUT);  
  pinMode(3,OUTPUT);  
  pinMode(4,OUTPUT);  
  pinMode(8,OUTPUT);  
  pinMode(9,INPUT);  
}

int maxDistance=100;

void loop() 
{
  int distance=al.GetSonicDistanceCm(8,9,maxDistance);
  al.SerialPrintlnValue("Distance",distance,"cm");
  int trig=map(distance,0,maxDistance,0,2);
  al.SerialPrintlnValue("trig",trig,"");

  digitalWrite(2,LOW);
  digitalWrite(3,LOW);
  digitalWrite(4,LOW);
  
  switch(trig)
  {
    case 0:
    digitalWrite(2,HIGH);
    break;
    case 1:
    digitalWrite(3,HIGH);
    break;
    case 2:
    digitalWrite(4,HIGH);
    break;
  }
  delay(500);
  
}
