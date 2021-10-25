using System;

namespace Lab_Oros_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cipher = null;
            int key = 3;

            for (int i = 0; i < key; i++)
            {
                cipher = alphabet.Substring(key) + alphabet.Substring(0, key);
            }

            Console.WriteLine(alphabet);
            Console.WriteLine(cipher);

            string plaintext = Console.ReadLine();



        }
    }
}
