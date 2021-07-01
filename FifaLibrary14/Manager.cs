// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Manager : IdObject
  {
    public static string ManagerTextureFileName(int dress, int skin, int color, int coat)
    {
      return FifaEnvironment.Year == 14 ? "data/sceneassets/manager/manager_" + dress.ToString() + "_" + skin.ToString() + "_" + color.ToString() + "_" + coat.ToString() + "_textures.rx3" : "data/sceneassets/slc/manager_" + dress.ToString() + "_0_" + skin.ToString() + "_" + color.ToString() + "_" + coat.ToString() + "_textures.rx3";
    }

    public static string ManagerModelFileName(int dress, int body, int coat)
    {
      return FifaEnvironment.Year == 14 ? "data/sceneassets/manager/manager_" + dress.ToString() + "_" + body.ToString() + "_" + coat.ToString() + ".rx3" : "data/sceneassets/slc/manager_" + dress.ToString() + "_" + body.ToString() + "_1_" + coat.ToString() + ".rx3";
    }

    public static Bitmap GetManagerTextures(int dress, int skin, int color, int coat)
    {
      return FifaEnvironment.GetBmpFromRx3(Manager.ManagerTextureFileName(dress, skin, color, coat), 0);
    }

    public static Rx3File GetManagerModel(int dress, int body, int coat)
    {
      return FifaEnvironment.GetRx3FromZdata(Manager.ManagerModelFileName(dress, body, coat));
    }

    public static bool SetManager(int dress, int skin, int color, int coat, Bitmap bitmap)
    {
      Bitmap[] bitmaps = new Bitmap[1]{ bitmap };
      return FifaEnvironment.ImportBmpsIntoZdata(Manager.ManagerTextureFileName(0, 0, 0, 0), Manager.ManagerTextureFileName(dress, skin, color, coat), bitmaps, ECompressionMode.Chunkzip, Manager.ManagerSignature(dress, skin, color, coat));
    }

    public static bool DeleteManagerTexture(int dress, int skin, int color, int coat)
    {
      return FifaEnvironment.DeleteFromZdata(Manager.ManagerTextureFileName(dress, skin, color, coat));
    }

    private static Rx3Signatures ManagerSignature(
      int dress,
      int skin,
      int color,
      int coat)
    {
      return FifaEnvironment.Year == 14 ? new Rx3Signatures(1398432, 36, new string[1]
      {
        "manager_" + dress.ToString() + "_" + skin.ToString() + "_" + color.ToString() + "_" + coat.ToString() + "_cm.Raster"
      }) : new Rx3Signatures(2097968, 27, new string[1]
      {
        "manager_" + dress.ToString() + "_" + skin.ToString() + "_" + color.ToString() + "_" + coat.ToString() + "_cm"
      });
    }
  }
}
