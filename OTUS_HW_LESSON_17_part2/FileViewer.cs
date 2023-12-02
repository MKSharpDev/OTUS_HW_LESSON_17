using System;
using System.Collections.Generic;
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

        public void GetFileNames() 
        {
            string[] allfiles = Directory.GetFiles(path);

            foreach (string filename in allfiles)
            {
                FileArgs fileArgs = new FileArgs();
                Thread.Sleep(500);
                EventHandler<FileArgs> handler = FileFound;
                fileArgs.DisplayMassege = $"Обнаружен файл {filename}";

                handler(this, fileArgs);
            }
        }
    }
}
