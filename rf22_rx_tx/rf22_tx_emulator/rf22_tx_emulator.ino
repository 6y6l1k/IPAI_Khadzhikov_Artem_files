#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);

#include <SoftwareSerial.h>
SoftwareSerial gps(6, 5);

unsigned long Timer = 0;
int i = 0;
int j = 0;
char _buffer[64];
bool flag = false;

void setup() 
{
  Serial.begin(9600);
  gps.begin(9600);
  rf22.init();

 

  rf22.setTxPower(RH_RF22_TXPOW_11DBM);
  rf22.setFrequency(466.0);
  rf22.setModemConfig(RH_RF22::FSK_Rb125Fd125); 
}

void loop() 
{
  if (gps.available())
  {
    _buffer[i] = gps.read();
    if (_buffer[i] == ';')
    {
      flag = true;
      j = i;
    }
    i++;
  }

  if (flag)
  {
    i = 0;
    flag = false;
    char _cbuffer[j+1];
    //Serial.print("debug: ");
    for (int k = 0; k < j+1; k++)
    {
      _cbuffer[k] = (char)_buffer[k];
      //erial.print(_cbuffer[k]);
    }
    //Serial.println();
    rf22.send(_cbuffer, sizeof(_cbuffer));
    rf22.waitPacketSent();
  }
  
}
