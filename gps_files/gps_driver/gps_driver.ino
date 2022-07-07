#include <SoftwareSerial.h>
SoftwareSerial GPS(4,5);

char _buffer[64];
char _cbuffer[64];
int i = 0;
bool flag = false;

String tempS = "";

void setup() 
{
  GPS.begin(9600);
  Serial.begin(38400);
}

void loop() 
{
  if (GPS.available())
  {
    _buffer[i] = GPS.read();
    if (_buffer[i] == ';')
    {
      _buffer[i+1] = 0;
//      i = 0;
//      while (_buffer[i] != 0)
//      {
//        _cbuffer[i] = _buffer[i];
//        i++;
//      }
      i = -1;
      //tempS = String(_buffer);
      //Serial.println(tempS);
    }
    i++;
  }

  if (Serial.available())
  {
    Serial.read();
    for (int j = 0; j < sizeof(_buffer); j++)
    {
      Serial.print(_buffer[j]);
    }
    Serial.println();
  }
}
