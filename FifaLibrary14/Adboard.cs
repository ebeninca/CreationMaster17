// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Adboard : IdObject
  {
    public Adboard(int adboardId)
      : base(adboardId)
    {
    }

    public override IdObject Clone(int newId)
    {
      Adboard adboard = (Adboard) base.Clone(newId);
      if (adboard != null)
        FifaEnvironment.CloneIntoZdata(Adboard.AdboardFileName(this.Id), Adboard.AdboardFileName(newId));
      return (IdObject) adboard;
    }

    public override string ToString()
    {
      return "Adboard n. " + FifaUtil.PadBlanks(this.Id.ToString(), 3);
    }

    public static string AdboardFileName(int adboardid)
    {
      return "data/sceneassets/adboard/adboard_" + adboardid.ToString() + "_0.rx3";
    }

    public static Bitmap GetAdboard(int adboardId)
    {
      return FifaEnvironment.GetBmpFromRx3(Adboard.AdboardFileName(adboardId), adboardId <= 1000000);
    }

    public Bitmap GetAdboard()
    {
      return Adboard.GetAdboard(this.Id);
    }

    public static bool SetAdboard(int adboardId, Bitmap bitmap)
    {
      return FifaEnvironment.ImportBmpsIntoZdata("data/sceneassets/adboard/adboard_#_0.rx3", adboardId, bitmap, ECompressionMode.Chunkref);
    }

    public bool SetAdboard(Bitmap bitmap)
    {
      return Adboard.SetAdboard(this.Id, bitmap);
    }

    public static bool SetAdboard(int adboardId, string srcFileName)
    {
      string archivedName = Adboard.AdboardFileName(adboardId);
      return FifaEnvironment.ImportFileIntoZdataAs(srcFileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public bool SetAdboard(string srcFileName)
    {
      return Adboard.SetAdboard(this.Id, srcFileName);
    }

    public static bool DeleteAdboard(int adboardId)
    {
      return FifaEnvironment.DeleteFromZdata(Adboard.AdboardFileName(adboardId));
    }
  }
}
