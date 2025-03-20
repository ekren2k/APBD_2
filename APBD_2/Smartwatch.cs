
namespace APBD_2;

public class Smartwatch : Device, IPowerNotifier
{
    private int _batteryPercentage;
    public int BatteryPercentage
    {
        get
        {
            return _batteryPercentage;
        }
        set
        {
            if (value < 0) _batteryPercentage = 0;
            if (value > 100) _batteryPercentage = 100;
            if (value < 20)
            {
                LowPowerNotification();
                _batteryPercentage = value;
            }
            else _batteryPercentage = value;
        }
    }

    public Smartwatch(string id, string name, int batteryPercentage) : base(id, name)
    {
        if (batteryPercentage < 0) BatteryPercentage = 0;
        if (batteryPercentage > 100) BatteryPercentage = 100;
        if (batteryPercentage < 20) LowPowerNotification();
        else BatteryPercentage = batteryPercentage;
    }

    public void LowPowerNotification()
    {
        Console.WriteLine("Low battery percentage: "+BatteryPercentage);
    }

    public override void TurnOn()
    {
        if (BatteryPercentage < 11) throw new EmptyBatteryException();
        if (BatteryPercentage <=20) LowPowerNotification();
        BatteryPercentage = BatteryPercentage - 10;
        base.TurnOn();
    }

    public override string ToString()
    {
        return "Device name: "+Name+", id:"+Id+", turned on: "+IsTurnedOn + ", battery percentage: " +BatteryPercentage;
    }
}