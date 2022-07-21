using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace rx
{

    public partial class Form1 : Form
    {
        private SerialPort rf22_rx;
        

        public Form1()
        {
            
          



            

            

            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
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
                        //Console.Clear();

                        //Console.WriteLine(buffer);
                        //Console.WriteLine($"elements = {i}");


                        byte[] bytes = new byte[i];
                        //Console.WriteLine(bytes.Length);

                        i = 0;

                        // 70;122;89;51;255;217;$;

                        //Console.Clear();
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

                        /*for (int j = 0; j < bytes.Length; j++)
                        {
                            Console.WriteLine(bytes[j]);
                        }*/

                        using (var ms = new MemoryStream(bytes))
                        {
                            pictureBox1.Image = new Bitmap(ms);
                        }

                        i = 0;
                        buffer = "";
                    }
                }
            }
        }
    }
}
