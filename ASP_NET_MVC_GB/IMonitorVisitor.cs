namespace ASP_NET_MVC_GB
{
    public interface IMonitorVisitor
    {
        void VisitComputer(IDeviceInfo info);
        void VisitController(IDeviceInfo info);
    }
}