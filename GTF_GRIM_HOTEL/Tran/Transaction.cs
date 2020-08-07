using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTF_Comm;
using GTF_STFM.Util;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace GTF_STFM.Tran
{
    //거래실행. 필요시 로컬 DB 정보 업데이트
    class Transaction
    {
        //public string ServerUrl     { get; set; }
        public string ServerIp      { get; set; }
        public string ServerPort    { get; set; }


        public string url_Slip_Submit = string.Empty;      //거래등록
        public string url_Slip_Cancel = string.Empty;      //거래취소
        public string url_Slip_SearchList = string.Empty;  //전표목록조회
        public string url_Slip_SearchListCnt = string.Empty;  //전표목록 카운트
        public string url_Slip_Info = string.Empty;        //전표정보
        public string url_CountryList = string.Empty;      //국가코드
        public string url_TmlInfo = string.Empty;          //단말기정보
        public string url_RefundRate = string.Empty;       //환급율
        public string url_TaxRate = string.Empty;          //세금계산율
        public string url_Status_check = string.Empty;     //서버 상태 체크

        public Transaction()
        {
            url_Slip_Submit = "/hotel/issue/issueSlip";           
            url_Slip_Cancel = "/hotel/issue/cancelSlip";          
            url_Slip_SearchList = "/hotel/search/searchSlipList";
            url_Slip_SearchListCnt = "/hotel/search/searchSlipListCnt";
            url_Slip_Info = "/hotel/search/searchSlipInfo";
            url_CountryList = "/code/searchCountryList";
            url_TmlInfo = "/code/searchTerminalInfo";
            url_RefundRate = "/code/refundRateInfo";
            url_TaxRate = "/code/taxRateInfo";
            url_Status_check = "/code/statusCheck";

            IgnoreBadCertificates();
        }
           
  
        //콤보 아이템 목록 갱신
        public JArray SearchItemList(JObject jsonWhere = null)
        {
            //로컬DB 조회
            JObject jsonReq = new JObject();
            JArray arrjsonRes = new JArray();
            JObject jsonTempRes = null;
            JArray arrjsonTempRes = null;
            //로컬 DB 조회
            arrjsonTempRes = Constants.LDB_MANAGER.SelectTable("ITEM", jsonWhere);
            for (int i = 0; i < arrjsonTempRes.Count; i++)
            {
                //국적만 받아옴
                jsonTempRes = (JObject)arrjsonTempRes[i];
                string tempData = jsonTempRes["SEQ"].ToString();
                jsonTempRes.Remove("SEQ");
                jsonTempRes.Add("SEQ", Int32.Parse(tempData));
                arrjsonRes.Add(jsonTempRes);
            }
            JArray sorted = new JArray(arrjsonRes.OrderBy(obj => obj["SEQ"]));
            arrjsonRes = sorted;
            return arrjsonRes;
        }


        public long getSeq(string strKey)
        {
            string strRet = string.Empty;
            long nSeq = 0;
            JObject jsonWhere = new JObject();
            JObject jsonInsert = new JObject();
            JObject jsonUpdate = new JObject();
            jsonWhere.Add("ITEM_KEY", strKey);

            JArray arrRet = Constants.LDB_MANAGER.SelectTable("ID_CREATION_RULE", jsonWhere);
            if (arrRet == null || arrRet.Count == 0)
            {
                jsonInsert.Add("ITEM_KEY", strKey);
                jsonInsert.Add("ITEM_DESC", strKey);
                jsonInsert.Add("ITEM_VALUE", "0");
                Constants.LDB_MANAGER.InsertTable(jsonInsert, "ID_CREATION_RULE");
                jsonInsert.RemoveAll();
                jsonInsert = null;
            }
            else
            {
                JObject jsonRet = (JObject)arrRet[0];
                nSeq = Int64.Parse(jsonRet["ITEM_VALUE"].ToString());
                if (nSeq == Int64.MaxValue)//최대숫자에 도달하면 0으로 변경. 해당경우는 없겠지만...
                    nSeq = 0;
                else
                    nSeq++;
                jsonUpdate.Add("ITEM_VALUE", nSeq.ToString());

                Constants.LDB_MANAGER.updateTable(jsonUpdate, jsonWhere, "ID_CREATION_RULE");
                jsonUpdate.RemoveAll();
                jsonUpdate = null;
            }
            return nSeq;
        }
        
        public Boolean InsertSlip(JObject jsonSlip , JArray arrItems , JObject jsonSlipDocs)
        {
            Boolean bRet = true;
            try {
                //전표저장
                if(!Constants.LDB_MANAGER.ExitsTable("REFUNDSLIP"))
                {
                    Constants.LDB_MANAGER.createTable(jsonSlip, "REFUNDSLIP");//DB생성
                }

                if (!Constants.LDB_MANAGER.ExitsTable("SALES_GOODS"))
                {
                    if(arrItems != null && arrItems.Count >0)
                        Constants.LDB_MANAGER.createTable((JObject)arrItems[0], "SALES_GOODS");//DB생성
                }

                if (!Constants.LDB_MANAGER.ExitsTable("SLIP_PRINT_DOCS"))
                {
                    Constants.LDB_MANAGER.createTable(jsonSlipDocs, "SLIP_PRINT_DOCS");//DB생성
                }

                //전표 저장
                Constants.LDB_MANAGER.InsertTable(jsonSlip, "REFUNDSLIP");

                //품목저장
                if (arrItems != null)
                {
                    for (int i = 0; i < arrItems.Count; i++)
                    {
                        JObject tempObj = (JObject)arrItems[i];
                        tempObj.Remove("SHOP_NO");
                        Constants.LDB_MANAGER.InsertTable(tempObj, "SALES_GOODS");
                    }
                }

                //출력내용 저장
                Constants.LDB_MANAGER.InsertTable(jsonSlipDocs, "SLIP_PRINT_DOCS");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                bRet = false;
            }
            return bRet;
        }

        //전표 테이블 내용 업데이트
        public Boolean UpdateSlip(JObject jsonSlip, JObject jsonFlag)
        {
            Boolean bRet = true;
            try
            {
                Constants.LDB_MANAGER.updateTable(jsonFlag, jsonSlip, Constants.TABLE_REFUND_SLIP);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                bRet = false;
            }
            return bRet;
        }

        //전표 조회
        //로컬DB 조회 또는 서버 조회 양쪽 공용으로 사용하기 위해서...
        public JArray SearchSlips(string strStartDate, string strEndDate, string strSendFlag, string strSlipStatus = "", string strSlipNo = "")
        {
            JArray jsonRes = null;
            if (Constants.LDB_MANAGER.ExitsTable(Constants.TABLE_REFUND_SLIP))
            {
                
                if (strStartDate == null || string.Empty.Equals(strStartDate))
                {
                    strStartDate = "20010101";
                }
                if (strEndDate == null || string.Empty.Equals(strEndDate))
                {
                    strEndDate = "29991231";
                }
                jsonRes = Constants.LDB_MANAGER.getSlipList(Constants.USER_ID, Constants.TABLE_REFUND_SLIP, strStartDate, strEndDate
                    , "ALL".Equals(strSendFlag.Trim()) ? "" : strSendFlag.Trim()
                    , "ALL".Equals(strSlipStatus.Trim()) ? "" : strSlipStatus.Trim() 
                    , strSlipNo
                    );
                //jsonRes = Constants.LDB_MANAGER.SelectTable(Constants.TABLE_REFUND_SLIP, jsonWhere);
            }
            return jsonRes;
        }


        //세부항목조회
        public JArray SearchSlipDetail(string strSlipNo)
        {
            JArray arrJsonRes = null;
            JObject jsonWhere = new JObject();
            jsonWhere.Add("SLIP_NO", strSlipNo);
            arrJsonRes = Constants.LDB_MANAGER.SelectTable("SALES_GOODS", jsonWhere);
            jsonWhere.RemoveAll();
            return arrJsonRes;
        }

        //로컬DB 설정값 조회
        public string SearchConfig()
        {
            string strRes = string.Empty;
            return strRes;
        }

        //가장 마지막에 접속한 사용자 정보 Get
        public JArray getLastUserInfo()
        {
            //JObject jsonRes = null;
            JArray arrjsonRes = new JArray();
            arrjsonRes = Constants.LDB_MANAGER.SelectTable("USERINFO");
            return arrjsonRes;
        }

        //가장 마지막에 접속한 사용자 정보 업데이트
        public string setLastUserInfo(JObject jsonRes)
        {
            string strRes = string.Empty;
            return strRes;
        }

        //UPI Bin 체크
        public Boolean Upi_BinCHeck(string strCardNo)
        {
            Boolean bRet = false;
            strCardNo = strCardNo.Replace("-", "");
            JArray arrjsonRes = new JArray();
            arrjsonRes = Constants.LDB_MANAGER.SelectUpiBinTable("BIN" , strCardNo);
            if (arrjsonRes != null && arrjsonRes.Count > 0)
                bRet = true;
            return bRet;
        }

        //UPI Bin 체크
        public Boolean QQ_Check(string strQQID)
        {
            Boolean bRet = true;
            decimal tempDec = 0;
            //데이터 체크
            if(strQQID == null || string.Empty.Equals(strQQID.Trim()) || !decimal.TryParse(strQQID, out tempDec))
            {
                bRet = false;
            }
            //값 범위
            if (tempDec < 10000 || tempDec > 4294967295)
            {
                bRet = false;
            }
            return bRet;
        }


        //서버 송신용 전문 생성
        public string BuildSlipDoc(string strSlipNo)
        {
            string strRet = "";
            //임시데이터 
            JObject jsonRet = null;
            JObject jsonRetItem = null;

            //where 조건
            JObject jsonWhere = new JObject();
            jsonWhere.Add("SLIP_NO", strSlipNo);
            jsonWhere.Add("USERID", Constants.USER_ID);

            //return 용
            JObject jsonSlip = new JObject();
            JObject SlipRet = new JObject();
            JArray ArrSlipRet = new JArray();
            JArray ArrItemsRet = new JArray();

            //로컬DB 조회 결과
            JArray arrSlip = Constants.LDB_MANAGER.SelectTable("REFUNDSLIP", jsonWhere);
            JArray ArrSlipItems = Constants.LDB_MANAGER.SelectTable("SALES_GOODS", jsonWhere);

            if (arrSlip.Count > 0)
            {
                for (int j = 0; j < arrSlip.Count; j++)
                {
                    ArrSlipRet.Clear();
                    ArrItemsRet.Clear();
                    jsonRet = (JObject)arrSlip[j];
                    SlipRet.Add("buyer_name", jsonRet["BUYER_NAME"].ToString());
                    SlipRet.Add("passport_serial_no", jsonRet["PASSPORT_SERIAL_NO"].ToString());
                    SlipRet.Add("nationality_code", jsonRet["NATIONALITY_CODE"].ToString());
                    SlipRet.Add("gender_code", jsonRet["GENDER_CODE"].ToString());
                    SlipRet.Add("buyer_birth", jsonRet["BUYER_BIRTH"].ToString());
                    SlipRet.Add("pass_expirydt", jsonRet["PASS_EXPIRYDT"].ToString());
                    SlipRet.Add("input_way_code", jsonRet["INPUT_WAY_CODE"].ToString()); //여권스캐너 입력
                    SlipRet.Add("residence_no", jsonRet["RESIDENCE_NO"].ToString());
                    SlipRet.Add("entrydt", jsonRet["ENTRYDT"].ToString()); //상륙연월일
                    SlipRet.Add("passport_type", jsonRet["PASSPORT_TYPE"].ToString());
                    SlipRet.Add("slip_no", jsonRet["SLIP_NO"].ToString());
                    SlipRet.Add("merchant_no", jsonRet["MERCHANT_NO"].ToString());
                    SlipRet.Add("out_div_code", jsonRet["OUT_DIV_CODE"].ToString());
                    SlipRet.Add("refund_way_code", jsonRet["REFUND_WAY_CODE"].ToString());
                    SlipRet.Add("slip_status_code", jsonRet["SLIP_STATUS_CODE"].ToString());
                    SlipRet.Add("tml_id", jsonRet["TML_ID"].ToString());
                    SlipRet.Add("refund_cardno", jsonRet["REFUND_CARDNO"].ToString());
                    SlipRet.Add("refund_card_code", jsonRet["REFUND_CARD_CODE"].ToString());
                    SlipRet.Add("total_slipseq", jsonRet["TOTAL_SLIPSEQ"].ToString());
                    SlipRet.Add("tax_proc_time_code", jsonRet["TAX_PROC_TIME_CODE"].ToString());


                    SlipRet.Add("unikey", jsonRet["UNIKEY"].ToString());

                    SlipRet.Add("saledt", jsonRet["SALEDT"].ToString());
                    SlipRet.Add("refunddt", jsonRet["REFUNDDT"].ToString());
                    SlipRet.Add("userId", jsonRet["USERID"].ToString());
                    SlipRet.Add("merchantNo", jsonRet["MERCHANTNO"].ToString());
                    SlipRet.Add("deskId", jsonRet["DESKID"].ToString());
                    SlipRet.Add("companyID", jsonRet["COMPANYID"].ToString());

                    ArrSlipRet.Add(SlipRet);
                    //1. 전표정보
                    long total_comm_sale_amt = 0;
                    long total_comm_tax_amt = 0;
                    long total_comm_refund_amt = 0;
                    long total_comm_fee_amt = 0;

                    long total_excomm_sale_amt = 0;
                    long total_excomm_tax_amt = 0;
                    long total_excomm_refund_amt = 0;
                    long total_excomm_fee_amt = 0;


                    //2. 물품정보
                    for (int i = 0; i < ArrSlipItems.Count; i++)
                    {
                        JObject tempObj = new JObject();
                        jsonRetItem = (JObject)ArrSlipItems[i];

                        tempObj.Add("slip_no", strSlipNo);
                        tempObj.Add("sale_seq", jsonRetItem["ITEM_NO"].ToString());
                        tempObj.Add("rec_no", jsonRetItem["RCT_NO"].ToString());
                        tempObj.Add("tax_amt", jsonRetItem["TAX_AMT"].ToString());
                        tempObj.Add("refund_amt", jsonRetItem["REFUND_AMT"].ToString());
                        tempObj.Add("fee_amt", jsonRetItem["FEE_AMT"].ToString());
                        tempObj.Add("goods_items_code", jsonRetItem["ITEM_TYPE"].ToString());
                        tempObj.Add("goods_group_code", jsonRetItem["MAIN_CAT"].ToString());
                        //tempObj.Add("goods_division", jsonRetItem["MID_CAT"].ToString());
                        tempObj.Add("goods_division", "C0167");
                        //tempObj.Add("tax_proc_time_code", jsonRet["TAX_PROC_TIME_CODE"].ToString());
                        tempObj.Add("tax_proc_time_code", jsonRetItem["TAX_TYPE"].ToString());
                        tempObj.Add("goods_amt", jsonRetItem["BUY_AMT"].ToString());
                        tempObj.Add("tax_point_proc_code", jsonRet["TAX_POINT_PROC_CODE"].ToString());
                        tempObj.Add("goods_qty", jsonRetItem["QTY"].ToString());
                        tempObj.Add("goods_unit_price", jsonRetItem["UNIT_AMT"].ToString());
                        tempObj.Add("goods_name", jsonRetItem["ITEM_NAME"].ToString());
                        tempObj.Add("goods_tax_code", "SCT");
                        tempObj.Add("same_unit_saleAmt", "Y");
                        tempObj.Add("worker_id", Constants.USER_ID);
                        ////소비용품
                        //if ("A0002".Equals(jsonRetItem["ITEM_TYPE"].ToString()))
                        //{
                        //    total_comm_sale_amt += Int64.Parse(jsonRetItem["BUY_AMT"].ToString());    //소비용품 판매액 합산 //(Int64.Parse(jsonRetItem["BUY_AMT"].ToString()) - Int64.Parse(jsonRetItem["TAX_AMT"].ToString()));//내세토탈 판매액
                        //    total_comm_tax_amt += Int64.Parse(jsonRetItem["TAX_AMT"].ToString());   //내세 세금합산
                        //    total_comm_refund_amt += Int64.Parse(jsonRetItem["REFUND_AMT"].ToString()); //내세 환급금 합산
                        //}
                        //else
                        //{
                        //    total_excomm_sale_amt += Int64.Parse(jsonRetItem["BUY_AMT"].ToString());    //외세 판매액 합산
                        //    total_excomm_tax_amt += Int64.Parse(jsonRetItem["TAX_AMT"].ToString());     //외세 세금 합산
                        //    total_excomm_refund_amt += Int64.Parse(jsonRetItem["REFUND_AMT"].ToString());   //외세 환급금 합산
                        //}
                        ArrItemsRet.Add(tempObj);
                    }


                    total_excomm_sale_amt = Int64.Parse(jsonRet["GOODS_BUY_AMT"].ToString());
                    total_excomm_tax_amt = Int64.Parse(jsonRet["GOODS_TAX_AMT"].ToString());
                    total_excomm_refund_amt = Int64.Parse(jsonRet["GOODS_REFUND_AMT"].ToString());

                    total_comm_sale_amt = Int64.Parse(jsonRet["CONSUMS_BUY_AMT"].ToString());
                    total_comm_tax_amt = Int64.Parse(jsonRet["CONSUMS_TAX_AMT"].ToString());
                    total_comm_refund_amt = Int64.Parse(jsonRet["CONSUMS_REFUND_AMT"].ToString());

                    SlipRet.Add("total_excomm_in_tax_sale_amt", jsonRet["TOTAL_EXCOMM_IN_TAX_SALE_AMT"].ToString());
                    SlipRet.Add("total_comm_in_tax_sale_amt", jsonRet["TOTAL_COMM_IN_TAX_SALE_AMT"].ToString());

                    total_comm_fee_amt = total_comm_tax_amt - total_comm_refund_amt;//소비용품 총 수수료
                    total_excomm_fee_amt = total_excomm_tax_amt - total_excomm_refund_amt;//일반물품 총 수수료

                    //소비용품
                    SlipRet.Add("comm", total_comm_sale_amt > 0 ? "A0002" : "");
                    SlipRet.Add("total_comm_sale_amt", total_comm_sale_amt.ToString());
                    SlipRet.Add("total_comm_tax_amt", total_comm_tax_amt.ToString());
                    SlipRet.Add("total_comm_refund_amt", total_comm_refund_amt.ToString());
                    SlipRet.Add("total_comm_fee_amt", total_comm_fee_amt.ToString());

                    //일반용품
                    SlipRet.Add("excomm", total_excomm_sale_amt > 0 ? "A0001" : "");
                    SlipRet.Add("total_excomm_sale_amt", total_excomm_sale_amt.ToString());
                    SlipRet.Add("total_excomm_tax_amt", total_excomm_tax_amt.ToString());
                    SlipRet.Add("total_excomm_refund_amt", total_excomm_refund_amt.ToString());
                    SlipRet.Add("total_excomm_fee_amt", total_excomm_fee_amt.ToString());

                    //if (bInTax)
                    //{
                    //    SlipRet.Add("total_excomm_in_tax_sale_amt", (total_excomm_sale_amt - total_excomm_tax_amt).ToString());
                    //    SlipRet.Add("total_comm_in_tax_sale_amt", (total_comm_sale_amt - total_comm_tax_amt).ToString());
                    //}else
                    //{
                    //    SlipRet.Add("total_excomm_in_tax_sale_amt", (total_excomm_sale_amt ).ToString());
                    //    SlipRet.Add("total_comm_in_tax_sale_amt", (total_comm_sale_amt  ).ToString());
                    //}
                    SlipRet.Add("remit_amt", (total_comm_refund_amt + total_excomm_refund_amt).ToString());
                    
                    SlipRet.Add("saleGoodsList", ArrItemsRet);
                    jsonSlip.Add("slipList", ArrSlipRet); 
                }
                jsonSlip.Add("userId", Constants.USER_ID);
                jsonSlip.Add("companyID", Constants.COMPANY_ID);
                jsonSlip.Add("languageCD", Constants.LANGUAGECD);
                jsonSlip.Add("merchantNo", Constants.MERCHANT_NO);
                jsonSlip.Add("deskId", Constants.DESK_ID);
                strRet = jsonSlip.ToString();
            }
            
            return strRet; 
        }

        //전표출력용 전문 Get
        public JObject GetPrintDocs(string strSlipNo)
        {
            JObject jsonRet = null;
            JObject jsonWhere = new JObject();
            jsonWhere.Add("SLIP_NO", strSlipNo);
            JArray arrSlip = Constants.LDB_MANAGER.SelectTable("SLIP_PRINT_DOCS", jsonWhere);
            if(arrSlip != null && arrSlip.Count > 0)
            {
                jsonRet = (JObject)arrSlip[0];
            }
            
            return jsonRet;
        }

        public Boolean NetworkPing()
        {
            Boolean bRet = true;
            GTF_CommManager comm = new GTF_CommManager(null);
            bRet = comm.sendPing(Constants.SERVER_URL);
            return bRet;
        }

        public bool checkNetworkStatus()
        {
            Boolean bRet = true;
            string strReq = string.Empty;
            string strRes = string.Empty;
            JObject jsonRes = null;
            try
            {
                GTF_CommManager comm = new GTF_CommManager(null);
                strRes = comm.sendHttp_Json(Constants.SERVER_URL + url_Status_check, strReq, true, 10 , false);

                if (strRes == null || string.Empty.Equals(strRes.Trim()))
                {
                    //처리오류
                    bRet = false;
                }
                else
                {
                    jsonRes = JObject.Parse(strRes);
                    if ("S".Equals((string)jsonRes["result"]))
                    {
                        //서버상태 체크 성공
                        bRet = true;
                    }
                    else
                    {
                        //서버상태 체크 실패
                        bRet = false;
                    }
                }
            }
            catch (Exception e)
            {
                Constants.LOGGER_MAIN.Info(e.Message);
            }
            return bRet;
        }

        //국가코드 조회
        public static JArray contryList ()
        {
            JArray arrRet = new JArray();
            return arrRet;
        }

        //환급액 계산식 조회
        public static JObject refundCal()
        {
            JObject objRet = new JObject();
            return objRet;
        }

        //세금 계산식 조회
        public static JObject taxCal()
        {
            JObject objRet = new JObject();
            return objRet;
        }

        public static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            System.Net.ServicePointManager.ServerCertificateValidationCallback
             = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }



        private static bool AcceptAllCertifications
        (
            object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certification,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors
        )
        {
            return true;
        }

        //서버 송신용 전문 생성
        public JArray sendServer_arr(String sendData, String strUrl, int nTimeout = 60, Boolean bLog = true, Boolean bEnocode = false)
        {
            string strReq = string.Empty;
            string strRes = string.Empty;
            JArray jsonRes = null;
            try
            {
                GTF_CommManager comm = new GTF_CommManager(Constants.LOGGER_MAIN);
                strRes = comm.sendHttp_Json(Constants.SERVER_URL + strUrl, sendData, true,  nTimeout ,  bLog , bEnocode);

                if (strRes == null || string.Empty.Equals(strRes.Trim()))
                {
                    jsonRes = null;
                }
                else
                {
                    jsonRes = JArray.Parse(strRes);
                }
            }
            catch (Exception e)
            {
                Constants.LOGGER_MAIN.Error(e.Message, e);
            }
            return jsonRes;
        }

        public JObject sendServer_object(String sendData, String strUrl, int nTimeout = 60, Boolean bLog = true, Boolean bEnocode = false)
        {
            string strReq = string.Empty;
            string strRes = string.Empty;
            JObject jsonRes = null;
            try
            {
                GTF_CommManager comm = new GTF_CommManager(Constants.LOGGER_MAIN);
                strRes = comm.sendHttp_Json(Constants.SERVER_URL + strUrl, sendData, true, nTimeout, bLog, bEnocode);

                if (strRes == null || string.Empty.Equals(strRes.Trim()))
                {
                    jsonRes = null;
                }
                else
                {
                    jsonRes = JObject.Parse(strRes);
                }
            }
            catch (Exception e)
            {
                Constants.LOGGER_MAIN.Error(e.Message, e);
            }
            return jsonRes;
        }


    }
}
