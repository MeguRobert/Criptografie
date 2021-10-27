using System;
using System.Collections.Generic;

namespace Lab_Oros_02
{
    internal class PlayFairCipher : ICipher
    {
        public PlayFairCipher()
        {
        }

        public string Key
        {
            get
            {
                return passPhrase;
            }
            set
            {
                // TODO validation (just letters) 
                passPhrase = value.ToUpper().Replace('J', 'I');
                GenerateKeyMatrix();
            }
        }

        private char[,] key;

        private void GenerateKeyMatrix()
        {
            key = new char[5, 5];

            Dictionary<char, bool> dictionary = new Dictionary<char, bool>();
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            foreach (char item in alphabet)
            {
                dictionary.Add(item, false);
            }

            int lin = 0, col = 0;
            for (int i = 0; i < passPhrase.Length; i++)
            {
                if (dictionary[passPhrase[i]] == false)
                {
                    dictionary[passPhrase[i]] = true;
                    key[lin, col] = passPhrase[i];
                    col++;

                    if (col == 5)
                    {
                        lin++;
                        col = 0;
                    }
                }
            }

            foreach (KeyValuePair<char, bool> item in dictionary)
            {
                if (item.Value == false)
                {
                    key[lin, col] = item.Key;
                    col++;
                    if (col == 5)
                    {
                        lin++;
                        col = 0;
                    }
                }
            }

        }

        public void PrintKeyMatrix()
        {
            for (int i = 0; i < key.GetLength(0); i++)
            {
                for (int j = 0; j < key.GetLength(1); j++)
                {
                    Console.Write($"{key[i, j]} ");
                }
                Console.WriteLine();

            }

        }

        private string passPhrase;

        public string Decrypt(string cipherText)
        {
            throw new System.NotImplementedException();
        }

        public string Encrypt(string message)
        {
            List<(char, char)> letterPairs = new List<(char, char)>();
            // TODO validation (only letters)
            message = message.ToUpper().Replace('J', 'I');

            // TODO ENCRYPT ALGO

            return null;
        }


    }
}