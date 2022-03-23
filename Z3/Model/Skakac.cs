using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3.Model
{
    public class Skakac
    {
        public int Idsc { get; set; }
        public string Imesc { get; set; }
        public string Przsc { get; set; }
        public string Idd { get; set; }
        public int Titule { get; set; }
        public double Pbsc { get; set; }

        public Skakac()
        {
        }

        public Skakac(int idsc, string imesc, string przsc, string idd, int titule, double pbsc)
        {
            Idsc = idsc;
            Imesc = imesc;
            Przsc = przsc;
            Idd = idd;
            Titule = titule;
            Pbsc = pbsc;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-10} {2,-15} {3,-10} {4,-10} {5,-10}",
               Idsc, Imesc, Przsc, Idd, Titule, Pbsc);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-10} {2,-15} {3,-10} {4,-10} {5,-10}",
                "IDSC", "IMESC", "PRZSC", "IDD", "TITULE", "PBSC");
        }
    }
}
