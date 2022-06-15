using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RF22_test_tx_rx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*RF22_tx rf22_tx = new RF22_tx();
            Console.WriteLine(rf22_tx.Init("rf22_tx", true, false, "COM5", 9600, "RH_RF22_TXPOW_11DBM", 466.00, "GFSK_Rb125Fd125"));
            Console.WriteLine('\n');

            string s = "hello from rf22_tx!!!;";
            while (true)
            {
                if (rf22_tx.Send(s) == 0)
                {
                    Console.WriteLine($"[INFO] packet  {s}  successfuly transcived");
                }
                else
                {
                    Console.WriteLine($"[INFO] packet  {s} NOT transcived");
                }
            }*/

            RF22_rx rf22_rx = new RF22_rx();
            Console.WriteLine(rf22_rx.Init("rf22_rx", true, true, "COM5", 9600, "RH_RF22_TXPOW_11DBM", 466.00, "GFSK_Rb125Fd125"));

            while (true)
            {
                if (rf22_rx.Available() == 0)
                {
                    
                    Console.WriteLine(rf22_rx.Read());
                    Console.WriteLine();
                }
            }
        }
    }
}
