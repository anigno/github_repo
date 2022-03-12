//arduino nano
//SCL A5      
//SDA A4      
//VCC 5v (A3)
//Gnd GND (A2)

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

int address=0x27; //could be 0x27 or 0x3f, use i2c scanner and connect scl sda to arduino scl sda
LiquidCrystal_I2C lcd(address,16,2);  // set the LCD address to 0x27 for a 16 chars and 2 line display

void setup()
{
  pinMode(A3,OUTPUT);
  pinMode(A2,OUTPUT);
  pinMode(12,OUTPUT);
  pinMode(11,OUTPUT);

  digitalWrite(A3,HIGH);
  digitalWrite(A2,LOW);

  pinMode(A1,INPUT);    //sensor
  digitalWrite(12,HIGH);
  digitalWrite(11,LOW);

  
  lcd.init();                      // initialize the lcd 
  lcd.backlight();
  lcd.setCursor(1,0);
  lcd.print("hello everyone");
  lcd.setCursor(1,1);
  lcd.print("   anignora");
}

int b=0;
void loop()
{
  delay(1000);
  lcd.setCursor(1,1);
  lcd.print(b++);
}
