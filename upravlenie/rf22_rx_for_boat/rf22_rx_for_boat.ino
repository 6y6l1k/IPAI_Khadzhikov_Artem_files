#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);

#include <SoftwareSerial.h>
SoftwareSerial uart(4, 3);

unsigned long Timer = 0;

void setup() 
{
  Serial.begin(9600);
  uart.begin(9600);

  if (!rf22.init())
    Serial.println("rf22 rx conn bad");
  else
    Serial.println("rf22 rx conn good");

  rf22.setTxPower(RH_RF22_TXPOW_11DBM);
  rf22.setFrequency(466.0);
  rf22.setModemConfig(RH_RF22::FSK_Rb2_4Fd36); 

  while (!uart.available()) {}
  char c = (char) uart.read();
  if (c == '0')
  {
    //Serial.println("good");
  }
  else
  {
    //Serial.print("bad     ");Serial.println(c);
  }
  
}

void loop() 
{
  if (rf22.available())
  {
     uint8_t buf[RH_RF22_MAX_MESSAGE_LEN];
     uint8_t len = sizeof(buf);
     rf22.recv(buf, &len);
     for (int j = 0; j < len; j++)
     {
      uart.write(buf[j]);
     } 
  }
}
