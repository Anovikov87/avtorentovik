using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Avtorentovik.Utils
{
    public class MD5Hash
    {
        /// <summary>
        /// Возвращает хэш-строку, являющуюся результатом алгоритма MD5 ко входной строке
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Get(string instr, Encoding encoding)
        {
            return new MD5CryptoServiceProvider().ComputeHash(encoding.GetBytes(instr))
                .Aggregate(string.Empty, (current, b) => current + b.ToString("x2"));
        }
    }
}
