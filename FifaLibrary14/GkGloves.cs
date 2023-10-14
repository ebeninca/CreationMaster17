// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class GkGloves : IdObject
  {
    /*private static Model3D s_GkGlovesModel;

    public static Model3D GkGlovesModel
    {
      get
      {
        return GkGloves.s_GkGlovesModel;
      }
    }*/

    public void Set3DModelTexture(Bitmap bitmaps)
    {
      //if (GkGloves.s_GkGlovesModel == null)
     //   return;
     // GkGloves.s_GkGlovesModel.TextureBitmap = bitmaps;
    }

    public GkGloves(int gkglovesId)
      : base(gkglovesId)
    {
      //if (GkGloves.s_GkGlovesModel != null)
       // return;
      Rx3File rx3FromZdata = FifaEnvironment.GetRx3FromZdata(GkGloves.GkGlovesModelFileName(1));
      //GkGloves.s_GkGlovesModel = new Model3D(rx3FromZdata.Rx3IndexArrays[0], rx3FromZdata.Rx3VertexArrays[0], (Bitmap) null);
    }

    public override string ToString()
    {
      return "GK Gloves n. " + this.Id.ToString();
    }

    public static string GkGlovesTextureFileName(int gkglovesId)
    {
      return "data/sceneassets/gkglove/gkglove_" + gkglovesId.ToString() + "_textures.rx3";
    }

    public static Bitmap[] GetGkGlovesTextures(int gkglovesId)
    {
      return FifaEnvironment.GetBmpsFromRx3(GkGloves.GkGlovesTextureFileName(gkglovesId));
    }

    public static string GkGloveTextureTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data\\sceneassets\\gkglove\\2014_gkglove_#_textures.rx3" : "data\\sceneassets\\gkglove\\gkglove_#_textures.rx3";
    }

    public static bool SetGkGlovesTextures(int gkglovesId, Bitmap[] bitmaps)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(GkGloves.GkGloveTextureTemplateFileName(), gkglovesId, bitmaps, ECompressionMode.Chunkzip);
    }

    public static bool SetGkGlovesTextures(int gkglovesId, string rx3FileName)
    {
      string archivedName = GkGloves.GkGlovesTextureFileName(gkglovesId);
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public static bool ExportGkGlovesTextures(int gkglovesId, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(GkGloves.GkGlovesTextureFileName(gkglovesId), exportDir);
    }

    public static bool DeleteGkGlovesTextures(int gkglovesId)
    {
      return FifaEnvironment.DeleteFromZdata(GkGloves.GkGlovesTextureFileName(gkglovesId));
    }

    public static string GkGlovesModelFileName(int id)
    {
      return "data/sceneassets/gkglove/gkglove_" + id.ToString() + ".rx3";
    }

    public static Rx3File GetGkGlovesModel(int gkglovesId)
    {
      return FifaEnvironment.GetRx3FromZdata(GkGloves.GkGlovesTextureFileName(gkglovesId));
    }

    public override IdObject Clone(int newId)
    {
      GkGloves gkGloves = (GkGloves) base.Clone(newId);
      if (gkGloves != null)
      {
        FifaEnvironment.CloneIntoZdata(GkGloves.GkGlovesTextureFileName(this.Id), GkGloves.GkGlovesTextureFileName(newId));
        FifaEnvironment.CloneIntoZdata(GkGloves.GkGlovesModelFileName(this.Id), GkGloves.GkGlovesModelFileName(newId));
      }
      return (IdObject) gkGloves;
    }
  }
}
