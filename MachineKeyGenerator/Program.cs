using System;
using System.Security.Cryptography;
using System.Text;

namespace MachineKeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] commandLineArgs = Environment.GetCommandLineArgs();
            string decryptionKey = CreateKey(Convert.ToInt32(commandLineArgs[1]));
            string validationKey = CreateKey(Convert.ToInt32(commandLineArgs[2]));

            Console.WriteLine("<machineKey validationKey=\"{0}\" decryptionKey=\"{1}\" validation=\"SHA1\"/>", validationKey, decryptionKey);
        }

        static String CreateKey(int numBytes)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[numBytes];

            rng.GetBytes(buff);
            return BytesToHexString(buff);
        }

        static String BytesToHexString(byte[] bytes)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int counter = 0; counter < bytes.Length; counter++)
            {
                hexString.Append(String.Format("{0:X2}", bytes[counter]));
            }
            return hexString.ToString();
        }
    }
}
