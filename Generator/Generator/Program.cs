using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("||||||||| KEY  GENERATOR |||||||||");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|            Allowed Chars:             |");
            Console.WriteLine("|      'x' 'X': Random Letter / Number  |");
            Console.WriteLine("|      'y' 'Y': Random Letter           |");
            Console.WriteLine("|      'z' 'Z': Random Number           |");
            Console.WriteLine("|                                       |");
            Console.WriteLine("|   Recommended amount : < 25.000.000   |");
            Console.WriteLine("|    25.000.000 Keys needs ~ 1GB RAM    |");
            Console.WriteLine("|      depending on your Pattern        |");
            Console.WriteLine("|      Used Pattern: XXXXX-XXXXX        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Input your desired Pattern");
            string _pattern = "";

            ConsoleKeyInfo keyX;

            do
            {
                keyX = Console.ReadKey(true);
                if (keyX.Key != ConsoleKey.Backspace)
                {
                    bool _x = false;
                    if (Char.ToUpper(keyX.KeyChar) == 'X' || Char.ToUpper(keyX.KeyChar) == 'Y' || Char.ToUpper(keyX.KeyChar) == 'Z' || Char.ToUpper(keyX.KeyChar) == '-')
                        _x = true;

                    if (_x)
                    {
                        _pattern += keyX.KeyChar;
                        string write = Convert.ToString(keyX.KeyChar);
                        write = write.ToUpper();
                        Console.Write(write);
                    }
                }
                else
                {
                    if (keyX.Key == ConsoleKey.Backspace && _pattern.Length > 0)
                    {
                        _pattern = _pattern.Substring(0, (_pattern.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (keyX.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("How many keys should be generated?");
            string _val = "";

            ConsoleKeyInfo keyN;

            do
            {
                keyN = Console.ReadKey(true);
                if (keyN.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(keyN.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += keyN.KeyChar;
                        Console.Write(keyN.KeyChar);
                    }
                }
                else
                {
                    if (keyN.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (keyN.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            

            Console.ReadLine();
        }

        static void GenerateKeys(string pattern, int amount)
        {
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i < amount; i++)
                {
                    string tempKey = SerialKey.Generate(pattern);
                    if (ExistingKeys.Where(o => string.Equals(tempKey, o, StringComparison.OrdinalIgnoreCase)).Any())
                        amount++;
                    else
                        SerialKeys.Add(tempKey);

                    progress.Report((double)i / amount);
                }
            }
            Console.WriteLine("Keys generated");
            Console.WriteLine();
            Console.WriteLine("Start Export");
            Console.WriteLine();
        }
    }
}
