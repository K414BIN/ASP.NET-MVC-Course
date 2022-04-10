namespace ASP_NET_MVC_GB
{
    public sealed class ControllerDeviceInfo : IDeviceInfo
    {
        public ICpuData Cpu { get; set; }
        
        public IRAMMemory Memory { get { throw new NotImplementedException(); } }

        
      
        public void Accept(IMonitorVisitor visitor)
        {
            if (visitor is null) return;
            visitor.VisitComputer(this);
        }
    }
}
