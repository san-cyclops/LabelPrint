﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Report.Inventory.Transactions.Reports {
    using System;
    using System.ComponentModel;
    using CrystalDecisions.Shared;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.CrystalReports.Engine;
    
    
    public class InvRptPurchaseOrderTemplateManjari : ReportClass {
        
        public InvRptPurchaseOrderTemplateManjari() {
        }
        
        public override string ResourceName {
            get {
                return "InvRptPurchaseOrderTemplateManjari.rpt";
            }
            set {
                // Do nothing
            }
        }
        
        public override bool NewGenerator {
            get {
                return true;
            }
            set {
                // Do nothing
            }
        }
        
        public override string FullResourceName {
            get {
                return "ERP.Report.Inventory.Transactions.Reports.InvRptPurchaseOrderTemplateManjari." +
                    "rpt";
            }
            set {
                // Do nothing
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section1 {
            get {
                return this.ReportDefinition.Sections[0];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section ReportHeaderSection3 {
            get {
                return this.ReportDefinition.Sections[1];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section ReportHeaderSection2 {
            get {
                return this.ReportDefinition.Sections[2];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section ReportHeaderSection1 {
            get {
                return this.ReportDefinition.Sections[3];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section ReportHeaderSection4 {
            get {
                return this.ReportDefinition.Sections[4];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section2 {
            get {
                return this.ReportDefinition.Sections[5];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section3 {
            get {
                return this.ReportDefinition.Sections[6];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section4 {
            get {
                return this.ReportDefinition.Sections[7];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.CrystalReports.Engine.Section Section5 {
            get {
                return this.ReportDefinition.Sections[8];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_prmSelectGroup1 {
            get {
                return this.DataDefinition.ParameterFields[0];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_prmSelectGroup2 {
            get {
                return this.DataDefinition.ParameterFields[1];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_prmSelectGroup3 {
            get {
                return this.DataDefinition.ParameterFields[2];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_SortChoice1 {
            get {
                return this.DataDefinition.ParameterFields[3];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_prmSelectGroup4 {
            get {
                return this.DataDefinition.ParameterFields[4];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_SortChoice2 {
            get {
                return this.DataDefinition.ParameterFields[5];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_SortChoice3 {
            get {
                return this.DataDefinition.ParameterFields[6];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_SortChoice4 {
            get {
                return this.DataDefinition.ParameterFields[7];
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public CrystalDecisions.Shared.IParameterField Parameter_prmDocumentNo {
            get {
                return this.DataDefinition.ParameterFields[8];
            }
        }
    }
    
    [System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
    public class CachedInvRptPurchaseOrderTemplateManjari : Component, ICachedReport {
        
        public CachedInvRptPurchaseOrderTemplateManjari() {
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable {
            get {
                return true;
            }
            set {
                // 
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool ShareDBLogonInfo {
            get {
                return false;
            }
            set {
                // 
            }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual System.TimeSpan CacheTimeOut {
            get {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set {
                // 
            }
        }
        
        public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CreateReport() {
            InvRptPurchaseOrderTemplateManjari rpt = new InvRptPurchaseOrderTemplateManjari();
            rpt.Site = this.Site;
            return rpt;
        }
        
        public virtual string GetCustomizedCacheKey(RequestContext request) {
            String key = null;
            // // The following is the code used to generate the default
            // // cache key for caching report jobs in the ASP.NET Cache.
            // // Feel free to modify this code to suit your needs.
            // // Returning key == null causes the default cache key to
            // // be generated.
            // 
            // key = RequestContext.BuildCompleteCacheKey(
            //     request,
            //     null,       // sReportFilename
            //     this.GetType(),
            //     this.ShareDBLogonInfo );
            return key;
        }
    }
}
