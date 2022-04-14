namespace AutofacTests
{
    public sealed class Decorator : IMonitorPipelineItem
    {
        private readonly IMonitorPipelineItem _pipelineItem;    

        public Decorator (IMonitorPipelineItem decoratedPipelineItem)
        {
            _pipelineItem = decoratedPipelineItem;
        }
        public void ProcessData(IMonitorData data)
        {
            _pipelineItem.ProcessData(data);
        }

        public void SetNextItem(IMonitorPipelineItem pipelineItem)
        {
            _pipelineItem.SetNextItem(pipelineItem);
        }
        // Запуск чего ? Мне кажется я неверно прописал здесь Run
        public void Run()
        {

        }
    }
}