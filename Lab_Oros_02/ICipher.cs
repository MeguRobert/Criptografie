namespace Lab_Oros_02
{
    interface ICipher
    {
        string Key { get; set; }

        string Encrypt(string message);

        string Decrypt(string cipherText);
    }
}
