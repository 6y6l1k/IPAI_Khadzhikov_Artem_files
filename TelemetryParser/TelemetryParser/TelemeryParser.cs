using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace TelemetryParser
{
    internal class TelemeryParser
    {
        public TelemeryParser()
        { 
        }

        private SerialPort telemetry;

        public int Init(string Port, int baudRate)
        {
            try
            {
                telemetry = new SerialPort(Port, baudRate);
                telemetry.Open();
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[INFO] Error when telemetry port {Port} try to open on {baudRate} baudrate");
                return 1;
            }
        }

        private void vaitPacket()
        {
            telemetry.Write("1");
            while (telemetry.BytesToRead == 0) { };
            
        }

        private string GetTelemetryGPSString()
        {
            try
            {
                vaitPacket();
                string _buffer = "";
                while (telemetry.BytesToRead > 0)
                {
                    _buffer += Convert.ToChar(telemetry.ReadByte());
                }
                return _buffer;
            }
            catch
            {
                return "none";
            }
        }


        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        //влажность,давление,напряжениеАКБ,токАКБ,ток1,ток2,ток3,магнетометр,; - пакет номер 2

        public string GetHumidity()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 1) break;
                rs += s[i]; 
            }
            return rs;
        }

        public string GetPreasure()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 1)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 2) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }

        public string GetBattVoltage()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 2)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 3) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }

        public string GetBattCurrentBatt()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 3)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 4) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }

        public string GetBattCurrent1()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 4)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 5) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }

        public string GetBattCurrent2()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 5)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 6) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }

        public string GetBattCurrent3()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 6)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 7) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }

        public string GetMagnetometr()
        {
            string s = GetTelemetryGPSString();
            string rs = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 7)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[i] == ',') coma += 1;
                        if (coma > 8) break;
                        rs += s[i];
                    }
                }
            }
            return rs;
        }
    }
}
