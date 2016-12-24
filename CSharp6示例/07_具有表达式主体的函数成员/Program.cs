using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_具有表达式主体的函数成员
{
    class Program
    {
        

        class MyClass
        {
            public int this[int id] => id;  //索引

            public double Add(int x, int y) => x + y;   //带返回值方法

            public void Output() => Console.WriteLine("Hi, Fanguzai!"); //无返回值方法
        }

        static void Main(string[] args)
        {
        }
    }
}
