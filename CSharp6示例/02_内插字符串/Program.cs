using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_内插字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Fanguzai";
            Console.WriteLine($"Hello, {name}");

            var s1 = $"hello, {name}";
            IFormattable s2 = $"Hello, {name}";
            FormattableString s3 = $"Hello, {name}";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.Read();
        }
    }
}
