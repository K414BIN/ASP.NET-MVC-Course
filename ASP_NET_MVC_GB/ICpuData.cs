namespace ASP_NET_MVC_GB
{
    public interface ICpuData
    {
        int Percent { get; }    
        int Threads { get; }   
        bool Error { get; }   
    }
}