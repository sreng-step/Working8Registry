using Microsoft.Win32;
foreach(string? name in Registry.CurrentUser.GetSubKeyNames())
{
    Console.WriteLine(name);
}
using (RegistryKey? key = Registry.CurrentUser.OpenSubKey("FTSDM11",true))
{
    RegistryKey? subkey = key?.CreateSubKey("GoodMorning");
    if (subkey == null) subkey = key?.OpenSubKey("GoodMorning", true);
    if(subkey != null)
    {
        subkey.SetValue("UsersCount", 700, RegistryValueKind.DWord);
    }
    subkey?.Close();
    Console.WriteLine("GoogMorning key is created.");
}
