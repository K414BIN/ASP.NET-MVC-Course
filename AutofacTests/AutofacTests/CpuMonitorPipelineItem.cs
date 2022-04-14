
namespace AutofacTests
{
    public sealed class CpuMonitorPipeline : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if (data is null)
            {
                return false;
            }
            if (data.Cpu < 2)
            {
                return false;
            }
            return true;    
        }
    }
}
