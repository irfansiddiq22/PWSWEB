using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Pipewellservice.Helper
{
    public class StringHelper
    {
        private static readonly ThreadLocal<System.Security.Cryptography.RandomNumberGenerator> crng = new ThreadLocal<System.Security.Cryptography.RandomNumberGenerator>(System.Security.Cryptography.RandomNumberGenerator.Create);
        private static readonly ThreadLocal<byte[]> bytes = new ThreadLocal<byte[]>(() => new byte[sizeof(int)]);
        public static string GenerateOTP()
        {
         return   (NextOTP() % 1000000).ToString("000000");
        }
        private static int NextOTP()
        {
            crng.Value.GetBytes(bytes.Value);
            return BitConverter.ToInt32(bytes.Value, 0) & int.MaxValue;
        }
        private static double NextDouble()
        {
            while (true)
            {
                long x = NextOTP() & 0x001FFFFF;
                x <<= 31;
                x |= (long)NextOTP();
                double n = x;
                const double d = 1L << 52;
                double q = n / d;
                if (q != 1.0)
                    return q;
            }
        }
        public static string NullToString(object value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value.ToString();
            }
        }
    }
    
}