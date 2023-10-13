// Original code created by Rinaldo

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
    public class FifaEnvironment
    {
        private static ToolStripStatusLabel m_Status = (ToolStripStatusLabel)null;
        private static string m_GameKey = (string)null;
        private static Language m_Language = (Language)null;
        private static bool m_NeedToSaveMiniHeads = false;
        private static CountryList s_CountryList = (CountryList)null;
        private static LeagueList s_LeagueList = (LeagueList)null;
        private static TeamList s_TeamList = (TeamList)null;
        private static FreeAgentList s_FreeAgentList = (FreeAgentList)null;
        private static PlayerList s_PlayerList = (PlayerList)null;
        private static PlayerNames s_OriginalPlayerNamesList = (PlayerNames)null;
        private static PlayerNames s_PlayerNamesList = (PlayerNames)null;
        private static NameDictionary s_NameDictionary = (NameDictionary)null;
        private static CareerFirstNameList s_CareerFirstNameList = (CareerFirstNameList)null;
        private static CareerLastNameList s_CareerLastNameList = (CareerLastNameList)null;
        private static CareerCommonNameList s_CareerCommonNameList = (CareerCommonNameList)null;
        private static StadiumList s_StadiumList = (StadiumList)null;
        private static RefereeList s_RefereeList = (RefereeList)null;
        private static KitList s_KitList = (KitList)null;
        private static CompobjList s_CompetitionObjects = (CompobjList)null;
        private static FormationList s_FormationList = (FormationList)null;
        private static FormationList s_GenericFormationList = (FormationList)null;
        private static RoleList s_RoleList = (RoleList)null;
        private static BallList s_BallList = (BallList)null;
        private static AdboardList s_AdboardList = (AdboardList)null;
        private static ShoesList s_ShoesList = (ShoesList)null;
        private static GkGlovesList s_GkGlovesList = (GkGlovesList)null;
        private static NetList s_NetList = (NetList)null;
        private static MowingPatternList s_MowingPatternList = (MowingPatternList)null;
        private static NumberFontList s_NumberFontList = (NumberFontList)null;
        private static NameFontList s_NameFontList = (NameFontList)null;
        private static FifaFat m_FifaFat;
        private static CareerFile m_CareerFile;
        private static string m_CareerFileName;
        private static CareerFile m_TournamentFile;
        private static string m_TournamentFileName;
        private static CareerFile m_MyTeamsFile;
        private static string m_MyTeamsFileName;
        private static DbFile m_OriginalFifaDb;
        private static DbFile m_FifaDb;
        private static string m_FifaDbFileName;
        private static string m_FifaXmlFileName;
        private static string m_FifaDbPartialFileName;
        private static string m_FifaXmlPartialFileName;
        private static int m_Year;
        private static DbFile m_LangDb;
        private static string m_LangDbFileName;
        private static string m_LangXmlFileName;
        private static string m_RootDir;
        private static string m_GameDir;
        private static string m_ExportFolder;
        private static string m_TempFolder;
        private static string m_LaunchDir;
        private static UserMessage m_UserMessages;
        private static UserOptions m_UserOptions;

        public static FifaFat FifaFat
        {
            get
            {
                return FifaEnvironment.m_FifaFat;
            }
        }

        public static CareerFile CareerFile
        {
            get
            {
                return FifaEnvironment.m_CareerFile;
            }
        }

        public static string CareerFileName
        {
            get
            {
                return FifaEnvironment.m_CareerFileName;
            }
            set
            {
                FifaEnvironment.m_CareerFileName = value;
            }
        }

        public static CareerFile TournamentFile
        {
            get
            {
                return FifaEnvironment.m_TournamentFile;
            }
        }

        public static string TournamentFileName
        {
            get
            {
                return FifaEnvironment.m_TournamentFileName;
            }
            set
            {
                FifaEnvironment.m_TournamentFileName = value;
            }
        }

        public static CareerFile MyTeamsFile
        {
            get
            {
                return FifaEnvironment.m_MyTeamsFile;
            }
        }

        public static string MyTeamsFileName
        {
            get
            {
                return FifaEnvironment.m_MyTeamsFileName;
            }
            set
            {
                FifaEnvironment.m_MyTeamsFileName = value;
            }
        }

        public static DbFile OriginalFifaDb
        {
            get
            {
                return FifaEnvironment.m_OriginalFifaDb;
            }
        }

        public static DbFile FifaDb
        {
            get
            {
                return FifaEnvironment.m_FifaDb;
            }
        }

        public static string FifaDbFileName
        {
            get
            {
                return FifaEnvironment.m_FifaDbFileName;
            }
            set
            {
                FifaEnvironment.m_FifaDbFileName = value;
            }
        }

        public static string FifaXmlFileName
        {
            get
            {
                return FifaEnvironment.m_FifaXmlFileName;
            }
            set
            {
                FifaEnvironment.m_FifaXmlFileName = value;
            }
        }

        public static string FifaDbPartialFileName
        {
            get
            {
                return FifaEnvironment.m_FifaDbPartialFileName;
            }
            set
            {
                FifaEnvironment.m_FifaDbPartialFileName = value;
            }
        }

        public static string FifaXmlPartialFileName
        {
            get
            {
                return FifaEnvironment.m_FifaXmlPartialFileName;
            }
            set
            {
                FifaEnvironment.m_FifaXmlPartialFileName = value;
            }
        }

        public static int Year
        {
            get
            {
                return FifaEnvironment.m_Year;
            }
            set
            {
                FifaEnvironment.m_Year = value;
            }
        }

        public static DbFile LangDb
        {
            get
            {
                return FifaEnvironment.m_LangDb;
            }
        }

        public static string LangDbFileName
        {
            get
            {
                return FifaEnvironment.m_LangDbFileName;
            }
            set
            {
                FifaEnvironment.m_LangDbFileName = value;
            }
        }

        public static string LangXmlFileName
        {
            get
            {
                return FifaEnvironment.m_LangXmlFileName;
            }
            set
            {
                FifaEnvironment.m_LangXmlFileName = value;
            }
        }

        public static Language Language
        {
            get
            {
                return FifaEnvironment.m_Language;
            }
        }

        public static string RootDir
        {
            get
            {
                return FifaEnvironment.m_RootDir;
            }
        }

        public static string GameDir
        {
            get
            {
                return FifaEnvironment.m_GameDir;
            }
        }

        public static string ExportFolder
        {
            get
            {
                return FifaEnvironment.m_ExportFolder;
            }
        }

        public static string TempFolder
        {
            get
            {
                return FifaEnvironment.m_TempFolder;
            }
        }

        public static string LaunchDir
        {
            get
            {
                return FifaEnvironment.m_LaunchDir;
            }
        }

        public static UserMessage UserMessages
        {
            get
            {
                return FifaEnvironment.m_UserMessages;
            }
        }

        public static UserOptions UserOptions
        {
            get
            {
                return FifaEnvironment.m_UserOptions;
            }
        }

        public static CountryList Countries
        {
            get
            {
                return FifaEnvironment.s_CountryList;
            }
        }

        public static LeagueList Leagues
        {
            get
            {
                return FifaEnvironment.s_LeagueList;
            }
        }

        public static TeamList Teams
        {
            get
            {
                return FifaEnvironment.s_TeamList;
            }
        }

        public static FreeAgentList FreeAgents
        {
            get
            {
                return FifaEnvironment.s_FreeAgentList;
            }
        }

        public static PlayerList Players
        {
            get
            {
                return FifaEnvironment.s_PlayerList;
            }
        }

        public static PlayerNames OriginalPlayerNamesList
        {
            get
            {
                return FifaEnvironment.s_OriginalPlayerNamesList;
            }
        }

        public static PlayerNames PlayerNamesList
        {
            get
            {
                return FifaEnvironment.s_PlayerNamesList;
            }
        }

        public static NameDictionary NameDictionary
        {
            get
            {
                return FifaEnvironment.s_NameDictionary;
            }
        }

        public static CareerFirstNameList CareerFirstNameList
        {
            get
            {
                return FifaEnvironment.s_CareerFirstNameList;
            }
        }

        public static CareerLastNameList CareerLastNameList
        {
            get
            {
                return FifaEnvironment.s_CareerLastNameList;
            }
        }

        public static CareerCommonNameList CareerCommonNameList
        {
            get
            {
                return FifaEnvironment.s_CareerCommonNameList;
            }
        }

        public static StadiumList Stadiums
        {
            get
            {
                return FifaEnvironment.s_StadiumList;
            }
        }

        public static RefereeList Referees
        {
            get
            {
                return FifaEnvironment.s_RefereeList;
            }
        }

        public static KitList Kits
        {
            get
            {
                return FifaEnvironment.s_KitList;
            }
        }

        public static CompobjList CompetitionObjects
        {
            get
            {
                return FifaEnvironment.s_CompetitionObjects;
            }
        }

        public static FormationList Formations
        {
            get
            {
                return FifaEnvironment.s_FormationList;
            }
        }

        public static FormationList GenericFormations
        {
            get
            {
                return FifaEnvironment.s_GenericFormationList;
            }
        }

        public static RoleList Roles
        {
            get
            {
                return FifaEnvironment.s_RoleList;
            }
        }

        public static BallList Balls
        {
            get
            {
                if (FifaEnvironment.s_BallList == null)
                    FifaEnvironment.s_BallList = new BallList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_BallList;
            }
        }

        public static AdboardList Adboards
        {
            get
            {
                if (FifaEnvironment.s_AdboardList == null)
                    FifaEnvironment.s_AdboardList = new AdboardList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_AdboardList;
            }
        }

        public static ShoesList Shoes
        {
            get
            {
                if (FifaEnvironment.s_ShoesList == null)
                    FifaEnvironment.s_ShoesList = new ShoesList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_ShoesList;
            }
        }

        public static GkGlovesList GkGloves
        {
            get
            {
                if (FifaEnvironment.s_GkGlovesList == null)
                    FifaEnvironment.s_GkGlovesList = new GkGlovesList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_GkGlovesList;
            }
        }

        public static NetList Nets
        {
            get
            {
                if (FifaEnvironment.s_NetList == null)
                    FifaEnvironment.s_NetList = new NetList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_NetList;
            }
        }

        public static MowingPatternList MowingPatterns
        {
            get
            {
                if (FifaEnvironment.s_MowingPatternList == null)
                    FifaEnvironment.s_MowingPatternList = new MowingPatternList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_MowingPatternList;
            }
        }

        public static NumberFontList NumberFonts
        {
            get
            {
                if (FifaEnvironment.s_NumberFontList == null)
                    FifaEnvironment.s_NumberFontList = new NumberFontList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_NumberFontList;
            }
        }

        public static NameFontList NameFonts
        {
            get
            {
                if (FifaEnvironment.s_NameFontList == null)
                    FifaEnvironment.s_NameFontList = new NameFontList(FifaEnvironment.m_FifaDb, FifaEnvironment.m_FifaFat);
                return FifaEnvironment.s_NameFontList;
            }
        }

        public static void InitializeLaunchFolder()
        {
            int num = Environment.CommandLine.IndexOf(".exe");
            for (int index = num; index >= 0; --index)
            {
                if (Environment.CommandLine[index] == '\\')
                {
                    num = index;
                    break;
                }
            }
            if (num < 0)
                return;
            FifaEnvironment.m_LaunchDir = Environment.CommandLine.Substring(1, num - 1);
        }

        public static bool InitializeDefault()
        {
            FifaEnvironment.InitializeLaunchFolder();
            return true;
        }

        public static bool Initialize14(string rootDir)
        {
            if (FifaEnvironment.m_UserMessages == null)
                FifaEnvironment.m_UserMessages = new UserMessage();
            if (FifaEnvironment.m_UserOptions == null)
                FifaEnvironment.m_UserOptions = new UserOptions();
            FifaEnvironment.m_FifaFat = (FifaFat)null;
            FifaEnvironment.m_FifaDb = (DbFile)null;
            FifaEnvironment.m_LangDb = (DbFile)null;
            FifaEnvironment.InitializeLaunchFolder();
            FifaEnvironment.m_Year = 14;
            FifaEnvironment.m_GameKey = RegistryInfo.GetFifaKey(FifaEnvironment.m_Year);
            if (rootDir == null)
            {
                if (!RegistryInfo.IsFifaInstalled(FifaEnvironment.m_GameKey))
                    return false;
                FifaEnvironment.m_RootDir = RegistryInfo.GetInstallDir(FifaEnvironment.m_GameKey);
            }
            else
                FifaEnvironment.m_RootDir = rootDir;
            FifaEnvironment.m_GameDir = FifaEnvironment.m_RootDir + "\\Game\\";
            FifaEnvironment.m_FifaDbPartialFileName = "data\\db\\fifa_ng_db.db";
            FifaEnvironment.m_FifaDbFileName = FifaEnvironment.m_GameDir + FifaEnvironment.m_FifaDbPartialFileName;
            FifaEnvironment.m_FifaXmlPartialFileName = "data\\db\\fifa_ng_db-meta.xml";
            FifaEnvironment.m_FifaXmlFileName = FifaEnvironment.m_GameDir + FifaEnvironment.m_FifaXmlPartialFileName;
            FifaEnvironment.m_LangDbFileName = FifaEnvironment.GetLanguageDbFilename(FifaEnvironment.m_GameKey);
            FifaEnvironment.m_LangXmlFileName = FifaEnvironment.GetLanguageXmlFilename(FifaEnvironment.m_GameKey);
            FifaEnvironment.m_TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            FifaEnvironment.m_TempFolder += "\\FM_temp";
            FifaEnvironment.m_ExportFolder = FifaEnvironment.m_UserOptions.m_AutoExportFolder ? FifaEnvironment.m_TempFolder : FifaEnvironment.m_UserOptions.m_ExportFolder;
            if (!Directory.Exists(FifaEnvironment.m_TempFolder))
                Directory.CreateDirectory(FifaEnvironment.m_TempFolder);
            if (!Directory.Exists(FifaEnvironment.m_ExportFolder))
                Directory.CreateDirectory(FifaEnvironment.m_TempFolder);
            FifaEnvironment.s_NameFontList = (NameFontList)null;
            FifaEnvironment.s_NumberFontList = (NumberFontList)null;
            FifaEnvironment.s_MowingPatternList = (MowingPatternList)null;
            FifaEnvironment.s_NetList = (NetList)null;
            FifaEnvironment.s_GkGlovesList = (GkGlovesList)null;
            FifaEnvironment.s_ShoesList = (ShoesList)null;
            FifaEnvironment.s_AdboardList = (AdboardList)null;
            FifaEnvironment.s_BallList = (BallList)null;
            FifaEnvironment.s_ShoesList = (ShoesList)null;
            return true;
        }

        public static bool Initialize15(string rootDir)
        {
            if (FifaEnvironment.m_UserMessages == null)
                FifaEnvironment.m_UserMessages = new UserMessage();
            if (FifaEnvironment.m_UserOptions == null)
                FifaEnvironment.m_UserOptions = new UserOptions();
            FifaEnvironment.m_FifaFat = (FifaFat)null;
            FifaEnvironment.m_FifaDb = (DbFile)null;
            FifaEnvironment.m_LangDb = (DbFile)null;
            FifaEnvironment.InitializeLaunchFolder();
            FifaEnvironment.m_Year = 15;
            FifaEnvironment.m_GameKey = RegistryInfo.GetFifaKey(FifaEnvironment.m_Year);
            if (rootDir == null)
            {
                if (!RegistryInfo.IsFifaInstalled(FifaEnvironment.m_GameKey))
                    return false;
                FifaEnvironment.m_RootDir = RegistryInfo.GetInstallDir(FifaEnvironment.m_GameKey);
            }
            else
                FifaEnvironment.m_RootDir = rootDir;
            FifaEnvironment.m_GameDir = FifaEnvironment.m_RootDir + "\\";
            FifaEnvironment.m_FifaDbPartialFileName = "data\\db\\fifa_ng_db.db";
            FifaEnvironment.m_FifaDbFileName = FifaEnvironment.m_GameDir + FifaEnvironment.m_FifaDbPartialFileName;
            FifaEnvironment.m_FifaXmlPartialFileName = "data\\db\\fifa_ng_db-meta.xml";
            FifaEnvironment.m_FifaXmlFileName = FifaEnvironment.m_GameDir + FifaEnvironment.m_FifaXmlPartialFileName;
            FifaEnvironment.m_LangDbFileName = FifaEnvironment.GetLanguageDbFilename(FifaEnvironment.m_GameKey);
            FifaEnvironment.m_LangXmlFileName = FifaEnvironment.GetLanguageXmlFilename(FifaEnvironment.m_GameKey);
            FifaEnvironment.m_TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            FifaEnvironment.m_TempFolder += "\\FM_temp";
            FifaEnvironment.m_ExportFolder = FifaEnvironment.m_UserOptions.m_AutoExportFolder ? FifaEnvironment.m_TempFolder : FifaEnvironment.m_UserOptions.m_ExportFolder;
            if (!Directory.Exists(FifaEnvironment.m_TempFolder))
                Directory.CreateDirectory(FifaEnvironment.m_TempFolder);
            if (!Directory.Exists(FifaEnvironment.m_ExportFolder))
                Directory.CreateDirectory(FifaEnvironment.m_TempFolder);
            FifaEnvironment.s_NameFontList = (NameFontList)null;
            FifaEnvironment.s_NumberFontList = (NumberFontList)null;
            FifaEnvironment.s_MowingPatternList = (MowingPatternList)null;
            FifaEnvironment.s_NetList = (NetList)null;
            FifaEnvironment.s_GkGlovesList = (GkGlovesList)null;
            FifaEnvironment.s_ShoesList = (ShoesList)null;
            FifaEnvironment.s_AdboardList = (AdboardList)null;
            FifaEnvironment.s_BallList = (BallList)null;
            FifaEnvironment.s_ShoesList = (ShoesList)null;
            return true;
        }

        public static bool Initialize17(string rootDir)
        {
            if (FifaEnvironment.m_UserMessages == null)
                FifaEnvironment.m_UserMessages = new UserMessage();
            if (FifaEnvironment.m_UserOptions == null)
                FifaEnvironment.m_UserOptions = new UserOptions();
            FifaEnvironment.m_FifaFat = (FifaFat)null;
            FifaEnvironment.m_FifaDb = (DbFile)null;
            FifaEnvironment.m_LangDb = (DbFile)null;
            FifaEnvironment.InitializeLaunchFolder();
            FifaEnvironment.m_Year = 17;
            FifaEnvironment.m_GameKey = RegistryInfo.GetFifaKey(FifaEnvironment.m_Year);
            if (rootDir == null)
            {
                if (!RegistryInfo.IsFifaInstalled(FifaEnvironment.m_GameKey))
                    return false;
                FifaEnvironment.m_RootDir = RegistryInfo.GetInstallDir(FifaEnvironment.m_GameKey);
            }
            else
                FifaEnvironment.m_RootDir = rootDir;
            FifaEnvironment.m_GameDir = FifaEnvironment.m_RootDir + "\\";
            FifaEnvironment.m_FifaDbPartialFileName = "data\\db\\fifa_ng_db.db";
            FifaEnvironment.m_FifaDbFileName = FifaEnvironment.m_GameDir + FifaEnvironment.m_FifaDbPartialFileName;
            FifaEnvironment.m_FifaXmlPartialFileName = "data\\db\\fifa_ng_db-meta.xml";
            FifaEnvironment.m_FifaXmlFileName = FifaEnvironment.m_GameDir + FifaEnvironment.m_FifaXmlPartialFileName;
            FifaEnvironment.m_LangDbFileName = FifaEnvironment.GetLanguageDbFilename(FifaEnvironment.m_GameKey);
            FifaEnvironment.m_LangXmlFileName = FifaEnvironment.GetLanguageXmlFilename(FifaEnvironment.m_GameKey);
            FifaEnvironment.m_TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            FifaEnvironment.m_TempFolder += "\\FM_temp";
            FifaEnvironment.m_ExportFolder = FifaEnvironment.m_UserOptions.m_AutoExportFolder ? FifaEnvironment.m_TempFolder : FifaEnvironment.m_UserOptions.m_ExportFolder;
            if (!Directory.Exists(FifaEnvironment.m_TempFolder))
                Directory.CreateDirectory(FifaEnvironment.m_TempFolder);
            if (!Directory.Exists(FifaEnvironment.m_ExportFolder))
                Directory.CreateDirectory(FifaEnvironment.m_TempFolder);
            FifaEnvironment.s_NameFontList = (NameFontList)null;
            FifaEnvironment.s_NumberFontList = (NumberFontList)null;
            FifaEnvironment.s_MowingPatternList = (MowingPatternList)null;
            FifaEnvironment.s_NetList = (NetList)null;
            FifaEnvironment.s_GkGlovesList = (GkGlovesList)null;
            FifaEnvironment.s_ShoesList = (ShoesList)null;
            FifaEnvironment.s_AdboardList = (AdboardList)null;
            FifaEnvironment.s_BallList = (BallList)null;
            FifaEnvironment.s_ShoesList = (ShoesList)null;
            return true;
        }

        public static bool Initialize(int year, string rootDir)
        {
            if (year == 14)
                return FifaEnvironment.Initialize14(rootDir);
            if (year == 15)
                return FifaEnvironment.Initialize15(rootDir);
            return year == 17 && FifaEnvironment.Initialize17(rootDir);
        }

        public static string GetLanguageDbFilename(string game)
        {
            return FifaEnvironment.m_GameDir + "data\\loc\\" + FifaEnvironment.ConvertLanguageToFileName(RegistryInfo.GetLocale(game)) + ".db";
        }

        public static string GetLanguageXmlFilename(string game)
        {
            return FifaEnvironment.m_GameDir + "data\\loc\\" + FifaEnvironment.ConvertLanguageToFileName(RegistryInfo.GetLocale(game)) + "-meta.xml";
        }

        private static string ConvertLanguageToFileName(string locale)
        {
            string str = "eng_us";
            if (locale != null && locale != string.Empty)
                str = !locale.StartsWith("it") ? (!locale.StartsWith("sa") ? (!locale.StartsWith("cz") ? (!locale.StartsWith("dk") ? (!locale.StartsWith("nl") ? (!locale.StartsWith("en") ? (!locale.StartsWith("fr") ? (!locale.StartsWith("de") ? (!locale.StartsWith("hu") ? (!locale.StartsWith("jp") ? (!locale.StartsWith("kr") ? (!locale.StartsWith("no") ? (!locale.StartsWith("pl") ? (!locale.StartsWith("pt") ? (!locale.StartsWith("br") ? (!locale.StartsWith("ru") ? (!locale.StartsWith("es") ? (!locale.StartsWith("mx") ? (!locale.StartsWith("se") ? "eng_us" : "swe_se") : "spa_mx") : "spa_es") : "rus_ru") : "por_br") : "por_pt") : "pol_pl") : "nor_no") : "kor_kr") : "jpn_jp") : "hun_hu") : "ger_de") : "fre_fr") : "eng_us") : "dut_nl") : "dan_dk") : "cze_cz") : "ara_sa") : "ita_it";
            return str;
        }

        public static string GetEnglishFilename(string game)
        {
            return FifaEnvironment.m_GameDir + "\\data\\loc\\eng_us.db";
        }

        public static string GetEnglishXmlFilename(string game)
        {
            return FifaEnvironment.m_GameDir + "\\data\\loc\\eng_us-meta.xml";
        }

        public static void Close()
        {
            if (FifaEnvironment.s_AdboardList != null)
                FifaEnvironment.s_AdboardList.Clear();
            if (FifaEnvironment.s_BallList != null)
                FifaEnvironment.s_BallList.Clear();
            if (FifaEnvironment.s_ShoesList != null)
                FifaEnvironment.s_ShoesList.Clear();
            if (FifaEnvironment.s_CountryList != null)
                FifaEnvironment.s_CountryList.Clear();
            if (FifaEnvironment.s_FormationList != null)
                FifaEnvironment.s_FormationList.Clear();
            if (FifaEnvironment.s_GenericFormationList != null)
                FifaEnvironment.s_GenericFormationList.Clear();
            if (FifaEnvironment.s_FreeAgentList != null)
                FifaEnvironment.s_FreeAgentList.Clear();
            if (FifaEnvironment.s_NumberFontList != null)
                FifaEnvironment.s_NumberFontList.Clear();
            if (FifaEnvironment.s_NameFontList != null)
                FifaEnvironment.s_NameFontList.Clear();
            if (FifaEnvironment.s_KitList != null)
                FifaEnvironment.s_KitList.Clear();
            if (FifaEnvironment.s_LeagueList != null)
                FifaEnvironment.s_LeagueList.Clear();
            if (FifaEnvironment.s_NetList != null)
                FifaEnvironment.s_NetList.Clear();
            if (FifaEnvironment.s_MowingPatternList != null)
                FifaEnvironment.s_MowingPatternList.Clear();
            if (FifaEnvironment.s_PlayerList != null)
                FifaEnvironment.s_PlayerList.Clear();
            if (FifaEnvironment.s_PlayerNamesList != null)
                FifaEnvironment.s_PlayerNamesList.Clear();
            if (FifaEnvironment.s_NameDictionary != null)
                FifaEnvironment.s_NameDictionary.Clear();
            if (FifaEnvironment.s_CareerFirstNameList != null)
                FifaEnvironment.s_CareerFirstNameList.Clear();
            if (FifaEnvironment.s_CareerLastNameList != null)
                FifaEnvironment.s_CareerLastNameList.Clear();
            if (FifaEnvironment.s_CareerCommonNameList != null)
                FifaEnvironment.s_CareerCommonNameList.Clear();
            if (FifaEnvironment.s_RefereeList != null)
                FifaEnvironment.s_RefereeList.Clear();
            if (FifaEnvironment.s_RoleList != null)
                FifaEnvironment.s_RoleList.Clear();
            if (FifaEnvironment.s_ShoesList != null)
                FifaEnvironment.s_ShoesList.Clear();
            if (FifaEnvironment.s_GkGlovesList != null)
                FifaEnvironment.s_GkGlovesList.Clear();
            if (FifaEnvironment.s_StadiumList != null)
                FifaEnvironment.s_StadiumList.Clear();
            if (FifaEnvironment.s_TeamList != null)
                FifaEnvironment.s_TeamList.Clear();
            if (FifaEnvironment.s_CompetitionObjects != null)
                FifaEnvironment.s_CompetitionObjects.Clear();
            FifaEnvironment.m_FifaDb = (DbFile)null;
            FifaEnvironment.m_CareerFile = (CareerFile)null;
            FifaEnvironment.m_FifaFat = (FifaFat)null;
            FifaEnvironment.m_LangDb = (DbFile)null;
        }

        public static bool Open(ToolStripStatusLabel statusBar)
        {
            FifaEnvironment.m_Status = statusBar;
            if (FifaEnvironment.m_FifaFat == null)
            {
                if (FifaEnvironment.m_Status != null)
                {
                    FifaEnvironment.m_Status.Text = "Opening data#.big files";
                    FifaEnvironment.m_Status.GetCurrentParent().Refresh();
                }
                if (!FifaEnvironment.OpenFat())
                    return false;
            }
            if (FifaEnvironment.m_FifaDb == null)
            {
                if (FifaEnvironment.m_Status != null)
                {
                    FifaEnvironment.m_Status.Text = "Opening main database";
                    FifaEnvironment.m_Status.GetCurrentParent().Refresh();
                }
                FifaEnvironment.ExtractMainDatabase();
                if (!FifaEnvironment.OpenFifaDb())
                    return false;
            }
            if (FifaEnvironment.m_LangDb == null)
            {
                if (FifaEnvironment.m_Status != null)
                {
                    FifaEnvironment.m_Status.Text = "Opening language database";
                    FifaEnvironment.m_Status.GetCurrentParent().Refresh();
                }
                FifaEnvironment.ExtractLangDatabase();
                if (!FifaEnvironment.OpenLangDb())
                    return false;
            }
            FifaEnvironment.m_OriginalFifaDb = FifaEnvironment.m_Year != 14 ?
                      new DbFile(FifaEnvironment.m_LaunchDir + "\\Templates\\" + FifaEnvironment.m_FifaDbPartialFileName,
                      FifaEnvironment.m_LaunchDir + "\\Templates\\" + FifaEnvironment.m_FifaXmlPartialFileName) :
                      new DbFile(FifaEnvironment.m_LaunchDir + "\\Templates\\2014\\" + FifaEnvironment.m_FifaDbPartialFileName,
                      FifaEnvironment.m_LaunchDir + "\\Templates\\2014\\" + FifaEnvironment.m_FifaXmlPartialFileName);
            FifaEnvironment.ExtractCompetitionFiles();
            if (FifaEnvironment.m_Status != null)
            {
                FifaEnvironment.m_Status.Text = "Loading...";
                FifaEnvironment.m_Status.GetCurrentParent().Refresh();
            }
            FifaEnvironment.LoadLists();

            if (FifaEnvironment.m_Status != null)
            {
                FifaEnvironment.m_Status.Text = "Ready";
                FifaEnvironment.m_Status.GetCurrentParent().Refresh();
            }
            return true;
        }

        public static bool Save(ToolStripStatusLabel statusBar)
        {
            FifaEnvironment.m_Status = statusBar;
            if (FifaEnvironment.m_Status != null)
            {
                FifaEnvironment.m_Status.Text = "Saving lists";
                FifaEnvironment.m_Status.GetCurrentParent().Refresh();
            }
            FifaEnvironment.SaveLists();
            if (FifaEnvironment.m_Status != null)
            {
                FifaEnvironment.m_Status.Text = "Saving main database";
                FifaEnvironment.m_Status.GetCurrentParent().Refresh();
            }
            FifaEnvironment.SaveFifaDb();
            if (FifaEnvironment.m_Status != null)
            {
                FifaEnvironment.m_Status.Text = "Saving language";
                FifaEnvironment.m_Status.GetCurrentParent().Refresh();
            }
            FifaEnvironment.SaveLangDb();
            if (FifaEnvironment.m_Status != null)
            {
                FifaEnvironment.m_Status.Text = "Saving big files";
                FifaEnvironment.m_Status.GetCurrentParent().Refresh();
            }
            //FifaEnvironment.m_FifaFat.Save();

            //Saving in FrostyEditor 1.0.6.2 format (fbproject)
            string selectedAssetPath = "Data\\ui\\imgAssets\\crest50x50\\dark\\I1667.DDS";
            string selectedAssetName = "I1667.DDS";
            byte[] bufferModAsset = null;

            //App.AssetManager.ModifyCustomAsset("legacy", selectedAssetName, bufferModAsset);

            return true;
        }

        public static bool OpenFat()
        {
            FifaEnvironment.m_FifaFat = (FifaFat)null;
            FifaEnvironment.m_FifaFat = FifaFat.Create(FifaEnvironment.m_GameDir);
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10003);
                return false;
            }
            FifaEnvironment.m_FifaFat.SaveOption = FifaFat.EFifaFatSaveOption.SaveOnCommand;
            FifaEnvironment.m_FifaFat.ResetDefaultZdata();
            return true;
        }

        public static bool ExtractMainDatabase()
        {
            if (FifaEnvironment.m_FifaFat == null)
                return false;
            bool flag1 = false;
            bool flag2 = false;
            switch (FifaEnvironment.m_Year)
            {
                case 14:
                    while (FifaEnvironment.m_FifaFat.IsArchivedFilePresent(FifaEnvironment.m_FifaDbPartialFileName))
                    {
                        if (!flag1)
                            flag1 = FifaEnvironment.m_FifaFat.ExtractFile(FifaEnvironment.m_FifaDbPartialFileName);
                        else
                            FifaEnvironment.m_FifaFat.HideFile(FifaEnvironment.m_FifaDbPartialFileName);
                    }
                    while (FifaEnvironment.m_FifaFat.IsArchivedFilePresent(FifaEnvironment.m_FifaXmlPartialFileName))
                    {
                        if (!flag2)
                            flag2 = FifaEnvironment.m_FifaFat.ExtractFile(FifaEnvironment.m_FifaXmlPartialFileName);
                        else
                            FifaEnvironment.m_FifaFat.HideFile(FifaEnvironment.m_FifaXmlPartialFileName);
                    }
                    break;
                case 15:
                    string directoryName = Path.GetDirectoryName(FifaEnvironment.m_FifaDbFileName);
                    if (!Directory.Exists(directoryName))
                        Directory.CreateDirectory(directoryName);
                    BhFile bhFile = FifaEnvironment.m_FifaFat.GetBhFile(17);
                    if (!File.Exists(FifaEnvironment.m_FifaDbFileName))
                        File.Copy(FifaEnvironment.m_LaunchDir + "\\Templates\\data\\db\\fifa_ng_db.db", FifaEnvironment.m_FifaDbFileName);
                    if (bhFile != null && !bhFile.IsHidden(47))
                        bhFile.Hide(47);
                    if (!File.Exists(FifaEnvironment.m_FifaXmlFileName))
                        File.Copy(FifaEnvironment.m_LaunchDir + "\\Templates\\data\\db\\fifa_ng_db-meta.xml", FifaEnvironment.m_FifaXmlFileName);
                    if (bhFile != null && !bhFile.IsHidden(48))
                    {
                        bhFile.Hide(48);
                        break;
                    }
                    break;
            }
            return flag1 && flag2;
        }

        public static bool ExtractLangDatabase()
        {
            string fileName = FifaEnvironment.m_GameDir + "data\\loc\\locale.big";
            string gameDir = FifaEnvironment.m_GameDir;
            FifaBigFile fifaBigFile = new FifaBigFile(fileName);
            string[] archivedFileNames1 = fifaBigFile.GetArchivedFileNames("*.db", true);
            string[] archivedFileNames2 = fifaBigFile.GetArchivedFileNames("*.xml", true);
            bool flag1 = fifaBigFile.Export(archivedFileNames1, gameDir);
            if (flag1)
                fifaBigFile.Delete(archivedFileNames1);
            bool flag2 = fifaBigFile.Export(archivedFileNames2, gameDir);
            if (flag2)
                fifaBigFile.Delete(archivedFileNames2);
            if (flag1 || flag2)
                fifaBigFile.Save();
            return flag1 || flag2;
        }

        public static bool ExtractCompetitionFiles()
        {
            if (FifaEnvironment.m_FifaFat == null)
                return false;
            string[] fileNames = CompobjList.GetFileNames();
            bool flag = false;
            for (int index = 0; index < fileNames.Length; ++index)
            {
                if (!File.Exists(FifaEnvironment.m_GameDir + fileNames[index]))
                {
                    FifaEnvironment.m_FifaFat.ExtractFile(fileNames[index]);
                    flag = true;
                }
                else
                    FifaEnvironment.m_FifaFat.HideFile(fileNames[index]);
            }
            return flag;
        }

        public static bool OpenFifaDb()
        {
            FifaEnvironment.m_FifaDb = (DbFile)null;
            if (FifaEnvironment.m_FifaDbFileName != null && FifaEnvironment.m_FifaXmlFileName != null && (File.Exists(FifaEnvironment.m_FifaDbFileName) && File.Exists(FifaEnvironment.m_FifaXmlFileName)))
                FifaEnvironment.m_FifaDb = new DbFile(FifaEnvironment.m_FifaDbFileName, FifaEnvironment.m_FifaXmlFileName);
            if (FifaEnvironment.m_FifaDb == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10000);
                return false;
            }
            if (FifaEnvironment.m_Year == 12)
            {
                TI.InitTIAsFIFA12(FifaEnvironment.m_FifaDb);
                FI.InitFIAsFIFA12();
            }
            if (FifaEnvironment.m_Year == 13)
            {
                TI.InitTIAsFIFA13(FifaEnvironment.m_FifaDb);
                FI.InitFIAsFIFA13();
            }
            if (FifaEnvironment.m_Year == 14)
            {
                TI.InitTIAsFIFA14(FifaEnvironment.m_FifaDb);
                FI.InitFI(FifaEnvironment.m_FifaDb);
            }
            if (FifaEnvironment.m_Year == 15)
            {
                TI.InitTIAsFIFA14(FifaEnvironment.m_FifaDb);
                FI.InitFI(FifaEnvironment.m_FifaDb);
            }
            if (FifaEnvironment.m_Year == 17)
            {
                TI.InitTIAsFIFA14(FifaEnvironment.m_FifaDb);
                FI.InitFI(FifaEnvironment.m_FifaDb);
            }
            return FifaEnvironment.m_FifaDb != null;
        }

        public static bool OpenLangDb()
        {
            FifaEnvironment.m_LangDb = (DbFile)null;
            if (FifaEnvironment.m_LangDbFileName != null && FifaEnvironment.m_LangXmlFileName != null && (File.Exists(FifaEnvironment.m_LangDbFileName) && File.Exists(FifaEnvironment.m_LangXmlFileName)))
                FifaEnvironment.m_LangDb = new DbFile(FifaEnvironment.m_LangDbFileName, FifaEnvironment.m_LangXmlFileName);
            if (FifaEnvironment.m_LangDb != null)
                FifaEnvironment.m_Language = new Language(FifaEnvironment.m_LangDb.Table[TI.lang]);
            return FifaEnvironment.m_LangDb != null;
        }

        public static void SaveFifaDb()
        {
            File.Copy(FifaEnvironment.m_FifaDbFileName, FifaEnvironment.m_FifaDbFileName + ".bak", true);
            FifaEnvironment.m_FifaDb.SaveDb(FifaEnvironment.m_FifaDbFileName);
            FifaEnvironment.m_FifaDb.SaveXml(FifaEnvironment.m_FifaXmlFileName);
        }

        public static void SaveLangDb()
        {
            File.Copy(FifaEnvironment.m_LangDbFileName, FifaEnvironment.m_LangDbFileName + ".bak", true);
            FifaEnvironment.m_Language.Save(FifaEnvironment.m_LangDb.Table[TI.lang]);
            FifaEnvironment.m_LangDb.SaveDb(FifaEnvironment.m_LangDbFileName);
        }

        public static Bitmap[] GetBitmaps(string[] pngFileNameList)
        {
            if (pngFileNameList == null)
                return null;

            Bitmap[] bmpFiles = new Bitmap[pngFileNameList.Length];

            for (int index = 0; index < pngFileNameList.Length; ++index)
            {
                try
                {
                    bmpFiles[index] = new Bitmap(FifaFat.GamePath + pngFileNameList[index]);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException("Texture not found: " + FifaFat.GamePath + pngFileNameList[index], e);
                }
            }

            return bmpFiles;
        }

        public static Rx3File GetRx3FromZdata(string rx3FileName, bool verbose)
        {
            if (FifaEnvironment.m_FifaFat == null)
                return (Rx3File)null;
            Rx3File rx3File = (Rx3File)null;
            FifaFile archivedFile = FifaEnvironment.m_FifaFat.GetArchivedFile(rx3FileName);
            if (archivedFile != null)
            {
                if (archivedFile.IsCompressed)
                    archivedFile.Decompress();
                BinaryReader reader = archivedFile.GetReader();
                rx3File = new Rx3File();
                rx3File.Load(reader);
                archivedFile.ReleaseReader(reader);
            }
            else
            {
                string path = FifaEnvironment.m_GameDir + rx3FileName;
                if (File.Exists(path))
                {
                    FifaFile fifaFile = new FifaFile(path, false);
                    if (fifaFile != null)
                    {
                        rx3File = new Rx3File();
                        rx3File.Load(fifaFile);
                    }
                }
            }
            if (rx3File != null || !verbose)
                return rx3File;
            int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(3000, rx3FileName, true);
            return (Rx3File)null;
        }

        public static Rx3File GetRx3FromZdata(string rx3FileName)
        {
            return FifaEnvironment.GetRx3FromZdata(rx3FileName, true);
        }

        public static KitFile GetKitFromZdata(string rx3FileName)
        {
            if (FifaEnvironment.m_FifaFat == null)
                return (KitFile)null;
            KitFile kitFile = (KitFile)null;
            FifaFile archivedFile = FifaEnvironment.m_FifaFat.GetArchivedFile(rx3FileName);
            if (archivedFile != null)
            {
                if (archivedFile.IsCompressed)
                    archivedFile.Decompress();
                BinaryReader reader = archivedFile.GetReader();
                kitFile = new KitFile();
                kitFile.Load(reader);
                archivedFile.ReleaseReader(reader);
            }
            else
            {
                string path = FifaEnvironment.m_GameDir + rx3FileName;
                if (File.Exists(path))
                {
                    FifaFile fifaFile = new FifaFile(path, false);
                    if (fifaFile != null)
                    {
                        kitFile = new KitFile();
                        kitFile.Load(fifaFile);
                    }
                }
            }
            if (kitFile != null)
                return kitFile;
            int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(3000, rx3FileName, true);
            return (KitFile)null;
        }

        public static bool IsFilePresent(string fileName)
        {
            return FifaEnvironment.m_FifaFat != null && (FifaEnvironment.m_FifaFat.IsArchivedFilePresent(fileName) || File.Exists(FifaEnvironment.m_GameDir + fileName));
        }

        public static Bitmap GetBmpFromRx3(string rx3FileName, int imageIndex)
        {
            Rx3File rx3FromZdata = FifaEnvironment.GetRx3FromZdata(rx3FileName);
            if (rx3FromZdata == null)
                return (Bitmap)null;
            return rx3FromZdata.Images.Length > imageIndex && imageIndex >= 0 ? rx3FromZdata.Images[imageIndex].GetBitmap() : (Bitmap)null;
        }

        public static Bitmap[] GetBmpsFromRx3(string FileNameList)
        {

            Rx3File rx3FromZdata = FifaEnvironment.GetRx3FromZdata(FileNameList);
            if (rx3FromZdata == null)
                return (Bitmap[])null;
            return rx3FromZdata.Images != null && rx3FromZdata.Images.Length > 0 ? rx3FromZdata.GetBitmaps() : (Bitmap[])null;
        }

        public static Bitmap[] GetBitmapsFromRx3File(string rx3FileName)
        {
            if (rx3FileName == null)
                return (Bitmap[])null;
            if (!File.Exists(rx3FileName))
                return (Bitmap[])null;
            Rx3File rx3File = new Rx3File();
            if (!rx3File.Load(rx3FileName))
                return (Bitmap[])null;
            return rx3File.Images.Length > 0 ? rx3File.GetBitmaps() : (Bitmap[])null;
        }

        public static Bitmap[] GetKitFromRx3(string rx3FileName, out float[] positions)
        {
            KitFile kitFromZdata = FifaEnvironment.GetKitFromZdata(rx3FileName);
            if (kitFromZdata == null)
            {
                positions = (float[])null;
                return (Bitmap[])null;
            }
            positions = kitFromZdata.Positions;
            return kitFromZdata.Images.Length > 0 ? kitFromZdata.GetBitmaps() : (Bitmap[])null;
        }

        public static Bitmap GetBmpFromRx3(string rx3FileName, bool verbose)
        {
            Rx3File rx3FromZdata = FifaEnvironment.GetRx3FromZdata(rx3FileName, verbose);
            if (rx3FromZdata == null)
                return (Bitmap)null;
            return rx3FromZdata.Images.Length > 0 ? rx3FromZdata.Images[0].GetBitmap() : (Bitmap)null;
        }

        public static Bitmap GetBmpFromRx3(string rx3FileName)
        {
            return FifaEnvironment.GetBmpFromRx3(rx3FileName, true);
        }

        public static Bitmap GetArtasset(string bigFileName)
        {
            FifaBigFile bigFromZdata = FifaEnvironment.GetBigFromZdata(bigFileName);
            if (bigFromZdata == null)
                return (Bitmap)null;
            FifaFile firstDds = bigFromZdata.GetFirstDds();
            return firstDds == null ? (Bitmap)null : new DdsFile(firstDds).GetBitmap();
        }

        public static Bitmap GetDdsArtasset(string ddsFileName)
        {
            FifaFile fileFromZdata = FifaEnvironment.GetFileFromZdata(ddsFileName);
            if (fileFromZdata == null)
                return (Bitmap)null;
            DdsFile ddsFile = new DdsFile(fileFromZdata);
            return fileFromZdata == null ? (Bitmap)null : ddsFile.GetBitmap();
        }

        public static Bitmap GetBitmapFromDdsFile(string ddsFileName)
        {
            if (ddsFileName == null)
                return (Bitmap)null;
            return !File.Exists(ddsFileName) ? (Bitmap)null : new DdsFile(ddsFileName).GetBitmap();
        }

        public static Bitmap GetBitmapFromBigFile(string bigFileName)
        {
            if (bigFileName == null)
                return (Bitmap)null;
            if (!File.Exists(bigFileName))
                return (Bitmap)null;
            FifaBigFile fifaBigFile = new FifaBigFile(bigFileName);
            if (fifaBigFile == null)
                return (Bitmap)null;
            FifaFile firstDds = fifaBigFile.GetFirstDds();
            return firstDds == null ? (Bitmap)null : new DdsFile(firstDds).GetBitmap();
        }

        public static Bitmap Get2dHead(string ddsFileName)
        {
            return FifaEnvironment.GetDdsArtasset(ddsFileName);
        }

        private static FifaBigFile GetBigFromZdata(string bigFileName)
        {
            if (FifaEnvironment.m_FifaFat == null)
                return (FifaBigFile)null;
            FifaBigFile fifaBigFile = (FifaBigFile)null;
            FifaFile archivedFile = FifaEnvironment.m_FifaFat.GetArchivedFile(bigFileName);
            if (archivedFile != null)
            {
                if (archivedFile.IsCompressed)
                    archivedFile.Decompress();
                fifaBigFile = new FifaBigFile(archivedFile);
            }
            else
            {
                string str = FifaEnvironment.m_GameDir + bigFileName;
                if (File.Exists(str))
                    fifaBigFile = new FifaBigFile(str);
            }
            if (fifaBigFile != null)
                return fifaBigFile;
            int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(3000, bigFileName, true);
            return (FifaBigFile)null;
        }

        public static bool SetArtasset(string templateBigName, string ddsName, int id, Bitmap bitmap)
        {
            string assetFromTemplate = FifaEnvironment.CreateAssetFromTemplate(templateBigName, ddsName, id, bitmap);
            if (assetFromTemplate == null)
                return false;
            FifaEnvironment.m_FifaFat.HideFile(assetFromTemplate);
            return true;
        }

        public static bool SetArtasset(
          string templateBigName,
          string ddsName,
          int[] ids,
          Bitmap bitmap)
        {
            string assetFromTemplate = FifaEnvironment.CreateAssetFromTemplate(templateBigName, ddsName, ids, bitmap);
            if (assetFromTemplate == null)
                return false;
            FifaEnvironment.m_FifaFat.HideFile(assetFromTemplate);
            return true;
        }

        public static bool SetArtasset(
          string templateBigName,
          string ddsName,
          int[] ids,
          Bitmap bitmap,
          string[] format)
        {
            string assetFromTemplate = FifaEnvironment.CreateAssetFromTemplate(templateBigName, ddsName, ids, bitmap, format);
            if (assetFromTemplate == null)
                return false;
            FifaEnvironment.m_FifaFat.HideFile(assetFromTemplate);
            return true;
        }

        public static bool SetDdsArtasset(string templateDdsName, int id, Bitmap bitmap)
        {
            if (bitmap == null)
                return false;
            string assetFromTemplate = FifaEnvironment.CreateDdsAssetFromTemplate(templateDdsName, id, bitmap);
            if (assetFromTemplate == null)
                return false;
            FifaEnvironment.m_FifaFat.HideFile(assetFromTemplate);
            return true;
        }

        public static bool SetDdsArtasset(
          string templateDdsName,
          int[] ids,
          Bitmap bitmap,
          string[] format)
        {
            string assetFromTemplate = FifaEnvironment.CreateDdsAssetFromTemplate(templateDdsName, ids, bitmap, format);
            if (assetFromTemplate == null)
                return false;
            FifaEnvironment.m_FifaFat.HideFile(assetFromTemplate);
            return true;
        }

        public static bool Set2dHead(string templateDdsName, int id, Bitmap bitmap)
        {
            return FifaEnvironment.SetDdsArtasset(templateDdsName, id, bitmap);
        }

        public static bool Delete2dHead(string fileName)
        {
            return FifaEnvironment.DeleteFromZdata(fileName);
        }

        private static string CreateAssetFromTemplate(
          string templateBigName,
          string ddsName,
          int id,
          Bitmap bitmap)
        {
            string format = (string)null;
            Path.GetDirectoryName(templateBigName);
            string newBigFileName = templateBigName.Replace("#", id.ToString(format)).Replace("2014_", "");
            return FifaEnvironment.CreateAssetFromTemplate(templateBigName, ddsName, newBigFileName, bitmap);
        }

        private static string CreateAssetFromTemplate(
          string templateBigName,
          string ddsName,
          int[] ids,
          Bitmap bitmap)
        {
            string format = (string)null;
            Path.GetDirectoryName(templateBigName);
            string newBigFileName = templateBigName.Replace("#", ids[0].ToString(format)).Replace("%", ids[1].ToString(format));
            return FifaEnvironment.CreateAssetFromTemplate(templateBigName, ddsName, newBigFileName, bitmap);
        }

        private static string CreateAssetFromTemplate(
          string templateBigName,
          string ddsName,
          int[] ids,
          Bitmap bitmap,
          string[] format)
        {
            Path.GetDirectoryName(templateBigName);
            string newBigFileName = templateBigName.Replace("#", ids[0].ToString(format[0])).Replace("%", ids[1].ToString(format[1]));
            return FifaEnvironment.CreateAssetFromTemplate(templateBigName, ddsName, newBigFileName, bitmap);
        }

        private static string CreateAssetFromTemplate(
          string templateBigName,
          string ddsName,
          string newBigFileName,
          Bitmap bitmap)
        {
            string directoryName = Path.GetDirectoryName(templateBigName);
            string str1 = FifaEnvironment.m_LaunchDir + "\\Templates\\" + templateBigName;
            string str2 = FifaEnvironment.m_LaunchDir + "\\Templates\\" + newBigFileName;
            if (!File.Exists(str1))
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5026);
                return (string)null;
            }
            File.Copy(str1, str2, true);
            FifaBigFile fifaBigFile = new FifaBigFile(str2);
            if (fifaBigFile == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5027);
                return (string)null;
            }
            fifaBigFile.LoadArchivedFiles();
            FifaFile archivedFile = fifaBigFile.GetArchivedFile(ddsName, true);
            if (archivedFile == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5027);
                return (string)null;
            }
            if (archivedFile.IsCompressed)
                archivedFile.Decompress();
            DdsFile ddsFile = new DdsFile(archivedFile);
            if (ddsFile == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5027);
                return (string)null;
            }
            ddsFile.ReplaceBitmap(bitmap);
            BinaryWriter writer = archivedFile.GetWriter();
            if (writer == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5027);
                return (string)null;
            }
            ddsFile.Save(writer);
            archivedFile.ReleaseWriter(writer);
            fifaBigFile.Save();
            string path = FifaEnvironment.m_GameDir + directoryName + "\\";
            string destFileName = path + Path.GetFileName(newBigFileName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(str2, destFileName, true);
            if (!str2.Contains("#"))
                File.Delete(str2);
            return newBigFileName;
        }

        private static string CreateMultipleAssetFromTemplate(
          string templateBigName,
          string[] ddsNames,
          string newBigFileName,
          Bitmap[] bitmaps)
        {
            if (ddsNames.Length != bitmaps.Length)
                return (string)null;
            string directoryName = Path.GetDirectoryName(templateBigName);
            string str1 = FifaEnvironment.m_LaunchDir + "\\Templates\\" + templateBigName;
            string str2 = FifaEnvironment.m_LaunchDir + "\\Templates\\" + newBigFileName;
            if (!File.Exists(str1))
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5026);
                return (string)null;
            }
            File.Copy(str1, str2, true);
            FifaBigFile fifaBigFile = new FifaBigFile(str2);
            if (fifaBigFile == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5027);
                return (string)null;
            }
            fifaBigFile.LoadArchivedFiles();
            for (int index = 0; index < ddsNames.Length; ++index)
            {
                FifaFile archivedFile = fifaBigFile.GetArchivedFile(ddsNames[index], true);
                if (archivedFile != null)
                {
                    if (archivedFile.IsCompressed)
                        archivedFile.Decompress();
                    DdsFile ddsFile = new DdsFile(archivedFile);
                    if (ddsFile != null)
                    {
                        ddsFile.ReplaceBitmap(bitmaps[index]);
                        BinaryWriter writer = archivedFile.GetWriter();
                        if (writer != null)
                        {
                            ddsFile.Save(writer);
                            archivedFile.ReleaseWriter(writer);
                        }
                    }
                }
            }
            fifaBigFile.Save();
            string path = FifaEnvironment.m_GameDir + directoryName + "\\";
            string destFileName = path + Path.GetFileName(newBigFileName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(str2, destFileName, true);
            if (!str2.Contains("#"))
                File.Delete(str2);
            return newBigFileName;
        }

        private static string CreateDdsAssetFromTemplate(string templateDdsName, int id, Bitmap bitmap)
        {
            Path.GetDirectoryName(templateDdsName);
            string newDdsFileName = templateDdsName.Replace("#", id.ToString());
            return FifaEnvironment.CreateDdsAssetFromTemplate(templateDdsName, newDdsFileName, bitmap);
        }

        private static string CreateDdsAssetFromTemplate(
          string templateDdsName,
          int id,
          Bitmap bitmap,
          string[] format)
        {
            int[] ids = new int[2] { id, 0 };
            return FifaEnvironment.CreateDdsAssetFromTemplate(templateDdsName, ids, bitmap, format);
        }

        private static string CreateDdsAssetFromTemplate(
          string templateDdsName,
          int[] ids,
          Bitmap bitmap,
          string[] format)
        {
            Path.GetDirectoryName(templateDdsName);
            string newDdsFileName = templateDdsName.Replace("2014_", "").Replace("#", ids[0].ToString(format[0]));
            if (ids.Length >= 2)
                newDdsFileName = newDdsFileName.Replace("%", ids[1].ToString(format[1]));
            if (ids.Length >= 3)
                newDdsFileName = newDdsFileName.Replace("@", ids[2].ToString(format[2]));
            return FifaEnvironment.CreateDdsAssetFromTemplate(templateDdsName, newDdsFileName, bitmap);
        }

        private static string CreateDdsAssetFromTemplate(
          string templateDdsName,
          string newDdsFileName,
          Bitmap bitmap)
        {
            if (bitmap == null)
                return (string)null;
            string directoryName = Path.GetDirectoryName(templateDdsName);
            string str1 = FifaEnvironment.m_LaunchDir + "\\Templates\\" + templateDdsName;
            string str2 = FifaEnvironment.m_LaunchDir + "\\Templates\\" + newDdsFileName;
            if (!File.Exists(str1))
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5026);
                return (string)null;
            }
            File.Copy(str1, str2, true);
            DdsFile ddsFile = new DdsFile(str2);
            if (ddsFile == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5027);
                return (string)null;
            }
            ddsFile.ReplaceBitmap(bitmap);
            ddsFile.Save(str2);
            string path = FifaEnvironment.m_GameDir + directoryName + "\\";
            string destFileName = path + Path.GetFileName(newDdsFileName);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(str2, destFileName, true);
            if (!str2.Contains("#"))
                File.Delete(str2);
            return newDdsFileName;
        }

        public static bool IsPatched(string fileName)
        {
            return File.Exists(FifaEnvironment.m_GameDir + fileName);
        }

        public static FifaFile GetFileFromZdata(string fileName)
        {
            if (FifaEnvironment.m_FifaFat == null || fileName == null)
                return (FifaFile)null;
            FifaFile archivedFile = FifaEnvironment.m_FifaFat.GetArchivedFile(fileName);
            if (archivedFile != null)
                return archivedFile;
            string path = FifaEnvironment.m_GameDir + fileName;
            return File.Exists(path) ? new FifaFile(path, false) : (FifaFile)null;
        }

        public static bool ExportFileFromZdata(string fileName, string path)
        {
            if (FifaEnvironment.m_FifaFat == null || fileName == null)
                return false;
            bool flag = FifaEnvironment.m_FifaFat.ExportFile(fileName, path);
            if (flag)
                return true;
            string str1 = FifaEnvironment.m_GameDir + fileName;
            string str2 = path + "\\" + fileName;
            if (File.Exists(str1) && str1 != str2)
            {
                string directoryName = Path.GetDirectoryName(str2);
                if (!Directory.Exists(directoryName))
                    Directory.CreateDirectory(directoryName);
                File.Copy(str1, str2, true);
                return true;
            }
            int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(1028, " " + fileName, true);
            return flag;
        }

        public static bool ExportTtfFromZdata(string fileName, string path)
        {
            if (FifaEnvironment.m_FifaFat == null || fileName == null)
                return false;
            string str = FifaEnvironment.m_GameDir + fileName;
            string destFileName = path + "\\" + fileName;
            if (File.Exists(str))
            {
                if (str != destFileName)
                    File.Copy(str, destFileName, true);
                return true;
            }
            int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(1028, " " + fileName, true);
            return false;
        }

        public static bool AskAndExportFromZdata(string fileName, ref string path)
        {
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                return false;
            }
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = path;
            folderBrowserDialog.Description = "Select the export folder";
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
            {
                folderBrowserDialog.Dispose();
                return false;
            }
            path = folderBrowserDialog.SelectedPath;
            folderBrowserDialog.Dispose();
            return FifaEnvironment.ExportFileFromZdata(fileName, path);
        }

        public static bool ImportKitIntoZdata(
          string templateRx3Name,
          int[] ids,
          Bitmap[] bitmaps,
          float[] kitPositions)
        {
            if (templateRx3Name == null)
                return false;
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                return false;
            }
            string sourceFileName = FifaEnvironment.m_LaunchDir + "\\Templates\\" + templateRx3Name;
            string str1 = templateRx3Name;
            string str2 = sourceFileName;
            if (str2.Contains("2014_"))
            {
                str1 = str1.Replace("2014_", "");
                str2 = str2.Replace("2014_", "");
            }
            if (ids.Length > 0)
            {
                str1 = str1.Replace("#", ids[0].ToString());
                str2 = str2.Replace("#", ids[0].ToString());
            }
            if (ids.Length > 1)
            {
                str1 = str1.Replace("%", ids[1].ToString());
                str2 = str2.Replace("%", ids[1].ToString());
            }
            string archivedName;
            string str3;
            if (ids.Length > 2)
            {
                archivedName = str1.Replace("@", ids[2].ToString());
                str3 = str2.Replace("@", ids[2].ToString());
            }
            else
            {
                archivedName = str1.Replace("@", "0");
                str3 = str2.Replace("@", "0");
            }
            if (sourceFileName != str3)
                File.Copy(sourceFileName, str3, true);
            KitFile kitFile = new KitFile();
            kitFile.Load(str3);
            if (kitFile.Images.Length != bitmaps.Length)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5025);
                return false;
            }
            kitFile.ReplaceBitmaps(bitmaps);
            kitFile.Positions = kitPositions;
            kitFile.Save(str3, true, false);
            bool flag = FifaEnvironment.ImportFileIntoZdataAs(str3, archivedName, true, ECompressionMode.Chunkzip);
            if (!flag)
            {
                int num1 = (int)FifaEnvironment.m_UserMessages.ShowMessage(10007);
            }
            return flag;
        }

        public static bool ImportBmpsIntoStadium(string stadiumRx3Name, Bitmap[] bitmaps)
        {
            if (stadiumRx3Name == null)
                return false;
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                return false;
            }
            string str = FifaEnvironment.m_GameDir + stadiumRx3Name;
            if (!File.Exists(str) && !FifaEnvironment.m_FifaFat.ExtractFile(stadiumRx3Name))
                return false;
            Rx3File rx3File = new Rx3File();
            rx3File.Load(str);
            if (rx3File.Images.Length != bitmaps.Length)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5025);
                return false;
            }
            rx3File.ReplaceBitmaps(bitmaps);
            rx3File.Save(str, true, false);
            return true;
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          string rx3FileName,
          Bitmap[] bitmaps,
          ECompressionMode compressionMode,
          Rx3Signatures signatures)
        {
            if (templateRx3Name == null)
                return false;
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                return false;
            }
            string sourceFileName = FifaEnvironment.m_LaunchDir + "\\Templates\\" + templateRx3Name;
            string str = FifaEnvironment.m_LaunchDir + "\\Templates\\" + rx3FileName;
            if (sourceFileName != str)
                File.Copy(sourceFileName, str, true);
            Rx3File rx3File = new Rx3File();
            rx3File.Load(str);
            rx3File.ReplaceBitmaps(bitmaps);
            rx3File.Signatures = signatures;
            rx3File.Save(str, true, false);
            bool flag = FifaEnvironment.ImportFileIntoZdataAs(str, rx3FileName, true, compressionMode);
            if (!flag)
            {
                int num1 = (int)FifaEnvironment.m_UserMessages.ShowMessage(10007);
            }
            return flag;
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int[] ids,
          Bitmap[] bitmaps,
          ECompressionMode compressionMode,
          Rx3Signatures signatures)
        {
            if (templateRx3Name == null)
                return false;
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                return false;
            }
            string sourceFileName = FifaEnvironment.m_LaunchDir + "\\Templates\\" + templateRx3Name;
            string archivedName = templateRx3Name;
            string str = sourceFileName;
            if (str.Contains("2014_"))
            {
                archivedName = archivedName.Replace("2014_", "");
                str = str.Replace("2014_", "");
            }
            if (ids.Length > 0)
            {
                archivedName = archivedName.Replace("#", ids[0].ToString());
                str = str.Replace("#", ids[0].ToString());
            }
            if (ids.Length > 1)
            {
                archivedName = archivedName.Replace("%", ids[1].ToString());
                str = str.Replace("%", ids[1].ToString());
            }
            if (sourceFileName != str)
                File.Copy(sourceFileName, str, true);
            Rx3File rx3File = new Rx3File();
            rx3File.Load(str);
            if (rx3File.Images.Length != bitmaps.Length)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5025);
                return false;
            }
            rx3File.ReplaceBitmaps(bitmaps);
            rx3File.Signatures = signatures;
            rx3File.Save(str, true, false);
            bool flag = FifaEnvironment.ImportFileIntoZdataAs(str, archivedName, true, compressionMode);
            if (!flag)
            {
                int num1 = (int)FifaEnvironment.m_UserMessages.ShowMessage(10007);
            }
            return flag;
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int[] ids,
          Bitmap[] bitmaps,
          ECompressionMode compressionMode)
        {
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, (Rx3Signatures)null);
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int id,
          Bitmap bitmap,
          ECompressionMode compressionMode)
        {
            Bitmap[] bitmaps = new Bitmap[1] { bitmap };
            int[] ids = new int[1] { id };
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, (Rx3Signatures)null);
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int id,
          Bitmap bitmap,
          ECompressionMode compressionMode,
          Rx3Signatures signatures)
        {
            Bitmap[] bitmaps = new Bitmap[1] { bitmap };
            int[] ids = new int[1] { id };
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, signatures);
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int id,
          Bitmap[] bitmaps,
          ECompressionMode compressionMode)
        {
            int[] ids = new int[1] { id };
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, (Rx3Signatures)null);
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int id,
          Bitmap[] bitmaps,
          ECompressionMode compressionMode,
          Rx3Signatures signatures)
        {
            int[] ids = new int[1] { id };
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, signatures);
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int[] ids,
          Bitmap bitmap,
          ECompressionMode compressionMode)
        {
            Bitmap[] bitmaps = new Bitmap[1] { bitmap };
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, (Rx3Signatures)null);
        }

        public static bool ImportBmpsIntoZdata(
          string templateRx3Name,
          int[] ids,
          Bitmap bitmap,
          ECompressionMode compressionMode,
          Rx3Signatures signatures)
        {
            Bitmap[] bitmaps = new Bitmap[1] { bitmap };
            return FifaEnvironment.ImportBmpsIntoZdata(templateRx3Name, ids, bitmaps, compressionMode, signatures);
        }

        public static bool ImportFileIntoZdataAs(
          string fileName,
          string archivedName,
          bool delete,
          ECompressionMode compressionMode)
        {
            return FifaEnvironment.ImportFileIntoZdataAs(fileName, archivedName, delete, compressionMode, (Rx3Signatures)null);
        }

        public static bool ImportFileIntoZdataAs(
          string fileName,
          string archivedName,
          bool delete,
          ECompressionMode compressionMode,
          Rx3Signatures signatures)
        {
            delete = delete && !fileName.Contains("#");
            archivedName = archivedName.Replace('\\', '/');
            if (fileName == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10010);
                return false;
            }
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                if (delete)
                    File.Delete(fileName);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                if (delete)
                    File.Delete(fileName);
                return false;
            }
            if (!File.Exists(fileName))
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10011);
                return false;
            }
            if (!FifaEnvironment.m_UserOptions.m_SaveZdataInFolder)
                return FifaEnvironment.m_FifaFat.ImportFileAs(fileName, archivedName, delete, compressionMode);
            string str = FifaEnvironment.m_GameDir + archivedName;
            string directoryName = Path.GetDirectoryName(str);
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            File.Copy(fileName, str, true);
            if (signatures != null)
            {
                FileStream fileStream = new FileStream(str, FileMode.Open, FileAccess.ReadWrite);
                BinaryWriter w = new BinaryWriter((Stream)fileStream);
                signatures.Save(w);
                w.Close();
                fileStream.Close();
            }
            if (delete)
                File.Delete(fileName);
            FifaEnvironment.m_FifaFat.HideFile(archivedName);
            return true;
        }

        public static bool ImportTtfIntoZdataAs(string fileName, string archivedName, bool delete)
        {
            delete = delete && !fileName.Contains("#");
            archivedName = archivedName.Replace('\\', '/');
            if (fileName == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10010);
                return false;
            }
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                if (delete)
                    File.Delete(fileName);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                if (delete)
                    File.Delete(fileName);
                return false;
            }
            if (!File.Exists(fileName))
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10011);
                return false;
            }
            if (!FifaEnvironment.m_UserOptions.m_SaveZdataInFolder)
                return false;
            string str = FifaEnvironment.m_GameDir + archivedName;
            string directoryName = Path.GetDirectoryName(str);
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
            File.Copy(fileName, str, true);
            if (delete)
                File.Delete(fileName);
            FifaEnvironment.m_FifaFat.HideFile(archivedName);
            return true;
        }

        public static bool DeleteFromZdata(string fileName)
        {
            if (fileName == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10010);
                return false;
            }
            if (!FifaEnvironment.m_UserOptions.m_SaveZdata)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5035);
                return false;
            }
            if (FifaEnvironment.m_FifaFat == null)
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10002);
                return false;
            }
            string path = FifaEnvironment.m_GameDir + fileName;
            if (!File.Exists(path))
                return FifaEnvironment.m_FifaFat.HideFile(fileName);
            File.Delete(path);
            FifaEnvironment.m_FifaFat.RestoreFile(fileName);
            return true;
        }

        public static bool CloneIntoZdata(string srcFileName, string destFileName)
        {
            string str1 = FifaEnvironment.m_TempFolder + "\\";
            if (!FifaEnvironment.ExportFileFromZdata(srcFileName, FifaEnvironment.m_TempFolder))
                return false;
            string str2 = str1 + srcFileName;
            if (!File.Exists(str2))
                return false;
            ECompressionMode compressionMode = FifaEnvironment.m_FifaFat.GetCompressionMode(srcFileName);
            return FifaEnvironment.ImportFileIntoZdataAs(str2, destFileName, true, compressionMode);
        }

        public static bool AskAndSaveBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                return false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png";
            saveFileDialog.InitialDirectory = FifaEnvironment.m_ExportFolder;
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Title = "Save picture as .bmp or .png";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                saveFileDialog.Dispose();
                return false;
            }
            string extension = Path.GetExtension(saveFileDialog.FileName);
            ImageFormat format;
            if (extension.ToLower() == ".bmp")
            {
                format = ImageFormat.Bmp;
                Color pixel = bitmap.GetPixel(0, 0);
                for (int x = bitmap.Width - 1; x >= 0; --x)
                {
                    for (int y = bitmap.Height - 1; y >= 0; --y)
                    {
                        if (bitmap.GetPixel(x, y).A < (byte)192)
                            bitmap.SetPixel(x, y, pixel);
                    }
                }
            }
            else if (extension.ToLower() == ".png")
            {
                format = ImageFormat.Png;
            }
            else
            {
                int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5034);
                return false;
            }
            bitmap.Save(saveFileDialog.FileName, format);
            saveFileDialog.Dispose();
            return true;
        }

        public static Bitmap BrowseAndCheckBitmap(
          int width,
          int height,
          int sizeMultiplier,
          int transparentMode)
        {
            switch (FifaEnvironment.m_UserMessages.ShowMessage(12))
            {
                case DialogResult.Cancel:
                case DialogResult.No:
                    return (Bitmap)null;
                default:
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.Multiselect = false;
                    openFileDialog.InitialDirectory = FifaEnvironment.m_ExportFolder;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Filter = "Image Files (*.bmp;*.png)|*.bmp;*.png";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Title = "Open Image File";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        openFileDialog.Dispose();
                        return (Bitmap)null;
                    }
                    string fileName = openFileDialog.FileName;
                    openFileDialog.Dispose();
                    Bitmap bitmap1 = new Bitmap(fileName);
                    if (bitmap1 == null)
                    {
                        int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(10006);
                        return (Bitmap)null;
                    }
                    if (bitmap1.Width != width || bitmap1.Height != height)
                    {
                        switch (sizeMultiplier)
                        {
                            case 1:
                                width += width / 2;
                                height += height / 2;
                                break;
                            case 2:
                                width *= 2;
                                height *= 2;
                                break;
                        }
                        if (bitmap1.Width != width || bitmap1.Height != height)
                        {
                            int num = (int)FifaEnvironment.m_UserMessages.ShowMessage(5015);
                            return (Bitmap)null;
                        }
                    }
                    if (transparentMode == 0 || !(Path.GetExtension(fileName).ToLower() == ".bmp"))
                        return bitmap1;
                    Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppArgb);
                    Color pixel1 = bitmap1.GetPixel(0, 0);
                    Color color = Color.FromArgb(0, 0, 0, 0);
                    for (int x = 0; x < bitmap1.Width; ++x)
                    {
                        for (int y = 0; y < bitmap1.Height; ++y)
                        {
                            Color pixel2 = bitmap1.GetPixel(x, y);
                            if (pixel2 == pixel1)
                                bitmap2.SetPixel(x, y, color);
                            else
                                bitmap2.SetPixel(x, y, pixel2);
                        }
                    }
                    return bitmap2;
            }
        }

        public static string BrowseAndCheckModel(ref string path, string title, string filter)
        {
            switch (FifaEnvironment.m_UserMessages.ShowMessage(12))
            {
                case DialogResult.Cancel:
                case DialogResult.No:
                    return (string)null;
                default:
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.Multiselect = false;
                    openFileDialog.InitialDirectory = path;
                    openFileDialog.Filter = filter;
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Title = title;
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        openFileDialog.Dispose();
                        return (string)null;
                    }
                    string fileName = openFileDialog.FileName;
                    path = Path.GetFullPath(fileName);
                    openFileDialog.Dispose();
                    return fileName;
            }
        }

        public static string BrowseAndCheckTtf(ref string path)
        {
            switch (FifaEnvironment.m_UserMessages.ShowMessage(12))
            {
                case DialogResult.Cancel:
                case DialogResult.No:
                    return (string)null;
                default:
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.CheckFileExists = true;
                    openFileDialog.Multiselect = false;
                    openFileDialog.InitialDirectory = path;
                    openFileDialog.Filter = "Font files(*.ttf)|*.ttf";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Title = "Open font file";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        openFileDialog.Dispose();
                        return (string)null;
                    }
                    string fileName = openFileDialog.FileName;
                    path = Path.GetFullPath(fileName);
                    openFileDialog.Dispose();
                    return fileName;
            }
        }

        public static void LoadLists(EFifaObjects fifaObjects)
        {
            FifaFat fifaFat = FifaEnvironment.m_FifaFat;
            if (FifaEnvironment.m_FifaDb == null)
                return;
            if ((fifaObjects & EFifaObjects.FifaRole) != (EFifaObjects)0)
                FifaEnvironment.s_RoleList = new RoleList(FifaEnvironment.m_FifaDb);
            if ((fifaObjects & EFifaObjects.FifaFormation) != (EFifaObjects)0)
            {
                FifaEnvironment.s_FormationList = new FormationList(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_GenericFormationList = new FormationList();
                foreach (Formation formation in (ArrayList)FifaEnvironment.s_FormationList)
                {
                    if (formation.IsGeneric())
                        FifaEnvironment.s_GenericFormationList.Add((object)formation);
                }
            }
            if ((fifaObjects & EFifaObjects.FifaCountry) != (EFifaObjects)0)
                FifaEnvironment.s_CountryList = new CountryList(FifaEnvironment.m_FifaDb);
            if ((fifaObjects & EFifaObjects.FifaKit) != (EFifaObjects)0)
                FifaEnvironment.s_KitList = new KitList(FifaEnvironment.m_FifaDb);
            if ((fifaObjects & EFifaObjects.FifaReferee) != (EFifaObjects)0)
                FifaEnvironment.s_RefereeList = new RefereeList(FifaEnvironment.m_FifaDb);
            if ((fifaObjects & EFifaObjects.FifaLeague) != (EFifaObjects)0)
                FifaEnvironment.s_LeagueList = new LeagueList(FifaEnvironment.m_FifaDb);
            if ((fifaObjects & EFifaObjects.FifaTeam) != (EFifaObjects)0)
            {
                FifaEnvironment.s_TeamList = new TeamList(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_FreeAgentList = new FreeAgentList();
                FifaEnvironment.s_TeamList.LinkOpponent(FifaEnvironment.s_TeamList);
            }
            if (FifaEnvironment.s_RefereeList != null && FifaEnvironment.s_CountryList != null)
                FifaEnvironment.s_RefereeList.LinkCountry(FifaEnvironment.s_CountryList);
            if (FifaEnvironment.s_RefereeList != null && FifaEnvironment.s_LeagueList != null)
                FifaEnvironment.s_RefereeList.LinkLeague(FifaEnvironment.s_LeagueList);
            if (FifaEnvironment.s_KitList != null && FifaEnvironment.s_TeamList != null)
            {
                FifaEnvironment.s_TeamList.LinkKits(FifaEnvironment.s_KitList);
                FifaEnvironment.s_KitList.LinkTeam(FifaEnvironment.s_TeamList);
            }
            if (FifaEnvironment.s_LeagueList != null && FifaEnvironment.s_TeamList != null)
                FifaEnvironment.s_LeagueList.FillFromLeagueTeamLinks(FifaEnvironment.m_FifaDb.Table[TI.leagueteamlinks]);
            if (FifaEnvironment.s_LeagueList != null && FifaEnvironment.s_CountryList != null)
                FifaEnvironment.s_LeagueList.LinkCountry(FifaEnvironment.s_CountryList);
            if (FifaEnvironment.s_LeagueList != null && FifaEnvironment.s_BallList != null)
                FifaEnvironment.s_LeagueList.LinkBall(FifaEnvironment.s_BallList);
            if ((fifaObjects & EFifaObjects.FifaPlayer) != (EFifaObjects)0)
            {
                FifaEnvironment.s_PlayerNamesList = new PlayerNames(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_OriginalPlayerNamesList = new PlayerNames(FifaEnvironment.m_OriginalFifaDb);
                Player.PlayerNames = FifaEnvironment.s_PlayerNamesList;
                FifaEnvironment.s_NameDictionary = new NameDictionary(FifaEnvironment.m_FifaDb);
                CareerFirstName.PlayerNames = FifaEnvironment.s_PlayerNamesList;
                CareerLastName.PlayerNames = FifaEnvironment.s_PlayerNamesList;
                CareerCommonName.PlayerNames = FifaEnvironment.s_PlayerNamesList;
                FifaEnvironment.s_PlayerList = new PlayerList(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerFirstNameList = new CareerFirstNameList(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerLastNameList = new CareerLastNameList(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerCommonNameList = new CareerCommonNameList(FifaEnvironment.m_FifaDb);
            }
            if (FifaEnvironment.s_TeamList != null && FifaEnvironment.s_PlayerList != null)
            {
                FifaEnvironment.s_TeamList.FillFromTeamPlayerLinks(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_TeamList.LinkPlayer(FifaEnvironment.s_PlayerList);
            }
            if (FifaEnvironment.s_PlayerList != null && FifaEnvironment.s_CountryList != null)
                FifaEnvironment.s_PlayerList.LinkCountry(FifaEnvironment.s_CountryList);
            if (FifaEnvironment.s_PlayerList != null && FifaEnvironment.s_TeamList != null)
                FifaEnvironment.s_PlayerList.LinkTeam(FifaEnvironment.s_TeamList);
            if (FifaEnvironment.s_TeamList != null && FifaEnvironment.s_FormationList != null)
            {
                FifaEnvironment.s_TeamList.LinkFormation(FifaEnvironment.s_FormationList);
                FifaEnvironment.s_FormationList.LinkTeam(FifaEnvironment.s_TeamList);
            }
            if ((fifaObjects & EFifaObjects.FifaStadium) != (EFifaObjects)0)
                FifaEnvironment.s_StadiumList = new StadiumList(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_TeamList != null && FifaEnvironment.s_StadiumList != null)
            {
                FifaEnvironment.s_TeamList.LinkStadiums(FifaEnvironment.s_StadiumList);
                FifaEnvironment.s_StadiumList.LinkTeam(FifaEnvironment.s_TeamList);
            }
            if (FifaEnvironment.s_CountryList != null && FifaEnvironment.s_StadiumList != null)
                FifaEnvironment.s_StadiumList.LinkCountry(FifaEnvironment.s_CountryList);
            if (FifaEnvironment.s_TeamList != null && FifaEnvironment.s_LeagueList != null)
                FifaEnvironment.s_TeamList.LinkLeague(FifaEnvironment.s_LeagueList);
            if ((fifaObjects & EFifaObjects.FifaTournament) != (EFifaObjects)0)
                FifaEnvironment.s_CompetitionObjects = new CompobjList(FifaEnvironment.m_GameDir, FifaEnvironment.m_FifaDb);

            //if (FifaEnvironment.s_TeamList != null && FifaEnvironment.s_CountryList != null)
            //  FifaEnvironment.s_TeamList.LinkCountry(FifaEnvironment.s_CountryList);
            if (FifaEnvironment.s_TeamList != null && FifaEnvironment.s_CountryList != null)
                FifaEnvironment.s_CountryList.LinkTeam(FifaEnvironment.s_TeamList);

            if (FifaEnvironment.s_CompetitionObjects == null)
                return;
            FifaEnvironment.s_CompetitionObjects.Link();
        }

        public static void LoadLists()
        {
            FifaEnvironment.LoadLists((EFifaObjects)(4096 | 2048 | 128 | 1 | 256 | 16384 | 65536 | 262144 | 2 | 32768 | 8 | 32 | 1024 | 8192 | 131072 | 512 | 16 | 4 | 64 | 524288 | 8388608 | 16777216));
        }

        public static void SaveLists()
        {
            if (FifaEnvironment.s_RoleList != null)
                FifaEnvironment.s_RoleList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_FormationList != null)
                FifaEnvironment.s_FormationList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_CountryList != null)
                FifaEnvironment.s_CountryList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_KitList != null)
                FifaEnvironment.s_KitList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_RefereeList != null)
                FifaEnvironment.s_RefereeList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_LeagueList != null)
                FifaEnvironment.s_LeagueList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_TeamList != null)
                FifaEnvironment.s_TeamList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_PlayerList != null)
            {
                FifaEnvironment.s_PlayerNamesList.ClearUsedFlags();
                FifaEnvironment.s_PlayerList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerFirstNameList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerLastNameList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerCommonNameList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_PlayerNamesList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_NameDictionary.Save(FifaEnvironment.m_FifaDb);
            }
            if (FifaEnvironment.s_StadiumList != null)
                FifaEnvironment.s_StadiumList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_CompetitionObjects != null)
                FifaEnvironment.s_CompetitionObjects.Save(FifaEnvironment.m_GameDir, FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_BallList != null)
                FifaEnvironment.s_BallList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_ShoesList == null)
                return;
            FifaEnvironment.s_ShoesList.Save(FifaEnvironment.m_FifaDb);
        }

        public static void SaveLists(EFifaObjects fifaObjects)
        {
            if (FifaEnvironment.s_RoleList != null && (fifaObjects & EFifaObjects.FifaRole) != (EFifaObjects)0)
                FifaEnvironment.s_RoleList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_FormationList != null && (fifaObjects & EFifaObjects.FifaFormation) != (EFifaObjects)0)
                FifaEnvironment.s_FormationList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_CountryList != null && (fifaObjects & EFifaObjects.FifaCountry) != (EFifaObjects)0)
                FifaEnvironment.s_CountryList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_KitList != null && (fifaObjects & EFifaObjects.FifaKit) != (EFifaObjects)0)
                FifaEnvironment.s_KitList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_RefereeList != null && (fifaObjects & EFifaObjects.FifaReferee) != (EFifaObjects)0)
                FifaEnvironment.s_RefereeList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_LeagueList != null && (fifaObjects & EFifaObjects.FifaLeague) != (EFifaObjects)0)
                FifaEnvironment.s_LeagueList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_TeamList != null && (fifaObjects & EFifaObjects.FifaTeam) != (EFifaObjects)0)
                FifaEnvironment.s_TeamList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_PlayerList != null && (fifaObjects & EFifaObjects.FifaPlayer) != (EFifaObjects)0)
            {
                FifaEnvironment.s_PlayerNamesList.ClearUsedFlags();
                FifaEnvironment.s_PlayerList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerFirstNameList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerLastNameList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_CareerCommonNameList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_PlayerNamesList.Save(FifaEnvironment.m_FifaDb);
                FifaEnvironment.s_NameDictionary.Save(FifaEnvironment.m_FifaDb);
            }
            if (FifaEnvironment.s_StadiumList != null && (fifaObjects & EFifaObjects.FifaStadium) != (EFifaObjects)0)
                FifaEnvironment.s_StadiumList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_CompetitionObjects != null && (fifaObjects & EFifaObjects.FifaTournament) != (EFifaObjects)0)
                FifaEnvironment.s_CompetitionObjects.Save(FifaEnvironment.m_GameDir, FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_BallList != null && (fifaObjects & EFifaObjects.FifaBall) != (EFifaObjects)0)
                FifaEnvironment.s_BallList.Save(FifaEnvironment.m_FifaDb);
            if (FifaEnvironment.s_ShoesList == null || (fifaObjects & EFifaObjects.FifaShoes) == (EFifaObjects)0)
                return;
            FifaEnvironment.s_ShoesList.Save(FifaEnvironment.m_FifaDb);
        }

        public static void SaveCareerLists()
        {
            if (FifaEnvironment.s_RoleList == null)
                return;
            FifaEnvironment.s_RoleList.Save(FifaEnvironment.m_FifaDb);
        }

        public static ArrayList FindMissedFiles()
        {
            ArrayList arrayList = new ArrayList();
            if (arrayList.Count == 0)
                arrayList.Add((object)"No missed files found.");
            else
                arrayList.Add((object)(arrayList.Count.ToString() + " missed files found."));
            return arrayList;
        }

        public static void LoadCareerLists(EFifaObjects fifaObjects)
        {
            FifaFat fifaFat = FifaEnvironment.m_FifaFat;
            if (FifaEnvironment.m_CareerFile == null)
                return;
            if ((fifaObjects & EFifaObjects.FifaRole) != (EFifaObjects)0)
                FifaEnvironment.s_RoleList = new RoleList(FifaEnvironment.m_FifaDb);
            if ((fifaObjects & EFifaObjects.FifaLeague) == (EFifaObjects)0)
                return;
            FifaEnvironment.s_LeagueList = new LeagueList(FifaEnvironment.m_FifaDb);
        }

        public static void ShowOptions()
        {
            if (FifaEnvironment.m_UserOptions.ShowOptions() != DialogResult.OK)
                return;
            if (FifaEnvironment.m_UserOptions.m_AutoExportFolder)
                FifaEnvironment.m_ExportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                FifaEnvironment.m_ExportFolder = FifaEnvironment.m_UserOptions.m_ExportFolder;
        }
    }
}
