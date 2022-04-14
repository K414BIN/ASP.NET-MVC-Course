
namespace AutofacTests
{
    public sealed class VoltageMonitorPipeline : MonitorPipelineItem
    {
        protected override bool ReviewData(IMonitorData data)
        {
            if (data is null)
            {
                return false;
            }
            if (data.Voltage == 0 )
            {
                return false;
            }
            return true;    
        }
    }
}
