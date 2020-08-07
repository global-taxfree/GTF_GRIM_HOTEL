using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace GTF_STFM.Util
{
    class WindowPrinterUtil
    {
        StringFormat strFormat = new StringFormat();
        Font strFont = new Font("Century Gothic", 9);
        //private const int nPageWidth = 700;
        //private int nStartPoint = 20;
        private int nStartPoint = 120;
        private const int nPageWidthHalf = 290;
        private const int nPageWidthQuater = 175;

        private EncodingOptions EncodingOptions { get; set; }
        private Type Renderer { get; set; }
        
        private string slip_status = "";

        private JObject slipData = null;
        private Rectangle rect;

        int nNomalSize = 8;
        int nSmallSize = 7;
        string m_Font = "맑은 고딕";
        string lineText = "-----------------------------------------------------------------------------------------------------------------------";
        int nPaddingLen_big = 80;

        ILog m_Logger = null;

        public WindowPrinterUtil(ILog Logger = null)
        {
            m_Logger = Logger;
            if(m_Logger == null)
            {
                m_Logger = Constants.LOGGER_MAIN;
            }
        }
        public int PrintRefundSlip(JObject obj)
        {
            int nRet = 0;

            Renderer = typeof(BitmapRenderer);
            try
            {
                slipData = obj;
                PrintDocument printDoc = new PrintDocument();
                //printDoc.UserPrintPageEvent += new UserPrintDocument.UserPrintPageEventHandler(PrintSlip);
                printDoc.PrintPage += new PrintPageEventHandler(PrintSlip);
                printDoc.PrinterSettings.PrinterName = Constants.PRINTER_TYPE;
                printDoc.Print();

            }
            catch (Exception ex)
            {
                m_Logger.Error(ex.Message, ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nRet = -1;
            }
            return nRet;
        }
        

        public void PrintSlip(object sender, PrintPageEventArgs e)
        {
            float yPos = 40;//2018.04.05 출력 위치 조정 20->40
            try
            {
                //2018.04.03 원본데이터 출력
                Encoding enc = Encoding.Default;
                //출력데이터 이용 m_slipData 
                //Image head_logo = Bitmap.FromFile(Constants.filePath_LOGO);

                //Image head_logo_Resize = new Bitmap(head_logo, new Size(head_logo.Width * 50 / 100, head_logo.Height * 50 / 100));

                //e.Graphics.DrawImage((Image)head_logo_Resize, new Rectangle(nStartPoint, (int)yPos, head_logo_Resize.Width, head_logo_Resize.Height));
                //yPos += head_logo_Resize.Height;
                //yPos = PrintImg(e, head_logo_Resize, yPos, StringAlignment.Center);

                //StringAlignment.Near   - 왼쪽
                //StringAlignment.Center - 가운데
                //StringAlignment.Far    - 오른쪽

                yPos = PrintText(e, "        GLOBAL         ", yPos, StringAlignment.Near , false , false , 15);
                yPos = PrintText(e, "                   TAX FREE", yPos, StringAlignment.Near, true, true, 15);

                yPos = PrintText(e, lineText, yPos , StringAlignment.Center, false,true,5);
                yPos = PrintText(e, "숙 박 용 역", yPos, StringAlignment.Center, true, true, 15);
                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);


                //strFormat.Alignment = StringAlignment.Center;//왼쪽
                //strFont = new Font(m_Font, nNomalSize, FontStyle.Bold);
                //rect = new Rectangle(nStartPoint, (int)yPos, nPageWidthHalf, strFont.Height);
                //e.Graphics.DrawString("----------------------------------------------------", strFont, Brushes.Black, rect, strFormat);
                //e.Graphics.DrawRectangle(Pens.White, rect);
                //yPos += strFont.Height;


                yPos = PrintText(e, "Hotel Tax Refund", yPos, StringAlignment.Center);
                yPos = PrintText(e, "This Document is authorized by Korea NTS", yPos, StringAlignment.Center);
                yPos = PrintText(e, "국세청장이 인정한 서식임", yPos, StringAlignment.Center);

                Image qrImg = Bitmap.FromFile(Constants.filePath_Combine);
                //Image qrImg_Resize = new Bitmap(qrImg, new Size(qrImg.Width * 60 / 100, qrImg.Height * 60 / 100));
                yPos = PrintImg(e, qrImg, yPos, StringAlignment.Center);

                qrImg.Dispose();

                yPos = PrintText(e, "gtf@global-taxfree.com            www.global-taxfree.com", yPos, StringAlignment.Center, true, true , nSmallSize);
                yPos = PrintText(e, "Contact Us : +82 2 518 0837" , yPos, StringAlignment.Near, false);
                yPos = PrintText(e, "단말기 ID " + slipData["tml_id"].ToString(), yPos, StringAlignment.Near, false);

                string strBuySerialNo = slipData["buy_serial_no"].ToString();
                yPos = PrintText(e, "구매일련번호" , yPos, StringAlignment.Near, false, false);

                yPos = PrintText(e, strBuySerialNo.Substring(0, 2)
                        + "-" + strBuySerialNo.Substring(2, 5)
                        + "-" + strBuySerialNo.Substring(7, 5)
                        + "-" + strBuySerialNo.Substring(12, 2)
                        + "-" + strBuySerialNo.Substring(14), yPos, StringAlignment.Far, false);

                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);
                yPos = PrintText(e, "호텔/Hotel" , yPos, StringAlignment.Near, true);

                yPos = PrintText(e, "사업자번호 " , yPos, StringAlignment.Near, false , false);
                //yPos = PrintText(e, slipData["biz_permit_no"].ToString().PadLeft(nPaddingLen_big - 11, ' '), yPos, StringAlignment.Far);
                String strBizPermitNo = slipData["biz_permit_no"].ToString();
                strBizPermitNo = strBizPermitNo.Substring(0, 3) +"-"+ strBizPermitNo.Substring(3, 2) + "-" + strBizPermitNo.Substring(5);
                yPos = PrintText(e, strBizPermitNo, yPos, StringAlignment.Far);

                yPos = PrintText(e, "관광사업등록번호" , yPos, StringAlignment.Near, false,false);
                yPos = PrintText(e,  slipData["company_reg_no"].ToString(), yPos, StringAlignment.Far);

                yPos = PrintText(e, "상호 " , yPos, StringAlignment.Near, false,false);
                yPos = PrintText(e, slipData["shop_name"] != null ? slipData["shop_name"].ToString() : " ", yPos, StringAlignment.Far);

                yPos = PrintText(e, "대표자 ", yPos, StringAlignment.Near, false, false);
                yPos = PrintText(e, slipData["ceo_name"] != null ? slipData["ceo_name"].ToString()  : " ", yPos, StringAlignment.Far);

                yPos = PrintText(e, "주소 " , yPos, StringAlignment.Near, false, false);
                yPos = PrintText(e, slipData["shop_addr"] != null ? slipData["shop_addr"].ToString() : " "  , yPos, StringAlignment.Far);

                yPos = PrintText(e, "연락처", yPos, StringAlignment.Near, false, false);
                yPos = PrintText(e, slipData["shop_phone"] != null ? slipData["shop_phone"].ToString() : " " , yPos, StringAlignment.Far);

                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);
                string strDate = slipData["sale_date"].ToString();
                strDate = strDate.Substring(0, 4) + "-" + strDate.Substring(4, 2) + "-" + strDate.Substring(6, 2);

                yPos = PrintText(e, "Date of sale ", yPos, StringAlignment.Near , false, false);
                yPos = PrintText(e, strDate, yPos, StringAlignment.Far);


                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);
                yPos = PrintText(e, "숙박내역 / Description of Accommodation", yPos, StringAlignment.Near , true);

                if (slipData["buyList"] != null)
                {
                    if (slipData["buyList"] is JArray)
                    {
                        JArray arrBuyData = (JArray)slipData["buyList"];
                        for (int i = 0; i < arrBuyData.Count(); i++)
                        {
                            yPos = PrintText(e, (i + 1) + ". " + arrBuyData[i]["goods_name"].ToString() , yPos, StringAlignment.Near , false , false);
                            yPos = PrintText(e, (arrBuyData[i]["qty"].ToString() + " Nights") , yPos, StringAlignment.Far);

                            yPos = PrintText(e, "  공급가격 Payment(Inc.Tax)", yPos, StringAlignment.Near , false , false);
                            yPos = PrintText(e,  string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(arrBuyData[i]["sales_amount"].ToString())), yPos, StringAlignment.Far);                            

                            yPos = PrintText(e, "  부가세    V.A.T " , yPos, StringAlignment.Near , false , false);
                            yPos = PrintText(e,  string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(arrBuyData[i]["tax_amount"].ToString())), yPos, StringAlignment.Far);
                        }
                    }
                }

                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);
                yPos = PrintText(e, "합계        Total ", yPos, StringAlignment.Near, true);

                yPos = PrintText(e, "공급가격   Payment(Inc.Tax) ", yPos, StringAlignment.Near , false, false);
                yPos = PrintText(e,string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(slipData["sales_amount"].ToString())), yPos, StringAlignment.Far);

                yPos = PrintText(e, "부가세      V.A.T"  , yPos, StringAlignment.Near , false, false);
                yPos = PrintText(e, string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(slipData["tax_amount"].ToString())), yPos, StringAlignment.Far);

                yPos = PrintText(e, "환급액      Refund Amount", yPos, StringAlignment.Near , false, false);
                yPos = PrintText(e, string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(slipData["refund_amount"].ToString())) , yPos, StringAlignment.Far);

                System.DateTime sd = new System.DateTime(Int32.Parse(slipData["sale_date"].ToString().Substring(0, 4)),
                Int32.Parse(slipData["sale_date"].ToString().Substring(4, 2))
                , Int32.Parse(slipData["sale_date"].ToString().Substring(6, 2)));
                sd = sd.AddMonths(3);

                yPos = PrintText(e, "환급유효기간/Refund Expiry date: " , yPos, StringAlignment.Near , false, false);
                yPos = PrintText(e, sd.ToString("yyyy-MM-dd"), yPos, StringAlignment.Far);

                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);

                yPos = PrintText(e, "투숙객 / GUEST Your Passport Info in English", yPos, StringAlignment.Near, true );

                String passportName = slipData["passport_name"] != null ? slipData["passport_name"].ToString() : "";
                String passportNat = slipData["passport_nat"] != null ? slipData["passport_nat"].ToString() : "";
                String passportNo = slipData["passport_no"] != null ? slipData["passport_no"].ToString() : "";

                yPos = PrintText(e, "Passport Full Name " , yPos, StringAlignment.Near , false);
                yPos = PrintText(e, passportName, yPos, StringAlignment.Far);
                
                yPos = PrintText(e, "Passport No ", yPos, StringAlignment.Near, false, false);
                yPos = PrintText(e, passportNo, yPos, StringAlignment.Far);

                yPos = PrintText(e, "Nationality " , yPos, StringAlignment.Near , false, false);
                yPos = PrintText(e, passportNat, yPos, StringAlignment.Far);

                yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5);

                yPos = PrintText(e, "환급수단/Refund Option", yPos, StringAlignment.Near, true);
                yPos = PrintText(e, "[  ]Credit Card (Visa/Master/JCB/CUP)", yPos, StringAlignment.Near);
                yPos = PrintText(e, "Card No. ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "", yPos, StringAlignment.Near , false, true , 4);
                yPos = PrintText(e, "[  ]QQ Number", yPos, StringAlignment.Near);
                yPos = PrintText(e, "", yPos, StringAlignment.Near, false, true, 4);
                yPos = PrintText(e, "[  ]Alipay ", yPos, StringAlignment.Near, false );
                yPos = PrintText(e, "(Alipay Mobile phone number 11digits) ", yPos, StringAlignment.Near, false);
                yPos = PrintText(e, " ", yPos, StringAlignment.Near, false, true, 5);

                yPos = PrintText(e, "", yPos, StringAlignment.Near, false, true, 4);

                float nMaxHeight = yPos-3;
                //yPos = PrintText(e, lineText, yPos, StringAlignment.Center, false, true, 5); //삭제처리


                //yPos = PrintText(e, "ver." + Properties.Resources.appVer, yPos, StringAlignment.Near, true,true , nSmallSize);

                System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black , 2);
                e.Graphics.DrawRectangle(myPen, new Rectangle(nStartPoint -3, 23, nPageWidthHalf+6, (int)yPos - 3));
                myPen.Dispose();


                //2018.04.03 추가 데이터 출력 
                yPos = 40; //2018.04.05 출력 위치 조정 20->40
                nStartPoint = nStartPoint + nPageWidthHalf + 10; //시작 좌표 위치 변경
                yPos = PrintText(e, "Consent to collect, use and disclose", yPos, StringAlignment.Center , false , true, -1, "맑은고딕", true);
                yPos = PrintText(e, "of personal information", yPos, StringAlignment.Center, false, true, -1, "맑은고딕", true);
                yPos = PrintText(e, "1. Personal Information Recipients", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  Hotel Tax Refund Processing Government ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  organizations", yPos, StringAlignment.Near);
                yPos = PrintText(e, " 2. Purpose of collection and use of personal", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  information", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  - To confirm identification and check departure ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  for V.A.T. refund of foreign tourists received ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  hotel accommodation.", yPos, StringAlignment.Near);
                yPos = PrintText(e, " 3. Categories for collecting personal information", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  - Personal Information : Name, Date of Birth, ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  Nationality, Passport No., Date of Departure,", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  Date of arrival", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  - Unique Identification Information : Passport ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  No.", yPos, StringAlignment.Near);
                yPos = PrintText(e, " 4. Period of holding and using personal ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  information", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  - The taxation period which includes The date ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  when the V.A.T. refund or remittance is ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  received", yPos, StringAlignment.Near);
                yPos = PrintText(e, " 5. Withdrawal of consent and contents of ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  disadvantage", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  - You have right to withdraw consents.However, ", yPos, StringAlignment.Near);
                yPos = PrintText(e, " consequence follows(You may only receive V.A.T. ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  refund at the refund counter within the airport  ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  or port of departure)", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  - Personal information will not be disclosed ", yPos, StringAlignment.Near);
                yPos = PrintText(e, "  for any other collected purpose", yPos, StringAlignment.Near);
                yPos = PrintText(e, " I will consent to disclosure of personal ", yPos, StringAlignment.Near);
                yPos = PrintText(e, " information.", yPos, StringAlignment.Near);
                yPos = PrintText(e, " I will consent to disclosure of unique ", yPos, StringAlignment.Near);
                yPos = PrintText(e, " identification information. ", yPos, StringAlignment.Near);

                String strCurrntDate = slipData["sale_date"].ToString().Substring(0, 4) + "." + slipData["sale_date"].ToString().Substring(4, 2) + "." + slipData["sale_date"].ToString().Substring(6, 2);
                yPos = PrintText(e, strCurrntDate, yPos, StringAlignment.Center);

                //서명란 
                //yPos = PrintText(e, "I agree to voluntarily provide personal INFO.", yPos, StringAlignment.Near);
                //yPos = PrintText(e, "Guest's Signature", yPos, StringAlignment.Near, true);

                yPos = PrintText(e, "Name ", yPos, StringAlignment.Near, false , false);
                yPos = PrintText(e, passportName, yPos, StringAlignment.Far);
                yPos = PrintText(e, "Signature", yPos, StringAlignment.Near, false);

                if (slipData["sign_img"] != null && !"".Equals(slipData["sign_img"].ToString().Trim()))
                {
                    byte[] sign_buff = System.Convert.FromBase64String(slipData["sign_img"].ToString());
                    ImageConverter imageConverter = new ImageConverter();
                    Image image = (Image)imageConverter.ConvertFrom(sign_buff);
                    Image resizeImage = new Bitmap(image, new Size(240, 64));
                    resizeImage.Save(Constants.filePath_Sign, ImageFormat.Jpeg);
                    yPos = PrintImg(e, resizeImage, yPos, StringAlignment.Center);
                    image.Dispose();
                    resizeImage.Dispose();
                }
                else
                {
                    yPos = PrintText(e, "  ", yPos, StringAlignment.Near);
                    yPos = PrintText(e, "  ", yPos, StringAlignment.Near);
                    yPos = PrintText(e, "  ", yPos, StringAlignment.Near);
                    yPos = PrintText(e, "  ", yPos, StringAlignment.Near);
                }

                yPos = PrintText(e, "ver." + Properties.Resources.appVer, nMaxHeight-16, StringAlignment.Center, true, true, nSmallSize);

                myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 2);
                //e.Graphics.DrawRectangle(myPen, new Rectangle(nStartPoint - 3, 3, nPageWidthHalf + 6, (int)yPos - 3));
                e.Graphics.DrawRectangle(myPen, new Rectangle(nStartPoint - 3, 23, nPageWidthHalf + 6, (int)nMaxHeight));
                
                myPen.Dispose();
            }
            catch (Exception ex)
            {
                m_Logger.Error(ex.Message, ex);
                Console.WriteLine(ex.Message);
            }

        }
        
        private float PrintText(PrintPageEventArgs e , string strData , float yPos, StringAlignment align,  Boolean bBold = false, Boolean bNewLine = true, int nFontSize = -1 ,   string fontName = "맑은 고딕", Boolean bUnderline = false)
        {
            strFormat.Alignment = align;
            strFont = new Font(fontName, nFontSize <0 ? nNomalSize: nFontSize, bUnderline ? FontStyle.Underline : (bBold ? FontStyle.Bold : FontStyle.Regular));//2018.04.02 Underline 옵션 추가
            rect = new Rectangle(nStartPoint, (int)yPos, nPageWidthHalf, strFont.Height);
            e.Graphics.DrawString(strData, strFont, Brushes.Black, rect, strFormat);
            e.Graphics.DrawRectangle(Pens.White, rect);
            if(bNewLine)
                yPos += strFont.Height +1;
            return yPos;
        }

        private float PrintImg(PrintPageEventArgs e, Image img, float yPos, StringAlignment align, Boolean bBold = false, int nFontSize = -1, string fontName = "맑은 고딕")
        {
            e.Graphics.DrawImage((Image)img, new Rectangle(nStartPoint+ ((nPageWidthHalf - img.Width) / 2), (int)yPos, img.Width, img.Height) );
            yPos += img.Height;
            return yPos;
        }


        public string getDocId(string docid)
        {
            string[] arrDocId = docid.Split('.');

            string strDocId = "";
            for (int i = 0; i < arrDocId.Length; i++)
            {
                strDocId += arrDocId[i];
            }

            return strDocId;
        }
    }
}
