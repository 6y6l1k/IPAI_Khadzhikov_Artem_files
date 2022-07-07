// http)//www.airspayce.com/mikem/arduino/RF22/classRF22.html#a76cd019f98e4f17d9ec00e54e5947ca1ae77ddcf9d0f51b0e9731e00dfcaebc20

#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);


char _buffer[64];
int i = 0;

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
    //Serial.print("rf22 tx conn bad try again");
    while(!tryToInitRF22())
    {
      //Serial.print("rf22 tx conn bad try again");
    }
  }
  else
  {
    //Serial.print("rf22 tx conn good");
  }

  while (!Serial.available()) {}
  if (Serial.read() == '1')
  {
    Serial.print("ready;");
    delay(1000);
  }
  
  Serial.print("giveSetTxPowerConfig;");
  while (!Serial.available()) { }
  delay(1000);
  while (Serial.available())
  {
    _buffer[i++] = Serial.read();
  }
  _buffer[i] = 0;
  i = 0;
  String s = String(_buffer);
  
  if (s == "RH_RF22_TXPOW_1DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_1DBM);
    Serial.print("RH_RF22_TXPOW_1DBM");
  }
  else if (s == "RH_RF22_TXPOW_2DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_2DBM);
    Serial.print("RH_RF22_TXPOW_2DBM");
  }
  else if (s == "RH_RF22_TXPOW_5DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_5DBM);
    Serial.print("RH_RF22_TXPOW_5DBM");
  }
  else if (s == "RH_RF22_TXPOW_8DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_8DBM);
    Serial.print("RH_RF22_TXPOW_8DBM");
  }
  else if (s == "RH_RF22_TXPOW_11DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_11DBM);
    Serial.print("RH_RF22_TXPOW_11DBM");
  }
  else if (s == "RH_RF22_TXPOW_14DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_14DBM);
    Serial.print("RH_RF22_TXPOW_14DBM");
  }
  else if (s == "RH_RF22_TXPOW_17DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_17DBM);
    Serial.print("1RH_RF22_TXPOW_17DBM");
  }
  else if (s == "RH_RF22_TXPOW_20DBM")
  {
    rf22.setTxPower(RH_RF22_TXPOW_20DBM);
    Serial.print("RH_RF22_TXPOW_20DBM");
  }
  else
  {
    rf22.setTxPower(RH_RF22_TXPOW_1DBM);
    Serial.print("default RH_RF22_TXPOW_1DBM");
  }
  delay(2000);
  
  
  Serial.print("giveSetFreqConfig;");
  while (!Serial.available()) { }
  delay(1000);
  while (Serial.available())
  {
    _buffer[i++] = Serial.read();
  }
  _buffer[i] = 0;
  i = 0;
  s = String(_buffer);
  rf22.setFrequency(s.toFloat());
  Serial.print("fereq: ");
  Serial.print(s.toFloat(), 2);
  delay(2000);
  
  Serial.print("giveSetModemConfig;");
  while (!Serial.available()) { }
  delay(1000);
  while (Serial.available())
  {
    _buffer[i++] = Serial.read();
  }
  _buffer[i] = 0;
  i = 0;
  s = String(_buffer);
  if (s == "FSK_PN9_Rb2Fd5")
  {
    rf22.setModemConfig(RH_RF22::FSK_PN9_Rb2Fd5);
    Serial.print("RH_RF22::FSK_PN9_Rb2Fd5");
  }
  else if (s == "FSK_Rb2Fd5")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb2Fd5);
    Serial.print("RH_RF22::FSK_Rb2Fd5");
  }
  else if (s == "FSK_Rb2_4Fd36")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb2_4Fd36);
    Serial.print("RH_RF22::FSK_Rb2_4Fd36");
  }
  else if (s == "FSK_Rb4_8Fd45")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb4_8Fd45);
    Serial.print("RH_RF22::FSK_Rb4_8Fd45");
  }
  else if (s == "FSK_Rb9_6Fd45")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb9_6Fd45);
    Serial.print("RH_RF22::FSK_Rb9_6Fd45");
  }
  else if (s == "FSK_Rb19_2Fd9_6")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb19_2Fd9_6);
    Serial.print("RH_RF22::FSK_Rb19_2Fd9_6");
  }
  else if (s == "FSK_Rb38_4Fd19_6")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb38_4Fd19_6);
    Serial.print("RH_RF22::FSK_Rb38_4Fd19_6");
  }
  else if (s == "FSK_Rb57_6Fd28_8")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb57_6Fd28_8);
    Serial.print("RH_RF22::FSK_Rb57_6Fd28_8");
  }
  else if (s == "FSK_Rb125Fd125")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb125Fd125);
    Serial.print("RH_RF22::FSK_Rb125Fd125");
  }
  else if (s == "FSK_Rb_512Fd2_5")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb_512Fd2_5);
    Serial.print("RH_RF22::FSK_Rb_512Fd2_5");
  }
  else if (s == "FSK_Rb_512Fd4_5")
  {
    rf22.setModemConfig(RH_RF22::FSK_Rb_512Fd4_5);
    Serial.print("RH_RF22::FSK_Rb_512Fd4_5");
  }
  else if (s == "GFSK_Rb2Fd5")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb2Fd5);
    Serial.print("RH_RF22::GFSK_Rb2Fd5");
  }
  else if (s == "GFSK_Rb2_4Fd36")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb2_4Fd36);
    Serial.print("RH_RF22::GFSK_Rb2_4Fd36");
  }
  else if (s == "GFSK_Rb4_8Fd45")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb4_8Fd45);
    Serial.print("RH_RF22::GFSK_Rb4_8Fd45");
  }
  else if (s == "GFSK_Rb9_6Fd45")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb9_6Fd45);
    Serial.print("RH_RF22::GFSK_Rb9_6Fd45");
  }
  else if (s == "GFSK_Rb19_2Fd9_6")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb19_2Fd9_6);
    Serial.print("RH_RF22::GFSK_Rb19_2Fd9_6");
  }
  else if (s == "GFSK_Rb38_4Fd19_6")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb38_4Fd19_6);
    Serial.print("RH_RF22::GFSK_Rb38_4Fd19_6");
  }
  else if (s == "GFSK_Rb57_6Fd28_8")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb57_6Fd28_8);
    Serial.print("RH_RF22::GFSK_Rb57_6Fd28_8");
  }
  else if (s == "GFSK_Rb125Fd125")
  {
    rf22.setModemConfig(RH_RF22::GFSK_Rb125Fd125);
    Serial.print("RH_RF22::GFSK_Rb125Fd125");
  }
  else if (s == "OOK_Rb1_2Bw75")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb1_2Bw75);
    Serial.print("RH_RF22::OOK_Rb1_2Bw75");
  }
  else if (s == "OOK_Rb2_4Bw335")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb2_4Bw335);
    Serial.print("RH_RF22::OOK_Rb2_4Bw335");
  }
  else if (s == "OOK_Rb4_8Bw335")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb4_8Bw335);
    Serial.print("RH_RF22::OOK_Rb4_8Bw335");
  }
  else if (s == "OOK_Rb9_6Bw335")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb9_6Bw335);
    Serial.print("RH_RF22::OOK_Rb9_6Bw335");
  }
  else if (s == "OOK_Rb19_2Bw335")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb19_2Bw335);
    Serial.print("RH_RF22::OOK_Rb19_2Bw335");
  }
  else if (s == "OOK_Rb38_4Bw335")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb38_4Bw335);
    Serial.print("RH_RF22::OOK_Rb38_4Bw335");
  }
  else if (s == "OOK_Rb40Bw335")
  {
    rf22.setModemConfig(RH_RF22::OOK_Rb40Bw335);
    Serial.print("RH_RF22::OOK_Rb40Bw335");
  }
  delay(1000);
}

void loop() 
{
  if (rf22.available())
  {
     uint8_t buf[RH_RF22_MAX_MESSAGE_LEN];
     uint8_t len = sizeof(buf);

     rf22.recv(buf, &len);
     Serial.print((char*) buf);

//     Serial.print(" RSSI: ");
//     Serial.println(rf22.lastRssi(), DEC); 
  }
}
