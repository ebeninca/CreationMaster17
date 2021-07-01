// Original code created by Rinaldo

namespace FifaLibrary
{
  public class CareerFormationList : FormationList
  {
    public CareerFormationList(CareerFile careerFile)
      : base(typeof (CareerFormation))
    {
      this.Load(careerFile);
    }

    public void Load(CareerFile careerFile)
    {
    }

    private void Load(Table formationsTable, int minId, int maxId)
    {
      this.MinId = minId;
      this.MaxId = maxId;
      this.Clear();
      for (int index = 0; index < formationsTable.NRecords; ++index)
        this.Add((object) new CareerFormation(formationsTable.Records[index]));
    }

    private void AdditionalLoad(Table formationsTable)
    {
      for (int index = 0; index < formationsTable.NRecords; ++index)
      {
        CareerFormation careerFormation1 = new CareerFormation(formationsTable.Records[index]);
        careerFormation1.IsInCareer = true;
        CareerFormation careerFormation2 = (CareerFormation) this.SearchId((IdObject) careerFormation1);
        if (careerFormation2 != null)
          this.RemoveId((IdObject) careerFormation2);
        this.InsertId((IdObject) careerFormation1);
      }
    }

    public void Save(DbFile dbFile, CareerFile careerFile)
    {
    }
  }
}
