// Original code created by Rinaldo

using FifaLibrary;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CreationMaster
{
    public class PatchCreatorForm : Form
    {
        private DataSet m_FifaDataSet = new DataSet("FIFA14");
        private DataSet m_LangDataSet = new DataSet("LANG14");
        private string m_TempFolder;
        private PatchCreatorForm.EPatchType m_PatchType;
        private int[] m_PlayerKeys;
        private int[] m_PlayerNameKeys;
        private int[] m_TeamKeys;
        private int[] m_KitKeys;
        private int[] m_LeagueKeys;
        private int[] m_CountryKeys;
        private int[] m_RefereeKeys;
        private int[] m_StadiumKeys;
        private int[] m_FormationKeys;
        private int[] m_LanguageKeys;
        private DataTable m_PlayersTable;
        private DataTable m_PlayernamesTable;
        private DataTable m_PlayerLoansTable;
        private DataTable m_TeamsTable;
        private DataTable m_TeamkitsTable;
        private DataTable m_TeamplayerlinksTable;
        private DataTable m_LeaguesTable;
        private DataTable m_BoardOutcomesTable;
        private DataTable m_LeagueTeamLinksTable;
        private DataTable m_NationsTable;
        private DataTable m_AudionationsTable;
        private DataTable m_TeamStadiumLinksTable;
        private DataTable m_TeamFormationTeamStyleLinksTable;
        private DataTable m_RowTeamNationLinksTable;
        private DataTable m_RefereesTable;
        private DataTable m_StadiumsTable;
        private DataTable m_StadiumAssignmentsTable;
        private DataTable m_ManagerTable;
        private DataTable m_FormationsTable;
        private DataTable m_LanguageTable;
        private IContainer components;
        private SplitContainer splitContainer1;
        private Panel panelLeft;
        private TextBox textPatchVersion;
        private TextBox textPatchName;
        private TextBox textDescription;
        private Label label1;
        private Label labelPatchVersion;
        private Label labelPatchName;
        private ComboBox comboPatchType;
        private GroupBox groupPatchOptions;
        private TabControl tabPatchOptions;
        private TabPage pagePlayerOptions;
        private CheckBox checkPlayerShoes;
        private CheckBox checkPlayerMiniface;
        private CheckBox checkPlayerHead;
        private CheckBox checkPlayerDatabase;
        private TabPage pageTeamOptions;
        private CheckBox checkTeamAdboard;
        private CheckBox checkTeamBall;
        private CheckBox checkTeamLinkedPlayers;
        private CheckBox checkTeamKits;
        private CheckBox checkTeamFlags;
        private CheckBox checkTeamGuiBanner;
        private CheckBox checkTeamGuiLogo;
        private CheckBox checkTeamDatabase;
        private TabPage pageLeagueOptions;
        private CheckBox checkLeagueLinkedTournament;
        private CheckBox checkLeagueLinkedTeams;
        private CheckBox checkLeagueLogo;
        private CheckBox checkLeagueDatabase;
        private TabPage pageCountryOptions;
        private CheckBox checkCountryMiniFlag;
        private CheckBox checkCountryDatabase;
        private CheckBox checkCountryFlag;
        private TabPage pageRefereeOptions;
        private CheckBox checkRefereeDatabase;
        private TabPage pageStadiumOptions;
        private CheckBox checkStadiumMowingPattern;
        private CheckBox checkStadiumModel;
        private CheckBox checkStadiumPreview;
        private CheckBox checkStadiumDatabase;
        private CheckBox checkStadiumNet;
        private Label labelPatchType;
        private CheckBox checkCMSCompatible;
        private CheckBox checkTeamFormation;
        private CheckBox checkRefereeKits;
        private ListBox listSource;
        private ListView listViewDest;
        private ColumnHeader columnComment;
        private ColumnHeader columnType;
        private ColumnHeader columnId;
        private ColumnHeader columnItem;
        private ToolStrip toolAddRemove;
        private ToolStripButton buttonAddObject;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonRemoveObject;
        private TabPage pageGeneralOptions;
        private RadioButton radioIncludeOriginal;
        private RadioButton radioIncludePatched;
        private CheckBox checkCountryLeagues;
        private CheckBox checkContrynationalTeam;
        private CheckBox checkCountryTournaments;
        private TabPage pageKitOptions;
        private CheckBox checkKitNumbers;
        private CheckBox checkKitMinikits;
        private CheckBox checkKitDatabase;
        private CheckBox checkKitNameFonts;
        private CheckBox checkLeagueReferees;
        private CheckBox checkRefereeShoes;
        private CheckBox checkTeamStadium;
        private CheckBox checkPlayerGloves;
        private MenuStrip mainMenuStrip;
        private ToolStrip toolMain;
        private ToolStripMenuItem patchToolStripMenuItem;
        private ToolStripMenuItem newPatchToolStripMenuItem;
        private ToolStripMenuItem createPatchToolStripMenuItem;
        private ToolStripMenuItem openPatchToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripButton buttonNewPatch;
        private ToolStripButton buttonOpenPatch;
        private ToolStripButton buttonCreatePatch;
        private ToolStripButton buttonExit;
        private StatusStrip statusBar;
        private ToolStripStatusLabel statusLabel;
        private Patch m_PatchDataSet;
        private OpenFileDialog openFileDialog;
        private CheckBox checkKitTextures;
        private CheckBox checkCountryCardFlag;
        private CheckBox checkRefereeMiniFace;
        private CheckBox checkLeagueBall;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton buttonAddFile;
        private CheckBox checkCountryMap;
        private CheckBox checkCountryFlag512x512;

        public PatchCreatorForm()
        {
            this.InitializeComponent();
            this.m_TempFolder = FifaEnvironment.TempFolder + "\\Patch";
        }

        private void comboPatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listSource.BeginUpdate();
            this.statusLabel.Text = "Loading ...";
            this.listSource.Items.Clear();
            PatchCreatorForm.EPatchType selectedIndex = (PatchCreatorForm.EPatchType)this.comboPatchType.SelectedIndex;
            this.listSource.Sorted = true;
            switch (selectedIndex)
            {
                case PatchCreatorForm.EPatchType.Country:
                    this.listSource.Items.AddRange(FifaEnvironment.Countries.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Country;
                    this.tabPatchOptions.SelectedTab = this.pageCountryOptions;
                    break;
                case PatchCreatorForm.EPatchType.League:
                    this.listSource.Items.AddRange(FifaEnvironment.Leagues.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.League;
                    this.tabPatchOptions.SelectedTab = this.pageLeagueOptions;
                    break;
                case PatchCreatorForm.EPatchType.Team:
                    this.listSource.Items.AddRange(FifaEnvironment.Teams.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Team;
                    this.tabPatchOptions.SelectedTab = this.pageTeamOptions;
                    break;
                case PatchCreatorForm.EPatchType.Player:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.Players.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Player;
                    this.tabPatchOptions.SelectedTab = this.pagePlayerOptions;
                    break;
                case PatchCreatorForm.EPatchType.Kit:
                    this.listSource.Items.AddRange(FifaEnvironment.Kits.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Kit;
                    this.tabPatchOptions.SelectedTab = this.pageKitOptions;
                    break;
                case PatchCreatorForm.EPatchType.Referee:
                    this.listSource.Items.AddRange(FifaEnvironment.Referees.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Referee;
                    this.tabPatchOptions.SelectedTab = this.pageRefereeOptions;
                    break;
                case PatchCreatorForm.EPatchType.Stadium:
                    this.listSource.Items.AddRange(FifaEnvironment.Stadiums.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Stadium;
                    this.tabPatchOptions.SelectedTab = this.pageStadiumOptions;
                    break;
                case PatchCreatorForm.EPatchType.Formation:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.Formations.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Formation;
                    break;
                case PatchCreatorForm.EPatchType.Ball:
                    this.listSource.Items.AddRange(FifaEnvironment.Balls.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Ball;
                    this.tabPatchOptions.SelectedTab = this.pageTeamOptions;
                    break;
                case PatchCreatorForm.EPatchType.Adboard:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.Adboards.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Adboard;
                    this.tabPatchOptions.SelectedTab = this.pageTeamOptions;
                    break;
                case PatchCreatorForm.EPatchType.NumberFont:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.NumberFonts.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.NumberFont;
                    this.tabPatchOptions.SelectedTab = this.pageTeamOptions;
                    break;
                case PatchCreatorForm.EPatchType.NameFont:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.NameFonts.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.NameFont;
                    this.tabPatchOptions.SelectedTab = this.pageTeamOptions;
                    break;
                case PatchCreatorForm.EPatchType.Shoes:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.Shoes.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Shoes;
                    this.tabPatchOptions.SelectedTab = this.pagePlayerOptions;
                    break;
                case PatchCreatorForm.EPatchType.GKGloves:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.GkGloves.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.GKGloves;
                    this.tabPatchOptions.SelectedTab = this.pagePlayerOptions;
                    break;
                case PatchCreatorForm.EPatchType.Net:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.Nets.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.Net;
                    this.tabPatchOptions.SelectedTab = this.pageStadiumOptions;
                    break;
                case PatchCreatorForm.EPatchType.MowingPattern:
                    this.listSource.Sorted = false;
                    this.listSource.Items.AddRange(FifaEnvironment.MowingPatterns.ToArray());
                    this.m_PatchType = PatchCreatorForm.EPatchType.MowingPattern;
                    this.tabPatchOptions.SelectedTab = this.pageStadiumOptions;
                    break;
            }
            this.listSource.EndUpdate();
            this.statusLabel.Text = "Ready";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.listSource.SelectedItems.Count <= 0)
                return;
            Cursor.Current = Cursors.WaitCursor;
            switch (this.m_PatchType)
            {
                case PatchCreatorForm.EPatchType.Country:
                    IEnumerator enumerator1 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator1.MoveNext())
                            this.AddToPatchList((Country)enumerator1.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator1 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.League:
                    IEnumerator enumerator2 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                            this.AddToPatchList((League)enumerator2.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Team:
                    IEnumerator enumerator3 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator3.MoveNext())
                            this.AddToPatchList((Team)enumerator3.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator3 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Player:
                    IEnumerator enumerator4 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator4.MoveNext())
                            this.AddToPatchList((Player)enumerator4.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator4 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Kit:
                    IEnumerator enumerator5 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator5.MoveNext())
                            this.AddToPatchList((Kit)enumerator5.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator5 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Referee:
                    IEnumerator enumerator6 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator6.MoveNext())
                            this.AddToPatchList((Referee)enumerator6.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator6 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Stadium:
                    IEnumerator enumerator7 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator7.MoveNext())
                            this.AddToPatchList((Stadium)enumerator7.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator7 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Formation:
                    IEnumerator enumerator8 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator8.MoveNext())
                            this.AddToPatchList((Formation)enumerator8.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator8 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Ball:
                    IEnumerator enumerator9 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator9.MoveNext())
                            this.AddToPatchList((Ball)enumerator9.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator9 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Adboard:
                    IEnumerator enumerator10 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator10.MoveNext())
                            this.AddToPatchList((Adboard)enumerator10.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator10 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.NumberFont:
                    IEnumerator enumerator11 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator11.MoveNext())
                            this.AddToPatchList((NumberFont)enumerator11.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator11 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.NameFont:
                    IEnumerator enumerator12 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator12.MoveNext())
                            this.AddToPatchList((NameFont)enumerator12.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator12 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Shoes:
                    IEnumerator enumerator13 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator13.MoveNext())
                            this.AddToPatchList((Shoes)enumerator13.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator13 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.GKGloves:
                    IEnumerator enumerator14 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator14.MoveNext())
                            this.AddToPatchList((GkGloves)enumerator14.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator14 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.Net:
                    IEnumerator enumerator15 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator15.MoveNext())
                            this.AddToPatchList((Net)enumerator15.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator15 is IDisposable disposable)
                            disposable.Dispose();
                    }
                case PatchCreatorForm.EPatchType.MowingPattern:
                    IEnumerator enumerator16 = this.listSource.SelectedItems.GetEnumerator();
                    try
                    {
                        while (enumerator16.MoveNext())
                            this.AddToPatchList((MowingPattern)enumerator16.Current);
                        break;
                    }
                    finally
                    {
                        if (enumerator16 is IDisposable disposable)
                            disposable.Dispose();
                    }
            }
            Cursor.Current = Cursors.Default;
            this.statusLabel.Text = "Ready";
            this.statusBar.Refresh();
        }

        private ListViewItem WriteToPatchList(IdObject obj)
        {
            return this.WriteToPatchList(obj, obj.Id, obj.ToString(), (string)null);
        }

        private ListViewItem WriteToPatchList(IdObject obj, string name)
        {
            return this.WriteToPatchList(obj, obj.Id, name, (string)null);
        }

        private ListViewItem WriteToPatchList(
          IdObject obj,
          int id,
          string name,
          string comment)
        {
            if (obj == null)
                return (ListViewItem)null;
            foreach (ListViewItem listViewItem in this.listViewDest.Items)
            {
                if (obj == listViewItem.Tag)
                    return (ListViewItem)null;
            }
            string[] items = new string[4]
            {
        null,
        obj.GetType().Name,
        id.ToString(),
        name
            };
            items[0] = comment;
            ListViewItem listViewItem1 = new ListViewItem(items);
            listViewItem1.Tag = (object)obj;
            this.listViewDest.Items.Add(listViewItem1);
            this.statusLabel.Text = "Adding " + name;
            this.statusBar.Refresh();
            return listViewItem1;
        }

        private ListViewItem AddToPatchList(string desc)
        {
            if (desc == null)
                return (ListViewItem)null;
            foreach (ListViewItem listViewItem in this.listViewDest.Items)
            {
                if (desc == listViewItem.Tag.ToString())
                    return (ListViewItem)null;
            }
            string[] items = new string[4];
            int length = desc.IndexOf(' ');
            items[1] = length > 0 ? desc.Substring(0, length) : desc;
            items[3] = desc;
            int startIndex = desc.LastIndexOf(' ');
            items[2] = desc.Substring(startIndex);
            items[0] = (string)null;
            ListViewItem listViewItem1 = new ListViewItem(items);
            listViewItem1.Tag = (object)desc;
            this.listViewDest.Items.Add(listViewItem1);
            return listViewItem1;
        }

        private void AddToPatchList(League league)
        {
            if (league == null)
                return;
            this.WriteToPatchList((IdObject)league, league.leaguename);
            if (this.checkLeagueLinkedTeams.Checked)
            {
                foreach (Team playingTeam in (ArrayList)league.PlayingTeams)
                    this.AddToPatchList(playingTeam);
            }
            if (!this.checkLeagueReferees.Checked)
                return;
            foreach (Referee referee in (ArrayList)FifaEnvironment.Referees)
            {
                if (referee.IsInLeague(league))
                    this.AddToPatchList(referee);
            }
        }

        private void AddToPatchList(Team team)
        {
            if (team == null)
                return;
            this.WriteToPatchList((IdObject)team, team.DatabaseName);
            if (this.checkTeamKits.Checked)
            {
                foreach (Kit kit in (ArrayList)team.m_KitList)
                    this.AddToPatchList(kit);
            }
            if (this.checkTeamFormation.Checked)
                this.AddToPatchList((Formation)FifaEnvironment.Formations.SearchId(team.formationid));
            if (this.checkTeamAdboard.Checked)
                this.AddToPatchList((Adboard)FifaEnvironment.Adboards.SearchId(team.adboardid));
            if (this.checkTeamBall.Checked)
                this.AddToPatchList((Ball)FifaEnvironment.Balls.SearchId(team.balltype));
            if (this.checkTeamStadium.Checked)
                this.AddToPatchList((Stadium)FifaEnvironment.Stadiums.SearchId((IdObject)team.Stadium));
            if (!this.checkTeamLinkedPlayers.Checked)
                return;
            foreach (TeamPlayer teamPlayer in (ArrayList)team.Roster)
                this.AddToPatchList(teamPlayer.Player);
        }

        private void AddToPatchList(Player player)
        {
            if (player == null)
                return;
            this.WriteToPatchList((IdObject)player);
            if (this.checkPlayerShoes.Checked)
                this.AddToPatchList((Shoes)FifaEnvironment.Shoes.SearchId(player.shoetypecode));
            if (!this.checkPlayerGloves.Checked)
                return;
            this.AddToPatchList((GkGloves)FifaEnvironment.GkGloves.SearchId(player.gkglovetypecode));
        }

        private void AddToPatchList(Shoes shoes)
        {
            if (shoes == null || shoes.Id == 0 || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(Shoes.ShoesTexturesFileName(shoes.Id, 0)))
                return;
            this.WriteToPatchList((IdObject)shoes);
        }

        private void AddToPatchList(Ball ball)
        {
            if (ball == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(ball.BallTextureFileName()))
                return;
            this.WriteToPatchList((IdObject)ball);
        }

        private void AddToPatchList(Adboard adboard)
        {
            if (adboard == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(Adboard.AdboardFileName(adboard.Id)))
                return;
            this.WriteToPatchList((IdObject)adboard);
        }

        private void AddToPatchList(Kit kit)
        {
            if (kit == null || kit.year != 0)
                return;
            if (kit.Team != null)
                this.WriteToPatchList((IdObject)kit, kit.Team.Id * 10 + kit.kittype, kit.ToString(), (string)null);
            else
                this.WriteToPatchList((IdObject)kit, kit.teamid * 10 + kit.kittype, kit.ToString(), (string)null);
            if (this.checkKitNumbers.Checked)
            {
                //this.AddToPatchList((NumberFont) FifaEnvironment.NumberFonts.SearchId(kit.jerseyNumberFont * 20 + kit.jerseyNumberColor));
                this.AddToPatchList((NumberFont)FifaEnvironment.NumberFonts.SearchId(kit.jerseyNumberFont * 20));
                //this.AddToPatchList((NumberFont) FifaEnvironment.NumberFonts.SearchId(kit.shortsNumberFont * 20 + kit.shortsNumberColor));
                this.AddToPatchList((NumberFont)FifaEnvironment.NumberFonts.SearchId(kit.shortsNumberFont * 20));
            }
            if (!this.checkKitNameFonts.Checked)
                return;
            this.AddToPatchList((NameFont)FifaEnvironment.NameFonts.SearchId(kit.jerseyNameFont));
        }

        private void AddToPatchList(Stadium stadium)
        {
            if (stadium == null)
                return;
            this.WriteToPatchList((IdObject)stadium, stadium.DatabaseString());
            if (this.checkStadiumNet.Checked)
                this.AddToPatchList((Net)FifaEnvironment.Nets.SearchId(stadium.NetColor));
            if (!this.checkStadiumMowingPattern.Checked)
                return;
            this.AddToPatchList((MowingPattern)FifaEnvironment.MowingPatterns.SearchId(stadium.MowingPatternId));
        }

        private void AddToPatchList(Referee referee)
        {
            if (referee == null)
                return;
            this.WriteToPatchList((IdObject)referee);
            if (!this.checkPlayerShoes.Checked)
                return;
            this.AddToPatchList((Shoes)FifaEnvironment.Shoes.SearchId(referee.shoetypecode));
        }

        private void AddToPatchList(Formation formation)
        {
            if (formation == null)
                return;
            this.WriteToPatchList((IdObject)formation);
        }

        private void AddToPatchList(Country country)
        {
            if (country == null)
                return;
            this.WriteToPatchList((IdObject)country, country.DatabaseName);
            if (this.checkCountryLeagues.Checked)
            {
                foreach (League league in (ArrayList)FifaEnvironment.Leagues)
                {
                    if (league.Country == country)
                        this.AddToPatchList(league);
                }
            }
            if (!this.checkContrynationalTeam.Checked || country.NationalTeam == null)
                return;
            this.AddToPatchList(country.NationalTeam);
        }

        private void AddToPatchList(NameFont nameFont)
        {
            if (nameFont == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(NameFont.NameFontFileName(nameFont.Id)))
                return;
            this.WriteToPatchList((IdObject)nameFont);
        }

        private void AddToPatchList(NumberFont numberFont)
        {
            if (numberFont == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(numberFont.NumberFontFileName()))
                return;
            this.WriteToPatchList((IdObject)numberFont);
        }

        private void AddToPatchList(Net net)
        {
            if (net == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(Net.NetFileName(net.Id)))
                return;
            this.WriteToPatchList((IdObject)net);
        }

        private void AddToPatchList(MowingPattern mowingPattern)
        {
            if (mowingPattern == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(MowingPattern.MowingPatternFileName(mowingPattern.Id)))
                return;
            this.WriteToPatchList((IdObject)mowingPattern);
        }

        private void AddToPatchList(GkGloves gloves)
        {
            if (gloves == null || this.radioIncludePatched.Checked && !FifaEnvironment.IsPatched(GkGloves.GkGlovesTextureFileName(gloves.Id)))
                return;
            this.WriteToPatchList((IdObject)gloves);
        }

        private void buttonRemoveObject_Click(object sender, EventArgs e)
        {
            int count = this.listViewDest.SelectedItems.Count;
            for (int index = 0; index < count; ++index)
                this.listViewDest.Items.Remove(this.listViewDest.SelectedItems[0]);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCreatePatch_Click(object sender, EventArgs e)
        {
            this.CreatePatch();
        }

        private void CreatePatch()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "cmp files (*.cmp)|*.cmp";
            saveFileDialog.InitialDirectory = FifaEnvironment.TempFolder;
            saveFileDialog.FileName = this.textPatchName.Text;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Save Creation Master Patch";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                saveFileDialog.Dispose();
            }
            else
            {
                string fileName1 = saveFileDialog.FileName;
                saveFileDialog.Dispose();
                Cursor.Current = Cursors.WaitCursor;
                this.Refresh();
                switch (FifaEnvironment.Year)
                {
                    case 14:
                        this.m_FifaDataSet.DataSetName = "FIFA14";
                        this.m_LangDataSet.DataSetName = "LANG14";
                        break;
                    case 15:
                        this.m_FifaDataSet.DataSetName = "FIFA15";
                        this.m_LangDataSet.DataSetName = "LANG15";
                        break;
                }
                this.m_FifaDataSet.Tables.Clear();
                this.m_LangDataSet.Tables.Clear();
                this.m_PatchDataSet.Tables[0].Clear();
                DataRow row1 = this.m_PatchDataSet.Tables[0].NewRow();
                row1[0] = (object)this.textPatchName.Text;
                row1[1] = (object)this.textPatchVersion.Text;
                row1[2] = (object)this.textDescription.Text;
                row1[3] = (object)"";
                this.m_PatchDataSet.Tables[0].Rows.Add(row1);
                this.m_PatchDataSet.Tables[1].Clear();
                foreach (ListViewItem listViewItem in this.listViewDest.Items)
                {
                    DataRow row2 = this.m_PatchDataSet.Tables[1].NewRow();
                    row2[0] = (object)listViewItem.SubItems[0].Text;
                    row2[1] = (object)listViewItem.SubItems[1].Text;
                    row2[2] = (object)listViewItem.SubItems[2].Text;
                    row2[3] = (object)listViewItem.SubItems[3].Text;
                    this.m_PatchDataSet.Tables[1].Rows.Add(row2);
                }
                this.CreateKeysArrays();
                this.m_LanguageTable = FifaEnvironment.LangDb.Table[TI.lang].ConvertToDataTable(this.m_LanguageKeys, "hashid");
                this.m_LangDataSet.Tables.Add(this.m_LanguageTable);
                if (this.m_PlayerKeys.Length > 0 && this.checkPlayerDatabase.Checked)
                {
                    this.m_PlayersTable = FifaEnvironment.FifaDb.Table[TI.players].ConvertToDataTable(this.m_PlayerKeys, "playerid");
                    this.m_FifaDataSet.Tables.Add(this.m_PlayersTable);
                    this.m_PlayernamesTable = FifaEnvironment.FifaDb.Table[TI.playernames].ConvertToDataTable(this.m_PlayerNameKeys, "nameid");
                    this.m_FifaDataSet.Tables.Add(this.m_PlayernamesTable);
                    this.m_PlayerLoansTable = FifaEnvironment.FifaDb.Table[TI.playerloans].ConvertToDataTable(this.m_PlayerNameKeys, "playerid");
                    this.m_FifaDataSet.Tables.Add(this.m_PlayerLoansTable);
                }
                if (this.m_TeamKeys.Length > 0 && this.checkTeamDatabase.Checked)
                {
                    this.m_TeamsTable = FifaEnvironment.FifaDb.Table[TI.teams].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_TeamsTable);
                    this.m_RowTeamNationLinksTable = FifaEnvironment.FifaDb.Table[TI.rowteamnationlinks].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_RowTeamNationLinksTable);
                    this.m_TeamplayerlinksTable = FifaEnvironment.FifaDb.Table[TI.teamplayerlinks].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_TeamplayerlinksTable);
                    this.m_TeamStadiumLinksTable = FifaEnvironment.FifaDb.Table[TI.teamstadiumlinks].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_TeamStadiumLinksTable);
                    this.m_TeamFormationTeamStyleLinksTable = FifaEnvironment.FifaDb.Table[TI.teamformationteamstylelinks].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_TeamFormationTeamStyleLinksTable);
                    this.m_StadiumAssignmentsTable = FifaEnvironment.FifaDb.Table[TI.stadiumassignments].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_StadiumAssignmentsTable);
                    this.m_ManagerTable = FifaEnvironment.FifaDb.Table[TI.manager].ConvertToDataTable(this.m_TeamKeys, "teamid");
                    this.m_FifaDataSet.Tables.Add(this.m_ManagerTable);
                }
                if (this.checkKitDatabase.Checked)
                {
                    this.m_TeamkitsTable = FifaEnvironment.FifaDb.Table[TI.teamkits].ConvertToDataTable(this.m_KitKeys, "teamkitid");
                    this.m_FifaDataSet.Tables.Add(this.m_TeamkitsTable);
                }
                if (this.m_LeagueKeys.Length > 0 && this.checkLeagueDatabase.Checked)
                {
                    this.m_LeaguesTable = FifaEnvironment.FifaDb.Table[TI.leagues].ConvertToDataTable(this.m_LeagueKeys, "leagueid");
                    this.m_FifaDataSet.Tables.Add(this.m_LeaguesTable);
                    this.m_BoardOutcomesTable = FifaEnvironment.FifaDb.Table[TI.career_boardoutcomes].ConvertToDataTable(this.m_LeagueKeys, "leagueid");
                    this.m_FifaDataSet.Tables.Add(this.m_BoardOutcomesTable);
                    if (this.checkLeagueLinkedTeams.Checked)
                    {
                        this.m_LeagueTeamLinksTable = FifaEnvironment.FifaDb.Table[TI.leagueteamlinks].ConvertToDataTable(this.m_LeagueKeys, "leagueid");
                        this.m_FifaDataSet.Tables.Add(this.m_LeagueTeamLinksTable);
                    }
                }
                if (this.m_CountryKeys.Length > 0 && this.checkCountryDatabase.Checked)
                {
                    this.m_NationsTable = FifaEnvironment.FifaDb.Table[TI.nations].ConvertToDataTable(this.m_CountryKeys, "nationid");
                    this.m_FifaDataSet.Tables.Add(this.m_NationsTable);
                    this.m_AudionationsTable = FifaEnvironment.FifaDb.Table[TI.audionation].ConvertToDataTable(this.m_CountryKeys, "nationid");
                    this.m_FifaDataSet.Tables.Add(this.m_AudionationsTable);
                }
                if (this.m_RefereeKeys.Length > 0 && this.checkRefereeDatabase.Checked)
                {
                    this.m_RefereesTable = FifaEnvironment.FifaDb.Table[TI.referee].ConvertToDataTable(this.m_RefereeKeys, "refereeid");
                    this.m_FifaDataSet.Tables.Add(this.m_RefereesTable);
                }
                if (this.m_StadiumKeys.Length > 0 && this.checkStadiumDatabase.Checked)
                {
                    this.m_StadiumsTable = FifaEnvironment.FifaDb.Table[TI.stadiums].ConvertToDataTable(this.m_StadiumKeys, "stadiumid");
                    this.m_FifaDataSet.Tables.Add(this.m_StadiumsTable);
                }
                if (this.m_FormationKeys.Length > 0)
                {
                    this.m_FormationsTable = FifaEnvironment.FifaDb.Table[TI.formations].ConvertToDataTable(this.m_FormationKeys, "formationid");
                    this.m_FifaDataSet.Tables.Add(this.m_FormationsTable);
                }
                if (Directory.Exists(this.m_TempFolder))
                    Directory.Delete(this.m_TempFolder, true);
                Directory.CreateDirectory(this.m_TempFolder);
                this.statusLabel.Text = "Saving XML files...";
                this.statusBar.Refresh();
                this.m_PatchDataSet.WriteXml(this.m_TempFolder + "\\patch.xml");
                this.m_FifaDataSet.WriteXml(this.m_TempFolder + "\\fifa.xml");
                this.m_LangDataSet.WriteXml(this.m_TempFolder + "\\lang.xml");
                foreach (ListViewItem listViewItem in this.listViewDest.Items)
                {
                    object tag = listViewItem.Tag;
                    string name = listViewItem.Tag.GetType().Name;
                    this.statusLabel.Text = "Saving " + listViewItem.SubItems[3].Text;
                    this.statusBar.Refresh();
                    if (name == "Player")
                    {
                        Player player = (Player)tag;
                        if (this.checkPlayerHead.Checked && player.HasSpecificHeadModel)
                        {
                            this.CheckAndExport(player.SpecificFaceTextureFileName());
                            this.CheckAndExport(player.SpecificHairTexturesFileName());
                            if (FifaEnvironment.Year == 14)
                                this.CheckAndExport(player.SpecificEyesTextureFileName());
                            this.CheckAndExport(player.SpecificHeadModelFileName());
                            this.CheckAndExport(player.SpecificHairModelFileName());
                            this.CheckAndExport(player.SpecificHairLodModelFileName());
                        }
                        if (this.checkPlayerMiniface.Checked)
                            this.CheckAndExport(player.SpecificPhotoDdsFileName());
                    }
                    else if (name == "Team")
                    {
                        Team team = (Team)tag;
                        if (this.checkTeamGuiLogo.Checked)
                        {
                            this.CheckAndExport(team.CrestDdsFileName());
                            this.CheckAndExport(team.Crest50DdsFileName());
                            this.CheckAndExport(team.Crest32DdsFileName());
                            this.CheckAndExport(team.Crest16DdsFileName());
                        }
                        if (this.checkTeamGuiBanner.Checked)
                            this.CheckAndExport(team.BannerFileName());
                        if (this.checkTeamFlags.Checked)
                            this.CheckAndExport(team.FlagFileName());
                    }
                    else if (name == "Kit")
                    {
                        Kit kit = (Kit)tag;
                        if (this.checkKitTextures.Checked)
                            this.CheckAndExport(kit.KitTextureFileName());
                        if (this.checkKitMinikits.Checked)
                            this.CheckAndExport(kit.MiniKitDdsFileName());
                    }
                    else if (name == "League")
                    {
                        League league = (League)tag;
                        if (this.checkLeagueLogo.Checked)
                        {
                            this.CheckAndExport(league.TinyLogoDdsFileName());
                            this.CheckAndExport(league.SmallLogoDdsFileName());
                            this.CheckAndExport(league.AnimLogoDdsFileName());
                            this.CheckAndExport(league.Logo512x128DdsFileName());
                        }
                    }
                    else if (name == "Country")
                    {
                        Country country = (Country)tag;
                        if (this.checkCountryFlag.Checked)
                            this.CheckAndExport(country.FlagBigFileName());
                        if (this.checkCountryMap.Checked)
                            this.CheckAndExport(country.ShapeFileName());
                        if (this.checkCountryFlag512x512.Checked)
                            this.CheckAndExport(country.Flag512DdsFileName());
                        if (this.checkCountryMiniFlag.Checked)
                            this.CheckAndExport(country.MiniFlagBigFileName());
                    }
                    else if (name == "Stadium")
                    {
                        Stadium stadium = (Stadium)tag;
                        if (this.checkStadiumModel.Checked)
                        {
                            this.CheckAndExport(stadium.ModelFileName());
                            if (stadium.HasSunnyDay())
                            {
                                this.CheckAndExport(stadium.TexturesFileName(1));
                                this.CheckAndExport(stadium.CrowdFileName(1));
                            }
                            if (stadium.HasNight())
                            {
                                this.CheckAndExport(stadium.TexturesFileName(3));
                                this.CheckAndExport(stadium.CrowdFileName(3));
                            }
                        }
                        foreach (string glaresLightFileName in stadium.GlaresLightFileNames())
                            this.CheckAndExport(glaresLightFileName);
                        if (this.checkStadiumPreview.Checked)
                        {
                            this.CheckAndExport(stadium.PreviewBigFileName(0));
                            this.CheckAndExport(stadium.PreviewLargeBigFileName(0));
                            this.CheckAndExport(stadium.PreviewBigFileName(1));
                            this.CheckAndExport(stadium.PreviewLargeBigFileName(1));
                            this.CheckAndExport(stadium.PreviewBigFileName(3));
                            this.CheckAndExport(stadium.PreviewLargeBigFileName(3));
                            this.CheckAndExport(stadium.PreviewBigFileName(4));
                            this.CheckAndExport(stadium.PreviewLargeBigFileName(4));
                        }
                    }
                    else if (name == "Referee")
                    {
                        Referee referee = (Referee)tag;
                        if (this.checkRefereeMiniFace.Checked && FifaEnvironment.Year == 14)
                            this.CheckAndExport(referee.PhotoBigFileName());
                    }
                    else
                    {
                        string text = listViewItem.SubItems[1].Text;
                        int int32 = Convert.ToInt32(listViewItem.SubItems[2].Text);
                        if (text == "Ball")
                        {
                            this.CheckAndExport(Ball.BallModelFileName(int32));
                            this.CheckAndExport(Ball.BallTextureFileNameList(int32)[0]);
                            if (FifaEnvironment.Year == 14)
                                this.CheckAndExport(Ball.BallPictureBigFileName(int32));
                            else
                                this.CheckAndExport(Ball.BallDdsFileName(int32));
                        }
                        else if (text == "Adboard")
                            this.CheckAndExport(Adboard.AdboardFileName(int32));
                        else if (text == "Shoes")
                        {
                            this.CheckAndExport(Shoes.ShoesTexturesFileName(int32, 0));
                            this.CheckAndExport(Shoes.ShoesModelFileName(int32));
                        }
                        else if (text == "Net")
                            this.CheckAndExport(Net.NetFileName(int32));
                        else if (text == "MowingPattern")
                            this.CheckAndExport(MowingPattern.MowingPatternFileName(int32));
                        else if (text == "GkGloves")
                            this.CheckAndExport(GkGloves.GkGlovesTextureFileName(int32));
                        else if (text == "NumberFont")
                        {
                            int styleId = int32 / 20;
                            int colorId = int32 - styleId * 20;
                            this.CheckAndExport(NumberFont.NumberFontFileName(styleId, colorId, null));
                        }
                        else if (text == "NameFont")
                            this.CheckAndExport(NameFont.NameFontFileName(int32));
                    }
                }
                ZipOutputStream zip = new ZipOutputStream((Stream)File.Create(fileName1));
                zip.SetLevel(8);
                string[] files = Directory.GetFiles(this.m_TempFolder, "*.*", SearchOption.AllDirectories);
                if (files == null)
                    return;
                int startIndex = this.m_TempFolder.Length + 1;
                for (int index = 0; index < files.Length; ++index)
                {
                    string path = files[index];
                    string fileName2 = path.Substring(startIndex);
                    FileStream fileStream = File.OpenRead(path);
                    this.AddStreamToZip(zip, (Stream)fileStream, fileName2);
                    fileStream.Close();
                    this.statusLabel.Text = "Zipping " + (files.Length - index).ToString();
                    this.statusBar.Refresh();
                }
                zip.Finish();
                zip.Close();
                Cursor.Current = Cursors.Default;
                this.statusLabel.Text = "Ready";
                this.statusBar.Refresh();
            }
        }

        private void CheckAndExport(string fileName)
        {
            if (!this.radioIncludeOriginal.Checked && !FifaEnvironment.IsPatched(fileName))
                return;
            FifaEnvironment.ExportFileFromZdata(fileName, this.m_TempFolder);
        }

        private void CreateKeysArrays()
        {
            int length1 = 0;
            int length2 = 0;
            int length3 = 0;
            int length4 = 0;
            int length5 = 0;
            int length6 = 0;
            int length7 = 0;
            int length8 = 0;
            int length9 = 0;
            int length10 = 0;
            foreach (ListViewItem listViewItem in this.listViewDest.Items)
            {
                object tag = listViewItem.Tag;
                string name = listViewItem.Tag.GetType().Name;
                if (name == "Player")
                {
                    ++length4;
                    length5 += 4;
                }
                else if (name == "Team")
                {
                    ++length3;
                    length10 += 5;
                }
                else if (name == "Kit")
                    ++length6;
                else if (name == "League")
                {
                    ++length2;
                    length10 += 2;
                }
                else if (name == "Country")
                {
                    ++length1;
                    ++length10;
                }
                else if (name == "Stadium")
                {
                    ++length8;
                    ++length10;
                }
                else if (name == "Referee")
                    ++length7;
                else if (name == "Formation")
                    ++length9;
                else if (name == "Ball")
                    ++length10;
            }
            this.m_PlayerKeys = new int[length4];
            this.m_PlayerNameKeys = new int[length5];
            this.m_TeamKeys = new int[length3];
            this.m_KitKeys = new int[length6];
            this.m_LeagueKeys = new int[length2];
            this.m_CountryKeys = new int[length1];
            this.m_RefereeKeys = new int[length7];
            this.m_StadiumKeys = new int[length8];
            this.m_FormationKeys = new int[length9];
            this.m_LanguageKeys = new int[length10];
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            int num10 = 0;
            foreach (ListViewItem listViewItem in this.listViewDest.Items)
            {
                object tag = listViewItem.Tag;
                string name = listViewItem.Tag.GetType().Name;
                if (name == "Player")
                {
                    Player player = (Player)tag;
                    this.m_PlayerKeys[num4++] = player.Id;
                    int[] playerNameKeys1 = this.m_PlayerNameKeys;
                    int index1 = num5;
                    int num11 = index1 + 1;
                    int firstnameid = player.firstnameid;
                    playerNameKeys1[index1] = firstnameid;
                    int[] playerNameKeys2 = this.m_PlayerNameKeys;
                    int index2 = num11;
                    int num12 = index2 + 1;
                    int lastnameid = player.lastnameid;
                    playerNameKeys2[index2] = lastnameid;
                    int[] playerNameKeys3 = this.m_PlayerNameKeys;
                    int index3 = num12;
                    int num13 = index3 + 1;
                    int commonnameid = player.commonnameid;
                    playerNameKeys3[index3] = commonnameid;
                    int[] playerNameKeys4 = this.m_PlayerNameKeys;
                    int index4 = num13;
                    num5 = index4 + 1;
                    int playerjerseynameid = player.playerjerseynameid;
                    playerNameKeys4[index4] = playerjerseynameid;
                }
                else if (name == "Team")
                {
                    Team team = (Team)tag;
                    this.m_TeamKeys[num3++] = team.Id;
                    int[] languageKeys1 = this.m_LanguageKeys;
                    int index1 = num10;
                    int num11 = index1 + 1;
                    int teamHash1 = (int)FifaEnvironment.Language.GetTeamHash(team.Id, Language.ETeamStringType.Full);
                    languageKeys1[index1] = teamHash1;
                    int[] languageKeys2 = this.m_LanguageKeys;
                    int index2 = num11;
                    int num12 = index2 + 1;
                    int teamHash2 = (int)FifaEnvironment.Language.GetTeamHash(team.Id, Language.ETeamStringType.Abbr10);
                    languageKeys2[index2] = teamHash2;
                    int[] languageKeys3 = this.m_LanguageKeys;
                    int index3 = num12;
                    int num13 = index3 + 1;
                    int teamHash3 = (int)FifaEnvironment.Language.GetTeamHash(team.Id, Language.ETeamStringType.Abbr15);
                    languageKeys3[index3] = teamHash3;
                    int[] languageKeys4 = this.m_LanguageKeys;
                    int index4 = num13;
                    int num14 = index4 + 1;
                    int teamHash4 = (int)FifaEnvironment.Language.GetTeamHash(team.Id, Language.ETeamStringType.Abbr7);
                    languageKeys4[index4] = teamHash4;
                    int[] languageKeys5 = this.m_LanguageKeys;
                    int index5 = num14;
                    num10 = index5 + 1;
                    int teamHash5 = (int)FifaEnvironment.Language.GetTeamHash(team.Id, Language.ETeamStringType.Abbr3);
                    languageKeys5[index5] = teamHash5;
                }
                else if (name == "Kit")
                {
                    Kit kit = (Kit)tag;
                    this.m_KitKeys[num6++] = kit.Id;
                }
                else if (name == "League")
                {
                    League league = (League)tag;
                    this.m_LeagueKeys[num2++] = league.Id;
                    int[] languageKeys1 = this.m_LanguageKeys;
                    int index1 = num10;
                    int num11 = index1 + 1;
                    int leagueHash1 = (int)FifaEnvironment.Language.GetLeagueHash(league.Id, Language.ELeagueStringType.Abbr15);
                    languageKeys1[index1] = leagueHash1;
                    int[] languageKeys2 = this.m_LanguageKeys;
                    int index2 = num11;
                    num10 = index2 + 1;
                    int leagueHash2 = (int)FifaEnvironment.Language.GetLeagueHash(league.Id, Language.ELeagueStringType.Full);
                    languageKeys2[index2] = leagueHash2;
                }
                else if (name == "Country")
                {
                    Country country = (Country)tag;
                    this.m_CountryKeys[num1++] = country.Id;
                    this.m_LanguageKeys[num10++] = (int)FifaEnvironment.Language.GetCountryHash(country.Id, Language.ECountryStringType.Full);
                }
                else if (name == "Stadium")
                {
                    Stadium stadium = (Stadium)tag;
                    this.m_StadiumKeys[num8++] = stadium.Id;
                    this.m_LanguageKeys[num10++] = (int)FifaEnvironment.Language.GetStadiumHash(stadium.Id);
                }
                else if (name == "Referee")
                {
                    Referee referee = (Referee)tag;
                    this.m_RefereeKeys[num7++] = referee.Id;
                }
                else if (!(name == "Sponsor"))
                {
                    if (name == "Formation")
                    {
                        Formation formation = (Formation)tag;
                        this.m_FormationKeys[num9++] = formation.Id;
                    }
                    else if (name == "Ball")
                    {
                        Ball ball = (Ball)tag;
                        this.m_LanguageKeys[num10++] = (int)FifaEnvironment.Language.GetBallHash(ball.Id);
                    }
                }
            }
        }

        private bool AddStreamToZip(ZipOutputStream zip, Stream inputStream, string fileName)
        {
            if (inputStream == null)
                return false;
            Crc32 crc32 = new Crc32();
            byte[] buffer = new byte[inputStream.Length];
            inputStream.Read(buffer, 0, buffer.Length);
            ZipEntry entry = new ZipEntry(fileName);
            entry.DateTime = DateTime.Now;
            entry.Size = inputStream.Length;
            crc32.Reset();
            crc32.Update(buffer);
            entry.Crc = crc32.Value;
            zip.PutNextEntry(entry);
            zip.Write(buffer, 0, buffer.Length);
            return true;
        }

        private void OpenPatch()
        {
            this.openFileDialog.CheckFileExists = true;
            this.openFileDialog.Title = "Open Creation Master Patch file";
            this.openFileDialog.Filter = "Creation Master Patch (*.cmp)|*.cmp";
            this.openFileDialog.FilterIndex = 1;
            this.openFileDialog.Multiselect = false;
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string fileName = this.openFileDialog.FileName;
            if (!File.Exists(fileName))
                return;
            this.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            if (Directory.Exists(this.m_TempFolder))
                Directory.Delete(this.m_TempFolder, true);
            Directory.CreateDirectory(this.m_TempFolder);
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            ZipFile zipFile = new ZipFile(fileName);
            ZipInputStream zip = new ZipInputStream((Stream)fileStream);
            this.ZipExtractAllFiles(zip, this.m_TempFolder);
            zip.Close();
            this.m_PatchDataSet.Clear();
            int num = (int)this.m_PatchDataSet.ReadXml(this.m_TempFolder + "\\Patch.xml");
            DataRow row1 = this.m_PatchDataSet.PatchIdentity.Rows[0];
            this.textDescription.Text = (string)row1["Description"];
            this.textPatchName.Text = (string)row1["Name"];
            this.textPatchVersion.Text = (string)row1["Version"];
            this.checkCMSCompatible.Checked = (string)row1["CMS"] == "CMS 14";
            this.listViewDest.Items.Clear();
            foreach (DataRow row2 in (InternalDataCollectionBase)this.m_PatchDataSet.PatchElements.Rows)
            {
                string[] strArray = new string[4]
                {
          null,
          (string) row2.ItemArray[1],
          (string) row2.ItemArray[2],
          (string) row2.ItemArray[3]
                };
                strArray[0] = (string)row2.ItemArray[0];
                switch (strArray[1])
                {
                    case "Player":
                        Player player = (Player)FifaEnvironment.Players.SearchId(Convert.ToInt32(strArray[2]));
                        if (player != null)
                        {
                            this.WriteToPatchList((IdObject)player, player.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Shoes":
                        Shoes shoes = (Shoes)FifaEnvironment.Shoes.SearchId(Convert.ToInt32(strArray[2]));
                        if (shoes != null)
                        {
                            this.WriteToPatchList((IdObject)shoes, shoes.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Team":
                        Team team = (Team)FifaEnvironment.Teams.SearchId(Convert.ToInt32(strArray[2]));
                        if (team != null)
                        {
                            this.WriteToPatchList((IdObject)team, team.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Kit":
                        Kit kit = (Kit)FifaEnvironment.Kits.SearchId(Convert.ToInt32(strArray[2]));
                        if (kit != null)
                        {
                            this.WriteToPatchList((IdObject)kit, kit.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Formation":
                        Formation formation = (Formation)FifaEnvironment.Formations.SearchId(Convert.ToInt32(strArray[2]));
                        if (formation != null)
                        {
                            this.WriteToPatchList((IdObject)formation, formation.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Ball":
                        Ball ball = (Ball)FifaEnvironment.Balls.SearchId(Convert.ToInt32(strArray[2]));
                        if (ball != null)
                        {
                            this.WriteToPatchList((IdObject)ball, ball.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Adboard":
                        Adboard adboard = (Adboard)FifaEnvironment.Adboards.SearchId(Convert.ToInt32(strArray[2]));
                        if (adboard != null)
                        {
                            this.WriteToPatchList((IdObject)adboard, adboard.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "League":
                        League league = (League)FifaEnvironment.Leagues.SearchId(Convert.ToInt32(strArray[2]));
                        if (league != null)
                        {
                            this.WriteToPatchList((IdObject)league, league.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Country":
                        Country country = (Country)FifaEnvironment.Countries.SearchId(Convert.ToInt32(strArray[2]));
                        if (country != null)
                        {
                            this.WriteToPatchList((IdObject)country, country.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Referee":
                        Referee referee = (Referee)FifaEnvironment.Referees.SearchId(Convert.ToInt32(strArray[2]));
                        if (referee != null)
                        {
                            this.WriteToPatchList((IdObject)referee, referee.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "NameFont":
                        NameFont nameFont = (NameFont)FifaEnvironment.NameFonts.SearchId(Convert.ToInt32(strArray[2]));
                        if (nameFont != null)
                        {
                            this.WriteToPatchList((IdObject)nameFont, nameFont.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "NumberFont":
                        NumberFont numberFont = (NumberFont)FifaEnvironment.NumberFonts.SearchId(Convert.ToInt32(strArray[2]));
                        if (numberFont != null)
                        {
                            this.WriteToPatchList((IdObject)numberFont, numberFont.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "Net":
                        Net net = (Net)FifaEnvironment.Nets.SearchId(Convert.ToInt32(strArray[2]));
                        if (net != null)
                        {
                            this.WriteToPatchList((IdObject)net, net.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "MowingPattern":
                        MowingPattern mowingPattern = (MowingPattern)FifaEnvironment.MowingPatterns.SearchId(Convert.ToInt32(strArray[2]));
                        if (mowingPattern != null)
                        {
                            this.WriteToPatchList((IdObject)mowingPattern, mowingPattern.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    case "GkGloves":
                        GkGloves gkGloves = (GkGloves)FifaEnvironment.GkGloves.SearchId(Convert.ToInt32(strArray[2]));
                        if (gkGloves != null)
                        {
                            this.WriteToPatchList((IdObject)gkGloves, gkGloves.Id, strArray[3], strArray[0]);
                            continue;
                        }
                        continue;
                    default:
                        continue;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonOpenPatch_Click(object sender, EventArgs e)
        {
            this.OpenPatch();
        }

        private void ZipExtractAllFiles(ZipInputStream zip, string exportFolder)
        {
            ZipEntry nextEntry;
            while ((nextEntry = zip.GetNextEntry()) != null)
                this.ZipExtractSingleFile(zip, nextEntry, exportFolder);
        }

        private void ZipExtractSingleFile(ZipInputStream zip, ZipEntry zipEntry, string exportFolder)
        {
            string path = exportFolder + "\\" + Path.GetDirectoryName(zipEntry.Name);
            if (!(Path.GetFileName(zipEntry.Name) != string.Empty))
                return;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fileStream = File.Create(exportFolder + "\\" + zipEntry.Name);
            byte[] buffer = new byte[2048];
            while (true)
            {
                int count = zip.Read(buffer, 0, buffer.Length);
                if (count > 0)
                    fileStream.Write(buffer, 0, count);
                else
                    break;
            }
            fileStream.Close();
        }

        private void buttonNewPatch_Click(object sender, EventArgs e)
        {
            this.InitPatchCreatorForm();
        }

        private void InitPatchCreatorForm()
        {
            this.listViewDest.Items.Clear();
            this.textDescription.Text = string.Empty;
            this.textPatchName.Text = string.Empty;
            this.textPatchVersion.Text = string.Empty;
            this.checkCMSCompatible.Checked = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InitPatchCreatorForm();
        }

        private void createPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreatePatch();
        }

        private void openPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenPatch();
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PatchCreatorForm));
            this.splitContainer1 = new SplitContainer();
            this.listSource = new ListBox();
            this.listViewDest = new ListView();
            this.columnComment = new ColumnHeader();
            this.columnType = new ColumnHeader();
            this.columnId = new ColumnHeader();
            this.columnItem = new ColumnHeader();
            this.toolAddRemove = new ToolStrip();
            this.buttonAddObject = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.buttonRemoveObject = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.buttonAddFile = new ToolStripButton();
            this.panelLeft = new Panel();
            this.statusBar = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();
            this.textDescription = new TextBox();
            this.label1 = new Label();
            this.checkCMSCompatible = new CheckBox();
            this.textPatchVersion = new TextBox();
            this.textPatchName = new TextBox();
            this.labelPatchVersion = new Label();
            this.labelPatchName = new Label();
            this.comboPatchType = new ComboBox();
            this.groupPatchOptions = new GroupBox();
            this.tabPatchOptions = new TabControl();
            this.pageGeneralOptions = new TabPage();
            this.radioIncludeOriginal = new RadioButton();
            this.radioIncludePatched = new RadioButton();
            this.pageCountryOptions = new TabPage();
            this.checkCountryMap = new CheckBox();
            this.checkCountryFlag512x512 = new CheckBox();
            this.checkCountryCardFlag = new CheckBox();
            this.checkCountryTournaments = new CheckBox();
            this.checkCountryLeagues = new CheckBox();
            this.checkContrynationalTeam = new CheckBox();
            this.checkCountryMiniFlag = new CheckBox();
            this.checkCountryDatabase = new CheckBox();
            this.checkCountryFlag = new CheckBox();
            this.pageLeagueOptions = new TabPage();
            this.checkLeagueBall = new CheckBox();
            this.checkLeagueReferees = new CheckBox();
            this.checkLeagueLinkedTournament = new CheckBox();
            this.checkLeagueLinkedTeams = new CheckBox();
            this.checkLeagueLogo = new CheckBox();
            this.checkLeagueDatabase = new CheckBox();
            this.pageTeamOptions = new TabPage();
            this.checkTeamStadium = new CheckBox();
            this.checkTeamFormation = new CheckBox();
            this.checkTeamAdboard = new CheckBox();
            this.checkTeamBall = new CheckBox();
            this.checkTeamLinkedPlayers = new CheckBox();
            this.checkTeamKits = new CheckBox();
            this.checkTeamFlags = new CheckBox();
            this.checkTeamGuiBanner = new CheckBox();
            this.checkTeamGuiLogo = new CheckBox();
            this.checkTeamDatabase = new CheckBox();
            this.pageKitOptions = new TabPage();
            this.checkKitTextures = new CheckBox();
            this.checkKitNameFonts = new CheckBox();
            this.checkKitDatabase = new CheckBox();
            this.checkKitNumbers = new CheckBox();
            this.checkKitMinikits = new CheckBox();
            this.pagePlayerOptions = new TabPage();
            this.checkPlayerGloves = new CheckBox();
            this.checkPlayerShoes = new CheckBox();
            this.checkPlayerMiniface = new CheckBox();
            this.checkPlayerHead = new CheckBox();
            this.checkPlayerDatabase = new CheckBox();
            this.pageRefereeOptions = new TabPage();
            this.checkRefereeMiniFace = new CheckBox();
            this.checkRefereeShoes = new CheckBox();
            this.checkRefereeKits = new CheckBox();
            this.checkRefereeDatabase = new CheckBox();
            this.pageStadiumOptions = new TabPage();
            this.checkStadiumMowingPattern = new CheckBox();
            this.checkStadiumModel = new CheckBox();
            this.checkStadiumPreview = new CheckBox();
            this.checkStadiumDatabase = new CheckBox();
            this.checkStadiumNet = new CheckBox();
            this.labelPatchType = new Label();
            this.mainMenuStrip = new MenuStrip();
            this.patchToolStripMenuItem = new ToolStripMenuItem();
            this.newPatchToolStripMenuItem = new ToolStripMenuItem();
            this.createPatchToolStripMenuItem = new ToolStripMenuItem();
            this.openPatchToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.toolMain = new ToolStrip();
            this.buttonNewPatch = new ToolStripButton();
            this.buttonOpenPatch = new ToolStripButton();
            this.buttonCreatePatch = new ToolStripButton();
            this.buttonExit = new ToolStripButton();
            this.openFileDialog = new OpenFileDialog();
            this.m_PatchDataSet = new Patch();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolAddRemove.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.groupPatchOptions.SuspendLayout();
            this.tabPatchOptions.SuspendLayout();
            this.pageGeneralOptions.SuspendLayout();
            this.pageCountryOptions.SuspendLayout();
            this.pageLeagueOptions.SuspendLayout();
            this.pageTeamOptions.SuspendLayout();
            this.pageKitOptions.SuspendLayout();
            this.pagePlayerOptions.SuspendLayout();
            this.pageRefereeOptions.SuspendLayout();
            this.pageStadiumOptions.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.toolMain.SuspendLayout();
            this.m_PatchDataSet.BeginInit();
            this.SuspendLayout();
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(300, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add((Control)this.listSource);
            this.splitContainer1.Panel2.Controls.Add((Control)this.listViewDest);
            this.splitContainer1.Panel2.Controls.Add((Control)this.toolAddRemove);
            this.splitContainer1.Size = new Size(728, 697);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            this.listSource.Dock = DockStyle.Fill;
            this.listSource.FormattingEnabled = true;
            this.listSource.Location = new Point(0, 0);
            this.listSource.Name = "listSource";
            this.listSource.SelectionMode = SelectionMode.MultiExtended;
            this.listSource.Size = new Size(262, 697);
            this.listSource.TabIndex = 27;
            this.listViewDest.AllowColumnReorder = true;
            this.listViewDest.Columns.AddRange(new ColumnHeader[4]
            {
        this.columnComment,
        this.columnType,
        this.columnId,
        this.columnItem
            });
            this.listViewDest.Dock = DockStyle.Fill;
            this.listViewDest.Font = new Font("Microsoft Sans Serif", 8.25f);
            this.listViewDest.FullRowSelect = true;
            this.listViewDest.GridLines = true;
            this.listViewDest.HideSelection = false;
            this.listViewDest.LabelEdit = true;
            this.listViewDest.Location = new Point(0, 25);
            this.listViewDest.Name = "listViewDest";
            this.listViewDest.Size = new Size(462, 672);
            this.listViewDest.TabIndex = 27;
            this.listViewDest.UseCompatibleStateImageBehavior = false;
            this.listViewDest.View = View.Details;
            this.columnComment.DisplayIndex = 3;
            this.columnComment.Text = "Comment";
            this.columnComment.Width = 147;
            this.columnType.DisplayIndex = 0;
            this.columnType.Text = "Type";
            this.columnType.Width = 72;
            this.columnId.DisplayIndex = 1;
            this.columnId.Text = "ID";
            this.columnId.TextAlign = HorizontalAlignment.Center;
            this.columnId.Width = 51;
            this.columnItem.DisplayIndex = 2;
            this.columnItem.Text = "Item";
            this.columnItem.TextAlign = HorizontalAlignment.Center;
            this.columnItem.Width = 124;
            this.toolAddRemove.GripStyle = ToolStripGripStyle.Hidden;
            this.toolAddRemove.Items.AddRange(new ToolStripItem[5]
            {
        (ToolStripItem) this.buttonAddObject,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.buttonRemoveObject,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.buttonAddFile
            });
            this.toolAddRemove.Location = new Point(0, 0);
            this.toolAddRemove.Name = "toolAddRemove";
            this.toolAddRemove.Size = new Size(462, 25);
            this.toolAddRemove.TabIndex = 7;
            this.buttonAddObject.Image = (Image)resources.GetObject("buttonAddObject.Image");
            this.buttonAddObject.ImageTransparentColor = Color.Magenta;
            this.buttonAddObject.Name = "buttonAddObject";
            this.buttonAddObject.Size = new Size(49, 22);
            this.buttonAddObject.Text = "Add";
            this.buttonAddObject.Click += new EventHandler(this.buttonAdd_Click);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 25);
            this.buttonRemoveObject.Image = (Image)resources.GetObject("buttonRemoveObject.Image");
            this.buttonRemoveObject.ImageTransparentColor = Color.Magenta;
            this.buttonRemoveObject.Name = "buttonRemoveObject";
            this.buttonRemoveObject.Size = new Size(70, 22);
            this.buttonRemoveObject.Text = "Remove";
            this.buttonRemoveObject.Click += new EventHandler(this.buttonRemoveObject_Click);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 25);
            this.buttonAddFile.Image = (Image)resources.GetObject("buttonAddFile.Image");
            this.buttonAddFile.ImageTransparentColor = Color.Magenta;
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new Size(70, 22);
            this.buttonAddFile.Text = "Add File";
            this.buttonAddFile.Visible = false;
            this.buttonAddFile.Click += new EventHandler(this.buttonAddFile_Click);
            this.panelLeft.AutoScroll = true;
            this.panelLeft.BorderStyle = BorderStyle.Fixed3D;
            this.panelLeft.Controls.Add((Control)this.statusBar);
            this.panelLeft.Controls.Add((Control)this.textDescription);
            this.panelLeft.Controls.Add((Control)this.label1);
            this.panelLeft.Controls.Add((Control)this.checkCMSCompatible);
            this.panelLeft.Controls.Add((Control)this.textPatchVersion);
            this.panelLeft.Controls.Add((Control)this.textPatchName);
            this.panelLeft.Controls.Add((Control)this.labelPatchVersion);
            this.panelLeft.Controls.Add((Control)this.labelPatchName);
            this.panelLeft.Controls.Add((Control)this.comboPatchType);
            this.panelLeft.Controls.Add((Control)this.groupPatchOptions);
            this.panelLeft.Controls.Add((Control)this.labelPatchType);
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Location = new Point(0, 49);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new Size(300, 697);
            this.panelLeft.TabIndex = 3;
            this.statusBar.Items.AddRange(new ToolStripItem[1]
            {
        (ToolStripItem) this.statusLabel
            });
            this.statusBar.Location = new Point(0, 671);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new Size(296, 22);
            this.statusBar.TabIndex = 29;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new Size(39, 17);
            this.statusLabel.Text = "Status";
            this.textDescription.Dock = DockStyle.Top;
            this.textDescription.Location = new Point(0, 411);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new Size(296, 185);
            this.textDescription.TabIndex = 15;
            this.label1.Dock = DockStyle.Top;
            this.label1.ImeMode = ImeMode.NoControl;
            this.label1.Location = new Point(0, 390);
            this.label1.Name = "label1";
            this.label1.Size = new Size(296, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Description";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.checkCMSCompatible.CheckAlign = ContentAlignment.MiddleCenter;
            this.checkCMSCompatible.Dock = DockStyle.Top;
            this.checkCMSCompatible.Location = new Point(0, 362);
            this.checkCMSCompatible.Name = "checkCMSCompatible";
            this.checkCMSCompatible.Size = new Size(296, 28);
            this.checkCMSCompatible.TabIndex = 28;
            this.checkCMSCompatible.Text = "CMS 14 Compliant";
            this.checkCMSCompatible.UseVisualStyleBackColor = true;
            this.checkCMSCompatible.Visible = false;
            this.textPatchVersion.Location = new Point(86, 338);
            this.textPatchVersion.Name = "textPatchVersion";
            this.textPatchVersion.Size = new Size(203, 20);
            this.textPatchVersion.TabIndex = 13;
            this.textPatchVersion.TextAlign = HorizontalAlignment.Center;
            this.textPatchName.Location = new Point(86, 310);
            this.textPatchName.Name = "textPatchName";
            this.textPatchName.Size = new Size(203, 20);
            this.textPatchName.TabIndex = 11;
            this.textPatchName.TextAlign = HorizontalAlignment.Center;
            this.labelPatchVersion.Dock = DockStyle.Top;
            this.labelPatchVersion.ImeMode = ImeMode.NoControl;
            this.labelPatchVersion.Location = new Point(0, 334);
            this.labelPatchVersion.Name = "labelPatchVersion";
            this.labelPatchVersion.Size = new Size(296, 28);
            this.labelPatchVersion.TabIndex = 12;
            this.labelPatchVersion.Text = "Patch Version";
            this.labelPatchVersion.TextAlign = ContentAlignment.MiddleLeft;
            this.labelPatchName.Dock = DockStyle.Top;
            this.labelPatchName.ImeMode = ImeMode.NoControl;
            this.labelPatchName.Location = new Point(0, 306);
            this.labelPatchName.Name = "labelPatchName";
            this.labelPatchName.Size = new Size(296, 28);
            this.labelPatchName.TabIndex = 10;
            this.labelPatchName.Text = "Patch Name";
            this.labelPatchName.TextAlign = ContentAlignment.MiddleLeft;
            this.comboPatchType.FormattingEnabled = true;
            this.comboPatchType.Items.AddRange(new object[16]
            {
        (object) "Countries",
        (object) "Leagues",
        (object) "Teams",
        (object) "Players",
        (object) "Kits",
        (object) "Referees",
        (object) "Stadiums",
        (object) "Formations",
        (object) "Balls",
        (object) "Adboards",
        (object) "Number Fonts",
        (object) "Name Fonts",
        (object) "Shoes",
        (object) "GK Gloves",
        (object) "Nets",
        (object) "Mowing Patterns"
            });
            this.comboPatchType.Location = new Point(7, 21);
            this.comboPatchType.Name = "comboPatchType";
            this.comboPatchType.Size = new Size(282, 21);
            this.comboPatchType.TabIndex = 1;
            this.comboPatchType.SelectedIndexChanged += new EventHandler(this.comboPatchType_SelectedIndexChanged);
            this.groupPatchOptions.Controls.Add((Control)this.tabPatchOptions);
            this.groupPatchOptions.Dock = DockStyle.Top;
            this.groupPatchOptions.Location = new Point(0, 48);
            this.groupPatchOptions.Name = "groupPatchOptions";
            this.groupPatchOptions.RightToLeft = RightToLeft.No;
            this.groupPatchOptions.Size = new Size(296, 258);
            this.groupPatchOptions.TabIndex = 9;
            this.groupPatchOptions.TabStop = false;
            this.groupPatchOptions.Text = "Patch Options";
            this.tabPatchOptions.Controls.Add((Control)this.pageGeneralOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pageCountryOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pageLeagueOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pageTeamOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pageKitOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pagePlayerOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pageRefereeOptions);
            this.tabPatchOptions.Controls.Add((Control)this.pageStadiumOptions);
            this.tabPatchOptions.Dock = DockStyle.Fill;
            this.tabPatchOptions.ItemSize = new Size(80, 20);
            this.tabPatchOptions.Location = new Point(3, 16);
            this.tabPatchOptions.Multiline = true;
            this.tabPatchOptions.Name = "tabPatchOptions";
            this.tabPatchOptions.SelectedIndex = 0;
            this.tabPatchOptions.Size = new Size(290, 239);
            this.tabPatchOptions.SizeMode = TabSizeMode.FillToRight;
            this.tabPatchOptions.TabIndex = 8;
            this.pageGeneralOptions.Controls.Add((Control)this.radioIncludeOriginal);
            this.pageGeneralOptions.Controls.Add((Control)this.radioIncludePatched);
            this.pageGeneralOptions.Location = new Point(4, 44);
            this.pageGeneralOptions.Name = "pageGeneralOptions";
            this.pageGeneralOptions.Size = new Size(282, 191);
            this.pageGeneralOptions.TabIndex = 8;
            this.pageGeneralOptions.Text = "General";
            this.pageGeneralOptions.UseVisualStyleBackColor = true;
            this.radioIncludeOriginal.AutoSize = true;
            this.radioIncludeOriginal.BackgroundImageLayout = ImageLayout.None;
            this.radioIncludeOriginal.Location = new Point(24, 43);
            this.radioIncludeOriginal.Name = "radioIncludeOriginal";
            this.radioIncludeOriginal.Size = new Size(186, 17);
            this.radioIncludeOriginal.TabIndex = 1;
            this.radioIncludeOriginal.TabStop = true;
            this.radioIncludeOriginal.Text = "Include Patched and Original Files";
            this.radioIncludeOriginal.UseVisualStyleBackColor = true;
            this.radioIncludePatched.AutoSize = true;
            this.radioIncludePatched.Checked = true;
            this.radioIncludePatched.Location = new Point(24, 20);
            this.radioIncludePatched.Name = "radioIncludePatched";
            this.radioIncludePatched.Size = new Size(151, 17);
            this.radioIncludePatched.TabIndex = 0;
            this.radioIncludePatched.TabStop = true;
            this.radioIncludePatched.Text = "Include Patched Files Only";
            this.radioIncludePatched.UseVisualStyleBackColor = true;
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryMap);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryFlag512x512);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryCardFlag);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryTournaments);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryLeagues);
            this.pageCountryOptions.Controls.Add((Control)this.checkContrynationalTeam);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryMiniFlag);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryDatabase);
            this.pageCountryOptions.Controls.Add((Control)this.checkCountryFlag);
            this.pageCountryOptions.Location = new Point(4, 44);
            this.pageCountryOptions.Name = "pageCountryOptions";
            this.pageCountryOptions.Size = new Size(282, 191);
            this.pageCountryOptions.TabIndex = 3;
            this.pageCountryOptions.Text = "Countries";
            this.pageCountryOptions.UseVisualStyleBackColor = true;
            this.checkCountryMap.AutoSize = true;
            this.checkCountryMap.ForeColor = SystemColors.ControlText;
            this.checkCountryMap.ImeMode = ImeMode.NoControl;
            this.checkCountryMap.Location = new Point(20, 66);
            this.checkCountryMap.Name = "checkCountryMap";
            this.checkCountryMap.Size = new Size(47, 17);
            this.checkCountryMap.TabIndex = 9;
            this.checkCountryMap.Text = "Map";
            this.checkCountryMap.UseVisualStyleBackColor = true;
            this.checkCountryFlag512x512.AutoSize = true;
            this.checkCountryFlag512x512.ForeColor = SystemColors.ControlText;
            this.checkCountryFlag512x512.ImeMode = ImeMode.NoControl;
            this.checkCountryFlag512x512.Location = new Point(20, 135);
            this.checkCountryFlag512x512.Name = "checkCountryFlag512x512";
            this.checkCountryFlag512x512.Size = new Size(93, 17);
            this.checkCountryFlag512x512.TabIndex = 8;
            this.checkCountryFlag512x512.Text = "512 x 512 flag";
            this.checkCountryFlag512x512.UseVisualStyleBackColor = true;
            this.checkCountryCardFlag.AutoSize = true;
            this.checkCountryCardFlag.ForeColor = SystemColors.ControlText;
            this.checkCountryCardFlag.ImeMode = ImeMode.NoControl;
            this.checkCountryCardFlag.Location = new Point(20, 89);
            this.checkCountryCardFlag.Name = "checkCountryCardFlag";
            this.checkCountryCardFlag.Size = new Size(71, 17);
            this.checkCountryCardFlag.TabIndex = 7;
            this.checkCountryCardFlag.Text = "Card Flag";
            this.checkCountryCardFlag.UseVisualStyleBackColor = true;
            this.checkCountryTournaments.AutoSize = true;
            this.checkCountryTournaments.ImeMode = ImeMode.NoControl;
            this.checkCountryTournaments.Location = new Point(150, 66);
            this.checkCountryTournaments.Name = "checkCountryTournaments";
            this.checkCountryTournaments.Size = new Size(123, 17);
            this.checkCountryTournaments.TabIndex = 6;
            this.checkCountryTournaments.Text = "Linked Tournaments";
            this.checkCountryTournaments.UseVisualStyleBackColor = true;
            this.checkCountryTournaments.Visible = false;
            this.checkCountryLeagues.AutoSize = true;
            this.checkCountryLeagues.Checked = true;
            this.checkCountryLeagues.CheckState = CheckState.Checked;
            this.checkCountryLeagues.ImeMode = ImeMode.NoControl;
            this.checkCountryLeagues.Location = new Point(150, 43);
            this.checkCountryLeagues.Name = "checkCountryLeagues";
            this.checkCountryLeagues.Size = new Size(102, 17);
            this.checkCountryLeagues.TabIndex = 5;
            this.checkCountryLeagues.Text = "Linked Leagues";
            this.checkCountryLeagues.UseVisualStyleBackColor = true;
            this.checkContrynationalTeam.AutoSize = true;
            this.checkContrynationalTeam.Checked = true;
            this.checkContrynationalTeam.CheckState = CheckState.Checked;
            this.checkContrynationalTeam.ImeMode = ImeMode.NoControl;
            this.checkContrynationalTeam.Location = new Point(150, 20);
            this.checkContrynationalTeam.Name = "checkContrynationalTeam";
            this.checkContrynationalTeam.Size = new Size(130, 17);
            this.checkContrynationalTeam.TabIndex = 4;
            this.checkContrynationalTeam.Text = "Linked National Team";
            this.checkContrynationalTeam.UseVisualStyleBackColor = true;
            this.checkCountryMiniFlag.AutoSize = true;
            this.checkCountryMiniFlag.ForeColor = SystemColors.ControlText;
            this.checkCountryMiniFlag.ImeMode = ImeMode.NoControl;
            this.checkCountryMiniFlag.Location = new Point(20, 112);
            this.checkCountryMiniFlag.Name = "checkCountryMiniFlag";
            this.checkCountryMiniFlag.Size = new Size(68, 17);
            this.checkCountryMiniFlag.TabIndex = 2;
            this.checkCountryMiniFlag.Text = "Mini Flag";
            this.checkCountryMiniFlag.UseVisualStyleBackColor = true;
            this.checkCountryDatabase.AutoSize = true;
            this.checkCountryDatabase.Checked = true;
            this.checkCountryDatabase.CheckState = CheckState.Checked;
            this.checkCountryDatabase.ForeColor = SystemColors.ControlText;
            this.checkCountryDatabase.ImeMode = ImeMode.NoControl;
            this.checkCountryDatabase.Location = new Point(20, 20);
            this.checkCountryDatabase.Name = "checkCountryDatabase";
            this.checkCountryDatabase.Size = new Size(93, 17);
            this.checkCountryDatabase.TabIndex = 1;
            this.checkCountryDatabase.Text = "Database Info";
            this.checkCountryDatabase.UseVisualStyleBackColor = true;
            this.checkCountryFlag.AutoSize = true;
            this.checkCountryFlag.Checked = true;
            this.checkCountryFlag.CheckState = CheckState.Checked;
            this.checkCountryFlag.ForeColor = SystemColors.ControlText;
            this.checkCountryFlag.ImeMode = ImeMode.NoControl;
            this.checkCountryFlag.Location = new Point(20, 43);
            this.checkCountryFlag.Name = "checkCountryFlag";
            this.checkCountryFlag.Size = new Size(46, 17);
            this.checkCountryFlag.TabIndex = 0;
            this.checkCountryFlag.Text = "Flag";
            this.checkCountryFlag.UseVisualStyleBackColor = true;
            this.pageLeagueOptions.Controls.Add((Control)this.checkLeagueBall);
            this.pageLeagueOptions.Controls.Add((Control)this.checkLeagueReferees);
            this.pageLeagueOptions.Controls.Add((Control)this.checkLeagueLinkedTournament);
            this.pageLeagueOptions.Controls.Add((Control)this.checkLeagueLinkedTeams);
            this.pageLeagueOptions.Controls.Add((Control)this.checkLeagueLogo);
            this.pageLeagueOptions.Controls.Add((Control)this.checkLeagueDatabase);
            this.pageLeagueOptions.Location = new Point(4, 44);
            this.pageLeagueOptions.Name = "pageLeagueOptions";
            this.pageLeagueOptions.Size = new Size(282, 191);
            this.pageLeagueOptions.TabIndex = 2;
            this.pageLeagueOptions.Text = "Leagues";
            this.pageLeagueOptions.UseVisualStyleBackColor = true;
            this.checkLeagueBall.AutoSize = true;
            this.checkLeagueBall.ImeMode = ImeMode.NoControl;
            this.checkLeagueBall.Location = new Point(150, 101);
            this.checkLeagueBall.Name = "checkLeagueBall";
            this.checkLeagueBall.Size = new Size(78, 17);
            this.checkLeagueBall.TabIndex = 15;
            this.checkLeagueBall.Text = "Linked Ball";
            this.checkLeagueBall.UseVisualStyleBackColor = true;
            this.checkLeagueBall.Visible = false;
            this.checkLeagueReferees.AutoSize = true;
            this.checkLeagueReferees.Checked = true;
            this.checkLeagueReferees.CheckState = CheckState.Checked;
            this.checkLeagueReferees.ImeMode = ImeMode.NoControl;
            this.checkLeagueReferees.Location = new Point(150, 43);
            this.checkLeagueReferees.Name = "checkLeagueReferees";
            this.checkLeagueReferees.Size = new Size(104, 17);
            this.checkLeagueReferees.TabIndex = 14;
            this.checkLeagueReferees.Text = "Linked Referees";
            this.checkLeagueReferees.UseVisualStyleBackColor = true;
            this.checkLeagueLinkedTournament.AutoSize = true;
            this.checkLeagueLinkedTournament.ImeMode = ImeMode.NoControl;
            this.checkLeagueLinkedTournament.Location = new Point(150, 124);
            this.checkLeagueLinkedTournament.Name = "checkLeagueLinkedTournament";
            this.checkLeagueLinkedTournament.Size = new Size(118, 17);
            this.checkLeagueLinkedTournament.TabIndex = 13;
            this.checkLeagueLinkedTournament.Text = "Linked Tournament";
            this.checkLeagueLinkedTournament.UseVisualStyleBackColor = true;
            this.checkLeagueLinkedTournament.Visible = false;
            this.checkLeagueLinkedTeams.AutoSize = true;
            this.checkLeagueLinkedTeams.Checked = true;
            this.checkLeagueLinkedTeams.CheckState = CheckState.Checked;
            this.checkLeagueLinkedTeams.ImeMode = ImeMode.NoControl;
            this.checkLeagueLinkedTeams.Location = new Point(150, 20);
            this.checkLeagueLinkedTeams.Name = "checkLeagueLinkedTeams";
            this.checkLeagueLinkedTeams.Size = new Size(93, 17);
            this.checkLeagueLinkedTeams.TabIndex = 12;
            this.checkLeagueLinkedTeams.Text = "Linked Teams";
            this.checkLeagueLinkedTeams.UseVisualStyleBackColor = true;
            this.checkLeagueLogo.AutoSize = true;
            this.checkLeagueLogo.Checked = true;
            this.checkLeagueLogo.CheckState = CheckState.Checked;
            this.checkLeagueLogo.ImeMode = ImeMode.NoControl;
            this.checkLeagueLogo.Location = new Point(20, 43);
            this.checkLeagueLogo.Name = "checkLeagueLogo";
            this.checkLeagueLogo.Size = new Size(55, 17);
            this.checkLeagueLogo.TabIndex = 10;
            this.checkLeagueLogo.Text = "Logos";
            this.checkLeagueLogo.UseVisualStyleBackColor = true;
            this.checkLeagueDatabase.AutoSize = true;
            this.checkLeagueDatabase.Checked = true;
            this.checkLeagueDatabase.CheckState = CheckState.Checked;
            this.checkLeagueDatabase.ImeMode = ImeMode.NoControl;
            this.checkLeagueDatabase.Location = new Point(20, 20);
            this.checkLeagueDatabase.Name = "checkLeagueDatabase";
            this.checkLeagueDatabase.Size = new Size(93, 17);
            this.checkLeagueDatabase.TabIndex = 9;
            this.checkLeagueDatabase.Text = "Database Info";
            this.checkLeagueDatabase.UseVisualStyleBackColor = true;
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamStadium);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamFormation);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamAdboard);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamBall);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamLinkedPlayers);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamKits);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamFlags);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamGuiBanner);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamGuiLogo);
            this.pageTeamOptions.Controls.Add((Control)this.checkTeamDatabase);
            this.pageTeamOptions.Location = new Point(4, 44);
            this.pageTeamOptions.Name = "pageTeamOptions";
            this.pageTeamOptions.Padding = new Padding(3);
            this.pageTeamOptions.Size = new Size(282, 191);
            this.pageTeamOptions.TabIndex = 1;
            this.pageTeamOptions.Text = "Teams";
            this.pageTeamOptions.UseVisualStyleBackColor = true;
            this.checkTeamStadium.AutoSize = true;
            this.checkTeamStadium.ImeMode = ImeMode.NoControl;
            this.checkTeamStadium.Location = new Point(150, 135);
            this.checkTeamStadium.Name = "checkTeamStadium";
            this.checkTeamStadium.Size = new Size(99, 17);
            this.checkTeamStadium.TabIndex = 13;
            this.checkTeamStadium.Text = "Linked Stadium";
            this.checkTeamStadium.UseVisualStyleBackColor = true;
            this.checkTeamFormation.AutoSize = true;
            this.checkTeamFormation.Checked = true;
            this.checkTeamFormation.CheckState = CheckState.Checked;
            this.checkTeamFormation.ImeMode = ImeMode.NoControl;
            this.checkTeamFormation.Location = new Point(150, 66);
            this.checkTeamFormation.Name = "checkTeamFormation";
            this.checkTeamFormation.Size = new Size(107, 17);
            this.checkTeamFormation.TabIndex = 12;
            this.checkTeamFormation.Text = "Linked Formation";
            this.checkTeamFormation.UseVisualStyleBackColor = true;
            this.checkTeamAdboard.AutoSize = true;
            this.checkTeamAdboard.Checked = true;
            this.checkTeamAdboard.CheckState = CheckState.Checked;
            this.checkTeamAdboard.ImeMode = ImeMode.NoControl;
            this.checkTeamAdboard.Location = new Point(150, 89);
            this.checkTeamAdboard.Name = "checkTeamAdboard";
            this.checkTeamAdboard.Size = new Size(106, 17);
            this.checkTeamAdboard.TabIndex = 11;
            this.checkTeamAdboard.Text = "Linked Adboards";
            this.checkTeamAdboard.UseVisualStyleBackColor = true;
            this.checkTeamBall.AutoSize = true;
            this.checkTeamBall.Checked = true;
            this.checkTeamBall.CheckState = CheckState.Checked;
            this.checkTeamBall.ImeMode = ImeMode.NoControl;
            this.checkTeamBall.Location = new Point(150, 112);
            this.checkTeamBall.Name = "checkTeamBall";
            this.checkTeamBall.Size = new Size(78, 17);
            this.checkTeamBall.TabIndex = 10;
            this.checkTeamBall.Text = "Linked Ball";
            this.checkTeamBall.UseVisualStyleBackColor = true;
            this.checkTeamLinkedPlayers.AutoSize = true;
            this.checkTeamLinkedPlayers.Checked = true;
            this.checkTeamLinkedPlayers.CheckState = CheckState.Checked;
            this.checkTeamLinkedPlayers.ImeMode = ImeMode.NoControl;
            this.checkTeamLinkedPlayers.Location = new Point(150, 20);
            this.checkTeamLinkedPlayers.Name = "checkTeamLinkedPlayers";
            this.checkTeamLinkedPlayers.Size = new Size(95, 17);
            this.checkTeamLinkedPlayers.TabIndex = 8;
            this.checkTeamLinkedPlayers.Text = "Linked Players";
            this.checkTeamLinkedPlayers.UseVisualStyleBackColor = true;
            this.checkTeamKits.AutoSize = true;
            this.checkTeamKits.Checked = true;
            this.checkTeamKits.CheckState = CheckState.Checked;
            this.checkTeamKits.ImeMode = ImeMode.NoControl;
            this.checkTeamKits.Location = new Point(150, 43);
            this.checkTeamKits.Name = "checkTeamKits";
            this.checkTeamKits.Size = new Size(78, 17);
            this.checkTeamKits.TabIndex = 6;
            this.checkTeamKits.Text = "Linked Kits";
            this.checkTeamKits.UseVisualStyleBackColor = true;
            this.checkTeamFlags.AutoSize = true;
            this.checkTeamFlags.Checked = true;
            this.checkTeamFlags.CheckState = CheckState.Checked;
            this.checkTeamFlags.ImeMode = ImeMode.NoControl;
            this.checkTeamFlags.Location = new Point(20, 89);
            this.checkTeamFlags.Name = "checkTeamFlags";
            this.checkTeamFlags.Size = new Size(51, 17);
            this.checkTeamFlags.TabIndex = 5;
            this.checkTeamFlags.Text = "Flags";
            this.checkTeamFlags.UseVisualStyleBackColor = true;
            this.checkTeamGuiBanner.AutoSize = true;
            this.checkTeamGuiBanner.Checked = true;
            this.checkTeamGuiBanner.CheckState = CheckState.Checked;
            this.checkTeamGuiBanner.ImeMode = ImeMode.NoControl;
            this.checkTeamGuiBanner.Location = new Point(20, 66);
            this.checkTeamGuiBanner.Name = "checkTeamGuiBanner";
            this.checkTeamGuiBanner.Size = new Size(60, 17);
            this.checkTeamGuiBanner.TabIndex = 3;
            this.checkTeamGuiBanner.Text = "Banner";
            this.checkTeamGuiBanner.UseVisualStyleBackColor = true;
            this.checkTeamGuiLogo.AutoSize = true;
            this.checkTeamGuiLogo.Checked = true;
            this.checkTeamGuiLogo.CheckState = CheckState.Checked;
            this.checkTeamGuiLogo.ImeMode = ImeMode.NoControl;
            this.checkTeamGuiLogo.Location = new Point(20, 43);
            this.checkTeamGuiLogo.Name = "checkTeamGuiLogo";
            this.checkTeamGuiLogo.Size = new Size(55, 17);
            this.checkTeamGuiLogo.TabIndex = 2;
            this.checkTeamGuiLogo.Text = "Logos";
            this.checkTeamGuiLogo.UseVisualStyleBackColor = true;
            this.checkTeamDatabase.AutoSize = true;
            this.checkTeamDatabase.Checked = true;
            this.checkTeamDatabase.CheckState = CheckState.Checked;
            this.checkTeamDatabase.ImeMode = ImeMode.NoControl;
            this.checkTeamDatabase.Location = new Point(20, 20);
            this.checkTeamDatabase.Name = "checkTeamDatabase";
            this.checkTeamDatabase.Size = new Size(93, 17);
            this.checkTeamDatabase.TabIndex = 1;
            this.checkTeamDatabase.Text = "Database Info";
            this.checkTeamDatabase.UseVisualStyleBackColor = true;
            this.pageKitOptions.Controls.Add((Control)this.checkKitTextures);
            this.pageKitOptions.Controls.Add((Control)this.checkKitNameFonts);
            this.pageKitOptions.Controls.Add((Control)this.checkKitDatabase);
            this.pageKitOptions.Controls.Add((Control)this.checkKitNumbers);
            this.pageKitOptions.Controls.Add((Control)this.checkKitMinikits);
            this.pageKitOptions.Location = new Point(4, 44);
            this.pageKitOptions.Name = "pageKitOptions";
            this.pageKitOptions.Size = new Size(282, 191);
            this.pageKitOptions.TabIndex = 9;
            this.pageKitOptions.Text = "Kits";
            this.pageKitOptions.UseVisualStyleBackColor = true;
            this.checkKitTextures.AutoSize = true;
            this.checkKitTextures.Checked = true;
            this.checkKitTextures.CheckState = CheckState.Checked;
            this.checkKitTextures.ImeMode = ImeMode.NoControl;
            this.checkKitTextures.Location = new Point(20, 43);
            this.checkKitTextures.Name = "checkKitTextures";
            this.checkKitTextures.Size = new Size(82, 17);
            this.checkKitTextures.TabIndex = 13;
            this.checkKitTextures.Text = "Kit Textures";
            this.checkKitTextures.UseVisualStyleBackColor = true;
            this.checkKitNameFonts.AutoSize = true;
            this.checkKitNameFonts.Checked = true;
            this.checkKitNameFonts.CheckState = CheckState.Checked;
            this.checkKitNameFonts.ImeMode = ImeMode.NoControl;
            this.checkKitNameFonts.Location = new Point(150, 43);
            this.checkKitNameFonts.Name = "checkKitNameFonts";
            this.checkKitNameFonts.Size = new Size(113, 17);
            this.checkKitNameFonts.TabIndex = 12;
            this.checkKitNameFonts.Text = "Linked Name Font";
            this.checkKitNameFonts.UseVisualStyleBackColor = true;
            this.checkKitDatabase.AutoSize = true;
            this.checkKitDatabase.Checked = true;
            this.checkKitDatabase.CheckState = CheckState.Checked;
            this.checkKitDatabase.ImeMode = ImeMode.NoControl;
            this.checkKitDatabase.Location = new Point(20, 20);
            this.checkKitDatabase.Name = "checkKitDatabase";
            this.checkKitDatabase.Size = new Size(93, 17);
            this.checkKitDatabase.TabIndex = 11;
            this.checkKitDatabase.Text = "Database Info";
            this.checkKitDatabase.UseVisualStyleBackColor = true;
            this.checkKitNumbers.AutoSize = true;
            this.checkKitNumbers.Checked = true;
            this.checkKitNumbers.CheckState = CheckState.Checked;
            this.checkKitNumbers.ImeMode = ImeMode.NoControl;
            this.checkKitNumbers.Location = new Point(150, 20);
            this.checkKitNumbers.Name = "checkKitNumbers";
            this.checkKitNumbers.Size = new Size(103, 17);
            this.checkKitNumbers.TabIndex = 10;
            this.checkKitNumbers.Text = "Linked Numbers";
            this.checkKitNumbers.UseVisualStyleBackColor = true;
            this.checkKitMinikits.AutoSize = true;
            this.checkKitMinikits.Checked = true;
            this.checkKitMinikits.CheckState = CheckState.Checked;
            this.checkKitMinikits.ImeMode = ImeMode.NoControl;
            this.checkKitMinikits.Location = new Point(20, 66);
            this.checkKitMinikits.Name = "checkKitMinikits";
            this.checkKitMinikits.Size = new Size(61, 17);
            this.checkKitMinikits.TabIndex = 8;
            this.checkKitMinikits.Text = "Minikits";
            this.checkKitMinikits.UseVisualStyleBackColor = true;
            this.pagePlayerOptions.Controls.Add((Control)this.checkPlayerGloves);
            this.pagePlayerOptions.Controls.Add((Control)this.checkPlayerShoes);
            this.pagePlayerOptions.Controls.Add((Control)this.checkPlayerMiniface);
            this.pagePlayerOptions.Controls.Add((Control)this.checkPlayerHead);
            this.pagePlayerOptions.Controls.Add((Control)this.checkPlayerDatabase);
            this.pagePlayerOptions.Location = new Point(4, 44);
            this.pagePlayerOptions.Name = "pagePlayerOptions";
            this.pagePlayerOptions.Padding = new Padding(3);
            this.pagePlayerOptions.Size = new Size(282, 191);
            this.pagePlayerOptions.TabIndex = 0;
            this.pagePlayerOptions.Text = "Players";
            this.pagePlayerOptions.UseVisualStyleBackColor = true;
            this.checkPlayerGloves.AutoSize = true;
            this.checkPlayerGloves.Checked = true;
            this.checkPlayerGloves.CheckState = CheckState.Checked;
            this.checkPlayerGloves.ImeMode = ImeMode.NoControl;
            this.checkPlayerGloves.Location = new Point(150, 43);
            this.checkPlayerGloves.Name = "checkPlayerGloves";
            this.checkPlayerGloves.Size = new Size(94, 17);
            this.checkPlayerGloves.TabIndex = 4;
            this.checkPlayerGloves.Text = "Linked Gloves";
            this.checkPlayerGloves.UseVisualStyleBackColor = true;
            this.checkPlayerShoes.AutoSize = true;
            this.checkPlayerShoes.Checked = true;
            this.checkPlayerShoes.CheckState = CheckState.Checked;
            this.checkPlayerShoes.ImeMode = ImeMode.NoControl;
            this.checkPlayerShoes.Location = new Point(150, 20);
            this.checkPlayerShoes.Name = "checkPlayerShoes";
            this.checkPlayerShoes.Size = new Size(91, 17);
            this.checkPlayerShoes.TabIndex = 3;
            this.checkPlayerShoes.Text = "Linked Shoes";
            this.checkPlayerShoes.UseVisualStyleBackColor = true;
            this.checkPlayerMiniface.AutoSize = true;
            this.checkPlayerMiniface.Checked = true;
            this.checkPlayerMiniface.CheckState = CheckState.Checked;
            this.checkPlayerMiniface.ImeMode = ImeMode.NoControl;
            this.checkPlayerMiniface.Location = new Point(20, 66);
            this.checkPlayerMiniface.Name = "checkPlayerMiniface";
            this.checkPlayerMiniface.Size = new Size(72, 17);
            this.checkPlayerMiniface.TabIndex = 2;
            this.checkPlayerMiniface.Text = "Mini Face";
            this.checkPlayerMiniface.UseVisualStyleBackColor = true;
            this.checkPlayerHead.AutoSize = true;
            this.checkPlayerHead.Checked = true;
            this.checkPlayerHead.CheckState = CheckState.Checked;
            this.checkPlayerHead.ImeMode = ImeMode.NoControl;
            this.checkPlayerHead.Location = new Point(20, 43);
            this.checkPlayerHead.Name = "checkPlayerHead";
            this.checkPlayerHead.Size = new Size(93, 17);
            this.checkPlayerHead.TabIndex = 1;
            this.checkPlayerHead.Text = "Specific Head";
            this.checkPlayerHead.UseVisualStyleBackColor = true;
            this.checkPlayerDatabase.AutoSize = true;
            this.checkPlayerDatabase.Checked = true;
            this.checkPlayerDatabase.CheckState = CheckState.Checked;
            this.checkPlayerDatabase.ImeMode = ImeMode.NoControl;
            this.checkPlayerDatabase.Location = new Point(20, 20);
            this.checkPlayerDatabase.Name = "checkPlayerDatabase";
            this.checkPlayerDatabase.Size = new Size(93, 17);
            this.checkPlayerDatabase.TabIndex = 0;
            this.checkPlayerDatabase.Text = "Database Info";
            this.checkPlayerDatabase.UseVisualStyleBackColor = true;
            this.pageRefereeOptions.Controls.Add((Control)this.checkRefereeMiniFace);
            this.pageRefereeOptions.Controls.Add((Control)this.checkRefereeShoes);
            this.pageRefereeOptions.Controls.Add((Control)this.checkRefereeKits);
            this.pageRefereeOptions.Controls.Add((Control)this.checkRefereeDatabase);
            this.pageRefereeOptions.Location = new Point(4, 44);
            this.pageRefereeOptions.Name = "pageRefereeOptions";
            this.pageRefereeOptions.Size = new Size(282, 191);
            this.pageRefereeOptions.TabIndex = 5;
            this.pageRefereeOptions.Text = "Referees";
            this.pageRefereeOptions.UseVisualStyleBackColor = true;
            this.checkRefereeMiniFace.AutoSize = true;
            this.checkRefereeMiniFace.Checked = true;
            this.checkRefereeMiniFace.CheckState = CheckState.Checked;
            this.checkRefereeMiniFace.ImeMode = ImeMode.NoControl;
            this.checkRefereeMiniFace.Location = new Point(20, 43);
            this.checkRefereeMiniFace.Name = "checkRefereeMiniFace";
            this.checkRefereeMiniFace.Size = new Size(72, 17);
            this.checkRefereeMiniFace.TabIndex = 6;
            this.checkRefereeMiniFace.Text = "Mini Face";
            this.checkRefereeMiniFace.UseVisualStyleBackColor = true;
            this.checkRefereeShoes.AutoSize = true;
            this.checkRefereeShoes.Checked = true;
            this.checkRefereeShoes.CheckState = CheckState.Checked;
            this.checkRefereeShoes.ImeMode = ImeMode.NoControl;
            this.checkRefereeShoes.Location = new Point(150, 20);
            this.checkRefereeShoes.Name = "checkRefereeShoes";
            this.checkRefereeShoes.Size = new Size(91, 17);
            this.checkRefereeShoes.TabIndex = 5;
            this.checkRefereeShoes.Text = "Linked Shoes";
            this.checkRefereeShoes.UseVisualStyleBackColor = true;
            this.checkRefereeKits.AutoSize = true;
            this.checkRefereeKits.ForeColor = SystemColors.ControlText;
            this.checkRefereeKits.ImeMode = ImeMode.NoControl;
            this.checkRefereeKits.Location = new Point(20, 73);
            this.checkRefereeKits.Name = "checkRefereeKits";
            this.checkRefereeKits.Size = new Size(84, 17);
            this.checkRefereeKits.TabIndex = 4;
            this.checkRefereeKits.Text = "Referee Kits";
            this.checkRefereeKits.UseVisualStyleBackColor = true;
            this.checkRefereeKits.Visible = false;
            this.checkRefereeDatabase.AutoSize = true;
            this.checkRefereeDatabase.BackColor = Color.Transparent;
            this.checkRefereeDatabase.Checked = true;
            this.checkRefereeDatabase.CheckState = CheckState.Checked;
            this.checkRefereeDatabase.ForeColor = SystemColors.ControlText;
            this.checkRefereeDatabase.ImeMode = ImeMode.NoControl;
            this.checkRefereeDatabase.Location = new Point(20, 20);
            this.checkRefereeDatabase.Name = "checkRefereeDatabase";
            this.checkRefereeDatabase.Size = new Size(93, 17);
            this.checkRefereeDatabase.TabIndex = 2;
            this.checkRefereeDatabase.Text = "Database Info";
            this.checkRefereeDatabase.UseVisualStyleBackColor = false;
            this.pageStadiumOptions.Controls.Add((Control)this.checkStadiumMowingPattern);
            this.pageStadiumOptions.Controls.Add((Control)this.checkStadiumModel);
            this.pageStadiumOptions.Controls.Add((Control)this.checkStadiumPreview);
            this.pageStadiumOptions.Controls.Add((Control)this.checkStadiumDatabase);
            this.pageStadiumOptions.Controls.Add((Control)this.checkStadiumNet);
            this.pageStadiumOptions.Location = new Point(4, 44);
            this.pageStadiumOptions.Name = "pageStadiumOptions";
            this.pageStadiumOptions.Size = new Size(282, 191);
            this.pageStadiumOptions.TabIndex = 6;
            this.pageStadiumOptions.Text = "Stadiums";
            this.pageStadiumOptions.UseVisualStyleBackColor = true;
            this.checkStadiumMowingPattern.AutoSize = true;
            this.checkStadiumMowingPattern.Checked = true;
            this.checkStadiumMowingPattern.CheckState = CheckState.Checked;
            this.checkStadiumMowingPattern.ImeMode = ImeMode.NoControl;
            this.checkStadiumMowingPattern.Location = new Point(144, 43);
            this.checkStadiumMowingPattern.Name = "checkStadiumMowingPattern";
            this.checkStadiumMowingPattern.Size = new Size(135, 17);
            this.checkStadiumMowingPattern.TabIndex = 17;
            this.checkStadiumMowingPattern.Text = "Linked Mowing Pattern";
            this.checkStadiumMowingPattern.UseVisualStyleBackColor = true;
            this.checkStadiumModel.AutoSize = true;
            this.checkStadiumModel.Checked = true;
            this.checkStadiumModel.CheckState = CheckState.Checked;
            this.checkStadiumModel.ImeMode = ImeMode.NoControl;
            this.checkStadiumModel.Location = new Point(20, 43);
            this.checkStadiumModel.Name = "checkStadiumModel";
            this.checkStadiumModel.Size = new Size(77, 17);
            this.checkStadiumModel.TabIndex = 15;
            this.checkStadiumModel.Text = "3D Models";
            this.checkStadiumModel.UseVisualStyleBackColor = true;
            this.checkStadiumPreview.AutoSize = true;
            this.checkStadiumPreview.Checked = true;
            this.checkStadiumPreview.CheckState = CheckState.Checked;
            this.checkStadiumPreview.ImeMode = ImeMode.NoControl;
            this.checkStadiumPreview.Location = new Point(20, 66);
            this.checkStadiumPreview.Name = "checkStadiumPreview";
            this.checkStadiumPreview.Size = new Size(105, 17);
            this.checkStadiumPreview.TabIndex = 13;
            this.checkStadiumPreview.Text = "Preview Pictures";
            this.checkStadiumPreview.UseVisualStyleBackColor = true;
            this.checkStadiumDatabase.AutoSize = true;
            this.checkStadiumDatabase.Checked = true;
            this.checkStadiumDatabase.CheckState = CheckState.Checked;
            this.checkStadiumDatabase.ImeMode = ImeMode.NoControl;
            this.checkStadiumDatabase.Location = new Point(20, 20);
            this.checkStadiumDatabase.Name = "checkStadiumDatabase";
            this.checkStadiumDatabase.Size = new Size(93, 17);
            this.checkStadiumDatabase.TabIndex = 12;
            this.checkStadiumDatabase.Text = "Database Info";
            this.checkStadiumDatabase.UseVisualStyleBackColor = true;
            this.checkStadiumNet.AutoSize = true;
            this.checkStadiumNet.Checked = true;
            this.checkStadiumNet.CheckState = CheckState.Checked;
            this.checkStadiumNet.ImeMode = ImeMode.NoControl;
            this.checkStadiumNet.Location = new Point(144, 20);
            this.checkStadiumNet.Name = "checkStadiumNet";
            this.checkStadiumNet.Size = new Size(78, 17);
            this.checkStadiumNet.TabIndex = 10;
            this.checkStadiumNet.Text = "Linked Net";
            this.checkStadiumNet.UseVisualStyleBackColor = true;
            this.labelPatchType.Dock = DockStyle.Top;
            this.labelPatchType.ImeMode = ImeMode.NoControl;
            this.labelPatchType.Location = new Point(0, 0);
            this.labelPatchType.Name = "labelPatchType";
            this.labelPatchType.Size = new Size(296, 48);
            this.labelPatchType.TabIndex = 6;
            this.labelPatchType.Text = "Objects Selection";
            this.labelPatchType.TextAlign = ContentAlignment.TopCenter;
            this.mainMenuStrip.Items.AddRange(new ToolStripItem[1]
            {
        (ToolStripItem) this.patchToolStripMenuItem
            });
            this.mainMenuStrip.Location = new Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new Size(1028, 24);
            this.mainMenuStrip.TabIndex = 29;
            this.mainMenuStrip.Text = "menuStrip1";
            this.patchToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
            {
        (ToolStripItem) this.newPatchToolStripMenuItem,
        (ToolStripItem) this.createPatchToolStripMenuItem,
        (ToolStripItem) this.openPatchToolStripMenuItem,
        (ToolStripItem) this.exitToolStripMenuItem
            });
            this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
            this.patchToolStripMenuItem.Size = new Size(49, 20);
            this.patchToolStripMenuItem.Text = "Patch";
            this.newPatchToolStripMenuItem.Image = (Image)resources.GetObject("newPatchToolStripMenuItem.Image");
            this.newPatchToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
            this.newPatchToolStripMenuItem.Name = "newPatchToolStripMenuItem";
            this.newPatchToolStripMenuItem.Size = new Size(141, 22);
            this.newPatchToolStripMenuItem.Text = "New Patch";
            this.newPatchToolStripMenuItem.Click += new EventHandler(this.newPatchToolStripMenuItem_Click);
            this.createPatchToolStripMenuItem.Image = (Image)resources.GetObject("createPatchToolStripMenuItem.Image");
            this.createPatchToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
            this.createPatchToolStripMenuItem.Name = "createPatchToolStripMenuItem";
            this.createPatchToolStripMenuItem.Size = new Size(141, 22);
            this.createPatchToolStripMenuItem.Text = "Create Patch";
            this.createPatchToolStripMenuItem.Click += new EventHandler(this.createPatchToolStripMenuItem_Click);
            this.openPatchToolStripMenuItem.Image = (Image)resources.GetObject("openPatchToolStripMenuItem.Image");
            this.openPatchToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
            this.openPatchToolStripMenuItem.Name = "openPatchToolStripMenuItem";
            this.openPatchToolStripMenuItem.Size = new Size(141, 22);
            this.openPatchToolStripMenuItem.Text = "Open Patch";
            this.openPatchToolStripMenuItem.Click += new EventHandler(this.openPatchToolStripMenuItem_Click);
            this.exitToolStripMenuItem.Image = (Image)resources.GetObject("exitToolStripMenuItem.Image");
            this.exitToolStripMenuItem.ImageTransparentColor = Color.Fuchsia;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
            this.toolMain.GripStyle = ToolStripGripStyle.Hidden;
            this.toolMain.Items.AddRange(new ToolStripItem[4]
            {
        (ToolStripItem) this.buttonNewPatch,
        (ToolStripItem) this.buttonOpenPatch,
        (ToolStripItem) this.buttonCreatePatch,
        (ToolStripItem) this.buttonExit
            });
            this.toolMain.Location = new Point(0, 24);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new Size(1028, 25);
            this.toolMain.TabIndex = 30;
            this.toolMain.Text = "toolStrip2";
            this.buttonNewPatch.AutoSize = false;
            this.buttonNewPatch.Image = (Image)resources.GetObject("buttonNewPatch.Image");
            this.buttonNewPatch.ImageScaling = ToolStripItemImageScaling.None;
            this.buttonNewPatch.ImageTransparentColor = Color.Magenta;
            this.buttonNewPatch.Name = "buttonNewPatch";
            this.buttonNewPatch.Size = new Size(90, 22);
            this.buttonNewPatch.Text = "New";
            this.buttonNewPatch.TextAlign = ContentAlignment.MiddleRight;
            this.buttonNewPatch.Click += new EventHandler(this.buttonNewPatch_Click);
            this.buttonOpenPatch.AutoSize = false;
            this.buttonOpenPatch.Image = (Image)resources.GetObject("buttonOpenPatch.Image");
            this.buttonOpenPatch.ImageScaling = ToolStripItemImageScaling.None;
            this.buttonOpenPatch.ImageTransparentColor = Color.Magenta;
            this.buttonOpenPatch.Name = "buttonOpenPatch";
            this.buttonOpenPatch.Size = new Size(90, 22);
            this.buttonOpenPatch.Text = "Open";
            this.buttonOpenPatch.TextAlign = ContentAlignment.MiddleRight;
            this.buttonOpenPatch.Click += new EventHandler(this.buttonOpenPatch_Click);
            this.buttonCreatePatch.AutoSize = false;
            this.buttonCreatePatch.Image = (Image)resources.GetObject("buttonCreatePatch.Image");
            this.buttonCreatePatch.ImageScaling = ToolStripItemImageScaling.None;
            this.buttonCreatePatch.ImageTransparentColor = Color.Magenta;
            this.buttonCreatePatch.Name = "buttonCreatePatch";
            this.buttonCreatePatch.Size = new Size(90, 22);
            this.buttonCreatePatch.Text = "Create";
            this.buttonCreatePatch.TextAlign = ContentAlignment.MiddleRight;
            this.buttonCreatePatch.Click += new EventHandler(this.buttonCreatePatch_Click);
            this.buttonExit.AutoSize = false;
            this.buttonExit.Image = (Image)resources.GetObject("buttonExit.Image");
            this.buttonExit.ImageScaling = ToolStripItemImageScaling.None;
            this.buttonExit.ImageTransparentColor = Color.Magenta;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new Size(90, 22);
            this.buttonExit.Text = "Exit";
            this.buttonExit.TextAlign = ContentAlignment.MiddleRight;
            this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
            this.openFileDialog.FileName = "openFileDialog";
            this.m_PatchDataSet.DataSetName = "Patch";
            this.m_PatchDataSet.Locale = new CultureInfo("");
            this.m_PatchDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1028, 746);
            this.Controls.Add((Control)this.splitContainer1);
            this.Controls.Add((Control)this.panelLeft);
            this.Controls.Add((Control)this.toolMain);
            this.Controls.Add((Control)this.mainMenuStrip);
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "PatchCreatorForm";
            this.Text = " CM-Patch Creator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolAddRemove.ResumeLayout(false);
            this.toolAddRemove.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.groupPatchOptions.ResumeLayout(false);
            this.tabPatchOptions.ResumeLayout(false);
            this.pageGeneralOptions.ResumeLayout(false);
            this.pageGeneralOptions.PerformLayout();
            this.pageCountryOptions.ResumeLayout(false);
            this.pageCountryOptions.PerformLayout();
            this.pageLeagueOptions.ResumeLayout(false);
            this.pageLeagueOptions.PerformLayout();
            this.pageTeamOptions.ResumeLayout(false);
            this.pageTeamOptions.PerformLayout();
            this.pageKitOptions.ResumeLayout(false);
            this.pageKitOptions.PerformLayout();
            this.pagePlayerOptions.ResumeLayout(false);
            this.pagePlayerOptions.PerformLayout();
            this.pageRefereeOptions.ResumeLayout(false);
            this.pageRefereeOptions.PerformLayout();
            this.pageStadiumOptions.ResumeLayout(false);
            this.pageStadiumOptions.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.m_PatchDataSet.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public enum EPatchType
        {
            Country,
            League,
            Team,
            Player,
            Kit,
            Referee,
            Stadium,
            Formation,
            Ball,
            Adboard,
            NumberFont,
            NameFont,
            Shoes,
            GKGloves,
            Net,
            MowingPattern,
        }
    }
}
