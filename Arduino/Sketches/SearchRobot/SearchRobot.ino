#include <Servo.h>
#include <AnignoLibrary.h>
#include <AnignoraDcMotor.h>

AnignoLibrary aLib;

  Servo searchServo;
  AnignoraDcMotor adm(3,4,6,7,2,150);

  int pinSonicTrig=8;
  int pinSonicEcho=9;
  int pinSearchServo=12;
  int pinSearchServoEnable=10;
 
  int minDistance=20;
  int searchServoSteps=3;
  int searchServoDirection=-1;
  int searchServoCenter=37;
  int searchServoBoundries=20;
  
  int driveBackDelay=500;
  int driveBackDirectionDelay(250);

void setup() 
{
  Serial.begin(9600);
  pinMode(pinSonicTrig,OUTPUT);
  pinMode(pinSonicEcho,INPUT);
  pinMode(pinSearchServo,OUTPUT);
  pinMode(pinSearchServoEnable,INPUT);
 searchServo.attach(pinSearchServo);
}

void loop() 
{
  adm.driveFwd();
  //Sonic distance servo operation
  bool servoEnable=digitalRead(pinSearchServoEnable);
    int servoPos=searchServo.read();
  if(servoEnable)
  {
    aLib.SerialPrintlnValue("servoPos",servoPos,"digrees");
    if(servoPos<=searchServoCenter-searchServoBoundries)searchServoDirection=1;
    if(servoPos>=searchServoCenter+searchServoBoundries)searchServoDirection=-1;
    searchServo.write(servoPos+searchServoDirection*searchServoSteps);
  }
  else
  {
    searchServo.write(searchServoCenter);
  }
  //Distance detection operations
  int distance=aLib.GetSonicDistanceCm(pinSonicTrig,pinSonicEcho,100);
  aLib.SerialPrintlnValue("Distance",distance,"cm");
  if(distance<minDistance)
  {
    aLib.SerialPrintlnValue("servoPos",servoPos,"digrees");
    if(servoPos<searchServoCenter)    adm.driveBckRt();
    if(servoPos>searchServoCenter)    adm.driveBckLt();
    delay(driveBackDelay);
  }
 
  delay(100);
}
