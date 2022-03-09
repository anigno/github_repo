void setup() {
  pinMode(13,OUTPUT);
}

void loop() {
  analogWrite(13,0);
  delay(300);
  analogWrite(13,255);
  delay(700);
  
}
