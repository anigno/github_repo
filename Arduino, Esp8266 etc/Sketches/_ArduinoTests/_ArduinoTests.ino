#include <AnignoLibrary.h>

void setup() 
{
  Serial.begin(9600);
}

AnignoLibrary al;


void loop() 
{
  String s="Hello ";
  Serial.println(s);
  
  String s1="World ";
  s+=s1;
  Serial.println(s);
  
  String s2=al.GetString(123.45,3);
  s+=s2;
  Serial.println(s);
  
  String s3=String(67);
  s+=s3;
  Serial.println(s);
  
  
  al.SerialPrintlnValue("1",3.1415,"3");
  
  delay(500);
}
