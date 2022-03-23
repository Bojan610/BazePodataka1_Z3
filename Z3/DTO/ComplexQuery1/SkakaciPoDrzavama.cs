using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.Model;

namespace Z3.DTO.ComplexQuery1
{
    public class SkakaciPoDrzavama
    {
        List<Skakac> skakaci = new List<Skakac>();
        int ukupnoTitula = 0;

        public List<Skakac> Skakaci { get => skakaci; set => skakaci = value; }
        public int UkupnoTitula { get => ukupnoTitula; set => ukupnoTitula = value; }
    }
}
