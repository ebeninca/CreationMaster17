// Original code created by Rinaldo

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CreationMaster.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) CreationMaster.Properties.Resources.resourceMan, (object) null))
          CreationMaster.Properties.Resources.resourceMan = new ResourceManager("CreationMaster.Properties.Resources", typeof (CreationMaster.Properties.Resources).Assembly);
        return CreationMaster.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return CreationMaster.Properties.Resources.resourceCulture;
      }
      set
      {
        CreationMaster.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
