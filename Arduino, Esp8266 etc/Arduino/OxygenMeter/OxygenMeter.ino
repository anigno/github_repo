#include <Wire.h>
#include <LCD.h>
#include <LiquidCrystal_I2C.h>

#define I2C_ADDR    0x27
#define BACKLIGHT_PIN     3
#define En_pin  2
#define Rw_pin  1
#define Rs_pin  0
#define D4_pin  4
#define D5_pin  5
#define D6_pin  6
#define D7_pin  7
LiquidCrystal_I2C  lcd(I2C_ADDR, En_pin, Rw_pin, Rs_pin, D4_pin, D5_pin, D6_pin, D7_pin);

#define SENSOR A1
#define SAMPLE PD6 //dammy for simulate low voltage
#define MIN_OXY A2
#define MAX_OXY A3
#define ERROR_PIN 3

#define SENSOR_RATIO 98
#define INIT_COUNT 9
float vSensor = 0.0;

float initValue = 0.0;
float calcValue[5] = {0, 0, 0, 0, 0};
int calcCnt = 0;

bool togle = false;

void lcdPrint(int x, int y, char* text)
{
  lcd.setCursor(x, y);
  lcd.print(text);
}

void lcdPrint(int x, int y, float f, int d)
{
  lcd.setCursor(x, y);
  lcd.print(f, d);
}

float getSensorMv()
{
  int sensor = analogRead(SENSOR);
  float sensorMv = 1000.0 * sensor / 1024 * 5 / SENSOR_RATIO;
  return sensorMv;
}

float calcAverage(float* fa, int l)
{
  float sum = 0;
  for (int i = 0; i < l; i++)
  {
    sum += fa[i];
  }
  return sum / l;
}

void setup()
{
  Serial.begin(115200);
  Serial.println("");
  Serial.println("setup...");
  pinMode(SENSOR, INPUT);
  pinMode(SAMPLE, OUTPUT);
  pinMode(MIN_OXY, INPUT);
  pinMode(MAX_OXY, INPUT);

  analogWrite(SAMPLE, 180);

  lcd.begin (16, 2);
  lcd.setBacklightPin(BACKLIGHT_PIN, POSITIVE);
  lcd.setBacklight(HIGH);

  lcdPrint(0, 0, "Oxygen Sensor");
  lcdPrint(0, 1, "init...");

  for (int a = INIT_COUNT; a > 0; a--)
  {
    lcdPrint(15, 0, a, 0);
    vSensor = getSensorMv();
    initValue += vSensor;
    lcdPrint(8, 1, vSensor, 2); lcd.print("mv        ");
    delay(500);
  }

  initValue = initValue / INIT_COUNT;
  lcd.clear();
  lcdPrint(0, 0, "20.9%=");
  lcd.print(initValue, 1);
  lcd.print("mv");
}


void loop()
{
  Serial.println("loop...");
  togle = !togle;

  float sensorMv = getSensorMv();
  float oxyRead = 20.9 / initValue * sensorMv;

  calcValue[calcCnt] = oxyRead;
  calcCnt++; if (calcCnt >= 5)calcCnt = 0;
  float oxy = calcAverage(calcValue, 5);
  Serial.println(oxy);

  int min = map(analogRead(MIN_OXY), 0, 1023, 0, 100);
  int max = map(analogRead(MAX_OXY), 0, 1023, 0, 100);

  bool inRange = (oxy >= min && oxy <= max);
  if (!inRange)
  {
    digitalWrite(ERROR_PIN, HIGH);
    lcdPrint(13, 0, "   ");
    if (togle)lcdPrint(13, 0, "ERR");
  }
  else
  {
    digitalWrite(ERROR_PIN, LOW);
    lcdPrint(13, 0, " OK ");
  }
  lcdPrint(0, 1, oxy, 1);
  lcd.print("% (");
  lcd.print(min);
  lcd.print("%-");
  lcd.print(max );
  lcd.print("%)   ");
  delay(500);
}
