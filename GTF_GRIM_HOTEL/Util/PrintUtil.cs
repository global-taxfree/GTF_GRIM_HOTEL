using GTF_Printer;
using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace GTF_STFM.Util
{
    class PrintUtil
    {

        string CRLF = "\r\n";
        string ESC = "\x1b";


        string FONT_BOLD = "\x01";
        string FONT_NOMAL = "\x00";
        string lineSpacing2 = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { (byte)'|', (byte)'\x33', (byte)'\x40' });
        string FONT_SIZE_LARGE = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { (byte)'|', (byte)'\x21', (byte)'\x30' });
        string FONT_SIZE_NORMAL = "\x40";

        string strBold = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27 }) + "|bC";
        string strCenterJustify = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] {  (byte)'|', (byte)'c', (byte)'A' });
        string strRightJustify = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] {  (byte)'|', (byte)'r', (byte)'A' });
        string strCutComm = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] {  (byte)'|', (byte)'9', (byte)'5', (byte)'P' });

        string strSmallFont = System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, (byte)'|', (byte)'t', (byte)'b', (byte)'C' });

        int nPaddingLen = 56;
        int nPaddingLen_big = 42;

        IBarcodeWriter writer = null;
        Bitmap qrbmp = null;
        Bitmap bmap = null;
        Image img = null;
        Image img2 = null;

        ILog m_Logger = null;

        public PrintUtil(ILog Logger = null)
        {
            m_Logger = Logger;
            if (m_Logger == null)
            {
                m_Logger = Constants.LOGGER_MAIN;
            }
        }

        public int PrintRefundSlip(JObject slipData)
        {
            int nRet = 0;

            //string filePath_QR = Directory.GetCurrentDirectory() + "/../Image/gtf_qr.bmp";
            //string filePath_LOGO = Directory.GetCurrentDirectory() + "/../Image/gtf_logo.bmp";
            //string filePath_ROUND_LOGO = Directory.GetCurrentDirectory() + "/../Image/gtf_logo_round.bmp";
            //string filePath_Combine = Directory.GetCurrentDirectory() + "/../Image/combine_QR.jpg";

            if (Constants.PRINTER_SELECT_TYPE == 0) //일반프린터
            {
                writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions
                    {

                        Width = 120,
                        Height = 120
                    }
                };
            }
            else if (Constants.PRINTER_SELECT_TYPE == 1) //영수증 프린터
            {

                writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions
                    {

                        Width = 160,
                        Height = 160
                    }
                };
            }


            qrbmp = new Bitmap(writer.Write(slipData["buy_serial_no"].ToString()));
            using (var stream = new FileStream(Constants.filePath_QR, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                ImageConverter converter = new ImageConverter();
                byte[] qrBytes = (byte[])converter.ConvertTo(qrbmp, typeof(byte[]));
                stream.Write(qrBytes, 0, qrBytes.Length);
                stream.Close();
            }

            
            if (Constants.PRINTER_SELECT_TYPE == 0) //일반프린터
            {
                bmap = new Bitmap(214, 120);
                Graphics g = Graphics.FromImage(bmap);

                img = Bitmap.FromFile(Constants.filePath_ROUND_LOGO_NORMAL);
                img2 = Bitmap.FromFile(Constants.filePath_QR);

                g.DrawImage(img, 0, 0);
                g.DrawImage(img2, 94, 0);

                bmap.Save(Constants.filePath_Combine, ImageFormat.Jpeg);
                bmap.Dispose();
                img.Dispose();
                img2.Dispose();
            }
            else if (Constants.PRINTER_SELECT_TYPE == 1) //영수증 프린터
            {
                bmap = new Bitmap(126+160, 160);
                Graphics g = Graphics.FromImage(bmap);

                img = Bitmap.FromFile(Constants.filePath_ROUND_LOGO);
                img2 = Bitmap.FromFile(Constants.filePath_QR);

                g.DrawImage(img, 0, 0);
                g.DrawImage(img2, 126, 0);

                bmap.Save(Constants.filePath_Combine, ImageFormat.Jpeg);
                bmap.Dispose();
                img.Dispose();
                img2.Dispose();
            }


            GTF_ReceiptPrinter dd = new GTF_ReceiptPrinter();
            WindowPrinterUtil wpu = new WindowPrinterUtil();

            if ( Constants.PRINTER_SELECT_TYPE ==0) //일반프린터
            {
                //dd.PrintHotelRefundSlip_Printer(Constants.PRINTER_OPOS_TYPE, Constants.PRINTER_OPOS_TYPE);
                wpu.PrintRefundSlip(slipData);
            }
            else if (Constants.PRINTER_SELECT_TYPE == 1) //영수증 프린터
            {
                try {
                    Utils util = new Utils();
                    System.DateTime sd = new System.DateTime(Int32.Parse(slipData["sale_date"].ToString().Substring(0, 4)),
                        Int32.Parse(slipData["sale_date"].ToString().Substring(4, 2))
                        , Int32.Parse(slipData["sale_date"].ToString().Substring(6, 2)));
                    sd = sd.AddMonths(3);
                    Encoding enc = Encoding.Default;
                    //Constants.PRINTER_OPOS_TYPE = "BIXOLON350";
                    Boolean bOpen = dd.OpenOPOS(Constants.PRINTER_OPOS_TYPE);

                    StringBuilder sb = new StringBuilder();
                    dd.PrintOPOS_Text(ESC + "|cA" + ESC + "|N" + CRLF);

                    //로고는 이미지로 대체
                    //dd.PrintOPOS_Text( ESC + "|2C" + ESC + "|cA" +ESC + "!0" + "GLOBAL TAX FREE "  + CRLF);
                    dd.PrintOPOS_BMP(Constants.filePath_LOGO);


                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.PrintOPOS_Text(ESC + "|cA" + ESC + "!0" + "숙 박 용 역" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "Hotel Tax Refund" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "This Document is authorized by Korea NTS" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "국세청장이 인정한 서식임" + CRLF);

                    dd.PrintOPOS_BMP(Constants.filePath_Combine);
                    //dd.PrintOPOS_BMP(filePath_QR);
                    //dd.PrintOPOS_BMP(filePath_ROUND_LOGO);
                    //dd.PrintOPOS_BMP(filePath_Combine2);
                    //bool bTest = true;
                    //if (bTest)
                    //{
                    //    dd.PrintOPOS_Text(ESC + "|N" + "Guest's Signature" + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF);
                    //    return 0;
                    //}

                    dd.font_change_Small();

                    string strBuySerialNo = slipData["buy_serial_no"].ToString();
                    dd.PrintOPOS_Text(ESC + "|N" + "gtf@global-taxfree.com            www.global-taxfree.com" + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text(ESC + "|N" + "Contact Us : +82 2 518 0837" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "단말기 ID " + slipData["tml_id"].ToString() + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "구매일련번호      " + strBuySerialNo.Substring(0, 2)
                        + "-" + strBuySerialNo.Substring(2, 5)
                        + "-" + strBuySerialNo.Substring(7, 5)
                        + "-" + strBuySerialNo.Substring(12, 2)
                        + "-" + strBuySerialNo.Substring(14)
                         + CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text(ESC + "E" + FONT_BOLD + "호텔/Hotel" + CRLF);
                    String strBizPermitNo = slipData["biz_permit_no"].ToString();
                    strBizPermitNo = strBizPermitNo.Substring(0, 3) + "-"+ strBizPermitNo.Substring(3, 2) + "-" + strBizPermitNo.Substring(5);
                    dd.PrintOPOS_Text(ESC + "|N" + "사업자번호 " + strBizPermitNo.PadLeft(nPaddingLen_big - 11, ' ') + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "관광사업등록번호 " + "".PadLeft(nPaddingLen_big - 17 - enc.GetByteCount(slipData["company_reg_no"].ToString()), ' ') + slipData["company_reg_no"].ToString()+ CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "상호 " + "".PadLeft(util.getPaddingLen(nPaddingLen_big - 5
                        - enc.GetByteCount(slipData["shop_name"].ToString())), ' ') + slipData["shop_name"].ToString() + CRLF);

                    int nCeoNameCnt = enc.GetByteCount(slipData["ceo_name"].ToString());
                    dd.PrintOPOS_Text(ESC + "|N" + "대표자 " +"".PadLeft(nPaddingLen_big - 7
                        - enc.GetByteCount(slipData["ceo_name"].ToString()), ' ') + slipData["ceo_name"].ToString() + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "주소 " + "".PadLeft(util.getPaddingLen(nPaddingLen_big - 5 - enc.GetByteCount(slipData["shop_addr"].ToString())), ' ')
                        + slipData["shop_addr"].ToString() + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "연락처 " + slipData["shop_phone"].ToString().PadLeft(nPaddingLen_big - 7, ' ') + CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();
                    string strDate = slipData["sale_date"].ToString();
                    strDate = strDate.Substring(0, 4) + "-" + strDate.Substring(4, 2) + "-" + strDate.Substring(6, 2);
                    dd.PrintOPOS_Text(ESC + "|N" + "Date of sale " + strDate.PadLeft(nPaddingLen_big - 13, ' ') + CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text(ESC + "E" + FONT_BOLD + "숙박내역/Description of Accommodation " + CRLF);
                    if (slipData["buyList"] != null)
                    {
                        if (slipData["buyList"] is JArray)
                        {
                            JArray arrBuyData = (JArray)slipData["buyList"];
                            for (int i = 0; i < arrBuyData.Count(); i++)
                            {
                                dd.PrintOPOS_Text((i + 1) + ". " + arrBuyData[i]["goods_name"].ToString()
                                    + (arrBuyData[i]["qty"].ToString() + " Nights")
                                    .PadLeft(nPaddingLen_big - enc.GetByteCount((i + 1) + ". " + arrBuyData[i]["goods_name"].ToString()) , ' ')
                                      + CRLF);
                                dd.PrintOPOS_Text("   공급가격 Payment(Inc.Tax) " + string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(arrBuyData[i]["sales_amount"].ToString())).PadLeft(nPaddingLen_big - 29, ' ') + CRLF);
                                dd.PrintOPOS_Text("   부가세   V.A.T " + string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(arrBuyData[i]["tax_amount"].ToString())).PadLeft(nPaddingLen_big - 18, ' ') + CRLF);
                            }
                        }
                    }

                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text("합계       Total " + CRLF);

                    dd.PrintOPOS_Text("공급가격   Payment(Inc.Tax) " + string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(slipData["sales_amount"].ToString())).PadLeft(nPaddingLen_big - 28, ' ') + CRLF);
                    dd.PrintOPOS_Text("부가세     V.A.T" + string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(slipData["tax_amount"].ToString())).PadLeft(nPaddingLen_big - 16, ' ') + CRLF);
                    dd.PrintOPOS_Text("환급액     Refund Amount" + string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:n0}", Int64.Parse(slipData["refund_amount"].ToString())).PadLeft(nPaddingLen_big - 24, ' ') + CRLF);
                    dd.PrintOPOS_Text("환급유효기간/Refund Expiry date " + sd.ToString("yyyy-MM-dd").PadLeft(nPaddingLen_big - 33, ' ') + CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text(ESC + "E" + FONT_BOLD + "투숙객/GUEST Your Passport Info in English" + CRLF);
                    dd.font_change_Big();
                    dd.PrintOPOS_Text(ESC + "|N" + "Passport Full Name " + CRLF);
                    String passportName = slipData["passport_name"] != null ? slipData["passport_name"].ToString().PadLeft(nPaddingLen_big, ' ') :"";
                    String passportNat = slipData["passport_nat"] != null ? slipData["passport_nat"].ToString() : ""; 
                    String passportNo = slipData["passport_no"] != null ? slipData["passport_no"].ToString() :"";

                    dd.PrintOPOS_Text(ESC + "|N" + passportName + CRLF );
                    dd.PrintOPOS_Text(ESC + "|N" + "Passport No " + passportNo.PadLeft(nPaddingLen_big - 12, ' ') + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "Nationality " + passportNat.PadLeft(nPaddingLen_big - 12, ' ') + CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();

                    dd.PrintOPOS_Text(ESC + "E" + FONT_BOLD + "환급수단/Refund Option " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "[  ]Credit Card (Visa/Master/JCB/CUP)" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "Card No." + CRLF + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "[  ]QQ Number" + CRLF + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "[  ]Alipay" + CRLF );
                    dd.PrintOPOS_Text(ESC + "|N" + "(Alipay Mobile phone number 11digits)" + CRLF + CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + "-".PadRight(nPaddingLen, '-') + CRLF);
                    dd.font_change_Big();

                    //출력데이터 추가

                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + ESC + "|uC"+"Consent to collect, use and disclose" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + ESC + "|uC" + "of personal information" + CRLF);

                    dd.PrintOPOS_Text(ESC + "|N" + "1. Personal Information Recipients" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " Hotel Tax Refund Processing Government " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " organizations" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "2. Purpose of collection and use of personal" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " information" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " - To confirm identification and check departure " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " for V.A.T. refund of foreign tourists received " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " hotel accommodation." + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "3. Categories for collecting personal information" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " - Personal Information : Name, Date of Birth, " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " Nationality, Passport No., Date of Departure," + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " Date of arrival" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " - Unique Identification Information : Passport " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " No." + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "4. Period of holding and using personal " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " information" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " - The taxation period which includes The date " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " when the V.A.T. refund or remittance is " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " received" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "5. Withdrawal of consent and contents of " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " disadvantage" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " - You have right to withdraw consents.However, " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " consequence follows(You may only receive V.A.T. " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " refund at the refund counter within the airport  " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " or port of departure)" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " - Personal information will not be disclosed " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + " for any other collected purpose" + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "I will consent to disclosure of personal " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "information." + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "I will consent to disclosure of unique " + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "identification information. " + CRLF);

                    //String strCurrntDate = DateTime.Now.ToString("yyyy.MM.dd");

                    String strCurrntDate = slipData["sale_date"].ToString().Substring(0, 4) + "." + slipData["sale_date"].ToString().Substring(4, 2) + "." + slipData["sale_date"].ToString().Substring(6, 2);
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" + strCurrntDate + CRLF);
                    dd.PrintOPOS_Text(ESC + "|N" + "Name " + passportName.Trim().PadLeft(nPaddingLen_big - 5, ' ') + CRLF);

                    //2018.04.03 영수증프린터 출력 데이터 변경
                    //dd.PrintOPOS_Text(ESC + "|N" + "I agree to voluntarily provide personal INFO." + CRLF + CRLF);
                    //dd.PrintOPOS_Text(ESC + "|N" + "Guest's Signature" + CRLF + CRLF );
                    dd.PrintOPOS_Text(ESC + "|N" + "Signature" + CRLF + CRLF);
                    if (slipData["sign_img"] != null && !"".Equals(slipData["sign_img"].ToString().Trim()))
                    {
                        byte[] sign_buff = System.Convert.FromBase64String(slipData["sign_img"].ToString());
                        ImageConverter imageConverter = new ImageConverter();
                        Image image = (Image)imageConverter.ConvertFrom(sign_buff);
                        Image resizeImage = new Bitmap(image, new Size(360, 96));
                        resizeImage.Save(Constants.filePath_Sign, ImageFormat.Jpeg);
                        image.Dispose();
                        resizeImage.Dispose();
                        dd.PrintOPOS_BMP(Constants.filePath_Sign);
                    }
                    else {
                        dd.PrintOPOS_Text(CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF);
                    }
                    dd.PrintOPOS_Text( CRLF);
                    dd.font_change_Small();
                    dd.PrintOPOS_Text(ESC + "|N" + ESC + "|cA" +"ver." + Properties.Resources.appVer + CRLF + CRLF);
                    dd.PrintOPOS_Text(CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF + CRLF);

                }
                catch (Exception e)
                {
                    m_Logger.Error(e.Message, e);
                    Console.WriteLine(e.Message);
                }finally
                {
                    if (dd != null)
                    {
                        dd.CusPaper();
                        dd.CloseOPOS();
                    }
                    if (writer != null)
                    {
                        writer = null;
                    }
                    if (qrbmp != null)
                    {
                        qrbmp.Dispose();
                        qrbmp = null;
                    }
                    if (bmap != null)
                    {
                        bmap.Dispose();
                        bmap = null;
                    }
                    if (img != null)
                    {
                        img.Dispose();
                        img = null;
                    }
                    if (img2 != null)
                    {
                        img2.Dispose();
                        img2 = null;
                    }
                }
            }

            try
            {
                if (System.IO.File.Exists(Constants.filePath_QR))
                {
                    System.IO.File.Delete(Constants.filePath_QR);
                }
                if (System.IO.File.Exists(Constants.filePath_Combine))
                {
                    System.IO.File.Delete(Constants.filePath_Combine);
                }
                if (System.IO.File.Exists(Constants.filePath_Sign))
                {
                    System.IO.File.Delete(Constants.filePath_Sign);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return nRet;

        }

        public Boolean printNomalData(JObject slipDate)
        {
            Boolean bRet = true;
            PrintDocument printDocObj = new PrintDocument();
            if (Constants.PRINTER_TYPE != null && !string.Empty.Equals(Constants.PRINTER_TYPE.Trim()))
            {
                printDocObj.PrinterSettings.PrinterName = Constants.PRINTER_TYPE;
            }
            
            return bRet;
        }


    }
}
