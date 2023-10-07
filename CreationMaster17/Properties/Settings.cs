// Original code created by Rinaldo

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CreationMaster.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("")]
    [DebuggerNonUserCode]
    public string RootDir
    {
      get
      {
        return (string) this[nameof (RootDir)];
      }
      set
      {
        this[nameof (RootDir)] = (object) value;
      }
    }

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string FifaDbFileName
    {
      get
      {
        return (string) this[nameof (FifaDbFileName)];
      }
      set
      {
        this[nameof (FifaDbFileName)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("")]
    [DebuggerNonUserCode]
    public string FifaXmlFileName
    {
      get
      {
        return (string) this[nameof (FifaXmlFileName)];
      }
      set
      {
        this[nameof (FifaXmlFileName)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string LangDbFileName
    {
      get
      {
        return (string) this[nameof (LangDbFileName)];
      }
      set
      {
        this[nameof (LangDbFileName)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string LangXmlFileName
    {
      get
      {
        return (string) this[nameof (LangXmlFileName)];
      }
      set
      {
        this[nameof (LangXmlFileName)] = (object) value;
      }
    }
  }
}
