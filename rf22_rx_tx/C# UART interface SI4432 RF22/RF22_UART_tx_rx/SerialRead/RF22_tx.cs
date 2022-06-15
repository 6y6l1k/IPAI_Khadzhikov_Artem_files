using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RF22_test_tx_rx
{
    internal class RF22_tx
    {
        public RF22_tx()
        {
        }

        private SerialPort rf22;
        private bool debugPrint { set; get; }
        private bool transferConfirmation { set; get; }

        public int Init(string name, bool debugPrintS, bool transferConfirmationS, string Port, int baudRate, string _powerSet, double _freqSet, string _modemSet)
        {
            try
            {
                debugPrint = debugPrintS;
                transferConfirmation = transferConfirmationS;

                rf22 = new SerialPort(Port, baudRate);
                rf22.Open();
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
                while(rf22.BytesToRead != 0)
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

        public int Send(string s)
        {
            try
            {
                rf22.Write(s);
                if (transferConfirmation)
                {
                    while (rf22.BytesToRead == 0) { }
                    int echoChar = Convert.ToChar(rf22.ReadByte());
                    if (echoChar == '0')
                    {
                        return 0;
                    }
                    else
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"echo state byte unknown:   {echoChar}");
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int Send(int n)
        {
            try
            {
                rf22.Write(Convert.ToString(n));
                if (transferConfirmation)
                {
                    while (rf22.BytesToRead == 0) { }
                    int echoChar = Convert.ToChar(rf22.ReadByte());
                    if (echoChar == '0')
                    {
                        return 0;
                    }
                    else
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"echo state byte unknown:   {echoChar}");
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int Send(float f)
        {
            try
            {
                rf22.Write(Convert.ToString(f));
                if (transferConfirmation)
                {
                    while (rf22.BytesToRead == 0) { }
                    int echoChar = Convert.ToChar(rf22.ReadByte());
                    if (echoChar == '0')
                    {
                        return 0;
                    }
                    else
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"echo state byte unknown:   {echoChar}");
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int Send(double d)
        {
            try
            {
                rf22.Write(Convert.ToString(d));
                if (transferConfirmation)
                {
                    while (rf22.BytesToRead == 0) { }
                    int echoChar = Convert.ToChar(rf22.ReadByte());
                    if (echoChar == '0')
                    {
                        return 0;
                    }
                    else
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"echo state byte unknown:   {echoChar}");
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int Send(char c)
        {
            try
            {
                rf22.Write(Convert.ToString(c));
                if (transferConfirmation)
                {
                    while (rf22.BytesToRead == 0) { }
                    int echoChar = Convert.ToChar(rf22.ReadByte());
                    if (echoChar == '0')
                    {
                        return 0;
                    }
                    else
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"echo state byte unknown:   {echoChar}");
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int Send(char[] c)
        {
            try
            {
                foreach (char item in c)
                {
                    rf22.Write(Convert.ToString(item));
                }
                if (transferConfirmation)
                {
                    while (rf22.BytesToRead == 0) { }
                    int echoChar = Convert.ToChar(rf22.ReadByte());
                    if (echoChar == '0')
                    {
                        return 0;
                    }
                    else
                    {
                        if (debugPrint)
                        {
                            Console.WriteLine($"echo state byte unknown:   {echoChar}");
                        }
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        public int conClose()
        {
            try
            {
                rf22.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
