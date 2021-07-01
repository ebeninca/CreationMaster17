// Original code created by Rinaldo

using System;
using System.Collections;

namespace FifaLibrary
{
  public class FormationList : IdArrayList
  {
    public FormationList()
      : base(typeof (Formation))
    {
    }

    public FormationList(Type type)
      : base(type)
    {
    }

    public FormationList(DbFile fifaDbFile)
      : base(typeof (Formation))
    {
      this.Load(fifaDbFile);
    }

    public FormationList(Table formationsTable, int minId, int maxId)
      : base(typeof (Formation))
    {
      this.Load(formationsTable, minId, maxId);
    }

    public void Load(DbFile fifaDbFile)
    {
      this.Load(FifaEnvironment.FifaDb.Table[TI.formations], 1, 899);
    }

    private void Load(Table formationsTable, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.Clear();
      for (int index = 0; index < formationsTable.NRecords; ++index)
        this.Add((object) new Formation(formationsTable.Records[index]));
      this.SortId();
    }

    public void Save(DbFile fifaDbFile)
    {
      this.Save(FifaEnvironment.FifaDb.Table[TI.formations]);
    }

    public void Save(Table formationsTable)
    {
      formationsTable.ResizeRecords(this.Count);
      int index = 0;
      foreach (Formation formation in (ArrayList) this)
      {
        Record record = formationsTable.Records[index];
        ++index;
        formation.Save(record);
      }
    }

    public void LinkTeam(TeamList teamList)
    {
      foreach (Formation formation in (ArrayList) this)
        formation.LinkTeam(teamList);
    }

    public Formation GetNearestFormation(Formation formation)
    {
      int num = 384;
      Formation formation1 = (Formation) null;
      foreach (Formation formation2 in (ArrayList) this)
      {
        if (formation2 != formation)
        {
          int distance = formation.ComputeDistance(formation2);
          if (distance < num)
          {
            num = distance;
            formation1 = formation2;
          }
        }
      }
      return formation1;
    }

    public Formation GetClosestFormation(Formation formation)
    {
      int num = 384;
      Formation formation1 = (Formation) null;
      foreach (Formation formation2 in (ArrayList) this)
      {
        if (formation2 != formation)
        {
          int similarity = formation.ComputeSimilarity(formation2);
          if (similarity < num)
          {
            num = similarity;
            formation1 = formation2;
          }
        }
      }
      return formation1;
    }

    public Formation GetExactFormation(Formation formation)
    {
      int num = 384;
      Formation formation1 = (Formation) null;
      foreach (Formation formation2 in (ArrayList) this)
      {
        if (formation2 != formation)
        {
          int distance = formation.ComputeDistance(formation2);
          if (distance < num)
          {
            num = distance;
            formation1 = formation2;
          }
        }
      }
      return num != 0 ? (Formation) null : formation1;
    }

    public Formation FitFormation(string name, int id)
    {
      foreach (Formation formation in (ArrayList) this)
      {
        if (formation.ToString() == name)
          return formation;
        if (formation.Team != null)
        {
          string str = formation.Team.DatabaseName + " ";
          if (name.StartsWith(str))
          {
            bool flag = true;
            for (int length = str.Length; length < name.Length; ++length)
            {
              if (name[length] != '-' && name[length] != '(' && (name[length] != ')' && name[length] != 'S') && (name[length] != 'W' && (name[length] < '0' || name[length] > '9')))
              {
                flag = false;
                break;
              }
            }
            if (flag)
              return formation;
          }
        }
      }
      return (Formation) null;
    }

    public void LinkRoles(RoleList roleList)
    {
      foreach (Formation formation in (ArrayList) this)
        formation.LinkRoles(roleList);
    }

    public Formation CreateNewFormation(int newId)
    {
      if (this.SearchId(newId) != null)
        return (Formation) null;
      Formation newId1 = (Formation) this.CreateNewId(newId);
      this.InsertId((IdObject) newId1);
      return newId1;
    }

    public Formation CreateNewFormation()
    {
      return (Formation) this.CreateNewId(this.GetNewId());
    }

    public override IdArrayList Filter(IdObject filter)
    {
      if (filter == null)
        return (IdArrayList) this;
      FormationList formationList = new FormationList();
      if (filter.GetType().Name == "League")
      {
        League league = (League) filter;
        for (int index = 0; index < this.Count; ++index)
        {
          Formation formation = (Formation) this[index];
          if (formation.Team != null && formation.Team.League == league)
            formationList.Add((object) formation);
        }
        return (IdArrayList) formationList;
      }
      if (filter.GetType().Name == "Country")
      {
        Country country = (Country) filter;
        for (int index = 0; index < this.Count; ++index)
        {
          Formation formation = (Formation) this[index];
          if (formation.Team != null && formation.Team.Country == country)
            formationList.Add((object) formation);
        }
        return (IdArrayList) formationList;
      }
      if (!(filter.GetType().Name == "Team") && !(filter.GetType().Name == "CareerTeam"))
        return (IdArrayList) this;
      Team team = (Team) filter;
      for (int index = 0; index < this.Count; ++index)
      {
        Formation formation = (Formation) this[index];
        if (formation.Team != null && formation.Team == team)
          formationList.Add((object) formation);
      }
      return (IdArrayList) formationList;
    }

    public bool DeleteFormation(Formation formation)
    {
      return this.RemoveId((IdObject) formation);
    }
  }
}
