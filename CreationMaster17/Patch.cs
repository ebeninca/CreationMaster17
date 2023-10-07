// Original code created by Rinaldo

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CreationMaster
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
  [HelpKeyword("vs.data.DataSet")]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [XmlRoot("Patch")]
  [Serializable]
  public class Patch : DataSet
  {
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;
    private Patch.PatchIdentityDataTable tablePatchIdentity;
    private Patch.PatchElementsDataTable tablePatchElements;

    [DebuggerNonUserCode]
    public Patch()
    {
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    protected Patch(SerializationInfo info, StreamingContext context)
      : base(info, context, false)
    {
      if (this.IsBinarySerialized(info, context))
      {
        this.InitVars(false);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
      else
      {
        string s = (string) info.GetValue("XmlSchema", typeof (string));
        if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
        {
          DataSet dataSet = new DataSet();
          dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
          if (dataSet.Tables[nameof (PatchIdentity)] != null)
            base.Tables.Add((DataTable) new Patch.PatchIdentityDataTable(dataSet.Tables[nameof (PatchIdentity)]));
          if (dataSet.Tables[nameof (PatchElements)] != null)
            base.Tables.Add((DataTable) new Patch.PatchElementsDataTable(dataSet.Tables[nameof (PatchElements)]));
          this.DataSetName = dataSet.DataSetName;
          this.Prefix = dataSet.Prefix;
          this.Namespace = dataSet.Namespace;
          this.Locale = dataSet.Locale;
          this.CaseSensitive = dataSet.CaseSensitive;
          this.EnforceConstraints = dataSet.EnforceConstraints;
          this.Merge(dataSet, false, MissingSchemaAction.Add);
          this.InitVars();
        }
        else
          this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        this.GetSerializationData(info, context);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    [DebuggerNonUserCode]
    public Patch.PatchIdentityDataTable PatchIdentity
    {
      get
      {
        return this.tablePatchIdentity;
      }
    }

    [DebuggerNonUserCode]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public Patch.PatchElementsDataTable PatchElements
    {
      get
      {
        return this.tablePatchElements;
      }
    }

    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DebuggerNonUserCode]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get
      {
        return this._schemaSerializationMode;
      }
      set
      {
        this._schemaSerializationMode = value;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [DebuggerNonUserCode]
    public new DataTableCollection Tables
    {
      get
      {
        return base.Tables;
      }
    }

    [DebuggerNonUserCode]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations
    {
      get
      {
        return base.Relations;
      }
    }

    [DebuggerNonUserCode]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    public override DataSet Clone()
    {
      Patch patch = (Patch) base.Clone();
      patch.InitVars();
      patch.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) patch;
    }

    [DebuggerNonUserCode]
    protected override bool ShouldSerializeTables()
    {
      return false;
    }

    [DebuggerNonUserCode]
    protected override bool ShouldSerializeRelations()
    {
      return false;
    }

    [DebuggerNonUserCode]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["PatchIdentity"] != null)
          base.Tables.Add((DataTable) new Patch.PatchIdentityDataTable(dataSet.Tables["PatchIdentity"]));
        if (dataSet.Tables["PatchElements"] != null)
          base.Tables.Add((DataTable) new Patch.PatchElementsDataTable(dataSet.Tables["PatchElements"]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
      {
        int num = (int) this.ReadXml(reader);
        this.InitVars();
      }
    }

    [DebuggerNonUserCode]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [DebuggerNonUserCode]
    internal void InitVars()
    {
      this.InitVars(true);
    }

    [DebuggerNonUserCode]
    internal void InitVars(bool initTable)
    {
      this.tablePatchIdentity = (Patch.PatchIdentityDataTable) base.Tables["PatchIdentity"];
      if (initTable && this.tablePatchIdentity != null)
        this.tablePatchIdentity.InitVars();
      this.tablePatchElements = (Patch.PatchElementsDataTable) base.Tables["PatchElements"];
      if (!initTable || this.tablePatchElements == null)
        return;
      this.tablePatchElements.InitVars();
    }

    [DebuggerNonUserCode]
    private void InitClass()
    {
      this.DataSetName = nameof (Patch);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/Patch.xsd";
      this.Locale = new CultureInfo("");
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablePatchIdentity = new Patch.PatchIdentityDataTable();
      base.Tables.Add((DataTable) this.tablePatchIdentity);
      this.tablePatchElements = new Patch.PatchElementsDataTable();
      base.Tables.Add((DataTable) this.tablePatchElements);
    }

    [DebuggerNonUserCode]
    private bool ShouldSerializePatchIdentity()
    {
      return false;
    }

    [DebuggerNonUserCode]
    private bool ShouldSerializePatchElements()
    {
      return false;
    }

    [DebuggerNonUserCode]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [DebuggerNonUserCode]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      Patch patch = new Patch();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = patch.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = patch.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            current.Write((Stream) memoryStream2);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return schemaComplexType;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return schemaComplexType;
    }

    public delegate void PatchIdentityRowChangeEventHandler(
      object sender,
      Patch.PatchIdentityRowChangeEvent e);

    public delegate void PatchElementsRowChangeEventHandler(
      object sender,
      Patch.PatchElementsRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable]
    public class PatchIdentityDataTable : DataTable, IEnumerable
    {
      private DataColumn columnName;
      private DataColumn columnVersion;
      private DataColumn columnDescription;
      private DataColumn columnChecksum;
      private DataColumn columnCMS;

      [DebuggerNonUserCode]
      public PatchIdentityDataTable()
      {
        this.TableName = "PatchIdentity";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      internal PatchIdentityDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      protected PatchIdentityDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      public DataColumn NameColumn
      {
        get
        {
          return this.columnName;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn VersionColumn
      {
        get
        {
          return this.columnVersion;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn DescriptionColumn
      {
        get
        {
          return this.columnDescription;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn ChecksumColumn
      {
        get
        {
          return this.columnChecksum;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn CMSColumn
      {
        get
        {
          return this.columnCMS;
        }
      }

      [Browsable(false)]
      [DebuggerNonUserCode]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      public Patch.PatchIdentityRow this[int index]
      {
        get
        {
          return (Patch.PatchIdentityRow) this.Rows[index];
        }
      }

      public event Patch.PatchIdentityRowChangeEventHandler PatchIdentityRowChanging;

      public event Patch.PatchIdentityRowChangeEventHandler PatchIdentityRowChanged;

      public event Patch.PatchIdentityRowChangeEventHandler PatchIdentityRowDeleting;

      public event Patch.PatchIdentityRowChangeEventHandler PatchIdentityRowDeleted;

      [DebuggerNonUserCode]
      public void AddPatchIdentityRow(Patch.PatchIdentityRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      public Patch.PatchIdentityRow AddPatchIdentityRow(
        string Name,
        string Version,
        string Description,
        int Checksum,
        string CMS)
      {
        Patch.PatchIdentityRow patchIdentityRow = (Patch.PatchIdentityRow) this.NewRow();
        object[] objArray = new object[5]
        {
          (object) Name,
          (object) Version,
          (object) Description,
          (object) Checksum,
          (object) CMS
        };
        patchIdentityRow.ItemArray = objArray;
        this.Rows.Add((DataRow) patchIdentityRow);
        return patchIdentityRow;
      }

      [DebuggerNonUserCode]
      public virtual IEnumerator GetEnumerator()
      {
        return this.Rows.GetEnumerator();
      }

      [DebuggerNonUserCode]
      public override DataTable Clone()
      {
        Patch.PatchIdentityDataTable identityDataTable = (Patch.PatchIdentityDataTable) base.Clone();
        identityDataTable.InitVars();
        return (DataTable) identityDataTable;
      }

      [DebuggerNonUserCode]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new Patch.PatchIdentityDataTable();
      }

      [DebuggerNonUserCode]
      internal void InitVars()
      {
        this.columnName = this.Columns["Name"];
        this.columnVersion = this.Columns["Version"];
        this.columnDescription = this.Columns["Description"];
        this.columnChecksum = this.Columns["Checksum"];
        this.columnCMS = this.Columns["CMS"];
      }

      [DebuggerNonUserCode]
      private void InitClass()
      {
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnVersion = new DataColumn("Version", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVersion);
        this.columnDescription = new DataColumn("Description", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription);
        this.columnCMS = new DataColumn("CMS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCMS);
      }

      [DebuggerNonUserCode]
      public Patch.PatchIdentityRow NewPatchIdentityRow()
      {
        return (Patch.PatchIdentityRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new Patch.PatchIdentityRow(builder);
      }

      [DebuggerNonUserCode]
      protected override Type GetRowType()
      {
        return typeof (Patch.PatchIdentityRow);
      }

      [DebuggerNonUserCode]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PatchIdentityRowChanged == null)
          return;
        this.PatchIdentityRowChanged((object) this, new Patch.PatchIdentityRowChangeEvent((Patch.PatchIdentityRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PatchIdentityRowChanging == null)
          return;
        this.PatchIdentityRowChanging((object) this, new Patch.PatchIdentityRowChangeEvent((Patch.PatchIdentityRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PatchIdentityRowDeleted == null)
          return;
        this.PatchIdentityRowDeleted((object) this, new Patch.PatchIdentityRowChangeEvent((Patch.PatchIdentityRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PatchIdentityRowDeleting == null)
          return;
        this.PatchIdentityRowDeleting((object) this, new Patch.PatchIdentityRowChangeEvent((Patch.PatchIdentityRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      public void RemovePatchIdentityRow(Patch.PatchIdentityRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        Patch patch = new Patch();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = patch.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PatchIdentityDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = patch.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable]
    public class PatchElementsDataTable : DataTable, IEnumerable
    {
      private DataColumn columnComment;
      private DataColumn columnType;
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnChecksum;

      [DebuggerNonUserCode]
      public PatchElementsDataTable()
      {
        this.TableName = "PatchElements";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      internal PatchElementsDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      protected PatchElementsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      public DataColumn CommentColumn
      {
        get
        {
          return this.columnComment;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn TypeColumn
      {
        get
        {
          return this.columnType;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn IDColumn
      {
        get
        {
          return this.columnID;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn NameColumn
      {
        get
        {
          return this.columnName;
        }
      }

      [DebuggerNonUserCode]
      public DataColumn ChecksumColumn
      {
        get
        {
          return this.columnChecksum;
        }
      }

      [DebuggerNonUserCode]
      [Browsable(false)]
      public int Count
      {
        get
        {
          return this.Rows.Count;
        }
      }

      [DebuggerNonUserCode]
      public Patch.PatchElementsRow this[int index]
      {
        get
        {
          return (Patch.PatchElementsRow) this.Rows[index];
        }
      }

      public event Patch.PatchElementsRowChangeEventHandler PatchElementsRowChanging;

      public event Patch.PatchElementsRowChangeEventHandler PatchElementsRowChanged;

      public event Patch.PatchElementsRowChangeEventHandler PatchElementsRowDeleting;

      public event Patch.PatchElementsRowChangeEventHandler PatchElementsRowDeleted;

      [DebuggerNonUserCode]
      public void AddPatchElementsRow(Patch.PatchElementsRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      public Patch.PatchElementsRow AddPatchElementsRow(
        string Comment,
        string Type,
        string ID,
        string Name,
        int Checksum)
      {
        Patch.PatchElementsRow patchElementsRow = (Patch.PatchElementsRow) this.NewRow();
        object[] objArray = new object[5]
        {
          (object) Comment,
          (object) Type,
          (object) ID,
          (object) Name,
          (object) Checksum
        };
        patchElementsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) patchElementsRow);
        return patchElementsRow;
      }

      [DebuggerNonUserCode]
      public virtual IEnumerator GetEnumerator()
      {
        return this.Rows.GetEnumerator();
      }

      [DebuggerNonUserCode]
      public override DataTable Clone()
      {
        Patch.PatchElementsDataTable elementsDataTable = (Patch.PatchElementsDataTable) base.Clone();
        elementsDataTable.InitVars();
        return (DataTable) elementsDataTable;
      }

      [DebuggerNonUserCode]
      protected override DataTable CreateInstance()
      {
        return (DataTable) new Patch.PatchElementsDataTable();
      }

      [DebuggerNonUserCode]
      internal void InitVars()
      {
        this.columnComment = this.Columns["Comment"];
        this.columnType = this.Columns["Type"];
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnChecksum = this.Columns["Checksum"];
      }

      [DebuggerNonUserCode]
      private void InitClass()
      {
        this.columnComment = new DataColumn("Comment", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnComment);
        this.columnType = new DataColumn("Type", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnType);
        this.columnID = new DataColumn("ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnChecksum = new DataColumn("Checksum", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnChecksum);
      }

      [DebuggerNonUserCode]
      public Patch.PatchElementsRow NewPatchElementsRow()
      {
        return (Patch.PatchElementsRow) this.NewRow();
      }

      [DebuggerNonUserCode]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
      {
        return (DataRow) new Patch.PatchElementsRow(builder);
      }

      [DebuggerNonUserCode]
      protected override Type GetRowType()
      {
        return typeof (Patch.PatchElementsRow);
      }

      [DebuggerNonUserCode]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PatchElementsRowChanged == null)
          return;
        this.PatchElementsRowChanged((object) this, new Patch.PatchElementsRowChangeEvent((Patch.PatchElementsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PatchElementsRowChanging == null)
          return;
        this.PatchElementsRowChanging((object) this, new Patch.PatchElementsRowChangeEvent((Patch.PatchElementsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PatchElementsRowDeleted == null)
          return;
        this.PatchElementsRowDeleted((object) this, new Patch.PatchElementsRowChangeEvent((Patch.PatchElementsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PatchElementsRowDeleting == null)
          return;
        this.PatchElementsRowDeleting((object) this, new Patch.PatchElementsRowChangeEvent((Patch.PatchElementsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      public void RemovePatchElementsRow(Patch.PatchElementsRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        Patch patch = new Patch();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = new Decimal(0);
        xmlSchemaAny1.MaxOccurs = new Decimal(-1, -1, -1, false, (byte) 0);
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = new Decimal(1);
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = patch.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PatchElementsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = patch.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class PatchIdentityRow : DataRow
    {
      private Patch.PatchIdentityDataTable tablePatchIdentity;

      [DebuggerNonUserCode]
      internal PatchIdentityRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablePatchIdentity = (Patch.PatchIdentityDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      public string Name
      {
        get
        {
          try
          {
            return (string) this[this.tablePatchIdentity.NameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Name' in table 'PatchIdentity' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchIdentity.NameColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public string Version
      {
        get
        {
          try
          {
            return (string) this[this.tablePatchIdentity.VersionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Version' in table 'PatchIdentity' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchIdentity.VersionColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public string Description
      {
        get
        {
          try
          {
            return (string) this[this.tablePatchIdentity.DescriptionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Description' in table 'PatchIdentity' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchIdentity.DescriptionColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public int Checksum
      {
        get
        {
          try
          {
            return (int) this[this.tablePatchIdentity.ChecksumColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Checksum' in table 'PatchIdentity' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchIdentity.ChecksumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public string CMS
      {
        get
        {
          return this.IsCMSNull() ? string.Empty : (string) this[this.tablePatchIdentity.CMSColumn];
        }
        set
        {
          this[this.tablePatchIdentity.CMSColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public bool IsNameNull()
      {
        return this.IsNull(this.tablePatchIdentity.NameColumn);
      }

      [DebuggerNonUserCode]
      public void SetNameNull()
      {
        this[this.tablePatchIdentity.NameColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsVersionNull()
      {
        return this.IsNull(this.tablePatchIdentity.VersionColumn);
      }

      [DebuggerNonUserCode]
      public void SetVersionNull()
      {
        this[this.tablePatchIdentity.VersionColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsDescriptionNull()
      {
        return this.IsNull(this.tablePatchIdentity.DescriptionColumn);
      }

      [DebuggerNonUserCode]
      public void SetDescriptionNull()
      {
        this[this.tablePatchIdentity.DescriptionColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsChecksumNull()
      {
        return this.IsNull(this.tablePatchIdentity.ChecksumColumn);
      }

      [DebuggerNonUserCode]
      public void SetChecksumNull()
      {
        this[this.tablePatchIdentity.ChecksumColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsCMSNull()
      {
        return this.IsNull(this.tablePatchIdentity.CMSColumn);
      }

      [DebuggerNonUserCode]
      public void SetCMSNull()
      {
        this[this.tablePatchIdentity.CMSColumn] = Convert.DBNull;
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class PatchElementsRow : DataRow
    {
      private Patch.PatchElementsDataTable tablePatchElements;

      [DebuggerNonUserCode]
      internal PatchElementsRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablePatchElements = (Patch.PatchElementsDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      public string Comment
      {
        get
        {
          try
          {
            return (string) this[this.tablePatchElements.CommentColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Comment' in table 'PatchElements' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchElements.CommentColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public string Type
      {
        get
        {
          try
          {
            return (string) this[this.tablePatchElements.TypeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Type' in table 'PatchElements' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchElements.TypeColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public string ID
      {
        get
        {
          return this.IsIDNull() ? string.Empty : (string) this[this.tablePatchElements.IDColumn];
        }
        set
        {
          this[this.tablePatchElements.IDColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public string Name
      {
        get
        {
          try
          {
            return (string) this[this.tablePatchElements.NameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Name' in table 'PatchElements' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchElements.NameColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public int Checksum
      {
        get
        {
          try
          {
            return (int) this[this.tablePatchElements.ChecksumColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Checksum' in table 'PatchElements' is DBNull.", (Exception) ex);
          }
        }
        set
        {
          this[this.tablePatchElements.ChecksumColumn] = (object) value;
        }
      }

      [DebuggerNonUserCode]
      public bool IsCommentNull()
      {
        return this.IsNull(this.tablePatchElements.CommentColumn);
      }

      [DebuggerNonUserCode]
      public void SetCommentNull()
      {
        this[this.tablePatchElements.CommentColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsTypeNull()
      {
        return this.IsNull(this.tablePatchElements.TypeColumn);
      }

      [DebuggerNonUserCode]
      public void SetTypeNull()
      {
        this[this.tablePatchElements.TypeColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsIDNull()
      {
        return this.IsNull(this.tablePatchElements.IDColumn);
      }

      [DebuggerNonUserCode]
      public void SetIDNull()
      {
        this[this.tablePatchElements.IDColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsNameNull()
      {
        return this.IsNull(this.tablePatchElements.NameColumn);
      }

      [DebuggerNonUserCode]
      public void SetNameNull()
      {
        this[this.tablePatchElements.NameColumn] = Convert.DBNull;
      }

      [DebuggerNonUserCode]
      public bool IsChecksumNull()
      {
        return this.IsNull(this.tablePatchElements.ChecksumColumn);
      }

      [DebuggerNonUserCode]
      public void SetChecksumNull()
      {
        this[this.tablePatchElements.ChecksumColumn] = Convert.DBNull;
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class PatchIdentityRowChangeEvent : EventArgs
    {
      private Patch.PatchIdentityRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      public PatchIdentityRowChangeEvent(Patch.PatchIdentityRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      public Patch.PatchIdentityRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    public class PatchElementsRowChangeEvent : EventArgs
    {
      private Patch.PatchElementsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      public PatchElementsRowChangeEvent(Patch.PatchElementsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      public Patch.PatchElementsRow Row
      {
        get
        {
          return this.eventRow;
        }
      }

      [DebuggerNonUserCode]
      public DataRowAction Action
      {
        get
        {
          return this.eventAction;
        }
      }
    }
  }
}
