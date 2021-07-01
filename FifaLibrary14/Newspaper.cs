// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class Newspaper
  {
    public static string NewspaperTemplateBigFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/artassets/newspapers/2014_np_#.big" : "data/ui/artassets/newspapers/np_#.big";
    }

    public static string NewspaperTemplateDdsName()
    {
      return "4";
    }

    public static string NewspaperBigFileName(int id)
    {
      return "data/ui/artassets/newspapers/np_" + id.ToString() + ".big";
    }

    public static Bitmap GetNewspaper(int id)
    {
      return FifaEnvironment.GetArtasset(Newspaper.NewspaperBigFileName(id));
    }

    public static bool SetNewspaper(int id, Bitmap bitmap)
    {
      return FifaEnvironment.SetArtasset(Newspaper.NewspaperTemplateBigFileName(), Newspaper.NewspaperTemplateDdsName(), id, bitmap);
    }

    public enum ENewspaperCountry
    {
      Equipe,
      Kicker,
      SkySport,
      CorriereDelloSport,
      Carrusel,
      LasNoticias,
      FutbolMundial,
      EAInsider,
      RMC,
      Deportes,
      Marca,
      LaStampa,
      talkSport,
      Carrusel2,
      Soccer,
    }
  }
}
