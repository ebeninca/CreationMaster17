// Original code created by Rinaldo

using System;
using System.Collections;

namespace FifaLibrary
{
  public class Roster : ArrayList
  {
    private RosterComparer m_Comparer = new RosterComparer();

    public void SortRoster()
    {
      this.Sort((IComparer) this.m_Comparer);
    }

    public Roster(int capacity)
    {
      this.Capacity = capacity;
    }

    public Player SearchPlayer(int playerid)
    {
      for (int index = 0; index < this.Count; ++index)
      {
        if (playerid == ((TeamPlayer) this[index]).Player.Id)
          return ((TeamPlayer) this[index]).Player;
      }
      return (Player) null;
    }

    public TeamPlayer SearchTeamPlayer(Player player)
    {
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
      {
        if (player == teamPlayer.Player)
          return teamPlayer;
      }
      return (TeamPlayer) null;
    }

    public int GetTeamPosition(Player player)
    {
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
      {
        if (player == teamPlayer.Player)
          return teamPlayer.position;
      }
      return 29;
    }

    public int GetTeamPosition(int playerId)
    {
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
      {
        if (playerId == teamPlayer.Player.Id)
          return teamPlayer.position;
      }
      return 29;
    }

    public TeamPlayer SearchTeamPlayer(Role role)
    {
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
      {
        if (role.Id == teamPlayer.position)
          return teamPlayer;
      }
      return (TeamPlayer) null;
    }

    public TeamPlayer GetRoleBestPlayer(ERole requestedRole)
    {
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      int num = -1;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this)
      {
        if (teamPlayer2 != null)
        {
          int rolePerformance = teamPlayer2.Player.GetRolePerformance(requestedRole);
          if (rolePerformance > num)
          {
            num = rolePerformance;
            teamPlayer1 = teamPlayer2;
          }
        }
      }
      return teamPlayer1;
    }

    public TeamPlayer GetRoleBestTitolar(ERole requestedRole)
    {
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      int num = -1;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this)
      {
        if (teamPlayer2 != null && teamPlayer2.position < 28)
        {
          int rolePerformance = teamPlayer2.Player.GetRolePerformance(requestedRole);
          if (rolePerformance > num)
          {
            num = rolePerformance;
            teamPlayer1 = teamPlayer2;
          }
        }
      }
      return teamPlayer1;
    }

    public TeamPlayer GetBestTitolar()
    {
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      int num = -1;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this)
      {
        if (teamPlayer2 != null && teamPlayer2.position < 28)
        {
          int overallrating = teamPlayer2.Player.overallrating;
          if (overallrating > num)
          {
            num = overallrating;
            teamPlayer1 = teamPlayer2;
          }
        }
      }
      return teamPlayer1;
    }

    public TeamPlayer GetBestPlayer()
    {
      TeamPlayer teamPlayer1 = (TeamPlayer) null;
      int num = -1;
      foreach (TeamPlayer teamPlayer2 in (ArrayList) this)
      {
        if (teamPlayer2 != null)
        {
          int averageRoleAttribute = teamPlayer2.Player.GetAverageRoleAttribute();
          if (averageRoleAttribute > num)
          {
            num = averageRoleAttribute;
            teamPlayer1 = teamPlayer2;
          }
        }
      }
      return teamPlayer1;
    }

    public bool IsNumberFree(int n)
    {
      if (n < 1 || n > 99)
        return false;
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
      {
        if (teamPlayer.m_jerseynumber == n)
          return false;
      }
      return true;
    }

    public int GetFreeNumber()
    {
      for (int n = 1; n < 99; ++n)
      {
        if (this.IsNumberFree(n))
          return n;
      }
      return 99;
    }

    public string[] GetFreeNumbers()
    {
      string[] array = new string[99];
      int newSize = 0;
      for (int n = 1; n < 100; ++n)
      {
        if (this.IsNumberFree(n))
        {
          array[newSize] = n.ToString();
          ++newSize;
        }
      }
      Array.Resize<string>(ref array, newSize);
      return array;
    }

    public void ChangeRole(Role oldRole, Role newRole)
    {
      TeamPlayer teamPlayer = this.SearchTeamPlayer(oldRole);
      if (teamPlayer == null)
        return;
      teamPlayer.position = newRole.Id;
    }

    public int EstimateOverall()
    {
      int[] numArray = new int[17];
      int num1 = 0;
      for (int index = 0; index < 16; ++index)
        numArray[index] = 0;
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
      {
        int overallrating = teamPlayer.Player.overallrating;
        for (int index1 = 0; index1 < 16; ++index1)
        {
          if (overallrating > numArray[index1])
          {
            for (int index2 = num1; index2 > index1; --index2)
              numArray[index2] = numArray[index2 - 1];
            numArray[index1] = overallrating;
            if (num1 < 16)
            {
              ++num1;
              break;
            }
            break;
          }
        }
      }
      int num2 = 0;
      for (int index = 0; index < num1; ++index)
        num2 += numArray[index];
      return num1 == 0 ? 50 : num2 / num1;
    }

    public void ResetToEmpty()
    {
      foreach (TeamPlayer teamPlayer in (ArrayList) this)
        teamPlayer.Player.NotPlayFor(teamPlayer.Team);
      this.Clear();
    }
  }
}
