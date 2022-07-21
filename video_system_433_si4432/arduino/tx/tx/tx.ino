#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);

char _sbuffer[64];
int i = 0;

void setup() 
{
  Serial.begin(38400);
  rf22.init();

  rf22.setTxPower(RH_RF22_TXPOW_20DBM);
  rf22.setFrequency(466.00);
  rf22.setModemConfig(RH_RF22::GFSK_Rb125Fd125);
}

void loop() 
{
  if (Serial.available())
  {
    _sbuffer[i] = Serial.read();
    
    if (_sbuffer[i] == ';')
    {
      char _cbuffer[i+1];
      
      for (int j = 0; j < sizeof(_cbuffer); j++)
      {
        _cbuffer[j] = _sbuffer[j];
        //Serial.write(_cbuffer[j]);
      }
      
      rf22.send(_cbuffer, sizeof(_cbuffer));
      rf22.waitPacketSent();

      
      
      Serial.write('0');
      i = -1;
    }
    i++;
  }
}
