#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x3f, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE); 
int phase=0;
float minBat=99.0;
float idleBat=12.5;
int cIdleBat=1;
int cIdleBatMax=100;
float tIdleBat=0;
float startBat=99;

float readBattery(){
  return analogRead(A0)*0.01515;
}

void lcdClear(int x,int y,int spaces){
  lcd.setCursor(x,y);
  for(int a=0;a<spaces;a++)lcd.print(" ");
}

void setup() 
{
  lcd.begin(16,2);//Defining 16 columns and 2 rows of lcd display
  pinMode(A0,INPUT);
  lcd.setCursor(0,0);
  lcd.print("1-Connect to BAT");
  lcd.setCursor(0,1);
  lcd.print("2-Start motor");
  delay(2000);
  lcd.clear();
}

void loop()
{
  float vBat=readBattery();
  if(phase==0){
      lcd.setCursor(0,0);
      lcd.print("I ");
      lcdClear(2,0,6);      
      lcd.setCursor(2,0);
      lcd.print(idleBat);
      lcd.print("v");
      delay(100);
      if(vBat<11.8)
      {
        phase=1;
        int batPer=idleBat*125-1475;
        if(batPer<0)batPer=0;
        if(batPer>99)batPer=99;
        lcd.setCursor(9,0);
        lcd.print(batPer);
        lcd.print("%");
      }
      else{
        tIdleBat=idleBat*cIdleBat;
        cIdleBat++;
        tIdleBat+=vBat;
        idleBat=tIdleBat/cIdleBat;
      }
  }
  if(phase==1){
      if(minBat>vBat)minBat=vBat;
      lcd.setCursor(0,1);
      lcd.print("S ");
      lcdClear(2,1,6);      
      lcd.setCursor(2,1);
      lcd.print(startBat);
      lcd.print("v");
      delay(10);
      if(vBat>idleBat)
      {
        phase=2;
        lcd.setCursor(13,0);
        if(minBat>=10)
          lcd.print("V");
         else
          lcd.print("X");
      }
      else
        startBat=minBat;  
  }
  if(phase==2){
      lcd.setCursor(9,1);
      lcd.print("C");
      lcdClear(10,1,6);      
      lcd.setCursor(10,1);
      lcd.print(vBat);
      lcd.print("v");
      delay(250);
      lcd.setCursor(15,0);
      if(vBat>=13.7)
        lcd.print("V");
       else
        lcd.print("X");
  }
}
  
  
