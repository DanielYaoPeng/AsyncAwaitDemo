using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppDemo20161118
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

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            btnSwitch.IsEnabled = false;

            //清除文本框所有内容
            tbResult.Clear();

            //统计总数
            await SumSizesAsync();

            btnSwitch.IsEnabled = true;
        }

        /// <summary>
        /// 异步统计总数
        /// </summary>
        private async Task SumSizesAsync()
        {

            var hc = new HttpClient() { MaxResponseContentBufferSize = 1024000 };
            //加载网址
            var urls = InitUrlInfoes();

            //字节总数
            var totalCount = 0;
            foreach (var url in urls)
            {
                //返回一个 url 内容的字节数组
                //var contents = await GetUrlContentsAsync(url);
                var contents = await hc.GetByteArrayAsync(url);

                //显示结果
                DisplayResults(url, contents);

                //更新总数
                totalCount += contents.Length;
            }

            tbResult.Text += $"\r\n         Total: {totalCount}， OK！";
        }

        /// <summary>
        /// 初始化 url 信息列表
        /// </summary>
        /// <returns></returns>
        private IList<string> InitUrlInfoes()
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

        /// <summary>
        /// 异步获取网址内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <remarks>
        /// private async byte[] GetUrlContents(string url)
        /// private async Task<byte[]> GetUrlContents(string url)
        /// </remarks>
        private async Task<byte[]> GetUrlContentsAsync(string url)
        {
            //假设下载速度平均延迟 300 毫秒
            //Thread.Sleep(300);
            await Task.Delay(300);

            using (var ms = new MemoryStream())
            {
                var req = WebRequest.Create(url);

                //var response = req.GetResponse();
                //Task<WebResponse> responseTask = req.GetResponseAsync();
                //var response = await responseTask;

                using (var response = await req.GetResponseAsync())
                {
                    //从指定 url 里读取数据
                    using (var rs = response.GetResponseStream())
                    {
                        //从当前流中读取字节并将其写入到另一流中
                        //rs.CopyTo(ms);
                        await rs.CopyToAsync(ms);
                    }
                }

                return ms.ToArray();
            }
        }

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        private void DisplayResults(string url, byte[] content)
        {
            //内容长度
            var bytes = content.Length;

            //移除 http:// 前缀
            var replaceUrl = url.Replace("http://", "");

            //显示
            tbResult.Text += $"\r\n {replaceUrl}:   {bytes}";
        }
    }
}
