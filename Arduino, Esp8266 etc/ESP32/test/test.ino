void setup() {
  // put your setup code here, to run once:
Serial.begin(115200);
  //Serial.setDebugOutput(true);
  Serial.println();
}
int a;
void loop() {
  // put your main code here, to run repeatedly:
Serial.println("12345abcde");
Serial.println(a++);
delay(1000);
}
