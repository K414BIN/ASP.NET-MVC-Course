using ReportExamples.Interfaces;
using TemplateEngine.Docx;


namespace ReportExamples.Reports;

public class ReportWord : IReport

{
    private readonly FileInfo _file;    
    public string OsVersion { get; set; } = null;
    public bool Os64 { get; set; }
    public string PcName { get; set; } = null;
    public int NumberOfCpus { get; set; } 
    public string WindowsFolder { get; set; } = null;
    public string[] LogicalDrives { get; set; } = null;

    public ReportWord( string TemplateFilePath)
    {
        _file = new (TemplateFilePath); 
    }

    public FileInfo Create(string ReportTemplateFile)  
    {
        if (!_file.Exists)
            throw new FileNotFoundException("Файл шаблона не найден ", _file.FullName);
        var report_file = new FileInfo(ReportTemplateFile );
        if (report_file.Exists) report_file.Delete(); 
        _file.CopyTo(report_file.FullName);
        var content = new Content(
            new FieldContent(PcName, PcName)    ,
            new FieldContent(OsVersion, OsVersion) ,   
            new FieldContent(WindowsFolder, WindowsFolder),
            new FieldContent(Os64.ToString(), Os64.ToString()),
            new FieldContent(NumberOfCpus.ToString(), NumberOfCpus.ToString()),
            new FieldContent(LogicalDrives[0], LogicalDrives[0])
            );
        using var doc =new TemplateProcessor(report_file.FullName)
        .SetRemoveContentControls(true);
        doc.FillContent(content);
        doc.SaveChanges();  
        report_file.Refresh();
        return report_file; 
        }
    
}
