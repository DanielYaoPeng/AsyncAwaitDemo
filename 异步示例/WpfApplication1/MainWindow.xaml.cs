using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async Task<string> DownloadAsync(string url)
        {
            using (var hc = new HttpClient())
            {
                return await hc.GetStringAsync(url);
            }
        }

        private void DisplayResult(string url, int length)
        {
            var replaceUrl = url.Replace("http://", "");
            tbResult.Text += $"  {replaceUrl}: {length} bytes. \n";
        }

        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var watch = new Stopwatch();
            watch.Start();

            tbResult.Clear();

            await DoAsync();

            watch.Stop();
            tbResult.Text += $"     OK! {watch.ElapsedMilliseconds} ms.";
        }

        private async Task DoAsync()
        {
            var urls = InitUrls();

            foreach (var url in urls)
            {
                var content = await DownloadAsync(url);
                //DisplayResult(url, content.Length);
            }

            //var urlTasksQuery = urls.Select(x => DownloadAsync(x));
            //var urlsTasks = urlTasksQuery.ToArray();

            //var contents = await Task.WhenAll(urlsTasks);
            //var sum = contents.Select(x => x.Length).Sum();

            //tbResult.Text += $"  Total: {sum}"; 添加测试文件
        }

        private IList<string> InitUrls()
        {
            var urls = new List<string>()
            {
                "http://www.cnblogs.com/",
                "http://www.cnblogs.com/liqingwen/",
                "http://www.cnblogs.com/liqingwen/p/5902587.html",
                "http://www.cnblogs.com/liqingwen/p/5922573.html"
            };

            return urls;
        }
    }
}
