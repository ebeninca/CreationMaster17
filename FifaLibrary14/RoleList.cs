// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class RoleList : IdArrayList
  {
    public RoleList()
      : base(typeof (Role))
    {
    }

    public RoleList(DbFile fifaDbFile)
      : base(typeof (Role))
    {
      this.Load(fifaDbFile);
    }

    public RoleList(Table boundingBoxTable)
      : base(typeof (Role))
    {
      this.Load(boundingBoxTable);
    }

    public void Load(DbFile fifaDbFile)
    {
      this.Load(FifaEnvironment.FifaDb.Table[TI.fieldpositionboundingboxes]);
    }

    public void Load(Table boundingBoxTable)
    {
      this.MinId = 0;
      this.MaxId = 32;
      this.Clear();
      for (int index = 0; index < boundingBoxTable.NRecords; ++index)
        this.Add((object) new Role(boundingBoxTable.Records[index]));
    }

    public void Save(DbFile fifaDbFile)
    {
      Table table = FifaEnvironment.FifaDb.Table[TI.fieldpositionboundingboxes];
      int index = 0;
      foreach (Role role in (ArrayList) this)
      {
        Record record = table.Records[index];
        ++index;
        role.Save(record);
      }
    }
  }
}
