//arduino nano
//SCL A5      
//SDA A4      
//VCC 5v (A3)
//Gnd GND (A2)

//sensor A0

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

int address=0x3f; //could be 0x27 or 0x3f, use i2c scanner and connect scl sda to arduino scl sda
LiquidCrystal_I2C lcd(address,16,2);  // set the LCD address to 0x27 for a 16 chars and 2 line display


void setup()
{
  //LCD power and init
  pinMode(A3,OUTPUT);
  pinMode(A2,OUTPUT);
  pinMode(12,OUTPUT);
  pinMode(11,OUTPUT);
  digitalWrite(A3,HIGH);
  digitalWrite(A2,LOW);
  digitalWrite(12,HIGH);
  digitalWrite(11,LOW);
  lcd.init();                      // initialize the lcd 
  lcd.backlight();
  ///////////////////
  
  pinMode(A0,INPUT);    //sensor
  
  lcd.setCursor(1,0);
  lcd.print("Current sensor");
  lcd.setCursor(1,1);
}


void loop()
{
  delay(250);
  int a=analogRead(A0)-435;
  float f=a/11.656;
  lcd.setCursor(1,1);lcd.print(f);lcd.print(" A");
  lcd.print(" %=");lcd.print(a/435.0*100.0);
}
