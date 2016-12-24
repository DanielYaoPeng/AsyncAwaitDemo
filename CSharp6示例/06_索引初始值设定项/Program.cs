using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_索引初始值设定项
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new Dictionary<int, string>
            {
                [7] = "seven",
                [9] = "nine",
                [13] = "thirteen"
            };

            //这是旧的方式
            var otherNums = new Dictionary<int, string>()
            {
                {1, "one"},
                {2, "two"},
                {3, "three"}
            };
        }
    }
}
