using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_自动实现的属性
{
    class Program
    {
        class MyClass
        {
            public string Name { get; set; } = "Fanguzai";
        }

        static void Main(string[] args)
        {
            var myClass=new MyClass();
            Console.WriteLine(myClass.Name);

            Console.Read();
        }
    }
}
