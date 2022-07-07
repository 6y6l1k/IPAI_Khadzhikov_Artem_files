using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embeededTelemetryParser
{
    internal class tParser
    {
        public int checkData(string s)
        {
            return s[0];
        }
 
        // 0A4645.88427,03647.50032,0.145,;
        public char dataGpsValidity(string s)
        {
            //A - good
            //V - bad
            return s[1];
        }

        // 0A4645.88427,03647.50032,0.145,;
        public string getLatitude(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 0) break;
                if (coma == 0 && i > 1 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // 0A4645.88427,03647.50032,0.145,;
        public string getLongitude(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 1) break;
                if (coma == 1 && s[i] != ',') t += s[i];
            }
            return t;
        }
             
        // 0A4645.88427,03647.50032,0.145,;
        public string getSpeed(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 2) break;
                if (coma == 2 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getPreasure1(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 1) break;
                if (coma == 1 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getPreasure2(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 2) break;
                if (coma == 2 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getTemp1(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 3) break;
                if (coma == 3 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getTemp2(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 4) break;
                if (coma == 4 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getHumidity1(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 5) break;
                if (coma == 5 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getHumidity2(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 6) break;
                if (coma == 6 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // давление1, давление2, тмепература1, температура2,влажность1, влажность2, тахометр1
        // 1,800,900,36,60,100,50,2400,;
        public string getTachometr1(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 7) break;
                if (coma == 7 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // тахометр2, напряжение, ток1, ток2
        // 2,16000,12.6,5,70,;
        public string getTachometr2(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 1) break;
                if (coma == 1 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // тахометр2, напряжение, ток1, ток2
        // 2,16000,12.6,5,70,;
        public string getVoltage(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 2) break;
                if (coma == 2 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // тахометр2, напряжение, ток1, ток2
        // 2,16000,12.6,5,70,;
        public string getCurrent1(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 3) break;
                if (coma == 3 && s[i] != ',') t += s[i];
            }
            return t;
        }

        // тахометр2, напряжение, ток1, ток2
        // 2,16000,12.6,5,70,;
        public string getCurrent2(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 4) break;
                if (coma == 4 && s[i] != ',') t += s[i];
            }
            return t;
        }
    }
}
