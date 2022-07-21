using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using AForge.Video.DirectShow;
using System.Drawing;
using System.IO;
//using System.Drawing.Imaging;

namespace tx
{
    internal class Program
    {
        static SerialPort rf22_rx;
        static void Main(string[] args)
        {
            rf22_rx = new SerialPort("COM4", 115200);
            rf22_rx.Open();

            string buffer = "";
            string buffer2 = "";
            int i = 0;


            while (true)
            {
                

                if (rf22_rx.BytesToRead > 0)
                {
                    // 70;122;89;51;255;217;$;
                    char c = Convert.ToChar(rf22_rx.ReadByte());
                    //Console.Write(c);
                    if (c != '$')
                    {
                        buffer += c;
                    }
                    if (c == ';')
                    {
                        i++;
                    }
                    if (c == '$')
                    {
                        buffer += c;
                        buffer += Convert.ToChar(rf22_rx.ReadByte());
                        Console.Clear();

                        //Console.WriteLine(buffer);
                        //Console.WriteLine($"elements = {i}");

                        
                        byte[] bytes = new byte[i];
                        //Console.WriteLine(bytes.Length);

                        i = 0;

                        // 70;122;89;51;255;217;$;

                        Console.Clear();
                        for (int j = 0; j < buffer.Length; j++)
                        {
                            if (buffer[j] != ';' && buffer[j] != '$')
                            {
                                buffer2 += buffer[j];
                            }
                            else if (buffer[j] == ';')
                            {
                                bytes[i] = Convert.ToByte(buffer2);
                                //Console.WriteLine(Convert.ToString(bytes[i]));
                                i++;
                                buffer2 = "";
                            }
                            else if (buffer[j] == '$')
                            {
                                break;
                            }
                        }

                        for (int j = 0; j < bytes.Length; j++)
                        {
                            Console.WriteLine(bytes[j]);
                        }

                        i = 0;
                        buffer = "";
                    }
                }
            }
        }
    }
}
