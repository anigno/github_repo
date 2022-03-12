/*
 p0 - 0
 p1 - 1
 p2 - A1
 p3 - A3
 p4 - A2
 p5 - A0
 */

void beep(int msOn,int msOff){
  digitalWrite(0, HIGH);
  delay(msOn);
  digitalWrite(0, LOW);
  delay(msOff);
}

void setup() {                
  pinMode(0, OUTPUT); //buzzer vcc,
  pinMode(1, OUTPUT); //LED on model A
  pinMode(3, OUTPUT); //buzzer zero
  pinMode(A0, INPUT);  //first cell voltage
  //digitalWrite(3, HIGH);  //silent buzzer
  digitalWrite(3, LOW); //on buzzer
}

int cnt=60;
bool led=HIGH;

void loop() {
  beep(180-cnt,200+cnt);
  beep(100-cnt,500+cnt);
  for(int a=0;a<cnt*2;a++){
    digitalWrite(1, led);
    led=!led;
    delay(500);
  }
  cnt--;
  if(cnt<10)cnt=10;
}
