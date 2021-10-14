using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHelper
{
    public class MyFile : IMyfile
    {
        public List<string> GetRows(string path) => ReadFile(path);

        private List<string> ReadFile(string path)
        {
            using var stream = new StreamReader(path);
            stream.ReadLine();
            List<string> myList = new List<string>();
            while (!stream.EndOfStream)
            {
                var myRow = stream.ReadLine();

                myList.Add(myRow);

            }

            return myList;
        }

        public bool Put(string path, List<string> content)
        {
            if(File.Exists(path) != null )
            { 
                File.AppendAllLines(path, content);
                return true;
            }
            else
            {
                string header = "Id;Name;SurrName;Phone;Email;BirthDate" + Environment.NewLine;
                File.WriteAllText(path, header);
                if ( Put(path, content) != null)
                    return true;
                else
                    return false;
                
            }
            return false;
        }
    }
}
