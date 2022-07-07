#include <SoftwareSerial.h>
SoftwareSerial GPS(4, 5);
String tempM = "";
void setup() 
{
  Serial.begin(9600);
  GPS.begin(9600);
}

void loop() 
{
  //GPS.flush();
  while (GPS.available() > 0)
  {
    GPS.read();
  }
  if (GPS.find("GPRMC,"))
  {
    tempM = GPS.readStringUntil('\n');
    Serial.print(tempM);
    Serial.print(';');
  }
}
