using System;
using System.IO;
using System.Diagnostics;
using ReportExamples.Models;
using ReportExamples.Interfaces;
using ReportExamples.Reports;
using ReportExamples.Infrastructure;
using RazorEngine;
using RazorEngine.Templating;

class Kalabin_Example
{
    static void Main()
    {
        
        ItemsPCtoView myInfo = new ItemsPCtoView
        {
            OsVersion = Environment.OSVersion.ToString(),
            Os64 = Environment.Is64BitOperatingSystem,
            PcName = Environment.MachineName,
            NumberOfCpus = Environment.ProcessorCount,
            WindowsFolder = Environment.SystemDirectory,
            LogicalDrives = Environment.GetLogicalDrives()
        };

        const string template_file = "template.docx";
        IReport report  = new ReportWord(template_file);
        const string report_file =  "report.docx";
        CreateReport (myInfo, report, report_file) ;
        GenerateReport(myInfo);
        Console.WriteLine(myInfo);
        Console.WriteLine("\nPress a key to close this window..");
        Console.ReadKey();
        
    }
    //TemplateEngine.Docx;
    private static void CreateReport(ItemsPCtoView myInfo, IReport report, string report_file)
    {
       report.LogicalDrives = myInfo.LogicalDrives;
       report.NumberOfCpus = myInfo.NumberOfCpus;  
       report.WindowsFolder = myInfo.WindowsFolder;
       report.OsVersion = myInfo.OsVersion; 
       report.Os64 = myInfo.Os64;  
       report.PcName = myInfo.PcName;  
       var _report_file = report.Create(report_file);
       _report_file.Execute();
    }
    //Razor report
    public static void GenerateReport(ItemsPCtoView myInfo, string output =   "")
    {
        string template = "Компьютер @Model.PcName, Версия Windows @Model.OsVersion";

        string report = Engine.Razor.RunCompile(template,   "myUniqueReport", null, myInfo);
        Console.WriteLine(report);
    }
}