namespace AutofacTests
{
    public interface IMonitorData
    {
        int Cpu { get; }
        int Voltage { get; }
        bool TurnedOn { get; }
    }
}