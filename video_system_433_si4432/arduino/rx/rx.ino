
#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);

int i = 0;
int p = 0;

void setup() 
{
  Serial.begin(115200);
  rf22.init();
  //if (!rf22.init())
    //Serial.println("rf22 rx conn bad");
  //else
    //Serial.println("rf22 rx conn good");

  rf22.setTxPower(RH_RF22_TXPOW_20DBM);
  rf22.setFrequency(466.00);
  rf22.setModemConfig(RH_RF22::GFSK_Rb125Fd125);

 
  
}

void loop() 
{
  if (rf22.available())
  {
    uint8_t buf[RH_RF22_MAX_MESSAGE_LEN];
    uint8_t len = sizeof(buf);

    rf22.recv(buf, &len);

    for (int j = 0; j < sizeof(buf); j++)
    {
      char c = (char) buf[j];
      Serial.write(c);
      if (c == ';')
      {
        //Serial.write('\n');
        break;
      }
    }
    //p++;
    //Serial.write(p);
    


  }
}
