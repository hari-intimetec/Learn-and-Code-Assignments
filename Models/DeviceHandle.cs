public class DeviceHandle
{
    public static readonly DeviceHandle Invalid = new DeviceHandle(false);

    public bool IsValid { get; }

    public DeviceHandle(bool isValid)
    {
        IsValid = isValid;
    }
}