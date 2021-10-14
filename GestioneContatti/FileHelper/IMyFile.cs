using System;
using System.Collections.Generic;

namespace FileHelper
{
    public interface IMyfile
    {
        List<string> GetRows(string path);
        bool Put(string path, List<string> content);
    }
}
