using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embeededTelemetryParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RF22_rx telemetry = new RF22_rx();
            //Console.WriteLine(telemetry.Init("rf22_rx", true, true, "COM5", 9600, "RH_RF22_TXPOW_11DBM", 466.00, "GFSK_Rb125Fd125"));

            tParser parser = new tParser();
            string s;
            //s = boatTelemetry.GetTelemetryGpsString();
            s = "0GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A * 74,;";

            if (parser.checkData(s) == '0')
            {
                Console.WriteLine(parser.getGpsType(s));
                Console.WriteLine(parser.dataValidity(s));
                Console.WriteLine(parser.getLatitude(s));
                Console.WriteLine(parser.getLatitudeType(s));
                Console.WriteLine(parser.getLongitude(s));
                Console.WriteLine(parser.getLongitudeType(s));
                Console.WriteLine(parser.getSpeed(s));
                Console.WriteLine(parser.getTime(s));
            }
            else if (parser.checkData(s) == '1')
            {

            }
            else if (parser.checkData(s) == '9')
            {
                Console.WriteLine("bad packet");
            }
        }
    }
}
