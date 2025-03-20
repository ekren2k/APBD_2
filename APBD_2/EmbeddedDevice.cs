using System.Text.RegularExpressions;

namespace APBD_2;

public class EmbeddedDevice : Device
{
    public string IpAddress
    {
        get { return IpAddress; }
        set
        {
            string pattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            if (!Regex.IsMatch(value, pattern)) throw new ArgumentException();
            else IpAddress = value;
        }
    }
    public string NetworkName { get; set; }

    public EmbeddedDevice(string id, string name, string ipAdress, string networkName) : base(id, name)
    {
        IpAddress = ipAdress;
        NetworkName = networkName;
    }

    public void Connect()
    {
        if (NetworkName.Contains("MD Ltd.")) throw new ConnectionException();
        else Console.WriteLine("Successfully connected to network: " + NetworkName);
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Connect();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}