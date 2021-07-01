// Original code created by Rinaldo

using System.IO;

namespace FifaLibrary
{
  public class NameFont : IdObject
  {
    public static void Clone(int oldStyle, int newStyle)
    {
      FifaEnvironment.CloneIntoZdata(NameFont.NameFontFileName(oldStyle), NameFont.NameFontFileName(newStyle));
    }

    public static string NameFontFileName(int id)
    {
      return "data/sceneassets/jerseyfonts/font_" + id.ToString() + ".ttf";
    }

    public NameFont(int id)
      : base(id)
    {
    }

    public override string ToString()
    {
      return "Name Font n. " + this.Id.ToString();
    }

    public static string CanShowNameFont(int style)
    {
      string path = FifaEnvironment.GameDir + NameFont.NameFontFileName(style);
      return File.Exists(path) ? path : (string) null;
    }

    public static bool Delete(int style)
    {
      return FifaEnvironment.DeleteFromZdata(NameFont.NameFontFileName(style));
    }

    public static bool Import(int style, string srcFileName)
    {
      string archivedName = NameFont.NameFontFileName(style);
      return FifaEnvironment.ImportFileIntoZdataAs(srcFileName, archivedName, false, ECompressionMode.Chunkzip2);
    }

    public static bool Export(int style, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(NameFont.NameFontFileName(style), exportDir);
    }
  }
}
