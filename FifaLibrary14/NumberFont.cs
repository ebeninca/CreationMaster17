// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class NumberFont : IdObject
  {
    private static int s_MaxColors = 20;
    private int m_Style;
    private int m_Color;

    public NumberFont(int fontId)
      : base(fontId)
    {
      this.ComputeStyleAndColor(fontId);
    }

    private void ComputeStyleAndColor(int fontId)
    {
      this.m_Style = fontId / NumberFont.s_MaxColors;
      this.m_Color = fontId - this.m_Style * NumberFont.s_MaxColors;
    }

    public override string ToString()
    {
      FifaUtil.PadBlanks(this.Id.ToString(), 3);
      string str1 = "Font n. " + (object) this.m_Style + " ";
      string str2;
      switch (this.m_Color)
      {
        case 0:
          str2 = str1 + "Transparent";
          break;
        case 1:
          str2 = str1 + "White";
          break;
        case 2:
          str2 = str1 + "Black";
          break;
        case 3:
          str2 = str1 + "Blue";
          break;
        case 4:
          str2 = str1 + "Red";
          break;
        case 5:
          str2 = str1 + "Yellow";
          break;
        case 6:
          str2 = str1 + "Green";
          break;
        case 7:
          str2 = str1 + "Orange";
          break;
        case 8:
          str2 = str1 + "Violet";
          break;
        case 9:
          str2 = str1 + "Brown";
          break;
        case 10:
          str2 = str1 + "Pink";
          break;
        case 11:
          str2 = str1 + "Dark Red";
          break;
        case 12:
          str2 = str1 + "Cyano";
          break;
        case 13:
          str2 = str1 + "Dark Blue";
          break;
        case 14:
          str2 = str1 + "Gray";
          break;
        case 15:
          str2 = str1 + "Pale Green";
          break;
        case 16:
          str2 = str1 + "Dark Gold";
          break;
        case 17:
          str2 = str1 + "Gold";
          break;
        case 18:
          str2 = str1 + "Light Red";
          break;
        case 19:
          str2 = str1 + "Dark Green";
          break;
        default:
          str2 = str1 + this.m_Color.ToString();
          break;
      }
      return str2;
    }

    public static void Clone(int oldStyle, int oldColor, int newStyle, int newColor)
    {
      FifaEnvironment.CloneIntoZdata(NumberFont.NumberFontFileName(oldStyle, oldColor), NumberFont.NumberFontFileName(newStyle, newColor));
    }

    public static string NumberFontFileName(int styleId, int colorId)
    {
      return "data/sceneassets/kitnumbers/kitnumbers_" + styleId.ToString() + "_" + colorId.ToString() + ".rx3";
    }

    public string NumberFontFileName()
    {
      return NumberFont.NumberFontFileName(this.m_Style, this.m_Color);
    }

    public static string NumberFontTemplateName()
    {
      return "data/sceneassets/kitnumbers/kitnumbers_#_%.rx3";
    }

    public static Rx3Signatures NumberFontSignature(int id, int colorId)
    {
      string[] signatures = new string[10];
      for (int index = 0; index < 10; ++index)
        signatures[index] = "numbers_" + id.ToString() + "_" + colorId.ToString() + "_" + index.ToString() + ".Raster";
      return new Rx3Signatures(220560, 31, signatures);
    }

    public static Rx3File GetNumberFontRx3(int style, int color)
    {
      return FifaEnvironment.GetRx3FromZdata(NumberFont.NumberFontFileName(style, color));
    }

    public static Bitmap[] GetNumberFont(int style, int color)
    {
      return FifaEnvironment.GetBmpsFromRx3(NumberFont.NumberFontFileName(style, color));
    }

    public static bool SetNumberFont(int style, int color, Bitmap[] bitmaps)
    {
      return FifaEnvironment.ImportBmpsIntoZdata(NumberFont.NumberFontTemplateName(), new int[2]
      {
        style,
        color
      }, bitmaps, ECompressionMode.Chunkzip, NumberFont.NumberFontSignature(style, color));
    }

    public static bool SetNumberFont(int style, int color, string rx3FileName)
    {
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, NumberFont.NumberFontFileName(style, color), false, ECompressionMode.Chunkzip);
    }

    public static bool Delete(int style, int color)
    {
      return FifaEnvironment.DeleteFromZdata(NumberFont.NumberFontFileName(style, color));
    }

    public static bool Import(int style, int color, string rx3FileName)
    {
      string archivedName = NumberFont.NumberFontFileName(style, color);
      return FifaEnvironment.ImportFileIntoZdataAs(rx3FileName, archivedName, false, ECompressionMode.Chunkzip, NumberFont.NumberFontSignature(style, color));
    }

    public static bool Export(int style, int color, string exportDir)
    {
      return FifaEnvironment.ExportFileFromZdata(NumberFont.NumberFontFileName(style, color), exportDir);
    }
  }
}
