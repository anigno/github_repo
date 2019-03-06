void SerialPrintlnValue(String name,float value,String units)
{
  Serial.print(name+"=");
  Serial.print(value);
  Serial.println(" "+units);
}

void setup() 
{
  Serial.begin(9600);
  pinMode(0,INPUT);
  pinMode(14,INPUT);
}

int cnt=0;

void loop() 
{
  cnt+=digitalRead(0);
  int val=analogRead(14);
  SerialPrintlnValue("trigger cnt",cnt,"");
  SerialPrintlnValue("sound value",val,"");
  delay(10);
}
