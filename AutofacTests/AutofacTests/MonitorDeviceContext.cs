
namespace AutofacTests
{
    public sealed class MonitorDeviceContext 
    {
        private readonly IMonitoringSystemDevice _monitoringSystemDevice;

        public MonitorDeviceContext(IMonitoringSystemDevice  monitoringSystemDevice)
        {
            _monitoringSystemDevice = monitoringSystemDevice;
        }

        public IMonitoringSystemDevice Get_monitoringSystemDevice()
        {
            return _monitoringSystemDevice;
        }

        public void RunMonitorProcess()
        {
            IMonitorPipelineItem pipelineItem = CreatePipeline();
            // Compiler Error CS1579 ---------------+
            //                                      |
            //                                      V              
            foreach (IMonitorData data in _monitoringSystemDevice) // Что-то пошло не так ...
            {
                pipelineItem.ProcessData(data);
            }
        }

        private IMonitorPipelineItem CreatePipeline()
        {
            IMonitorPipelineItem cpuMonitorPipelineItem = new CpuMonitorPipeline();
            IMonitorPipelineItem voltageMonitorPipelineItem = new VoltageMonitorPipeline();

            cpuMonitorPipelineItem.SetNextItem(voltageMonitorPipelineItem);
            return cpuMonitorPipelineItem;
        }
    }
}

