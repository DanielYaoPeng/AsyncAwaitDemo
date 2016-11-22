using System.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication20161120
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

        private async void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            await WriteTextAsync();
        }

        private async void btnRead_Click(object sender, RoutedEventArgs e)
        {
            var fileName = $"temp.txt";
            if (!File.Exists(fileName))
            {
                Debug.WriteLine($"文件找不到：{fileName}");
                return;
            }

            try
            {
                var content = await ReadTextAsync(fileName);
                Debug.WriteLine(content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 异步写入文件
        /// </summary>
        /// <returns></returns>
        private async Task WriteTextAsync()
        {
            var path = $"temp.txt";
            var content = Guid.NewGuid().ToString();

            using (var fs = new FileStream(path,
                FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                var buffer = Encoding.UTF8.GetBytes(content);

                //var writeTask = fs.WriteAsync(buffer, 0, buffer.Length);
                //await writeTask;
                await fs.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// 异步读取文本
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private async Task<string> ReadTextAsync(string fileName)
        {
            using (var fs = new FileStream(fileName,
                FileMode.OpenOrCreate, FileAccess.Read, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                var sb = new StringBuilder();
                var buffer = new byte[0x1000];  //十六进制 等于十进制的 4096
                var readLength = 0;

                while ((readLength = await fs.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    var text = Encoding.UTF8.GetString(buffer, 0, readLength);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }

        private async void btnWriteMulti_Click(object sender, RoutedEventArgs e)
        {
            var folder = $"temp";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            await WriteMultiTextAsync(folder);
        }

        /// <summary>
        /// 异步写入多个文件
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private async Task WriteMultiTextAsync(string folder)
        {
            var tasks = new List<Task>();
            var fileStreams = new List<FileStream>();

            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    var fileName = Path.Combine(folder, $"{i}.txt");
                    var content = Guid.NewGuid().ToString();
                    var buffer = Encoding.UTF8.GetBytes(content);

                    var fs = new FileStream(fileName,
        FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, bufferSize: 4096, useAsync: true);
                    fileStreams.Add(fs);

                    var writeTask = fs.WriteAsync(buffer, 0, buffer.Length);
                    tasks.Add(writeTask);
                }

                await Task.WhenAll(tasks);
            }
            finally
            {
                foreach (var fs in fileStreams)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
    }
}
