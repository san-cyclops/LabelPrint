using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Domain;
using System.Data;
using ERP.Utility;
using System.Data.OleDb;
using System.Globalization;

namespace ERP.Service
{
    public class InvBarCodeService
    {
        string str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Database\Database.mdb;User Id=admin;Password=;";
         
        public List<InvBarcodeDetailTemp> getUpdateBarCodeDetailTemp(List<InvBarcodeDetailTemp> invBarcodeDetailTempList, InvBarcodeDetailTemp invBarcodeDetail)
        {
            InvBarcodeDetailTemp invBarcodeDetailTemp = new InvBarcodeDetailTemp();


            //invBarcodeDetailTemp = invBarcodeDetailTempList.Where(p => p.ProductID == invBarcodeDetail.ProductID && p.BatchNo == invBarcodeDetail.BatchNo).FirstOrDefault();

            if(invBarcodeDetailTempList != null)
            {
                invBarcodeDetailTemp = invBarcodeDetailTempList.Where(p => p.ProductCode == invBarcodeDetail.ProductCode && p.UnitOfMeasure == invBarcodeDetail.UnitOfMeasure && p.BatchNo == invBarcodeDetail.BatchNo).FirstOrDefault();
            }

             
            if (invBarcodeDetailTemp == null || invBarcodeDetailTemp.LineNo.Equals(0))
            {
                invBarcodeDetailTemp = invBarcodeDetail;
                if (invBarcodeDetailTempList == null)
                {invBarcodeDetailTemp.LineNo = 1;}
                else
                { invBarcodeDetailTemp.LineNo = invBarcodeDetailTempList.Max(s => s.LineNo) + 1;}
            }
            else
            {
                invBarcodeDetailTempList.Remove(invBarcodeDetailTemp);
                invBarcodeDetail.LineNo = invBarcodeDetailTemp.LineNo;
                invBarcodeDetail.Qty = invBarcodeDetailTemp.Qty + invBarcodeDetail.Qty; 
                invBarcodeDetailTemp = invBarcodeDetail;
            }
            if (invBarcodeDetailTempList == null)
            {
                invBarcodeDetailTempList = new List<InvBarcodeDetailTemp>();
            }
                invBarcodeDetailTempList.Add(invBarcodeDetailTemp);

            return invBarcodeDetailTempList.OrderBy(pd => pd.LineNo).ToList();
        }

        public List<InvBarcodeDetailTemp> getDeleteBarCodeDetailTemp(List<InvBarcodeDetailTemp> invBarcodeDetailTempList, InvBarcodeDetailTemp invBarcodeDetail)
        {
            InvBarcodeDetailTemp invBarcodeDetailTemp = new global::ERP.Domain.InvBarcodeDetailTemp();

            invBarcodeDetailTemp = invBarcodeDetailTempList.Where(p => p.ProductCode == invBarcodeDetail.ProductCode && p.BatchNo == invBarcodeDetail.BatchNo).FirstOrDefault();
            long removedLineNo = 0;
            if (invBarcodeDetailTemp != null)
            {
                invBarcodeDetailTempList.Remove(invBarcodeDetailTemp);
                removedLineNo = invBarcodeDetailTemp.LineNo;
            }


           // invBarcodeDetailTempList.ToList().Where(x => x.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);
            return invBarcodeDetailTempList.OrderBy(pd => pd.LineNo).ToList();
        }


        public string[] GetLabel()
        {
            using (OleDbConnection con = new OleDbConnection(str))
            {
                string statement = "SELECT COUNT(*) FROM [LableConfig]";
                OleDbCommand cmd = new OleDbCommand(statement, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                string command = "Select lablename from LableConfig";
                OleDbCommand cmdd = new OleDbCommand(command, con);
                OleDbDataReader dr;
                con.Open();
                //cmdd.ExecuteNonQuery();
                dr = cmdd.ExecuteReader();
                
                int x=0;
                string[] strList = new string[count];

                while (dr.Read())
                {
                    strList[x] = dr["lablename"].ToString();
                    x++; 
                } 
                con.Close();
                return strList;
            }
        }

        public string[] GetUnitOfMeasure()
        {
            using (OleDbConnection con = new OleDbConnection(str))
            {
                string statement = "SELECT COUNT(*) FROM [InvUnit]";
                OleDbCommand cmd = new OleDbCommand(statement, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                string command = "Select UnitOfMeasure from InvUnit";
                OleDbCommand cmdd = new OleDbCommand(command, con);
                OleDbDataReader dr;
                con.Open();
                //cmdd.ExecuteNonQuery();
                dr = cmdd.ExecuteReader();

                int x = 0;
                string[] strList = new string[count];

                while (dr.Read())
                {
                    strList[x] = dr["UnitOfMeasure"].ToString();
                    x++;
                }
                con.Close();
                return strList;
            }
        }

        public string GetDocumentNo()
        {
            using (OleDbConnection con = new OleDbConnection(str))
            {
                string statement = "SELECT DocumentNo FROM [InvBarCodeConfig]";
                OleDbCommand cmd = new OleDbCommand(statement, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar()+1;
                con.Close();
                string getNewCode = "LBL" + new StringBuilder().Insert(0, "0", 6 - (count.ToString().Length)) + count.ToString();
                return getNewCode;
            }
        }

        public void updateDocumentNo(string documentNo)
        {
            int x = Convert.ToInt32(documentNo.Substring(3, 6));
            using (OleDbConnection con = new OleDbConnection(str))
            {
                string command = "update InvBarCodeConfig set DocumentNo = " + x ;
                OleDbCommand cmdd = new OleDbCommand(command, con);
                con.Open();
                cmdd.ExecuteNonQuery();
                con.Close();
            }
        }

        public string[] GetDocumentNos()
        {
            using (OleDbConnection con = new OleDbConnection(str))
            {
                string statement = "SELECT Count(*) AS N FROM (SELECT DISTINCT DocumentNo FROM InvBarcode) AS T"; 
                OleDbCommand cmd = new OleDbCommand(statement, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                string command = "SELECT DocumentNo FROM InvBarcode GROUP BY DocumentNo ORDER BY DocumentNo desc";
                OleDbCommand cmdd = new OleDbCommand(command, con);
                OleDbDataReader dr;
                con.Open();
                //cmdd.ExecuteNonQuery();
                dr = cmdd.ExecuteReader();

                int x = 0;
                string[] strList = new string[count];   

                while (dr.Read())
                {
                    strList[x] = dr["DocumentNo"].ToString();
                    x++;
                }
                con.Close();
                return strList;
            }
        }

        public List<InvBarcodeDetailTemp> GetDocument(string DocNo)
        {
            try
            {
                List<InvBarcodeDetailTemp> invBarcodeDetailTemps = new List<InvBarcodeDetailTemp>();
                using (OleDbConnection con = new OleDbConnection(str))
                {
                    string command = @"SELECT DocumentNo, DocumentDate, LineNo, ProductCode, ProductName, BarCode,BatchNo, ExpiryDate, ManufDate, Qty, WholesalePrice, SellingPrice, UnitOfMeasure
                                    FROM InvBarcode where documentno = '" + DocNo + "'ORDER BY LineNo asc";
                    OleDbCommand cmdd = new OleDbCommand(command, con);
                    OleDbDataReader dr;
                    con.Open();
                    dr = cmdd.ExecuteReader();

                    CultureInfo provider = CultureInfo.InvariantCulture;

                    InvBarcodeDetailTemp invBarcodeDetailTemp = new InvBarcodeDetailTemp();
                    while (dr.Read())
                    {
                        invBarcodeDetailTemp = new InvBarcodeDetailTemp();
                        invBarcodeDetailTemp.DocumentNo = dr["DocumentNo"].ToString();
                        //    invBarcodeDetailTemp.DocumentDate = DateTime.ParseExact(dr["DocumentDate"].ToString(), "mm/dd/yyyy", provider);
                        invBarcodeDetailTemp.LineNo = Convert.ToInt64(dr["LineNo"].ToString());
                        invBarcodeDetailTemp.ProductCode = dr["ProductCode"].ToString();
                        invBarcodeDetailTemp.ProductName = dr["ProductName"].ToString();
                        invBarcodeDetailTemp.BarCode = dr["BarCode"].ToString();
                        invBarcodeDetailTemp.BatchNo = dr["BatchNo"].ToString();
                        invBarcodeDetailTemp.ExpiryDate = DateTime.Parse(dr["ExpiryDate"].ToString());
                        invBarcodeDetailTemp.ManufDate = DateTime.Parse(dr["ManufDate"].ToString());
                        invBarcodeDetailTemp.Qty = Convert.ToDecimal(dr["Qty"]);
                        invBarcodeDetailTemp.WholesalePrice = Convert.ToDecimal(dr["WholesalePrice"].ToString());
                        invBarcodeDetailTemp.SellingPrice = Convert.ToDecimal(dr["SellingPrice"].ToString());
                        invBarcodeDetailTemp.UnitOfMeasure = dr["UnitOfMeasure"].ToString();
                        invBarcodeDetailTemps.Add(invBarcodeDetailTemp);
                    }
                    con.Close();
                    return invBarcodeDetailTemps;
                }
            }
            catch (Exception ex)
            {
                return null;

            }
           
        }

        public bool Save(List<InvBarcodeDetailTemp> invBarcodeDetailTemp, string newDocumentNo, string formName = "")
        {
            
            {
                //newDocumentNo = "001";

                updateDocumentNo(newDocumentNo);


                string DocumentNo = newDocumentNo;

                invBarcodeDetailTemp.ForEach(se => se.DocumentNo = DocumentNo);

                var invBarcodeDetailSaveQuery = (from pd in invBarcodeDetailTemp select pd).ToList();

                //string mergeSql = CommonService.MergeSqlToForTrans(invBarcodeDetailSaveQuery.ToDataTable(), "invBarcode");
                //CommonService.BulkInsert(invBarcodeDetailSaveQuery.ToDataTable(), "invBarcode", mergeSql);
                //context.SaveChanges();



                using (OleDbConnection con = new OleDbConnection(str))
                { 
                    foreach (var obj in invBarcodeDetailTemp)
                    { 
                        string command = "insert into InvBarcode(InvBarcodeID,DocumentNo, DocumentDate, LineNo, ProductCode, ProductName, ExpiryDate, ManufDate, BatchNo, Qty, WholesalePrice, SellingPrice, UnitOfMeasure) values(0,'" + obj.DocumentNo + "','" + obj.DocumentDate + "','" + obj.LineNo + "','" + obj.ProductCode + "','" + obj.ProductName + "','" + obj.ExpiryDate + "','" + obj.ManufDate + "','" + obj.BatchNo + "','" + obj.Qty + "','" + obj.WholesalePrice + "','" + obj.SellingPrice + "','" + obj.UnitOfMeasure + "') ";
                        OleDbCommand cmdd = new OleDbCommand(command, con);
                        con.Open();
                        cmdd.ExecuteNonQuery();
                        con.Close();  
                    }
                }

    
                return true;
            }
        }


    }
}
