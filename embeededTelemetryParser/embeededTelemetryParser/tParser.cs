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

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getGpsType(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 1) break;
                if (coma < 1) t += s[i];
            }
            return t;
        }

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string dataValidity(string s)
        {
            //A - good
            //V - bad
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma += 1;
                if (coma > 2) break;
                if (coma == 2 && s[i] != ',') t += s[i];
            }
            return t;
        }

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getLatitude(string s)
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

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getLatitudeType(string s)
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

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getLongitude(string s)
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

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getLongitudeType(string s)
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
        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getSpeed(string s)
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

        //GPRMC,073111.00,A,4645.88427,N,03647.50032,E,0.145,,140422,,,A*74,; - пакет номер 1
        public string getTime(string s)
        {
            string t = "";
            int coma = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') coma++;
                if (coma > 9) break;
                if (coma == 9 && s[i] != ',') t += s[i];
            }
            return t;
        }

    }
}
