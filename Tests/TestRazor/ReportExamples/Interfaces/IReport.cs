using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportExamples.Interfaces
{
    public interface IReport
    {
        public string OsVersion { get; set; }
        public bool Os64 { get; set; }
        public string PcName { get; set; }
        public int NumberOfCpus { get; set; }
        public string WindowsFolder { get; set; }
        public string[] LogicalDrives { get; set; }

        FileInfo Create (string ReportTemplateFile);
    }
}
