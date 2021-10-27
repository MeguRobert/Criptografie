using System;
using System.Text;

namespace Lab_Oros_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "hElLo";
            string key = "XMCKL";
            //OneTimePad_CharacterBased(message, key);
            //OneTimePad_XOR(message, key);

            PlayFairCipher playFairCipher = new PlayFairCipher();
            playFairCipher.Key = "LETSCODETOGETHER";
            playFairCipher.PrintKeyMatrix();

        }

        private static void OneTimePad_XOR(string message, string key)
        {
            if (message.Length > key.Length)
            {
                throw new ArgumentException("Lungimea mesajului este mai mare ca lungimea cheii");
            }
            byte[] messageBytes = Encoding.Unicode.GetBytes(message);
            byte[] keyBytes = Encoding.Unicode.GetBytes(key);
            byte[] cypherTextBytes = TransformXOR(messageBytes, keyBytes);
            byte[] decriptedBytes = TransformXOR(cypherTextBytes, keyBytes);

            string decripted = Encoding.Unicode.GetString(decriptedBytes);

            Console.WriteLine(decripted);
        }

        private static byte[] TransformXOR(byte[] messageBytes, byte[] keyBytes)
        {
            byte[] resultBytes = new byte[messageBytes.Length];

            for (int i = 0; i < messageBytes.Length; i++)
            {
                resultBytes[i] = (byte)(messageBytes[i] ^ keyBytes[i]);
            }

            return resultBytes;
        }

        private static void OneTimePad_CharacterBased(string message, string key)
        {
            string cypherText = Transform(message, key, (x, y) => (x + y) % 26);
            string decrypted = Transform(cypherText, key, (x, y) => (x - y + 26) % 26);

            Console.WriteLine(cypherText);
            Console.WriteLine(decrypted);
        }

        private static string Transform(string message, string key, Func<int, int, int> func)
        {
            if (message.Length > key.Length)
            {
                throw new ArgumentException("Lungimea mesajului este mai mare ca lungimea cheii");
            }

            // TODO message and key validation (should contain only letters) 
            // Use Regex

            StringBuilder cypherText = new StringBuilder(message.Length);
            for (int i = 0; i < message.Length; i++)
            {
                int offset1 = 0, offset2 = 0;
                if (char.IsLetter(message[i]))
                {
                    offset1 = char.ToUpper(message[i]) - 'A';
                }
                else
                {
                    continue;
                }
                if (char.IsLetter(key[i]))
                {
                    offset2 = char.ToUpper(key[i]) - 'A';
                }
                else
                {
                    continue;
                }
                int offset = func(offset1, offset2);

                char c = (char)(char.IsLower(message[i]) ? 'a' + offset : 'A' + offset);
                cypherText.Append(c);
            }

            return cypherText.ToString();
        }
    }
}
