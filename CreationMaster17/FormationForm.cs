// Original code created by Rinaldo

using FifaControls;
using FifaLibrary;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CreationMaster
{
  public class FormationForm : Form
  {
    private NewIdCreator m_NewIdCreator = new NewIdCreator();
    private Label[] m_LabelPos = new Label[11];
    private Label[] m_LabelArrowAtt1 = new Label[11];
    private Label[] m_LabelArrowDef1 = new Label[11];
    private int m_BoundRight = 250;
    private int m_BoundBottom = 350;
    private Point m_LabelLocation = new Point(0, 0);
    private ComboBox[,] m_ComboPlayerInstructions = new ComboBox[11, 5];
    private IContainer components;
    public PickUpControl pickUpControl;
    private GroupBox groupTactic;
    private Label labelAssignTeam;
    private TextBox textName;
    private Label labelName;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label3;
    private Label label4;
    private Label label2;
    private Label label1;
    private ComboBox comboBox7;
    private ComboBox comboBox1;
    private ComboBox comboBox8;
    private ComboBox comboBox2;
    private ComboBox comboBox9;
    private ComboBox comboBox3;
    private ComboBox comboBox10;
    private ComboBox comboBox6;
    private ComboBox comboBox11;
    private ComboBox comboBox5;
    private ComboBox comboBox4;
    private TabControl tabFormation;
    private TabPage pagePosition;
    private TabPage pageAttack1;
    private TabPage pageDefense1;
    private ImageList imageListPlayers;
    private ImageList imageListArrows;
    private Panel panelFormation;
    private BindingSource teamBindingSource;
    private Button buttonPresetFormation;
    private ComboBox comboFormation;
    private Label label12;
    private BindingSource teamListBindingSource;
    private CheckBox checkIsSweeper;
    private ComboBox comboOffensiveRating;
    private Label label14;
    private ComboBox comboPI_10;
    private ComboBox comboPI_11;
    private ComboBox comboPI_103;
    private ComboBox comboPI_102;
    private ComboBox comboPI_101;
    private ComboBox comboPI_100;
    private ComboBox comboPI_93;
    private ComboBox comboPI_92;
    private ComboBox comboPI_91;
    private ComboBox comboPI_90;
    private ComboBox comboPI_83;
    private ComboBox comboPI_82;
    private ComboBox comboPI_81;
    private ComboBox comboPI_80;
    private ComboBox comboPI_73;
    private ComboBox comboPI_72;
    private ComboBox comboPI_71;
    private ComboBox comboPI_70;
    private ComboBox comboPI_63;
    private ComboBox comboPI_62;
    private ComboBox comboPI_61;
    private ComboBox comboPI_60;
    private ComboBox comboPI_53;
    private ComboBox comboPI_52;
    private ComboBox comboPI_51;
    private ComboBox comboPI_50;
    private ComboBox comboPI_43;
    private ComboBox comboPI_42;
    private ComboBox comboPI_41;
    private ComboBox comboPI_40;
    private ComboBox comboPI_33;
    private ComboBox comboPI_32;
    private ComboBox comboPI_31;
    private ComboBox comboPI_30;
    private ComboBox comboPI_23;
    private ComboBox comboPI_22;
    private ComboBox comboPI_21;
    private ComboBox comboPI_20;
    private ComboBox comboPI_13;
    private ComboBox comboPI_12;
    private GroupBox groupInstructions;
    private ComboBox comboPI_104;
    private ComboBox comboPI_14;
    private ComboBox comboPI_94;
    private ComboBox comboPI_24;
    private ComboBox comboPI_84;
    private ComboBox comboPI_34;
    private ComboBox comboPI_74;
    private ComboBox comboPI_44;
    private ComboBox comboPI_64;
    private ComboBox comboPI_54;
    private Formation m_CurrentFormation;
    private bool m_LockUserChanges;
    private bool m_IsLoaded;
    private bool m_PositioningFlag;
    private Label m_MovingLabel;
    private int m_MovingLabelIndex;
    private int m_BoundLeft;
    private int m_BoundTop;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager resources = new ComponentResourceManager(typeof (FormationForm));
      this.groupTactic = new GroupBox();
      this.groupInstructions = new GroupBox();
      this.comboPI_104 = new ComboBox();
      this.comboPI_14 = new ComboBox();
      this.comboPI_94 = new ComboBox();
      this.comboPI_24 = new ComboBox();
      this.comboPI_84 = new ComboBox();
      this.comboPI_34 = new ComboBox();
      this.comboPI_74 = new ComboBox();
      this.comboPI_44 = new ComboBox();
      this.comboPI_64 = new ComboBox();
      this.comboPI_54 = new ComboBox();
      this.comboPI_10 = new ComboBox();
      this.comboPI_103 = new ComboBox();
      this.comboPI_11 = new ComboBox();
      this.comboPI_102 = new ComboBox();
      this.comboPI_12 = new ComboBox();
      this.comboPI_101 = new ComboBox();
      this.comboPI_13 = new ComboBox();
      this.comboPI_100 = new ComboBox();
      this.comboPI_20 = new ComboBox();
      this.comboPI_93 = new ComboBox();
      this.comboPI_21 = new ComboBox();
      this.comboPI_92 = new ComboBox();
      this.comboPI_22 = new ComboBox();
      this.comboPI_91 = new ComboBox();
      this.comboPI_23 = new ComboBox();
      this.comboPI_90 = new ComboBox();
      this.comboPI_30 = new ComboBox();
      this.comboPI_83 = new ComboBox();
      this.comboPI_31 = new ComboBox();
      this.comboPI_82 = new ComboBox();
      this.comboPI_32 = new ComboBox();
      this.comboPI_81 = new ComboBox();
      this.comboPI_33 = new ComboBox();
      this.comboPI_80 = new ComboBox();
      this.comboPI_40 = new ComboBox();
      this.comboPI_73 = new ComboBox();
      this.comboPI_41 = new ComboBox();
      this.comboPI_72 = new ComboBox();
      this.comboPI_42 = new ComboBox();
      this.comboPI_71 = new ComboBox();
      this.comboPI_43 = new ComboBox();
      this.comboPI_70 = new ComboBox();
      this.comboPI_50 = new ComboBox();
      this.comboPI_63 = new ComboBox();
      this.comboPI_51 = new ComboBox();
      this.comboPI_62 = new ComboBox();
      this.comboPI_52 = new ComboBox();
      this.comboPI_61 = new ComboBox();
      this.comboPI_53 = new ComboBox();
      this.comboPI_60 = new ComboBox();
      this.checkIsSweeper = new CheckBox();
      this.comboOffensiveRating = new ComboBox();
      this.label14 = new Label();
      this.buttonPresetFormation = new Button();
      this.comboFormation = new ComboBox();
      this.label12 = new Label();
      this.labelAssignTeam = new Label();
      this.textName = new TextBox();
      this.labelName = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.comboBox7 = new ComboBox();
      this.comboBox1 = new ComboBox();
      this.comboBox8 = new ComboBox();
      this.comboBox2 = new ComboBox();
      this.comboBox9 = new ComboBox();
      this.comboBox3 = new ComboBox();
      this.comboBox10 = new ComboBox();
      this.comboBox6 = new ComboBox();
      this.comboBox11 = new ComboBox();
      this.comboBox5 = new ComboBox();
      this.comboBox4 = new ComboBox();
      this.tabFormation = new TabControl();
      this.pagePosition = new TabPage();
      this.pageAttack1 = new TabPage();
      this.pageDefense1 = new TabPage();
      this.imageListPlayers = new ImageList(this.components);
      this.imageListArrows = new ImageList(this.components);
      this.panelFormation = new Panel();
      this.pickUpControl = new PickUpControl();
      this.teamBindingSource = new BindingSource(this.components);
      this.teamListBindingSource = new BindingSource(this.components);
      this.groupTactic.SuspendLayout();
      this.groupInstructions.SuspendLayout();
      this.tabFormation.SuspendLayout();
      this.panelFormation.SuspendLayout();
      ((ISupportInitialize) this.teamBindingSource).BeginInit();
      ((ISupportInitialize) this.teamListBindingSource).BeginInit();
      this.SuspendLayout();
      this.groupTactic.AutoSize = true;
      this.groupTactic.Controls.Add((Control) this.groupInstructions);
      this.groupTactic.Controls.Add((Control) this.checkIsSweeper);
      this.groupTactic.Controls.Add((Control) this.comboOffensiveRating);
      this.groupTactic.Controls.Add((Control) this.label14);
      this.groupTactic.Controls.Add((Control) this.buttonPresetFormation);
      this.groupTactic.Controls.Add((Control) this.comboFormation);
      this.groupTactic.Controls.Add((Control) this.label12);
      this.groupTactic.Controls.Add((Control) this.labelAssignTeam);
      this.groupTactic.Controls.Add((Control) this.textName);
      this.groupTactic.Controls.Add((Control) this.labelName);
      this.groupTactic.Controls.Add((Control) this.label9);
      this.groupTactic.Controls.Add((Control) this.label10);
      this.groupTactic.Controls.Add((Control) this.label11);
      this.groupTactic.Controls.Add((Control) this.label5);
      this.groupTactic.Controls.Add((Control) this.label6);
      this.groupTactic.Controls.Add((Control) this.label7);
      this.groupTactic.Controls.Add((Control) this.label8);
      this.groupTactic.Controls.Add((Control) this.label3);
      this.groupTactic.Controls.Add((Control) this.label4);
      this.groupTactic.Controls.Add((Control) this.label2);
      this.groupTactic.Controls.Add((Control) this.label1);
      this.groupTactic.Controls.Add((Control) this.comboBox7);
      this.groupTactic.Controls.Add((Control) this.comboBox1);
      this.groupTactic.Controls.Add((Control) this.comboBox8);
      this.groupTactic.Controls.Add((Control) this.comboBox2);
      this.groupTactic.Controls.Add((Control) this.comboBox9);
      this.groupTactic.Controls.Add((Control) this.comboBox3);
      this.groupTactic.Controls.Add((Control) this.comboBox10);
      this.groupTactic.Controls.Add((Control) this.comboBox6);
      this.groupTactic.Controls.Add((Control) this.comboBox11);
      this.groupTactic.Controls.Add((Control) this.comboBox5);
      this.groupTactic.Controls.Add((Control) this.comboBox4);
      this.groupTactic.Location = new Point(267, 6);
      this.groupTactic.Name = "groupTactic";
      this.groupTactic.Size = new Size(1079, 459);
      this.groupTactic.TabIndex = 8;
      this.groupTactic.TabStop = false;
      this.groupTactic.Text = "Roles";
      this.groupInstructions.Controls.Add((Control) this.comboPI_104);
      this.groupInstructions.Controls.Add((Control) this.comboPI_14);
      this.groupInstructions.Controls.Add((Control) this.comboPI_94);
      this.groupInstructions.Controls.Add((Control) this.comboPI_24);
      this.groupInstructions.Controls.Add((Control) this.comboPI_84);
      this.groupInstructions.Controls.Add((Control) this.comboPI_34);
      this.groupInstructions.Controls.Add((Control) this.comboPI_74);
      this.groupInstructions.Controls.Add((Control) this.comboPI_44);
      this.groupInstructions.Controls.Add((Control) this.comboPI_64);
      this.groupInstructions.Controls.Add((Control) this.comboPI_54);
      this.groupInstructions.Controls.Add((Control) this.comboPI_10);
      this.groupInstructions.Controls.Add((Control) this.comboPI_103);
      this.groupInstructions.Controls.Add((Control) this.comboPI_11);
      this.groupInstructions.Controls.Add((Control) this.comboPI_102);
      this.groupInstructions.Controls.Add((Control) this.comboPI_12);
      this.groupInstructions.Controls.Add((Control) this.comboPI_101);
      this.groupInstructions.Controls.Add((Control) this.comboPI_13);
      this.groupInstructions.Controls.Add((Control) this.comboPI_100);
      this.groupInstructions.Controls.Add((Control) this.comboPI_20);
      this.groupInstructions.Controls.Add((Control) this.comboPI_93);
      this.groupInstructions.Controls.Add((Control) this.comboPI_21);
      this.groupInstructions.Controls.Add((Control) this.comboPI_92);
      this.groupInstructions.Controls.Add((Control) this.comboPI_22);
      this.groupInstructions.Controls.Add((Control) this.comboPI_91);
      this.groupInstructions.Controls.Add((Control) this.comboPI_23);
      this.groupInstructions.Controls.Add((Control) this.comboPI_90);
      this.groupInstructions.Controls.Add((Control) this.comboPI_30);
      this.groupInstructions.Controls.Add((Control) this.comboPI_83);
      this.groupInstructions.Controls.Add((Control) this.comboPI_31);
      this.groupInstructions.Controls.Add((Control) this.comboPI_82);
      this.groupInstructions.Controls.Add((Control) this.comboPI_32);
      this.groupInstructions.Controls.Add((Control) this.comboPI_81);
      this.groupInstructions.Controls.Add((Control) this.comboPI_33);
      this.groupInstructions.Controls.Add((Control) this.comboPI_80);
      this.groupInstructions.Controls.Add((Control) this.comboPI_40);
      this.groupInstructions.Controls.Add((Control) this.comboPI_73);
      this.groupInstructions.Controls.Add((Control) this.comboPI_41);
      this.groupInstructions.Controls.Add((Control) this.comboPI_72);
      this.groupInstructions.Controls.Add((Control) this.comboPI_42);
      this.groupInstructions.Controls.Add((Control) this.comboPI_71);
      this.groupInstructions.Controls.Add((Control) this.comboPI_43);
      this.groupInstructions.Controls.Add((Control) this.comboPI_70);
      this.groupInstructions.Controls.Add((Control) this.comboPI_50);
      this.groupInstructions.Controls.Add((Control) this.comboPI_63);
      this.groupInstructions.Controls.Add((Control) this.comboPI_51);
      this.groupInstructions.Controls.Add((Control) this.comboPI_62);
      this.groupInstructions.Controls.Add((Control) this.comboPI_52);
      this.groupInstructions.Controls.Add((Control) this.comboPI_61);
      this.groupInstructions.Controls.Add((Control) this.comboPI_53);
      this.groupInstructions.Controls.Add((Control) this.comboPI_60);
      this.groupInstructions.Location = new Point(246, 35);
      this.groupInstructions.Name = "groupInstructions";
      this.groupInstructions.Size = new Size(827, 315);
      this.groupInstructions.TabIndex = 76;
      this.groupInstructions.TabStop = false;
      this.groupInstructions.Text = "Instructions";
      this.comboPI_104.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_104.FormattingEnabled = true;
      this.comboPI_104.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_104.Location = new Point(662, 276);
      this.comboPI_104.Name = "comboPI_104";
      this.comboPI_104.Size = new Size(160, 21);
      this.comboPI_104.TabIndex = 85;
      this.comboPI_14.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_14.FormattingEnabled = true;
      this.comboPI_14.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_14.Location = new Point(662, 51);
      this.comboPI_14.Name = "comboPI_14";
      this.comboPI_14.Size = new Size(160, 21);
      this.comboPI_14.TabIndex = 76;
      this.comboPI_94.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_94.FormattingEnabled = true;
      this.comboPI_94.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_94.Location = new Point(662, 251);
      this.comboPI_94.Name = "comboPI_94";
      this.comboPI_94.Size = new Size(160, 21);
      this.comboPI_94.TabIndex = 84;
      this.comboPI_24.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_24.FormattingEnabled = true;
      this.comboPI_24.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_24.Location = new Point(662, 76);
      this.comboPI_24.Name = "comboPI_24";
      this.comboPI_24.Size = new Size(160, 21);
      this.comboPI_24.TabIndex = 77;
      this.comboPI_84.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_84.FormattingEnabled = true;
      this.comboPI_84.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_84.Location = new Point(662, 226);
      this.comboPI_84.Name = "comboPI_84";
      this.comboPI_84.Size = new Size(160, 21);
      this.comboPI_84.TabIndex = 83;
      this.comboPI_34.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_34.FormattingEnabled = true;
      this.comboPI_34.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_34.Location = new Point(662, 101);
      this.comboPI_34.Name = "comboPI_34";
      this.comboPI_34.Size = new Size(160, 21);
      this.comboPI_34.TabIndex = 78;
      this.comboPI_74.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_74.FormattingEnabled = true;
      this.comboPI_74.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_74.Location = new Point(662, 201);
      this.comboPI_74.Name = "comboPI_74";
      this.comboPI_74.Size = new Size(160, 21);
      this.comboPI_74.TabIndex = 82;
      this.comboPI_44.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_44.FormattingEnabled = true;
      this.comboPI_44.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_44.Location = new Point(662, 126);
      this.comboPI_44.Name = "comboPI_44";
      this.comboPI_44.Size = new Size(160, 21);
      this.comboPI_44.TabIndex = 79;
      this.comboPI_64.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_64.FormattingEnabled = true;
      this.comboPI_64.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_64.Location = new Point(662, 176);
      this.comboPI_64.Name = "comboPI_64";
      this.comboPI_64.Size = new Size(160, 21);
      this.comboPI_64.TabIndex = 81;
      this.comboPI_54.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_54.FormattingEnabled = true;
      this.comboPI_54.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_54.Location = new Point(662, 151);
      this.comboPI_54.Name = "comboPI_54";
      this.comboPI_54.Size = new Size(160, 21);
      this.comboPI_54.TabIndex = 80;
      this.comboPI_10.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_10.FormattingEnabled = true;
      this.comboPI_10.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_10.Location = new Point(6, 51);
      this.comboPI_10.Name = "comboPI_10";
      this.comboPI_10.Size = new Size(160, 21);
      this.comboPI_10.TabIndex = 36;
      this.comboPI_10.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_103.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_103.FormattingEnabled = true;
      this.comboPI_103.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_103.Location = new Point(498, 276);
      this.comboPI_103.Name = "comboPI_103";
      this.comboPI_103.Size = new Size(160, 21);
      this.comboPI_103.TabIndex = 75;
      this.comboPI_103.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_11.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_11.FormattingEnabled = true;
      this.comboPI_11.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_11.Location = new Point(170, 51);
      this.comboPI_11.Name = "comboPI_11";
      this.comboPI_11.Size = new Size(160, 21);
      this.comboPI_11.TabIndex = 37;
      this.comboPI_11.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_102.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_102.FormattingEnabled = true;
      this.comboPI_102.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_102.Location = new Point(334, 276);
      this.comboPI_102.Name = "comboPI_102";
      this.comboPI_102.Size = new Size(160, 21);
      this.comboPI_102.TabIndex = 74;
      this.comboPI_102.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_12.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_12.FormattingEnabled = true;
      this.comboPI_12.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_12.Location = new Point(334, 51);
      this.comboPI_12.Name = "comboPI_12";
      this.comboPI_12.Size = new Size(160, 21);
      this.comboPI_12.TabIndex = 38;
      this.comboPI_12.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_101.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_101.FormattingEnabled = true;
      this.comboPI_101.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_101.Location = new Point(170, 276);
      this.comboPI_101.Name = "comboPI_101";
      this.comboPI_101.Size = new Size(160, 21);
      this.comboPI_101.TabIndex = 73;
      this.comboPI_101.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_13.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_13.FormattingEnabled = true;
      this.comboPI_13.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_13.Location = new Point(498, 51);
      this.comboPI_13.Name = "comboPI_13";
      this.comboPI_13.Size = new Size(160, 21);
      this.comboPI_13.TabIndex = 39;
      this.comboPI_13.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_100.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_100.FormattingEnabled = true;
      this.comboPI_100.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_100.Location = new Point(6, 276);
      this.comboPI_100.Name = "comboPI_100";
      this.comboPI_100.Size = new Size(160, 21);
      this.comboPI_100.TabIndex = 72;
      this.comboPI_100.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_20.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_20.FormattingEnabled = true;
      this.comboPI_20.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_20.Location = new Point(6, 76);
      this.comboPI_20.Name = "comboPI_20";
      this.comboPI_20.Size = new Size(160, 21);
      this.comboPI_20.TabIndex = 40;
      this.comboPI_20.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_93.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_93.FormattingEnabled = true;
      this.comboPI_93.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_93.Location = new Point(498, 251);
      this.comboPI_93.Name = "comboPI_93";
      this.comboPI_93.Size = new Size(160, 21);
      this.comboPI_93.TabIndex = 71;
      this.comboPI_93.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_21.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_21.FormattingEnabled = true;
      this.comboPI_21.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_21.Location = new Point(170, 76);
      this.comboPI_21.Name = "comboPI_21";
      this.comboPI_21.Size = new Size(160, 21);
      this.comboPI_21.TabIndex = 41;
      this.comboPI_21.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_92.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_92.FormattingEnabled = true;
      this.comboPI_92.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_92.Location = new Point(334, 251);
      this.comboPI_92.Name = "comboPI_92";
      this.comboPI_92.Size = new Size(160, 21);
      this.comboPI_92.TabIndex = 70;
      this.comboPI_92.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_22.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_22.FormattingEnabled = true;
      this.comboPI_22.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_22.Location = new Point(334, 76);
      this.comboPI_22.Name = "comboPI_22";
      this.comboPI_22.Size = new Size(160, 21);
      this.comboPI_22.TabIndex = 42;
      this.comboPI_22.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_91.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_91.FormattingEnabled = true;
      this.comboPI_91.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_91.Location = new Point(170, 251);
      this.comboPI_91.Name = "comboPI_91";
      this.comboPI_91.Size = new Size(160, 21);
      this.comboPI_91.TabIndex = 69;
      this.comboPI_91.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_23.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_23.FormattingEnabled = true;
      this.comboPI_23.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_23.Location = new Point(498, 76);
      this.comboPI_23.Name = "comboPI_23";
      this.comboPI_23.Size = new Size(160, 21);
      this.comboPI_23.TabIndex = 43;
      this.comboPI_23.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_90.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_90.FormattingEnabled = true;
      this.comboPI_90.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_90.Location = new Point(6, 251);
      this.comboPI_90.Name = "comboPI_90";
      this.comboPI_90.Size = new Size(160, 21);
      this.comboPI_90.TabIndex = 68;
      this.comboPI_90.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_30.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_30.FormattingEnabled = true;
      this.comboPI_30.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_30.Location = new Point(6, 101);
      this.comboPI_30.Name = "comboPI_30";
      this.comboPI_30.Size = new Size(160, 21);
      this.comboPI_30.TabIndex = 44;
      this.comboPI_30.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_83.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_83.FormattingEnabled = true;
      this.comboPI_83.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_83.Location = new Point(498, 226);
      this.comboPI_83.Name = "comboPI_83";
      this.comboPI_83.Size = new Size(160, 21);
      this.comboPI_83.TabIndex = 67;
      this.comboPI_83.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_31.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_31.FormattingEnabled = true;
      this.comboPI_31.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_31.Location = new Point(170, 101);
      this.comboPI_31.Name = "comboPI_31";
      this.comboPI_31.Size = new Size(160, 21);
      this.comboPI_31.TabIndex = 45;
      this.comboPI_31.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_82.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_82.FormattingEnabled = true;
      this.comboPI_82.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_82.Location = new Point(334, 226);
      this.comboPI_82.Name = "comboPI_82";
      this.comboPI_82.Size = new Size(160, 21);
      this.comboPI_82.TabIndex = 66;
      this.comboPI_82.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_32.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_32.FormattingEnabled = true;
      this.comboPI_32.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_32.Location = new Point(334, 101);
      this.comboPI_32.Name = "comboPI_32";
      this.comboPI_32.Size = new Size(160, 21);
      this.comboPI_32.TabIndex = 46;
      this.comboPI_32.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_81.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_81.FormattingEnabled = true;
      this.comboPI_81.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_81.Location = new Point(170, 226);
      this.comboPI_81.Name = "comboPI_81";
      this.comboPI_81.Size = new Size(160, 21);
      this.comboPI_81.TabIndex = 65;
      this.comboPI_81.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_33.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_33.FormattingEnabled = true;
      this.comboPI_33.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_33.Location = new Point(498, 101);
      this.comboPI_33.Name = "comboPI_33";
      this.comboPI_33.Size = new Size(160, 21);
      this.comboPI_33.TabIndex = 47;
      this.comboPI_33.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_80.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_80.FormattingEnabled = true;
      this.comboPI_80.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_80.Location = new Point(6, 226);
      this.comboPI_80.Name = "comboPI_80";
      this.comboPI_80.Size = new Size(160, 21);
      this.comboPI_80.TabIndex = 64;
      this.comboPI_80.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_40.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_40.FormattingEnabled = true;
      this.comboPI_40.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_40.Location = new Point(6, 126);
      this.comboPI_40.Name = "comboPI_40";
      this.comboPI_40.Size = new Size(160, 21);
      this.comboPI_40.TabIndex = 48;
      this.comboPI_40.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_73.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_73.FormattingEnabled = true;
      this.comboPI_73.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_73.Location = new Point(498, 201);
      this.comboPI_73.Name = "comboPI_73";
      this.comboPI_73.Size = new Size(160, 21);
      this.comboPI_73.TabIndex = 63;
      this.comboPI_73.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_41.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_41.FormattingEnabled = true;
      this.comboPI_41.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_41.Location = new Point(170, 126);
      this.comboPI_41.Name = "comboPI_41";
      this.comboPI_41.Size = new Size(160, 21);
      this.comboPI_41.TabIndex = 49;
      this.comboPI_41.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_72.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_72.FormattingEnabled = true;
      this.comboPI_72.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_72.Location = new Point(334, 201);
      this.comboPI_72.Name = "comboPI_72";
      this.comboPI_72.Size = new Size(160, 21);
      this.comboPI_72.TabIndex = 62;
      this.comboPI_72.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_42.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_42.FormattingEnabled = true;
      this.comboPI_42.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_42.Location = new Point(334, 126);
      this.comboPI_42.Name = "comboPI_42";
      this.comboPI_42.Size = new Size(160, 21);
      this.comboPI_42.TabIndex = 50;
      this.comboPI_42.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_71.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_71.FormattingEnabled = true;
      this.comboPI_71.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_71.Location = new Point(170, 201);
      this.comboPI_71.Name = "comboPI_71";
      this.comboPI_71.Size = new Size(160, 21);
      this.comboPI_71.TabIndex = 61;
      this.comboPI_71.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_43.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_43.FormattingEnabled = true;
      this.comboPI_43.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_43.Location = new Point(498, 126);
      this.comboPI_43.Name = "comboPI_43";
      this.comboPI_43.Size = new Size(160, 21);
      this.comboPI_43.TabIndex = 51;
      this.comboPI_43.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_70.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_70.FormattingEnabled = true;
      this.comboPI_70.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_70.Location = new Point(6, 201);
      this.comboPI_70.Name = "comboPI_70";
      this.comboPI_70.Size = new Size(160, 21);
      this.comboPI_70.TabIndex = 60;
      this.comboPI_70.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_50.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_50.FormattingEnabled = true;
      this.comboPI_50.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_50.Location = new Point(6, 151);
      this.comboPI_50.Name = "comboPI_50";
      this.comboPI_50.Size = new Size(160, 21);
      this.comboPI_50.TabIndex = 52;
      this.comboPI_50.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_63.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_63.FormattingEnabled = true;
      this.comboPI_63.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_63.Location = new Point(498, 176);
      this.comboPI_63.Name = "comboPI_63";
      this.comboPI_63.Size = new Size(160, 21);
      this.comboPI_63.TabIndex = 59;
      this.comboPI_63.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_51.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_51.FormattingEnabled = true;
      this.comboPI_51.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_51.Location = new Point(170, 151);
      this.comboPI_51.Name = "comboPI_51";
      this.comboPI_51.Size = new Size(160, 21);
      this.comboPI_51.TabIndex = 53;
      this.comboPI_51.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_62.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_62.FormattingEnabled = true;
      this.comboPI_62.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_62.Location = new Point(334, 176);
      this.comboPI_62.Name = "comboPI_62";
      this.comboPI_62.Size = new Size(160, 21);
      this.comboPI_62.TabIndex = 58;
      this.comboPI_62.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_52.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_52.FormattingEnabled = true;
      this.comboPI_52.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_52.Location = new Point(334, 151);
      this.comboPI_52.Name = "comboPI_52";
      this.comboPI_52.Size = new Size(160, 21);
      this.comboPI_52.TabIndex = 54;
      this.comboPI_52.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_61.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_61.FormattingEnabled = true;
      this.comboPI_61.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_61.Location = new Point(170, 176);
      this.comboPI_61.Name = "comboPI_61";
      this.comboPI_61.Size = new Size(160, 21);
      this.comboPI_61.TabIndex = 57;
      this.comboPI_61.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_53.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_53.FormattingEnabled = true;
      this.comboPI_53.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_53.Location = new Point(498, 151);
      this.comboPI_53.Name = "comboPI_53";
      this.comboPI_53.Size = new Size(160, 21);
      this.comboPI_53.TabIndex = 55;
      this.comboPI_53.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.comboPI_60.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboPI_60.FormattingEnabled = true;
      this.comboPI_60.Items.AddRange(new object[1]
      {
        (object) "Stay On Edge Of Box For Cross"
      });
      this.comboPI_60.Location = new Point(6, 176);
      this.comboPI_60.Name = "comboPI_60";
      this.comboPI_60.Size = new Size(160, 21);
      this.comboPI_60.TabIndex = 56;
      this.comboPI_60.SelectedIndexChanged += new EventHandler(this.comboInstruction_SelectedIndexChanged);
      this.checkIsSweeper.AutoSize = true;
      this.checkIsSweeper.Location = new Point(109, 391);
      this.checkIsSweeper.Name = "checkIsSweeper";
      this.checkIsSweeper.Size = new Size(90, 17);
      this.checkIsSweeper.TabIndex = 30;
      this.checkIsSweeper.Text = "Has Sweeper";
      this.checkIsSweeper.UseVisualStyleBackColor = true;
      this.checkIsSweeper.CheckedChanged += new EventHandler(this.checkIsSweeper_CheckedChanged);
      this.comboOffensiveRating.FormattingEnabled = true;
      this.comboOffensiveRating.Items.AddRange(new object[5]
      {
        (object) "Very Defensive",
        (object) "Defensive",
        (object) "Neutral",
        (object) "Offensive",
        (object) "Very Offensive"
      });
      this.comboOffensiveRating.Location = new Point(109, 364);
      this.comboOffensiveRating.Name = "comboOffensiveRating";
      this.comboOffensiveRating.Size = new Size(130, 21);
      this.comboOffensiveRating.TabIndex = 35;
      this.comboOffensiveRating.SelectedIndexChanged += new EventHandler(this.comboOffensiveRating_SelectedIndexChanged);
      this.label14.AutoSize = true;
      this.label14.Location = new Point(12, 368);
      this.label14.Name = "label14";
      this.label14.Size = new Size(86, 13);
      this.label14.TabIndex = 34;
      this.label14.Text = "Offensive Rating";
      this.buttonPresetFormation.Location = new Point(191, 408);
      this.buttonPresetFormation.Name = "buttonPresetFormation";
      this.buttonPresetFormation.Size = new Size(47, 23);
      this.buttonPresetFormation.TabIndex = 29;
      this.buttonPresetFormation.Text = "Copy";
      this.buttonPresetFormation.UseVisualStyleBackColor = true;
      this.buttonPresetFormation.Click += new EventHandler(this.buttonPresetFormation_Click);
      this.comboFormation.FormattingEnabled = true;
      this.comboFormation.Location = new Point(55, 410);
      this.comboFormation.Name = "comboFormation";
      this.comboFormation.Size = new Size(130, 21);
      this.comboFormation.TabIndex = 28;
      this.label12.AutoSize = true;
      this.label12.Location = new Point(12, 415);
      this.label12.Name = "label12";
      this.label12.Size = new Size(37, 13);
      this.label12.TabIndex = 27;
      this.label12.Text = "Preset";
      this.labelAssignTeam.Cursor = Cursors.Hand;
      this.labelAssignTeam.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, (byte) 0);
      this.labelAssignTeam.ForeColor = SystemColors.ActiveCaption;
      this.labelAssignTeam.Location = new Point(6, 13);
      this.labelAssignTeam.Name = "labelAssignTeam";
      this.labelAssignTeam.Size = new Size(232, 19);
      this.labelAssignTeam.TabIndex = 26;
      this.labelAssignTeam.Text = "Formation";
      this.labelAssignTeam.TextAlign = ContentAlignment.MiddleCenter;
      this.labelAssignTeam.DoubleClick += new EventHandler(this.labelAssignTeam_DoubleClick);
      this.textName.Location = new Point(53, 35);
      this.textName.Name = "textName";
      this.textName.Size = new Size(187, 20);
      this.textName.TabIndex = 25;
      this.textName.TextChanged += new EventHandler(this.textName_TextChanged);
      this.labelName.AutoSize = true;
      this.labelName.Location = new Point(12, 38);
      this.labelName.Name = "labelName";
      this.labelName.Size = new Size(35, 13);
      this.labelName.TabIndex = 24;
      this.labelName.Text = "Name";
      this.label9.Location = new Point(5, 311);
      this.label9.Name = "label9";
      this.label9.Size = new Size(20, 18);
      this.label9.TabIndex = 23;
      this.label9.Text = "11";
      this.label9.TextAlign = ContentAlignment.MiddleCenter;
      this.label10.Location = new Point(5, 286);
      this.label10.Name = "label10";
      this.label10.Size = new Size(20, 18);
      this.label10.TabIndex = 22;
      this.label10.Text = "10";
      this.label10.TextAlign = ContentAlignment.MiddleCenter;
      this.label11.Location = new Point(5, 261);
      this.label11.Name = "label11";
      this.label11.Size = new Size(20, 18);
      this.label11.TabIndex = 21;
      this.label11.Text = "9";
      this.label11.TextAlign = ContentAlignment.MiddleCenter;
      this.label5.Location = new Point(5, 236);
      this.label5.Name = "label5";
      this.label5.Size = new Size(20, 18);
      this.label5.TabIndex = 20;
      this.label5.Text = "8";
      this.label5.TextAlign = ContentAlignment.MiddleCenter;
      this.label6.Location = new Point(5, 211);
      this.label6.Name = "label6";
      this.label6.Size = new Size(20, 18);
      this.label6.TabIndex = 19;
      this.label6.Text = "7";
      this.label6.TextAlign = ContentAlignment.MiddleCenter;
      this.label7.Location = new Point(5, 186);
      this.label7.Name = "label7";
      this.label7.Size = new Size(20, 18);
      this.label7.TabIndex = 18;
      this.label7.Text = "6";
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.Location = new Point(5, 161);
      this.label8.Name = "label8";
      this.label8.Size = new Size(20, 18);
      this.label8.TabIndex = 17;
      this.label8.Text = "5";
      this.label8.TextAlign = ContentAlignment.MiddleCenter;
      this.label3.Location = new Point(5, 136);
      this.label3.Name = "label3";
      this.label3.Size = new Size(20, 18);
      this.label3.TabIndex = 16;
      this.label3.Text = "4";
      this.label3.TextAlign = ContentAlignment.MiddleCenter;
      this.label4.Location = new Point(5, 111);
      this.label4.Name = "label4";
      this.label4.Size = new Size(20, 18);
      this.label4.TabIndex = 15;
      this.label4.Text = "3";
      this.label4.TextAlign = ContentAlignment.MiddleCenter;
      this.label2.Location = new Point(5, 86);
      this.label2.Name = "label2";
      this.label2.Size = new Size(20, 18);
      this.label2.TabIndex = 14;
      this.label2.Text = "2";
      this.label2.TextAlign = ContentAlignment.MiddleCenter;
      this.label1.Location = new Point(5, 61);
      this.label1.Name = "label1";
      this.label1.Size = new Size(20, 18);
      this.label1.TabIndex = 13;
      this.label1.Text = "1";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.comboBox7.FormattingEnabled = true;
      this.comboBox7.Location = new Point(31, 211);
      this.comboBox7.Name = "comboBox7";
      this.comboBox7.Size = new Size(209, 21);
      this.comboBox7.TabIndex = 6;
      this.comboBox7.SelectedIndexChanged += new EventHandler(this.comboBox7_SelectedIndexChanged);
      this.comboBox1.BackColor = Color.White;
      this.comboBox1.Enabled = false;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(31, 61);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(209, 21);
      this.comboBox1.TabIndex = 0;
      this.comboBox8.FormattingEnabled = true;
      this.comboBox8.Location = new Point(31, 236);
      this.comboBox8.Name = "comboBox8";
      this.comboBox8.Size = new Size(209, 21);
      this.comboBox8.TabIndex = 7;
      this.comboBox8.SelectedIndexChanged += new EventHandler(this.comboBox8_SelectedIndexChanged);
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new Point(31, 86);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(209, 21);
      this.comboBox2.TabIndex = 1;
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.comboBox9.FormattingEnabled = true;
      this.comboBox9.Location = new Point(31, 261);
      this.comboBox9.Name = "comboBox9";
      this.comboBox9.Size = new Size(209, 21);
      this.comboBox9.TabIndex = 8;
      this.comboBox9.SelectedIndexChanged += new EventHandler(this.comboBox9_SelectedIndexChanged);
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Location = new Point(31, 111);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(209, 21);
      this.comboBox3.TabIndex = 2;
      this.comboBox3.SelectedIndexChanged += new EventHandler(this.comboBox3_SelectedIndexChanged);
      this.comboBox10.FormattingEnabled = true;
      this.comboBox10.Location = new Point(31, 286);
      this.comboBox10.Name = "comboBox10";
      this.comboBox10.Size = new Size(209, 21);
      this.comboBox10.TabIndex = 9;
      this.comboBox10.SelectedIndexChanged += new EventHandler(this.comboBox10_SelectedIndexChanged);
      this.comboBox6.FormattingEnabled = true;
      this.comboBox6.Location = new Point(31, 186);
      this.comboBox6.Name = "comboBox6";
      this.comboBox6.Size = new Size(209, 21);
      this.comboBox6.TabIndex = 5;
      this.comboBox6.SelectedIndexChanged += new EventHandler(this.comboBox6_SelectedIndexChanged);
      this.comboBox11.FormattingEnabled = true;
      this.comboBox11.Location = new Point(31, 311);
      this.comboBox11.Name = "comboBox11";
      this.comboBox11.Size = new Size(209, 21);
      this.comboBox11.TabIndex = 10;
      this.comboBox11.SelectedIndexChanged += new EventHandler(this.comboBox11_SelectedIndexChanged);
      this.comboBox5.FormattingEnabled = true;
      this.comboBox5.Location = new Point(31, 161);
      this.comboBox5.Name = "comboBox5";
      this.comboBox5.Size = new Size(209, 21);
      this.comboBox5.TabIndex = 4;
      this.comboBox5.SelectedIndexChanged += new EventHandler(this.comboBox5_SelectedIndexChanged);
      this.comboBox4.FormattingEnabled = true;
      this.comboBox4.Location = new Point(31, 136);
      this.comboBox4.Name = "comboBox4";
      this.comboBox4.Size = new Size(209, 21);
      this.comboBox4.TabIndex = 3;
      this.comboBox4.SelectedIndexChanged += new EventHandler(this.comboBox4_SelectedIndexChanged);
      this.tabFormation.Controls.Add((Control) this.pagePosition);
      this.tabFormation.Controls.Add((Control) this.pageAttack1);
      this.tabFormation.Controls.Add((Control) this.pageDefense1);
      this.tabFormation.Location = new Point(0, 0);
      this.tabFormation.Name = "tabFormation";
      this.tabFormation.SelectedIndex = 0;
      this.tabFormation.Size = new Size(263, 376);
      this.tabFormation.TabIndex = 9;
      this.pagePosition.BackgroundImage = (Image) resources.GetObject("pagePosition.BackgroundImage");
      this.pagePosition.BackgroundImageLayout = ImageLayout.Stretch;
      this.pagePosition.Location = new Point(4, 22);
      this.pagePosition.Name = "pagePosition";
      this.pagePosition.Padding = new Padding(3);
      this.pagePosition.Size = new Size((int) byte.MaxValue, 350);
      this.pagePosition.TabIndex = 0;
      this.pagePosition.Text = "Position";
      this.pagePosition.UseVisualStyleBackColor = true;
      this.pageAttack1.BackgroundImage = (Image) resources.GetObject("pageAttack1.BackgroundImage");
      this.pageAttack1.BackgroundImageLayout = ImageLayout.None;
      this.pageAttack1.Location = new Point(4, 22);
      this.pageAttack1.Name = "pageAttack1";
      this.pageAttack1.Padding = new Padding(3);
      this.pageAttack1.Size = new Size((int) byte.MaxValue, 350);
      this.pageAttack1.TabIndex = 1;
      this.pageAttack1.Text = "Attack";
      this.pageAttack1.UseVisualStyleBackColor = true;
      this.pageDefense1.BackgroundImage = (Image) resources.GetObject("pageDefense1.BackgroundImage");
      this.pageDefense1.BackgroundImageLayout = ImageLayout.None;
      this.pageDefense1.Location = new Point(4, 22);
      this.pageDefense1.Name = "pageDefense1";
      this.pageDefense1.Size = new Size((int) byte.MaxValue, 350);
      this.pageDefense1.TabIndex = 3;
      this.pageDefense1.Text = "Defense";
      this.pageDefense1.UseVisualStyleBackColor = true;
      this.imageListPlayers.ImageStream = (ImageListStreamer) resources.GetObject("imageListPlayers.ImageStream");
      this.imageListPlayers.TransparentColor = Color.Fuchsia;
      this.imageListPlayers.Images.SetKeyName(0, "P1.png");
      this.imageListPlayers.Images.SetKeyName(1, "P2.png");
      this.imageListPlayers.Images.SetKeyName(2, "P3.png");
      this.imageListPlayers.Images.SetKeyName(3, "p4.png");
      this.imageListPlayers.Images.SetKeyName(4, "p5.png");
      this.imageListPlayers.Images.SetKeyName(5, "p6.png");
      this.imageListPlayers.Images.SetKeyName(6, "p7.png");
      this.imageListPlayers.Images.SetKeyName(7, "p8.png");
      this.imageListPlayers.Images.SetKeyName(8, "P9.png");
      this.imageListPlayers.Images.SetKeyName(9, "P10.png");
      this.imageListPlayers.Images.SetKeyName(10, "p11.png");
      this.imageListPlayers.Images.SetKeyName(11, "Pnull.png");
      this.imageListArrows.ImageStream = (ImageListStreamer) resources.GetObject("imageListArrows.ImageStream");
      this.imageListArrows.TransparentColor = Color.Fuchsia;
      this.imageListArrows.Images.SetKeyName(0, "Move0Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(1, "Move1Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(2, "Move2tYellow.PNG");
      this.imageListArrows.Images.SetKeyName(3, "Move3Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(4, "Move4Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(5, "Move5Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(6, "Move6Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(7, "Move7Yellow.PNG");
      this.imageListArrows.Images.SetKeyName(8, "Move8tYellow.PNG");
      this.imageListArrows.Images.SetKeyName(9, "Move0Red.PNG");
      this.imageListArrows.Images.SetKeyName(10, "Move1Red.PNG");
      this.imageListArrows.Images.SetKeyName(11, "Move2Red.PNG");
      this.imageListArrows.Images.SetKeyName(12, "Move3Red.PNG");
      this.imageListArrows.Images.SetKeyName(13, "Move4Red.PNG");
      this.imageListArrows.Images.SetKeyName(14, "Move5Red.PNG");
      this.imageListArrows.Images.SetKeyName(15, "Move6Red.PNG");
      this.imageListArrows.Images.SetKeyName(16, "Move7Red.PNG");
      this.imageListArrows.Images.SetKeyName(17, "Move8Red.PNG");
      this.imageListArrows.Images.SetKeyName(18, "Move0Blue.PNG");
      this.imageListArrows.Images.SetKeyName(19, "Move1Blue.PNG");
      this.imageListArrows.Images.SetKeyName(20, "Move2Blue.PNG");
      this.imageListArrows.Images.SetKeyName(21, "Move3Blue.PNG");
      this.imageListArrows.Images.SetKeyName(22, "Move4Blue.PNG");
      this.imageListArrows.Images.SetKeyName(23, "Move5Blue.PNG");
      this.imageListArrows.Images.SetKeyName(24, "Move6Blue.PNG");
      this.imageListArrows.Images.SetKeyName(25, "Move7Blue.PNG");
      this.imageListArrows.Images.SetKeyName(26, "Move8Blue.PNG");
      this.imageListArrows.Images.SetKeyName(27, "Move0White.PNG");
      this.imageListArrows.Images.SetKeyName(28, "Move1White.PNG");
      this.imageListArrows.Images.SetKeyName(29, "Move2White.PNG");
      this.imageListArrows.Images.SetKeyName(30, "Move3White.PNG");
      this.imageListArrows.Images.SetKeyName(31, "Move4White.PNG");
      this.imageListArrows.Images.SetKeyName(32, "Move5White.PNG");
      this.imageListArrows.Images.SetKeyName(33, "Move6White.PNG");
      this.imageListArrows.Images.SetKeyName(34, "Move7White.PNG");
      this.imageListArrows.Images.SetKeyName(35, "Move8White.PNG");
      this.panelFormation.AutoScroll = true;
      this.panelFormation.Controls.Add((Control) this.groupTactic);
      this.panelFormation.Controls.Add((Control) this.tabFormation);
      this.panelFormation.Dock = DockStyle.Fill;
      this.panelFormation.Location = new Point(0, 25);
      this.panelFormation.Name = "panelFormation";
      this.panelFormation.Size = new Size(1343, 750);
      this.panelFormation.TabIndex = 10;
      this.pickUpControl.BackColor = SystemColors.Control;
      this.pickUpControl.CloneButtonEnabled = true;
      this.pickUpControl.CreateButtonEnabled = true;
      this.pickUpControl.CurrentIndex = 0;
      this.pickUpControl.Dock = DockStyle.Top;
      this.pickUpControl.FilterByList = new string[4]
      {
        "All",
        "by League",
        "by Country",
        "by Team"
      };
      this.pickUpControl.FilterEnabled = false;
      this.pickUpControl.FilterValues = (IdArrayList[]) null;
      this.pickUpControl.Location = new Point(0, 0);
      this.pickUpControl.MainSelectionEnabled = true;
      this.pickUpControl.Name = "pickUpControl";
      this.pickUpControl.ObjectList = (IdArrayList) null;
      this.pickUpControl.RefreshButtonEnabled = true;
      this.pickUpControl.RemoveButtonEnabled = true;
      this.pickUpControl.SearchEnabled = true;
      this.pickUpControl.Size = new Size(1343, 25);
      this.pickUpControl.TabIndex = 1;
      this.pickUpControl.WizardButtonEnabled = false;
      this.pickUpControl.YoungPlayersEnabled = false;
      this.teamBindingSource.DataSource = (object) typeof (Team);
      this.teamListBindingSource.DataSource = (object) typeof (TeamList);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1343, 775);
      this.Controls.Add((Control) this.panelFormation);
      this.Controls.Add((Control) this.pickUpControl);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "FormationForm";
      this.Text = "FormationForm";
      this.Load += new EventHandler(this.FormationForm_Load);
      this.groupTactic.ResumeLayout(false);
      this.groupTactic.PerformLayout();
      this.groupInstructions.ResumeLayout(false);
      this.tabFormation.ResumeLayout(false);
      this.panelFormation.ResumeLayout(false);
      this.panelFormation.PerformLayout();
      ((ISupportInitialize) this.teamBindingSource).EndInit();
      ((ISupportInitialize) this.teamListBindingSource).EndInit();
      this.ResumeLayout(false);
    }

    public FormationForm()
    {
      this.InitializeComponent();
      this.pickUpControl.SelectObject = new PickUpControl.PickUpCallback(this.SelectFormation);
      this.pickUpControl.CreateObject = new PickUpControl.PickUpCallback(this.CreateFormation);
      this.pickUpControl.DeleteObject = new PickUpControl.PickUpCallback(this.DeleteFormation);
      this.pickUpControl.CloneObject = new PickUpControl.PickUpCallback(this.CloneFormation);
      this.pickUpControl.RefreshObject = new PickUpControl.PickUpCallback(this.RefreshFormation);
      this.pickUpControl.combo.Sorted = false;
      for (int index = 0; index <= 10; ++index)
      {
        this.m_LabelPos[index] = new Label();
        this.m_LabelPos[index].AutoSize = false;
        this.m_LabelPos[index].Location = new Point(118, (index + 4) * 20);
        this.m_LabelPos[index].ImageList = this.imageListPlayers;
        this.m_LabelPos[index].ImageIndex = index;
        this.m_LabelPos[index].Width = 16;
        this.m_LabelPos[index].Height = 16;
        this.m_LabelPos[index].Cursor = Cursors.Hand;
        this.m_LabelPos[index].MouseUp += new MouseEventHandler(this.MouseUpService);
        this.m_LabelPos[index].MouseMove += new MouseEventHandler(this.MouseMoveService);
        this.m_LabelPos[index].MouseDown += new MouseEventHandler(this.MouseDownService);
        this.pagePosition.Controls.Add((Control) this.m_LabelPos[index]);
      }
      for (int index = 0; index <= 10; ++index)
      {
        this.m_LabelArrowAtt1[index] = new Label();
        this.m_LabelArrowAtt1[index].AutoSize = false;
        this.m_LabelArrowAtt1[index].Location = new Point(50 + index * 10, (index + 1) * 20);
        this.m_LabelArrowAtt1[index].ImageList = this.imageListArrows;
        this.m_LabelArrowAtt1[index].ImageIndex = 0;
        this.m_LabelArrowAtt1[index].Width = 48;
        this.m_LabelArrowAtt1[index].Height = 48;
        this.m_LabelArrowAtt1[index].ForeColor = Color.Black;
        this.m_LabelArrowAtt1[index].Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
        this.m_LabelArrowAtt1[index].Text = (index + 1).ToString();
        this.m_LabelArrowAtt1[index].TextAlign = ContentAlignment.MiddleCenter;
        this.m_LabelArrowAtt1[index].DoubleClick += new EventHandler(this.labelAtt_DoubleClick);
        this.m_LabelArrowAtt1[index].Click += new EventHandler(this.labelAtt_Click);
        this.m_LabelArrowAtt1[index].Cursor = Cursors.Hand;
        this.pageAttack1.Controls.Add((Control) this.m_LabelArrowAtt1[index]);
        this.pageAttack1.Controls[index].BringToFront();
      }
      for (int index = 0; index <= 10; ++index)
      {
        this.m_LabelArrowDef1[index] = new Label();
        this.m_LabelArrowDef1[index].AutoSize = false;
        this.m_LabelArrowDef1[index].Location = new Point(50 + index * 10, (index + 1) * 20);
        this.m_LabelArrowDef1[index].ImageList = this.imageListArrows;
        this.m_LabelArrowDef1[index].ImageIndex = 0;
        this.m_LabelArrowDef1[index].Width = 48;
        this.m_LabelArrowDef1[index].Height = 48;
        this.m_LabelArrowDef1[index].ForeColor = Color.Black;
        this.m_LabelArrowDef1[index].Text = (index + 1).ToString();
        this.m_LabelArrowDef1[index].Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
        this.m_LabelArrowDef1[index].TextAlign = ContentAlignment.MiddleCenter;
        this.m_LabelArrowDef1[index].DoubleClick += new EventHandler(this.labelDef_DoubleClick);
        this.m_LabelArrowDef1[index].Click += new EventHandler(this.labelDef_Click);
        this.m_LabelArrowDef1[index].Cursor = Cursors.Hand;
        this.pageDefense1.Controls.Add((Control) this.m_LabelArrowDef1[index]);
        this.pageDefense1.Controls[index].BringToFront();
      }
      this.m_ComboPlayerInstructions[0, 0] = (ComboBox) null;
      this.m_ComboPlayerInstructions[0, 1] = (ComboBox) null;
      this.m_ComboPlayerInstructions[0, 2] = (ComboBox) null;
      this.m_ComboPlayerInstructions[0, 3] = (ComboBox) null;
      this.m_ComboPlayerInstructions[1, 0] = this.comboPI_10;
      this.m_ComboPlayerInstructions[1, 1] = this.comboPI_11;
      this.m_ComboPlayerInstructions[1, 2] = this.comboPI_12;
      this.m_ComboPlayerInstructions[1, 3] = this.comboPI_13;
      this.m_ComboPlayerInstructions[1, 4] = this.comboPI_14;
      this.m_ComboPlayerInstructions[2, 0] = this.comboPI_20;
      this.m_ComboPlayerInstructions[2, 1] = this.comboPI_21;
      this.m_ComboPlayerInstructions[2, 2] = this.comboPI_22;
      this.m_ComboPlayerInstructions[2, 3] = this.comboPI_23;
      this.m_ComboPlayerInstructions[2, 4] = this.comboPI_24;
      this.m_ComboPlayerInstructions[3, 0] = this.comboPI_30;
      this.m_ComboPlayerInstructions[3, 1] = this.comboPI_31;
      this.m_ComboPlayerInstructions[3, 2] = this.comboPI_32;
      this.m_ComboPlayerInstructions[3, 3] = this.comboPI_33;
      this.m_ComboPlayerInstructions[3, 4] = this.comboPI_34;
      this.m_ComboPlayerInstructions[4, 0] = this.comboPI_40;
      this.m_ComboPlayerInstructions[4, 1] = this.comboPI_41;
      this.m_ComboPlayerInstructions[4, 2] = this.comboPI_42;
      this.m_ComboPlayerInstructions[4, 3] = this.comboPI_43;
      this.m_ComboPlayerInstructions[4, 4] = this.comboPI_44;
      this.m_ComboPlayerInstructions[5, 0] = this.comboPI_50;
      this.m_ComboPlayerInstructions[5, 1] = this.comboPI_51;
      this.m_ComboPlayerInstructions[5, 2] = this.comboPI_52;
      this.m_ComboPlayerInstructions[5, 3] = this.comboPI_53;
      this.m_ComboPlayerInstructions[5, 4] = this.comboPI_54;
      this.m_ComboPlayerInstructions[6, 0] = this.comboPI_60;
      this.m_ComboPlayerInstructions[6, 1] = this.comboPI_61;
      this.m_ComboPlayerInstructions[6, 2] = this.comboPI_62;
      this.m_ComboPlayerInstructions[6, 3] = this.comboPI_63;
      this.m_ComboPlayerInstructions[6, 4] = this.comboPI_64;
      this.m_ComboPlayerInstructions[7, 0] = this.comboPI_70;
      this.m_ComboPlayerInstructions[7, 1] = this.comboPI_71;
      this.m_ComboPlayerInstructions[7, 2] = this.comboPI_72;
      this.m_ComboPlayerInstructions[7, 3] = this.comboPI_73;
      this.m_ComboPlayerInstructions[7, 4] = this.comboPI_74;
      this.m_ComboPlayerInstructions[8, 0] = this.comboPI_80;
      this.m_ComboPlayerInstructions[8, 1] = this.comboPI_81;
      this.m_ComboPlayerInstructions[8, 2] = this.comboPI_82;
      this.m_ComboPlayerInstructions[8, 3] = this.comboPI_83;
      this.m_ComboPlayerInstructions[8, 4] = this.comboPI_84;
      this.m_ComboPlayerInstructions[9, 0] = this.comboPI_90;
      this.m_ComboPlayerInstructions[9, 1] = this.comboPI_91;
      this.m_ComboPlayerInstructions[9, 2] = this.comboPI_92;
      this.m_ComboPlayerInstructions[9, 3] = this.comboPI_93;
      this.m_ComboPlayerInstructions[9, 4] = this.comboPI_94;
      this.m_ComboPlayerInstructions[10, 0] = this.comboPI_100;
      this.m_ComboPlayerInstructions[10, 1] = this.comboPI_101;
      this.m_ComboPlayerInstructions[10, 2] = this.comboPI_102;
      this.m_ComboPlayerInstructions[10, 3] = this.comboPI_103;
      this.m_ComboPlayerInstructions[10, 4] = this.comboPI_104;
    }

    private void FormationForm_Load(object sender, EventArgs e)
    {
      this.m_IsLoaded = true;
      this.Preset();
    }

    public void Clean()
    {
      this.Visible = false;
    }

    private Formation SelectFormation(object sender, object obj)
    {
      this.Refresh();
      this.LoadFormation((Formation) obj);
      return (Formation) obj;
    }

    private Formation CreateFormation(object sender, object obj)
    {
      DialogResult dialogResult = this.m_NewIdCreator.ShowDialog();
      if (this.m_NewIdCreator.NewObject == null)
      {
        if (dialogResult == DialogResult.OK)
        {
          int num = (int) FifaEnvironment.UserMessages.ShowMessage(5060, this.m_NewIdCreator.NewId);
        }
        return (Formation) null;
      }
      Formation newObject = (Formation) this.m_NewIdCreator.NewObject;
      if (this.m_NewIdCreator.NewName != null && newObject != null)
        newObject.Name = this.m_NewIdCreator.NewName;
      return newObject;
    }

    private Formation CloneFormation(object sender, object obj)
    {
      return (Formation) FifaEnvironment.Formations.CloneId((IdObject) obj, FifaEnvironment.Formations.GetNewId());
    }

    private Formation DeleteFormation(object sender, object obj)
    {
      FifaEnvironment.Formations.RemoveId((IdObject) obj);
      this.m_CurrentFormation = (Formation) null;
      return (Formation) null;
    }

    public Formation RefreshFormation(object sender, object obj)
    {
      this.Preset();
      this.ReloadFormation(this.m_CurrentFormation);
      return this.m_CurrentFormation;
    }

    public void ReloadFormation(Formation formation)
    {
      this.m_CurrentFormation = (Formation) null;
      this.LoadFormation(formation);
    }

    public void LoadFormation(Formation formation)
    {
      if (!this.m_IsLoaded || this.m_CurrentFormation == formation)
        return;
      this.m_CurrentFormation = formation;
      this.m_PositioningFlag = true;
      for (int i = 0; i < 11; ++i)
      {
        this.m_LabelPos[i].Tag = (object) this.m_CurrentFormation.PlayingRoles[i];
        this.m_LabelArrowAtt1[i].Tag = (object) this.m_CurrentFormation.PlayingRoles[i];
        this.m_LabelArrowDef1[i].Tag = (object) this.m_CurrentFormation.PlayingRoles[i];
        this.PutLabelsOnField(i);
      }
      this.comboBox1.SelectedItem = (object) formation.PlayingRoles[0].Role;
      this.comboBox2.SelectedItem = (object) formation.PlayingRoles[1].Role;
      this.comboBox3.SelectedItem = (object) formation.PlayingRoles[2].Role;
      this.comboBox4.SelectedItem = (object) formation.PlayingRoles[3].Role;
      this.comboBox5.SelectedItem = (object) formation.PlayingRoles[4].Role;
      this.comboBox6.SelectedItem = (object) formation.PlayingRoles[5].Role;
      this.comboBox7.SelectedItem = (object) formation.PlayingRoles[6].Role;
      this.comboBox8.SelectedItem = (object) formation.PlayingRoles[7].Role;
      this.comboBox9.SelectedItem = (object) formation.PlayingRoles[8].Role;
      this.comboBox10.SelectedItem = (object) formation.PlayingRoles[9].Role;
      this.comboBox11.SelectedItem = (object) formation.PlayingRoles[10].Role;
      this.m_PositioningFlag = false;
      this.checkIsSweeper.Checked = formation.formations_issweeper != 0;
      this.textName.Text = formation.formationfullname;
      this.comboOffensiveRating.SelectedIndex = formation.offensiverating;
      this.labelAssignTeam.Text = formation.Team != null ? formation.Team.ToString() : "Generic";
      if (FifaEnvironment.Year == 14)
        return;
      for (int playerIndex = 1; playerIndex < 11; ++playerIndex)
        this.ShowPlayerInstruction(playerIndex);
    }

    private void ShowPlayerInstruction(int playerIndex)
    {
      int id = this.m_CurrentFormation.PlayingRoles[playerIndex].Role.Id;
      int num = PlayingRole.c_InstrucionNumber[id];
      for (int index = 0; index < 5; ++index)
      {
        this.m_ComboPlayerInstructions[playerIndex, index].Visible = index < num;
        this.m_ComboPlayerInstructions[playerIndex, index].Items.Clear();
      }
      for (int index1 = 0; index1 < num; ++index1)
      {
        int index2 = PlayingRole.c_InstrucionSetSelection[id, index1];
        this.m_ComboPlayerInstructions[playerIndex, index1].Tag = (object) index2;
        for (int index3 = 0; index3 < PlayingRole.c_InstrucionSet[index2].Length; ++index3)
        {
          int index4 = PlayingRole.c_InstrucionSet[index2][index3];
          string str = PlayingRole.c_InstructionCaption[index4];
          this.m_ComboPlayerInstructions[playerIndex, index1].Items.Add((object) str);
          if ((this.m_CurrentFormation.PlayingRoles[playerIndex].PlayerInstruction & 1 << index4) != 0)
            this.m_ComboPlayerInstructions[playerIndex, index1].SelectedIndex = index3;
        }
      }
    }

    private void ComboRoleSelectedIndexChanged(object sender, int i)
    {
      if (this.m_PositioningFlag)
        return;
      ComboBox comboBox = (ComboBox) sender;
      if (comboBox.SelectedIndex < 0)
        return;
      Role selectedItem = (Role) comboBox.SelectedItem;
      Role role = this.m_CurrentFormation.PlayingRoles[i].Role;
      this.m_CurrentFormation.PlayingRoles[i].Role = selectedItem;
      this.m_CurrentFormation.PlayingRoles[i].PlayerInstruction = PlayingRole.GetDefaultInstruction(selectedItem.Id);
      Point center = selectedItem.GetCenter();
      this.m_CurrentFormation.PlayingRoles[i].OffsetX = center.X;
      this.m_CurrentFormation.PlayingRoles[i].OffsetY = center.Y;
      this.PutLabelsOnField(i);
      foreach (Team team in (ArrayList) FifaEnvironment.Teams)
      {
        if (team.Formation == this.m_CurrentFormation)
          team.Roster.ChangeRole(role, selectedItem);
      }
      this.ShowPlayerInstruction(i);
    }

    private void comboInstruction_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.m_PositioningFlag)
        return;
      ComboBox comboBox = (ComboBox) sender;
      if (comboBox.SelectedIndex < 0)
        return;
      int index1 = -1;
      int index2 = -1;
      for (int index3 = 0; index3 < 11; ++index3)
      {
        for (int index4 = 0; index4 < 4; ++index4)
        {
          if (this.m_ComboPlayerInstructions[index3, index4] == comboBox)
          {
            index1 = index3;
            index2 = index4;
          }
        }
      }
      if (index1 <= 0 || index2 < 0)
        return;
      int id = this.m_CurrentFormation.PlayingRoles[index1].Role.Id;
      int index5 = PlayingRole.c_InstrucionSetSelection[id, index2];
      int num1 = PlayingRole.c_InstrucionSet[index5][comboBox.SelectedIndex];
      for (int index3 = 0; index3 < PlayingRole.c_InstrucionSet[index5].Length; ++index3)
      {
        int num2 = PlayingRole.c_InstrucionSet[index5][index3];
        if (num2 == num1)
          this.m_CurrentFormation.PlayingRoles[index1].PlayerInstruction |= 1 << num2;
        else
          this.m_CurrentFormation.PlayingRoles[index1].PlayerInstruction &= ~(1 << num2);
      }
    }

    private void textName_TextChanged(object sender, EventArgs e)
    {
      this.m_CurrentFormation.Name = this.textName.Text;
      this.pickUpControl.SwitchObject((IdObject) this.m_CurrentFormation);
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 1);
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 2);
    }

    private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 3);
    }

    private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 4);
    }

    private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 5);
    }

    private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 6);
    }

    private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 7);
    }

    private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 8);
    }

    private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 9);
    }

    private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ComboRoleSelectedIndexChanged(sender, 10);
    }

    public void Preset()
    {
      this.m_NewIdCreator.IdList = (IdArrayList) FifaEnvironment.Formations;
      this.pickUpControl.FilterValues = new IdArrayList[4]
      {
        (IdArrayList) null,
        (IdArrayList) FifaEnvironment.Leagues,
        (IdArrayList) FifaEnvironment.Countries,
        (IdArrayList) FifaEnvironment.Teams
      };
      this.comboBox1.Items.Clear();
      this.comboBox1.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox2.Items.Clear();
      this.comboBox2.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox3.Items.Clear();
      this.comboBox3.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox4.Items.Clear();
      this.comboBox4.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox5.Items.Clear();
      this.comboBox5.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox6.Items.Clear();
      this.comboBox6.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox7.Items.Clear();
      this.comboBox7.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox8.Items.Clear();
      this.comboBox8.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox9.Items.Clear();
      this.comboBox9.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox10.Items.Clear();
      this.comboBox10.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboBox11.Items.Clear();
      this.comboBox11.Items.AddRange(FifaEnvironment.Roles.ToArray());
      this.comboFormation.Items.Clear();
      foreach (Formation formation in (ArrayList) FifaEnvironment.Formations)
      {
        if (formation.IsGeneric())
          this.comboFormation.Items.Add((object) formation);
      }
      this.pickUpControl.ObjectList = (IdArrayList) FifaEnvironment.Formations;
      this.groupInstructions.Visible = FifaEnvironment.Year != 14;
    }

    private void PutLabelsOnField(int i)
    {
      int offsetX = this.m_CurrentFormation.PlayingRoles[i].OffsetX;
      int offsetY = this.m_CurrentFormation.PlayingRoles[i].OffsetY;
      int fieldX = this.OffsetToFieldX(offsetX);
      int fieldY = this.OffsetToFieldY(offsetY);
      this.m_LabelPos[i].Location = new Point(fieldX, fieldY);
      int x = fieldX - 16;
      int y = fieldY - 16;
      this.m_LabelArrowAtt1[i].Location = new Point(x, y);
      this.m_LabelArrowDef1[i].Location = new Point(x, y);
      this.m_LabelArrowAtt1[i].ImageIndex = this.ComputeOffensiveImageIndex(i);
      this.m_LabelArrowDef1[i].ImageIndex = this.ComputeDefensiveImageIndex(i);
    }

    private int ComputeOffensiveImageIndex(int roleIndex)
    {
      return this.ComputeOffensiveImageIndex(this.m_CurrentFormation.PlayingRoles[roleIndex]);
    }

    private int ComputeOffensiveImageIndex(PlayingRole playingRole)
    {
      EPlayingDirection offDirection0 = playingRole.OffDirection0;
      EPlayingIntensity offIntensity = playingRole.OffIntensity;
      int num = 0;
      switch (offIntensity)
      {
        case EPlayingIntensity.Normal:
          num = 0;
          break;
        case EPlayingIntensity.Poor:
          num = 9;
          break;
        case EPlayingIntensity.Intense:
          num = 18;
          break;
        case EPlayingIntensity.UsePlayer:
          num = 27;
          break;
      }
      switch (offDirection0)
      {
        case EPlayingDirection.Standing:
          num = num;
          break;
        case EPlayingDirection.Left:
          num += 3;
          break;
        case EPlayingDirection.DiagonalLeft:
          num += 2;
          break;
        case EPlayingDirection.Stright:
          ++num;
          break;
        case EPlayingDirection.DiagonalRight:
          num += 8;
          break;
        case EPlayingDirection.Right:
          num += 7;
          break;
      }
      return num;
    }

    private int ComputeDefensiveImageIndex(int roleIndex)
    {
      return this.ComputeDefensiveImageIndex(this.m_CurrentFormation.PlayingRoles[roleIndex]);
    }

    private int ComputeDefensiveImageIndex(PlayingRole playingRole)
    {
      EPlayingDirection defDirection0 = playingRole.DefDirection0;
      EPlayingIntensity defIntensity = playingRole.DefIntensity;
      int num = 0;
      switch (defIntensity)
      {
        case EPlayingIntensity.Normal:
          num = 0;
          break;
        case EPlayingIntensity.Poor:
          num = 9;
          break;
        case EPlayingIntensity.Intense:
          num = 18;
          break;
        case EPlayingIntensity.UsePlayer:
          num = 27;
          break;
      }
      switch (defDirection0)
      {
        case EPlayingDirection.Standing:
          num = num;
          break;
        case EPlayingDirection.Left:
          num += 3;
          break;
        case EPlayingDirection.DiagonalLeft:
          num += 4;
          break;
        case EPlayingDirection.Stright:
          num += 5;
          break;
        case EPlayingDirection.DiagonalRight:
          num += 6;
          break;
        case EPlayingDirection.Right:
          num += 7;
          break;
      }
      return num;
    }

    private int FieldXToOffset(int x)
    {
      return (250 - (x + 8)) * 2 / 5;
    }

    private int FieldYToOffset(int y)
    {
      return (y + 8) * 2 / 7;
    }

    private int OffsetToFieldX(int x)
    {
      return 250 - (x * 2 + x / 2) - 8;
    }

    private int OffsetToFieldY(int y)
    {
      return y * 3 + y / 2 - 8;
    }

    private void MouseUpService(object sender, MouseEventArgs e)
    {
      int x = this.m_MovingLabel.Location.X;
      int y = this.m_MovingLabel.Location.Y;
      this.m_MovingLabel = (Label) null;
      if (this.m_MovingLabelIndex < 0)
        return;
      this.m_CurrentFormation.PlayingRoles[this.m_MovingLabelIndex].m_OffsetX = this.FieldXToOffset(x);
      this.m_CurrentFormation.PlayingRoles[this.m_MovingLabelIndex].m_OffsetY = this.FieldYToOffset(y);
      this.PutLabelsOnField(this.m_MovingLabelIndex);
    }

    private void MouseMoveService(object sender, MouseEventArgs e)
    {
      if (this.m_MovingLabel == null)
        return;
      this.MovePicture(e, this.m_MovingLabel);
    }

    private void MouseDownService(object sender, MouseEventArgs e)
    {
      this.m_MovingLabel = (Label) sender;
      this.m_MovingLabelIndex = -1;
      for (int index = 0; index < 11; ++index)
      {
        if (this.m_MovingLabel == this.m_LabelPos[index])
        {
          this.m_MovingLabelIndex = index;
          this.m_BoundRight = this.OffsetToFieldX(this.m_CurrentFormation.PlayingRoles[index].Role.Xmin);
          this.m_BoundLeft = this.OffsetToFieldX(this.m_CurrentFormation.PlayingRoles[index].Role.Xmax);
          this.m_BoundTop = this.OffsetToFieldY(this.m_CurrentFormation.PlayingRoles[index].Role.Ymin);
          this.m_BoundBottom = this.OffsetToFieldY(this.m_CurrentFormation.PlayingRoles[index].Role.Ymax);
          break;
        }
      }
    }

    private void MovePicture(MouseEventArgs e, Label picture)
    {
      int num1 = e.X - 8;
      int num2 = e.Y - 8;
      this.m_LabelLocation.X = picture.Location.X + num1;
      this.m_LabelLocation.Y = picture.Location.Y + num2;
      if (this.m_LabelLocation.X < this.m_BoundLeft)
        this.m_LabelLocation.X = this.m_BoundLeft;
      if (this.m_LabelLocation.X > this.m_BoundRight)
        this.m_LabelLocation.X = this.m_BoundRight;
      if (this.m_LabelLocation.Y < this.m_BoundTop)
        this.m_LabelLocation.Y = this.m_BoundTop;
      if (this.m_LabelLocation.Y > this.m_BoundBottom)
        this.m_LabelLocation.Y = this.m_BoundBottom;
      picture.Location = this.m_LabelLocation;
    }

    private void labelAtt_Click(object sender, EventArgs e)
    {
      Label label = (Label) sender;
      PlayingRole tag = (PlayingRole) label.Tag;
      EPlayingDirection attackRole = this.ClickToAttackRole(e);
      tag.OffDirection0 = attackRole;
      label.ImageIndex = this.ComputeOffensiveImageIndex(tag);
    }

    private void labelAtt_DoubleClick(object sender, EventArgs e)
    {
      Label label = (Label) sender;
      PlayingRole tag = (PlayingRole) label.Tag;
      switch (tag.OffIntensity)
      {
        case EPlayingIntensity.Normal:
          tag.OffIntensity = EPlayingIntensity.Poor;
          break;
        case EPlayingIntensity.Poor:
          tag.OffIntensity = EPlayingIntensity.Intense;
          break;
        case EPlayingIntensity.Intense:
          tag.OffIntensity = EPlayingIntensity.UsePlayer;
          break;
        case EPlayingIntensity.UsePlayer:
          tag.OffIntensity = EPlayingIntensity.Normal;
          break;
      }
      label.ImageIndex = this.ComputeOffensiveImageIndex(tag);
    }

    private void labelDef_Click(object sender, EventArgs e)
    {
      Label label = (Label) sender;
      PlayingRole tag = (PlayingRole) label.Tag;
      EPlayingDirection defenseRole = this.ClickToDefenseRole(e);
      tag.DefDirection0 = defenseRole;
      label.ImageIndex = this.ComputeDefensiveImageIndex(tag);
    }

    private void labelDef_DoubleClick(object sender, EventArgs e)
    {
      Label label = (Label) sender;
      PlayingRole tag = (PlayingRole) label.Tag;
      switch (tag.DefIntensity)
      {
        case EPlayingIntensity.Normal:
          tag.DefIntensity = EPlayingIntensity.Poor;
          break;
        case EPlayingIntensity.Poor:
          tag.DefIntensity = EPlayingIntensity.Intense;
          break;
        case EPlayingIntensity.Intense:
          tag.DefIntensity = EPlayingIntensity.UsePlayer;
          break;
        case EPlayingIntensity.UsePlayer:
          tag.DefIntensity = EPlayingIntensity.Normal;
          break;
      }
      label.ImageIndex = this.ComputeDefensiveImageIndex(tag);
    }

    private EPlayingDirection ClickToAttackRole(EventArgs e)
    {
      int x = ((MouseEventArgs) e).X;
      int y = ((MouseEventArgs) e).Y;
      return x >= 16 ? (x >= 32 ? (y >= 16 ? (y >= 32 ? EPlayingDirection.DiagonalLeft : EPlayingDirection.Left) : EPlayingDirection.Left) : (y >= 16 ? (y >= 32 ? EPlayingDirection.Stright : EPlayingDirection.Standing) : EPlayingDirection.Standing)) : (y >= 16 ? (y >= 32 ? EPlayingDirection.DiagonalRight : EPlayingDirection.Right) : EPlayingDirection.Right);
    }

    private EPlayingDirection ClickToDefenseRole(EventArgs e)
    {
      int x = ((MouseEventArgs) e).X;
      int y = ((MouseEventArgs) e).Y;
      return x >= 16 ? (x >= 32 ? (y >= 16 ? (y >= 32 ? EPlayingDirection.Left : EPlayingDirection.Left) : EPlayingDirection.DiagonalLeft) : (y >= 16 ? (y >= 32 ? EPlayingDirection.Standing : EPlayingDirection.Standing) : EPlayingDirection.Stright)) : (y >= 16 ? (y >= 32 ? EPlayingDirection.Right : EPlayingDirection.Right) : EPlayingDirection.DiagonalRight);
    }

    private void buttonPresetFormation_Click(object sender, EventArgs e)
    {
      Formation selectedItem = (Formation) this.comboFormation.SelectedItem;
      if (selectedItem != null)
        this.m_CurrentFormation.ReInitialize(selectedItem);
      if (this.m_CurrentFormation.Team != null)
        this.m_CurrentFormation.Team.AssignTitolarToRoles(this.m_CurrentFormation);
      this.ReloadFormation(this.m_CurrentFormation);
    }

    private void checkIsSweeper_CheckedChanged(object sender, EventArgs e)
    {
      if (this.m_LockUserChanges)
        return;
      this.m_CurrentFormation.formations_issweeper = this.checkIsSweeper.Checked ? 1 : 0;
    }

    private void comboOffensiveRating_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboOffensiveRating.SelectedIndex < 0)
        return;
      this.m_CurrentFormation.offensiverating = this.comboOffensiveRating.SelectedIndex;
    }

    private void labelAssignTeam_DoubleClick(object sender, EventArgs e)
    {
      if (this.m_CurrentFormation.Team == null)
        return;
      MainForm.CM.JumpTo((IdObject) this.m_CurrentFormation.Team);
    }
  }
}
