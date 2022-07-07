using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO.Ports;

namespace embeededTelemetryParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            RF22_rx telemetry = new RF22_rx();
            Console.WriteLine(telemetry.Init("rf22_rx", true, true, "COM5", 9600, "RH_RF22_TXPOW_11DBM", 466.00, "GFSK_Rb125Fd125"));

            tParser parser = new tParser();

            /*while (true)
            {
                while (telemetry.Available() == 0) { }
                Console.WriteLine(telemetry.ReadString());
            }*/

            while (true)
            {
                while (telemetry.Available() == 0) { }
                string s = telemetry.ReadString();

                if (parser.checkData(s) == '0') // 0A4645.88427,03647.50032,0.145,;
                {
                    Console.Write("Data validity:\t");
                    Console.WriteLine(parser.dataGpsValidity(s));

                    Console.Write("Latitude:\t");
                    Console.WriteLine(parser.getLatitude(s));


                    Console.Write("Longitude:\t");
                    Console.WriteLine(parser.getLongitude(s));


                    Console.Write("speed:\t\t"); ;
                    Console.Write(Convert.ToDouble(parser.getSpeed(s), numberFormatInfo) * 1.852);
                    Console.WriteLine("km/h\n");
                }
                else if (parser.checkData(s) == '1') // 1,800,900,36,60,100,50,2400,;
                {
                    Console.Write("preasure 1:\t");
                    Console.Write(parser.getPreasure1(s));
                    Console.WriteLine("мм.рт.ст.");

                    Console.Write("preasure 2:\t");
                    Console.Write(parser.getPreasure2(s));
                    Console.WriteLine("мм.рт.ст.");

                    Console.Write("temp 1:\t\t");
                    Console.Write(parser.getTemp1(s));
                    Console.WriteLine("°C");

                    Console.Write("temp 2:\t\t");
                    Console.Write(parser.getTemp2(s));
                    Console.WriteLine("°C");

                    Console.Write("humidity 1:\t");
                    Console.Write(parser.getHumidity1(s));
                    Console.WriteLine("%");

                    Console.Write("humidity 2:\t");
                    Console.Write(parser.getHumidity2(s));
                    Console.WriteLine("%");

                    Console.Write("tachometr 1:\t");
                    Console.Write(parser.getTachometr1(s));
                    Console.WriteLine("rpm\n");


                }
                else if (parser.checkData(s) == '2') // 2,16000,12.6,5,70,;
                {
                    Console.Write("tachometr 2:\t");
                    Console.Write(parser.getTachometr2(s));
                    Console.WriteLine("rpm");

                    Console.Write("voltage:\t");
                    Console.Write(parser.getVoltage(s));
                    Console.WriteLine("V");

                    Console.Write("current 1:\t");
                    Console.Write(parser.getCurrent1(s));
                    Console.WriteLine("A");

                    Console.Write("current 2:\t");
                    Console.Write(parser.getCurrent2(s));
                    Console.WriteLine("A\n\n\n");
                }
            }



        }
    }
}
