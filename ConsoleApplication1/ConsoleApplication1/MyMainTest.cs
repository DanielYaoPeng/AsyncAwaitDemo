using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyMainTest
    {
        static void Main(string[] args)
        {
            var msg = "1a2b3";
            var temp = "";
            foreach (var c in msg)
            {
                int num;
                if (int.TryParse(c.ToString(), out num))
                {
                    temp += c;
                }
                else
                {
                    temp += ",";
                }
            }

            Console.WriteLine(temp);

            Console.Read();
        }
    }
}
