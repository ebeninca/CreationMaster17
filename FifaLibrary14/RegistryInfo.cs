// Original code created by Rinaldo

using Microsoft.Win32;

namespace FifaLibrary
{
  public class RegistryInfo
  {
    private static string GetString(string year, string key)
    {
      string str = (string) null;
      RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(year);
      if (registryKey != null)
      {
        str = (string) registryKey.GetValue(key);
        if (str.EndsWith("\\"))
          str = str.Substring(0, str.Length - 1);
        registryKey.Close();
      }
      return str;
    }

    public static string GetLatestFifaInstalled()
    {
      for (int index = 20; index >= 10; --index)
      {
        string year1 = "SOFTWARE\\EA SPORTS\\FIFA " + index.ToString();
        if (RegistryInfo.GetString(year1, "Install Dir") != null)
          return year1;
        string year2 = "SOFTWARE\\Wow6432Node\\EA SPORTS\\FIFA " + index.ToString();
        if (RegistryInfo.GetString(year2, "Install Dir") != null)
          return year2;
      }
      return (string) null;
    }

    public static string[] GetAllFifaInstalled()
    {
      int length = 0;
      string[] subKeyNames = Registry.LocalMachine.OpenSubKey("SOFTWARE\\EA SPORTS").GetSubKeyNames();
      for (int index = 0; index < subKeyNames.Length; ++index)
      {
        if (!subKeyNames[index].StartsWith("FIFA"))
          subKeyNames[index] = (string) null;
        else
          ++length;
      }
      if (length == 0)
        return (string[]) null;
      string[] strArray = new string[length];
      int num = 0;
      for (int index = 0; index < subKeyNames.Length; ++index)
      {
        if (subKeyNames[index] != null)
          strArray[num++] = subKeyNames[index];
      }
      return strArray;
    }

    public static string GetFifaKey(int year)
    {
      return "SOFTWARE\\EA SPORTS\\FIFA " + year.ToString();
    }

    public static bool IsFifaInstalled(string game)
    {
      return RegistryInfo.GetString(game, "Install Dir") != null;
    }

    public static string GetInstallDir(string game)
    {
      string str = RegistryInfo.GetString(game, "Install Dir");
      if (str != null && str.EndsWith("\\"))
        str = str.Substring(0, str.Length - 1);
      return str;
    }

    public static string GetFolder(string game)
    {
      return RegistryInfo.GetString(game, "Folder");
    }

    public static string GetLocale(string game)
    {
      return RegistryInfo.GetString(game, "Locale");
    }
  }
}
