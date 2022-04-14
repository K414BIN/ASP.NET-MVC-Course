
namespace AutofacTests
{
    public interface IMonitorPipelineItem
    {
        void SetNextItem  (IMonitorPipelineItem pipelineItem);   
        //void SetPreviousItem (IMonitorPipelineItem pipelineItem);
        void ProcessData (IMonitorData data);
    }
}
