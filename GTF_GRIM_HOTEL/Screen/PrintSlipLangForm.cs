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

using log4net;
namespace GTF_STFM.Screen
{
    public partial class PrintSlipLangForm : MetroFramework.Forms.MetroForm
    {
        ILog m_Logger = null;

        public MessageBoxButtons m_MessageType { get; set;}
        public string m_SelectLang = string.Empty;

        public PrintSlipLangForm(  ILog Logger = null )
        {
            InitializeComponent();
            m_Logger = Logger;
            RadioSelect();
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            RDO_LANG_CN.Text = Constants.getScreenText("COMBO_ITEM_CN");
            RDO_LANG_EN.Text = Constants.getScreenText("COMBO_ITEM_EN");
            RDO_LANG_KO.Text = Constants.getScreenText("COMBO_ITEM_KO");
            LBL_MSG.Text = Constants.getScreenText("PRINTSLIPLANG_FORM");
            RadioSelect();
        }
        private void BTN_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

       
        private void RDO_LANG_KO_CheckedChanged(object sender, EventArgs e)
        {
            RadioSelect();
        }

        private void RDO_LANG_CN_CheckedChanged(object sender, EventArgs e)
        {
            RadioSelect();
        }

        private void RDO_LANG_EN_CheckedChanged(object sender, EventArgs e)
        {
            RadioSelect();
        }

        private void RadioSelect()
        {
            if(RDO_LANG_CN.Checked)
            {
                m_SelectLang= "CN";
            }
            else if (RDO_LANG_EN.Checked)
            {
                m_SelectLang = "EN";
            }
            else if (RDO_LANG_KO.Checked)
            {
                m_SelectLang = "KR";
            }
            else
            {
                m_SelectLang = "EN";
            }
        }
    }
}
