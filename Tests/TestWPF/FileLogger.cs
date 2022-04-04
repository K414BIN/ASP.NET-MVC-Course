using System;
using System.IO;

namespace TestWPF
{
    internal class FileLogger : Logger 
    {
        private readonly string _fileName;

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }
        public override void Log(string message)
        {
            File.AppendAllText(_fileName,$"{DateTime.Now:s} - {message}{Environment.NewLine}");
        }
    }
}