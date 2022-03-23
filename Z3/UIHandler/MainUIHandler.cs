using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3.UIHandler
{
    public class MainUIHandler
    {
        private readonly SkakacUIHandler skakacUIHandler = new SkakacUIHandler();
        private readonly ComplexQueryUIHandler complexQueryUIHandler = new ComplexQueryUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje skakacima");
                Console.WriteLine("2 - Kompleksni upiti");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        skakacUIHandler.HandleTheatreMenu();
                        break;
                    case "2":
                        complexQueryUIHandler.HandleComplexQueryMenu();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
