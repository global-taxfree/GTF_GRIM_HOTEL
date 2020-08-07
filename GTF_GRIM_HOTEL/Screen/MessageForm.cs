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
namespace GTF_STFM.Screen
{
    public partial class MessageForm : MetroFramework.Forms.MetroForm
    {
        ILog m_Logger = null;

        public MessageBoxButtons m_MessageType { get; set;}

        public MessageForm(String strMessage , ILog Logger = null , MessageBoxButtons nMsgType = MessageBoxButtons.OK)
        {
            InitializeComponent();
            m_Logger = Logger;
            m_MessageType = nMsgType;
            LBL_MSG.Text = strMessage;
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            if (m_MessageType == MessageBoxButtons.OK)
            {
                BTN_YES.Visible = true;
                BTN_NO.Visible = false;
                BTN_OK.Visible = false;
                BTN_CANCEL.Visible = false;
            }
                
            if (m_MessageType == MessageBoxButtons.YesNo)
            {
                BTN_YES.Visible = true;
                BTN_NO.Visible = true;
                BTN_OK.Visible = false;
                BTN_CANCEL.Visible = false;
            }

            if (m_MessageType == MessageBoxButtons.YesNoCancel)
            {
                BTN_YES.Visible = true;
                BTN_NO.Visible = true;
                BTN_OK.Visible = false;
                BTN_CANCEL.Visible = true;
            }

            if (m_MessageType == MessageBoxButtons.OK)
            {
                BTN_YES.Visible = false;
                BTN_NO.Visible = false;
                BTN_OK.Visible = true;
                BTN_CANCEL.Visible = false;
            }
            
        }

        private void BTN_YES_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void BTN_NO_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void BTN_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
