// Original code created by Rinaldo

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace FifaControls.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
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
        if (object.ReferenceEquals((object) FifaControls.Properties.Resources.resourceMan, (object) null))
          FifaControls.Properties.Resources.resourceMan = new ResourceManager("FifaControls.Properties.Resources", typeof (FifaControls.Properties.Resources).Assembly);
        return FifaControls.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return FifaControls.Properties.Resources.resourceCulture;
      }
      set
      {
        FifaControls.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
