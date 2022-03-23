using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.Model;

namespace Z3.DTO.ComplexQuery2
{
    public class SkokoviPoTipuSkakaonice
    {
        List<Skok> skokoviNaNormalnimSkakaonicama = new List<Skok>();
        int ukBrSkNormalna = 0;
        int ukBrRazSkNormalna = 0;

        List<Skok> skokoviNaSrednjimSkakaonicama = new List<Skok>();
        int ukBrSkSrednja = 0;
        int ukBrRazSkSrednja = 0;

        List<Skok> skokoviNaVelikimSkakaonicama = new List<Skok>();
        int ukBrSkVelika = 0;
        int ukBrRazSkVelika = 0;

        public List<Skok> SkokoviNaNormalnimSkakaonicama { get => skokoviNaNormalnimSkakaonicama; set => skokoviNaNormalnimSkakaonicama = value; }
        public int UkBrSkNormalna { get => ukBrSkNormalna; set => ukBrSkNormalna = value; }
        public int UkBrRazSkNormalna { get => ukBrRazSkNormalna; set => ukBrRazSkNormalna = value; }
        public List<Skok> SkokoviNaSrednjimSkakaonicama { get => skokoviNaSrednjimSkakaonicama; set => skokoviNaSrednjimSkakaonicama = value; }
        public int UkBrSkSrednja { get => ukBrSkSrednja; set => ukBrSkSrednja = value; }
        public int UkBrRazSkSrednja { get => ukBrRazSkSrednja; set => ukBrRazSkSrednja = value; }
        public List<Skok> SkokoviNaVelikimSkakaonicama { get => skokoviNaVelikimSkakaonicama; set => skokoviNaVelikimSkakaonicama = value; }
        public int UkBrSkVelika { get => ukBrSkVelika; set => ukBrSkVelika = value; }
        public int UkBrRazSkVelika { get => ukBrRazSkVelika; set => ukBrRazSkVelika = value; }
    }
}
