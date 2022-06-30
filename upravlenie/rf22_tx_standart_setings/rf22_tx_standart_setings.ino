// http)//www.airspayce.com/mikem/arduino/RF22/classRF22.html#a76cd019f98e4f17d9ec00e54e5947ca1ae77ddcf9d0f51b0e9731e00dfcaebc20

#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);

char _buffer[64];
int i = 0;

bool flag = false;

int tryToInitRF22()
{
  int _status = rf22.init();
  return _status;
}

void setup() 
{
  Serial.begin(9600);
  if (!tryToInitRF22())
  {
    Serial.println("rf22 tx conn bad try again");
    while(!tryToInitRF22())
    {
      Serial.println("rf22 tx conn bad try again");
    }
  }
  else
  {
    Serial.println("rf22 tx conn good");
  }

  

    rf22.setTxPower(RH_RF22_TXPOW_11DBM);
    rf22.setFrequency(466.00);
    rf22.setModemConfig(RH_RF22::GFSK_Rb2_4Fd36);
    Serial.println("ready...");
}

void loop() 
{
    "180,900|;"//  if (Serial.available())
  {
    _buffer[i] = Serial.read();
    if (_buffer[i] == ';')
    {
      flag = true;
    }
    i++;
  }

  if (flag)
  {
    flag = false;
    for (int j = 0; j < sizeof(_buffer); j++)
    {
      if (_buffer[j] == ';')
      {
        i = j;
        break;
      }
    }
    char _cbuffer11[i];
    for (int j = 0; j < i+1; j++)
    {
      _cbuffer11[j] = _buffer[j];
    }
    rf22.send(_cbuffer11, sizeof(_cbuffer11));
    rf22.waitPacketSent();
    i = 0;
  }



}
