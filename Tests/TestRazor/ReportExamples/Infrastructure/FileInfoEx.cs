 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ReportExamples.Infrastructure
{
    internal static  class FileInfoEx
    {
        public static Process? Execute(this FileInfo file, bool UseShellExecute = true)
        {
            var info = new ProcessStartInfo(file.FullName) { UseShellExecute = UseShellExecute };   
            return Process.Start(info); 

        }
    }
}
