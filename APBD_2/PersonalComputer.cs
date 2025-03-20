namespace APBD_2;

public class PersonalComputer : Device
{
    private string OperatingSystem
    { get; set; }

    public PersonalComputer(string id, string name, string operatingSystem) : base(id, name)
    {
        OperatingSystem = operatingSystem;
    }

    public override void TurnOn()
    {
        if (string.IsNullOrEmpty(OperatingSystem)) throw new EmptySystemException();
        else base.TurnOn();
    }
}