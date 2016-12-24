using System;
using static System.Console;

namespace _08_usingStatic类型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi,Fanguzai!");
            WriteLine("Hi,Fanguzai!");  // 使用了 using static System.Console;
        }
    }
}
