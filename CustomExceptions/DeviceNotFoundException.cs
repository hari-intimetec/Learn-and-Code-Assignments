public class DeviceNotFoundException : Exception
{
    public DeviceNotFoundException() : base("Invalid device handle.") { }
}