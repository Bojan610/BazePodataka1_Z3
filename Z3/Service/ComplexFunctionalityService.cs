using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.DAO;
using Z3.DAO.Impl;
using Z3.DTO.ComplexQuery1;
using Z3.DTO.ComplexQuery2;
using Z3.DTO.ComplexQuery4;
using Z3.Model;

namespace Z3.Service
{
    public class ComplexFunctionalityService
    {
        private static readonly ISkakacDAO skakacDAO = new SkakacDAOImpl();
        private static readonly ISkokDAO skokDAO = new SkokDAOImpl();
        private static readonly ISkakaonicaDAO skakaonicaDAO = new SkakaonicaDAOImpl();

        public SkakaciPoDrzavama ComplexQuery1(string idd)
        {
            SkakaciPoDrzavama ret = new SkakaciPoDrzavama();
            int sum = 0;

            ret.Skakaci = skakacDAO.FindByIdd(idd);
            foreach (Skakac item in ret.Skakaci)
                sum += item.Titule;

            ret.UkupnoTitula = sum;
            return ret;
        }

        public SkokoviPoTipuSkakaonice ComplexQuery2()
        {
            SkokoviPoTipuSkakaonice ret = new SkokoviPoTipuSkakaonice();

            ret.SkokoviNaNormalnimSkakaonicama = skokDAO.FindAllByTypeDivingBoard("normalna");
            ret.UkBrSkNormalna = ret.SkokoviNaNormalnimSkakaonicama.Count();

            List<Skok> temp = new List<Skok>();
            bool find = false;
            foreach (Skok item in ret.SkokoviNaNormalnimSkakaonicama)
            {
                foreach (Skok skok in temp)
                {
                    if (skok.Idsc.Equals(item.Idsc))
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                    temp.Add(item);

                find = false;
            }
            ret.UkBrRazSkNormalna = temp.Count();

            ret.SkokoviNaSrednjimSkakaonicama = skokDAO.FindAllByTypeDivingBoard("srednja");
            ret.UkBrSkSrednja = ret.SkokoviNaSrednjimSkakaonicama.Count();

            temp = new List<Skok>();
            find = false;
            foreach (Skok item in ret.SkokoviNaSrednjimSkakaonicama)
            {
                foreach (Skok skok in temp)
                {
                    if (skok.Idsc.Equals(item.Idsc))
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                    temp.Add(item);

                find = false;
            }
            ret.UkBrRazSkSrednja = temp.Count();

            ret.SkokoviNaVelikimSkakaonicama = skokDAO.FindAllByTypeDivingBoard("velika");
            ret.UkBrSkVelika = ret.SkokoviNaVelikimSkakaonicama.Count();

            temp = new List<Skok>();
            find = false;
            foreach (Skok item in ret.SkokoviNaVelikimSkakaonicama)
            {
                foreach (Skok skok in temp)
                {
                    if (skok.Idsc.Equals(item.Idsc))
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                    temp.Add(item);

                find = false;
            }
            ret.UkBrRazSkVelika = temp.Count();

            return ret;
        }

        public bool ComplexQuery3(Skok skok)
        {
            int inserted = skokDAO.Save(skok);
            if (inserted != 0)
            {
                if ((skok.Bduzina + skok.Bstil) > skakacDAO.FindById(skok.Idsc).Pbsc)
                {
                    Skakac skakac = skakacDAO.FindById(skok.Idsc);
                    skakac.Pbsc = skok.Bduzina + skok.Bstil;
                    skakacDAO.Save(skakac);
                }
                return true;
            }
            return false;
        }

        public SkakaonicePoTipu ComplexQuery4(string tipsa)
        {
            SkakaonicePoTipu skakaonicePoTipu = new SkakaonicePoTipu();

            skakaonicePoTipu.Skakaonice = skakaonicaDAO.FindAllByTypeSnowingBoard(tipsa);

            int ukDuzina = 0;
            foreach (Skakaonica item in skakaonicePoTipu.Skakaonice)
            {
                ukDuzina += item.Duzinasa;
            }

            skakaonicePoTipu.ProsecnaDuzina = (double)ukDuzina / (double)skakaonicePoTipu.Skakaonice.Count();

            return skakaonicePoTipu;
        }
    }
}
