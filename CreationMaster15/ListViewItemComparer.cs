// Original code created by Rinaldo

using System.Collections;
using System.Windows.Forms;

namespace CreationMaster
{
  internal class ListViewItemComparer : IComparer
  {
    private int col;
    private SortOrder m_SortOrder;

    public ListViewItemComparer()
    {
      this.col = 0;
    }

    public ListViewItemComparer(int column, SortOrder sortOrder)
    {
      this.col = column;
      this.m_SortOrder = sortOrder;
    }

    public int Compare(object x, object y)
    {
      return this.m_SortOrder == SortOrder.Ascending ? string.Compare(((ListViewItem) x).SubItems[this.col].Text, ((ListViewItem) y).SubItems[this.col].Text) : string.Compare(((ListViewItem) y).SubItems[this.col].Text, ((ListViewItem) x).SubItems[this.col].Text);
    }
  }
}
