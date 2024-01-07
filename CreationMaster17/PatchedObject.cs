// Original code created by Rinaldo

using FifaLibrary;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace CreationMaster
{
    public class PatchedObject
    {
        private static Language s_Language = (Language)null;
        private static DataSet s_FifaDataSet = (DataSet)null;
        private static Table s_LangTable = (Table)null;
        private static Table s_NationsTable = (Table)null;
        private static Table s_TeamsTable = (Table)null;
        private static Table s_TeamplayerlinksTable = (Table)null;
        private static Table s_TeamstadiumlinksTable = (Table)null;
        private static Table s_TeamformationteamstylelinkTable = (Table)null;
        private static Table s_StadiumassignmentsTable = (Table)null;
        private static Table s_ManagerTable = (Table)null;
        private static Table s_TeamkitsTable = (Table)null;
        private static Table s_RowteamnationlinksTable = (Table)null;
        private static Table s_FormationsTable = (Table)null;
        private static Table s_LeaguesTable = (Table)null;
        private static Table s_BoardOutcomesTable = (Table)null;
        private static Table s_LeagueteamlinksTable = (Table)null;
        private static Table s_PlayernamesTable = (Table)null;
        private static Table s_PlayersTable = (Table)null;
        private static Table s_RefereeTable = (Table)null;
        private static Table s_StadiumsTable = (Table)null;
        private static Table s_FinalstadiumsTable = (Table)null;
        private static Table s_Tourn_licensedTable = (Table)null;
        private static Table s_Tourn_licensed_stagesTable = (Table)null;
        private static PlayerNames s_PlayerNames = (PlayerNames)null;
        private static DataSet s_Fifa12DataSet = (DataSet)null;
        private static int[] c_FormationSwitchTable = new int[21]
        {
      801,
      806,
      808,
      808,
      808,
      809,
      803,
      805,
      802,
      803,
      805,
      804,
      801,
      801,
      805,
      806,
      807,
      806,
      807,
      801,
      801
        };
        public static bool s_RefereeKitNotLoaded;
        private static int s_PlayerCount;
        public static bool s_TeamCrossReferenceRequired;
        public static bool s_PlayerCrossReferenceRequired;
        public static bool s_CountryCrossReferenceRequired;
        public static bool s_ShoesCrossReferenceRequired;
        public static bool s_BallCrossReferenceRequired;
        public static bool s_AdboardCrossReferenceRequired;
        private string m_Type;
        private string m_Name;
        private int m_Id;
        private int m_ImportId;
        private object m_ReplacedObject;
        private object m_NewObject;
        private object m_CmsObject;
        private PatchedObject.EUsedObject m_UsedObject;
        private bool m_IsCmsNew;

        public string Type
        {
            get
            {
                return this.m_Type;
            }
            set
            {
                this.m_Type = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.m_Id;
            }
            set
            {
                this.m_Id = value;
            }
        }

        public int ImportId
        {
            get
            {
                return this.m_ImportId;
            }
        }

        public object ReplacedObject
        {
            get
            {
                return this.m_ReplacedObject;
            }
            set
            {
                this.m_ReplacedObject = value;
                if (!this.IsUsedFittingObject())
                    return;
                this.m_ImportId = ((IdObject)this.m_ReplacedObject).Id;
            }
        }

        public object NewObject
        {
            get
            {
                return this.m_NewObject;
            }
            set
            {
                this.m_NewObject = value;
            }
        }

        public object CmsObject
        {
            get
            {
                return this.m_CmsObject;
            }
            set
            {
                this.m_CmsObject = value;
            }
        }

        public static void SetLanguageDataSet(DataSet langDataSet)
        {
            if (!(langDataSet.DataSetName == "LANG14") && !(langDataSet.DataSetName == "LANG15"))
                return;
            DataTable table = langDataSet.Tables["LanguageStrings"];
            PatchedObject.s_LangTable = (Table)null;
            if (table == null)
                return;
            PatchedObject.s_LangTable = new Table(FifaEnvironment.LangDb.Table[TI.lang].TableDescriptor);
            PatchedObject.s_LangTable.ConvertFromDataTable(table);
            if (PatchedObject.s_LangTable == null)
                return;
            PatchedObject.s_Language = new Language(PatchedObject.s_LangTable);
        }

        private static DataRow ConvertDefaultDataRowFromPreviousFifa(
          DataRow previousFifaDataRow,
          DataRow fifaDataRow)
        {
            for (int index = 0; index < previousFifaDataRow.ItemArray.Length; ++index)
            {
                string columnName = previousFifaDataRow.Table.Columns[index].ColumnName;
                if (fifaDataRow.Table.Columns.Contains(columnName))
                    fifaDataRow[columnName] = previousFifaDataRow[index];
            }
            return fifaDataRow;
        }

        public static void ConvertDataTableFromPreviousFifa(DataTable previousFifaDataTable)
        {
            foreach (DataRow row in (InternalDataCollectionBase)previousFifaDataTable.Rows)
                PatchedObject.ConvertDataRowFromPreviousFifa(row);
        }

        public static void ConvertDataRowFromPreviousFifa(DataRow previousFifaDataRow)
        {
            string tableName;
            if ((tableName = previousFifaDataRow.Table.TableName) == null)
                return;
            int num = tableName == "players" ? 1 : 0;
        }

        public static void ConvertPlayersFromPreviousFifa(DataRow playersPreviousDataRow)
        {
            DataRow dataRow = PatchedObject.s_Fifa12DataSet.Tables["players"].NewRow();
            PatchedObject.ConvertDefaultDataRowFromPreviousFifa(playersPreviousDataRow, dataRow);
            Record record = new Record(FifaEnvironment.FifaDb.Table[TI.players].TableDescriptor);
            record.ConvertFromDataRow(dataRow);
            record.IntField[FI.players_playerid] = (int)playersPreviousDataRow["playerid"];
        }

        public static bool SetFifaDataSet(DataSet fifaDataSet)
        {
            if (fifaDataSet.DataSetName == "FIFA14" || fifaDataSet.DataSetName == "FIFA15")
            {
                PatchedObject.s_FifaDataSet = fifaDataSet;
                PatchedObject.s_NationsTable = PatchedObject.ConvertTable("nations", TI.nations);
                PatchedObject.s_TeamsTable = PatchedObject.ConvertTable("teams", TI.teams);
                PatchedObject.s_TeamplayerlinksTable = PatchedObject.ConvertTable("teamplayerlinks", TI.teamplayerlinks);
                PatchedObject.s_TeamstadiumlinksTable = PatchedObject.ConvertTable("teamstadiumlinks", TI.teamstadiumlinks);
                PatchedObject.s_TeamformationteamstylelinkTable = PatchedObject.ConvertTable("teamformationteamstylelinks", TI.teamformationteamstylelinks);
                PatchedObject.s_StadiumassignmentsTable = PatchedObject.ConvertTable("stadiumassignments", TI.stadiumassignments);
                PatchedObject.s_ManagerTable = PatchedObject.ConvertTable("manager", TI.manager);
                PatchedObject.s_TeamkitsTable = PatchedObject.ConvertTable("teamkits", TI.teamkits);
                PatchedObject.s_RowteamnationlinksTable = PatchedObject.ConvertTable("rowteamnationlinks", TI.rowteamnationlinks);
                PatchedObject.s_FormationsTable = PatchedObject.ConvertTable("formations", TI.formations);
                PatchedObject.s_LeaguesTable = PatchedObject.ConvertTable("leagues", TI.leagues);
                PatchedObject.s_BoardOutcomesTable = PatchedObject.ConvertTable("career_boardoutcomes", TI.career_boardoutcomes);
                PatchedObject.s_LeagueteamlinksTable = PatchedObject.ConvertTable("leagueteamlinks", TI.leagueteamlinks);
                PatchedObject.s_PlayersTable = PatchedObject.ConvertTable("players", TI.players);
                PatchedObject.s_RefereeTable = PatchedObject.ConvertTable("referee", TI.referee);
                PatchedObject.s_StadiumsTable = PatchedObject.ConvertTable("stadiums", TI.stadiums);
                PatchedObject.s_FinalstadiumsTable = PatchedObject.ConvertTable("finalstadiums", TI.finalstadiums);
                PatchedObject.s_Tourn_licensedTable = PatchedObject.ConvertTable("tourn_licensed", TI.tourn_licensed);
                PatchedObject.s_Tourn_licensed_stagesTable = PatchedObject.ConvertTable("tourn_licensed_stages", TI.tourn_licensed_stages);
                PatchedObject.s_PlayernamesTable = PatchedObject.ConvertTable("playernames", TI.playernames);
                if (PatchedObject.s_PlayernamesTable != null && PatchedObject.s_PlayernamesTable.Records.Length > 0)
                    PatchedObject.s_PlayerNames = new PlayerNames(PatchedObject.s_PlayernamesTable);
                if (fifaDataSet.DataSetName == "FIFA14" && FifaEnvironment.Year == 15)
                    PatchedObject.ConvertTablesFrom14to15();
                else if (fifaDataSet.DataSetName == "FIFA15" && FifaEnvironment.Year == 14)
                    PatchedObject.ConvertTablesFrom15to14();
                return true;
            }
            int num = (int)FifaEnvironment.UserMessages.ShowMessage(1032);
            return false;
        }

        private static void ConvertTablesFrom14to15()
        {
            if (PatchedObject.s_TeamsTable != null)
            {
                for (int index = 0; index < PatchedObject.s_TeamsTable.Records.Length; ++index)
                {
                    Record record = PatchedObject.s_TeamsTable.Records[index];
                    record.IntField[FI.teams_rightfreekicktakerid] = record.IntField[FI.teams_freekicktakerid];
                    record.IntField[FI.teams_leftfreekicktakerid] = record.IntField[FI.teams_freekicktakerid];
                }
            }
            if (PatchedObject.s_FormationsTable == null)
                return;
            for (int index = 0; index < PatchedObject.s_FormationsTable.Records.Length; ++index)
            {
                Record record = PatchedObject.s_FormationsTable.Records[index];
                int roleid1 = record.IntField[FI.formations_position0];
                record.IntField[FI.formations_playerinstruction0] = PlayingRole.GetDefaultInstruction(roleid1);
                int roleid2 = record.IntField[FI.formations_position1];
                record.IntField[FI.formations_playerinstruction1] = PlayingRole.GetDefaultInstruction(roleid2);
                int roleid3 = record.IntField[FI.formations_position2];
                record.IntField[FI.formations_playerinstruction2] = PlayingRole.GetDefaultInstruction(roleid3);
                int roleid4 = record.IntField[FI.formations_position3];
                record.IntField[FI.formations_playerinstruction3] = PlayingRole.GetDefaultInstruction(roleid4);
                int roleid5 = record.IntField[FI.formations_position4];
                record.IntField[FI.formations_playerinstruction4] = PlayingRole.GetDefaultInstruction(roleid5);
                int roleid6 = record.IntField[FI.formations_position5];
                record.IntField[FI.formations_playerinstruction5] = PlayingRole.GetDefaultInstruction(roleid6);
                int roleid7 = record.IntField[FI.formations_position6];
                record.IntField[FI.formations_playerinstruction6] = PlayingRole.GetDefaultInstruction(roleid7);
                int roleid8 = record.IntField[FI.formations_position7];
                record.IntField[FI.formations_playerinstruction7] = PlayingRole.GetDefaultInstruction(roleid8);
                int roleid9 = record.IntField[FI.formations_position8];
                record.IntField[FI.formations_playerinstruction8] = PlayingRole.GetDefaultInstruction(roleid9);
                int roleid10 = record.IntField[FI.formations_position9];
                record.IntField[FI.formations_playerinstruction9] = PlayingRole.GetDefaultInstruction(roleid10);
                int roleid11 = record.IntField[FI.formations_position10];
                record.IntField[FI.formations_playerinstruction10] = PlayingRole.GetDefaultInstruction(roleid11);
            }
        }

        private static void ConvertTablesFrom15to14()
        {
        }

        private static Table ConvertTable(string tableName, int tableIndex)
        {
            if (PatchedObject.s_FifaDataSet == null)
                return (Table)null;
            PatchedObject.s_FifaDataSet.Locale = new CultureInfo(CultureInfo.InvariantCulture.LCID);
            DataTable table1 = PatchedObject.s_FifaDataSet.Tables[tableName];
            if (table1 == null)
                return (Table)null;
            Table table2 = new Table(FifaEnvironment.FifaDb.Table[tableIndex].TableDescriptor);
            table2.ConvertFromDataTable(table1);
            return table2;
        }

        private static DataTable ConvertDataTableFromPreviousFifa(
          string tableName,
          int tableIndex)
        {
            return PatchedObject.ConvertDataTableFromPreviousFifa(tableName, tableName, tableIndex);
        }

        private static DataTable ConvertDataTableFromPreviousFifa(
          string oldTableName,
          string newTableName,
          int newTableIndex)
        {
            if (PatchedObject.s_FifaDataSet == null)
                return (DataTable)null;
            if (!PatchedObject.s_Fifa12DataSet.Tables.Contains(newTableName))
                return (DataTable)null;
            DataTable table = PatchedObject.s_FifaDataSet.Tables[oldTableName];
            PatchedObject.s_Fifa12DataSet.Tables[newTableName].Clear();
            foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
            {
                DataRow dataRow = PatchedObject.s_Fifa12DataSet.Tables[newTableName].NewRow();
                PatchedObject.ConvertDefaultDataRowFromPreviousFifa(row, dataRow);
                PatchedObject.s_Fifa12DataSet.Tables[newTableName].Rows.Add(dataRow);
            }
            return PatchedObject.s_Fifa12DataSet.Tables[newTableName];
        }

        public static void Initialize()
        {
            PatchedObject.s_PlayerCount = 0;
        }

        public PatchedObject.EUsedObject UsedObject
        {
            get
            {
                return this.m_UsedObject;
            }
            set
            {
                this.m_UsedObject = value;
                switch (this.m_UsedObject)
                {
                    case PatchedObject.EUsedObject.UseCms:
                        this.m_ImportId = ((IdObject)this.m_CmsObject).Id;
                        break;
                    case PatchedObject.EUsedObject.UseNew:
                        this.m_ImportId = ((IdObject)this.m_NewObject).Id;
                        break;
                    case PatchedObject.EUsedObject.UseFitting:
                        this.m_ImportId = ((IdObject)this.m_ReplacedObject).Id;
                        break;
                }
            }
        }

        public bool IsUsedUndefinedObject()
        {
            return this.m_UsedObject == PatchedObject.EUsedObject.Undefined;
        }

        public bool IsUsedNewObject()
        {
            return this.m_UsedObject == PatchedObject.EUsedObject.UseNew;
        }

        public bool IsUsedCmsObject()
        {
            return this.m_UsedObject == PatchedObject.EUsedObject.UseCms;
        }

        public bool IsUsedFittingObject()
        {
            return this.m_UsedObject == PatchedObject.EUsedObject.UseFitting;
        }

        public bool IsCmsNew
        {
            get
            {
                return this.m_IsCmsNew;
            }
            set
            {
                this.m_IsCmsNew = value;
            }
        }

        private bool IsObjectUsedNew()
        {
            if (this.m_UsedObject == PatchedObject.EUsedObject.UseNew)
                return true;
            return this.m_UsedObject == PatchedObject.EUsedObject.UseCms && this.IsCmsNew;
        }

        public PatchedObject(string type, string name, int id)
        {
            this.m_Type = type;
            this.m_Name = name;
            this.m_Id = id;
        }

        public void UseReplacedObject()
        {
            this.UsedObject = PatchedObject.EUsedObject.UseFitting;
        }

        public void UsePatchId()
        {
            this.UsedObject = PatchedObject.EUsedObject.UseCms;
        }

        public void UseNewObject()
        {
            if (this.m_NewObject != null)
            {
                this.UsedObject = PatchedObject.EUsedObject.UseNew;
            }
            else
            {
                if (!this.AssignAutoNewObject())
                    return;
                this.UsedObject = PatchedObject.EUsedObject.UseNew;
            }
        }

        private void RemoveObject(object toBeRemovedObject)
        {
            if (this.m_Type == "Player")
                FifaEnvironment.Players.RemoveId((IdObject)toBeRemovedObject);
            else if (this.m_Type == "Team")
                FifaEnvironment.Teams.RemoveId((IdObject)toBeRemovedObject);
            else if (this.m_Type == "League")
                FifaEnvironment.Leagues.RemoveId((IdObject)toBeRemovedObject);
            else if (this.m_Type == "Country")
                FifaEnvironment.Countries.RemoveId((IdObject)toBeRemovedObject);
            else if (this.m_Type == "Stadium")
                FifaEnvironment.Stadiums.RemoveId((IdObject)toBeRemovedObject);
            else if (this.m_Type == "Referee")
                FifaEnvironment.Referees.RemoveId((IdObject)toBeRemovedObject);
            else if (this.m_Type == "Formation")
            {
                FifaEnvironment.Formations.RemoveId((IdObject)toBeRemovedObject);
            }
            else
            {
                if (this.m_Type == "Sponsor")
                    return;
                if (this.m_Type == "Ball")
                    FifaEnvironment.Balls.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "Adboard")
                    FifaEnvironment.Adboards.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "NumberFont")
                    FifaEnvironment.NumberFonts.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "NameFont")
                    FifaEnvironment.NameFonts.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "Shoes")
                    FifaEnvironment.Shoes.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "Net")
                    FifaEnvironment.Nets.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "Grass")
                    FifaEnvironment.GkGloves.RemoveId((IdObject)toBeRemovedObject);
                else if (this.m_Type == "MowingPatterns")
                {
                    FifaEnvironment.MowingPatterns.RemoveId((IdObject)toBeRemovedObject);
                }
                else
                {
                    if (!(this.m_Type == "Kit"))
                        return;
                    FifaEnvironment.Kits.RemoveId((IdObject)toBeRemovedObject);
                }
            }
        }

        public void RemoveNewObject()
        {
            if (this.m_NewObject != null)
                this.RemoveObject(this.m_NewObject);
            if (!this.IsCmsNew || this.m_CmsObject == null)
                return;
            this.RemoveObject(this.m_CmsObject);
        }

        public void RemoveNewObjectIfUnused()
        {
            object usedObject = this.GetUsedObject();
            if (usedObject != this.m_NewObject && this.m_NewObject != null)
                this.RemoveObject(this.m_NewObject);
            if (usedObject == this.m_CmsObject || this.m_CmsObject == null || !this.IsCmsNew)
                return;
            this.RemoveObject(this.m_CmsObject);
        }

        public Color GetColor()
        {
            if (!this.IsObjectUsedNew())
                return Color.Red;
            return this.m_NewObject != null || this.m_CmsObject != null ? Color.Green : Color.Gray;
        }

        private bool AssignAutoNewObject()
        {
            if (this.m_Type == "Player")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Players.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Team")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Teams.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "League")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Leagues.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Country")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Countries.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Stadium")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Stadiums.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Referee")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Referees.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Formation")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Formations.CreateNewFormation() : this.m_CmsObject;
            else if (this.m_Type == "Ball")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Balls.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Adboard")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Adboards.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "NumberFont")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.NumberFonts.CreateNewId(this.m_Id) : this.m_CmsObject;
            else if (this.m_Type == "NameFont")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.NameFonts.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Shoes")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Shoes.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Net")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.Nets.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "GkGloves")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.GkGloves.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "MowingPattern")
                this.m_NewObject = !this.IsCmsNew ? (object)FifaEnvironment.MowingPatterns.CreateNewId() : this.m_CmsObject;
            else if (this.m_Type == "Kit")
            {
                if (this.IsCmsNew)
                {
                    this.m_NewObject = this.m_CmsObject;
                }
                else
                {
                    this.m_NewObject = (object)FifaEnvironment.Kits.CreateNewId();
                    int num = this.m_Id / 10;
                    ((Kit)this.m_NewObject).teamid = num;
                    ((Kit)this.m_NewObject).kittype = this.m_Id - 10 * num;
                }
            }
            if (this.m_NewObject == null)
            {
                int num1 = (int)FifaEnvironment.UserMessages.ShowMessage(5043);
            }
            return this.m_NewObject != null;
        }

        private bool AssignFittingObject()
        {
            if (this.m_Type == "Player")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Players.FitPlayer(this.m_Name, this.m_Id);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Players.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Players[0];
            }
            else if (this.m_Type == "Team")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Teams.FitTeam(this.m_Name);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Teams.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Teams[0];
            }
            else if (this.m_Type == "League")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Leagues.FitLeague(this.m_Name, this.m_Id);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Leagues.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Leagues[0];
            }
            else if (this.m_Type == "Country")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Countries.FitCountry(this.m_Name, this.m_Id);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Countries.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Countries[0];
            }
            else if (this.m_Type == "Stadium")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Stadiums.FitStadium(this.m_Name, this.m_Id);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Stadiums.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Stadiums[0];
            }
            else if (this.m_Type == "Referee")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Referees.FitReferee(this.m_Name, this.m_Id);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Referees.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Referees[0];
            }
            else if (this.m_Type == "Formation")
            {
                this.m_ReplacedObject = (object)FifaEnvironment.Formations.FitFormation(this.m_Name, this.m_Id);
                if (this.m_ReplacedObject != null)
                    this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                if (this.m_ReplacedObject == null && FifaEnvironment.Formations.Count > 0)
                    this.m_ReplacedObject = FifaEnvironment.Formations[0];
            }
            else if (!(this.m_Type == "Sponsor"))
            {
                if (this.m_Type == "Kit")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.Kits.FitKit(this.m_Name, this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.Kits.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.Kits[0];
                }
                else if (this.m_Type == "Ball")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.Balls.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.Balls.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.Balls[0];
                }
                else if (this.m_Type == "Adboard")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.Adboards.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.Adboards.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.Adboards[0];
                }
                else if (this.m_Type == "NumberFont")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.NumberFonts.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.NumberFonts.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.NumberFonts[0];
                }
                else if (this.m_Type == "NameFont")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.NameFonts.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.NameFonts.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.NameFonts[0];
                }
                else if (this.m_Type == "Shoes")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.Shoes.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.Shoes.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.Shoes[0];
                }
                else if (this.m_Type == "Net")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.Nets.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.Nets.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.Nets[0];
                }
                else if (this.m_Type == "GkGloves")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.GkGloves.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.GkGloves.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.GkGloves[0];
                }
                else if (this.m_Type == "MowingPattern")
                {
                    this.m_ReplacedObject = (object)FifaEnvironment.MowingPatterns.SearchId(this.m_Id);
                    if (this.m_ReplacedObject != null)
                        this.UsedObject = PatchedObject.EUsedObject.UseFitting;
                    if (this.m_ReplacedObject == null && FifaEnvironment.MowingPatterns.Count > 0)
                        this.m_ReplacedObject = FifaEnvironment.MowingPatterns[0];
                }
            }
            return this.m_ReplacedObject != null;
        }

        private bool AssignCmsReplacedObject()
        {
            if (this.m_Type == "Player")
                this.m_CmsObject = (object)FifaEnvironment.Players.SearchId(this.Id);
            else if (this.m_Type == "Team")
                this.m_CmsObject = (object)FifaEnvironment.Teams.SearchId(this.Id);
            else if (this.m_Type == "League")
                this.m_CmsObject = (object)FifaEnvironment.Leagues.SearchId(this.Id);
            else if (this.m_Type == "Country")
                this.m_CmsObject = (object)FifaEnvironment.Countries.SearchId(this.Id);
            else if (this.m_Type == "Stadium")
                this.m_CmsObject = (object)FifaEnvironment.Stadiums.SearchId(this.Id);
            else if (this.m_Type == "Referee")
                this.m_CmsObject = (object)FifaEnvironment.Referees.SearchId(this.Id);
            else if (this.m_Type == "Formation")
                this.m_CmsObject = (object)null;
            else if (this.m_Type == "Ball")
                this.m_CmsObject = (object)FifaEnvironment.Balls.SearchId(this.Id);
            else if (this.m_Type == "Adboard")
                this.m_CmsObject = (object)FifaEnvironment.Adboards.SearchId(this.Id);
            else if (this.m_Type == "NumberFont")
                this.m_CmsObject = (object)FifaEnvironment.NumberFonts.SearchId(this.Id);
            else if (this.m_Type == "NameFont")
                this.m_CmsObject = (object)FifaEnvironment.NameFonts.SearchId(this.Id);
            else if (this.m_Type == "Shoes")
                this.m_CmsObject = (object)FifaEnvironment.Shoes.SearchId(this.Id);
            else if (this.m_Type == "Net")
                this.m_CmsObject = (object)FifaEnvironment.Nets.SearchId(this.Id);
            else if (this.m_Type == "GkGloves")
                this.m_CmsObject = (object)FifaEnvironment.GkGloves.SearchId(this.Id);
            else if (this.m_Type == "MowingPattern")
                this.m_CmsObject = (object)FifaEnvironment.MowingPatterns.SearchId(this.Id);
            else if (this.m_Type == "Kit")
                this.m_CmsObject = (object)null;
            this.IsCmsNew = this.m_CmsObject == null;
            return !this.IsCmsNew;
        }

        public bool AssignNewCmsObject(bool isCmsPatch)
        {
            if (this.m_Type == "Player")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Players.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Team")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Teams.CreateNewId(this.Id);
            }
            else if (this.m_Type == "League")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Leagues.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Country")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Countries.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Stadium")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Stadiums.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Referee")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Referees.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Formation")
            {
                if (this.IsCmsNew)
                {
                    this.m_CmsObject = (object)FifaEnvironment.Formations.CreateNewFormation();
                    return this.m_CmsObject != null;
                }
            }
            else if (this.m_Type == "Ball")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Balls.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Adboard")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Adboards.CreateNewId(this.Id);
            }
            else if (this.m_Type == "NumberFont")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.NumberFonts.CreateNewId(this.Id);
            }
            else if (this.m_Type == "NameFont")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.NameFonts.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Shoes")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Shoes.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Net")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.Nets.CreateNewId(this.Id);
            }
            else if (this.m_Type == "GkGloves")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.GkGloves.CreateNewId(this.Id);
            }
            else if (this.m_Type == "MowingPattern")
            {
                if (this.IsCmsNew)
                    this.m_CmsObject = (object)FifaEnvironment.MowingPatterns.CreateNewId(this.Id);
            }
            else if (this.m_Type == "Kit" && this.IsCmsNew)
            {
                this.m_CmsObject = (object)FifaEnvironment.Kits.CreateNewId();
                return this.m_CmsObject != null;
            }
            if (this.m_CmsObject != null && isCmsPatch)
                this.UsedObject = PatchedObject.EUsedObject.UseCms;
            return this.m_CmsObject != null;
        }

        public void AssignReplacedObject(bool isCmsPatch)
        {
            this.AssignFittingObject();
            this.AssignCmsReplacedObject();
        }

        public void AssignNewObject(bool isCmsPatch)
        {
            if (!this.IsUsedUndefinedObject() || !this.AssignAutoNewObject())
                return;
            this.UsedObject = PatchedObject.EUsedObject.UseNew;
        }

        public object GetUsedObject()
        {
            switch (this.UsedObject)
            {
                case PatchedObject.EUsedObject.UseCms:
                    return this.m_CmsObject;
                case PatchedObject.EUsedObject.UseFitting:
                    return this.m_ReplacedObject;
                default:
                    return this.m_NewObject;
            }
        }

        public string GetObjectType()
        {
            switch (this.UsedObject)
            {
                case PatchedObject.EUsedObject.UseCms:
                    return this.m_CmsObject.GetType().Name;
                case PatchedObject.EUsedObject.UseNew:
                    return this.m_NewObject.GetType().Name;
                case PatchedObject.EUsedObject.UseFitting:
                    return this.m_ReplacedObject.GetType().Name;
                default:
                    return (string)null;
            }
        }

        public void Import()
        {
            if (this.m_Type == "Player")
                this.ImportPlayer();
            else if (this.m_Type == "Team")
                this.ImportTeam();
            else if (this.m_Type == "League")
                this.ImportLeague();
            else if (this.m_Type == "Country")
                this.ImportCountry();
            else if (this.m_Type == "Stadium")
                this.ImportStadium();
            else if (this.m_Type == "Referee")
                this.ImportReferee();
            else if (this.m_Type == "Formation")
                this.ImportFormation();
            else if (this.m_Type == "Ball")
                this.ImportBall();
            else if (this.m_Type == "Adboard")
                this.ImportAdboard();
            else if (this.m_Type == "NumberFont")
                this.ImportNumberFont();
            else if (this.m_Type == "NameFont")
                this.ImportNameFont();
            else if (this.m_Type == "Shoes")
                this.ImportShoes();
            else if (this.m_Type == "Net")
                this.ImportNet();
            else if (this.m_Type == "MowingPattern")
                this.ImportMowingPattern();
            else if (this.m_Type == "Kit")
            {
                this.ImportKit();
            }
            else
            {
                if (!(this.m_Type == "GkGloves"))
                    return;
                this.ImportGkGloves();
            }
        }

        private void ImportKit()
        {
            Kit usedObject = (Kit)this.GetUsedObject();
            if (usedObject == null)
                return;
            int num1 = this.m_Id / 10;
            int num2 = this.m_Id - 10 * num1;
            if (MainForm.m_PatchLoaderForm.checkKits.Checked)
            {
                if (PatchedObject.s_TeamkitsTable != null)
                {
                    foreach (Record record in PatchedObject.s_TeamkitsTable.Records)
                    {
                        if (record.IntField[FI.teamkits_teamtechid] == num1 && record.IntField[FI.teamkits_teamkittypetechid] == num2)
                        {
                            usedObject.Load(record);
                            usedObject.Id = this.m_ImportId;
                            if (PatchedObject.s_TeamCrossReferenceRequired)
                                usedObject.teamid = MainForm.m_PatchLoaderForm.CrossReference("Team", num1);
                            usedObject.LinkTeam(FifaEnvironment.Teams);
                            if (usedObject.Team != null)
                            {
                                usedObject.Team.m_KitList.Add((object)usedObject);
                                usedObject.Team.LinkKits(FifaEnvironment.Kits);
                                break;
                            }
                            break;
                        }
                    }
                }
                string str1 = Kit.KitTextureFileName(num1, usedObject.kittype, 0);
                string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                if (File.Exists(str2))
                    usedObject.SetKitTextures(str2);
            }
            if (!MainForm.m_PatchLoaderForm.checkMinikits.Checked)
                return;
            string str3 = Kit.MiniKitDdsFileName(num1, usedObject.kittype, 0);
            string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
            if (!File.Exists(str4))
                return;
            Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str4);
            usedObject.SetMiniKit(bitmapFromDdsFile);
        }

        private void ImportStadium()
        {
            Stadium usedObject = (Stadium)this.GetUsedObject();
            if (usedObject == null)
                return;
            if (MainForm.m_PatchLoaderForm.checkStadiumDatabase.Checked && PatchedObject.s_StadiumsTable != null)
            {
                foreach (Record record in PatchedObject.s_StadiumsTable.Records)
                {
                    if (record.IntField[FI.stadiums_stadiumid] == this.m_Id)
                    {
                        usedObject.Load(record);
                        usedObject.LocalName = usedObject.name;
                        if (PatchedObject.s_CountryCrossReferenceRequired)
                            usedObject.countrycode = MainForm.m_PatchLoaderForm.CrossReference("Country", record.IntField[FI.stadiums_countrycode]);
                        usedObject.LinkCountry(FifaEnvironment.Countries);
                        if (PatchedObject.s_TeamCrossReferenceRequired)
                            usedObject.hometeamid = MainForm.m_PatchLoaderForm.CrossReference("Team", usedObject.hometeamid);
                        usedObject.LinkTeam(FifaEnvironment.Teams);
                        break;
                    }
                }
            }
            if (MainForm.m_PatchLoaderForm.checkStadiumPreview.Checked)
            {
                for (int timeofday = 0; timeofday <= 4; ++timeofday)
                {
                    if (timeofday != 2)
                    {
                        string str1 = Stadium.PreviewBigFileName(this.m_Id, timeofday);
                        string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                        if (File.Exists(str2))
                        {
                            Bitmap bitmapFromBigFile = FifaEnvironment.GetBitmapFromBigFile(str2);
                            usedObject.SetPreview(timeofday, bitmapFromBigFile);
                        }
                        string str3 = Stadium.PreviewLargeBigFileName(this.m_Id, timeofday);
                        string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
                        if (File.Exists(str4))
                        {
                            Bitmap bitmapFromBigFile = FifaEnvironment.GetBitmapFromBigFile(str4);
                            usedObject.SetPreviewLarge(timeofday, bitmapFromBigFile);
                        }
                    }
                }
            }
            if (!MainForm.m_PatchLoaderForm.checkStadiumModel.Checked)
                return;
            string str5 = Stadium.ModelFileName(this.m_Id);
            string str6 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str5;
            if (File.Exists(str6))
                usedObject.SetModel(str6);
            for (int timeofday = 0; timeofday <= 4; ++timeofday)
            {
                if (timeofday != 2)
                {
                    string str1 = Stadium.TexturesFileName(this.m_Id, timeofday);
                    string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                    if (File.Exists(str2))
                        usedObject.SetTextures(timeofday, str2);
                    string str3 = Stadium.CrowdFileName(this.m_Id, timeofday);
                    string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
                    if (File.Exists(str4))
                        usedObject.SetCrowd(timeofday, str4);
                }
            }
            string[] sourceFileNames = Stadium.GlaresLightFileNames(this.m_Id);
            for (int index = 0; index < sourceFileNames.Length; ++index)
                sourceFileNames[index] = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + sourceFileNames[index];
            usedObject.SetGlaresLight(sourceFileNames);
        }

        private void ImportPlayer()
        {
            Player usedObject = (Player)this.GetUsedObject();
            if (usedObject == null)
                return;
            if (PatchedObject.s_PlayersTable != null)
            {
                if (PatchedObject.s_PlayerCount >= PatchedObject.s_PlayersTable.Records.Length)
                    PatchedObject.s_PlayerCount = 0;
                int index1 = PatchedObject.s_PlayerCount;
                for (int index2 = 0; index2 < PatchedObject.s_PlayersTable.Records.Length; ++index2)
                {
                    Record record = PatchedObject.s_PlayersTable.Records[index1];
                    if (record.IntField[FI.players_playerid] == this.m_Id)
                    {
                        PatchedObject.s_PlayerCount = index1 + 1;
                        usedObject.Load(record);
                        if (PatchedObject.s_PlayerNames != null)
                        {
                            string name;
                            usedObject.firstname = PatchedObject.s_PlayerNames.TryGetValue(usedObject.firstnameid, out name, true) ? name : string.Empty;
                            usedObject.lastname = PatchedObject.s_PlayerNames.TryGetValue(usedObject.lastnameid, out name, true) ? name : string.Empty;
                            usedObject.commonname = PatchedObject.s_PlayerNames.TryGetValue(usedObject.commonnameid, out name, true) ? name : string.Empty;
                            usedObject.playerjerseyname = PatchedObject.s_PlayerNames.TryGetValue(usedObject.playerjerseynameid, out name, true) ? name : string.Empty;
                        }
                        else
                        {
                            usedObject.firstname = string.Empty;
                            usedObject.lastname = "Player " + usedObject.Id.ToString();
                            usedObject.commonname = string.Empty;
                            usedObject.playerjerseyname = string.Empty;
                        }
                        if (PatchedObject.s_ShoesCrossReferenceRequired)
                            usedObject.shoetypecode = MainForm.m_PatchLoaderForm.CrossReference("Shoes", usedObject.shoetypecode);
                        if (PatchedObject.s_CountryCrossReferenceRequired)
                            usedObject.nationality = MainForm.m_PatchLoaderForm.CrossReference("Country", usedObject.nationality);
                        usedObject.LinkCountry(FifaEnvironment.Countries);
                        break;
                    }
                    ++index1;
                    if (index1 == PatchedObject.s_PlayersTable.Records.Length)
                        index1 = 0;
                }
            }
            if (MainForm.m_PatchLoaderForm.checkPlayerHead.Checked)
            {
                if (FifaEnvironment.Year == 14)
                {
                    string str1 = Player.SpecificEyesTextureFileName(this.m_Id);
                    string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                    if (File.Exists(str2))
                        usedObject.SetEyesTextures(str2);
                }
                string str3 = Player.SpecificFaceTextureFileName(this.m_Id);
                string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
                if (File.Exists(str4))
                {
                    usedObject.SetFaceTextures(str4);
                    switch (FifaEnvironment.Year)
                    {
                        case 14:
                            usedObject.ConvertFaceTexturesFrom15To14();
                            break;
                        case 15:
                            usedObject.ConvertFaceTexturesFrom14To15();
                            break;
                    }
                }
                string str5 = Player.SpecificHeadModelFileName(this.m_Id);
                string str6 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str5;
                if (File.Exists(str6))
                    usedObject.SetHeadModel(str6);
                if (FifaEnvironment.Year == MainForm.m_PatchLoaderForm.PatchYear)
                {
                    string str1 = Player.SpecificHairTexturesFileName(this.m_Id);
                    string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                    if (File.Exists(str2))
                        usedObject.SetHairTextures(str2);
                    string str7 = Player.SpecificHairModelFileName(this.m_Id);
                    string str8 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str7;
                    if (File.Exists(str8))
                        usedObject.SetHairModel(str8);
                    string str9 = Player.SpecificHairLodModelFileName(this.m_Id);
                    string str10 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str9;
                    if (File.Exists(str10))
                        usedObject.SetHairLodModel(str10);
                }
            }
            if (!MainForm.m_PatchLoaderForm.checkPlayerMiniface.Checked)
                return;
            string str11 = Player.SpecificPhotoDdsFileName(this.m_Id);
            string str12 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str11;
            if (!File.Exists(str12))
                return;
            Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str12);
            usedObject.SetPhoto(bitmapFromDdsFile);
        }

        private void ImportTeam()
        {
            Team usedObject = (Team)this.GetUsedObject();
            if (usedObject == null)
                return;
            if (MainForm.m_PatchLoaderForm.checkTeamDatabase.Checked)
            {
                if (PatchedObject.s_TeamsTable != null)
                {
                    foreach (Record record in PatchedObject.s_TeamsTable.Records)
                    {
                        if (record.IntField[FI.teams_teamid] == this.m_Id)
                        {
                            usedObject.Load(record);
                            if (PatchedObject.s_BallCrossReferenceRequired)
                                usedObject.balltype = MainForm.m_PatchLoaderForm.CrossReference("Ball", usedObject.balltype);
                            if (PatchedObject.s_AdboardCrossReferenceRequired)
                                usedObject.adboardid = MainForm.m_PatchLoaderForm.CrossReference("Adboard", usedObject.adboardid);
                            if (PatchedObject.s_TeamCrossReferenceRequired)
                                usedObject.rivalteamId = MainForm.m_PatchLoaderForm.CrossReference("Team", usedObject.rivalteamId);
                            usedObject.LinkTeam(FifaEnvironment.Teams);
                            if (PatchedObject.s_PlayerCrossReferenceRequired)
                            {
                                usedObject.captainid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.captainid);
                                usedObject.penaltytakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.penaltytakerid);
                                usedObject.freekicktakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.freekicktakerid);
                                usedObject.longkicktakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.longkicktakerid);
                                usedObject.leftcornerkicktakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.leftcornerkicktakerid);
                                usedObject.rightcornerkicktakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.rightcornerkicktakerid);
                                if (FifaEnvironment.Year > 14)
                                {
                                    usedObject.leftfreekicktakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.leftfreekicktakerid);
                                    usedObject.rightcornerkicktakerid = MainForm.m_PatchLoaderForm.CrossReference("Player", usedObject.rightcornerkicktakerid);
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                    }
                }
                if (PatchedObject.s_TeamstadiumlinksTable != null)
                {
                    foreach (Record record in PatchedObject.s_TeamstadiumlinksTable.Records)
                    {
                        if (record.IntField[FI.teamstadiumlinks_teamid] == this.m_Id)
                        {
                            usedObject.FillFromTeamStadiumLinks(record);
                            usedObject.Stadiumid = MainForm.m_PatchLoaderForm.CrossReference("Stadium", record.IntField[FI.teamstadiumlinks_stadiumid]);
                            usedObject.LinkStadium(FifaEnvironment.Stadiums);
                            break;
                        }
                    }
                }
                if (PatchedObject.s_StadiumassignmentsTable != null)
                {
                    foreach (Record record in PatchedObject.s_StadiumassignmentsTable.Records)
                    {
                        if (record.IntField[FI.stadiumassignments_teamid] == this.m_Id)
                        {
                            usedObject.FillFromStadiumAssignments(record);
                            break;
                        }
                    }
                }
                if (PatchedObject.s_ManagerTable != null)
                {
                    foreach (Record record in PatchedObject.s_ManagerTable.Records)
                    {
                        if (record.IntField[FI.manager_teamid] == this.m_Id)
                        {
                            usedObject.FillFromManager(record);
                            break;
                        }
                    }
                }
                if (PatchedObject.s_TeamformationteamstylelinkTable != null)
                {
                    foreach (Record record in PatchedObject.s_TeamformationteamstylelinkTable.Records)
                    {
                        if (record.IntField[FI.teamstadiumlinks_teamid] == this.m_Id)
                        {
                            usedObject.FillFromTeamFormationLinks(record);
                            usedObject.formationid = MainForm.m_PatchLoaderForm.CrossReference("Formation", record.IntField[FI.teamformationteamstylelinks_formationid]);
                            usedObject.LinkFormation(FifaEnvironment.Formations);
                            break;
                        }
                    }
                }
                if (PatchedObject.s_TeamplayerlinksTable != null)
                {
                    usedObject.Roster.ResetToEmpty();
                    foreach (Record record in PatchedObject.s_TeamplayerlinksTable.Records)
                    {
                        if (record.IntField[FI.teamplayerlinks_teamid] == this.m_Id)
                        {
                            int id = record.IntField[FI.teamplayerlinks_playerid];
                            if (PatchedObject.s_PlayerCrossReferenceRequired)
                                id = MainForm.m_PatchLoaderForm.CrossReference("Player", id);
                            Player player = (Player)FifaEnvironment.Players.SearchId(id);
                            if (player != null)
                            {
                                player.PlayFor(usedObject);
                                TeamPlayer teamPlayer = new TeamPlayer(record, player, usedObject);
                                if (teamPlayer != null)
                                    usedObject.Roster.Add((object)teamPlayer);
                                usedObject.LinkPlayer(FifaEnvironment.Players);
                            }
                        }
                    }
                    if (usedObject.IsClub())
                    {
                        for (int index1 = 0; index1 < usedObject.Roster.Count; ++index1)
                        {
                            Player player = ((TeamPlayer)usedObject.Roster[index1]).Player;
                            bool flag = false;
                            foreach (Team playingForTeam in (ArrayList)player.m_PlayingForTeams)
                            {
                                if (playingForTeam.IsClub() && playingForTeam != usedObject)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                for (int index2 = 0; index2 < player.m_PlayingForTeams.Count; ++index2)
                                {
                                    Team playingForTeam = (Team)player.m_PlayingForTeams[index2];
                                    if (playingForTeam.IsClub() && playingForTeam != usedObject)
                                    {
                                        if (MainForm.m_PatchLoaderForm.radioTransferToNewTeam.Checked)
                                        {
                                            playingForTeam.RemoveTeamPlayer(player);
                                            break;
                                        }
                                        if (MainForm.m_PatchLoaderForm.radioLeaveInExistingTeam.Checked)
                                        {
                                            usedObject.RemoveTeamPlayer(player);
                                            --index1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (PatchedObject.s_NationsTable != null)
                {
                    foreach (Record record in PatchedObject.s_NationsTable.Records)
                    {
                        if (record.IntField[FI.nations_teamid] == this.m_Id)
                        {
                            //usedObject.FillFromNations(record);
                            //if (PatchedObject.s_TeamCrossReferenceRequired)
                            //    usedObject.countryid_IfNationalTeam = MainForm.m_PatchLoaderForm.CrossReference("Team", usedObject.countryid_IfNationalTeam);
                            //usedObject.LinkCountry(FifaEnvironment.Countries);
                            break;
                        }
                    }
                }
                if (PatchedObject.s_RowteamnationlinksTable != null)
                {
                    foreach (Record record in PatchedObject.s_RowteamnationlinksTable.Records)
                    {
                        if (record.IntField[FI.rowteamnationlinks_teamid] == this.m_Id)
                        {
                            usedObject.FillFromRowTeamNationLinks(record);
                            //if (PatchedObject.s_TeamCrossReferenceRequired)
                            //    usedObject.m_countryid_IfRowTeam = MainForm.m_PatchLoaderForm.CrossReference("Team", usedObject.m_countryid_IfRowTeam);
                            //usedObject.LinkCountry(FifaEnvironment.Countries);
                            League.GetDefaultLeague().AddTeam(usedObject);
                            break;
                        }
                    }
                }
                if (PatchedObject.s_Language != null)
                {
                    usedObject.TeamNameFull = PatchedObject.s_Language.GetTeamString(this.m_Id, Language.ETeamStringType.Full);
                    usedObject.TeamNameAbbr15 = PatchedObject.s_Language.GetTeamString(this.m_Id, Language.ETeamStringType.Abbr15);
                    usedObject.TeamNameAbbr10 = PatchedObject.s_Language.GetTeamString(this.m_Id, Language.ETeamStringType.Abbr10);
                    usedObject.TeamNameAbbr7 = PatchedObject.s_Language.GetTeamString(this.m_Id, Language.ETeamStringType.Abbr7);
                    usedObject.TeamNameAbbr3 = PatchedObject.s_Language.GetTeamString(this.m_Id, Language.ETeamStringType.Abbr3);
                }
            }
            if (MainForm.m_PatchLoaderForm.checkTeamLogo.Checked)
            {
                string str1 = Team.CrestDdsFileName(this.m_Id, MainForm.m_PatchLoaderForm.PatchYear);
                string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                if (File.Exists(str2))
                {
                    Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str2);
                    usedObject.SetCrest(bitmapFromDdsFile);
                    usedObject.SetCrestDark(bitmapFromDdsFile);
                }
                string str3 = Team.Crest50DdsFileName(this.m_Id, MainForm.m_PatchLoaderForm.PatchYear);
                string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
                if (File.Exists(str4))
                {
                    Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str4);
                    usedObject.SetCrest50(bitmapFromDdsFile);
                    usedObject.SetCrest50Dark(bitmapFromDdsFile);
                }
                string str5 = Team.Crest32DdsFileName(this.m_Id, MainForm.m_PatchLoaderForm.PatchYear);
                string str6 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str5;
                if (File.Exists(str6))
                {
                    Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str6);
                    usedObject.SetCrest32(bitmapFromDdsFile);
                    usedObject.SetCrest32Dark(bitmapFromDdsFile);
                }
                string str7 = Team.Crest16DdsFileName(this.m_Id, MainForm.m_PatchLoaderForm.PatchYear);
                string str8 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str7;
                if (File.Exists(str8))
                {
                    Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str8);
                    usedObject.SetCrest16(bitmapFromDdsFile);
                    usedObject.SetCrest16Dark(bitmapFromDdsFile);
                }
            }
            if (MainForm.m_PatchLoaderForm.checkTeamBanner.Checked)
            {
                string str1 = Team.BannerFileName(this.m_Id);
                string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                if (File.Exists(str2))
                    usedObject.SetBanner(str2);
            }
            if (!MainForm.m_PatchLoaderForm.checkTeamFlags.Checked)
                return;
            string str9 = Team.FlagFileName(this.m_Id);
            string str10 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str9;
            if (!File.Exists(str10))
                return;
            usedObject.SetFlags(str10);
        }

        public int ConvertFormationTo08(int id07)
        {
            if (id07 <= 20)
            {
                int id = PatchedObject.c_FormationSwitchTable[id07];
                if (FifaEnvironment.Formations.SearchId(id) != null)
                    return id;
            }
            return FifaEnvironment.Formations.GetNewId();
        }

        private void ImportLeague()
        {
            League usedObject = (League)this.GetUsedObject();
            if (usedObject == null)
                return;
            if (MainForm.m_PatchLoaderForm.checkLeagueDatabase.Checked)
            {
                if (PatchedObject.s_LeaguesTable != null)
                {
                    foreach (Record record in PatchedObject.s_LeaguesTable.Records)
                    {
                        if (record.IntField[FI.leagues_leagueid] == this.m_Id)
                        {
                            usedObject.Load(record);
                            if (PatchedObject.s_CountryCrossReferenceRequired)
                                usedObject.countryid = MainForm.m_PatchLoaderForm.CrossReference("Country", record.IntField[FI.leagues_countryid]);
                            usedObject.LinkCountry(FifaEnvironment.Countries);
                            if (PatchedObject.s_Language != null)
                            {
                                usedObject.ShortName = PatchedObject.s_Language.GetLeagueString(this.m_Id, Language.ELeagueStringType.Abbr15);
                                usedObject.LongName = PatchedObject.s_Language.GetLeagueString(this.m_Id, Language.ELeagueStringType.Full);
                                if (usedObject.LongName == null)
                                    usedObject.LongName = usedObject.ShortName;
                                if (usedObject.ShortName == null)
                                {
                                    usedObject.ShortName = usedObject.LongName;
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                    }
                }
                if (PatchedObject.s_BoardOutcomesTable != null)
                {
                    foreach (Record record in PatchedObject.s_BoardOutcomesTable.Records)
                    {
                        if (record.IntField[FI.career_boardoutcomes_leagueid] == this.m_Id)
                            usedObject.FillFromBoardOutcomes(record);
                    }
                }
                if (PatchedObject.s_LeagueteamlinksTable != null)
                {
                    usedObject.PlayingTeams.Clear();
                    foreach (Record record in PatchedObject.s_LeagueteamlinksTable.Records)
                    {
                        if (record.IntField[FI.leagueteamlinks_leagueid] == this.m_Id)
                        {
                            int id = record.IntField[FI.leagueteamlinks_teamid];
                            if (PatchedObject.s_TeamCrossReferenceRequired)
                                id = MainForm.m_PatchLoaderForm.CrossReference("Team", id);
                            Team team = (Team)FifaEnvironment.Teams.SearchId(id);
                            if (team != null)
                            {
                                usedObject.PlayingTeams.InsertId((IdObject)team);
                                if (team.League != null && team.League != usedObject)
                                    team.League.RemoveTeam(team);
                                team.League = usedObject;
                                if (team.League.Country == null)
                                    team.League.Country = usedObject.Country;
                                team.FillFromLeagueTeamLinks(record);
                                team.LinkLeague(FifaEnvironment.Leagues);
                            }
                        }
                    }
                }
            }
            if (!MainForm.m_PatchLoaderForm.checkLeagueLogo.Checked)
                return;
            string str1 = League.TinyLogoDdsFileName(this.m_Id, MainForm.m_PatchLoaderForm.PatchYear);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (File.Exists(str2))
            {
                Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str2);
                usedObject.SetTinyLogo(bitmapFromDdsFile);
                usedObject.SetTinyLogoDark(bitmapFromDdsFile);
            }
            string str3 = League.AnimLogoDdsFileName(this.m_Id, MainForm.m_PatchLoaderForm.PatchYear);
            string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
            if (File.Exists(str4))
            {
                Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str4);
                usedObject.SetAnimLogo(bitmapFromDdsFile);
                usedObject.SetAnimLogoDark(bitmapFromDdsFile);
            }
            string str5 = League.SmallLogoDdsFileName(this.m_Id);
            string str6 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str5;
            if (File.Exists(str6))
            {
                Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str6);
                usedObject.SetSmallLogo(bitmapFromDdsFile);
                usedObject.SetSmallLogoDark(bitmapFromDdsFile);
            }
            string str7 = League.Logo512x128DdsFileName(this.m_Id);
            string str8 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str7;
            if (!File.Exists(str8))
                return;
            Bitmap bitmapFromDdsFile1 = FifaEnvironment.GetBitmapFromDdsFile(str8);
            usedObject.SetLogo512x128(bitmapFromDdsFile1);
            usedObject.SetLogo512x128Dark(bitmapFromDdsFile1);
        }

        private void ImportCountry()
        {
            Country usedObject = (Country)this.GetUsedObject();
            if (usedObject == null)
                return;
            if (MainForm.m_PatchLoaderForm.checkCountryDatabase.Checked && PatchedObject.s_NationsTable != null)
            {
                foreach (Record record in PatchedObject.s_NationsTable.Records)
                {
                    if (record.IntField[FI.nations_nationid] == this.m_Id)
                    {
                        usedObject.Load(record);
                        if (PatchedObject.s_TeamCrossReferenceRequired)
                            usedObject.NationalTeamId = MainForm.m_PatchLoaderForm.CrossReference("Team", usedObject.NationalTeamId);
                        usedObject.LinkTeam(FifaEnvironment.Teams);
                        break;
                    }
                }
                if (PatchedObject.s_Language != null)
                {
                    string countryString = PatchedObject.s_Language.GetCountryString(this.m_Id, Language.ECountryStringType.Full);
                    if (countryString != null)
                        usedObject.LanguageName = countryString;
                }
            }
            if (MainForm.m_PatchLoaderForm.checkCountryFlag.Checked)
            {
                string str1 = Country.FlagBigFileName(this.m_Id);
                string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                if (File.Exists(str2))
                {
                    Bitmap bitmapFromBigFile = FifaEnvironment.GetBitmapFromBigFile(str2);
                    usedObject.SetFlag(bitmapFromBigFile);
                }
                string str3 = Country.MiniFlagBigFileName(this.m_Id);
                string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
                if (File.Exists(str4))
                {
                    Bitmap bitmapFromBigFile = FifaEnvironment.GetBitmapFromBigFile(str4);
                    usedObject.SetMiniFlag(bitmapFromBigFile);
                }
                string str7 = Country.Flag512DdsFileName(this.m_Id);
                string str8 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str7;
                if (File.Exists(str8))
                {
                    Bitmap bitmapFromDdsFile = FifaEnvironment.GetBitmapFromDdsFile(str8);
                    usedObject.SetFlag512(bitmapFromDdsFile);
                }
            }
            if (!MainForm.m_PatchLoaderForm.checkCountryMap.Checked)
                return;
            string str9 = Country.ShapeFileName(this.m_Id);
            string str10 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str9;
            if (!File.Exists(str10))
                return;
            Bitmap bitmapFromDdsFile1 = FifaEnvironment.GetBitmapFromDdsFile(str10);
            usedObject.SetShape(bitmapFromDdsFile1);
        }

        private void ImportReferee()
        {
            Referee usedObject = (Referee)this.GetUsedObject();
            if (usedObject == null || PatchedObject.s_RefereeTable == null)
                return;
            foreach (Record record in PatchedObject.s_RefereeTable.Records)
            {
                if (record.IntField[FI.referee_refereeid] == this.m_Id)
                {
                    usedObject.Load(record);
                    usedObject.LinkLeague(FifaEnvironment.Leagues);
                    if (PatchedObject.s_CountryCrossReferenceRequired)
                        usedObject.nationalitycode = MainForm.m_PatchLoaderForm.CrossReference("Country", usedObject.nationalitycode);
                    usedObject.LinkCountry(FifaEnvironment.Countries);
                    break;
                }
                if (FifaEnvironment.Year == 14 && MainForm.m_PatchLoaderForm.PatchYear == 14)
                {
                    string str1 = Referee.PhotoBigFileName(this.m_Id);
                    string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
                    if (File.Exists(str2))
                    {
                        Bitmap bitmapFromBigFile = FifaEnvironment.GetBitmapFromBigFile(str2);
                        usedObject.SetPhoto(bitmapFromBigFile);
                    }
                }
            }
        }

        private void ImportFormation()
        {
            Formation usedObject = (Formation)this.GetUsedObject();
            if (usedObject == null || PatchedObject.s_FormationsTable == null)
                return;
            foreach (Record record in PatchedObject.s_FormationsTable.Records)
            {
                if (record.IntField[FI.formations_formationid] == this.m_Id)
                {
                    usedObject.Load(record);
                    if (usedObject.teamid != -1)
                    {
                        if (PatchedObject.s_TeamCrossReferenceRequired)
                            usedObject.teamid = MainForm.m_PatchLoaderForm.CrossReference("Team", usedObject.teamid);
                        usedObject.LinkTeam(FifaEnvironment.Teams);
                        if (usedObject.Team != null)
                        {
                            usedObject.Team.formationid = usedObject.Id;
                            usedObject.Team.LinkFormation(FifaEnvironment.Formations);
                        }
                    }
                    usedObject.LinkRoles(FifaEnvironment.Roles);
                    break;
                }
            }
        }

        private void ImportBall()
        {
            Ball usedObject = (Ball)this.GetUsedObject();
            if (usedObject == null)
                return;
            string str1 = Ball.BallTextureFileNameList(this.m_Id)[0];
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (File.Exists(str2))
                usedObject.SetBallTextures(str2);
            string str3 = Ball.BallModelFileName(this.m_Id);
            string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
            if (File.Exists(str4))
                usedObject.SetBallModel(str4);
            Bitmap bitmap = (Bitmap)null;
            if (MainForm.m_PatchLoaderForm.PatchYear == 14)
            {
                string str5 = Ball.BallPictureBigFileName(this.m_Id);
                string str6 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str5;
                if (File.Exists(str6))
                    bitmap = FifaEnvironment.GetBitmapFromBigFile(str6);
            }
            else
            {
                string str5 = Ball.BallDdsFileName(this.m_Id);
                string str6 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str5;
                if (File.Exists(str6))
                    bitmap = FifaEnvironment.GetBitmapFromDdsFile(str6);
            }
            if (bitmap != null)
                usedObject.SetBallPicture(bitmap);
            if (PatchedObject.s_Language == null)
                return;
            usedObject.Name = PatchedObject.s_Language.GetBallName(this.m_Id, out bool _);
        }

        private void ImportAdboard()
        {
            Adboard usedObject = (Adboard)this.GetUsedObject();
            if (usedObject == null)
                return;
            string str1 = Adboard.AdboardFileName(this.m_Id);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (!File.Exists(str2))
                return;
            Adboard.SetAdboard(usedObject.Id, str2);
        }

        private void ImportNumberFont()
        {
            if ((NumberFont)this.GetUsedObject() == null)
                return;
            int styleId = this.m_Id / 20;
            int colorId = this.m_Id - 20 * styleId;
            string str1 = NumberFont.NumberFontFileName(styleId, colorId, null);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (!File.Exists(str2))
                return;
            int style = this.m_ImportId / 20;
            int color = this.m_ImportId - 20 * style;
            NumberFont.SetNumberFont(style, color, str2);
        }

        private void ImportNameFont()
        {
            if ((NameFont)this.GetUsedObject() == null)
                return;
            string str1 = NameFont.NameFontFileName(this.m_Id);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (!File.Exists(str2))
                return;
            NameFont.Import(this.m_ImportId, str2);
        }

        private void ImportShoes()
        {
            if ((Shoes)this.GetUsedObject() == null)
                return;
            string str1 = Shoes.ShoesTexturesFileName(this.m_Id, 0);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (File.Exists(str2))
                Shoes.SetShoesTextures(this.m_ImportId, 0, str2);
            string str3 = Shoes.ShoesModelFileName(this.m_Id);
            string str4 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str3;
            if (!File.Exists(str4))
                return;
            Shoes.SetShoesModel(this.m_ImportId, str4);
        }

        private void ImportNet()
        {
            if ((Net)this.GetUsedObject() == null)
                return;
            string str1 = Net.NetFileName(this.m_Id);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (!File.Exists(str2))
                return;
            Net.SetNet(this.m_ImportId, str2);
        }

        private void ImportGkGloves()
        {
            if ((GkGloves)this.GetUsedObject() == null)
                return;
            string str1 = GkGloves.GkGlovesTextureFileName(this.m_Id);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (!File.Exists(str2))
                return;
            GkGloves.SetGkGlovesTextures(this.m_ImportId, str2);
        }

        private void ImportMowingPattern()
        {
            if ((MowingPattern)this.GetUsedObject() == null)
                return;
            string str1 = MowingPattern.MowingPatternFileName(this.m_Id);
            string str2 = MainForm.m_PatchLoaderForm.m_TempFolder + "\\" + str1;
            if (!File.Exists(str2))
                return;
            MowingPattern.SetMowingPattern(this.m_ImportId, str2);
        }

        public enum EUsedObject
        {
            Undefined,
            UseCms,
            UseNew,
            UseFitting,
        }
    }
}
