using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_NULL_条件运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = null;
            Console.WriteLine($"1：{name?.Length}");

            name = "Fanguzai";
            Console.WriteLine($"2：{name?.Length}");
            Console.WriteLine($"3: {name?[0]}");

            //普通的委托调用
            Func<int> func = () => 0;
            if (func!=null)
            {
                func();
            }

            //简化调用
            func?.Invoke();

            Console.Read();
        }

        public int A { get; set; }
    }
}
