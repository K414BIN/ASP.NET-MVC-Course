namespace ASP_NET_MVC_GB
{
    public interface IRAMMemory
    {
        int FreeMem { get; }
        int TotalMem { get; }
        bool Error { get; }   
    }
}