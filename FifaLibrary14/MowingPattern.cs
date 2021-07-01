// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class MowingPattern : IdObject
  {
    public MowingPattern(int mowingPatternId)
      : base(mowingPatternId)
    {
    }

    public override IdObject Clone(int newMowingPatternId)
    {
      MowingPattern mowingPattern = (MowingPattern) base.Clone(newMowingPatternId);
      if (mowingPattern != null)
        FifaEnvironment.CloneIntoZdata(MowingPattern.MowingPatternFileName(this.Id), MowingPattern.MowingPatternFileName(newMowingPatternId));
      return (IdObject) mowingPattern;
    }

    public override string ToString()
    {
      return "Mowing Pattern n. " + this.Id.ToString("000");
    }

    public static string MowingPatternFileName(int mowingPatternId)
    {
      return "data/sceneassets/pitch/pitchmowpattern_" + mowingPatternId.ToString() + "_textures.rx3";
    }

    public static Bitmap GetMowingPattern(int mowingPatternId)
    {
      return FifaEnvironment.GetBmpFromRx3(MowingPattern.MowingPatternFileName(mowingPatternId));
    }

    public static bool SetMowingPattern(int mowingPatternId, string srcFileName)
    {
      string archivedName = MowingPattern.MowingPatternFileName(mowingPatternId);
      return FifaEnvironment.ImportFileIntoZdataAs(srcFileName, archivedName, false, ECompressionMode.Chunkzip);
    }

    public static bool DeleteMowingPattern(int mowingPatternId)
    {
      return FifaEnvironment.DeleteFromZdata(MowingPattern.MowingPatternFileName(mowingPatternId));
    }

    public static string MowingPatternTemplate()
    {
      return FifaEnvironment.Year == 14 ? "data/sceneassets/pitch/2014_pitchmowpattern_#_textures.rx3" : "data/sceneassets/pitch/pitchmowpattern_#_textures.rx3";
    }

    public static bool SetMowingPattern(int mowingPatternId, Bitmap bitmap)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(MowingPattern.MowingPatternTemplate(), mowingPatternId, bitmap, ECompressionMode.Chunkzip);
    }
  }
}
