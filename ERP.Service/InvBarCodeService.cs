using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using System.Data;
using ERP.Utility;
using EntityFramework.Extensions;
using System.Transactions;
using System.Data.Entity.Core.Objects;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Data.Entity;
using MoreLinq;
using System.Data.OleDb;

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
                invBarcodeDetailTemp = invBarcodeDetailTempList.Where(p => p.ProductCode == invBarcodeDetail.ProductCode && p.BatchNo == invBarcodeDetail.BatchNo).FirstOrDefault();
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

        public bool Save(List<InvBarcodeDetailTemp> invBarcodeDetailTemp, out string newDocumentNo, string formName = "")
        {
            
            {

                newDocumentNo = "001";
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
