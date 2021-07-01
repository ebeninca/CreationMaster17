// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class RosterComparer : IComparer
  {
    int IComparer.Compare(object x, object y)
    {
      TeamPlayer teamPlayer1 = (TeamPlayer) x;
      TeamPlayer teamPlayer2 = (TeamPlayer) y;
      return teamPlayer1.position != teamPlayer2.position ? teamPlayer1.position - teamPlayer2.position : teamPlayer1.Player.preferredposition1 - teamPlayer2.Player.preferredposition1;
    }
  }
}
