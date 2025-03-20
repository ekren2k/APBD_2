namespace APBD_2;

public abstract class Device
{
    private int Id
    {
        get; set;
    }

    private string Name
    {
        get; set;
    }

    private bool IsTurnedOn
    {
        get; set;
    }

    public Device(int id, string name, bool isTurnedOn)
    {
        Id = id;
        Name = name;
        IsTurnedOn = isTurnedOn;
    }

    protected Device()
    {
        throw new NotImplementedException();
    }
}