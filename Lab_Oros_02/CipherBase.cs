using System;

namespace Lab_Oros_02
{
    class CipherBase : ICipher
    {
        public string Key { get; set; }

        public string Decrypt(string cipherText)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string message)
        {
            throw new NotImplementedException();
        }
    }
}
