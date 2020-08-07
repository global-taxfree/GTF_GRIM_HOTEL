using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using MetroFramework;
using GTF_STFM.Util;

namespace GTF_STFM.Screen
{
    public partial class MessageSmallForm : MetroFramework.Forms.MetroForm
    {
        ILog m_Logger = null;

        public MessageBoxButtons m_MessageType { get; set;}

        public MessageSmallForm(String strMessage , ILog Logger = null)
        {
            InitializeComponent();
            m_Logger = Logger;
            LBL_MSG.Text = strMessage;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            TXT_PASSORD.Focus();
        }

        private void BTN_NO_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            if("admin".Equals(TXT_PASSORD.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MetroMessageBox.Show(this, Constants.getMessage("PASSWORD_ERROR"), "Issue", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXT_PASSORD.Focus();
                TXT_PASSORD.SelectAll();
            }
            
        }

        private void MessageForm_Load_1(object sender, EventArgs e)
        {

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
                        BTN_OK_Click(null, null);
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
    }
}
