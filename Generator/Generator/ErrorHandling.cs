using System;

namespace Generator
{
    public static class ErrorHandling
    {
        public static void PrintError(string error)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("An Error occurred");
            Console.WriteLine(error);
            Console.WriteLine("-----------------");
        }
    }
}
