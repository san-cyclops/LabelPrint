using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using ERP.Report.Com;
using ERP.Report.CRM;
using ERP.Report.GV;
using ERP.Report.Inventory;
using ERP.Report.Logistic;
using ERP.Report.Restaurant;

namespace ERP.Report
{
    public class CommonReportGenerator
    {

        public void ViewReferenceDocumentOnGrid(AutoGenerateInfo autoGenerateInfo, string referenceDocumentNo)
        {
            try
            {
                switch (autoGenerateInfo.ModuleType)
                {
                    case 1: //Common Summary Report
                        ComReportGenerator comReportGenerator = new ComReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction
                                //accReportGenerator.GenerateTransactionReport(autoGenerateInfo, referenceDocumentNo, 2);

                                break;
                            default:
                                break;
                        }
                        break;
                    case 2: //Inventory Summary Report
                        InvReportGenerator invReportGenerator = new InvReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction
                                invReportGenerator.GenerateTransactionReport(autoGenerateInfo, referenceDocumentNo, 2);
                                break;
                            default:

                                break;
                        }
                        break;
                    case 3: //Logistic Summary Report
                        LgsReportGenerator lgsReportGenerator = new LgsReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction
                                lgsReportGenerator.GenearateTransactionReport(autoGenerateInfo, referenceDocumentNo, 2);

                                break;
                            default:
                                break;
                        }
                        break;
                    case 4: //CRM Summary Report
                        CrmReportGenerator crmReportGenerator = new CrmReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction
                                //crmReportGenerator.GenearateCrmReport(autoGenerateInfo, referenceDocumentNo, 2);

                                break;
                            default:

                                break;
                        }
                        break;
                    case 6: //Gift Voucher Summary Report
                        GvReportGenerator gvReportGenerator = new GvReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction
                                //gvReportGenerator.GenearateReferenceReport(autoGenerateInfo, referenceDocumentNo, 2);

                                break;
                            default:

                                break;
                        }
                        break;

                    case 15: //Restaurent management
                        ResReportGenerator resReportGenerator = new ResReportGenerator();
                        switch (autoGenerateInfo.ReportType)
                        {
                            case 1: // Reference

                                break;
                            case 2: // Transaction
                                //resReportGenerator.GenerateTransactionReport(autoGenerateInfo, referenceDocumentNo, 2);

                                break;
                            default:

                                break;
                        }
                        break;

                default:
                    break;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
