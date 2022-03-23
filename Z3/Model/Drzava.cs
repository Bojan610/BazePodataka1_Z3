using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3.Model
{
    public class Drzava
    {
        public string Idd { get; set; }
        public string NazivD { get; set; }

        public Drzava()
        {
        }

        public Drzava(string idd, string nazivD)
        {
            Idd = idd;
            NazivD = nazivD;
        }

        public override string ToString()
        {
            return string.Format("{0,-15} {1,-15}", Idd, NazivD);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-15} {1,-15}", "IDD", "NAZIVD");
        }
    }
}
