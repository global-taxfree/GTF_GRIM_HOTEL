using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTF_STFM.Util;
using GTF_STFM.Tran;
using log4net;
using Newtonsoft.Json.Linq;
using MetroFramework;

namespace GTF_STFM.Screen
{
    public partial class PassportInfoForm : MetroFramework.Forms.MetroForm
    {
        private ILog m_logger=null;
        //public string m_strRetVal = string.Empty;
        public PassportInfoForm(ILog Logger = null, JArray ArrNationalList =null)
        {
            InitializeComponent();
            m_logger = Logger;
            if (ArrNationalList != null)
                init(ArrNationalList);
        }
        public void init(JArray ArrNationalList)
        {
            COM_PASSPORT_NAT.Items.Clear();

            if (ArrNationalList != null && ArrNationalList.Count > 0)
            {
                Dictionary<string, string> item_list = new Dictionary<string, string>();
                for (int i = 0; i < ArrNationalList.Count; i++)
                {
                    JObject tempObj = (JObject)ArrNationalList[i];
                    IList<string> keys = tempObj.Properties().Select(p => p.Name).ToList();
                    for (int j = 0; j < keys.Count; j++)
                    {
                        item_list.Add(keys[j].ToString(), tempObj[keys[j].ToString()].ToString() + "(" + keys[j].ToString() + ")");
                    }
                }
                COM_PASSPORT_NAT.DataSource = new BindingSource(item_list, null);
                COM_PASSPORT_NAT.DisplayMember = "Value";
                COM_PASSPORT_NAT.ValueMember = "Key";
                COM_PASSPORT_NAT.SelectedIndex = 0;
            }

            Dictionary<string, string> gender_list = new Dictionary<string, string>();
            gender_list.Add("M", "M");
            gender_list.Add("F", "F");
            COM_PASSPORT_SEX.Items.Clear();
            COM_PASSPORT_SEX.DataSource = new BindingSource(gender_list, null);
            COM_PASSPORT_SEX.DisplayMember = "Value";
            COM_PASSPORT_SEX.ValueMember = "Key";
            COM_PASSPORT_SEX.SelectedIndex = 0;

            //화면 디스크립트 변경
            //ControlManager CtlSizeManager = new ControlManager(this);
            //CtlSizeManager.ChageLabel(this);
            //CtlSizeManager = null;
            //Clear();
        }

        private void PassportInfoForm_Load(object sender, EventArgs e)
        {
            //this.Text = Constants.getScreenText("PASSPORTINFO_FORM");
        }
   
        private void metroLabel7_Click(object sender, EventArgs e)
        {
            
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            if (string.Empty.Equals(TXT_PASSPORT_NAME.Text))
            {
                //MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("TXT_PASSPORT_NAME"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXT_PASSPORT_NAME.Focus();
                return;
            }
            if (string.Empty.Equals(TXT_PASSPORT_NO.Text))
            {
                //MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("TXT_PASSPORT_NO"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXT_PASSPORT_NO.Focus();
                return;
            }
            if (string.Empty.Equals(COM_PASSPORT_NAT.Text))
            {
                //MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("COM_PASSPORT_NAT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                COM_PASSPORT_NAT.Focus();
                return;
            }
            if (string.Empty.Equals(COM_PASSPORT_SEX.Text))
            {
                //MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("COM_PASSPORT_SEX"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                COM_PASSPORT_SEX.Focus();
                return;
            }
            if (string.Empty.Equals(TXT_PASSPORT_BIRTH.Text))
            {
                //MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("TXT_PASSPORT_BIRTH"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXT_PASSPORT_BIRTH.Focus();
                return;
            }
            if (string.Empty.Equals(TXT_PASSPORT_EXP.Text))
            {
                //MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("TXT_PASSPORT_EXP"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MetroFramework.MetroMessageBox.Show(this, Constants.getMessage("ERROR_PASSPORT"), "Passport", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXT_PASSPORT_EXP.Focus();
                return;
            }

            TXT_PASSPORT_NAME.Text = TXT_PASSPORT_NAME.Text.Replace("<", "").Replace(" ", "");

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void BTN_CLOSE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Clear();
            this.Close(); 
        }

        public void Clear()
        {
            TXT_PASSPORT_NAME.Text = "";
            TXT_PASSPORT_NO.Text = "";
            COM_PASSPORT_NAT.Text = "";
            COM_PASSPORT_SEX.Text = "";
            //TXT_PASSPORT_BIRTH.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            //TXT_PASSPORT_EXP.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            TXT_PASSPORT_BIRTH.Value = System.DateTime.Now;
            TXT_PASSPORT_EXP.Value = System.DateTime.Now;

            //TXT_DATE_LAND.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void PassportInfoForm_Activated(object sender, EventArgs e)
        {
            if( this.Parent != null)

            {
                this.Parent.Focus();
                this.Focus();
            }
            Console.Write("PassportInfoForm_Activated");
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            //Keys key = keyData & ~(Keys.Shift | Keys.Control);
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        BTN_OK.Focus();
                        BTN_OK_Click(null, null);
                        return true;
                    case Keys.Escape:
                        BTN_CLOSE.Focus();
                        BTN_CLOSE_Click(null, null);
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
