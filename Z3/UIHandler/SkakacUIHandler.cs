using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.Model;
using Z3.Service;

namespace Z3.UIHandler
{
    public class SkakacUIHandler
    {
        private static readonly SkakacService skakacService = new SkakacService();

        public void HandleTheatreMenu()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad skakacima:");
                Console.WriteLine("1 - Prebroj skakace");
                Console.WriteLine("2 - Brisanje po identifikatoru");
                Console.WriteLine("3 - Brisanje svih skakaca iz tabele");
                Console.WriteLine("4 - Proveri da li postoji skakac sa unetim id-om");
                Console.WriteLine("5 - Prikaz svih");
                Console.WriteLine("6 - Prikaz svih sa zadatim identifikatorima");
                Console.WriteLine("7 - Prikaz po identifikatoru");
                Console.WriteLine("8 - Unos jednog skakaca");
                Console.WriteLine("9 - Unos vise skakaca");
                Console.WriteLine("10 - Izmena po identifikatoru");
               
                Console.WriteLine("X - Izlazak iz rukovanja pozoristima");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Count();
                        break;
                    case "2":
                        HandleDelete();
                        break;
                    case "3":
                        HandleDeleteAll();
                        break;
                    case "4":
                        ExistsById();
                        break;
                    case "5":
                        ShowAll();
                        break;
                    case "6":
                        ShowAllById();
                        break;
                    case "7":
                        ShowById();
                        break;
                    case "8":
                        HandleSingleInsert();
                        break;
                    case "9":
                        HandleMultipleInserts();
                        break;
                    case "10":
                        HandleUpdate();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void Count()
        {
            try
            {
                Console.WriteLine("Trenutni broj skakaca: " + skakacService.Count());
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleDelete()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                int deleted = skakacService.DeleteById(id);
                if (deleted != 0)
                {
                    Console.WriteLine("Skakac sa šifrom \"{0}\" uspešno obrisan.", id);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleDeleteAll()
        {
            try
            {
                int deleted = skakacService.DeleteAll();
                if (deleted != 0)
                {
                    Console.WriteLine("Skakaci uspešno obrisani.");
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExistsById()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                if (skakacService.ExistsById(id))
                    Console.WriteLine("Skakac sa unetim id podacima je pronadjen.");
                else
                    Console.WriteLine("Skakac sa unetim id podacima nije pronadjen.");
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowAll()
        {
            Console.WriteLine(Skakac.GetFormattedHeader());

            try
            {
                foreach (Skakac item in skakacService.FindAll())
                {
                    Console.WriteLine(item);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowAllById()
        {
            List<int> ids = new List<int>();
            int id = 0;
            Console.WriteLine("IDSC(za zavrsetak unesi 0):");

            do
            {
                id = int.Parse(Console.ReadLine());
                if (id != 0)
                    ids.Add(id);
            } while (id != 0);

            Console.WriteLine(Skakac.GetFormattedHeader());
            try
            {
                foreach (Skakac item in skakacService.FindAllById(ids))
                {
                    Console.WriteLine(item);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowById()
        {
            Console.WriteLine("IDPOZ: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                Skakac skakac = skakacService.FindById(id);

                Console.WriteLine(Skakac.GetFormattedHeader());
                Console.WriteLine(skakac);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleSingleInsert()
        {
            Console.WriteLine("IDSC: ");
            int idsc = int.Parse(Console.ReadLine());

            Console.WriteLine("IMESC: ");
            string imesc = Console.ReadLine();

            Console.WriteLine("PRZSC: ");
            string przsc = Console.ReadLine();

            Console.WriteLine("IDD: ");
            string idd = Console.ReadLine();

            Console.WriteLine("TITULE: ");
            int titule = int.Parse(Console.ReadLine());

            Console.WriteLine("PBSC: ");
            double pbsc = double.Parse(Console.ReadLine());

            try
            {
                int inserted = skakacService.Save(new Skakac(idsc, imesc, przsc, idd, titule, pbsc));
                if (inserted != 0)
                {
                    Console.WriteLine("Skakac \"{0}\" uspešno unet.", imesc);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleMultipleInserts()
        {
            List<Skakac> skakacList = new List<Skakac>();
            String answer;
            do
            {
                Console.WriteLine("IDSC: ");
                int idsc = int.Parse(Console.ReadLine());

                Console.WriteLine("IMESC: ");
                string imesc = Console.ReadLine();

                Console.WriteLine("PRZSC: ");
                string przsc = Console.ReadLine();

                Console.WriteLine("IDD: ");
                string idd = Console.ReadLine();

                Console.WriteLine("TITULE: ");
                int titule = int.Parse(Console.ReadLine());

                Console.WriteLine("PBSC: ");
                double pbsc = double.Parse(Console.ReadLine());

                skakacList.Add(new Skakac(idsc, imesc, przsc, idd, titule, pbsc));

                Console.WriteLine("Unesi još jednog skakaca? (ENTER za potvrdu, X za odustanak)");
                answer = Console.ReadLine();
            } while (!answer.ToUpper().Equals("X"));

            try
            {
                int numInserted = skakacService.SaveAll(skakacList);
                Console.WriteLine("Uspešno uneto {0} skakaca.", numInserted);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void HandleUpdate()
        {
            Console.WriteLine("IDSC: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                if (!skakacService.ExistsById(id))
                {
                    Console.WriteLine("Uneta vrednost ne postoji!");
                    return;
                }

                Console.WriteLine("IMESC: ");
                string imesc = Console.ReadLine();

                Console.WriteLine("PRZSC: ");
                string przsc = Console.ReadLine();

                Console.WriteLine("IDD: ");
                string idd = Console.ReadLine();

                Console.WriteLine("TITULE: ");
                int titule = int.Parse(Console.ReadLine());

                Console.WriteLine("PBSC: ");
                double pbsc = double.Parse(Console.ReadLine());

                int updated = skakacService.Save(new Skakac(id, imesc, przsc, idd, titule, pbsc));
                if (updated != 0)
                {
                    Console.WriteLine("Skakac \"{0}\" uspešno izmenjen.", id);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
