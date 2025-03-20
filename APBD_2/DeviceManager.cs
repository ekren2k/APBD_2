using System.Text.RegularExpressions;

namespace APBD_2;

public class DeviceManager
{
    private List<Device> _devices;
    private int MaxDevices = 15;

    public DeviceManager(string filePath)
    {
        _devices = new List<Device>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                try
                {
                    Device device = ParseDevice(line);
                    AddDevice(device);
                }
                catch (Exception e)
                {
                    Console.WriteLine("failed to parse line");
                }
            }
        }
    }
    
    public void RemoveDevice(string id)
    {
        Device device = _devices.Find(d => d.Id == id);
        if (device == null)
        {
            throw new Exception("Device not found");
        }
        _devices.Remove(device);
    }

    public void AddDevice(Device device)
    {
        if (_devices.Count >= MaxDevices) throw new InvalidOperationException("Storage is full");
        else _devices.Add(device);
    }
    public void TurnOnDevice(string id)
    {
        Device device = _devices.Find(d => d.Id == id);
        if (device == null)
        {
            throw new Exception("Device not found.");
        }
        device.TurnOn();
    }

    public void TurnOffDevice(string id)
    {
        Device device = _devices.Find(d => d.Id == id);
        if (device == null)
        {
            throw new Exception("Device not found.");
        }
        device.TurnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var device in _devices)
        {
            Console.WriteLine(device);
        }
    }

    public void SaveDataToFile(string filePath)
    {
        List<string> lines = new List<string>();
        foreach (var device in _devices)
        {
            lines.Add(device.ToString());
        }
        File.WriteAllLines(filePath, lines);
    }

    private Device ParseDevice(string line)
    {
        string[] parts = line.Split(',');
        if (parts.Length < 3)
        {
            throw new FormatException("Corrupted line format.");
        }

        string id = parts[0];
        string name = parts[1];
        if (id.StartsWith("SW"))
        {
            bool isTurnedOn = bool.Parse(parts[2]);
            int batteryPercentage = int.Parse(parts[3].Trim('%'));
            return new Smartwatch(id, name, batteryPercentage) { IsTurnedOn = isTurnedOn };
        }
        else if (id.StartsWith("P"))
        {
            bool isTurnedOn = bool.Parse(parts[2]);
            string os = parts.Length > 3 ? parts[3] : null;
            return new PersonalComputer(id, name, os) { IsTurnedOn = isTurnedOn };
        }
        else if (id.StartsWith("ED"))
        {
            string ipAddress = parts[2];
            string networkName = parts[3];
            if (!Regex.IsMatch(ipAddress, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b"))
            {
                throw new ArgumentException();
            }

            return new EmbeddedDevice(id, name, ipAddress, networkName);
        }

        throw new FormatException("Unknown device type.");
    }
}