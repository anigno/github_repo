//O led está no GPIO14
#define LED 2
//ou usar a constante D5 que já está definida
//#define LED D5
 
void setup() {
  pinMode(LED, FUNCTION_3);
}
 
void loop() {
  digitalWrite(LED, HIGH);
  delay(1000);
  digitalWrite(LED, LOW);
  delay(1000);
}
