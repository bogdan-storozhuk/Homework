using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    internal class Archivator
    {
        private static readonly object Locker = new object();

        public void Archive(object path)
        {
            var files = Directory.GetFiles((string) path);
            var directories = Directory.GetDirectories((string)path);
            var threads = new Thread[directories.Length];
            for (var i = 0; i < directories.Length; i++)
            {
                threads[i] = new Thread(Archive);
                threads[i].Start(directories[i]);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            lock (Locker)
            {
                foreach (var file in files)
                {
                    if (File.Exists(string.Format("{0}/{1}.zip", path, Path.GetFileNameWithoutExtension(file))))
                    {
                        File.Delete(string.Format("{0}/{1}.zip", path, Path.GetFileNameWithoutExtension(file)));
                    }
                    Directory.CreateDirectory(string.Format("{0}/{1}", path, Path.GetFileNameWithoutExtension(file)));
                    File.Copy(file, string.Format("{0}/{1}/{2}", path, Path.GetFileNameWithoutExtension(file),Path.GetFileName(file)));
                    ZipFile.CreateFromDirectory(string.Format("{0}/{1}", path, Path.GetFileNameWithoutExtension(file)), string.Format("{0}/{1}.zip", path, Path.GetFileNameWithoutExtension(file)));
                    var filesToDelete = Directory.GetFiles(
                        string.Format("{0}/{1}", path, Path.GetFileNameWithoutExtension(file)));
                    foreach (var fileToDelete in filesToDelete)
                    {
                        File.Delete(fileToDelete);
                    }
                    Directory.Delete(string.Format("{0}/{1}", path, Path.GetFileNameWithoutExtension(file)));
                    
                }
            }
        }
    }
}
