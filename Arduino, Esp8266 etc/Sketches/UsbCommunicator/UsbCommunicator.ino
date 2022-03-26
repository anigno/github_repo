
String inputString = "";

void Echo(String p_s,String p_d){
  Serial.print("ECHO: "+p_s+"="+p_d+"@");
}




void Parse(String p_s){
  Echo("Command","******"+p_s+"******");
  String sPinNumber=p_s.substring(2,4);
  int pinNumber=sPinNumber.toInt();
  Echo("PinNumber",String(pinNumber));
  switch(p_s[0]){
    //Set pin mode
  case 'S':  
    {
      char sIo=p_s[5];
      Echo("IO",String(sIo));
      if(sIo=='O'){
        pinMode(pinNumber,OUTPUT);
      }
      else{
        pinMode(pinNumber,INPUT);
      }
    }
    break;
    //Write analog data 0-255
  case 'a':
    {
      String sValue=p_s.substring(5,9);
      int value=sValue.toInt();
      Echo("Value",String(value));
      analogWrite(pinNumber,value);
    }
    break;
    //Write digital data 0/1
  case 'd':
    {
      String sValue=p_s.substring(5,9);
      int value=sValue.toInt();
      Echo("Value",String(value));
      digitalWrite(pinNumber,value);
    }
    break;
    //Read analog data 0-1023
  case 'A':
    {
      int value=analogRead(pinNumber);
      Echo("ValueRead Analog Pin=[#]"+String(pinNumber)+"[#] Value","[#]"+String(value)+"[#]");
    }
    break;
    //Read digital data 0/1
  case 'D':
    {
      int value=digitalRead(pinNumber);
      Echo("ValueRead Digital Pin=[#]"+String(pinNumber)+"[#] Value","[#]"+String(value)+"[#]");
    }
    break;
    default:
      Echo("SimpleEcho","SimpleEcho");
    break;
  }
}








void setup() {
  Serial.begin(9600);     
  inputString.reserve(200);
}







long ledLightCounter=0;

void loop() {
  while (Serial.available()) {
    char inChar = (char)Serial.read(); 

    if (inChar == '\n') {
      Parse(inputString);
      inputString="";
    }
    else{
      inputString += inChar;
    }
  }
  delay(1);
  if(ledLightCounter++%1000<800){
  digitalWrite(13,1);
}
else{
  digitalWrite(13,0);
}
if(ledLightCounter>1000000)ledLightCounter=0;
}



















