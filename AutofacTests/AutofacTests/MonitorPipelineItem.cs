using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTests
{
    public abstract class MonitorPipelineItem : IMonitorPipelineItem
    {
        public void ProcessData(IMonitorData data)
        {
            if (ReviewData(data) && _next != null)
            {
                _next.ProcessData(data);
            }
        }
        
        protected abstract bool ReviewData(IMonitorData data);
        
        private IMonitorPipelineItem _next;

        public void SetNextItem(IMonitorPipelineItem pipelineItem)
        {
            _next = pipelineItem;   
        }
    }
}
