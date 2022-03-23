using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3.Model
{
    public class Skakaonica
    {
        public string Idsa { get; set; }
        public string Nazivsa { get; set; }
        public int Duzinasa { get; set; }
        public string Tipsa { get; set; }
        public string Idd { get; set; }

        public Skakaonica()
        {
        }

        public Skakaonica(string idsa, string nazivsa, int duzinasa, string tipsa, string idd)
        {
            Idsa = idsa;
            Nazivsa = nazivsa;
            Duzinasa = duzinasa;
            Tipsa = tipsa;
            Idd = idd;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20} {2,-15} {3,-15} {4,-15}",
               Idsa, Nazivsa, Duzinasa, Tipsa, Idd);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-20} {2,-15} {3,-15} {4,-15}",
                "IDSA", "NAZIVSA", "DUZINASA", "TIPSA", "IDD");
        }
    }
}
