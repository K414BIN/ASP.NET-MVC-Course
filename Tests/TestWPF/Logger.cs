using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    internal abstract class Logger : ILogger
    {
        public abstract void Log(string message);   
    }
}
