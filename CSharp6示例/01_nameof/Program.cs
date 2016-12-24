using System;
using SystemTest = System.Text;


namespace _01_nameof
{
    class Program
    {
        private static void Func1(int x) { }
        private string F<T>() => nameof(T);
        private void Func2(string msg) { }

        static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine(nameof(SystemTest));
            Console.WriteLine(nameof(Func1));
            Console.WriteLine(nameof(Program));
            Console.WriteLine(nameof(program));
            Console.WriteLine(nameof(F));

            Console.Read();
        }

        private void Func(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                throw new ArgumentException(nameof(msg));
            }
        }
    }
}
