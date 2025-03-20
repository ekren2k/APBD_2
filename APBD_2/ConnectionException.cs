namespace APBD_2;

public class ConnectionException : Exception
{
    public ConnectionException() : base("Illegal connection") { }
}