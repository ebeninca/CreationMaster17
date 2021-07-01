// Original code created by Rinaldo

using System;
using System.Reflection;

namespace FifaLibrary
{
  public class IdObject
  {
    private int m_Id;

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

    public IdObject()
    {
      this.m_Id = -1;
    }

    public IdObject(int id)
    {
      this.m_Id = id;
    }

    public virtual IdObject Clone(int newId)
    {
      IdObject idObject = (IdObject) this.MemberwiseClone();
      idObject.Id = newId;
      return idObject;
    }

    public virtual bool Delete()
    {
      return true;
    }

    public static IdObject Create(Type type, int newId)
    {
      Type[] types = new Type[1]{ typeof (int) };
      object[] parameters = new object[1]{ (object) newId };
      ConstructorInfo constructor = type.GetConstructor(types);
      return constructor == (ConstructorInfo) null ? (IdObject) null : (IdObject) constructor.Invoke(parameters);
    }
  }
}
