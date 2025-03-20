namespace APBD_2;

public abstract class Device
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool IsTurnedOn { get; set; }

    public Device(int id, string name)
    {
        Id = id;
        Name = name;
        IsTurnedOn = false;
    }

    public override string ToString()
    {
        return "Device name: "+Name+", id:"+Id+", turned on: "+IsTurnedOn;
    }

    public virtual void TurnOn()
    {
        IsTurnedOn = true;
        Console.WriteLine("Turned on device: "+Name);
    }

    public virtual void TurnOff()
    {
        IsTurnedOn = false;
        Console.WriteLine("Turned off device: "+Name);
    }
}