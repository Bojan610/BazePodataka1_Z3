using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.DTO.ComplexQuery1;
using Z3.DTO.ComplexQuery2;
using Z3.DTO.ComplexQuery4;
using Z3.Model;
using Z3.Service;

namespace Z3.UIHandler
{
    public class ComplexQueryUIHandler
    {
        private static readonly ComplexFunctionalityService complexFunctionalityService = new ComplexFunctionalityService();

        public void HandleComplexQueryMenu()
        {
            String answer;
            do
            {
                Console.WriteLine("\nOdaberite funkcionalnost:");
                Console.WriteLine(
                        "\n1  -  Izveštaj koji će za uneti IDD (identifikaciona oznaka države) prikazati" +
                        "sve skakače koji dolaze iz države sa tim IDD.Nakon liste skakača ce se prikazati i" +
                        " ukupan broj titula skakača iz te države");
                Console.WriteLine(
                        "\n2  -  Izveštaj koji će za svaki tip skakaonice prikazati skokove vršene na" +
                        " skakaonicama tog tipa. Potom ce prikazati i ukupan broj ovih skokova, kao i" +
                        " ukupan broj različitih skakača koji su skakali na skakaonicama datog tipa.");
                Console.WriteLine(
                       "\n3  -  Funkcija koja će omogućiti unošenje novog skoka. Prilikom unošenja skoka," +
                                " ukoliko je ostvareni broj bodova u tom novom skoku(dobijen kao suma broja" +
                                " bodova za dužinu i stil skoka) veći od najboljeg ostvarenog broja bodova " +
                                "tog skakača(obeležje PBSC u tabeli Skakac), ažurirace se i vrednost " +
                                "najboljeg ostvarenog broja bodova tog skakača");
                Console.WriteLine(
                       "\n4  -  Izveštaj koji će za uneti naziv tipa skakaonica prikazati sve skakaonice" +
                                " tog tipa. Nakon liste skakaonica prikazace se i prosečna dužina" +
                                " skakaonica datog tipa.");
                Console.WriteLine("\nX  - Izlazak iz kompleksnih upita");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ComplexQuery1();
                        break;
                    case "2":
                        ComplexQuery2();
                        break;
                    case "3":
                        ComplexQuery3();
                        break;
                    case "4":
                        ComplexQuery4();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void ComplexQuery1()
        {
            Console.WriteLine("IDD: ");
            string idd = Console.ReadLine();

            Console.WriteLine(Skakac.GetFormattedHeader());

            try
            {
                SkakaciPoDrzavama skakaciPoDrzavama = complexFunctionalityService.ComplexQuery1(idd);
                foreach (Skakac item in skakaciPoDrzavama.Skakaci)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine($"\nUkupan broj titula({idd}): {skakaciPoDrzavama.UkupnoTitula}");

            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ComplexQuery2()
        {
            try
            {
                SkokoviPoTipuSkakaonice skokoviPoTipuSkakaonice = complexFunctionalityService.ComplexQuery2();

                Console.WriteLine("Skokovi na normalnim skakaonicama:\n");
                Console.WriteLine(Skok.GetFormattedHeader());
                foreach (Skok item in skokoviPoTipuSkakaonice.SkokoviNaNormalnimSkakaonicama)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Ukupan broj skokova: " + skokoviPoTipuSkakaonice.UkBrSkNormalna);
                Console.WriteLine("Ukupan broj razlicitih skakaca: " + skokoviPoTipuSkakaonice.UkBrRazSkNormalna);

                Console.WriteLine("\nSkokovi na srednjim skakaonicama:\n");
                Console.WriteLine(Skok.GetFormattedHeader());
                foreach (Skok item in skokoviPoTipuSkakaonice.SkokoviNaSrednjimSkakaonicama)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Ukupan broj skokova: " + skokoviPoTipuSkakaonice.UkBrSkSrednja);
                Console.WriteLine("Ukupan broj razlicitih skakaca: " + skokoviPoTipuSkakaonice.UkBrRazSkSrednja);

                Console.WriteLine("\nSkokovi na velikim skakaonicama:\n");
                Console.WriteLine(Skok.GetFormattedHeader());
                foreach (Skok item in skokoviPoTipuSkakaonice.SkokoviNaVelikimSkakaonicama)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Ukupan broj skokova: " + skokoviPoTipuSkakaonice.UkBrSkVelika);
                Console.WriteLine("Ukupan broj razlicitih skakaca: " + skokoviPoTipuSkakaonice.UkBrRazSkVelika);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ComplexQuery3()
        {
            Console.WriteLine("IDSK: ");
            string idsk = Console.ReadLine();

            Console.WriteLine("IDSC: ");
            int idsc = int.Parse(Console.ReadLine());

            Console.WriteLine("IDSA: ");
            string idsa = Console.ReadLine();

            Console.WriteLine("BDUZINA: ");
            double bduzima = double.Parse(Console.ReadLine());

            Console.WriteLine("BSTIL: ");
            double bstil = double.Parse(Console.ReadLine());

            Console.WriteLine("BVETAR: ");
            double bvetar = double.Parse(Console.ReadLine());

            try
            {
                if (complexFunctionalityService.ComplexQuery3(new Skok(idsk.Trim(), idsc, idsa, bduzima, bstil, bvetar)))
                    Console.WriteLine("Skok \"{0}\" uspešno unet.", idsk);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ComplexQuery4()
        {
            Console.WriteLine("TIPSA: ");
            string tipsa = Console.ReadLine();

            Console.WriteLine("\nSve skakaonice tipa " + tipsa);
            Console.WriteLine(Skakaonica.GetFormattedHeader());

            try
            {
                SkakaonicePoTipu skakaonicePoTipu = complexFunctionalityService.ComplexQuery4(tipsa);
                foreach (Skakaonica item in skakaonicePoTipu.Skakaonice)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Prosecna duzina skakaonica: " + skakaonicePoTipu.ProsecnaDuzina);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
