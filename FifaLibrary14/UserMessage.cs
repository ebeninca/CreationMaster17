// Original code created by Rinaldo

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace FifaLibrary
{
    public class UserMessage : Form
    {
        private IContainer components;
        private Button buttonOK;
        private TextBox textMessage;
        private CheckBox checkSuppressMessage;
        private TextBox textErrorNumber;
        private Messages setMessages;
        private Button buttonCancel;
        private Button buttonNo;
        private Button buttonYes;
        private PictureBox pictureBox;
        private ImageList imageList;
        private int m_CurrentIndex;
        private string m_XmlFileName;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserMessage));
            this.buttonOK = new Button();
            this.textMessage = new TextBox();
            this.checkSuppressMessage = new CheckBox();
            this.textErrorNumber = new TextBox();
            this.buttonCancel = new Button();
            this.buttonNo = new Button();
            this.buttonYes = new Button();
            this.pictureBox = new PictureBox();
            this.imageList = new ImageList(this.components);
            this.setMessages = new Messages();
            ((ISupportInitialize)this.pictureBox).BeginInit();
            this.setMessages.BeginInit();
            this.SuspendLayout();
            this.buttonOK.DialogResult = DialogResult.OK;
            resources.ApplyResources((object)this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.textMessage.BorderStyle = BorderStyle.None;
            resources.ApplyResources((object)this.textMessage, "textMessage");
            this.textMessage.Name = "textMessage";
            this.textMessage.ReadOnly = true;
            resources.ApplyResources((object)this.checkSuppressMessage, "checkSuppressMessage");
            this.checkSuppressMessage.Name = "checkSuppressMessage";
            this.checkSuppressMessage.UseVisualStyleBackColor = true;
            this.checkSuppressMessage.CheckedChanged += new EventHandler(this.checkSuppressMessage_CheckedChanged);
            resources.ApplyResources((object)this.textErrorNumber, "textErrorNumber");
            this.textErrorNumber.Name = "textErrorNumber";
            this.textErrorNumber.ReadOnly = true;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            resources.ApplyResources((object)this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonNo.DialogResult = DialogResult.No;
            resources.ApplyResources((object)this.buttonNo, "buttonNo");
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Click += new EventHandler(this.buttonNo_Click);
            this.buttonYes.DialogResult = DialogResult.Yes;
            resources.ApplyResources((object)this.buttonYes, "buttonYes");
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Click += new EventHandler(this.buttonYes_Click);
            resources.ApplyResources((object)this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            this.imageList.TransparentColor = Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "Error_16.PNG");
            this.imageList.Images.SetKeyName(1, "Warning_16.PNG");
            this.imageList.Images.SetKeyName(2, "Info_16.PNG");
            this.imageList.Images.SetKeyName(3, "Help.PNG");
            this.setMessages.DataSetName = "Messages";
            this.setMessages.Locale = new CultureInfo("");
            this.setMessages.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            resources.ApplyResources((object)this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add((Control)this.pictureBox);
            this.Controls.Add((Control)this.buttonCancel);
            this.Controls.Add((Control)this.buttonNo);
            this.Controls.Add((Control)this.buttonYes);
            this.Controls.Add((Control)this.textErrorNumber);
            this.Controls.Add((Control)this.checkSuppressMessage);
            this.Controls.Add((Control)this.textMessage);
            this.Controls.Add((Control)this.buttonOK);
            this.Name = "UserMessage";
            ((ISupportInitialize)this.pictureBox).EndInit();
            this.setMessages.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public UserMessage()
        {
            this.InitializeComponent();
            string currentDirectory = Environment.CurrentDirectory;
            string str = CultureInfo.CurrentUICulture.Name.Substring(0, 2);
            string path1 = currentDirectory + "\\" + str;
            this.m_XmlFileName = (string)null;
            if (Directory.Exists(path1))
            {
                string path2 = path1 + "\\Messages.xml";
                if (File.Exists(path2))
                    this.m_XmlFileName = path2;
            }
            if (this.m_XmlFileName == null)
                this.m_XmlFileName = currentDirectory + "\\Messages.xml";
            if (!File.Exists(this.m_XmlFileName))
                return;
            int num = (int)this.setMessages.ReadXml(this.m_XmlFileName);
        }

        public DialogResult ShowMessage(int id)
        {
            string str = (string)null;
            bool flag = true;
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (id == this.setMessages.DataTableMex[index].MexId)
                {
                    str = this.setMessages.DataTableMex[index].MexText;
                    flag = !this.setMessages.DataTableMex[index].MexSuppressed;
                    this.m_CurrentIndex = index;
                    break;
                }
            }
            this.textMessage.Text = str;
            if (!flag)
                return DialogResult.OK;
            this.SetUpLook(id);
            return this.ShowDialog();
        }

        public DialogResult ShowMessage(int id, int reference)
        {
            string str = (string)null;
            bool flag = true;
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (id == this.setMessages.DataTableMex[index].MexId)
                {
                    str = this.setMessages.DataTableMex[index].MexText;
                    flag = !this.setMessages.DataTableMex[index].MexSuppressed;
                    this.m_CurrentIndex = index;
                    break;
                }
            }
            this.textMessage.Text = str + " Reference: " + reference.ToString();
            if (!flag)
                return DialogResult.OK;
            this.SetUpLook(id);
            return this.ShowDialog();
        }

        private void SetUpLook(int id)
        {
            if (id < 1000)
            {
                this.textErrorNumber.Text = "Please select your choice";
                this.pictureBox.Image = this.imageList.Images[3];
            }
            else if (id < 3000)
            {
                this.textErrorNumber.Text = "Warning: " + id.ToString();
                this.pictureBox.Image = this.imageList.Images[1];
            }
            else if (id < 5000)
            {
                this.textErrorNumber.Text = "Info: " + id.ToString();
                this.pictureBox.Image = this.imageList.Images[2];
            }
            else if (id < 15000)
            {
                this.textErrorNumber.Text = "Error: " + id.ToString();
                this.pictureBox.Image = this.imageList.Images[0];
            }
            else
            {
                this.textErrorNumber.Text = "Info";
                this.pictureBox.Image = this.imageList.Images[2];
            }
            this.checkSuppressMessage.Visible = id < 10000;
            this.checkSuppressMessage.Checked = false;
            this.buttonOK.Visible = id >= 1000;
            this.buttonNo.Visible = id < 1000;
            this.buttonYes.Visible = id < 1000;
            this.buttonCancel.Visible = id < 1000;
        }

        public DialogResult ShowMessage(int id, string messageText)
        {
            bool flag = true;
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (id == this.setMessages.DataTableMex[index].MexId)
                {
                    string mexText = this.setMessages.DataTableMex[index].MexText;
                    flag = !this.setMessages.DataTableMex[index].MexSuppressed;
                    this.m_CurrentIndex = index;
                    break;
                }
            }
            this.textMessage.Text = messageText;
            if (!flag)
                return DialogResult.OK;
            this.SetUpLook(id);
            return this.ShowDialog();
        }

        public DialogResult ShowMessage(int id, string messageText, bool merge)
        {
            if (!merge)
                return this.ShowMessage(id, messageText);
            string str = (string)null;
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (id == this.setMessages.DataTableMex[index].MexId)
                {
                    str = this.setMessages.DataTableMex[index].MexText;
                    this.m_CurrentIndex = index;
                    break;
                }
            }
            return this.ShowMessage(id, str + "\r\n" + messageText);
        }

        public DialogResult ShowMessage(int id, string messageText, bool merge, Form mainForm)
        {
            int dialogX = mainForm.AccessibilityObject.Bounds.X + (mainForm.Width - this.Width) / 2;
            int dialogY = mainForm.AccessibilityObject.Bounds.Y + (mainForm.Height - this.Height) / 2;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(dialogX, dialogY);

            if (!merge)
                return this.ShowMessage(id, messageText);
            string str = (string)null;
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (id == this.setMessages.DataTableMex[index].MexId)
                {
                    str = this.setMessages.DataTableMex[index].MexText;
                    this.m_CurrentIndex = index;
                    break;
                }
            }
            return this.ShowMessage(id, str + "\r\n" + messageText);
        }

        public void EnableMessages(bool enable)
        {
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (this.setMessages.DataTableMex[index].MexId < 10000)
                    this.setMessages.DataTableMex[index].MexSuppressed = !enable;
            }
            this.setMessages.WriteXml(this.m_XmlFileName);
        }


        public void EnableWarnings(bool enable)
        {
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (this.setMessages.DataTableMex[index].MexId < 5000)
                    this.setMessages.DataTableMex[index].MexSuppressed = !enable;
            }
            this.setMessages.WriteXml(this.m_XmlFileName);
        }

        public void EnableErrors(bool enable)
        {
            for (int index = 0; index < this.setMessages.DataTableMex.Count; ++index)
            {
                if (this.setMessages.DataTableMex[index].MexId >= 5000 && this.setMessages.DataTableMex[index].MexId < 10000)
                    this.setMessages.DataTableMex[index].MexSuppressed = !enable;
            }
            this.setMessages.WriteXml(this.m_XmlFileName);
        }

        private void checkSuppressMessage_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.checkSuppressMessage.Checked)
                this.setMessages.DataTableMex[this.m_CurrentIndex].MexSuppressed = true;
            this.setMessages.WriteXml(this.m_XmlFileName);
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (this.checkSuppressMessage.Checked)
                this.setMessages.DataTableMex[this.m_CurrentIndex].MexSuppressed = true;
            this.setMessages.WriteXml(this.m_XmlFileName);
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            if (this.checkSuppressMessage.Checked)
                this.setMessages.DataTableMex[this.m_CurrentIndex].MexSuppressed = true;
            this.setMessages.WriteXml(this.m_XmlFileName);
        }
    }
}
