// Original code created by Rinaldo

namespace FifaLibrary
{
  public class PlayerName : IdObject
  {
    private string m_Text;
    private bool m_IsOriginal;
    private bool m_IsUsed;
    private int m_CommentaryId;

    public string Text
    {
      get
      {
        return this.m_Text;
      }
      set
      {
        this.m_Text = value;
      }
    }

    public bool IsOriginal
    {
      get
      {
        return this.m_IsOriginal;
      }
      set
      {
        this.m_IsOriginal = value;
      }
    }

    public bool IsUsed
    {
      get
      {
        return this.m_IsUsed;
      }
      set
      {
        this.m_IsUsed = value;
      }
    }

    public int CommentaryId
    {
      get
      {
        return this.m_CommentaryId;
      }
      set
      {
        this.m_CommentaryId = value;
      }
    }

    public PlayerName(Record r)
      : base(r.IntField[FI.playernames_nameid])
    {
      this.Load(r);
    }

    public PlayerName(int id, string text, bool isUsed)
    {
      this.Id = id;
      this.m_Text = text;
      this.m_IsUsed = isUsed;
      this.m_IsOriginal = false;
      this.m_CommentaryId = 900000;
    }

    public void Load(Record r)
    {
      this.m_Text = r.CompressedString[FI.playernames_name];
      this.m_CommentaryId = r.IntField[FI.playernames_commentaryid];
      this.m_IsUsed = false;
      this.m_IsOriginal = false;
    }

    public void SavePlayerName(Record r)
    {
      r.IntField[FI.playernames_nameid] = this.Id;
      r.CompressedString[FI.playernames_name] = this.Text;
      r.IntField[FI.playernames_commentaryid] = this.m_CommentaryId;
    }
  }
}
