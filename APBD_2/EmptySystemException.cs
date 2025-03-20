namespace APBD_2;

public class EmptySystemException : Exception
{
    public EmptySystemException() : base("No operating system is installed") { }
}