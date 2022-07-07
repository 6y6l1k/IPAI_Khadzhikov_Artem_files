#include <SPI.h>
#include <RH_RF22.h>
RH_RF22 rf22(10, 2);

void setup()
{
  Serial.begin(9600);
  rf22.init();

  rf22.setTxPower(RH_RF22_TXPOW_11DBM);
  rf22.setFrequency(466.00);
  rf22.setModemConfig(RH_RF22::GFSK_Rb125Fd125);
}

void loop()
{
  delay(2000);           // давление1, давление2, давление3, тмепература1, температура2,влажность1, влажность2, тахометр1, тахометр2, напряжение, ток1, ток2  
  char _gps[] = "0A4645.88427,03647.50032,0.145,;";
  rf22.send(_gps, sizeof(_gps));
  rf22.waitPacketSent();  
  for (int j = 0; j < sizeof(_gps); j++)
  {
    Serial.print(_gps[j]);
  }
  Serial.println();

  delay(2000);           // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1, тахометр2, напряжение, ток1, ток2  
  char _telemetry_1[] = "1,800,900,36,60,100,50,2400,;";
  rf22.send(_telemetry_1, sizeof(_telemetry_1));
  rf22.waitPacketSent();  
  for (int j = 0; j < sizeof(_telemetry_1); j++)
  {
    Serial.print(_telemetry_1[j]);
  }
  Serial.println();

  delay(2000);           // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1, тахометр2, напряжение, ток1, ток2  
  char _telemetry_2[] = "2,16000,12.6,5,70,;";
  rf22.send(_telemetry_2, sizeof(_telemetry_2));
  rf22.waitPacketSent();  
  for (int j = 0; j < sizeof(_telemetry_2); j++)
  {
    Serial.print(_telemetry_2[j]);
  }
  Serial.println();
}
