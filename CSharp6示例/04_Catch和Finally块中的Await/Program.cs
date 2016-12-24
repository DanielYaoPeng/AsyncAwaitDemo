using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _04_Catch和Finally块中的Await
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        async Task Test()
        {
            var wc = new WebClient();
            try
            {
                await wc.DownloadDataTaskAsync("");
            }
            catch (Exception)
            {
                await wc.DownloadDataTaskAsync("");
            }
            finally
            {
                await wc.DownloadDataTaskAsync("");
            }
        }
    }
}
