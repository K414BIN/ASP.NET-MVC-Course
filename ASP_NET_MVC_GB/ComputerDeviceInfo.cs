namespace ASP_NET_MVC_GB
{
    public sealed class ComputerDeviceInfo : IDeviceInfo
    {
            public ICpuData Cpu { get; set; }   
            public IRAMMemory Memory { get; set; }

     
        public void Accept (IMonitorVisitor visitor)
        {
                if (visitor is null)  return;
                visitor.VisitComputer(this);
        }
    }
}
