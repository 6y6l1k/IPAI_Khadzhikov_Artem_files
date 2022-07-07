using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace embeededTelemetryParser
{
    internal class RF22_rx
    {
        public RF22_rx()
        {
        }

        private SerialPort rf22;
        private bool debugPrint { set; get; }
        private string name { set; get; }

        public int Init(string nameS, bool debugPrintS, bool RSSI, string Port, int baudRate, string _powerSet, double _freqSet, string _modemSet)
        {
            try
            {
                debugPrint = debugPrintS;
                name = nameS;

                rf22 = new SerialPort(Port, baudRate);
                try
                {
                    rf22.Open();
                }
                catch
                {
                    Console.WriteLine("port not open");
                }

                if (debugPrint)
                {
                    Console.WriteLine($"{Port} open. {baudRate} baud rate");
                    Console.WriteLine();
                }
                System.Threading.Thread.Sleep(2000);

                rf22.Write("1");
                char[] _sBuffer = new char[64];
                char[] readyBuffer = { 'r', 'e', 'a', 'd', 'y', ';' };
                int i = 0;
                int count = 0;
                while (rf22.BytesToRead == 0) { }
                while (rf22.BytesToRead != 0)
                {
                    _sBuffer[i] = Convert.ToChar(rf22.ReadByte());
                    if (_sBuffer[i] == readyBuffer[i])
                    {
                        count += 1;
                    }
                    if (_sBuffer[i] == ';' && i == count - 1)
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"{name} is ready to start seting up");
                            Console.WriteLine();
                        }
                        break;
                    }
                    i++;
                }

                i = 0;
                count = 0;
                char[] powerBuffer = { 'g', 'i', 'v', 'e', 'S', 'e', 't', 'T', 'x', 'P', 'o', 'w', 'e', 'r', 'C', 'o', 'n', 'f', 'i', 'g', ';' };
                while (rf22.BytesToRead == 0) { }
                while (rf22.BytesToRead != 0)
                {
                    _sBuffer[i] = Convert.ToChar(rf22.ReadByte());
                    if (_sBuffer[i] == powerBuffer[i])
                    {
                        count++;
                    }
                    if (_sBuffer[i] == ';' && i == count - 1)
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"{name} ready to set power");
                        }
                        rf22.Write(Convert.ToString(_powerSet));
                        if (debugPrint)
                        {
                            Console.WriteLine("power seting alredy setuped");
                        }
                        break;
                    }
                    i++;
                }
                while (rf22.BytesToRead == 0) { }
                if (debugPrint)
                {
                    Console.Write($"\techo from {name}: ");
                }
                while (rf22.BytesToRead != 0)
                {
                    char c = Convert.ToChar(rf22.ReadByte());
                    if (debugPrint)
                    {
                        if (c != '\n')
                        {
                            Console.Write(c);
                        }
                    }
                }
                if (debugPrint)
                {
                    Console.WriteLine('\n');
                }

                i = 0;
                count = 0;
                char[] freqBuffer = { 'g', 'i', 'v', 'e', 'S', 'e', 't', 'F', 'r', 'e', 'q', 'C', 'o', 'n', 'f', 'i', 'g', ';' };
                while (rf22.BytesToRead == 0) { }
                while (rf22.BytesToRead != 0)
                {
                    _sBuffer[i] = Convert.ToChar(rf22.ReadByte());
                    if (_sBuffer[i] == freqBuffer[i])
                    {
                        count++;
                    }
                    if (_sBuffer[i] == ';' && i == count - 1)
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"{name} ready to set freq");
                        }
                        rf22.Write(Convert.ToString(_freqSet));
                        if (debugPrint)
                        {
                            Console.WriteLine("freq seting alredy setuped");
                        }
                        break;
                    }
                    i++;
                }
                while (rf22.BytesToRead == 0) { }
                if (debugPrint)
                {
                    Console.Write($"\techo from {name}: ");
                }
                while (rf22.BytesToRead != 0)
                {
                    char c = Convert.ToChar(rf22.ReadByte());
                    if (debugPrint)
                    {
                        if (c != '\n')
                        {
                            Console.Write(c);
                        }
                    }
                }
                if (debugPrint)
                {
                    Console.WriteLine('\n');
                }

                i = 0;
                count = 0;
                char[] modemBuffer = { 'g', 'i', 'v', 'e', 'S', 'e', 't', 'M', 'o', 'd', 'e', 'm', 'C', 'o', 'n', 'f', 'i', 'g', ';' };
                while (rf22.BytesToRead == 0) { }
                while (rf22.BytesToRead != 0)
                {
                    _sBuffer[i] = Convert.ToChar(rf22.ReadByte());
                    if (_sBuffer[i] == modemBuffer[i])
                    {
                        count++;
                    }
                    if (_sBuffer[i] == ';' && i == count - 1)
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"{name} ready to set modem");
                        }
                        rf22.Write(Convert.ToString(_modemSet));
                        if (debugPrint)
                        {
                            Console.WriteLine("modem seting alredy setuped");
                        }
                        break;
                    }
                    i++;
                }
                while (rf22.BytesToRead == 0) { }
                if (debugPrint)
                {
                    Console.Write($"\techo from {name}: ");
                }
                while (rf22.BytesToRead != 0)
                {
                    char c = Convert.ToChar(rf22.ReadByte());
                    if (debugPrint)
                    {
                        if (c != '\n')
                        {
                            Console.Write(c);
                        }
                    }
                }
                if (debugPrint)
                {
                    Console.WriteLine('\n');
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public int Available()
        {
            try
            {
                return rf22.BytesToRead;
            }
            catch (Exception e)
            {
                if (debugPrint)
                {
                    Console.WriteLine($"[INFO] {name} give out exception, text:\n {e}");
                }
                return 0;
            }
        }

        public string ReadString()
        {
            string message = "";
            while (rf22.BytesToRead > 0)
            {
               message += Convert.ToChar(rf22.ReadByte());
            }
            return message; 
        }
    }
}
