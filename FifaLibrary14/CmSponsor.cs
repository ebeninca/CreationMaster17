// Original code created by Rinaldo

using System.Drawing;

namespace FifaLibrary
{
  public class CmSponsor
  {
    public static string CmSponsorTemplateBigFileName()
    {
      return "data/ui/artassets/cmsponsors/cmsponsor_#.big";
    }

    public static string CmSponsorTemplateDdsName()
    {
      return "36";
    }

    public static string CmSponsorBigFileName(int id)
    {
      return "data/ui/artassets/cmsponsors/cmsponsor_" + id.ToString() + ".big";
    }

    public static string CmSponsorDdsFileName(int id)
    {
      return "data/ui/imgassets/cmsponsors/cmsponsors" + id.ToString() + ".dds";
    }

    public static Bitmap GetCmSponsor(int id)
    {
      return FifaEnvironment.Year == 14 ? FifaEnvironment.GetArtasset(CmSponsor.CmSponsorBigFileName(id)) : FifaEnvironment.GetDdsArtasset(CmSponsor.CmSponsorDdsFileName(id));
    }

    public static string CmSponsorsDdsTemplateFileName()
    {
      return "data/ui/imgassets/cmsponsors/cmsponsors#.dds";
    }

    public static bool SetCmSponsor(int id, Bitmap bitmap)
    {
      return FifaEnvironment.Year == 14 ? FifaEnvironment.SetArtasset(CmSponsor.CmSponsorTemplateBigFileName(), CmSponsor.CmSponsorTemplateDdsName(), id, bitmap) : FifaEnvironment.SetDdsArtasset(CmSponsor.CmSponsorsDdsTemplateFileName(), id, bitmap);
    }

    public static bool DeleteCmSponsor(int id)
    {
      return FifaEnvironment.Year == 14 ? FifaEnvironment.DeleteFromZdata(CmSponsor.CmSponsorBigFileName(id)) : FifaEnvironment.DeleteFromZdata(CmSponsor.CmSponsorDdsFileName(id));
    }

    public static string CmSponsorSmallTemplateBigFileName()
    {
      return "data/ui/artassets/cmsponsorssmall/cmsponsor_sml_#.big";
    }

    public static string CmSponsorSmallTemplateDdsName()
    {
      return "4";
    }

    public static string CmSponsorSmallBigFileName(int id)
    {
      return "data/ui/artassets/cmsponsorssmall/cmsponsor_sml_" + id.ToString() + ".big";
    }

    public static Bitmap GetCmSponsorSmall(int id)
    {
      return FifaEnvironment.GetArtasset(CmSponsor.CmSponsorSmallBigFileName(id));
    }

    public static bool SetCmSponsorSmall(int id, Bitmap bitmap)
    {
      return FifaEnvironment.SetArtasset(CmSponsor.CmSponsorSmallTemplateBigFileName(), CmSponsor.CmSponsorSmallTemplateDdsName(), id, bitmap);
    }
  }
}
