// Original code created by Rinaldo

using System.Collections;

namespace FifaLibrary
{
  public class FieldComparer : IComparer
  {
    int IComparer.Compare(object x, object y)
    {
      FieldDescriptor fieldDescriptor1 = (FieldDescriptor) x;
      FieldDescriptor fieldDescriptor2 = (FieldDescriptor) y;
      if (fieldDescriptor1.BitOffset == fieldDescriptor2.BitOffset)
        return 0;
      return fieldDescriptor1.BitOffset <= fieldDescriptor2.BitOffset ? -1 : 1;
    }
  }
}
