using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Metadata;

namespace AutofacTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            var builder = new ContainerBuilder();

            builder.RegisterType<CpuMonitorPipeline>().As<IMonitorPipelineItem>();
            builder.RegisterType<VoltageMonitorPipeline>().As<IMonitorPipelineItem>();
            builder.RegisterDecorator<Decorator,IMonitorPipelineItem>();  
            IContainer container = builder.Build();       
            // Что делать с этим контейнером ?
            // container.
        }


    }
}
