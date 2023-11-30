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
        public delegate void FileHandler(string message);
        public event FileHandler? Notify;

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
                Notify?.Invoke($"Обнаружен файл {filename}");
                Thread.Sleep(500);          
            }
        }
    }
}
