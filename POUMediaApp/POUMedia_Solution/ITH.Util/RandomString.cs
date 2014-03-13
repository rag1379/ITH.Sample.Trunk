using System;
using System.Collections.Generic;
using System.Text;

namespace ITH.Library
{
    public static class RandomString
    {
        /// <summary>
        /// Randoms the number generator.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string Generate(int length)
        {
            System.Security.Cryptography.RandomNumberGenerator rng = System.Security.Cryptography.RandomNumberGenerator.Create();

            char[] chars = new char[length];

            //based on your requirment you can take only alphabets or number
            string validChars = "abcdefghijklmnopqrstuvwxyzABCEDFGHIJKLMNOPQRSTUVWXYZ1234567890";

            for (int i = 0; i < length; i++)
            {
                byte[] bytes = new byte[1];
                rng.GetBytes(bytes);

                Random rnd = new Random(bytes[0]);

                chars[i] = validChars[rnd.Next(0, 61)];
            }

            return (new string(chars));
        }
    }
}
