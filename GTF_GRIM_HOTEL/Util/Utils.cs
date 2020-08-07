using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace GTF_STFM.Util
{
    public class Utils
    {
        [DllImport("SvkSignPad.dll", CharSet = CharSet.Ansi)]
        public static extern int svkGetSign(int log_falg, int com_port, int input_amt, int auto_flag, int input_sign_size,
                string input_sign_path, string input_sign_name, StringBuilder output_msg);

        public class ComboItem
        {
            //public ComboItem(string value, string text, string parent = "") { Value = value; Text = text; Parent = parent; }
            public ComboItem(string value, string text) { Value = value; Text = text;  }
            public string Value { get; set; }
            public string Text { get; set; }
            //public string Parent { get; set; }
            public override string ToString() { return Text; }
        }


        public void createSlipNo(long nSeq, string strTermNo, out string strSlipNo)
        {
            strSlipNo = "2" + strTermNo.PadLeft(5, '0') + DateTime.Now.ToString("yyMMddHHmmss") + (nSeq % 100).ToString("D2");        
        }

        public string getFullDate(string strBirth)
        {
            string strRet = "20000101";
            int nBirth = Int32.Parse(strBirth.Substring(0,2));
            if((nBirth+2000) >(Int32.Parse(DateTime.Now.ToString("yyyy"))-10))
            {
                strRet = "19" + strBirth;
            }
            else
            {
                strRet = "20" + strBirth;
            }
            return strRet;
        }

        public Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        public ArrayList GetFixOrderCountryList()
        {
            ArrayList temp = new ArrayList();
            temp.Add("CHN");
            temp.Add("KOR");
            temp.Add("TWN");
            temp.Add("THA");
            temp.Add("SGP");
            temp.Add("USA");
            temp.Add("JPN");
            temp.Add("PHL");
            temp.Add("MYS");
            temp.Add("NPL");
            temp.Add("DEU");
            temp.Add("ISL");
            temp.Add("VNM");
            temp.Add("MNG");
            return temp;
        }
        public int gtf_svkGetSign(int log_falg, int com_port, int input_amt, int auto_flag, int input_sign_size,
                string input_sign_path, string input_sign_name, StringBuilder output_msg)
        {
            return svkGetSign( log_falg,  com_port,  input_amt,  auto_flag,  input_sign_size,
                 input_sign_path,  input_sign_name,  output_msg);
        }

        public int getPaddingLen(int nLen)
        {
            int nPad = 0;
            if (nLen < 0)
                nLen = 0;
            else
                nPad = nLen;
            return nPad;
        }

        public Int64 getRefundAmount(long nSalesAmount)
        {
            Int64 nRet = 0;
            JObject tmpObj = new JObject();
            Boolean bFind = false;
            long nMin = 0;
            long nMax = 0;
            decimal dc = 0;
            if ( Constants.ARR_RATE_INFO != null)
            {
                for (int i = 0; i < Constants.ARR_RATE_INFO.Count; i ++)
                {
                    tmpObj = (JObject)Constants.ARR_RATE_INFO[i];
                    nMin = Int64.Parse(tmpObj["appl_amt_min"].ToString());
                    nMax = Int64.Parse(tmpObj["appl_amt_max"].ToString());

                    if (nSalesAmount >= nMin && nSalesAmount <= nMax)
                    {
                        nRet = Int64.Parse(tmpObj["refund_amt"].ToString());
                        bFind = true;
                        break;
                    }

                    if (nSalesAmount >= nMin && nMax == 0)
                    {
                        dc = decimal.Parse(tmpObj["refund_rate"].ToString());
                        nRet = (long)((decimal)nSalesAmount / 11 * dc);
                        nRet = nRet - (nRet % 1000);

                        bFind = true;
                        break;
                    }

                }
            }
            //못찾았으면 세금의 90% 로 계산
            //if(!bFind)
            //{
            //    nRet = nSalesAmount * 9 / 10 / 11;
            //}
            return nRet;
        }

    }
}
