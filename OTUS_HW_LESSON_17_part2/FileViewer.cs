using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTUS_HW_LESSON_17_part2
{
    public class FileViewer
    {
        public string path;

        public event EventHandler<FileArgs> FileFound;

        public FileViewer()
        {
            this.path = "..\\Test";
        }
        public FileViewer(string path)
        {
            this.path = path;
        }

        public async Task GetFileNames(CancellationToken token, Stopwatch stopwatch)
        {
            string[] allfiles = Directory.GetFiles(path);

            foreach (string filename in allfiles)
            {
                if (token.IsCancellationRequested)
                {
                    stopwatch.Stop();
                    Console.WriteLine($"Операция отменена через - {stopwatch.ElapsedMilliseconds} мс");
                    break;
                }
                FileArgs fileArgs = new FileArgs();
                Thread.Sleep(700);
                EventHandler<FileArgs> handler = FileFound;
                fileArgs.DisplayMassege = $"Обнаружен файл {filename}";
                
                handler(this, fileArgs);
            }
        }
    }
}