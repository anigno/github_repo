#include <AnignoLibrary.h>
#include <VirtualWire.h>

void setup()

{
  pinMode(13,OUTPUT);
    vw_set_ptt_inverted(true);  // Required by the RF module
    vw_setup(2000);            // bps connection speed
    vw_set_tx_pin(3);         // Arduino pin to connect the receiver data pin
}

bool bLed=false;
int cnt=1000;
void loop()
{
   //Message to send:
  //const char *msg = "This is an RF Transmission.";
  
  String sMsg="Hello:";
  String sCnt=String(cnt++);
  sMsg=sCnt;
  char msg[sizeof(sMsg)];
  sMsg.toCharArray(msg,sizeof(sMsg));
  
   vw_send((uint8_t *)msg, strlen(msg));
   vw_wait_tx();        // We wait to finish sending the message
   delay(500);         // We wait to send the message again                
   digitalWrite(13,bLed);
   bLed=!bLed;
}
