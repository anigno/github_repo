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
  digitalWrite(1, HIGH);
  delay(msOn);
  digitalWrite(0, LOW);
  digitalWrite(1, LOW);
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

int state=0;
int minCellVoltageRef=715; //3.5v
int cnt=0;
int v=0;

void loop() {
    v=analogRead(A0);
    
    if(state==0){
    state=1;
  }
  
  if(v<minCellVoltageRef){
    state=2;
  }

  if(state==2){
    beep(500,1000);
  }

  if(cnt%10==0){
    int f=(v-minCellVoltageRef)/35;
    for(int a=0;a<=f;a++){
      beep(200,300);
    }
  }

  delay(1000);
  cnt++;

}
