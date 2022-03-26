#include <Arduino.h>
#include "AnignoLibrary.h"


String AnignoLibrary::GetString(double d,int p)
{
  int d1=d*pow(10,p);
  int i=int(d);
  int i1=i*pow(10,p);
  int i2=d1-i1;
  String s=String(i)+"."+String(i2);
  return s;
}

float AnignoLibrary::GetFloatAverage(float floats[],int nFloats)
{
  float sum=0;
  for(int a=0;a<nFloats;a++)
  {
    sum+=floats[a];
  }
  return sum/nFloats;
}

int AnignoLibrary::GetSonicDistanceCm(int trigPin,int echoPin,int maxLimitCm)
{
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(100);
  digitalWrite(trigPin, LOW);
  int duration = pulseIn(echoPin, HIGH);
  int distance = (duration/2) / 29.1;
  distance=constrain(distance,2,maxLimitCm);
  return distance;
} 

void AnignoLibrary::SerialPrintlnValue(String name,float value,String units)
{
  Serial.print(name+"=");
  Serial.print(value);
  Serial.println(" "+units);
} 