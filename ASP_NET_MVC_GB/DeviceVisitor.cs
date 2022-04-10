namespace ASP_NET_MVC_GB
{
    public sealed class DeviceVisitor : IMonitorVisitor
    {
        public void VisitComputer(IDeviceInfo info)
        {
            throw new NotImplementedException();
        }

        public void VisitController(IDeviceInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
