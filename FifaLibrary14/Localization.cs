// Original code created by Rinaldo

using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace FifaLibrary
{
  public class Localization
  {
    private string m_LanguageFileName;
    private string m_LanguageDefaultFileName;
    private ResXResourceSet m_ResxSet;

    public ResXResourceSet ResxSet
    {
      get
      {
        return this.m_ResxSet;
      }
    }

    public Localization()
    {
      string currentDirectory = Environment.CurrentDirectory;
      string letterIsoLanguageName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
      this.m_LanguageFileName = currentDirectory + "\\Language." + letterIsoLanguageName + ".resx";
      this.m_LanguageDefaultFileName = currentDirectory + "\\Language.resx";
      if (File.Exists(this.m_LanguageFileName))
        this.m_ResxSet = new ResXResourceSet(this.m_LanguageFileName);
      else if (File.Exists(this.m_LanguageFileName))
        this.m_ResxSet = new ResXResourceSet(this.m_LanguageDefaultFileName);
      else
        this.m_ResxSet = (ResXResourceSet) null;
    }

    public string GetString(string s)
    {
      return this.m_ResxSet == null ? s : this.m_ResxSet.GetString("_" + s);
    }

    public void LocalizeControl(Control control)
    {
      string str = this.GetString(control.Text);
      if (str != null)
        control.Text = str;
      if (control.GetType().Name == "ListView")
      {
        foreach (ColumnHeader column in ((ListView) control).Columns)
          column.Text = this.GetString(column.Text);
      }
      foreach (Control control1 in (ArrangedElementCollection) control.Controls)
        this.LocalizeControl(control1);
    }

    public void LocalizeMenu(MenuStrip menu)
    {
      foreach (ToolStripMenuItem menuItem in (ArrangedElementCollection) menu.Items)
        this.LocalizeMenuItem(menuItem);
    }

    public void LocalizeMenuItem(ToolStripMenuItem menuItem)
    {
      string str = this.GetString(menuItem.Text);
      if (str != null)
        menuItem.Text = str;
      foreach (ToolStripMenuItem dropDownItem in (ArrangedElementCollection) menuItem.DropDownItems)
        this.LocalizeMenuItem(dropDownItem);
    }

    public void LocalizeToolStrip(ToolStrip toolStrip)
    {
      foreach (ToolStripItem toolStripItem in (ArrangedElementCollection) toolStrip.Items)
        this.LocalizeToolStripItem(toolStripItem);
    }

    public void LocalizeToolStripItem(ToolStripItem toolStripItem)
    {
      string str1 = this.GetString(toolStripItem.Text);
      if (str1 != null)
        toolStripItem.Text = str1;
      string str2 = this.GetString(toolStripItem.ToolTipText);
      if (str2 != null)
        toolStripItem.ToolTipText = str2;
      try
      {
        foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) ((ToolStripDropDownItem) toolStripItem).DropDownItems)
          this.LocalizeToolStripItem(dropDownItem);
      }
      catch
      {
      }
    }
  }
}
