//arduino nano    leonardo
//SCL A5          3
//SDA A4          2
//VCC 5v
//Gnd GND


int address=0x27; //could be 0x3f, use i2c scanner and connect scl sda to arduino scl sda

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(address,16,2);  // set the LCD address to 0x27 for a 16 chars and 2 line display

void setup()
{
  lcd.init();                      // initialize the lcd 
//  lcd.init();
  // Print a message to the LCD.
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
