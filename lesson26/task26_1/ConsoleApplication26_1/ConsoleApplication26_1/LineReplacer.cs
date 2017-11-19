using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication26_1
{
    internal class LineReplacer
    {
        private static readonly object Locker = new object();
        public void ReplaceLinesInFiles(string path, string wordToReplace, string replacingWord)
        {
            var files = Directory.GetFiles(path, "*.txt");

            Parallel.ForEach(files, currentfile =>
            {
                var text = File.ReadAllText(currentfile);
                var words = text.Split();
                var changedWords=new string[words.Length];
                
                    for (var i = 0; i < words.Length; i++)
                    {
                        if (words[i] == wordToReplace)
                        {
                            changedWords[i] = replacingWord;
                            lock (Locker)
                            {
                                using (TextWriter tw = new StreamWriter("date.txt", true))
                                {
                                    tw.WriteLine(string.Format("{0}-{1}-{2}", Path.GetFileNameWithoutExtension(currentfile),
                                                                    words[i],
                                                                    changedWords[i]) + Environment.NewLine);
                                }
                            }
                        }
                        else { changedWords[i] = words[i]; }
                    }
                File.WriteAllText(currentfile, string.Join(" ",changedWords));
            });
        }
    }
}
