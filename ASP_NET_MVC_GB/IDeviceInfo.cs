namespace ASP_NET_MVC_GB
{
    public interface IDeviceInfo
    {
        IRAMMemory Memory { get; }
        ICpuData Cpu { get; }

        void Accept(IMonitorVisitor visitor);
    }
}
