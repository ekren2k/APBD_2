using APBD_2;

    DeviceManager dm = new DeviceManager("input.txt");
    dm.ShowAllDevices();
    dm.TurnOffDevice("SW-1"); 
    dm.ShowAllDevices();
    dm.RemoveDevice("SW-1");
    Console.WriteLine();
    dm.ShowAllDevices();
