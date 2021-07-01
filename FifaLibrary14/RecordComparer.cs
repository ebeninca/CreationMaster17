// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class RecordComparer : IComparer
  {
    int IComparer.Compare(object x, object y)
    {
      Record record1 = (Record) x;
      Record record2 = (Record) y;
      TableDescriptor tableDescriptor = record1.TableDescriptor;
      for (int index1 = 0; index1 < tableDescriptor.NKeyFields; ++index1)
      {
        int index2 = tableDescriptor.KeyIndex[index1];
        if (record1.IntField[index2] != record2.IntField[index2])
          return record1.IntField[index2] <= record2.IntField[index2] ? -1 : 1;
      }
      return 0;
    }
  }
}
