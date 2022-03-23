using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.Model;

namespace Z3.DTO.ComplexQuery4
{
    public class SkakaonicePoTipu
    {
        List<Skakaonica> skakaonice = new List<Skakaonica>();
        double prosecnaDuzina = 0;

        public List<Skakaonica> Skakaonice { get => skakaonice; set => skakaonice = value; }
        public double ProsecnaDuzina { get => prosecnaDuzina; set => prosecnaDuzina = value; }
    }
}
