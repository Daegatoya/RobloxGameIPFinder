using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RobloxIPFinder
{
    internal class FileReader
    {
        private string path { get; set; }
        private string? IP = null;

        public FileReader(string path, string? IP)
        {
            this.path = path;
            this.IP = IP;

            Finder(ref this.IP);
        }

        private void Finder(ref string? IP)
        {
            string? path = this.path;
            string? line = "";
            StreamReader reader = null;
            DirectoryInfo _dir = new DirectoryInfo(path);
            FileInfo[] files_Array = _dir.GetFiles();
            FileStream streamer;
            IEnumerable<FileInfo> _query;
            int count = 0;

            Func<IEnumerable<FileInfo>> function = () => _query =
            from f in files_Array
            orderby f.CreationTime descending
            select f;

            foreach (FileInfo f in function())
            {
                files_Array[count] = f;
                count++;
            }

            path = Path.Combine(path, files_Array[0].ToString());

            using (streamer = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (reader = new StreamReader(streamer))
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("Connecting to"))
                        {
                            IP = line.Split("to ")[1];
                            break;
                        }
                        else
                        {
                            IP = null;
                        }
                    }
                    reader.Close();
                }
            }
        }

        public string ReturnIP()
        {
            return IP;
        }
    }
}
