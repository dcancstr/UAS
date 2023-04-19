using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Utilities.Helpers
{
    public static class UniqueId
    {
        public static string GetUniqueId()
        {

            int maxSize = 10;
            //int minSize = 9;
            char[] chars = new char[62];
            string a;
            a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RandomNumberGenerator provider = RandomNumberGenerator.Create();
            provider.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            provider.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();

        }

    }
}
