namespace APBD_2;

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException() : base("No Battery Available") { }
}