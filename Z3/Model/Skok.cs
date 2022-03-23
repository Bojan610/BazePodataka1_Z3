using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3.Model
{
    public class Skok
    {
        public string Idsk { get; set; }
        public int Idsc { get; set; }
        public string Idsa { get; set; }
        public double Bduzina { get; set; }
        public double Bstil { get; set; }
        public double Bvetar { get; set; }

        public Skok()
        {
        }

        public Skok(string idsk, int idsc, string idsa, double bduzina, double bstil, double bvetar)
        {
            Idsk = idsk;
            Idsc = idsc;
            Idsa = idsa;
            Bduzina = bduzina;
            Bstil = bstil;
            Bvetar = bvetar;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-10} {2,-15} {3,-10} {4,-10} {5,-10}",
                Idsk, Idsc, Idsa, Bduzina, Bstil, Bvetar);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-10} {2,-15} {3,-10} {4,-10} {5,-10}",
                "IDSK", "IDSC", "IDSA", "BDUZINA", "BSTIL", "BVETAR");
        }
    }
}
