void SerialPrintlnValue(String name,float value,String units)
{
  Serial.print(name+"=");
  Serial.print(value);
  Serial.println(" "+units);
}

float GetFloatAverage(float floats[],int nFloats)
{
  float sum=0;
  for(int a=0;a<nFloats;a++)
  {
    sum+=floats[a];
  }
  return sum/nFloats;
}

int GetSonicDistanceCm(int trigPin,int echoPin,int maxLimitCm)
{
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(100);
  digitalWrite(trigPin, LOW);
  int duration = pulseIn(echoPin, HIGH);
  int distance = (duration/2) / 29.1;
  distance=constrain(distance,2,maxLimitCm);
  return distance;
}

//****** Pins decleration ******
int ledPin=13;
int sonicTrigPin=7;
int sonicEchoPin=8;
int lightMeasurePin=5;
int noLightOutPin=10;
int minDistanceOutPin=11;
int noLightTrigger=500;
int minDistanceTriggerCm=100;
boolean ledState=LOW;


//************************************************************
void setup() 
{
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
  pinMode(sonicTrigPin,OUTPUT);
  pinMode(sonicEchoPin,INPUT);
  pinMode(lightMeasurePin,INPUT);
  pinMode(noLightOutPin,OUTPUT);
  pinMode(minDistanceOutPin,OUTPUT);
  pinMode(10,OUTPUT);
}
//************************************************************


//************************************************************
void loop() 
{
  int sonicDistanceCm=GetSonicDistanceCm(sonicTrigPin,sonicEchoPin,340);
  SerialPrintlnValue("SonicDistance",sonicDistanceCm,"cm");
  int lightMeasure=analogRead(lightMeasurePin);
  SerialPrintlnValue("LightMeasure",lightMeasure,"units/1023");
  
  boolean noLightTriggerValue=lightMeasure<noLightTrigger;
  boolean minDistanceTriggerCmValue=sonicDistanceCm<minDistanceTriggerCm;
  SerialPrintlnValue("noLightTriggerValue",noLightTriggerValue,"On/Off");
  SerialPrintlnValue("minDistanceTriggerCmValue",minDistanceTriggerCmValue,"On/Off");
    
  digitalWrite(noLightOutPin,noLightTriggerValue);
  digitalWrite(minDistanceOutPin,minDistanceTriggerCmValue);
  
  //****** Operation LED ******
  digitalWrite(ledPin,ledState);
  ledState=!ledState;
  delay(500);
  //****** Operation LED ******

}
//************************************************************

