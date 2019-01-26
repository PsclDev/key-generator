using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Generator
{
    class Program
    {
        public static List<string> SerialKeys = new List<string>();
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
                    string tempKey = Key.Generate(pattern);
                    SerialKeys.Add(tempKey);
                    progress.Report((double)i / amount);
                }
            }
            Console.WriteLine("Keys generated");
            Console.WriteLine();
            Console.WriteLine("Start Export");
            Console.WriteLine();
        }

        static void ExportKeys()
        {
            try
            {
                int amount = Program.SerialKeys.Count;
                DateTime now = DateTime.Now;
                string ExportPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\SerialKeyGenerator";
                Directory.CreateDirectory(ExportPath);


                string filename = $"{ExportPath}\\{amount} Keys_Generated__Date_{now.ToString("ddMMyyyy - hhmm")}.txt";
                FileStream fs = new FileStream(filename, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                using (var progress = new ProgressBar())
                {
                    for (int i = 0; i < SerialKeys.Count; i++)
                    {
                        sw.WriteLine(SerialKeys[i]);
                        progress.Report((double)i / SerialKeys.Count);
                    }
                }
                sw.Close();

                Database.AddSerialKeys();

                Console.WriteLine("Keys has been exported");

                System.Diagnostics.Process.Start(ExportPath);
            }
            catch (Exception ex)
            {
                ErrorHandling.PrintError(ex.ToString());
            }
        }
    }
}
