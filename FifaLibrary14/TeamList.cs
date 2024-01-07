// Original code created by Rinaldo

using System;
using System.Collections;
using System.Collections.Generic;

namespace FifaLibrary
{
    public class TeamList : IdArrayList
    {
        public TeamList(Type teamType)
          : base(teamType)
        {
        }

        public TeamList()
          : base(typeof(Team))
        {
        }

        public TeamList(DbFile fifaDbFile)
          : base(typeof(Team))
        {
            this.Load(fifaDbFile);
        }

        public void Load(DbFile fifaDbFile)
        {
            int minId = 130010;
            int maxId = 200000;
            this.Load(fifaDbFile.Table[TI.teams], minId, maxId);
            //this.FillFromNations(fifaDbFile.Table[TI.nations]);
            this.FillFromStadiumAssignments(fifaDbFile.Table[TI.stadiumassignments]);
            this.FillFromManager(fifaDbFile.Table[TI.manager]);
            this.FillFromTeamStadiumLinks(fifaDbFile.Table[TI.teamstadiumlinks]);
            this.FillFromTeamkits(fifaDbFile.Table[TI.teamkits]);
            this.FillFromTeamFormationLinks(fifaDbFile.Table[TI.teamformationteamstylelinks]);
            this.FillFromFormations(fifaDbFile.Table[TI.formations]);
            this.FillFromLeagueTeamLinks(fifaDbFile.Table[TI.leagueteamlinks]);
            this.FillFromRowTeamNationLinks(fifaDbFile.Table[TI.rowteamnationlinks]);
        }

        private void Load(Table t, int minId, int maxId)
        {
            this.MinId = minId;
            this.MaxId = maxId;
            Team[] teamArray = new Team[t.NRecords];
            this.Clear();
            for (int index = 0; index < t.NRecords; ++index)
                teamArray[index] = new Team(t.Records[index]);
            this.AddRange((ICollection)teamArray);
            this.SortId();
        }

        public void FillFromStadiumAssignments(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.stadiumassignments_teamid]))?.FillFromStadiumAssignments(record);
            }
        }

        public void FillFromManager(Table t)
        {
            for (int index = 0; index < t.NValidRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.manager_teamid]))?.FillFromManager(record);
            }
        }

        public void FillFromTeamStadiumLinks(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.teamstadiumlinks_teamid]))?.FillFromTeamStadiumLinks(record);
            }
        }

        public void FillFromTeamkits(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.teamkits_teamtechid]))?.FillFromTeamkits(record);
            }
        }

        public void FillFromFormations(Table t)
        {
            for (int index = 0; index < t.NValidRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.formations_teamid]))?.FillFromFormations(record);
            }
        }

        public void FillFromTeamFormationLinks(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.teamformationteamstylelinks_teamid]))?.FillFromTeamFormationLinks(record);
            }
        }

        /*public void FillFromNations(Table t)
        {
            foreach (Team team in (ArrayList)this)
            {
                for (int index = 0; index < t.NRecords; ++index)
                {
                    Record record = t.Records[index];
                    string fullName = FifaEnvironment.Language.GetCountryString(record.IntField[FI.nations_nationid], Language.ECountryStringType.Full);
                    if (team.DatabaseName.Equals(record.StringField[FI.nations_nationname]) || team.DatabaseName.Equals(fullName))
                    {
                        team.FillFromNations(record);
                        break;
                    }
                }
            }

        }*/

        public void FillFromLeagueTeamLinks(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.leagueteamlinks_teamid]))?.FillFromLeagueTeamLinks(record);
            }
        }

        public void FillFromRivals(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                Team team1 = (Team)this.SearchId(record.IntField[FI.rivals_teamid1]);
                Team team2 = (Team)this.SearchId(record.IntField[FI.rivals_teamid2]);
                if (team1 != null)
                    ;
            }
        }

        public void FillFromRowTeamNationLinks(Table t)
        {
            for (int index = 0; index < t.NRecords; ++index)
            {
                Record record = t.Records[index];
                ((Team)this.SearchId(record.IntField[FI.rowteamnationlinks_teamid]))?.FillFromRowTeamNationLinks(record);
            }
        }

        public void FillFromTeamPlayerLinks(DbFile fifaDbFile)
        {
            this.FillFromTeamPlayerLinks(fifaDbFile.Table[TI.teamplayerlinks]);
        }

        public void FillFromTeamPlayerLinks(Table t)
        {
            if (FifaEnvironment.Players == null)
                return;
            for (int index = 0; index < t.NValidRecords; ++index)
            {
                Record record = t.Records[index];
                int num1 = record.IntField[FI.teamplayerlinks_teamid];
                Team team = (Team)this.SearchId(num1);
                if (team == null)
                {
                    int num2 = (int)FifaEnvironment.UserMessages.ShowMessage(5016, num1);
                }
                else
                {
                    int num3 = record.IntField[FI.teamplayerlinks_playerid];
                    Player player = (Player)FifaEnvironment.Players.SearchId(num3);
                    if (player == null)
                    {
                        int num4 = (int)FifaEnvironment.UserMessages.ShowMessage(5017, num3);
                    }
                    else
                    {
                        player.PlayFor(team);
                        TeamPlayer teamPlayer = new TeamPlayer(record, player, team);
                        team.Roster.Add((object)teamPlayer);
                    }
                }
            }
        }

        public void LinkKits(KitList kitList)
        {
            if (kitList == null)
                return;
            foreach (Team team in (ArrayList)this)
                team.LinkKits(kitList);
        }

        public void LinkBall(BallList ballList)
        {
            if (ballList == null)
                return;
            foreach (Team team in (ArrayList)this)
                team.LinkBall(ballList);
        }

        public void LinkStadiums(StadiumList stadiumList)
        {
            foreach (Team team in (ArrayList)this)
                team.LinkStadium(stadiumList);
        }

        public void LinkLeague(LeagueList leagueList)
        {
            foreach (Team team in (ArrayList)this)
                team.LinkLeague(leagueList);
        }

        public void LinkOpponent(TeamList teamList)
        {
            foreach (Team team in (ArrayList)this)
                team.LinkTeam(teamList);
        }

        //public void LinkCountry(CountryList countryList)
        //{
        //  foreach (Team team in (ArrayList)this)
        //    team.LinkCountry(countryList);
        //}

        public void LinkFormation(FormationList formationList)
        {
            foreach (Team team in (ArrayList)this)
                team.LinkFormation(formationList);
        }

        public void LinkPlayer(PlayerList playerList)
        {
            foreach (Team team in (ArrayList)this)
                team.LinkPlayer(playerList);
        }

        public void Save(DbFile fifaDbFile)
        {
            Table table1 = fifaDbFile.Table[TI.teams];
            Table table2 = fifaDbFile.Table[TI.teamstadiumlinks];
            Table table3 = fifaDbFile.Table[TI.stadiumassignments];
            Table table4 = fifaDbFile.Table[TI.manager];
            Table table5 = fifaDbFile.Table[TI.rowteamnationlinks];
            Table table6 = fifaDbFile.Table[TI.teamplayerlinks];
            Table table7 = fifaDbFile.Table[TI.teamformationteamstylelinks];
            Table table8 = (Table)null;
            if (TI.defaultteamdata >= 0)
                table8 = fifaDbFile.Table[TI.defaultteamdata];
            Table table9 = (Table)null;
            if (TI.default_teamsheets >= 0)
                table9 = fifaDbFile.Table[TI.default_teamsheets];
            table1.ResizeRecords(this.Count);
            table2.ResizeRecords(this.Count);
            table8?.ResizeRecords(this.Count);
            table9?.ResizeRecords(this.Count);
            int nRecordsRosters = 0;
            int nRecordsStadiums = 0;
            int nRecordsRowTeams = 0;
            int nRecordsFormations = 0;
            int nRecordsManagers = 0;
            int index1 = 0;
            foreach (Team team in (ArrayList)this)
            {
                Record record1 = table1.Records[index1];
                Record r1 = (Record)null;
                if (table8 != null)
                    r1 = table8.Records[index1];
                Record record2 = table2.Records[index1];
                Record r2 = (Record)null;
                if (table9 != null)
                    r2 = table9.Records[index1];
                ++index1;
                team.SaveTeam(record1);
                team.Roster.SortRoster();
                team.SaveDefaultTeamData(r1);
                team.SaveDefaultTeamsheets(r2);
                team.SaveTeamStadiumLinks(record2);
                team.SaveLangTable();
                nRecordsRosters += team.Roster.Count;
                if (team.stadiumcustomname != null)
                    ++nRecordsStadiums;
                if (team.ManagerSurname != null)
                    ++nRecordsManagers;
                if (team.Formation != null && team.Formation.IsGeneric())
                    ++nRecordsFormations;
                if (team.League != null && team.IsRowTeam)
                    ++nRecordsRowTeams;
            }
            table6.ResizeRecords(nRecordsRosters);
            table3.ResizeRecords(nRecordsStadiums);
            table5.ResizeRecords(nRecordsRowTeams);
            table7.ResizeRecords(nRecordsFormations);
            table4.ResizeRecords(nRecordsManagers);
            int indexRosters = 0;
            int indexStadiums = 0;
            int indexRowTeams = 0;
            int indexFormations = 0;
            int indexManagers = 0;
            int artificialkey = 0;
            foreach (Team team in (ArrayList)this)
            {
                foreach (TeamPlayer teamPlayer in (ArrayList)team.Roster)
                {
                    Record record = table6.Records[indexRosters];
                    ++indexRosters;
                    teamPlayer.Save(record, artificialkey);
                    ++artificialkey;
                }
                if (team.stadiumcustomname != null)
                {
                    Record record = table3.Records[indexStadiums];
                    ++indexStadiums;
                    team.SaveStadiumAssignment(record);
                }
                //if (team.League == League.GetDefaultLeague())
                if (team.League != null && team.IsRowTeam)
                {
                    Record record = table5.Records[indexRowTeams];
                    ++indexRowTeams;
                    team.SaveRowTeamNationLinks(record);
                }
                if (team.Formation != null && team.Formation.IsGeneric())
                {
                    Record record = table7.Records[indexFormations];
                    ++indexFormations;
                    team.SaveTeamFormationLinks(record);
                }
                if (team.ManagerSurname != null)
                {
                    Record record = table4.Records[indexManagers];
                    ++indexManagers;
                    team.SaveManager(record);
                }
            }
        }

        public override IdArrayList Filter(IdObject filter)
        {
            TeamList teamList = new TeamList();
            if (filter == null)
                return (IdArrayList)this;
            if (filter.GetType().Name == "League")
            {
                League league = (League)filter;
                for (int index = 0; index < this.Count; ++index)
                {
                    Team team = (Team)this[index];
                    if (team.League == league)
                        teamList.Add((object)team);
                }
                return (IdArrayList)teamList;
            }
            if (!(filter.GetType().Name == "Country"))
                return (IdArrayList)this;
            Country country = (Country)filter;
            for (int index = 0; index < this.Count; ++index)
            {
                Team team = (Team)this[index];
                if (team.League.Country == country)
                    teamList.Add((object)team);
            }
            return (IdArrayList)teamList;
        }

        public void DeleteTeam(Team team)
        {
            this.RemoveId((IdObject)team);
        }

        public Team FitTeam(string name)
        {
            foreach (Team team in (ArrayList)this)
            {
                if (team.DatabaseName == name)
                    return team;
            }
            return (Team)null;
        }

        public Team IsInTopLeague()
        {
            foreach (Team team in (ArrayList)this)
            {
                if (team.IsInTopLeague())
                    return team;
            }
            return (Team)null;
        }
    }
}
