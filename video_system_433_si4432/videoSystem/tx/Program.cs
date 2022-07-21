using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using AForge.Video.DirectShow;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace tx
{
    internal class Program
    {
        static SerialPort rf_22_tx;
        static void Main(string[] args)
        {
            rf_22_tx = new SerialPort("COM5", 115200);
            rf_22_tx.Open();

            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);

            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();

        }

        private static void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            var bmp = new Bitmap(eventArgs.Frame, 10, 10);
            try
            {
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    var bytes = ms.ToArray();

                    int counter = 0;
                    foreach (var item in bytes)
                    {
                        counter++;
                        rf_22_tx.Write(Convert.ToString(item));
                        Console.Write(Convert.ToString(item));
                        rf_22_tx.Write(";");
                        Console.WriteLine(';');
                        while (rf_22_tx.BytesToRead == 0) { }
                        rf_22_tx.ReadByte();
                    }

                    rf_22_tx.Write("$");
                    Console.Write("$");
                    rf_22_tx.Write(";");
                    Console.WriteLine(';');

                    Console.Write($"\n END   counter: {counter}\n");
                    Console.ReadKey();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
