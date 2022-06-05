using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Diagnostics;

namespace ReportExamples.Models;

public class ItemsPCtoView 
{
    public string OsVersion { get; set; }
    public bool Os64 { get; set; }
    public string PcName { get; set; }
    public int NumberOfCpus { get; set; }
    public string WindowsFolder { get; set; }
    public string[] LogicalDrives { get; set; }

    public override string ToString()
    {
        const double BytesInMB = 1048576;
        const double BytesInGB = 1073741824;
        StringBuilder output = new StringBuilder();
        output.AppendFormat("Windows version: {0}\n", OsVersion);
        output.AppendFormat("64 Bit operating system? : {0}\n",
           Os64 ? "Yes" : "No");
        output.AppendFormat("PC Name : {0}\n", PcName);
        output.AppendFormat("Number of CPUS : {0}\n", NumberOfCpus);
        output.AppendFormat("Windows folder : {0}\n", WindowsFolder);
        output.AppendFormat("Logical Drives Available : {0}\n",
              String.Join(", ", LogicalDrives)
           .Replace("\\", String.Empty));

        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            // Skip to next loop cycle when drive is not ready
            if (!drive.IsReady)
                continue;

            output.AppendFormat("\nDrive: {0} ({1}, {2})\n",
                drive.Name, drive.DriveType, drive.DriveFormat);

            // Show the used and total size in MB and GB, with two decimals
            output.AppendFormat("  Used space:\t{0:0.00} MB\t{1:0.00} GB\n",
                (drive.TotalSize - drive.TotalFreeSpace) / BytesInMB,
                (drive.TotalSize - drive.TotalFreeSpace) / BytesInGB);

            output.AppendFormat("  Total size:\t{0:0.00} MB\t{1:0.00} GB\n",
                drive.TotalSize / BytesInMB,
                drive.TotalSize / BytesInGB);
        }
        return output.ToString();
    }
}


