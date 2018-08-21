using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace FileChecksum
{
    class Program
    {
        static void Main(string[] args)
        {
            var twoFiles = Directory.GetFiles("Images").Take(2);

            var hash1 = CalculateMD5(twoFiles.First());
            var hash2 = CalculateMD5(twoFiles.Last());

            Console.WriteLine("Hash1 == Hash2 ? {0}", hash1 == hash2);
            Console.ReadLine();
        }

        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", string.Empty);
                }
            }
        }
    }
}
