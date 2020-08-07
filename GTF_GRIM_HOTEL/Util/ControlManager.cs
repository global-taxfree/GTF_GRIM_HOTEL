using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace GTF_STFM.Util
{
    class ControlManager
    {
        [Flags]
        public enum enumSizeChange //사이즈 변경 bit 체크
        {
            None = 0,
            b_X_Move = 1 << 0,//횡이동
            b_Y_Move = 1 << 1,//종이동
            b_X_Expend = 1 << 2,//횡늘림
            b_Y_Expend = 1 << 3,//종늘림
            All = int.MaxValue
        };
        ILog m_Logger = null;

        private Control m_parent ;
        private Size m_parentOriSize;

        Dictionary<Control, enumSizeChange> ctls = new Dictionary<Control, enumSizeChange>();
        Dictionary<Control, Point> ctlsPoint = new Dictionary<Control, Point>();
        Dictionary<Control, Size> ctlsSize = new Dictionary<Control, Size>();

        public ControlManager(Control parentControl, ILog logger = null)
        {
            m_Logger = logger;
            if (m_Logger == null)
                m_Logger = LogManager.GetLogger("");
            if (parentControl is Control)
            {
                m_parent = parentControl;
                m_parentOriSize = new Size(parentControl.Size.Width, parentControl.Size.Height);
                m_Logger.Info("ControlManager >> parentControl.Size.Width:"+ parentControl.Size.Width + ", parentControl.Size.Height:"+ parentControl.Size.Height);
            }
        }

        public void ChageLabel(Control curCtl)
        {
            //하위컨트롤 있는 경우는  재귀호출
            if (!(curCtl is MetroFramework.Controls.MetroGrid) && curCtl.Controls.Count > 1)
            {
                foreach (Control ctl in curCtl.Controls)
                {
                    ChageLabel(ctl);//재귀호출
                }
            }
            else
            {
                //LABEL 만 TEXT 변경. 필요시엔 타 컨트롤도 추가.
                //is(curCtl is Label) 로 비교하는 방법도 있으나 불필요한 컴포넌트는 검색하지 않기 위해 name.index 로 찾는다.
                if (curCtl.Name.IndexOf("LBL_") >=0 || curCtl.Name.IndexOf("BTN_") >= 0 
                    || curCtl.Name.IndexOf("CHK_") >= 0 || curCtl.Name.IndexOf("GRD_") >= 0)
                {
                    string strTempVal = Constants.CONF_MANAGER.getCustomValue("ScreenText"
                        , Constants.SYSTEM_LANGUAGE+"/"+m_parent.Name+"/"+curCtl.Name);
                    if (strTempVal != null && !string.Empty.Equals(strTempVal))
                    {
                        if (curCtl.Name.IndexOf("GRD_") >= 0 && curCtl is MetroFramework.Controls.MetroGrid)
                        {
                            string[] arrData = strTempVal.Split(';');
                            for (int i = 0; i < arrData.Length; i++)
                            {
                                ((MetroFramework.Controls.MetroGrid)curCtl).Columns[i].HeaderText = arrData[i];
                            }
                        }
                        else
                        {
                            curCtl.Text = strTempVal;
                        }
                    }
                }
            }
        }

        public void addControlMove(Control cur_Con, Boolean b_X_Move, Boolean b_Y_Move, Boolean b_X_Expend, Boolean b_Y_Expend)
        {
            enumSizeChange enumSize = enumSizeChange.None;
            if (b_X_Move)
                enumSize |= enumSizeChange.b_X_Move;
            if (b_Y_Move)
                enumSize |= enumSizeChange.b_Y_Move;
            if (b_X_Expend)
                enumSize |= enumSizeChange.b_X_Expend;
            if (b_Y_Expend)
                enumSize |= enumSizeChange.b_Y_Expend;
            if (!ctls.ContainsKey(cur_Con))
            {
                ctls.Add(cur_Con, enumSize);//컨트롤별 변경속성 저장
                ctlsPoint.Add(cur_Con, ((Control)cur_Con).Location);//초기 위치 저장
                ctlsSize.Add(cur_Con, ((Control)cur_Con).Size);     //초기 크기 저장
            }
            else
            {
                ctls[cur_Con] = enumSize;
                ctlsPoint[cur_Con] = ((Control)cur_Con).Location;//초기 위치 저장
                ctlsSize[cur_Con] =((Control)cur_Con).Size;     //초기 크기 저장
            }
        }

        public void MoveControls()
        {
            foreach (Control de in ctls.Keys)
            {
                //Constants.LOGGER_MAIN.Info("Key = {0}, Value = {1}", de, ctls[de]);
                enumSizeChange tmpEnum = ctls[de];
                Point tempPoint = ctlsPoint[de];
                Size tempSize = ctlsSize[de];

                Size temp_Panel_Size = m_parent.Size;

                //m_Logger.Info("ControlManager >> MoveControls >> temp_Panel_Size :("+ temp_Panel_Size.Width +" , "+ temp_Panel_Size.Height +")");

                //횡이동
                if ((ctls[de] & enumSizeChange.b_X_Move) == enumSizeChange.b_X_Move)
                {
                    tempPoint.X += (temp_Panel_Size.Width - m_parentOriSize.Width);
                }
                //종이동
                if ((ctls[de] & enumSizeChange.b_Y_Move) == enumSizeChange.b_Y_Move)
                {
                    tempPoint.Y += (temp_Panel_Size.Height - m_parentOriSize.Height);
                }
                //횡늘림
                if ((ctls[de] & enumSizeChange.b_X_Expend) == enumSizeChange.b_X_Expend)
                {
                    tempSize.Width += (temp_Panel_Size.Width - m_parentOriSize.Width);
                }
                //종늘림
                if ((ctls[de] & enumSizeChange.b_Y_Expend) == enumSizeChange.b_Y_Expend)
                {
                    tempSize.Height += (temp_Panel_Size.Height - m_parentOriSize.Height);
                }
                ((Control)de).Location = tempPoint;
                ((Control)de).Size = tempSize;
            }

        }
    }
}
