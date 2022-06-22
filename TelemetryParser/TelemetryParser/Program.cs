using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace TelemetryParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var boatTelemetry = new TelemeryParser();
            int n = boatTelemetry.Init("COM5", 9600);
            if (n == 0) Console.WriteLine("COM5, 9600");
            else Console.WriteLine("Error");

            //влажность,давление,напряжениеАКБ,токАКБ,ток1,ток2,ток3,магнетометр,; - пакет номер 2

            Console.WriteLine(boatTelemetry.GetHumidity());
            Console.WriteLine(boatTelemetry.GetPreasure());
            Console.WriteLine(boatTelemetry.GetBattVoltage());
            Console.WriteLine(boatTelemetry.GetBattCurrentBatt());
            Console.WriteLine(boatTelemetry.GetBattCurrent1());
            Console.WriteLine(boatTelemetry.GetBattCurrent2());
            Console.WriteLine(boatTelemetry.GetBattCurrent3());
            Console.WriteLine(boatTelemetry.GetMagnetometr());
        }
    }
}
