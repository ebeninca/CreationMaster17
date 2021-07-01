// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FifaControls
{
  public class WeatherForm : Form
  {
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private NumericUpDown numericJanOvercast;
    private DomainUpDown domainJanSunset;
    private DomainUpDown domainJanDark;
    private NumericUpDown numericJanRain;
    private NumericUpDown numericJanSnow;
    private NumericUpDown numericUpDown1;
    private NumericUpDown numericUpDown2;
    private DomainUpDown domainUpDown1;
    private DomainUpDown domainUpDown2;
    private NumericUpDown numericFebOvercast;
    private Label label9;
    private NumericUpDown numericUpDown3;
    private NumericUpDown numericUpDown4;
    private DomainUpDown domainUpDown3;
    private DomainUpDown domainUpDown4;
    private NumericUpDown numericUpDown5;
    private Label label10;
    private NumericUpDown numericUpDown6;
    private NumericUpDown numericUpDown7;
    private DomainUpDown domainUpDown5;
    private DomainUpDown domainUpDown6;
    private NumericUpDown numericUpDown8;
    private Label label11;
    private NumericUpDown numericUpDown9;
    private NumericUpDown numericUpDown10;
    private DomainUpDown domainUpDown7;
    private DomainUpDown domainUpDown8;
    private NumericUpDown numericUpDown11;
    private Label label12;
    private NumericUpDown numericUpDown12;
    private NumericUpDown numericUpDown13;
    private DomainUpDown domainUpDown9;
    private DomainUpDown domainUpDown10;
    private NumericUpDown numericUpDown14;
    private Label label13;
    private NumericUpDown numericUpDown15;
    private NumericUpDown numericUpDown16;
    private DomainUpDown domainUpDown11;
    private DomainUpDown domainUpDown12;
    private NumericUpDown numericUpDown17;
    private Label label14;
    private NumericUpDown numericUpDown18;
    private NumericUpDown numericUpDown19;
    private DomainUpDown domainUpDown13;
    private DomainUpDown domainUpDown14;
    private NumericUpDown numericUpDown20;
    private Label label15;
    private NumericUpDown numericUpDown21;
    private NumericUpDown numericUpDown22;
    private DomainUpDown domainUpDown15;
    private DomainUpDown domainUpDown16;
    private NumericUpDown numericUpDown23;
    private Label label16;
    private NumericUpDown numericUpDown24;
    private NumericUpDown numericUpDown25;
    private DomainUpDown domainUpDown17;
    private DomainUpDown domainUpDown18;
    private NumericUpDown numericUpDown26;
    private Label label17;
    private NumericUpDown numericUpDown27;
    private NumericUpDown numericUpDown28;
    private DomainUpDown domainUpDown19;
    private DomainUpDown domainUpDown20;
    private NumericUpDown numericUpDown29;
    private Label label18;
    private NumericUpDown numericUpDown30;
    private NumericUpDown numericUpDown31;
    private DomainUpDown domainUpDown21;
    private DomainUpDown domainUpDown22;
    private NumericUpDown numericUpDown32;
    private Label label19;
    private Button buttonOk;
    private Button buttonCancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager resources = new ComponentResourceManager(typeof (WeatherForm));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.numericJanOvercast = new NumericUpDown();
      this.domainJanSunset = new DomainUpDown();
      this.domainJanDark = new DomainUpDown();
      this.numericJanRain = new NumericUpDown();
      this.numericJanSnow = new NumericUpDown();
      this.numericUpDown1 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.domainUpDown1 = new DomainUpDown();
      this.domainUpDown2 = new DomainUpDown();
      this.numericFebOvercast = new NumericUpDown();
      this.label9 = new Label();
      this.numericUpDown3 = new NumericUpDown();
      this.numericUpDown4 = new NumericUpDown();
      this.domainUpDown3 = new DomainUpDown();
      this.domainUpDown4 = new DomainUpDown();
      this.numericUpDown5 = new NumericUpDown();
      this.label10 = new Label();
      this.numericUpDown6 = new NumericUpDown();
      this.numericUpDown7 = new NumericUpDown();
      this.domainUpDown5 = new DomainUpDown();
      this.domainUpDown6 = new DomainUpDown();
      this.numericUpDown8 = new NumericUpDown();
      this.label11 = new Label();
      this.numericUpDown9 = new NumericUpDown();
      this.numericUpDown10 = new NumericUpDown();
      this.domainUpDown7 = new DomainUpDown();
      this.domainUpDown8 = new DomainUpDown();
      this.numericUpDown11 = new NumericUpDown();
      this.label12 = new Label();
      this.numericUpDown12 = new NumericUpDown();
      this.numericUpDown13 = new NumericUpDown();
      this.domainUpDown9 = new DomainUpDown();
      this.domainUpDown10 = new DomainUpDown();
      this.numericUpDown14 = new NumericUpDown();
      this.label13 = new Label();
      this.numericUpDown15 = new NumericUpDown();
      this.numericUpDown16 = new NumericUpDown();
      this.domainUpDown11 = new DomainUpDown();
      this.domainUpDown12 = new DomainUpDown();
      this.numericUpDown17 = new NumericUpDown();
      this.label14 = new Label();
      this.numericUpDown18 = new NumericUpDown();
      this.numericUpDown19 = new NumericUpDown();
      this.domainUpDown13 = new DomainUpDown();
      this.domainUpDown14 = new DomainUpDown();
      this.numericUpDown20 = new NumericUpDown();
      this.label15 = new Label();
      this.numericUpDown21 = new NumericUpDown();
      this.numericUpDown22 = new NumericUpDown();
      this.domainUpDown15 = new DomainUpDown();
      this.domainUpDown16 = new DomainUpDown();
      this.numericUpDown23 = new NumericUpDown();
      this.label16 = new Label();
      this.numericUpDown24 = new NumericUpDown();
      this.numericUpDown25 = new NumericUpDown();
      this.domainUpDown17 = new DomainUpDown();
      this.domainUpDown18 = new DomainUpDown();
      this.numericUpDown26 = new NumericUpDown();
      this.label17 = new Label();
      this.numericUpDown27 = new NumericUpDown();
      this.numericUpDown28 = new NumericUpDown();
      this.domainUpDown19 = new DomainUpDown();
      this.domainUpDown20 = new DomainUpDown();
      this.numericUpDown29 = new NumericUpDown();
      this.label18 = new Label();
      this.numericUpDown30 = new NumericUpDown();
      this.numericUpDown31 = new NumericUpDown();
      this.domainUpDown21 = new DomainUpDown();
      this.domainUpDown22 = new DomainUpDown();
      this.numericUpDown32 = new NumericUpDown();
      this.label19 = new Label();
      this.buttonOk = new Button();
      this.buttonCancel = new Button();
      this.numericJanOvercast.BeginInit();
      this.numericJanRain.BeginInit();
      this.numericJanSnow.BeginInit();
      this.numericUpDown1.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericFebOvercast.BeginInit();
      this.numericUpDown3.BeginInit();
      this.numericUpDown4.BeginInit();
      this.numericUpDown5.BeginInit();
      this.numericUpDown6.BeginInit();
      this.numericUpDown7.BeginInit();
      this.numericUpDown8.BeginInit();
      this.numericUpDown9.BeginInit();
      this.numericUpDown10.BeginInit();
      this.numericUpDown11.BeginInit();
      this.numericUpDown12.BeginInit();
      this.numericUpDown13.BeginInit();
      this.numericUpDown14.BeginInit();
      this.numericUpDown15.BeginInit();
      this.numericUpDown16.BeginInit();
      this.numericUpDown17.BeginInit();
      this.numericUpDown18.BeginInit();
      this.numericUpDown19.BeginInit();
      this.numericUpDown20.BeginInit();
      this.numericUpDown21.BeginInit();
      this.numericUpDown22.BeginInit();
      this.numericUpDown23.BeginInit();
      this.numericUpDown24.BeginInit();
      this.numericUpDown25.BeginInit();
      this.numericUpDown26.BeginInit();
      this.numericUpDown27.BeginInit();
      this.numericUpDown28.BeginInit();
      this.numericUpDown29.BeginInit();
      this.numericUpDown30.BeginInit();
      this.numericUpDown31.BeginInit();
      this.numericUpDown32.BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(19, 66);
      this.label1.Name = "label1";
      this.label1.Size = new Size(27, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "JAN";
      this.label2.BorderStyle = BorderStyle.FixedSingle;
      this.label2.Location = new Point(55, 9);
      this.label2.Name = "label2";
      this.label2.Size = new Size(248, 23);
      this.label2.TabIndex = 1;
      this.label2.Text = "Probability";
      this.label2.TextAlign = ContentAlignment.MiddleCenter;
      this.label3.BorderStyle = BorderStyle.FixedSingle;
      this.label3.Location = new Point(55, 34);
      this.label3.Name = "label3";
      this.label3.Size = new Size(79, 23);
      this.label3.TabIndex = 2;
      this.label3.Text = "Overcast";
      this.label3.TextAlign = ContentAlignment.MiddleCenter;
      this.label4.BorderStyle = BorderStyle.FixedSingle;
      this.label4.Location = new Point(139, 34);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 23);
      this.label4.TabIndex = 3;
      this.label4.Text = "Rain";
      this.label4.TextAlign = ContentAlignment.MiddleCenter;
      this.label5.BorderStyle = BorderStyle.FixedSingle;
      this.label5.Location = new Point(224, 34);
      this.label5.Name = "label5";
      this.label5.Size = new Size(79, 23);
      this.label5.TabIndex = 4;
      this.label5.Text = "Snow";
      this.label5.TextAlign = ContentAlignment.MiddleCenter;
      this.label6.BorderStyle = BorderStyle.FixedSingle;
      this.label6.Location = new Point(309, 9);
      this.label6.Name = "label6";
      this.label6.Size = new Size(163, 23);
      this.label6.TabIndex = 5;
      this.label6.Text = "Time";
      this.label6.TextAlign = ContentAlignment.MiddleCenter;
      this.label7.BorderStyle = BorderStyle.FixedSingle;
      this.label7.Location = new Point(393, 34);
      this.label7.Name = "label7";
      this.label7.Size = new Size(79, 23);
      this.label7.TabIndex = 7;
      this.label7.Text = "Totall Dark";
      this.label7.TextAlign = ContentAlignment.MiddleCenter;
      this.label8.BorderStyle = BorderStyle.FixedSingle;
      this.label8.Location = new Point(309, 34);
      this.label8.Name = "label8";
      this.label8.Size = new Size(79, 23);
      this.label8.TabIndex = 6;
      this.label8.Text = "Sunset";
      this.label8.TextAlign = ContentAlignment.MiddleCenter;
      this.numericJanOvercast.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericJanOvercast.Location = new Point(55, 64);
      this.numericJanOvercast.Name = "numericJanOvercast";
      this.numericJanOvercast.Size = new Size(79, 20);
      this.numericJanOvercast.TabIndex = 8;
      this.numericJanOvercast.TextAlign = HorizontalAlignment.Center;
      this.domainJanSunset.Items.Add((object) "16.00");
      this.domainJanSunset.Items.Add((object) "16.30");
      this.domainJanSunset.Items.Add((object) "17.00");
      this.domainJanSunset.Items.Add((object) "17.30");
      this.domainJanSunset.Items.Add((object) "18.00");
      this.domainJanSunset.Items.Add((object) "18.30");
      this.domainJanSunset.Items.Add((object) "19.00");
      this.domainJanSunset.Items.Add((object) "19.30");
      this.domainJanSunset.Items.Add((object) "20.00");
      this.domainJanSunset.Location = new Point(309, 64);
      this.domainJanSunset.Name = "domainJanSunset";
      this.domainJanSunset.Size = new Size(79, 20);
      this.domainJanSunset.TabIndex = 9;
      this.domainJanDark.Items.Add((object) "17.00");
      this.domainJanDark.Items.Add((object) "17.30");
      this.domainJanDark.Items.Add((object) "18.00");
      this.domainJanDark.Items.Add((object) "18.30");
      this.domainJanDark.Items.Add((object) "19.00");
      this.domainJanDark.Items.Add((object) "19.30");
      this.domainJanDark.Items.Add((object) "20.00");
      this.domainJanDark.Items.Add((object) "20.30");
      this.domainJanDark.Items.Add((object) "21.00");
      this.domainJanDark.Items.Add((object) "21.30");
      this.domainJanDark.Items.Add((object) "22.00");
      this.domainJanDark.Items.Add((object) "22.30");
      this.domainJanDark.Location = new Point(393, 64);
      this.domainJanDark.Name = "domainJanDark";
      this.domainJanDark.Size = new Size(79, 20);
      this.domainJanDark.TabIndex = 10;
      this.numericJanRain.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericJanRain.Location = new Point(139, 64);
      this.numericJanRain.Name = "numericJanRain";
      this.numericJanRain.Size = new Size(79, 20);
      this.numericJanRain.TabIndex = 11;
      this.numericJanRain.TextAlign = HorizontalAlignment.Center;
      this.numericJanSnow.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericJanSnow.Location = new Point(224, 64);
      this.numericJanSnow.Name = "numericJanSnow";
      this.numericJanSnow.Size = new Size(79, 20);
      this.numericJanSnow.TabIndex = 12;
      this.numericJanSnow.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown1.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown1.Location = new Point(224, 91);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(79, 20);
      this.numericUpDown1.TabIndex = 18;
      this.numericUpDown1.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown2.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown2.Location = new Point(139, 91);
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(79, 20);
      this.numericUpDown2.TabIndex = 17;
      this.numericUpDown2.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown1.Items.Add((object) "17.00");
      this.domainUpDown1.Items.Add((object) "17.30");
      this.domainUpDown1.Items.Add((object) "18.00");
      this.domainUpDown1.Items.Add((object) "18.30");
      this.domainUpDown1.Items.Add((object) "19.00");
      this.domainUpDown1.Items.Add((object) "19.30");
      this.domainUpDown1.Items.Add((object) "20.00");
      this.domainUpDown1.Items.Add((object) "20.30");
      this.domainUpDown1.Items.Add((object) "21.00");
      this.domainUpDown1.Items.Add((object) "21.30");
      this.domainUpDown1.Items.Add((object) "22.00");
      this.domainUpDown1.Items.Add((object) "22.30");
      this.domainUpDown1.Location = new Point(393, 91);
      this.domainUpDown1.Name = "domainUpDown1";
      this.domainUpDown1.Size = new Size(79, 20);
      this.domainUpDown1.TabIndex = 16;
      this.domainUpDown2.Items.Add((object) "16.00");
      this.domainUpDown2.Items.Add((object) "16.30");
      this.domainUpDown2.Items.Add((object) "17.00");
      this.domainUpDown2.Items.Add((object) "17.30");
      this.domainUpDown2.Items.Add((object) "18.00");
      this.domainUpDown2.Items.Add((object) "18.30");
      this.domainUpDown2.Items.Add((object) "19.00");
      this.domainUpDown2.Items.Add((object) "19.30");
      this.domainUpDown2.Items.Add((object) "20.00");
      this.domainUpDown2.Location = new Point(309, 91);
      this.domainUpDown2.Name = "domainUpDown2";
      this.domainUpDown2.Size = new Size(79, 20);
      this.domainUpDown2.TabIndex = 15;
      this.numericFebOvercast.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericFebOvercast.Location = new Point(55, 91);
      this.numericFebOvercast.Name = "numericFebOvercast";
      this.numericFebOvercast.Size = new Size(79, 20);
      this.numericFebOvercast.TabIndex = 14;
      this.numericFebOvercast.TextAlign = HorizontalAlignment.Center;
      this.label9.AutoSize = true;
      this.label9.Location = new Point(19, 93);
      this.label9.Name = "label9";
      this.label9.Size = new Size(27, 13);
      this.label9.TabIndex = 13;
      this.label9.Text = "FEB";
      this.numericUpDown3.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown3.Location = new Point(224, 117);
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(79, 20);
      this.numericUpDown3.TabIndex = 24;
      this.numericUpDown3.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown4.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown4.Location = new Point(139, 117);
      this.numericUpDown4.Name = "numericUpDown4";
      this.numericUpDown4.Size = new Size(79, 20);
      this.numericUpDown4.TabIndex = 23;
      this.numericUpDown4.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown3.Items.Add((object) "17.00");
      this.domainUpDown3.Items.Add((object) "17.30");
      this.domainUpDown3.Items.Add((object) "18.00");
      this.domainUpDown3.Items.Add((object) "18.30");
      this.domainUpDown3.Items.Add((object) "19.00");
      this.domainUpDown3.Items.Add((object) "19.30");
      this.domainUpDown3.Items.Add((object) "20.00");
      this.domainUpDown3.Items.Add((object) "20.30");
      this.domainUpDown3.Items.Add((object) "21.00");
      this.domainUpDown3.Items.Add((object) "21.30");
      this.domainUpDown3.Items.Add((object) "22.00");
      this.domainUpDown3.Items.Add((object) "22.30");
      this.domainUpDown3.Location = new Point(393, 117);
      this.domainUpDown3.Name = "domainUpDown3";
      this.domainUpDown3.Size = new Size(79, 20);
      this.domainUpDown3.TabIndex = 22;
      this.domainUpDown4.Items.Add((object) "16.00");
      this.domainUpDown4.Items.Add((object) "16.30");
      this.domainUpDown4.Items.Add((object) "17.00");
      this.domainUpDown4.Items.Add((object) "17.30");
      this.domainUpDown4.Items.Add((object) "18.00");
      this.domainUpDown4.Items.Add((object) "18.30");
      this.domainUpDown4.Items.Add((object) "19.00");
      this.domainUpDown4.Items.Add((object) "19.30");
      this.domainUpDown4.Items.Add((object) "20.00");
      this.domainUpDown4.Location = new Point(309, 117);
      this.domainUpDown4.Name = "domainUpDown4";
      this.domainUpDown4.Size = new Size(79, 20);
      this.domainUpDown4.TabIndex = 21;
      this.numericUpDown5.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown5.Location = new Point(55, 117);
      this.numericUpDown5.Name = "numericUpDown5";
      this.numericUpDown5.Size = new Size(79, 20);
      this.numericUpDown5.TabIndex = 20;
      this.numericUpDown5.TextAlign = HorizontalAlignment.Center;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(19, 119);
      this.label10.Name = "label10";
      this.label10.Size = new Size(27, 13);
      this.label10.TabIndex = 19;
      this.label10.Text = "FEB";
      this.numericUpDown6.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown6.Location = new Point(224, 143);
      this.numericUpDown6.Name = "numericUpDown6";
      this.numericUpDown6.Size = new Size(79, 20);
      this.numericUpDown6.TabIndex = 30;
      this.numericUpDown6.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown7.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown7.Location = new Point(139, 143);
      this.numericUpDown7.Name = "numericUpDown7";
      this.numericUpDown7.Size = new Size(79, 20);
      this.numericUpDown7.TabIndex = 29;
      this.numericUpDown7.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown5.Items.Add((object) "17.00");
      this.domainUpDown5.Items.Add((object) "17.30");
      this.domainUpDown5.Items.Add((object) "18.00");
      this.domainUpDown5.Items.Add((object) "18.30");
      this.domainUpDown5.Items.Add((object) "19.00");
      this.domainUpDown5.Items.Add((object) "19.30");
      this.domainUpDown5.Items.Add((object) "20.00");
      this.domainUpDown5.Items.Add((object) "20.30");
      this.domainUpDown5.Items.Add((object) "21.00");
      this.domainUpDown5.Items.Add((object) "21.30");
      this.domainUpDown5.Items.Add((object) "22.00");
      this.domainUpDown5.Items.Add((object) "22.30");
      this.domainUpDown5.Location = new Point(393, 143);
      this.domainUpDown5.Name = "domainUpDown5";
      this.domainUpDown5.Size = new Size(79, 20);
      this.domainUpDown5.TabIndex = 28;
      this.domainUpDown6.Items.Add((object) "16.00");
      this.domainUpDown6.Items.Add((object) "16.30");
      this.domainUpDown6.Items.Add((object) "17.00");
      this.domainUpDown6.Items.Add((object) "17.30");
      this.domainUpDown6.Items.Add((object) "18.00");
      this.domainUpDown6.Items.Add((object) "18.30");
      this.domainUpDown6.Items.Add((object) "19.00");
      this.domainUpDown6.Items.Add((object) "19.30");
      this.domainUpDown6.Items.Add((object) "20.00");
      this.domainUpDown6.Location = new Point(309, 143);
      this.domainUpDown6.Name = "domainUpDown6";
      this.domainUpDown6.Size = new Size(79, 20);
      this.domainUpDown6.TabIndex = 27;
      this.numericUpDown8.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown8.Location = new Point(55, 143);
      this.numericUpDown8.Name = "numericUpDown8";
      this.numericUpDown8.Size = new Size(79, 20);
      this.numericUpDown8.TabIndex = 26;
      this.numericUpDown8.TextAlign = HorizontalAlignment.Center;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(19, 145);
      this.label11.Name = "label11";
      this.label11.Size = new Size(27, 13);
      this.label11.TabIndex = 25;
      this.label11.Text = "FEB";
      this.numericUpDown9.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown9.Location = new Point(224, 169);
      this.numericUpDown9.Name = "numericUpDown9";
      this.numericUpDown9.Size = new Size(79, 20);
      this.numericUpDown9.TabIndex = 36;
      this.numericUpDown9.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown10.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown10.Location = new Point(139, 169);
      this.numericUpDown10.Name = "numericUpDown10";
      this.numericUpDown10.Size = new Size(79, 20);
      this.numericUpDown10.TabIndex = 35;
      this.numericUpDown10.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown7.Items.Add((object) "17.00");
      this.domainUpDown7.Items.Add((object) "17.30");
      this.domainUpDown7.Items.Add((object) "18.00");
      this.domainUpDown7.Items.Add((object) "18.30");
      this.domainUpDown7.Items.Add((object) "19.00");
      this.domainUpDown7.Items.Add((object) "19.30");
      this.domainUpDown7.Items.Add((object) "20.00");
      this.domainUpDown7.Items.Add((object) "20.30");
      this.domainUpDown7.Items.Add((object) "21.00");
      this.domainUpDown7.Items.Add((object) "21.30");
      this.domainUpDown7.Items.Add((object) "22.00");
      this.domainUpDown7.Items.Add((object) "22.30");
      this.domainUpDown7.Location = new Point(393, 169);
      this.domainUpDown7.Name = "domainUpDown7";
      this.domainUpDown7.Size = new Size(79, 20);
      this.domainUpDown7.TabIndex = 34;
      this.domainUpDown8.Items.Add((object) "16.00");
      this.domainUpDown8.Items.Add((object) "16.30");
      this.domainUpDown8.Items.Add((object) "17.00");
      this.domainUpDown8.Items.Add((object) "17.30");
      this.domainUpDown8.Items.Add((object) "18.00");
      this.domainUpDown8.Items.Add((object) "18.30");
      this.domainUpDown8.Items.Add((object) "19.00");
      this.domainUpDown8.Items.Add((object) "19.30");
      this.domainUpDown8.Items.Add((object) "20.00");
      this.domainUpDown8.Location = new Point(309, 169);
      this.domainUpDown8.Name = "domainUpDown8";
      this.domainUpDown8.Size = new Size(79, 20);
      this.domainUpDown8.TabIndex = 33;
      this.numericUpDown11.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown11.Location = new Point(55, 169);
      this.numericUpDown11.Name = "numericUpDown11";
      this.numericUpDown11.Size = new Size(79, 20);
      this.numericUpDown11.TabIndex = 32;
      this.numericUpDown11.TextAlign = HorizontalAlignment.Center;
      this.label12.AutoSize = true;
      this.label12.Location = new Point(19, 171);
      this.label12.Name = "label12";
      this.label12.Size = new Size(27, 13);
      this.label12.TabIndex = 31;
      this.label12.Text = "FEB";
      this.numericUpDown12.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown12.Location = new Point(224, 194);
      this.numericUpDown12.Name = "numericUpDown12";
      this.numericUpDown12.Size = new Size(79, 20);
      this.numericUpDown12.TabIndex = 42;
      this.numericUpDown12.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown13.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown13.Location = new Point(139, 194);
      this.numericUpDown13.Name = "numericUpDown13";
      this.numericUpDown13.Size = new Size(79, 20);
      this.numericUpDown13.TabIndex = 41;
      this.numericUpDown13.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown9.Items.Add((object) "17.00");
      this.domainUpDown9.Items.Add((object) "17.30");
      this.domainUpDown9.Items.Add((object) "18.00");
      this.domainUpDown9.Items.Add((object) "18.30");
      this.domainUpDown9.Items.Add((object) "19.00");
      this.domainUpDown9.Items.Add((object) "19.30");
      this.domainUpDown9.Items.Add((object) "20.00");
      this.domainUpDown9.Items.Add((object) "20.30");
      this.domainUpDown9.Items.Add((object) "21.00");
      this.domainUpDown9.Items.Add((object) "21.30");
      this.domainUpDown9.Items.Add((object) "22.00");
      this.domainUpDown9.Items.Add((object) "22.30");
      this.domainUpDown9.Location = new Point(393, 194);
      this.domainUpDown9.Name = "domainUpDown9";
      this.domainUpDown9.Size = new Size(79, 20);
      this.domainUpDown9.TabIndex = 40;
      this.domainUpDown10.Items.Add((object) "16.00");
      this.domainUpDown10.Items.Add((object) "16.30");
      this.domainUpDown10.Items.Add((object) "17.00");
      this.domainUpDown10.Items.Add((object) "17.30");
      this.domainUpDown10.Items.Add((object) "18.00");
      this.domainUpDown10.Items.Add((object) "18.30");
      this.domainUpDown10.Items.Add((object) "19.00");
      this.domainUpDown10.Items.Add((object) "19.30");
      this.domainUpDown10.Items.Add((object) "20.00");
      this.domainUpDown10.Location = new Point(309, 194);
      this.domainUpDown10.Name = "domainUpDown10";
      this.domainUpDown10.Size = new Size(79, 20);
      this.domainUpDown10.TabIndex = 39;
      this.numericUpDown14.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown14.Location = new Point(55, 194);
      this.numericUpDown14.Name = "numericUpDown14";
      this.numericUpDown14.Size = new Size(79, 20);
      this.numericUpDown14.TabIndex = 38;
      this.numericUpDown14.TextAlign = HorizontalAlignment.Center;
      this.label13.AutoSize = true;
      this.label13.Location = new Point(19, 196);
      this.label13.Name = "label13";
      this.label13.Size = new Size(27, 13);
      this.label13.TabIndex = 37;
      this.label13.Text = "FEB";
      this.numericUpDown15.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown15.Location = new Point(224, 218);
      this.numericUpDown15.Name = "numericUpDown15";
      this.numericUpDown15.Size = new Size(79, 20);
      this.numericUpDown15.TabIndex = 48;
      this.numericUpDown15.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown16.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown16.Location = new Point(139, 218);
      this.numericUpDown16.Name = "numericUpDown16";
      this.numericUpDown16.Size = new Size(79, 20);
      this.numericUpDown16.TabIndex = 47;
      this.numericUpDown16.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown11.Items.Add((object) "17.00");
      this.domainUpDown11.Items.Add((object) "17.30");
      this.domainUpDown11.Items.Add((object) "18.00");
      this.domainUpDown11.Items.Add((object) "18.30");
      this.domainUpDown11.Items.Add((object) "19.00");
      this.domainUpDown11.Items.Add((object) "19.30");
      this.domainUpDown11.Items.Add((object) "20.00");
      this.domainUpDown11.Items.Add((object) "20.30");
      this.domainUpDown11.Items.Add((object) "21.00");
      this.domainUpDown11.Items.Add((object) "21.30");
      this.domainUpDown11.Items.Add((object) "22.00");
      this.domainUpDown11.Items.Add((object) "22.30");
      this.domainUpDown11.Location = new Point(393, 218);
      this.domainUpDown11.Name = "domainUpDown11";
      this.domainUpDown11.Size = new Size(79, 20);
      this.domainUpDown11.TabIndex = 46;
      this.domainUpDown12.Items.Add((object) "16.00");
      this.domainUpDown12.Items.Add((object) "16.30");
      this.domainUpDown12.Items.Add((object) "17.00");
      this.domainUpDown12.Items.Add((object) "17.30");
      this.domainUpDown12.Items.Add((object) "18.00");
      this.domainUpDown12.Items.Add((object) "18.30");
      this.domainUpDown12.Items.Add((object) "19.00");
      this.domainUpDown12.Items.Add((object) "19.30");
      this.domainUpDown12.Items.Add((object) "20.00");
      this.domainUpDown12.Location = new Point(309, 218);
      this.domainUpDown12.Name = "domainUpDown12";
      this.domainUpDown12.Size = new Size(79, 20);
      this.domainUpDown12.TabIndex = 45;
      this.numericUpDown17.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown17.Location = new Point(55, 218);
      this.numericUpDown17.Name = "numericUpDown17";
      this.numericUpDown17.Size = new Size(79, 20);
      this.numericUpDown17.TabIndex = 44;
      this.numericUpDown17.TextAlign = HorizontalAlignment.Center;
      this.label14.AutoSize = true;
      this.label14.Location = new Point(19, 220);
      this.label14.Name = "label14";
      this.label14.Size = new Size(27, 13);
      this.label14.TabIndex = 43;
      this.label14.Text = "FEB";
      this.numericUpDown18.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown18.Location = new Point(224, 243);
      this.numericUpDown18.Name = "numericUpDown18";
      this.numericUpDown18.Size = new Size(79, 20);
      this.numericUpDown18.TabIndex = 54;
      this.numericUpDown18.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown19.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown19.Location = new Point(139, 243);
      this.numericUpDown19.Name = "numericUpDown19";
      this.numericUpDown19.Size = new Size(79, 20);
      this.numericUpDown19.TabIndex = 53;
      this.numericUpDown19.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown13.Items.Add((object) "17.00");
      this.domainUpDown13.Items.Add((object) "17.30");
      this.domainUpDown13.Items.Add((object) "18.00");
      this.domainUpDown13.Items.Add((object) "18.30");
      this.domainUpDown13.Items.Add((object) "19.00");
      this.domainUpDown13.Items.Add((object) "19.30");
      this.domainUpDown13.Items.Add((object) "20.00");
      this.domainUpDown13.Items.Add((object) "20.30");
      this.domainUpDown13.Items.Add((object) "21.00");
      this.domainUpDown13.Items.Add((object) "21.30");
      this.domainUpDown13.Items.Add((object) "22.00");
      this.domainUpDown13.Items.Add((object) "22.30");
      this.domainUpDown13.Location = new Point(393, 243);
      this.domainUpDown13.Name = "domainUpDown13";
      this.domainUpDown13.Size = new Size(79, 20);
      this.domainUpDown13.TabIndex = 52;
      this.domainUpDown14.Items.Add((object) "16.00");
      this.domainUpDown14.Items.Add((object) "16.30");
      this.domainUpDown14.Items.Add((object) "17.00");
      this.domainUpDown14.Items.Add((object) "17.30");
      this.domainUpDown14.Items.Add((object) "18.00");
      this.domainUpDown14.Items.Add((object) "18.30");
      this.domainUpDown14.Items.Add((object) "19.00");
      this.domainUpDown14.Items.Add((object) "19.30");
      this.domainUpDown14.Items.Add((object) "20.00");
      this.domainUpDown14.Location = new Point(309, 243);
      this.domainUpDown14.Name = "domainUpDown14";
      this.domainUpDown14.Size = new Size(79, 20);
      this.domainUpDown14.TabIndex = 51;
      this.numericUpDown20.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown20.Location = new Point(55, 243);
      this.numericUpDown20.Name = "numericUpDown20";
      this.numericUpDown20.Size = new Size(79, 20);
      this.numericUpDown20.TabIndex = 50;
      this.numericUpDown20.TextAlign = HorizontalAlignment.Center;
      this.label15.AutoSize = true;
      this.label15.Location = new Point(19, 245);
      this.label15.Name = "label15";
      this.label15.Size = new Size(27, 13);
      this.label15.TabIndex = 49;
      this.label15.Text = "FEB";
      this.numericUpDown21.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown21.Location = new Point(224, 269);
      this.numericUpDown21.Name = "numericUpDown21";
      this.numericUpDown21.Size = new Size(79, 20);
      this.numericUpDown21.TabIndex = 60;
      this.numericUpDown21.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown22.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown22.Location = new Point(139, 269);
      this.numericUpDown22.Name = "numericUpDown22";
      this.numericUpDown22.Size = new Size(79, 20);
      this.numericUpDown22.TabIndex = 59;
      this.numericUpDown22.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown15.Items.Add((object) "17.00");
      this.domainUpDown15.Items.Add((object) "17.30");
      this.domainUpDown15.Items.Add((object) "18.00");
      this.domainUpDown15.Items.Add((object) "18.30");
      this.domainUpDown15.Items.Add((object) "19.00");
      this.domainUpDown15.Items.Add((object) "19.30");
      this.domainUpDown15.Items.Add((object) "20.00");
      this.domainUpDown15.Items.Add((object) "20.30");
      this.domainUpDown15.Items.Add((object) "21.00");
      this.domainUpDown15.Items.Add((object) "21.30");
      this.domainUpDown15.Items.Add((object) "22.00");
      this.domainUpDown15.Items.Add((object) "22.30");
      this.domainUpDown15.Location = new Point(393, 269);
      this.domainUpDown15.Name = "domainUpDown15";
      this.domainUpDown15.Size = new Size(79, 20);
      this.domainUpDown15.TabIndex = 58;
      this.domainUpDown16.Items.Add((object) "16.00");
      this.domainUpDown16.Items.Add((object) "16.30");
      this.domainUpDown16.Items.Add((object) "17.00");
      this.domainUpDown16.Items.Add((object) "17.30");
      this.domainUpDown16.Items.Add((object) "18.00");
      this.domainUpDown16.Items.Add((object) "18.30");
      this.domainUpDown16.Items.Add((object) "19.00");
      this.domainUpDown16.Items.Add((object) "19.30");
      this.domainUpDown16.Items.Add((object) "20.00");
      this.domainUpDown16.Location = new Point(309, 269);
      this.domainUpDown16.Name = "domainUpDown16";
      this.domainUpDown16.Size = new Size(79, 20);
      this.domainUpDown16.TabIndex = 57;
      this.numericUpDown23.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown23.Location = new Point(55, 269);
      this.numericUpDown23.Name = "numericUpDown23";
      this.numericUpDown23.Size = new Size(79, 20);
      this.numericUpDown23.TabIndex = 56;
      this.numericUpDown23.TextAlign = HorizontalAlignment.Center;
      this.label16.AutoSize = true;
      this.label16.Location = new Point(19, 271);
      this.label16.Name = "label16";
      this.label16.Size = new Size(27, 13);
      this.label16.TabIndex = 55;
      this.label16.Text = "FEB";
      this.numericUpDown24.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown24.Location = new Point(224, 295);
      this.numericUpDown24.Name = "numericUpDown24";
      this.numericUpDown24.Size = new Size(79, 20);
      this.numericUpDown24.TabIndex = 66;
      this.numericUpDown24.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown25.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown25.Location = new Point(139, 295);
      this.numericUpDown25.Name = "numericUpDown25";
      this.numericUpDown25.Size = new Size(79, 20);
      this.numericUpDown25.TabIndex = 65;
      this.numericUpDown25.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown17.Items.Add((object) "17.00");
      this.domainUpDown17.Items.Add((object) "17.30");
      this.domainUpDown17.Items.Add((object) "18.00");
      this.domainUpDown17.Items.Add((object) "18.30");
      this.domainUpDown17.Items.Add((object) "19.00");
      this.domainUpDown17.Items.Add((object) "19.30");
      this.domainUpDown17.Items.Add((object) "20.00");
      this.domainUpDown17.Items.Add((object) "20.30");
      this.domainUpDown17.Items.Add((object) "21.00");
      this.domainUpDown17.Items.Add((object) "21.30");
      this.domainUpDown17.Items.Add((object) "22.00");
      this.domainUpDown17.Items.Add((object) "22.30");
      this.domainUpDown17.Location = new Point(393, 295);
      this.domainUpDown17.Name = "domainUpDown17";
      this.domainUpDown17.Size = new Size(79, 20);
      this.domainUpDown17.TabIndex = 64;
      this.domainUpDown18.Items.Add((object) "16.00");
      this.domainUpDown18.Items.Add((object) "16.30");
      this.domainUpDown18.Items.Add((object) "17.00");
      this.domainUpDown18.Items.Add((object) "17.30");
      this.domainUpDown18.Items.Add((object) "18.00");
      this.domainUpDown18.Items.Add((object) "18.30");
      this.domainUpDown18.Items.Add((object) "19.00");
      this.domainUpDown18.Items.Add((object) "19.30");
      this.domainUpDown18.Items.Add((object) "20.00");
      this.domainUpDown18.Location = new Point(309, 295);
      this.domainUpDown18.Name = "domainUpDown18";
      this.domainUpDown18.Size = new Size(79, 20);
      this.domainUpDown18.TabIndex = 63;
      this.numericUpDown26.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown26.Location = new Point(55, 295);
      this.numericUpDown26.Name = "numericUpDown26";
      this.numericUpDown26.Size = new Size(79, 20);
      this.numericUpDown26.TabIndex = 62;
      this.numericUpDown26.TextAlign = HorizontalAlignment.Center;
      this.label17.AutoSize = true;
      this.label17.Location = new Point(19, 297);
      this.label17.Name = "label17";
      this.label17.Size = new Size(27, 13);
      this.label17.TabIndex = 61;
      this.label17.Text = "FEB";
      this.numericUpDown27.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown27.Location = new Point(224, 321);
      this.numericUpDown27.Name = "numericUpDown27";
      this.numericUpDown27.Size = new Size(79, 20);
      this.numericUpDown27.TabIndex = 72;
      this.numericUpDown27.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown28.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown28.Location = new Point(139, 321);
      this.numericUpDown28.Name = "numericUpDown28";
      this.numericUpDown28.Size = new Size(79, 20);
      this.numericUpDown28.TabIndex = 71;
      this.numericUpDown28.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown19.Items.Add((object) "17.00");
      this.domainUpDown19.Items.Add((object) "17.30");
      this.domainUpDown19.Items.Add((object) "18.00");
      this.domainUpDown19.Items.Add((object) "18.30");
      this.domainUpDown19.Items.Add((object) "19.00");
      this.domainUpDown19.Items.Add((object) "19.30");
      this.domainUpDown19.Items.Add((object) "20.00");
      this.domainUpDown19.Items.Add((object) "20.30");
      this.domainUpDown19.Items.Add((object) "21.00");
      this.domainUpDown19.Items.Add((object) "21.30");
      this.domainUpDown19.Items.Add((object) "22.00");
      this.domainUpDown19.Items.Add((object) "22.30");
      this.domainUpDown19.Location = new Point(393, 321);
      this.domainUpDown19.Name = "domainUpDown19";
      this.domainUpDown19.Size = new Size(79, 20);
      this.domainUpDown19.TabIndex = 70;
      this.domainUpDown20.Items.Add((object) "16.00");
      this.domainUpDown20.Items.Add((object) "16.30");
      this.domainUpDown20.Items.Add((object) "17.00");
      this.domainUpDown20.Items.Add((object) "17.30");
      this.domainUpDown20.Items.Add((object) "18.00");
      this.domainUpDown20.Items.Add((object) "18.30");
      this.domainUpDown20.Items.Add((object) "19.00");
      this.domainUpDown20.Items.Add((object) "19.30");
      this.domainUpDown20.Items.Add((object) "20.00");
      this.domainUpDown20.Location = new Point(309, 321);
      this.domainUpDown20.Name = "domainUpDown20";
      this.domainUpDown20.Size = new Size(79, 20);
      this.domainUpDown20.TabIndex = 69;
      this.numericUpDown29.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown29.Location = new Point(55, 321);
      this.numericUpDown29.Name = "numericUpDown29";
      this.numericUpDown29.Size = new Size(79, 20);
      this.numericUpDown29.TabIndex = 68;
      this.numericUpDown29.TextAlign = HorizontalAlignment.Center;
      this.label18.AutoSize = true;
      this.label18.Location = new Point(19, 323);
      this.label18.Name = "label18";
      this.label18.Size = new Size(27, 13);
      this.label18.TabIndex = 67;
      this.label18.Text = "FEB";
      this.numericUpDown30.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown30.Location = new Point(224, 347);
      this.numericUpDown30.Name = "numericUpDown30";
      this.numericUpDown30.Size = new Size(79, 20);
      this.numericUpDown30.TabIndex = 78;
      this.numericUpDown30.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown31.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown31.Location = new Point(139, 347);
      this.numericUpDown31.Name = "numericUpDown31";
      this.numericUpDown31.Size = new Size(79, 20);
      this.numericUpDown31.TabIndex = 77;
      this.numericUpDown31.TextAlign = HorizontalAlignment.Center;
      this.domainUpDown21.Items.Add((object) "17.00");
      this.domainUpDown21.Items.Add((object) "17.30");
      this.domainUpDown21.Items.Add((object) "18.00");
      this.domainUpDown21.Items.Add((object) "18.30");
      this.domainUpDown21.Items.Add((object) "19.00");
      this.domainUpDown21.Items.Add((object) "19.30");
      this.domainUpDown21.Items.Add((object) "20.00");
      this.domainUpDown21.Items.Add((object) "20.30");
      this.domainUpDown21.Items.Add((object) "21.00");
      this.domainUpDown21.Items.Add((object) "21.30");
      this.domainUpDown21.Items.Add((object) "22.00");
      this.domainUpDown21.Items.Add((object) "22.30");
      this.domainUpDown21.Location = new Point(393, 347);
      this.domainUpDown21.Name = "domainUpDown21";
      this.domainUpDown21.Size = new Size(79, 20);
      this.domainUpDown21.TabIndex = 76;
      this.domainUpDown22.Items.Add((object) "16.00");
      this.domainUpDown22.Items.Add((object) "16.30");
      this.domainUpDown22.Items.Add((object) "17.00");
      this.domainUpDown22.Items.Add((object) "17.30");
      this.domainUpDown22.Items.Add((object) "18.00");
      this.domainUpDown22.Items.Add((object) "18.30");
      this.domainUpDown22.Items.Add((object) "19.00");
      this.domainUpDown22.Items.Add((object) "19.30");
      this.domainUpDown22.Items.Add((object) "20.00");
      this.domainUpDown22.Location = new Point(309, 347);
      this.domainUpDown22.Name = "domainUpDown22";
      this.domainUpDown22.Size = new Size(79, 20);
      this.domainUpDown22.TabIndex = 75;
      this.numericUpDown32.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown32.Location = new Point(55, 347);
      this.numericUpDown32.Name = "numericUpDown32";
      this.numericUpDown32.Size = new Size(79, 20);
      this.numericUpDown32.TabIndex = 74;
      this.numericUpDown32.TextAlign = HorizontalAlignment.Center;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(19, 349);
      this.label19.Name = "label19";
      this.label19.Size = new Size(27, 13);
      this.label19.TabIndex = 73;
      this.label19.Text = "FEB";
      this.buttonOk.DialogResult = DialogResult.OK;
      this.buttonOk.Location = new Point(140, 377);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new Size(75, 23);
      this.buttonOk.TabIndex = 79;
      this.buttonOk.Text = "OK";
      this.buttonOk.UseVisualStyleBackColor = true;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(284, 377);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 80;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(481, 408);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOk);
      this.Controls.Add((Control) this.numericUpDown30);
      this.Controls.Add((Control) this.numericUpDown31);
      this.Controls.Add((Control) this.domainUpDown21);
      this.Controls.Add((Control) this.domainUpDown22);
      this.Controls.Add((Control) this.numericUpDown32);
      this.Controls.Add((Control) this.label19);
      this.Controls.Add((Control) this.numericUpDown27);
      this.Controls.Add((Control) this.numericUpDown28);
      this.Controls.Add((Control) this.domainUpDown19);
      this.Controls.Add((Control) this.domainUpDown20);
      this.Controls.Add((Control) this.numericUpDown29);
      this.Controls.Add((Control) this.label18);
      this.Controls.Add((Control) this.numericUpDown24);
      this.Controls.Add((Control) this.numericUpDown25);
      this.Controls.Add((Control) this.domainUpDown17);
      this.Controls.Add((Control) this.domainUpDown18);
      this.Controls.Add((Control) this.numericUpDown26);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.numericUpDown21);
      this.Controls.Add((Control) this.numericUpDown22);
      this.Controls.Add((Control) this.domainUpDown15);
      this.Controls.Add((Control) this.domainUpDown16);
      this.Controls.Add((Control) this.numericUpDown23);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.numericUpDown18);
      this.Controls.Add((Control) this.numericUpDown19);
      this.Controls.Add((Control) this.domainUpDown13);
      this.Controls.Add((Control) this.domainUpDown14);
      this.Controls.Add((Control) this.numericUpDown20);
      this.Controls.Add((Control) this.label15);
      this.Controls.Add((Control) this.numericUpDown15);
      this.Controls.Add((Control) this.numericUpDown16);
      this.Controls.Add((Control) this.domainUpDown11);
      this.Controls.Add((Control) this.domainUpDown12);
      this.Controls.Add((Control) this.numericUpDown17);
      this.Controls.Add((Control) this.label14);
      this.Controls.Add((Control) this.numericUpDown12);
      this.Controls.Add((Control) this.numericUpDown13);
      this.Controls.Add((Control) this.domainUpDown9);
      this.Controls.Add((Control) this.domainUpDown10);
      this.Controls.Add((Control) this.numericUpDown14);
      this.Controls.Add((Control) this.label13);
      this.Controls.Add((Control) this.numericUpDown9);
      this.Controls.Add((Control) this.numericUpDown10);
      this.Controls.Add((Control) this.domainUpDown7);
      this.Controls.Add((Control) this.domainUpDown8);
      this.Controls.Add((Control) this.numericUpDown11);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.numericUpDown6);
      this.Controls.Add((Control) this.numericUpDown7);
      this.Controls.Add((Control) this.domainUpDown5);
      this.Controls.Add((Control) this.domainUpDown6);
      this.Controls.Add((Control) this.numericUpDown8);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.numericUpDown3);
      this.Controls.Add((Control) this.numericUpDown4);
      this.Controls.Add((Control) this.domainUpDown3);
      this.Controls.Add((Control) this.domainUpDown4);
      this.Controls.Add((Control) this.numericUpDown5);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Controls.Add((Control) this.numericUpDown2);
      this.Controls.Add((Control) this.domainUpDown1);
      this.Controls.Add((Control) this.domainUpDown2);
      this.Controls.Add((Control) this.numericFebOvercast);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.numericJanSnow);
      this.Controls.Add((Control) this.numericJanRain);
      this.Controls.Add((Control) this.domainJanDark);
      this.Controls.Add((Control) this.domainJanSunset);
      this.Controls.Add((Control) this.numericJanOvercast);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.Name = "WeatherForm";
      this.Text = "Weather";
      this.numericJanOvercast.EndInit();
      this.numericJanRain.EndInit();
      this.numericJanSnow.EndInit();
      this.numericUpDown1.EndInit();
      this.numericUpDown2.EndInit();
      this.numericFebOvercast.EndInit();
      this.numericUpDown3.EndInit();
      this.numericUpDown4.EndInit();
      this.numericUpDown5.EndInit();
      this.numericUpDown6.EndInit();
      this.numericUpDown7.EndInit();
      this.numericUpDown8.EndInit();
      this.numericUpDown9.EndInit();
      this.numericUpDown10.EndInit();
      this.numericUpDown11.EndInit();
      this.numericUpDown12.EndInit();
      this.numericUpDown13.EndInit();
      this.numericUpDown14.EndInit();
      this.numericUpDown15.EndInit();
      this.numericUpDown16.EndInit();
      this.numericUpDown17.EndInit();
      this.numericUpDown18.EndInit();
      this.numericUpDown19.EndInit();
      this.numericUpDown20.EndInit();
      this.numericUpDown21.EndInit();
      this.numericUpDown22.EndInit();
      this.numericUpDown23.EndInit();
      this.numericUpDown24.EndInit();
      this.numericUpDown25.EndInit();
      this.numericUpDown26.EndInit();
      this.numericUpDown27.EndInit();
      this.numericUpDown28.EndInit();
      this.numericUpDown29.EndInit();
      this.numericUpDown30.EndInit();
      this.numericUpDown31.EndInit();
      this.numericUpDown32.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public WeatherForm()
    {
      this.InitializeComponent();
    }
  }
}
