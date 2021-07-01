// Original code created by Rinaldo

using System;
using System.Collections;

namespace FifaLibrary
{
  public class IdArrayList : ArrayList
  {
    private IdObjectComparer m_Comparer = new IdObjectComparer();
    private int m_MinId;
    private int m_MaxId;
    private Type m_Type;

    public int MinId
    {
      get
      {
        return this.m_MinId;
      }
      set
      {
        this.m_MinId = value;
      }
    }

    public int MaxId
    {
      get
      {
        return this.m_MaxId;
      }
      set
      {
        this.m_MaxId = value;
      }
    }

    public Type ObjectType
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

    public IdArrayList(Type type, int minId, int maxId)
    {
      this.m_Type = type;
      this.m_MinId = minId;
      this.m_MaxId = maxId;
    }

    public IdArrayList(Type type)
    {
      this.m_Type = type;
      this.m_MinId = 0;
      this.m_MaxId = -1;
    }

    public IdArrayList(int minId, int maxId)
    {
      this.m_Type = typeof (IdObject);
      this.m_MinId = minId;
      this.m_MaxId = maxId;
    }

    public IdArrayList()
    {
      this.m_Type = typeof (IdObject);
      this.m_MinId = -1;
      this.m_MaxId = 0;
    }

    public bool InsertId(IdObject idObject)
    {
      if (idObject == null)
        return false;
      int num = this.BinarySearch((object) idObject, (IComparer) this.m_Comparer);
      if (num >= 0)
        return false;
      this.Insert(~num, (object) idObject);
      return true;
    }

    public bool RemoveId(IdObject idObject)
    {
      int index = this.BinarySearch((object) idObject, (IComparer) this.m_Comparer);
      if (index < 0)
        return false;
      this.RemoveAt(index);
      return true;
    }

    public bool RemoveId(int id)
    {
      return this.RemoveId(new IdObject(id));
    }

    public void SortId()
    {
      this.Sort((IComparer) this.m_Comparer);
    }

    public bool DeleteId(IdObject idObject)
    {
      return this.RemoveId(idObject) && idObject.Delete();
    }

    public IdObject SearchId(int id)
    {
      return this.SearchId(new IdObject(id));
    }

    public IdObject SearchId(IdObject idObject)
    {
      int index = this.BinarySearch((object) idObject, (IComparer) this.m_Comparer);
      return index >= 0 ? (IdObject) this[index] : (IdObject) null;
    }

    public bool ChangeId(IdObject idObject, int newId)
    {
      int id = idObject.Id;
      if (!this.RemoveId(idObject))
        return false;
      idObject.Id = newId;
      if (this.InsertId(idObject))
        return true;
      idObject.Id = id;
      this.InsertId(idObject);
      return false;
    }

    public virtual int GetNewId()
    {
      int num = -1;
      for (int minId = this.m_MinId; minId <= this.m_MaxId; ++minId)
      {
        if (this.SearchId(minId) == null)
        {
          num = minId;
          break;
        }
      }
      return num;
    }

    public virtual int GetNextId(int minId)
    {
      int num = -1;
      for (int id = minId; id <= this.m_MaxId; ++id)
      {
        if (this.SearchId(id) == null)
        {
          num = id;
          break;
        }
      }
      return num;
    }

    public IdObject CreateNewId()
    {
      int newId = this.GetNewId();
      if (newId < 0)
        return (IdObject) null;
      IdObject idObject = IdObject.Create(this.m_Type, newId);
      this.InsertId(idObject);
      return idObject;
    }

    public IdObject CreateNewId(int newId)
    {
      if (this.SearchId(newId) != null)
        return (IdObject) null;
      IdObject idObject = IdObject.Create(this.m_Type, newId);
      this.InsertId(idObject);
      return idObject;
    }

    public IdObject CloneId(IdObject srcIdObject)
    {
      int newId = this.GetNewId();
      if (newId < 0)
        return (IdObject) null;
      IdObject idObject = srcIdObject.Clone(newId);
      this.InsertId(idObject);
      return idObject;
    }

    public IdObject CloneId(int srcId)
    {
      IdObject srcIdObject = this.SearchId(srcId);
      return srcIdObject == null ? (IdObject) null : this.CloneId(srcIdObject);
    }

    public IdObject CloneId(IdObject srcIdObject, int newId)
    {
      IdObject idObject = srcIdObject.Clone(newId);
      this.InsertId(idObject);
      return idObject;
    }

    public IdObject CloneId(IdObject srcIdObject, IdObject newObject)
    {
      IdObject idObject = srcIdObject.Clone(newObject.Id);
      this.RemoveId(newObject);
      this.InsertId(idObject);
      return idObject;
    }

    public virtual IdArrayList Filter(IdObject filterValue)
    {
      return this;
    }

    public virtual IdArrayList Filter(IdObject filterValue, bool flag)
    {
      return this;
    }
  }
}
