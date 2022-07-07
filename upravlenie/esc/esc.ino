#include <Servo.h>
#include <SoftwareSerial.h>

SoftwareSerial uart(4, 3);


Servo motor;
Servo servo;

bool flag = false;

char _buffer[64];
int i = 0;
int k = 0;

void setup() 
{

  Serial.begin(9600);
  uart.begin(9600);

  Serial.println("serial was started...");
  
  servo.attach(6);
  motor.attach(7);
  delay(3000);

  motor.writeMicroseconds(2300);
  delay(2000);  
  motor.writeMicroseconds(800);
  delay(6000); 

  uart.write('0');
  Serial.println('0');
}



void loop() 
{
  // char _ccbuffer2[] = "10,1500;";
  if (uart.available())
  {
    _buffer[i] = uart.read();
    //Serial.print(_buffer[i]);
    if (_buffer[i] == ';')
    {
      //Serial.println();
      flag = true;
      k = i;
    }
    i++;
  }

  if (flag)
  {
    flag  = false;
    i = 0;
    char _cbuffer[k+1];
    k = 0;
    
    for (int j = 0; j < sizeof(_cbuffer); j++)
    {
      _cbuffer[j] = _buffer[j];
      if (_cbuffer[j] == ';')
      {
        break;   
      }
    }

//    for (int j = 0; j < sizeof(_cbuffer); j++)
//    {
//      Serial.print(_cbuffer[j]);
//    }
//    Serial.println();
    String _sservo = "";
    String _smotor = "";

    for (int j = 0; j < sizeof(_cbuffer); j++)
    {
      if (_cbuffer[j] != ',')
      {
        _sservo += _cbuffer[j];
      }
      else 
      {
        k = j;
        break;
      }
    }
//    Serial.print(_sservo);
//    Serial.print("   ");

    for (int j = k+1; j < sizeof(_cbuffer); j++)
    {
      if (_cbuffer[j] != ';')
      {
        _smotor += _cbuffer[j];
      }
      else 
      {
        break;
      }
    }
//    Serial.print(_smotor);
//    Serial.println(" <end");

    int _iservo = _sservo.toInt();
    if (_iservo > 180)
    {
      _iservo = 180;
    }
    else if (_iservo < 0)
    {
      _iservo = 0;
    }
    servo.write(_iservo);

    int _imotor = _smotor.toInt();
    if (_imotor > 2300)
    {
      _imotor = 2300;
    }
    else if (_imotor < 800)
    {
      _imotor = 800;
    }
    motor.writeMicroseconds(_imotor);
    
    k = 0;
  }
}
