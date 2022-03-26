#include <Servo.h>

Servo servo1;

void setup() 
{
  pinMode(14,INPUT);
  servo1.attach(12);  
  Serial.begin(9600);
}

void loop() 
{
  int input=  analogRead(14);  //analog in A5
  int output=map(input,0,1023,0,160);
  Serial.println(input);
  Serial.println(output);
  servo1.write(output);
  delay(100);
}
