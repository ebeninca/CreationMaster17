// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Police : IdObject
  {
    public Police(int policeId)
      : base(policeId)
    {
    }

    public override IdObject Clone(int newId)
    {
      Police police = (Police) base.Clone(newId);
      if (police != null)
      {
        FifaEnvironment.CloneIntoZdata(Police.PoliceFileName(this.Id, 0), Police.PoliceFileName(newId, 0));
        FifaEnvironment.CloneIntoZdata(Police.PoliceFileName(this.Id, 1), Police.PoliceFileName(newId, 1));
      }
      return (IdObject) police;
    }

    public override string ToString()
    {
      return "Police n. " + FifaUtil.PadBlanks(this.Id.ToString(), 3);
    }

    public static string PoliceFileName(int policeid, int type)
    {
      return FifaEnvironment.Year == 14 ? "data/sceneassets/policeofficer/policeofficer_" + policeid.ToString() + "_0_0_" + type.ToString() + "_textures.rx3" : "data/sceneassets/slc/policeofficer_" + policeid.ToString() + "_0_0_" + type.ToString() + "_textures.rx3";
    }

    public static string PoliceTemplateName()
    {
      return FifaEnvironment.Year == 14 ? "data/sceneassets/policeofficer/policeofficer_#_0_0_%_textures.rx3" : "data/sceneassets/slc/policeofficer_#_0_0_%_textures.rx3";
    }

    public static Bitmap GetPolice(int policeid, int type)
    {
      return FifaEnvironment.GetBmpFromRx3(Police.PoliceFileName(policeid, type), 0);
    }

    public static bool SetPolice(int policeid, int type, Bitmap bitmap)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(Police.PoliceTemplateName(), new int[2]
      {
        policeid,
        type
      }, bitmap, ECompressionMode.Chunkzip, Police.PoliceSignature(policeid, type));
    }

    public static bool DeletePolice(int policeid, int type)
    {
      return FifaEnvironment.DeleteFromZdata(Police.PoliceFileName(policeid, type));
    }

    private static Rx3Signatures PoliceSignature(int policeid, int type)
    {
      return new Rx3Signatures(43984, 48, new string[1]
      {
        "policeofficer_" + policeid.ToString() + "_0_0_" + type.ToString() + "_cm.Raster"
      });
    }
  }
}
