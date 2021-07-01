// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Net : IdObject
  {
    public Net(int netId)
      : base(netId)
    {
    }

    public override IdObject Clone(int newId)
    {
      Net net = (Net) base.Clone(newId);
      if (net != null)
        FifaEnvironment.CloneIntoZdata(Net.NetFileName(this.Id), Net.NetFileName(newId));
      return (IdObject) net;
    }

    public override string ToString()
    {
      return "Net n. " + FifaUtil.PadBlanks(this.Id.ToString(), 3);
    }

    public static string NetFileName(int netid)
    {
      return "data/sceneassets/goalnet/netcolor_" + netid.ToString() + "_textures.rx3";
    }

    public static Bitmap GetNet(int netId)
    {
      return FifaEnvironment.GetBmpFromRx3(Net.NetFileName(netId), 0);
    }

    public static bool SetNet(int netId, Bitmap bitmap)
    {
      return FifaEnvironment.ImportBmpsIntoZdata("data/sceneassets/goalnet/netcolor_#_textures.rx3", netId, bitmap, ECompressionMode.Chunkzip);
    }

    public static bool SetNet(int netId, string srcFileName)
    {
      string archivedName = Net.NetFileName(netId);
      return FifaEnvironment.ImportFileIntoZdataAs(srcFileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public static bool DeleteNet(int netId)
    {
      return FifaEnvironment.DeleteFromZdata(Net.NetFileName(netId));
    }
  }
}
