// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class TeamNews
  {
    public static string TeamNewsDdsFileName(int teamid, int newsType, int order)
    {
      return "data/ui/imgassets/cmnews/nw_" + teamid.ToString() + "_" + newsType.ToString() + "_" + order.ToString() + ".dds";
    }

    public static Bitmap GetTeamNews(int teamid, int newsType, int order)
    {
      return FifaEnvironment.GetDdsArtasset(TeamNews.TeamNewsDdsFileName(teamid, newsType, order));
    }

    public static string TeamNewsDdsTemplateFileName()
    {
      return FifaEnvironment.Year == 14 ? "data/ui/imgassets/cmnews/2014_nw_#_%_@.dds" : "data/ui/imgassets/cmnews/nw_#_%_@.dds";
    }

    public static bool SetTeamNews(int teamid, int newsType, int order, Bitmap bitmap)
    {
      int[] ids = new int[3];
      string[] format = new string[3];
      ids[0] = teamid;
      ids[1] = newsType;
      ids[2] = order;
      format[0] = format[1] = format[2] = "D";
      return FifaEnvironment.SetDdsArtasset(TeamNews.TeamNewsDdsTemplateFileName(), ids, bitmap, format);
    }

    public static bool DeleteTeamNews(int teamid, int newsType, int order)
    {
      return FifaEnvironment.DeleteFromZdata(TeamNews.TeamNewsDdsFileName(teamid, newsType, order));
    }
  }
}
