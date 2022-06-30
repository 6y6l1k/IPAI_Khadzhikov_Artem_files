#include <Servo.h>
#include <SoftwareSerial.h>

SoftwareSerial uart(4, 3);


Servo motor;
Servo servo;

bool flag = false;

char cbuffer[64];
int i = 0;

void setup() 
{

  Serial.begin(9600);
  uart.begin(9600);

  //Serial.println("serial was started...");
  
  servo.attach(6);
  motor.attach(7);
  delay(3000);

  motor.writeMicroseconds(2300);
  delay(2000);  
  motor.writeMicroseconds(800);
  delay(6000); 

  uart.write('0');
  //Serial.println('0');
}



void loop() 
{
  // char _ccbuffer2[] = "10,1500|;";
  if (uart.available())
  {
    cbuffer[i] = (char) uart.read();
    if (cbuffer[i] == ';')
    {
      flag = true;
    }
    i++;
  }

  if (flag)
  {
    String sval0 = "";
    String sval1 = "";

    int k = 0;
    
    for (int j = 0; j < sizeof(cbuffer); j++)
    {
      if (cbuffer[j] == ',')
      {
        k = j;
        break;
      }
      else
      {
        sval0 += cbuffer[j];
      }
    }

    for (int j = k+1; j < sizeof(cbuffer); j++)
    {
      if (cbuffer[j] == '|')
      {
        break;
      }
      else
      {
        sval1 += cbuffer[j];
      }
    }
  
//    Serial.print(sval0.toInt());
//    Serial.print("  ");
//    Serial.println(sval1.toInt());

    servo.write(sval0.toInt());
    motor.writeMicroseconds(sval1.toInt());
    
    flag = false;
    i = 0;
  }
}
