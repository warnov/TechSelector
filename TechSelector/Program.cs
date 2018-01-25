using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TechSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Y = "Y";
            const string SEP = "\t";
            const string FILENAME = "techlist.txt";
            
            var techsText = File.ReadAllText(FILENAME);
            var techsList = techsText.Split(SEP[0]);
            var sb = new StringBuilder();

            Console.WriteLine("OCP LATAM TE's Partner Technologies Selector Tool");
            Console.WriteLine("=================================================\n\n\n");

            ConsoleKey cont = ConsoleKey.Y;
            do
            {
                Console.WriteLine("Enter your partner's name: ");
                var partnerName = Console.ReadLine();
                Console.WriteLine("\n\n\nType Y if the tech applies for your partner. Otherwise type any other key.\n\n");

                var i = 1;
                foreach (var tech in techsList)
                {
                    Console.Write($"[{i++}/{techsList.Count()}] {tech}: ");
                    var ans = Console.ReadKey();
                    sb.Append(
                        ans.Key == ConsoleKey.Y ? $"{Y}{SEP}" : SEP);
                    Console.WriteLine();
                }

                var ansText = sb.ToString();
                var fileName = $"{partnerName} Techs.txt";
                File.WriteAllText(fileName, ansText);                

                Console.WriteLine($"The file {fileName} has been created with your answers. You can copy its contents and paste them in the Excel File\n" +
                    $"{ansText}\n\nContinue with another partner? [Y/N] ");
                cont = Console.ReadKey().Key;
                Console.Clear();
                sb.Clear();
            }
            while (cont == ConsoleKey.Y);
            Console.WriteLine("Press ENTER to exit...");
            Console.Read();
        }
    }
}
