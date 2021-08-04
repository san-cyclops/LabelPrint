namespace ERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccAccountReconciliationDetail",
                c => new
                    {
                        AccAccountReconciliationDetailID = c.Long(nullable: false, identity: true),
                        AccountReconciliationDetailID = c.Long(nullable: false),
                        AccAccountReconciliationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        OpeningAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClosingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReconciled = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        LineNo = c.Int(nullable: false),
                        AccGlTransactionDetailID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccAccountReconciliationDetailID)
                .ForeignKey("dbo.AccAccountReconciliationHeader", t => t.AccAccountReconciliationHeaderID, cascadeDelete: true)
                .Index(t => t.AccAccountReconciliationHeaderID);
            
            CreateTable(
                "dbo.AccAccountReconciliationHeader",
                c => new
                    {
                        AccAccountReconciliationHeaderID = c.Long(nullable: false, identity: true),
                        AccountReconciliationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        ReconcileDate = c.DateTime(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        AccLedgerAccountID = c.Long(nullable: false),
                        OpeningAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StatementClosingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClosingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepositAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WithdrawalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnrealizedChqeueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnpresentedChqeueAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepositCount = c.Int(nullable: false),
                        WithdrawalCount = c.Int(nullable: false),
                        UnrealizedChqeueCount = c.Int(nullable: false),
                        UnpresentedChqeueCount = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 25),
                        ManualNo = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccAccountReconciliationHeaderID);
            
            CreateTable(
                "dbo.AccBankDepositDetail",
                c => new
                    {
                        AccBankDepositDetailID = c.Long(nullable: false, identity: true),
                        BankDepositDetailID = c.Long(nullable: false),
                        AccBankdepositheaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        LineNo = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccBankDepositDetailID)
                .ForeignKey("dbo.AccBankDepositHeader", t => t.AccBankdepositheaderID, cascadeDelete: true)
                .Index(t => t.AccBankdepositheaderID);
            
            CreateTable(
                "dbo.AccBankDepositHeader",
                c => new
                    {
                        AccBankdepositheaderID = c.Long(nullable: false, identity: true),
                        BankdepositheaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        AccBankAccountID = c.Long(nullable: false),
                        AccCashAccountID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        BankDepositMode = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccBankdepositheaderID);
            
            CreateTable(
                "dbo.AccBillEntryDetail",
                c => new
                    {
                        AccBillEntryDetailID = c.Long(nullable: false, identity: true),
                        BillEntryDetailID = c.Long(nullable: false),
                        AccBillEntryHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        AllocatedCostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        HeaderLedgerID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Narration = c.String(maxLength: 150),
                        ScanDocument = c.Binary(),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccBillEntryDetailID)
                .ForeignKey("dbo.AccBillEntryHeader", t => t.AccBillEntryHeaderID, cascadeDelete: true)
                .Index(t => t.AccBillEntryHeaderID);
            
            CreateTable(
                "dbo.AccBillEntryHeader",
                c => new
                    {
                        AccBillEntryHeaderID = c.Long(nullable: false, identity: true),
                        BillEntryHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                        BillDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        LedgerID = c.Long(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 25),
                        ManualNo = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccBillEntryHeaderID);
            
            CreateTable(
                "dbo.AccBudgetDetail",
                c => new
                    {
                        AccBudgetDetailID = c.Int(nullable: false, identity: true),
                        BudgetDescription = c.String(nullable: false, maxLength: 15),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        FinancialYear = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        BudgetPeriod = c.Int(nullable: false),
                        BudgetAmountPeriod1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod11 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetAmountPeriod12 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBudgetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccBudgetDetailID);
            
            CreateTable(
                "dbo.AccCardCommission",
                c => new
                    {
                        AccCardCommissionID = c.Int(nullable: false, identity: true),
                        BankLedgerID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccCardCommissionID);
            
            CreateTable(
                "dbo.AccChequeCancelHeader",
                c => new
                    {
                        AccChequeCancelHeaderID = c.Long(nullable: false, identity: true),
                        ChequeCancelHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        ChequeNo = c.String(maxLength: 15),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccChequeCancelHeaderID);
            
            CreateTable(
                "dbo.AccChequeCancelDetail",
                c => new
                    {
                        AccChequeCancelDetailID = c.Long(nullable: false, identity: true),
                        ChequeCancelDetailID = c.Long(nullable: false),
                        AccChequeCancelHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccChequeCancelDetailID)
                .ForeignKey("dbo.AccChequeCancelHeader", t => t.AccChequeCancelHeaderID, cascadeDelete: true)
                .Index(t => t.AccChequeCancelHeaderID);
            
            CreateTable(
                "dbo.AccChequeDetail",
                c => new
                    {
                        AccChequeDetailID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        BankID = c.Int(nullable: false),
                        BankBranchID = c.Int(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        PayeeName = c.String(maxLength: 50),
                        ChequeNo = c.String(maxLength: 15),
                        DepositedBankID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeType = c.Int(nullable: false),
                        ChequeStatus = c.Int(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        LineNo = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccChequeDetailID);
            
            CreateTable(
                "dbo.AccChequeNoEntry",
                c => new
                    {
                        AccChequeNoEntryID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        AccLedgerAccountID = c.Long(nullable: false),
                        ChequeStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccChequeNoEntryID);
            
            CreateTable(
                "dbo.AccChequeReturnHeader",
                c => new
                    {
                        AccChequeReturnHeaderID = c.Long(nullable: false, identity: true),
                        ChequeReturnHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        ChequeNo = c.String(maxLength: 15),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccChequeReturnHeaderID);
            
            CreateTable(
                "dbo.AccChequeReturnDetail",
                c => new
                    {
                        AccChequeReturnDetailID = c.Long(nullable: false, identity: true),
                        ChequeReturnDetailID = c.Long(nullable: false),
                        AccChequeReturnHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccChequeReturnDetailID)
                .ForeignKey("dbo.AccChequeReturnHeader", t => t.AccChequeReturnHeaderID, cascadeDelete: true)
                .Index(t => t.AccChequeReturnHeaderID);
            
            CreateTable(
                "dbo.AccCreditNoteDetail",
                c => new
                    {
                        AccCreditNoteDetailID = c.Long(nullable: false, identity: true),
                        CreditNoteDetailID = c.Long(nullable: false),
                        AccCreditNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccCreditNoteDetailID)
                .ForeignKey("dbo.AccCreditNoteHeader", t => t.AccCreditNoteHeaderID, cascadeDelete: true)
                .Index(t => t.AccCreditNoteHeaderID);
            
            CreateTable(
                "dbo.AccCreditNoteHeader",
                c => new
                    {
                        AccCreditNoteHeaderID = c.Long(nullable: false, identity: true),
                        CreditNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 20),
                        ManualNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccCreditNoteHeaderID);
            
            CreateTable(
                "dbo.AccDebitNoteDetail",
                c => new
                    {
                        AccDebitNoteDetailID = c.Long(nullable: false, identity: true),
                        DebitNoteDetailID = c.Long(nullable: false),
                        AccDebitNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        ReferenceID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccDebitNoteDetailID)
                .ForeignKey("dbo.AccDebitNoteHeader", t => t.AccDebitNoteHeaderID, cascadeDelete: true)
                .Index(t => t.AccDebitNoteHeaderID);
            
            CreateTable(
                "dbo.AccDebitNoteHeader",
                c => new
                    {
                        AccDebitNoteHeaderID = c.Long(nullable: false, identity: true),
                        DebitNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 20),
                        ManualNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccDebitNoteHeaderID);
            
            CreateTable(
                "dbo.AccGlTransactionDetail",
                c => new
                    {
                        AccGlTransactionDetailID = c.Long(nullable: false, identity: true),
                        GlTransactionDetailID = c.Long(nullable: false),
                        AccGlTransactionHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        LedgerSerial = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceCardTypeID = c.Long(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionTypeId = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 25),
                        AccTransactionDefinitionID = c.Int(nullable: false),
                        ChequeNo = c.String(maxLength: 15),
                        ReferenceNo = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        IsReconciled = c.Boolean(nullable: false),
                        TempReconciledStatus = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccGlTransactionDetailID)
                .ForeignKey("dbo.AccGlTransactionHeader", t => t.AccGlTransactionHeaderID, cascadeDelete: true)
                .Index(t => t.AccGlTransactionHeaderID);
            
            CreateTable(
                "dbo.AccGlTransactionHeader",
                c => new
                    {
                        AccGlTransactionHeaderID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        ReferenceCardTypeID = c.Long(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 25),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccGlTransactionHeaderID);
            
            CreateTable(
                "dbo.AccGlTransactionDetailTemp",
                c => new
                    {
                        AccGlTransactionDetailTempID = c.Long(nullable: false, identity: true),
                        GlTransactionDetailTempID = c.Long(nullable: false),
                        AccGlTransactionDetailID = c.Long(nullable: false),
                        GlTransactionDetailID = c.Long(nullable: false),
                        AccGlTransactionHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        LedgerSerial = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceCardTypeID = c.Long(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionTypeId = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 25),
                        ChequeNo = c.String(maxLength: 15),
                        ReferenceNo = c.String(maxLength: 50),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        IsReconciled = c.Boolean(nullable: false),
                        TempReconciledStatus = c.Boolean(nullable: false),
                        AccTransactionDefinitionId = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccGlTransactionDetailTempID);
            
            CreateTable(
                "dbo.AccJournalEntryDetail",
                c => new
                    {
                        AccJournalEntryDetailID = c.Long(nullable: false, identity: true),
                        JournalEntryDetailID = c.Long(nullable: false),
                        AccJournalEntryHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        Remark = c.String(maxLength: 150),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductImage = c.Binary(),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccJournalEntryDetailID)
                .ForeignKey("dbo.AccJournalEntryHeader", t => t.AccJournalEntryHeaderID, cascadeDelete: true)
                .Index(t => t.AccJournalEntryHeaderID);
            
            CreateTable(
                "dbo.AccJournalEntryHeader",
                c => new
                    {
                        AccJournalEntryHeaderID = c.Long(nullable: false, identity: true),
                        JournalEntryHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        ManualNo = c.String(maxLength: 25),
                        ReferenceID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        ScanDocument = c.Binary(),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccJournalEntryHeaderID);
            
            CreateTable(
                "dbo.AccLedgerAccount",
                c => new
                    {
                        AccLedgerAccountID = c.Long(nullable: false, identity: true),
                        LedgerType = c.String(nullable: false),
                        TypeLevel = c.Int(nullable: false),
                        ParentIndex = c.Int(nullable: false),
                        LedgerCode = c.String(nullable: false, maxLength: 200),
                        LedgerName = c.String(nullable: false, maxLength: 100),
                        BankID = c.Int(nullable: false),
                        BankBranchID = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        AccountStatus = c.Int(nullable: false),
                        StandardDrCr = c.Int(nullable: false),
                        StatementType = c.Int(nullable: false),
                        IsLock = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        AccountNo = c.String(maxLength: 50),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccLedgerAccountID);
            
            CreateTable(
                "dbo.AccLedgerSerialNumber",
                c => new
                    {
                        AccLedgerSerialNumberID = c.Long(nullable: false, identity: true),
                        DocumentID = c.Int(nullable: false),
                        DocumentName = c.String(),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        DocumentNo = c.Long(nullable: false),
                        TempDocumentNo = c.Long(nullable: false),
                        financialBeginDate = c.DateTime(nullable: false),
                        financialEndingDate = c.DateTime(nullable: false),
                        PrefixCode = c.String(),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccLedgerSerialNumberID);
            
            CreateTable(
                "dbo.AccLoanEntryDetail",
                c => new
                    {
                        AccLoanEntryDetailID = c.Long(nullable: false, identity: true),
                        LoanEntryDetailID = c.Long(nullable: false),
                        AccLoanEntryHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        RentalNo = c.Int(nullable: false),
                        RentalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CapitalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InterestAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccLoanEntryDetailID);
            
            CreateTable(
                "dbo.AccLoanEntryHeader",
                c => new
                    {
                        AccLoanEntryHeaderID = c.Long(nullable: false, identity: true),
                        LoanEntryHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AssetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DownPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BeginMonthDownPayment = c.Int(nullable: false),
                        EndMonthDownPayment = c.Int(nullable: false),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethodID = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 25),
                        ManualNo = c.String(maxLength: 25),
                        FinanceInstituteID = c.Int(nullable: false),
                        LoanTypeID = c.Int(nullable: false),
                        LoanPurposeID = c.Int(nullable: false),
                        LoanTermID = c.Int(nullable: false),
                        LoanPeriod = c.Int(nullable: false),
                        NoOfPaymentsPerYr = c.Int(nullable: false),
                        OptionalExtraPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GracePeriod = c.Int(nullable: false),
                        MonthlyGracePeriod = c.Int(nullable: false),
                        StartingLoanDate = c.DateTime(nullable: false),
                        Remark = c.String(maxLength: 150),
                        IsSendEmail = c.Boolean(nullable: false),
                        EmailAddress = c.String(maxLength: 150),
                        IsSendSms = c.Boolean(nullable: false),
                        TelephoneNo = c.String(maxLength: 50),
                        IsUserPopups = c.Boolean(nullable: false),
                        NotifyBeforeNoOfDays = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsMortgageLoan = c.Boolean(nullable: false),
                        MortgageDate = c.DateTime(nullable: false),
                        MortgageInterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MortgageNo = c.String(maxLength: 25),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccLoanEntryHeaderID);
            
            CreateTable(
                "dbo.AccOpenningBalanceDetail",
                c => new
                    {
                        AccOpenningBalanceDetailID = c.Long(nullable: false, identity: true),
                        OpenningBalanceDetailID = c.Long(nullable: false),
                        AccOpenningBalanceHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        LineNo = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccOpenningBalanceDetailID)
                .ForeignKey("dbo.AccOpenningBalanceHeader", t => t.AccOpenningBalanceHeaderID, cascadeDelete: true)
                .Index(t => t.AccOpenningBalanceHeaderID);
            
            CreateTable(
                "dbo.AccOpenningBalanceHeader",
                c => new
                    {
                        AccOpenningBalanceHeaderID = c.Long(nullable: false, identity: true),
                        OpenningBalanceHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccOpenningBalanceHeaderID);
            
            CreateTable(
                "dbo.AccPaymentDetail",
                c => new
                    {
                        AccPaymentDetailID = c.Long(nullable: false, identity: true),
                        PaymentDetailID = c.Long(nullable: false),
                        AccPaymentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 25),
                        SetoffDocumentID = c.Long(nullable: false),
                        SetoffDocumentDocumentID = c.Int(nullable: false),
                        SetoffLocationID = c.Int(nullable: false),
                        SetoffDocumentNo = c.String(maxLength: 25),
                        ReferenceCardTypeID = c.Long(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethodID = c.Int(nullable: false),
                        ReferenceLedgerID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        BankID = c.Long(nullable: false),
                        BankBranchID = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        CardNo = c.String(maxLength: 15),
                        ChequeDate = c.DateTime(),
                        IsOverPaid = c.Boolean(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        DepositStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPaymentDetailID);
            
            CreateTable(
                "dbo.AccPaymentHeader",
                c => new
                    {
                        AccPaymentHeaderID = c.Long(nullable: false, identity: true),
                        PaymentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceLedgerID = c.Long(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        SalesPersonID = c.Long(nullable: false),
                        CollectorName = c.String(maxLength: 100),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdvanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 50),
                        ManualNo = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        DocumentType = c.Int(nullable: false),
                        AdvancePaymentStatus = c.Int(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPaymentHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashBillDetail",
                c => new
                    {
                        AccPettyCashBillDetailID = c.Long(nullable: false, identity: true),
                        PettyCashBillDetailID = c.Long(nullable: false),
                        AccPettyCashBillHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        ScanDocument = c.Binary(),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashBillDetailID)
                .ForeignKey("dbo.AccPettyCashBillHeader", t => t.AccPettyCashBillHeaderID)
                .Index(t => t.AccPettyCashBillHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashBillHeader",
                c => new
                    {
                        AccPettyCashBillHeaderID = c.Long(nullable: false, identity: true),
                        PettyCashBillHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        PettyCashLedgerID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        PayeeName = c.String(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IOUAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReturnedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToSettleAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashBillHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashImprestDetail",
                c => new
                    {
                        AccPettyCashImprestDetailID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        PettyCashLedgerID = c.Long(nullable: false),
                        ImprestAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssuedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailabledAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashImprestDetailID);
            
            CreateTable(
                "dbo.AccPettyCashIOUDetail",
                c => new
                    {
                        AccPettyCashIOUDetailID = c.Long(nullable: false, identity: true),
                        PettyCashIOUDetailID = c.Long(nullable: false),
                        AccPettyCashIOUHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        AccLedgerAccountID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashIOUDetailID)
                .ForeignKey("dbo.AccPettyCashIOUHeader", t => t.AccPettyCashIOUHeaderID, cascadeDelete: true)
                .Index(t => t.AccPettyCashIOUHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashIOUHeader",
                c => new
                    {
                        AccPettyCashIOUHeaderID = c.Long(nullable: false, identity: true),
                        PettyCashIOUHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        PettyCashLedgerID = c.Long(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        PayeeName = c.String(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IOUStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashIOUHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashMaster",
                c => new
                    {
                        AccPettyCashMasterID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashMasterID);
            
            CreateTable(
                "dbo.AccPettyCashPaymentDetail",
                c => new
                    {
                        AccPettyCashPaymentDetailID = c.Long(nullable: false, identity: true),
                        PettyCashPaymentDetailID = c.Long(nullable: false),
                        AccPettyCashPaymentHeaderID = c.Long(nullable: false),
                        PettyCashPaymentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 25),
                        SetoffDocumentID = c.Long(nullable: false),
                        SetoffDocumentDocumentID = c.Int(nullable: false),
                        SetoffLocationID = c.Int(nullable: false),
                        SetoffDocumentNo = c.String(maxLength: 25),
                        LedgerID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentModeID = c.Int(nullable: false),
                        BankID = c.Int(nullable: false),
                        BankBranchID = c.Int(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        ChequeDate = c.DateTime(),
                        PaymentStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashPaymentDetailID)
                .ForeignKey("dbo.AccPettyCashPaymentHeader", t => t.AccPettyCashPaymentHeaderID, cascadeDelete: true)
                .Index(t => t.AccPettyCashPaymentHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashPaymentHeader",
                c => new
                    {
                        AccPettyCashPaymentHeaderID = c.Long(nullable: false, identity: true),
                        PettyCashPaymentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        PettyCashLedgerID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        PayeeName = c.String(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        PaymentStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashPaymentHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashPaymentProcessDetail",
                c => new
                    {
                        AccPettyCashPaymentProcessDetailID = c.Long(nullable: false, identity: true),
                        PettyCashPaymentProcessDetailID = c.Long(nullable: false),
                        AccPettyCashPaymentProcessHeaderID = c.Long(nullable: false),
                        PettyCashPaymentProcessHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        SetoffDocumentID = c.Long(nullable: false),
                        SetoffDocumentDocumentID = c.Int(nullable: false),
                        SetoffLocationID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashPaymentProcessDetailID)
                .ForeignKey("dbo.AccPettyCashPaymentProcessHeader", t => t.AccPettyCashPaymentProcessHeaderID, cascadeDelete: true)
                .Index(t => t.AccPettyCashPaymentProcessHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashPaymentProcessHeader",
                c => new
                    {
                        AccPettyCashPaymentProcessHeaderID = c.Long(nullable: false, identity: true),
                        PettyCashPaymentProcessHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        PettyCashLedgerID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        PaymentStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashPaymentProcessHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashReimbursement",
                c => new
                    {
                        AccPettyCashReimbursementID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        EmployeeID = c.Long(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        PayeeName = c.String(nullable: false),
                        PettyCashLedgerID = c.Long(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        ChequeNo = c.String(),
                        ReimburseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImprestAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssuedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailabledAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UsedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookBalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashReimbursementID);
            
            CreateTable(
                "dbo.AccPettyCashVoucherDetail",
                c => new
                    {
                        AccPettyCashVoucherDetailID = c.Long(nullable: false, identity: true),
                        PettyCashVoucherDetailID = c.Long(nullable: false),
                        AccPettyCashVoucherHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        SetoffDocumentID = c.Long(nullable: false),
                        SetoffDocumentDocumentID = c.Int(nullable: false),
                        SetoffLocationID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentModeID = c.Int(nullable: false),
                        BankID = c.Int(nullable: false),
                        BankBranchID = c.Int(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        ChequeDate = c.DateTime(),
                        VoucherStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashVoucherDetailID)
                .ForeignKey("dbo.AccPettyCashVoucherHeader", t => t.AccPettyCashVoucherHeaderID)
                .Index(t => t.AccPettyCashVoucherHeaderID);
            
            CreateTable(
                "dbo.AccPettyCashVoucherHeader",
                c => new
                    {
                        AccPettyCashVoucherHeaderID = c.Long(nullable: false, identity: true),
                        PettyCashVoucherHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        LedgerSerialNo = c.String(maxLength: 25),
                        PettyCashLedgerID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        PayeeName = c.String(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IOUAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Reference = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        VoucherStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccPettyCashVoucherHeaderID);
            
            CreateTable(
                "dbo.AccSalesDownload",
                c => new
                    {
                        AccSalesDownloadID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        RefeReferenceID = c.Long(nullable: false),
                        SalesTypeDescription = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AccSalesDownloadID);
            
            CreateTable(
                "dbo.AccSalesDownloadSetting",
                c => new
                    {
                        AccSalesDownloadSettingID = c.Long(nullable: false, identity: true),
                        ReferenceTypeID = c.Long(nullable: false),
                        SalesTypeDescription = c.String(maxLength: 50),
                        DebitLedgerAccountID = c.Long(nullable: false),
                        CreditLedgerAccountID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LocationID = c.Int(nullable: false),
                        LineNo = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccSalesDownloadSettingID);
            
            CreateTable(
                "dbo.AccSalesType",
                c => new
                    {
                        AccSalesTypeID = c.Long(nullable: false, identity: true),
                        ReferenceTypeID = c.Long(nullable: false),
                        SalesTypeDescription = c.String(maxLength: 50),
                        DebitLedgerAccountID = c.Long(nullable: false),
                        CreditLedgerAccountID = c.Long(nullable: false),
                        PaymentTypeID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccSalesTypeID);
            
            CreateTable(
                "dbo.AccThirdPartyDownload",
                c => new
                    {
                        AccThirdPartyDownloadID = c.Long(nullable: false, identity: true),
                        Idx = c.Int(nullable: false),
                        DocType = c.String(),
                        SerialNo = c.String(),
                        RefNo = c.String(),
                        LocationID = c.Int(nullable: false),
                        LocaCode = c.String(),
                        ReferenceID = c.Long(nullable: false),
                        AcCode = c.String(),
                        AcDate = c.DateTime(nullable: false),
                        GAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrMode = c.Int(nullable: false),
                        PayMode = c.Int(nullable: false),
                        IdCode = c.String(),
                        Status = c.Int(nullable: false),
                        BankId = c.Int(nullable: false),
                        ChequeNo = c.String(),
                        ChequeDate = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                        DataDownStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccThirdPartyDownloadID);
            
            CreateTable(
                "dbo.AccTransactionDefinition",
                c => new
                    {
                        AccTransactionDefinitionID = c.Int(nullable: false, identity: true),
                        TransactionDefinitionCode = c.Int(nullable: false),
                        TransactionDefinitionName = c.String(nullable: false, maxLength: 100),
                        IsMultiple = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccTransactionDefinitionID);
            
            CreateTable(
                "dbo.AccTransactionTemplateDetail",
                c => new
                    {
                        AccTransactionTemplateDetailID = c.Long(nullable: false, identity: true),
                        TransactionTemplateDetailID = c.Long(nullable: false),
                        AccTransactionTemplateHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceLocationID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 25),
                        SetoffDocumentID = c.Long(nullable: false),
                        SetoffDocumentDocumentID = c.Int(nullable: false),
                        SetoffLocationID = c.Int(nullable: false),
                        SetoffDocumentNo = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        ScanDocument = c.Binary(),
                        ReferenceLedgerID = c.Long(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        BankID = c.Long(nullable: false),
                        BankBranchID = c.Int(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        ChequeDate = c.DateTime(),
                        IsOverPaid = c.Boolean(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        ReferenceID = c.Long(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        DrCr = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccTransactionTemplateDetailID)
                .ForeignKey("dbo.AccTransactionTemplateHeader", t => t.AccTransactionTemplateHeaderID, cascadeDelete: true)
                .Index(t => t.AccTransactionTemplateHeaderID);
            
            CreateTable(
                "dbo.AccTransactionTemplateHeader",
                c => new
                    {
                        AccTransactionTemplateHeaderID = c.Long(nullable: false, identity: true),
                        TransactionTemplateHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        JobClassID = c.Long(nullable: false),
                        TemplateName = c.String(maxLength: 50),
                        LedgerSerialNo = c.String(maxLength: 25),
                        ManualNo = c.String(maxLength: 25),
                        ReferenceID = c.Long(nullable: false),
                        ReferenceLedgerID = c.Long(nullable: false),
                        SalesPersonID = c.Long(nullable: false),
                        ReferenceCardTypeID = c.Int(nullable: false),
                        CollectorName = c.String(maxLength: 50),
                        BalanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdvanceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentType = c.Int(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        ScanDocument = c.Binary(),
                        IsUpLoad = c.Boolean(nullable: false),
                        IsRecurringEntry = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccTransactionTemplateHeaderID);
            
            CreateTable(
                "dbo.AccTransactionTypeDetail",
                c => new
                    {
                        AccTransactionTypeDetailID = c.Long(nullable: false, identity: true),
                        TransactionTypeDetailID = c.Long(nullable: false),
                        AccTransactionTypeHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        AccTransactionDefinitionID = c.Int(nullable: false),
                        TransactionModeID = c.Int(nullable: false),
                        DrCr = c.Int(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        LedgerPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDefault = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccTransactionTypeDetailID);
            
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaID = c.Long(nullable: false, identity: true),
                        AreaCode = c.String(nullable: false, maxLength: 15),
                        AreaName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Long(nullable: false, identity: true),
                        CustomerCode = c.String(nullable: false, maxLength: 15),
                        CustomerTitle = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        CustomerType = c.Int(nullable: false),
                        ContactPersonName = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        BillingAddress1 = c.String(maxLength: 50),
                        BillingAddress2 = c.String(maxLength: 50),
                        BillingAddress3 = c.String(maxLength: 50),
                        BillingTelephone = c.String(),
                        BillingMobile = c.String(),
                        BillingFax = c.String(),
                        Email = c.String(),
                        RepresentativeName = c.String(maxLength: 100),
                        RepresentativeNICNo = c.String(maxLength: 50),
                        NICNo = c.String(maxLength: 50),
                        RepresentativeMobileNo = c.String(),
                        DeliveryAddress1 = c.String(maxLength: 50),
                        DeliveryAddress2 = c.String(maxLength: 50),
                        DeliveryAddress3 = c.String(maxLength: 50),
                        DeliveryTelephone = c.String(),
                        DeliveryMobile = c.String(),
                        DeliveryFax = c.String(),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TemporaryLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Outstanding = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceNo = c.String(),
                        BankDraft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerImage = c.Binary(),
                        MaximumCashDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumCreditDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequePeriod = c.Int(nullable: false),
                        PaymentTermID = c.Int(nullable: false),
                        CreditPeriod = c.Int(nullable: false),
                        TaxID1 = c.Int(nullable: false),
                        TaxNo1 = c.String(maxLength: 25),
                        TaxID2 = c.Int(nullable: false),
                        TaxNo2 = c.String(maxLength: 25),
                        TaxID3 = c.Int(nullable: false),
                        TaxNo3 = c.String(maxLength: 25),
                        TaxID4 = c.Int(nullable: false),
                        TaxNo4 = c.String(maxLength: 25),
                        TaxID5 = c.Int(nullable: false),
                        TaxNo5 = c.String(maxLength: 25),
                        Remark = c.String(maxLength: 150),
                        IsFixedDiscount = c.Boolean(nullable: false),
                        IsSuspended = c.Boolean(nullable: false),
                        IsBlackListed = c.Boolean(nullable: false),
                        IsLoyalty = c.Boolean(nullable: false),
                        IsCreditAllowed = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        BrokerID = c.Long(nullable: false),
                        CustomerGroupID = c.Int(nullable: false),
                        AreaID = c.Long(nullable: false),
                        TerritoryID = c.Long(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        OtherLedgerID = c.Long(nullable: false),
                        IsUpload = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Area", t => t.AreaID)
                .ForeignKey("dbo.CustomerGroup", t => t.CustomerGroupID)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethodID)
                .ForeignKey("dbo.Territory", t => t.TerritoryID)
                .Index(t => t.AreaID)
                .Index(t => t.CustomerGroupID)
                .Index(t => t.PaymentMethodID)
                .Index(t => t.TerritoryID);
            
            CreateTable(
                "dbo.CustomerGroup",
                c => new
                    {
                        CustomerGroupID = c.Int(nullable: false, identity: true),
                        CustomerGroupCode = c.String(nullable: false, maxLength: 20),
                        CustomerGroupName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerGroupID);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false, identity: true),
                        PaymentMethodCode = c.String(maxLength: 15),
                        PaymentMethodName = c.String(maxLength: 50),
                        CommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentType = c.Int(nullable: false),
                        IsPaymentType = c.Boolean(nullable: false),
                        IsReceiptType = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.Territory",
                c => new
                    {
                        TerritoryID = c.Long(nullable: false, identity: true),
                        AreaID = c.Long(nullable: false),
                        TerritoryCode = c.String(nullable: false, maxLength: 15),
                        TerritoryName = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerritoryID)
                .ForeignKey("dbo.Area", t => t.AreaID)
                .Index(t => t.AreaID);
            
            CreateTable(
                "dbo.AutoGenerateInfo",
                c => new
                    {
                        AutoGenerateInfoID = c.Long(nullable: false, identity: true),
                        ModuleType = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        FormId = c.Int(nullable: false),
                        FormName = c.String(nullable: false, maxLength: 50),
                        FormText = c.String(nullable: false, maxLength: 100),
                        Prefix = c.String(maxLength: 3),
                        Prefix2 = c.String(maxLength: 3),
                        CodeLength = c.Int(nullable: false),
                        Suffix = c.Int(nullable: false),
                        AutoGenerete = c.Boolean(nullable: false),
                        AutoClear = c.Boolean(nullable: false),
                        IsDepend = c.Boolean(nullable: false),
                        IsDependCode = c.Boolean(nullable: false),
                        IsSupplierProduct = c.Boolean(nullable: false),
                        IsOverWriteQty = c.Boolean(nullable: false),
                        IsLocationCode = c.Boolean(nullable: false),
                        ReportPrefix = c.String(maxLength: 3),
                        ReportType = c.Int(nullable: false),
                        PoIsMandatory = c.Boolean(nullable: false),
                        IsDispatchRecall = c.Boolean(nullable: false),
                        IsBackDated = c.Boolean(nullable: false),
                        IsCard = c.Boolean(nullable: false),
                        CardId = c.Int(nullable: false),
                        IsEntry = c.Boolean(nullable: false),
                        IsSlabReport = c.Boolean(nullable: false),
                        IsConsignment = c.Boolean(nullable: false),
                        IsRoundOff = c.Boolean(nullable: false),
                        IsAutoComplete = c.Boolean(nullable: false),
                        IsUpdateProductImage = c.Boolean(nullable: false),
                        IsAllowedInHO = c.Boolean(nullable: false),
                        IsAllowedInOutlet = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AutoGenerateInfoID);
            
            CreateTable(
                "dbo.BankBin",
                c => new
                    {
                        BankBinID = c.Long(nullable: false, identity: true),
                        CardPfx = c.String(maxLength: 10),
                        CardName = c.String(maxLength: 75),
                        CardType = c.String(maxLength: 75),
                        CardID = c.Long(nullable: false),
                        BankID = c.Long(nullable: false),
                        BankName = c.String(maxLength: 20),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ValueFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValueTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsValidForGVSales = c.Boolean(nullable: false),
                        IsCombined = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankBinID);
            
            CreateTable(
                "dbo.BankBranch",
                c => new
                    {
                        BankBranchID = c.Int(nullable: false, identity: true),
                        BankID = c.Int(nullable: false),
                        BankBranchCode = c.String(nullable: false, maxLength: 15),
                        BranchName = c.String(nullable: false, maxLength: 100),
                        Address1 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Telephone = c.String(),
                        Fax = c.String(),
                        Mobile = c.String(),
                        FaxNo = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankBranchID);
            
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        BankID = c.Int(nullable: false, identity: true),
                        BankCode = c.String(nullable: false, maxLength: 15),
                        BankName = c.String(nullable: false, maxLength: 100),
                        BanK = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(maxLength: 150),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTerminal = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankID);
            
            CreateTable(
                "dbo.BankPos",
                c => new
                    {
                        BankPosID = c.Long(nullable: false, identity: true),
                        BankID = c.Long(nullable: false),
                        Bank = c.String(nullable: false, maxLength: 20),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTerminal = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankPosID);
            
            CreateTable(
                "dbo.BillingLocationAssignedCostCentre",
                c => new
                    {
                        BillingLocationAssignedCostCentreID = c.Int(nullable: false, identity: true),
                        BillingLocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        Select = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillingLocationAssignedCostCentreID);
            
            CreateTable(
                "dbo.BillingLocation",
                c => new
                    {
                        BillingLocationID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationCode = c.String(nullable: false, maxLength: 15),
                        LocationName = c.String(nullable: false, maxLength: 50),
                        Address1 = c.String(nullable: false, maxLength: 50),
                        Address2 = c.String(nullable: false, maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        FaxNo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        ContactPersonName = c.String(maxLength: 100),
                        OtherBusinessName = c.String(maxLength: 100),
                        LocationPrefixCode = c.String(maxLength: 3),
                        TypeOfBusiness = c.String(maxLength: 50),
                        CostingMethod = c.String(maxLength: 50),
                        CostCentreID = c.Int(nullable: false),
                        IsVat = c.Boolean(nullable: false),
                        IsStockLocation = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsHeadOffice = c.Boolean(nullable: false),
                        UploadPath = c.String(),
                        DownloadPath = c.String(),
                        LocalUploadPath = c.String(),
                        BackupPath = c.String(),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceChargeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        LocationIP = c.String(maxLength: 50),
                        IsShowRoom = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillingLocationID);
            
            CreateTable(
                "dbo.Broker",
                c => new
                    {
                        BrokerID = c.Long(nullable: false, identity: true),
                        BrokerCode = c.String(nullable: false, maxLength: 25),
                        BrokerName = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrokerID);
            
            CreateTable(
                "dbo.LoyaltyCardAllocationLog",
                c => new
                    {
                        LoyaltyCardAllocationLogID = c.Int(nullable: false, identity: true),
                        LoyaltyCardAllocationID = c.Int(nullable: false),
                        CardTypeId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        SerialNo = c.String(maxLength: 150),
                        CardNo = c.String(maxLength: 150),
                        EncodeNo = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardAllocationLogID);
            
            CreateTable(
                "dbo.CardGenerationLocationSetting",
                c => new
                    {
                        CardGenerationLocationSettingID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CardNoLength = c.Int(nullable: false),
                        CardStartingNo = c.Long(nullable: false),
                        EncodeStartingNo = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardGenerationLocationSettingID);
            
            CreateTable(
                "dbo.CardGenerationSetting",
                c => new
                    {
                        CardGenerationSettingID = c.Long(nullable: false, identity: true),
                        CardNoLength = c.Int(nullable: false),
                        CardNoStartingNo = c.Int(nullable: false),
                        DefaultCardNoPrefix = c.String(maxLength: 3),
                        EncodeLength = c.Int(nullable: false),
                        EncodeStartingNo = c.Int(nullable: false),
                        DefaultEncodePrefix = c.String(maxLength: 3),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardGenerationSettingID);
            
            CreateTable(
                "dbo.CardMaster",
                c => new
                    {
                        CardMasterID = c.Long(nullable: false, identity: true),
                        CardType = c.Int(nullable: false),
                        CardCode = c.String(nullable: false, maxLength: 15),
                        CardName = c.String(nullable: false, maxLength: 50),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPoints = c.Int(nullable: false),
                        ReDeemPointValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardMasterID);
            
            CreateTable(
                "dbo.CashierFunction",
                c => new
                    {
                        CashierFunctionID = c.Long(nullable: false, identity: true),
                        FunctionName = c.String(nullable: false, maxLength: 15),
                        FunctionDescription = c.String(nullable: false, maxLength: 100),
                        Order = c.Long(nullable: false),
                        TypeID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsValue = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CashierFunctionID);
            
            CreateTable(
                "dbo.CashierGroup",
                c => new
                    {
                        CashierGroupID = c.Long(nullable: false, identity: true),
                        EmployeeDesignationTypeID = c.Int(nullable: false),
                        FunctionName = c.String(nullable: false, maxLength: 100),
                        FunctionDescription = c.String(nullable: false, maxLength: 250),
                        Order = c.Long(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        TypeID = c.Int(nullable: false),
                        IsAccess = c.Boolean(nullable: false),
                        IsValue = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CashierGroupID);
            
            CreateTable(
                "dbo.CashierPermission",
                c => new
                    {
                        CashierPermissionID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                        JournalName = c.String(maxLength: 50),
                        EnCode = c.String(maxLength: 50),
                        FunctionName = c.String(nullable: false, maxLength: 100),
                        FunctName = c.String(nullable: false, maxLength: 100),
                        FunctionDescription = c.String(nullable: false, maxLength: 250),
                        Order = c.Long(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.String(),
                        TypeID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsAccess = c.Boolean(nullable: false),
                        Remarks = c.String(maxLength: 500),
                        IsDelete = c.Boolean(nullable: false),
                        IsValue = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CashierPermissionID);
            
            CreateTable(
                "dbo.ChangedTableItemDet",
                c => new
                    {
                        ChangedTableItemDetID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        RefCode = c.String(nullable: false, maxLength: 25),
                        BarCodeFull = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 50),
                        BatchNo = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        ExpiryDate = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(maxLength: 10),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1 = c.Int(nullable: false),
                        IDis1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1CashierID = c.Long(nullable: false),
                        IDI2 = c.Int(nullable: false),
                        IDis2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI2CashierID = c.Long(nullable: false),
                        IDI3 = c.Int(nullable: false),
                        IDis3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI3CashierID = c.Long(nullable: false),
                        IDI4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDis4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI4CashierID = c.Long(nullable: false),
                        IDI5 = c.Int(nullable: false),
                        IDis5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI5CashierID = c.Long(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSDis = c.Boolean(nullable: false),
                        SDNo = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                        SDIs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDisCashierID = c.Long(nullable: false),
                        Nett = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        SalesmanID = c.Long(nullable: false),
                        Salesman = c.String(maxLength: 15),
                        CustomerID = c.Long(nullable: false),
                        Customer = c.String(maxLength: 150),
                        CashierID = c.Long(nullable: false),
                        Cashier = c.String(maxLength: 15),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RecDate = c.DateTime(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        RowNo = c.Int(nullable: false),
                        IsRecall = c.Boolean(nullable: false),
                        RecallNO = c.String(maxLength: 20),
                        RecallAdv = c.Boolean(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTax = c.Boolean(nullable: false),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStock = c.Boolean(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        TransStatus = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        IsPromotionApplied = c.Boolean(nullable: false),
                        PromotionID = c.Long(nullable: false),
                        IsPromotion = c.Int(nullable: false),
                        LocationIDBilling = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        OrderTerminalID = c.Int(nullable: false),
                        TicketID = c.Long(nullable: false),
                        OrderNo = c.Long(nullable: false),
                        IsPrinted = c.Boolean(nullable: false),
                        ItemComment = c.String(maxLength: 100),
                        Packs = c.Int(nullable: false),
                        IsCancelKOT = c.Boolean(nullable: false),
                        StewardID = c.Int(nullable: false),
                        StewardName = c.String(maxLength: 50),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceChargeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShiftNo = c.Long(nullable: false),
                        IsDayEnd = c.Boolean(nullable: false),
                        UpdateUnitNo = c.Int(nullable: false),
                        ChangedCashierID = c.Long(nullable: false),
                        ChangedDateTime = c.DateTime(nullable: false),
                        ChangedTableID = c.Int(nullable: false),
                        ChangedBillingLocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChangedTableItemDetID);
            
            CreateTable(
                "dbo.ChangedTablePaymentDet",
                c => new
                    {
                        ChangedTablePaymentDetID = c.Long(nullable: false, identity: true),
                        RowNo = c.Long(nullable: false),
                        PayTypeID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDate = c.DateTime(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        LocationID = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        RefNo = c.String(nullable: false, maxLength: 30),
                        BankId = c.Long(nullable: false),
                        ChequeDate = c.DateTime(),
                        IsRecallAdv = c.Boolean(nullable: false),
                        RecallNo = c.String(nullable: false, maxLength: 10),
                        Descrip = c.String(nullable: false, maxLength: 20),
                        EnCodeName = c.String(nullable: false, maxLength: 50),
                        UpdatedBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        CustomerCode = c.String(maxLength: 25),
                        GroupOfCompanyID = c.Int(nullable: false),
                        Datatransfer = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        TerminalID = c.Int(nullable: false),
                        LoyaltyType = c.Int(nullable: false),
                        IsUploadToGL = c.Int(nullable: false),
                        LocationIDBilling = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        TicketID = c.Long(nullable: false),
                        OrderNo = c.Long(nullable: false),
                        ShiftNo = c.Long(nullable: false),
                        IsDayEnd = c.Boolean(nullable: false),
                        UpdateUnitNo = c.Int(nullable: false),
                        ChangedCashierID = c.Long(nullable: false),
                        ChangedDateTime = c.DateTime(nullable: false),
                        ChangedTableID = c.Int(nullable: false),
                        ChangedBillingLocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChangedTablePaymentDetID);
            
            CreateTable(
                "dbo.CommissionSchema",
                c => new
                    {
                        CommissionSchemaID = c.Int(nullable: false, identity: true),
                        CommissionSchemaCode = c.String(nullable: false, maxLength: 15),
                        CommissionSchemaName = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommissionSchemaID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CostCentreID = c.Int(nullable: false),
                        CompanyCode = c.String(nullable: false, maxLength: 15),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        OtherBusinessName1 = c.String(maxLength: 100),
                        OtherBusinessName2 = c.String(maxLength: 100),
                        OtherBusinessName3 = c.String(maxLength: 100),
                        Address1 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        FaxNo = c.String(),
                        Email = c.String(),
                        WebAddress = c.String(),
                        ContactPerson = c.String(),
                        TaxID1 = c.Int(nullable: false),
                        TaxID2 = c.Int(nullable: false),
                        TaxID3 = c.Int(nullable: false),
                        TaxID4 = c.Int(nullable: false),
                        TaxID5 = c.Int(nullable: false),
                        TaxRegistrationNumber1 = c.String(maxLength: 50),
                        TaxRegistrationNumber2 = c.String(maxLength: 50),
                        TaxRegistrationNumber3 = c.String(maxLength: 50),
                        TaxRegistrationNumber4 = c.String(maxLength: 50),
                        TaxRegistrationNumber5 = c.String(maxLength: 50),
                        StartOfFiscalYear = c.Int(nullable: false),
                        CostingMethod = c.String(nullable: false, maxLength: 50),
                        IsVat = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.CostCentre", t => t.CostCentreID, cascadeDelete: true)
                .ForeignKey("dbo.GroupOfCompany", t => t.GroupOfCompanyID, cascadeDelete: true)
                .Index(t => t.CostCentreID)
                .Index(t => t.GroupOfCompanyID);
            
            CreateTable(
                "dbo.CostCentre",
                c => new
                    {
                        CostCentreID = c.Int(nullable: false, identity: true),
                        CostCentreCode = c.String(nullable: false),
                        CostCentreName = c.String(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CostCentreID);
            
            CreateTable(
                "dbo.GroupOfCompany",
                c => new
                    {
                        GroupOfCompanyID = c.Int(nullable: false, identity: true),
                        GroupOfCompanyCode = c.String(),
                        GroupOfCompanyName = c.String(),
                        IsInventory = c.Boolean(nullable: false),
                        IsPos = c.Boolean(nullable: false),
                        IsManufacture = c.Boolean(nullable: false),
                        IsHirePurchase = c.Boolean(nullable: false),
                        IsCrm = c.Boolean(nullable: false),
                        IsGiftVoucher = c.Boolean(nullable: false),
                        IsGeneralLedger = c.Boolean(nullable: false),
                        IsLogistic = c.Boolean(nullable: false),
                        IsHrManagement = c.Boolean(nullable: false),
                        IsHospitalManagement = c.Boolean(nullable: false),
                        IsApparelManufacture = c.Boolean(nullable: false),
                        IsRestaurantManagement = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupOfCompanyID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationCode = c.String(nullable: false, maxLength: 15),
                        LocationName = c.String(nullable: false, maxLength: 50),
                        Address1 = c.String(nullable: false, maxLength: 50),
                        Address2 = c.String(nullable: false, maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        FaxNo = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        ContactPersonName = c.String(maxLength: 100),
                        OtherBusinessName = c.String(maxLength: 100),
                        LocationPrefixCode = c.String(maxLength: 3),
                        LoyaltyPrefixCode = c.String(maxLength: 50),
                        TypeOfBusiness = c.String(maxLength: 50),
                        CostingMethod = c.String(maxLength: 50),
                        CostCentreID = c.Int(nullable: false),
                        IsVat = c.Boolean(nullable: false),
                        IsStockLocation = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsHeadOffice = c.Boolean(nullable: false),
                        UploadPath = c.String(),
                        DownloadPath = c.String(),
                        LocalUploadPath = c.String(),
                        BackupPath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LocationIP = c.String(maxLength: 50),
                        IsShowRoom = c.Boolean(nullable: false),
                        AccLedgerAccountID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Counter",
                c => new
                    {
                        CounterID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(maxLength: 15),
                        LocationName = c.String(maxLength: 15),
                        OrderNo = c.Long(nullable: false),
                        TicketID = c.Long(nullable: false),
                        IsLoadSteward = c.Boolean(nullable: false),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrintLength = c.Int(nullable: false),
                        IsLayaway = c.Boolean(nullable: false),
                        IsAutoLayaway = c.Boolean(nullable: false),
                        Zno = c.Long(nullable: false),
                        ShiftNo = c.Long(nullable: false),
                        LogPath = c.String(maxLength: 100),
                        JnlPath = c.String(maxLength: 100),
                        Receipt = c.Long(nullable: false),
                        Suspend = c.Long(nullable: false),
                        DocNo2 = c.Long(nullable: false),
                        DocNo3 = c.Long(nullable: false),
                        DocNo4 = c.Long(nullable: false),
                        DocNo5 = c.Long(nullable: false),
                        CrNote = c.Long(nullable: false),
                        Invoice = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        StDisc1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StDisc2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoyaltyScale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GoldCardScale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StpScale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Head1 = c.String(maxLength: 48),
                        Head2 = c.String(maxLength: 48),
                        Head3 = c.String(maxLength: 48),
                        Head4 = c.String(maxLength: 48),
                        Head5 = c.String(maxLength: 48),
                        Head6 = c.String(maxLength: 48),
                        Head7 = c.String(maxLength: 48),
                        Head8 = c.String(maxLength: 48),
                        Head9 = c.String(maxLength: 48),
                        Head10 = c.String(maxLength: 48),
                        Tail1 = c.String(maxLength: 48),
                        Tail2 = c.String(maxLength: 48),
                        Tail3 = c.String(maxLength: 48),
                        Tail4 = c.String(maxLength: 48),
                        Tail5 = c.String(maxLength: 48),
                        Tail6 = c.String(maxLength: 48),
                        Tail7 = c.String(maxLength: 48),
                        Tail8 = c.String(maxLength: 48),
                        Tail9 = c.String(maxLength: 48),
                        Tail10 = c.String(maxLength: 48),
                        lpc = c.Int(nullable: false),
                        lpc2 = c.Int(nullable: false),
                        DispDate = c.Boolean(nullable: false),
                        DispTime = c.Boolean(nullable: false),
                        PPort = c.String(maxLength: 20),
                        BRate = c.Int(nullable: false),
                        AutoCut = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CounterID);
            
            CreateTable(
                "dbo.CreditCardBankMaster",
                c => new
                    {
                        CreditCardBankMasterID = c.Long(nullable: false, identity: true),
                        BankID = c.Long(nullable: false),
                        Commission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccLedgerCreditID = c.Long(nullable: false),
                        AccLedgerDebitID = c.Long(nullable: false),
                        AccLedgerDiscountID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardBankMasterID);
            
            CreateTable(
                "dbo.CrmReportCondition",
                c => new
                    {
                        CrmReportConditionID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CardMasterID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CrmReportConditionID);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        CurrencyID = c.Int(nullable: false, identity: true),
                        CurrencyCode = c.String(maxLength: 5),
                        CurrencyDescription = c.String(maxLength: 50),
                        CurrencyFormat = c.String(maxLength: 15),
                        CurrencySymbol = c.String(maxLength: 5),
                        BuyingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AsofDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.CurrencyHistory",
                c => new
                    {
                        CurrencyHistoryID = c.Int(nullable: false, identity: true),
                        CurrencyID = c.Int(nullable: false),
                        BuyingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AsofDate = c.DateTime(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CurrencyHistoryID);
            
            CreateTable(
                "dbo.CustomerFeedBack",
                c => new
                    {
                        CustomerFeedBackID = c.Long(nullable: false, identity: true),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        CustomerName = c.String(maxLength: 100),
                        Nic = c.String(maxLength: 100),
                        Gender = c.String(maxLength: 100),
                        Age = c.String(maxLength: 100),
                        Occupation = c.String(maxLength: 100),
                        Ethinicity = c.String(maxLength: 100),
                        CardType = c.String(maxLength: 100),
                        Address1 = c.String(maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        Address3 = c.String(maxLength: 100),
                        ContactPerson = c.String(maxLength: 100),
                        Province = c.String(maxLength: 100),
                        District = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Telephone = c.String(maxLength: 100),
                        Mobile = c.String(maxLength: 100),
                        Fax = c.String(maxLength: 100),
                        RefPerson = c.String(maxLength: 100),
                        RefAddress1 = c.String(maxLength: 100),
                        RefAddress2 = c.String(maxLength: 100),
                        RefAddress3 = c.String(maxLength: 100),
                        HabitualShopping = c.String(maxLength: 100),
                        ItemPrice = c.String(maxLength: 100),
                        Quality = c.String(maxLength: 100),
                        Service = c.String(maxLength: 100),
                        SatisfiedWithAvailability = c.String(maxLength: 100),
                        ShoppingAt = c.String(maxLength: 100),
                        SatisfiedWithVariety = c.String(maxLength: 100),
                        StaffsQuality = c.String(maxLength: 100),
                        StaffsKnowledge = c.String(maxLength: 100),
                        InfluencedBy = c.String(maxLength: 100),
                        Comfortable = c.String(maxLength: 100),
                        FactQuality = c.Boolean(nullable: false),
                        FactService = c.Boolean(nullable: false),
                        FactPrice = c.Boolean(nullable: false),
                        FactCollections = c.Boolean(nullable: false),
                        FactMerchandising = c.Boolean(nullable: false),
                        FactAppearance = c.Boolean(nullable: false),
                        KnowAbtPromotion = c.String(maxLength: 100),
                        Regularity = c.String(maxLength: 100),
                        ShoppingFor = c.String(maxLength: 100),
                        Motivates = c.String(maxLength: 100),
                        Recommend4Others = c.String(maxLength: 100),
                        YourChanges = c.String(maxLength: 100),
                        Recommendations = c.String(maxLength: 100),
                        RateService = c.String(maxLength: 100),
                        LocationID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerFeedBackID);
            
            CreateTable(
                "dbo.DayStart",
                c => new
                    {
                        DayStartID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        LocationIDBilling = c.Int(nullable: false),
                        DayStartCashierID = c.Long(nullable: false),
                        Daystart = c.DateTime(nullable: false, storeType: "date"),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartSystemDate = c.DateTime(nullable: false),
                        IsDayEnd = c.Boolean(nullable: false),
                        DayEndCashierID = c.Long(nullable: false),
                        EndSystemDate = c.DateTime(nullable: false),
                        DayEnd = c.DateTime(nullable: false, storeType: "date"),
                        ZNo = c.Long(nullable: false),
                        CashInHand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsShiftStarted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DayStartID);
            
            CreateTable(
                "dbo.DocumentNumber",
                c => new
                    {
                        DocumentNumberID = c.Long(nullable: false, identity: true),
                        DocumentID = c.Int(nullable: false),
                        DocumentName = c.String(),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentNo = c.Long(nullable: false),
                        TempDocumentNo = c.Long(nullable: false),
                        TemplateDocumentNo = c.Long(nullable: false),
                        DocumentYear = c.Int(nullable: false),
                        PrefixCode = c.String(),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentNumberID);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        DriverID = c.Long(nullable: false, identity: true),
                        DriverCode = c.String(nullable: false, maxLength: 15),
                        DriverName = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(maxLength: 15),
                        ReferenceNo = c.String(maxLength: 25),
                        Address1 = c.String(maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        Address3 = c.String(maxLength: 100),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        DriverImage = c.Byte(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverID);
            
            CreateTable(
                "dbo.EmployeeBackup",
                c => new
                    {
                        EmployeeBackupID = c.Long(nullable: false, identity: true),
                        EmployeeID = c.Long(nullable: false),
                        EmployeeCode = c.String(nullable: false, maxLength: 15),
                        EmployeeTitle = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        Designation = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        ReferenceNo = c.String(nullable: false, maxLength: 25),
                        Remark = c.String(maxLength: 100),
                        Address1 = c.String(nullable: false, maxLength: 100),
                        Address2 = c.String(nullable: false, maxLength: 100),
                        Address3 = c.String(maxLength: 100),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(nullable: false),
                        Image = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                        MinimumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CrLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PchLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccPch = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        Department = c.String(maxLength: 30),
                        BackupDate = c.DateTime(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeBackupID);
            
            CreateTable(
                "dbo.EmployeeDesignationType",
                c => new
                    {
                        EmployeeDesignationTypeID = c.Int(nullable: false, identity: true),
                        DesignationCode = c.String(nullable: false, maxLength: 15),
                        Designation = c.String(nullable: false, maxLength: 100),
                        Remarks = c.String(maxLength: 500),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeDesignationTypeID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Long(nullable: false, identity: true),
                        EmployeeCode = c.String(nullable: false, maxLength: 15),
                        EmployeeTitle = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        Designation = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        ReferenceNo = c.String(nullable: false, maxLength: 25),
                        Remark = c.String(maxLength: 100),
                        Address1 = c.String(nullable: false, maxLength: 100),
                        Address2 = c.String(nullable: false, maxLength: 100),
                        Address3 = c.String(maxLength: 100),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(nullable: false),
                        Image = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                        MinimumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CrLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PchLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccPch = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        Department = c.String(maxLength: 30),
                        LocationID = c.Int(nullable: false),
                        CostCenterID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.FinancialInstitution",
                c => new
                    {
                        FinancialInstitutionID = c.Int(nullable: false, identity: true),
                        FinancialInstitutionCode = c.String(nullable: false, maxLength: 15),
                        FinancialInstitutionName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinancialInstitutionID);
            
            CreateTable(
                "dbo.FinancialPeriod",
                c => new
                    {
                        FinancialPeriodID = c.Long(nullable: false, identity: true),
                        DocumentDate = c.DateTime(nullable: false),
                        FinancialYear = c.Int(nullable: false),
                        FinancialStartDate = c.DateTime(nullable: false),
                        FinancialEndDate = c.DateTime(nullable: false),
                        ProcessStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinancialPeriodID);
            
            CreateTable(
                "dbo.Helper",
                c => new
                    {
                        HelperID = c.Long(nullable: false, identity: true),
                        HelperCode = c.String(nullable: false, maxLength: 15),
                        HelperName = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 15),
                        ReferenceNo = c.Long(nullable: false),
                        Address1 = c.String(maxLength: 100),
                        Address2 = c.String(maxLength: 100),
                        Address3 = c.String(maxLength: 100),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        HelperImage = c.Byte(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HelperID);
            
            CreateTable(
                "dbo.HourlySales",
                c => new
                    {
                        HourlySalesID = c.Long(nullable: false, identity: true),
                        DateX = c.DateTime(nullable: false),
                        Slab = c.String(maxLength: 50),
                        LocationCode = c.String(maxLength: 5),
                        LocationName = c.String(maxLength: 50),
                        NetAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillCount = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HourlySalesID);
            
            CreateTable(
                "dbo.HspChannelingCenterDetails",
                c => new
                    {
                        HspChannelingCenterDetailsID = c.Long(nullable: false, identity: true),
                        HspDoctorID = c.Long(nullable: false),
                        ChannelingCenterName = c.String(nullable: false, maxLength: 50),
                        ChannelingDate = c.String(nullable: false, maxLength: 15),
                        ChannelingTime = c.String(maxLength: 15),
                        ContactNo = c.String(maxLength: 25),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HspChannelingCenterDetailsID);
            
            CreateTable(
                "dbo.HspDoctor",
                c => new
                    {
                        HspDoctorID = c.Long(nullable: false, identity: true),
                        DoctorID = c.Long(nullable: false),
                        DoctorCode = c.String(nullable: false, maxLength: 15),
                        DoctorTitle = c.Int(nullable: false),
                        DoctorName = c.String(nullable: false, maxLength: 100),
                        Gender = c.Int(nullable: false),
                        Specialty = c.String(maxLength: 50),
                        SpecialtyDescription = c.String(maxLength: 200),
                        RegistrationNo = c.String(maxLength: 25),
                        ReferenceNo = c.String(maxLength: 25),
                        MedicalInstitute = c.String(maxLength: 100),
                        EmploymentType = c.Int(nullable: false),
                        Address1 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Telephone = c.String(),
                        Mobile = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        HospitalFeeDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HospitalFeeNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConsultancyFeeDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConsultancyFeeNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherFee1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethodID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        OtherLedgerID = c.Long(nullable: false),
                        DoctorImage = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HspDoctorID);
            
            CreateTable(
                "dbo.HspPatient",
                c => new
                    {
                        HspPatientID = c.Long(nullable: false, identity: true),
                        PatientID = c.Long(nullable: false),
                        PatientCode = c.String(nullable: false, maxLength: 15),
                        PatientTitle = c.Int(nullable: false),
                        PatientName = c.String(nullable: false, maxLength: 100),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        GuardianName = c.String(maxLength: 100),
                        GuardianAddress = c.String(maxLength: 100),
                        Address1 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HspPatientID);
            
            CreateTable(
                "dbo.HspRoomFacility",
                c => new
                    {
                        HspRoomFacilityID = c.Long(nullable: false, identity: true),
                        RoomFacilityID = c.Long(nullable: false),
                        FacilityCode = c.String(nullable: false, maxLength: 15),
                        FacilityDescription = c.String(nullable: false, maxLength: 100),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HspRoomFacilityID);
            
            CreateTable(
                "dbo.HspRoomFacilityDetails",
                c => new
                    {
                        HspRoomFacilityDetailsID = c.Long(nullable: false, identity: true),
                        RoomFacilityDetailsID = c.Long(nullable: false),
                        RoomID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HspRoomFacilityDetailsID);
            
            CreateTable(
                "dbo.HspRoom",
                c => new
                    {
                        HspRoomID = c.Long(nullable: false, identity: true),
                        RoomID = c.Long(nullable: false),
                        RoomCode = c.String(nullable: false, maxLength: 15),
                        RoomName = c.String(nullable: false, maxLength: 100),
                        RoomType = c.String(nullable: false, maxLength: 25),
                        RoomFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 200),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        RoomImage = c.Binary(),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        RoomFacility_HspRoomFacilityID = c.Long(),
                    })
                .PrimaryKey(t => t.HspRoomID)
                .ForeignKey("dbo.HspRoomFacility", t => t.RoomFacility_HspRoomFacilityID)
                .Index(t => t.RoomFacility_HspRoomFacilityID);
            
            CreateTable(
                "dbo.HspSpecialty",
                c => new
                    {
                        HspSpecialtyID = c.Long(nullable: false, identity: true),
                        SpecialtyID = c.Long(nullable: false),
                        SpecialtyCode = c.String(nullable: false, maxLength: 15),
                        SpecialtyDescription = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HspSpecialtyID);
            
            CreateTable(
                "dbo.InvAgeAnalysisSlabReportTable",
                c => new
                    {
                        InvAgeAnalysisSlabReportTableID = c.Int(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        DepartmentId = c.Long(nullable: false),
                        DepartmentCode = c.String(),
                        CategoryId = c.Long(nullable: false),
                        CategoryCode = c.String(),
                        SubCategoryId = c.Long(nullable: false),
                        SubCategoryCode = c.String(),
                        SubCategory2Id = c.Long(nullable: false),
                        SubCategory2Code = c.String(),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPurchaseQty = c.Int(nullable: false),
                        TotalSellingQty = c.Int(nullable: false),
                        Slab1 = c.Int(nullable: false),
                        Slab2 = c.Int(nullable: false),
                        Slab3 = c.Int(nullable: false),
                        Slab4 = c.Int(nullable: false),
                        Slab5 = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvAgeAnalysisSlabReportTableID);
            
            CreateTable(
                "dbo.InvAgeAnalysisSlab",
                c => new
                    {
                        InvAgeAnalysisSlabId = c.Int(nullable: false, identity: true),
                        FromSlab = c.Int(nullable: false),
                        ToSlab = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvAgeAnalysisSlabId);
            
            CreateTable(
                "dbo.InvBasketAnalysisSelectedLocationsTemp",
                c => new
                    {
                        InvBasketAnalysisSelectedLocationsTempID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        LocationDescription = c.String(maxLength: 100),
                        PcName = c.String(),
                        UserName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InvBasketAnalysisSelectedLocationsTempID);
            
            CreateTable(
                "dbo.InvBasketAnalysisValueRange",
                c => new
                    {
                        InvBasketAnalysisValueRangeID = c.Long(nullable: false, identity: true),
                        RangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvBasketAnalysisValueRangeID);
            
            CreateTable(
                "dbo.InvBasketAnalysisValueRangeTemp",
                c => new
                    {
                        InvBasketAnalysisValueRangeTempID = c.Long(nullable: false, identity: true),
                        RangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeType = c.Int(nullable: false),
                        PcName = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InvBasketAnalysisValueRangeTempID);
            
            CreateTable(
                "dbo.InvCategory",
                c => new
                    {
                        InvCategoryID = c.Long(nullable: false, identity: true),
                        InvDepartmentID = c.Long(nullable: false),
                        CategoryCode = c.String(nullable: false, maxLength: 15),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsNonExchangeable = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvCategoryID)
                .ForeignKey("dbo.InvDepartment", t => t.InvDepartmentID, cascadeDelete: true)
                .Index(t => t.InvDepartmentID);
            
            CreateTable(
                "dbo.InvDepartment",
                c => new
                    {
                        InvDepartmentID = c.Long(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 15),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvDepartmentID);
            
            CreateTable(
                "dbo.InvSubCategory",
                c => new
                    {
                        InvSubCategoryID = c.Long(nullable: false, identity: true),
                        InvCategoryID = c.Long(nullable: false),
                        SubCategoryCode = c.String(nullable: false, maxLength: 15),
                        SubCategoryName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSubCategoryID)
                .ForeignKey("dbo.InvCategory", t => t.InvCategoryID, cascadeDelete: true)
                .Index(t => t.InvCategoryID);
            
            CreateTable(
                "dbo.InvSubCategory2",
                c => new
                    {
                        InvSubCategory2ID = c.Long(nullable: false, identity: true),
                        InvSubCategoryID = c.Long(nullable: false),
                        SubCategory2Code = c.String(nullable: false, maxLength: 15),
                        SubCategory2Name = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSubCategory2ID)
                .ForeignKey("dbo.InvSubCategory", t => t.InvSubCategoryID, cascadeDelete: true)
                .Index(t => t.InvSubCategoryID);
            
            CreateTable(
                "dbo.InvCreditNoteDet",
                c => new
                    {
                        InvCreditNoteDetID = c.Long(nullable: false, identity: true),
                        CrNoteNo = c.String(maxLength: 15),
                        Receipt = c.String(maxLength: 15),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Zno = c.Long(nullable: false),
                        TransID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvCreditNoteDetID);
            
            CreateTable(
                "dbo.InvCreditNoteHed",
                c => new
                    {
                        InvCreditNoteHedID = c.Long(nullable: false, identity: true),
                        CrNoteNo = c.String(maxLength: 15),
                        Receipt = c.String(maxLength: 15),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Zno = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvCreditNoteHedID);
            
            CreateTable(
                "dbo.InvDamageType",
                c => new
                    {
                        InvDamageTypeID = c.Int(nullable: false, identity: true),
                        DamageType = c.String(maxLength: 30),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvDamageTypeID);
            
            CreateTable(
                "dbo.InvEmployeeTransaction",
                c => new
                    {
                        InvEmployeeTransactionID = c.Long(nullable: false, identity: true),
                        EmployeeID = c.Long(nullable: false),
                        Receipt = c.String(maxLength: 15),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        DiscPer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zno = c.Long(nullable: false),
                        CrLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PchLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccPch = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashierID = c.Long(nullable: false),
                        IsSync = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvEmployeeTransactionID);
            
            CreateTable(
                "dbo.InvGiftVoucherBookCode",
                c => new
                    {
                        InvGiftVoucherBookCodeID = c.Int(nullable: false, identity: true),
                        InvGiftVoucherGroupID = c.Int(nullable: false),
                        BookCode = c.String(nullable: false, maxLength: 20),
                        BookName = c.String(nullable: false, maxLength: 50),
                        BookPrefix = c.String(maxLength: 4),
                        GiftVoucherValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftVoucherPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValidityPeriod = c.Int(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        StartingNo = c.Int(nullable: false),
                        CurrentSerialNo = c.Int(nullable: false),
                        SerialLength = c.Int(nullable: false),
                        PageCount = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        BasedOn = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherBookCodeID)
                .ForeignKey("dbo.InvGiftVoucherGroup", t => t.InvGiftVoucherGroupID)
                .Index(t => t.InvGiftVoucherGroupID);
            
            CreateTable(
                "dbo.InvGiftVoucherGroup",
                c => new
                    {
                        InvGiftVoucherGroupID = c.Int(nullable: false, identity: true),
                        GiftVoucherGroupCode = c.String(nullable: false, maxLength: 20),
                        GiftVoucherGroupName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherGroupID);
            
            CreateTable(
                "dbo.InvGiftVoucherMaster",
                c => new
                    {
                        InvGiftVoucherMasterID = c.Long(nullable: false, identity: true),
                        InvGiftVoucherBookCodeID = c.Int(nullable: false),
                        InvGiftVoucherGroupID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        VoucherNo = c.String(nullable: false, maxLength: 15),
                        VoucherNoSerial = c.Int(nullable: false),
                        VoucherPrefix = c.String(maxLength: 4),
                        SerialLength = c.Int(nullable: false),
                        GiftVoucherValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftVoucherPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartingNo = c.Int(nullable: false),
                        VoucherCount = c.Int(nullable: false),
                        PageCount = c.Int(nullable: false),
                        VoucherSerial = c.String(),
                        VoucherSerialNo = c.Int(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        VoucherStatus = c.Int(nullable: false),
                        ToLocationID = c.Int(nullable: false),
                        SoldLocationID = c.Int(nullable: false),
                        SoldCashierID = c.Long(nullable: false),
                        SoldReceiptNo = c.String(),
                        SoldUnitID = c.Int(nullable: false),
                        SoldZNo = c.Long(nullable: false),
                        SoldDate = c.DateTime(nullable: false),
                        RedeemedLocationID = c.Int(nullable: false),
                        RedeemedCashierID = c.Long(nullable: false),
                        RedeemedReceiptNo = c.String(),
                        RedeemedUnitID = c.Int(nullable: false),
                        RedeemedZNo = c.Long(nullable: false),
                        RedeemedDate = c.DateTime(nullable: false),
                        IsBarcodePrinted = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherMasterID)
                .ForeignKey("dbo.InvGiftVoucherBookCode", t => t.InvGiftVoucherBookCodeID, cascadeDelete: true)
                .ForeignKey("dbo.InvGiftVoucherGroup", t => t.InvGiftVoucherGroupID, cascadeDelete: true)
                .Index(t => t.InvGiftVoucherBookCodeID)
                .Index(t => t.InvGiftVoucherGroupID);
            
            CreateTable(
                "dbo.InvGiftVoucherPurchaseDetail",
                c => new
                    {
                        InvGiftVoucherPurchaseDetailID = c.Long(nullable: false, identity: true),
                        GiftVoucherPurchaseDetailID = c.Long(nullable: false),
                        InvGiftVoucherPurchaseHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        LineNo = c.Long(nullable: false),
                        InvGiftVoucherMasterID = c.Long(nullable: false),
                        NumberOfCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherType = c.Int(nullable: false),
                        IsTransfer = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherPurchaseDetailID)
                .ForeignKey("dbo.InvGiftVoucherPurchaseHeader", t => t.InvGiftVoucherPurchaseHeaderID, cascadeDelete: true)
                .Index(t => t.InvGiftVoucherPurchaseHeaderID);
            
            CreateTable(
                "dbo.InvGiftVoucherPurchaseHeader",
                c => new
                    {
                        InvGiftVoucherPurchaseHeaderID = c.Long(nullable: false, identity: true),
                        GiftVoucherPurchaseHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        PartyInvoiceDate = c.DateTime(nullable: false),
                        DispatchDate = c.DateTime(nullable: false),
                        GiftVoucherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftVoucherPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditPeriod = c.Int(nullable: false),
                        ChequeLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequePeriod = c.Int(nullable: false),
                        GiftVoucherQty = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        ReferenceNo = c.String(maxLength: 20),
                        PartyInvoiceNo = c.String(maxLength: 20),
                        DispatchNo = c.String(maxLength: 20),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        DeliveryPerson = c.String(maxLength: 150),
                        DeliveryPersonNICNo = c.String(maxLength: 150),
                        VehicleNo = c.String(maxLength: 150),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherPurchaseHeaderID);
            
            CreateTable(
                "dbo.InvGiftVoucherPurchaseOrderDetail",
                c => new
                    {
                        InvGiftVoucherPurchaseOrderDetailID = c.Long(nullable: false, identity: true),
                        GiftVoucherPurchaseOrderDetailID = c.Long(nullable: false),
                        InvGiftVoucherPurchaseOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        LineNo = c.Long(nullable: false),
                        InvGiftVoucherMasterID = c.Long(nullable: false),
                        NumberOfCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherType = c.Int(nullable: false),
                        IsPurchase = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherPurchaseOrderDetailID);
            
            CreateTable(
                "dbo.InvGiftVoucherPurchaseOrderHeader",
                c => new
                    {
                        InvGiftVoucherPurchaseOrderHeaderID = c.Long(nullable: false, identity: true),
                        GiftVoucherPurchaseOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        ExpectedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        GiftVoucherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftVoucherPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditPeriod = c.Int(nullable: false),
                        ChequeLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequePeriod = c.Int(nullable: false),
                        GiftVoucherQty = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        ReferenceNo = c.String(maxLength: 20),
                        VoucherType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherPurchaseOrderHeaderID);
            
            CreateTable(
                "dbo.InvGiftVoucherTransferNoteDetail",
                c => new
                    {
                        InvGiftVoucherTransferNoteDetailID = c.Long(nullable: false, identity: true),
                        GiftVoucherTransferNoteDetailID = c.Long(nullable: false),
                        InvGiftVoucherTransferNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        LineNo = c.Long(nullable: false),
                        InvGiftVoucherMasterID = c.Long(nullable: false),
                        NumberOfCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VoucherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToLocationID = c.Int(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherTransferNoteDetailID)
                .ForeignKey("dbo.InvGiftVoucherTransferNoteHeader", t => t.InvGiftVoucherTransferNoteHeaderID, cascadeDelete: true)
                .Index(t => t.InvGiftVoucherTransferNoteHeaderID);
            
            CreateTable(
                "dbo.InvGiftVoucherTransferNoteHeader",
                c => new
                    {
                        InvGiftVoucherTransferNoteHeaderID = c.Long(nullable: false, identity: true),
                        GiftVoucherTransferNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        TransferTypeID = c.Int(nullable: false),
                        GiftVoucherAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftVoucherPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftVoucherQty = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        ReferenceNo = c.String(maxLength: 20),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        ToLocationID = c.Int(nullable: false),
                        VoucherType = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvGiftVoucherTransferNoteHeaderID);
            
            CreateTable(
                "dbo.InvKitchenBar",
                c => new
                    {
                        InvKitchenBarID = c.Int(nullable: false, identity: true),
                        KitchenBarCode = c.String(nullable: false, maxLength: 15),
                        KitchenBarName = c.String(nullable: false, maxLength: 50),
                        IpAddress = c.String(maxLength: 20),
                        CommPort = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvKitchenBarID);
            
            CreateTable(
                "dbo.InvLoyaltyTransaction",
                c => new
                    {
                        InvLoyaltyTransactionID = c.Long(nullable: false, identity: true),
                        CustomerID = c.Long(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 15),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        DocumentTime = c.DateTime(nullable: false),
                        DiscPer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PointsRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zno = c.Long(nullable: false),
                        CardNo = c.String(maxLength: 15),
                        CardType = c.Int(nullable: false),
                        LoyaltyType = c.Int(nullable: false),
                        IsGuidClaimed = c.Boolean(nullable: false),
                        IsSync = c.Int(nullable: false),
                        CustomerCode = c.String(maxLength: 20),
                        NIC = c.String(maxLength: 50),
                        RefNo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InvLoyaltyTransactionID);
            
            CreateTable(
                "dbo.InvoiceWiseSalesTemp",
                c => new
                    {
                        InvoiceWiseSalesTempID = c.Long(nullable: false, identity: true),
                        Receipt = c.String(maxLength: 10),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceWiseSalesTempID);
            
            CreateTable(
                "dbo.InvPaymentCardType",
                c => new
                    {
                        InvPaymentCardTypeID = c.Long(nullable: false, identity: true),
                        BankID = c.Long(nullable: false),
                        PaymentCardCode = c.String(nullable: false, maxLength: 15),
                        PaymentCardName = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvPaymentCardTypeID);
            
            CreateTable(
                "dbo.InvPosConfiguration",
                c => new
                    {
                        InvPosConfigurationID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        DocNo2 = c.Long(nullable: false),
                        DocNo3 = c.Long(nullable: false),
                        DocNo4 = c.Long(nullable: false),
                        DocNo5 = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvPosConfigurationID);
            
            CreateTable(
                "dbo.InvPosTerminalDetails",
                c => new
                    {
                        InvPosTerminalDetailsID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        TerminalId = c.Int(nullable: false),
                        IP = c.String(),
                        DBNAME = c.String(),
                        UserId = c.String(),
                        PWD = c.String(),
                        JrnlPath = c.String(),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPosTerminalDetailsID);
            
            CreateTable(
                "dbo.InvPriceLevelList",
                c => new
                    {
                        InvPriceLevelListID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        InvPriceLevelID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        PriceLevelPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPriceLevelListID);
            
            CreateTable(
                "dbo.InvPriceLevel",
                c => new
                    {
                        InvPriceLevelID = c.Long(nullable: false, identity: true),
                        PriceLevelCode = c.String(nullable: false, maxLength: 15),
                        PriceLevelName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPriceLevelID);
            
            CreateTable(
                "dbo.InvProductAssemble",
                c => new
                    {
                        InvProductAssembleID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        ProductAssembleID = c.Long(nullable: false),
                        ProductAssembleCode = c.String(nullable: false, maxLength: 25),
                        ProductAssembleUnit = c.String(maxLength: 25),
                        ProductAssembleCostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductAssembleUnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductAssembleQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductAssembleID);
            
            CreateTable(
                "dbo.InvProductBatchNoExpiaryDetail",
                c => new
                    {
                        InvProductBatchNoExpiaryDetailID = c.Long(nullable: false, identity: true),
                        ProductBatchNoExpiaryDetailID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BarCode = c.Long(nullable: false),
                        BatchNo = c.String(nullable: false, maxLength: 40),
                        ExpiryDate = c.DateTime(),
                        LineNo = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductBatchNoExpiaryDetailID);
            
            CreateTable(
                "dbo.InvProductExtendedProperty",
                c => new
                    {
                        InvProductExtendedPropertyID = c.Long(nullable: false, identity: true),
                        ExtendedPropertyCode = c.String(maxLength: 15),
                        ExtendedPropertyName = c.String(maxLength: 50),
                        DataType = c.String(maxLength: 15),
                        Parent = c.String(maxLength: 15),
                        IsAllLocations = c.Boolean(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductExtendedPropertyID);
            
            CreateTable(
                "dbo.InvProductExtendedPropertyValue",
                c => new
                    {
                        InvProductExtendedPropertyValueID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        InvProductExtendedPropertyID = c.Long(nullable: false),
                        InvProductExtendedValueID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductExtendedPropertyValueID);
            
            CreateTable(
                "dbo.InvProductExtendedValue",
                c => new
                    {
                        InvProductExtendedValueID = c.Long(nullable: false, identity: true),
                        InvProductExtendedPropertyID = c.Long(nullable: false),
                        ValueData = c.String(maxLength: 50),
                        ParentValueData = c.String(maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductExtendedValueID);
            
            CreateTable(
                "dbo.InvProductLink",
                c => new
                    {
                        InvProductLinkID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductLinkCode = c.String(maxLength: 25),
                        ProductLinkName = c.String(maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductLinkID);
            
            CreateTable(
                "dbo.InvProductMasterBillingLocationWise",
                c => new
                    {
                        InvProductMasterBillingLocationWiseID = c.Long(nullable: false, identity: true),
                        BillingLocationID = c.Int(nullable: false),
                        InvProductMasterID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        BarCode = c.String(maxLength: 25),
                        BarCode2 = c.String(maxLength: 25),
                        ReferenceCode1 = c.String(maxLength: 25),
                        ReferenceCode2 = c.String(maxLength: 25),
                        ReferenceCode3 = c.String(maxLength: 25),
                        ProductName = c.String(maxLength: 100),
                        NameOnInvoice = c.String(maxLength: 50),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        InvProductTypeID = c.Int(nullable: false),
                        InvKitchenBarID = c.Int(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        PackSize = c.String(maxLength: 25),
                        ProductImage = c.Binary(),
                        CostingMethod = c.String(maxLength: 50),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ReOrderPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        IsPromotion = c.Boolean(nullable: false),
                        IsBundle = c.Boolean(nullable: false),
                        IsFreeIssue = c.Boolean(nullable: false),
                        IsDrayage = c.Boolean(nullable: false),
                        DrayagePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsExpiry = c.Boolean(nullable: false),
                        IsConsignment = c.Boolean(nullable: false),
                        IsCountable = c.Boolean(nullable: false),
                        IsDCS = c.Boolean(nullable: false),
                        DcsID = c.Long(nullable: false),
                        IsTax = c.Boolean(nullable: false),
                        IsSerial = c.Boolean(nullable: false),
                        IsNonExchangeable = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        PackSizeUnitOfMeasureID = c.Long(nullable: false),
                        Margin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesaleMargin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedGP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseLedgerID = c.Long(nullable: false),
                        SalesLedgerID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductMasterBillingLocationWiseID);
            
            CreateTable(
                "dbo.InvProductMaster",
                c => new
                    {
                        InvProductMasterID = c.Long(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        BarCode = c.String(maxLength: 25),
                        BarCode2 = c.String(maxLength: 25),
                        ReferenceCode1 = c.String(maxLength: 25),
                        ReferenceCode2 = c.String(maxLength: 25),
                        ReferenceCode3 = c.String(maxLength: 25),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        NameOnInvoice = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        InvProductTypeID = c.Int(nullable: false),
                        InvKitchenBarID = c.Int(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        PackSize = c.String(nullable: false, maxLength: 25),
                        ProductImage = c.Binary(),
                        CostingMethod = c.String(maxLength: 50),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ReOrderPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        IsPromotion = c.Boolean(nullable: false),
                        IsBundle = c.Boolean(nullable: false),
                        IsFreeIssue = c.Boolean(nullable: false),
                        IsDrayage = c.Boolean(nullable: false),
                        DrayagePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsExpiry = c.Boolean(nullable: false),
                        IsConsignment = c.Boolean(nullable: false),
                        IsCountable = c.Boolean(nullable: false),
                        IsDCS = c.Boolean(nullable: false),
                        DcsID = c.Long(nullable: false),
                        IsTax = c.Boolean(nullable: false),
                        IsSerial = c.Boolean(nullable: false),
                        IsNonExchangeable = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        PackSizeUnitOfMeasureID = c.Long(nullable: false),
                        Margin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesaleMargin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedGP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseLedgerID = c.Long(nullable: false),
                        SalesLedgerID = c.Long(nullable: false),
                        OtherPurchaseLedgerID = c.Long(nullable: false),
                        OtherSalesLedgerID = c.Long(nullable: false),
                        Remark = c.String(maxLength: 150),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductMasterID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfMeasure", t => t.UnitOfMeasureID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.UnitOfMeasureID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierID = c.Long(nullable: false, identity: true),
                        SupplierCode = c.String(nullable: false, maxLength: 15),
                        SupplierTitle = c.Int(nullable: false),
                        SupplierName = c.String(nullable: false, maxLength: 100),
                        SupplierType = c.Int(nullable: false),
                        ContactPersonName = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        BillingAddress1 = c.String(maxLength: 50),
                        BillingAddress2 = c.String(maxLength: 50),
                        BillingAddress3 = c.String(maxLength: 50),
                        BillingTelephone = c.String(nullable: false, maxLength: 50),
                        BillingMobile = c.String(maxLength: 50),
                        BillingFax = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        RepresentativeName = c.String(maxLength: 100),
                        RepresentativeNICNo = c.String(maxLength: 50),
                        PayeeName = c.String(maxLength: 100),
                        DeliveryAddress1 = c.String(maxLength: 50),
                        DeliveryAddress2 = c.String(maxLength: 50),
                        DeliveryAddress3 = c.String(maxLength: 50),
                        DeliveryTelephone = c.String(maxLength: 50),
                        DeliveryMobile = c.String(maxLength: 50),
                        DeliveryFax = c.String(maxLength: 50),
                        SupplierImage = c.Binary(),
                        ReferenceNo = c.String(maxLength: 20),
                        ReferenceSerial = c.String(maxLength: 20),
                        PostalCode = c.String(maxLength: 20),
                        TaxID1 = c.Int(nullable: false),
                        TaxNo1 = c.String(maxLength: 25),
                        TaxID2 = c.Int(nullable: false),
                        TaxNo2 = c.String(maxLength: 25),
                        TaxID3 = c.Int(nullable: false),
                        TaxNo3 = c.String(maxLength: 25),
                        TaxID4 = c.Int(nullable: false),
                        TaxNo4 = c.String(maxLength: 25),
                        TaxID5 = c.Int(nullable: false),
                        TaxNo5 = c.String(maxLength: 25),
                        TaxRegistrationNo = c.String(maxLength: 50),
                        TaxRegistrationName = c.String(maxLength: 100),
                        PaymentMethod = c.Int(nullable: false),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequePeriod = c.Int(nullable: false),
                        PaymentTermID = c.Int(nullable: false),
                        CreditPeriod = c.Int(nullable: false),
                        Remark = c.String(maxLength: 100),
                        ProductBusinessType = c.String(maxLength: 200),
                        SuppliedProducts = c.String(maxLength: 200),
                        OrderCircle = c.Int(nullable: false),
                        SupplierGroupID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        OtherLedgerID = c.Long(nullable: false),
                        TaxIdNo = c.String(maxLength: 50),
                        IsUpload = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        IsSuspended = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID)
                .ForeignKey("dbo.SupplierGroup", t => t.SupplierGroupID)
                .Index(t => t.SupplierGroupID);
            
            CreateTable(
                "dbo.SupplierGroup",
                c => new
                    {
                        SupplierGroupID = c.Int(nullable: false, identity: true),
                        SupplierGroupCode = c.String(nullable: false, maxLength: 20),
                        SupplierGroupName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierGroupID);
            
            CreateTable(
                "dbo.LgsSupplier",
                c => new
                    {
                        LgsSupplierID = c.Long(nullable: false, identity: true),
                        SupplierCode = c.String(nullable: false, maxLength: 15),
                        SupplierTitle = c.Int(nullable: false),
                        SupplierName = c.String(nullable: false, maxLength: 100),
                        SupplierType = c.Int(nullable: false),
                        ContactPersonName = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        BillingAddress1 = c.String(maxLength: 50),
                        BillingAddress2 = c.String(maxLength: 50),
                        BillingAddress3 = c.String(maxLength: 50),
                        BillingTelephone = c.String(nullable: false, maxLength: 50),
                        BillingMobile = c.String(maxLength: 50),
                        BillingFax = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        RepresentativeName = c.String(maxLength: 100),
                        RepresentativeNICNo = c.String(maxLength: 50),
                        PayeeName = c.String(nullable: false, maxLength: 100),
                        DeliveryAddress1 = c.String(maxLength: 50),
                        DeliveryAddress2 = c.String(maxLength: 50),
                        DeliveryAddress3 = c.String(maxLength: 50),
                        DeliveryTelephone = c.String(maxLength: 50),
                        DeliveryMobile = c.String(maxLength: 50),
                        DeliveryFax = c.String(maxLength: 50),
                        SupplierImage = c.Binary(),
                        ReferenceNo = c.String(maxLength: 20),
                        ReferenceSerial = c.String(maxLength: 20),
                        PostalCode = c.String(maxLength: 20),
                        TaxID1 = c.Int(nullable: false),
                        TaxNo1 = c.String(maxLength: 25),
                        TaxID2 = c.Int(nullable: false),
                        TaxNo2 = c.String(maxLength: 25),
                        TaxID3 = c.Int(nullable: false),
                        TaxNo3 = c.String(maxLength: 25),
                        TaxID4 = c.Int(nullable: false),
                        TaxNo4 = c.String(maxLength: 25),
                        TaxID5 = c.Int(nullable: false),
                        TaxNo5 = c.String(maxLength: 25),
                        TaxRegistrationNo = c.String(maxLength: 50),
                        TaxRegistrationName = c.String(maxLength: 100),
                        PaymentMethod = c.Int(nullable: false),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequePeriod = c.Int(nullable: false),
                        PaymentTermID = c.Int(nullable: false),
                        CreditPeriod = c.Int(nullable: false),
                        Remark = c.String(maxLength: 100),
                        ProductBusinessType = c.String(maxLength: 200),
                        SuppliedProducts = c.String(maxLength: 200),
                        OrderCircle = c.Int(nullable: false),
                        SupplierGroupID = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        OtherLedgerID = c.Long(nullable: false),
                        TaxIdNo = c.String(maxLength: 50),
                        IsUpload = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        IsSuspended = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSupplierID)
                .ForeignKey("dbo.SupplierGroup", t => t.SupplierGroupID)
                .Index(t => t.SupplierGroupID);
            
            CreateTable(
                "dbo.LgsProductMaster",
                c => new
                    {
                        LgsProductMasterID = c.Long(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        BarCode = c.String(maxLength: 25),
                        ReferenceCode1 = c.String(maxLength: 25),
                        ReferenceCode2 = c.String(maxLength: 25),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        NameOnInvoice = c.String(nullable: false, maxLength: 50),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        LgsSupplierID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        PackSize = c.String(nullable: false, maxLength: 25),
                        ProductImage = c.Binary(),
                        CostingMethod = c.String(maxLength: 50),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ReOrderPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        IsPromotion = c.Boolean(nullable: false),
                        IsBundle = c.Boolean(nullable: false),
                        IsFreeIssue = c.Boolean(nullable: false),
                        IsDrayage = c.Boolean(nullable: false),
                        DrayagePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsExpiry = c.Boolean(nullable: false),
                        IsConsignment = c.Boolean(nullable: false),
                        IsCountable = c.Boolean(nullable: false),
                        IsDCS = c.Boolean(nullable: false),
                        DcsID = c.Long(nullable: false),
                        IsTax = c.Boolean(nullable: false),
                        IsSerial = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsService = c.Boolean(nullable: false),
                        Remarks = c.String(maxLength: 500),
                        PackSizeUnitOfMeasureID = c.Long(nullable: false),
                        Margin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholesaleMargin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedGP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseLedgerID = c.Long(nullable: false),
                        SalesLedgerID = c.Long(nullable: false),
                        OtherPurchaseLedgerID = c.Long(nullable: false),
                        OtherSalesLedgerID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductMasterID)
                .ForeignKey("dbo.LgsSupplier", t => t.LgsSupplierID, cascadeDelete: true)
                .ForeignKey("dbo.UnitOfMeasure", t => t.UnitOfMeasureID, cascadeDelete: true)
                .Index(t => t.LgsSupplierID)
                .Index(t => t.UnitOfMeasureID);
            
            CreateTable(
                "dbo.UnitOfMeasure",
                c => new
                    {
                        UnitOfMeasureID = c.Long(nullable: false, identity: true),
                        UnitOfMeasureCode = c.String(nullable: false, maxLength: 15),
                        UnitOfMeasureName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitOfMeasureID);
            
            CreateTable(
                "dbo.LgsSupplierProperty",
                c => new
                    {
                        LgsSupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 15),
                        PaymentCollector1Name = c.String(maxLength: 100),
                        PaymentCollector1Designation = c.String(maxLength: 100),
                        PaymentCollector1ReferenceNo = c.String(maxLength: 50),
                        PaymentCollector1TelephoneNo = c.String(maxLength: 50),
                        PaymentCollector1Image = c.Binary(),
                        PaymentCollector2Name = c.String(maxLength: 100),
                        PaymentCollector2Designation = c.String(maxLength: 50),
                        PaymentCollector2ReferenceNo = c.String(maxLength: 50),
                        PaymentCollector2TelephoneNo = c.String(maxLength: 50),
                        PaymentCollector2Image = c.Binary(),
                        IntroducedPerson1Name = c.String(maxLength: 100),
                        IntroducedPerson1Address1 = c.String(maxLength: 50),
                        IntroducedPerson1Address2 = c.String(maxLength: 50),
                        IntroducedPerson1Address3 = c.String(maxLength: 50),
                        IntroducedPerson1TelephoneNo = c.String(maxLength: 50),
                        IntroducedPerson2Name = c.String(maxLength: 100),
                        IntroducedPerson2Address1 = c.String(maxLength: 50),
                        IntroducedPerson2Address2 = c.String(maxLength: 50),
                        IntroducedPerson2Address3 = c.String(maxLength: 50),
                        IntroducedPerson2TelephoneNo = c.String(maxLength: 50),
                        DealingPeriod = c.Long(nullable: false),
                        YearOfBusinessCommencement = c.Int(nullable: false),
                        NoOfEmployees = c.Int(nullable: false),
                        NoOfMachines = c.Int(nullable: false),
                        PercentageOfWHT = c.Int(nullable: false),
                        IncomeTaxFileNo = c.String(maxLength: 50),
                        RemarkByPurchasingDepartment = c.String(maxLength: 200),
                        RemarkByAccountDepartment = c.String(maxLength: 200),
                        IsVatRegistrationCopy = c.Boolean(nullable: false),
                        VatRegistrationCopy = c.Binary(),
                        IsPassportPhotos = c.Boolean(nullable: false),
                        PassportPhotos = c.Binary(),
                        IsCDDCertification = c.Boolean(nullable: false),
                        CDDCertificate = c.Binary(),
                        IsBrandCertification = c.Boolean(nullable: false),
                        BrandCertificate = c.Binary(),
                        IsRefeneceDocumentCopy = c.Boolean(nullable: false),
                        RefeneceDocumentCopy = c.Binary(),
                        IsLicenceToImport = c.Boolean(nullable: false),
                        LicenceToImport = c.Binary(),
                        IsLabCertification = c.Boolean(nullable: false),
                        LabCertificate = c.Binary(),
                        IsBRCCopy = c.Boolean(nullable: false),
                        BRCCopy = c.Binary(),
                        IsDistributorOwnerCopy = c.Boolean(nullable: false),
                        DistributorOwnerCopy = c.Binary(),
                        IsQCCertification = c.Boolean(nullable: false),
                        QCCertificate = c.Binary(),
                        IsSLSISOCertiification = c.Boolean(nullable: false),
                        SLSISOCertiificate = c.Binary(),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSupplierID)
                .ForeignKey("dbo.LgsSupplier", t => t.LgsSupplierID)
                .Index(t => t.LgsSupplierID);
            
            CreateTable(
                "dbo.SupplierProperty",
                c => new
                    {
                        SupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 15),
                        PaymentCollector1Name = c.String(maxLength: 100),
                        PaymentCollector1Designation = c.String(maxLength: 100),
                        PaymentCollector1ReferenceNo = c.String(maxLength: 50),
                        PaymentCollector1TelephoneNo = c.String(maxLength: 50),
                        PaymentCollector1Image = c.Binary(),
                        PaymentCollector2Name = c.String(maxLength: 100),
                        PaymentCollector2Designation = c.String(maxLength: 50),
                        PaymentCollector2ReferenceNo = c.String(maxLength: 50),
                        PaymentCollector2TelephoneNo = c.String(maxLength: 50),
                        PaymentCollector2Image = c.Binary(),
                        IntroducedPerson1Name = c.String(maxLength: 100),
                        IntroducedPerson1Address1 = c.String(maxLength: 50),
                        IntroducedPerson1Address2 = c.String(maxLength: 50),
                        IntroducedPerson1Address3 = c.String(maxLength: 50),
                        IntroducedPerson1TelephoneNo = c.String(maxLength: 50),
                        IntroducedPerson2Name = c.String(maxLength: 100),
                        IntroducedPerson2Address1 = c.String(maxLength: 50),
                        IntroducedPerson2Address2 = c.String(maxLength: 50),
                        IntroducedPerson2Address3 = c.String(maxLength: 50),
                        IntroducedPerson2TelephoneNo = c.String(maxLength: 50),
                        DealingPeriod = c.Long(nullable: false),
                        YearOfBusinessCommencement = c.Int(nullable: false),
                        NoOfEmployees = c.Int(nullable: false),
                        NoOfMachines = c.Int(nullable: false),
                        PercentageOfWHT = c.Int(nullable: false),
                        IncomeTaxFileNo = c.String(maxLength: 50),
                        RemarkByPurchasingDepartment = c.String(maxLength: 200),
                        RemarkByAccountDepartment = c.String(maxLength: 200),
                        IsVatRegistrationCopy = c.Boolean(nullable: false),
                        VatRegistrationCopy = c.Binary(),
                        IsPassportPhotos = c.Boolean(nullable: false),
                        PassportPhotos = c.Binary(),
                        IsCDDCertification = c.Boolean(nullable: false),
                        CDDCertificate = c.Binary(),
                        IsBrandCertification = c.Boolean(nullable: false),
                        BrandCertificate = c.Binary(),
                        IsRefeneceDocumentCopy = c.Boolean(nullable: false),
                        RefeneceDocumentCopy = c.Binary(),
                        IsLicenceToImport = c.Boolean(nullable: false),
                        LicenceToImport = c.Binary(),
                        IsLabCertification = c.Boolean(nullable: false),
                        LabCertificate = c.Binary(),
                        IsBRCCopy = c.Boolean(nullable: false),
                        BRCCopy = c.Binary(),
                        IsDistributorOwnerCopy = c.Boolean(nullable: false),
                        DistributorOwnerCopy = c.Binary(),
                        IsQCCertification = c.Boolean(nullable: false),
                        QCCertificate = c.Binary(),
                        IsSLSISOCertiification = c.Boolean(nullable: false),
                        SLSISOCertiificate = c.Binary(),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID)
                .ForeignKey("dbo.Supplier", t => t.SupplierID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.InvProductPriceChangeDetailDamage",
                c => new
                    {
                        InvProductPriceChangeDetailDamageID = c.Long(nullable: false, identity: true),
                        InvProductPriceChangeHeaderDamageID = c.Long(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        ProductName = c.String(maxLength: 100),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        OldCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        NewProductID = c.Long(nullable: false),
                        NewProductCode = c.String(maxLength: 25),
                        NewProductName = c.String(maxLength: 100),
                        EffectFromDate = c.DateTime(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        LineNo = c.Long(nullable: false),
                        Process = c.Int(nullable: false),
                        DamageType = c.String(maxLength: 100),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductPriceChangeDetailDamageID);
            
            CreateTable(
                "dbo.InvProductPriceChangeDetail",
                c => new
                    {
                        InvProductPriceChangeDetailID = c.Long(nullable: false, identity: true),
                        InvProductPriceChangeHeaderID = c.Long(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        ProductName = c.String(maxLength: 100),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        OldCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewSellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        EffectFromDate = c.DateTime(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        LineNo = c.Long(nullable: false),
                        Process = c.Int(nullable: false),
                        BarCode = c.Long(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        PriceChangeRemark = c.String(),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductPriceChangeDetailID);
            
            CreateTable(
                "dbo.InvProductPriceChangeHeaderDamage",
                c => new
                    {
                        InvProductPriceChangeHeaderDamageID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        EffectFromDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        TogNO = c.String(maxLength: 20),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductPriceChangeHeaderDamageID);
            
            CreateTable(
                "dbo.InvProductPriceChangeHeader",
                c => new
                    {
                        InvProductPriceChangeHeaderID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        EffectFromDate = c.DateTime(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        IsUpLoad = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductPriceChangeHeaderID);
            
            CreateTable(
                "dbo.InvProductPriceLink",
                c => new
                    {
                        InvProductPriceLinkID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        CreatedLocation = c.String(maxLength: 15),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductPriceLinkID);
            
            CreateTable(
                "dbo.InvProductProperty",
                c => new
                    {
                        InvProductPropertyID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        CostPrice = c.Long(nullable: false),
                        SellingPrice = c.Long(nullable: false),
                        Brand = c.String(),
                        Collar = c.String(),
                        Colour = c.String(),
                        Country = c.String(),
                        Cut = c.String(),
                        Embelishment = c.String(),
                        Fit = c.String(),
                        Heel = c.String(),
                        Length = c.String(),
                        Material = c.String(),
                        Neck = c.String(),
                        PatternNo = c.String(),
                        ProductFeature = c.String(),
                        Shop = c.String(),
                        Size = c.String(),
                        Sleeve = c.String(),
                        Texture = c.String(),
                    })
                .PrimaryKey(t => t.InvProductPropertyID);
            
            CreateTable(
                "dbo.InvProductSerialNoDetail",
                c => new
                    {
                        InvProductSerialNoDetailID = c.Long(nullable: false, identity: true),
                        ProductSerialNoDetailID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ExpiryDate = c.DateTime(),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        SerialNo = c.String(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        BatchNo = c.String(maxLength: 40),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductSerialNoDetailID);
            
            CreateTable(
                "dbo.InvProductSerialNo",
                c => new
                    {
                        InvProductSerialNoID = c.Long(nullable: false, identity: true),
                        ProductSerialNoID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 40),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ExpiryDate = c.DateTime(),
                        SerialNo = c.String(nullable: false),
                        SerialNoStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductSerialNoID);
            
            CreateTable(
                "dbo.InvProductStockMaster",
                c => new
                    {
                        InvProductStockMasterID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductStockMasterID);
            
            CreateTable(
                "dbo.InvProductSupplierLink",
                c => new
                    {
                        InvProductSupplierLinkID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 50),
                        DocumentDate = c.DateTime(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedGP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductSupplierLinkID);
            
            CreateTable(
                "dbo.InvProductType",
                c => new
                    {
                        InvProductTypeID = c.Int(nullable: false, identity: true),
                        ProductTypeCode = c.String(nullable: false, maxLength: 15),
                        ProductTypeName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        PackageType = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductTypeID);
            
            CreateTable(
                "dbo.InvProductUnitConversion",
                c => new
                    {
                        InvProductUnitConversionID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        LineNo = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvProductUnitConversionID);
            
            CreateTable(
                "dbo.InvPromotionDetailsAllowLocations",
                c => new
                    {
                        InvPromotionDetailsAllowLocationsID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        PromotionLocationID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsAllowLocationsID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionMaster",
                c => new
                    {
                        InvPromotionMasterID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        PromotionCode = c.String(nullable: false, maxLength: 15),
                        PromotionName = c.String(nullable: false, maxLength: 50),
                        IsAutoApply = c.Boolean(nullable: false),
                        PromotionTypeID = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsMonday = c.Boolean(nullable: false),
                        IsTuesday = c.Boolean(nullable: false),
                        IsWednesday = c.Boolean(nullable: false),
                        IsThuresday = c.Boolean(nullable: false),
                        IsFriday = c.Boolean(nullable: false),
                        IsSaturday = c.Boolean(nullable: false),
                        IsSunday = c.Boolean(nullable: false),
                        IsMondayTime = c.Boolean(nullable: false),
                        IsTuesdayTime = c.Boolean(nullable: false),
                        IsWednesdayTime = c.Boolean(nullable: false),
                        IsThuresdayTime = c.Boolean(nullable: false),
                        IsFridayTime = c.Boolean(nullable: false),
                        IsSaturdayTime = c.Boolean(nullable: false),
                        IsSundayTime = c.Boolean(nullable: false),
                        MondayStartTime = c.DateTime(),
                        MondayEndTime = c.DateTime(),
                        TuesdayStartTime = c.DateTime(),
                        TuesdayEndTime = c.DateTime(),
                        WednesdayStartTime = c.DateTime(),
                        WednesdayEndTime = c.DateTime(),
                        ThuresdayStartTime = c.DateTime(),
                        ThuresdayEndTime = c.DateTime(),
                        FridayStartTime = c.DateTime(),
                        FridayEndTime = c.DateTime(),
                        SaturdayStartTime = c.DateTime(),
                        SaturdayEndTime = c.DateTime(),
                        SundayStartTime = c.DateTime(),
                        SundayEndTime = c.DateTime(),
                        PaymentMethodID = c.Int(nullable: false),
                        IsProvider = c.Boolean(nullable: false),
                        IsAllLocations = c.Boolean(nullable: false),
                        IsAllType = c.Boolean(nullable: false),
                        IsValueRange = c.Boolean(nullable: false),
                        MinimumValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        DisplayMessage = c.String(maxLength: 150),
                        CashierMessage = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        IsRaffle = c.Boolean(nullable: false),
                        IsIncreseQty = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsAllowTypes",
                c => new
                    {
                        InvPromotionDetailsAllowTypesID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsAllowTypesID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsBuyXCategory",
                c => new
                    {
                        InvPromotionDetailsBuyXCategoryID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        BuyCategoryID = c.Long(nullable: false),
                        BuyQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsBuyXCategoryID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsBuyXDepartment",
                c => new
                    {
                        InvPromotionDetailsBuyXDepartmentID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        BuyDepartmentID = c.Long(nullable: false),
                        BuyQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsBuyXDepartmentID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsBuyXProduct",
                c => new
                    {
                        InvPromotionDetailsBuyXProductID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        BuyProductID = c.Long(nullable: false),
                        BuyUnitOfMeasureID = c.Long(nullable: false),
                        BuyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsBuyXProductID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsBuyXSubCategory",
                c => new
                    {
                        InvPromotionDetailsBuyXSubCategoryID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        BuySubCategoryID = c.Long(nullable: false),
                        BuyQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsBuyXSubCategoryID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsBuyXSubCategory2",
                c => new
                    {
                        InvPromotionDetailsBuyXSubCategory2ID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        BuySubCategory2ID = c.Long(nullable: false),
                        BuyQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsBuyXSubCategory2ID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsCategoryDis",
                c => new
                    {
                        InvPromotionDetailsCategoryDisID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Points = c.Long(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsCategoryDisID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsDepartmentDis",
                c => new
                    {
                        InvPromotionDetailsDepartmentDisID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DepartmentID = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Points = c.Long(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsDepartmentDisID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsGetYDetails",
                c => new
                    {
                        InvPromotionDetailsGetYDetailsID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        GetProductID = c.Long(nullable: false),
                        GetUnitOfMeasureID = c.Long(nullable: false),
                        GetRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GetQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        GetPoints = c.Long(nullable: false),
                        GetDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GetDiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsGetYDetailsID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsProductDis",
                c => new
                    {
                        InvPromotionDetailsProductDisID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Points = c.Long(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsProductDisID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsSubCategory2Dis",
                c => new
                    {
                        InvPromotionDetailsSubCategory2DisID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Points = c.Long(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsSubCategory2DisID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsSubCategoryDis",
                c => new
                    {
                        InvPromotionDetailsSubCategoryDisID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Points = c.Long(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsSubCategoryDisID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionDetailsSubTotal",
                c => new
                    {
                        InvPromotionDetailsSubTotalID = c.Long(nullable: false, identity: true),
                        InvPromotionMasterID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCombined = c.Boolean(nullable: false),
                        IsValidForGV = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionDetailsSubTotalID)
                .ForeignKey("dbo.InvPromotionMaster", t => t.InvPromotionMasterID, cascadeDelete: true)
                .Index(t => t.InvPromotionMasterID);
            
            CreateTable(
                "dbo.InvPromotionType",
                c => new
                    {
                        InvPromotionTypeID = c.Long(nullable: false, identity: true),
                        PromotionTypeCode = c.String(nullable: false, maxLength: 15),
                        PromotionTypeName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPromotionTypeID);
            
            CreateTable(
                "dbo.InvPurchase",
                c => new
                    {
                        InvPurchaseID = c.Long(nullable: false, identity: true),
                        PurchaseID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        CompanyCode = c.String(nullable: false, maxLength: 15),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(nullable: false, maxLength: 15),
                        LocationName = c.String(maxLength: 50),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 15),
                        SupplierName = c.String(maxLength: 100),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentCode = c.String(maxLength: 15),
                        DepartmentName = c.String(maxLength: 50),
                        CategoryCode = c.String(maxLength: 15),
                        CategoryName = c.String(maxLength: 50),
                        SubCategoryCode = c.String(maxLength: 15),
                        SubCategoryName = c.String(maxLength: 50),
                        SubCategory2Code = c.String(maxLength: 15),
                        SubCategory2Name = c.String(maxLength: 50),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        ProductName = c.String(maxLength: 100),
                        BarCode = c.String(maxLength: 25),
                        BatchNo = c.String(nullable: false, maxLength: 40),
                        ExpiryDate = c.DateTime(),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(nullable: false, maxLength: 50),
                        PackSize = c.String(nullable: false, maxLength: 25),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholeSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsFreeIssue = c.Boolean(nullable: false),
                        IsDispatch = c.Boolean(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPurchaseID);
            
            CreateTable(
                "dbo.InvPurchaseDetail",
                c => new
                    {
                        InvPurchaseDetailID = c.Long(nullable: false, identity: true),
                        PurchaseDetailID = c.Long(nullable: false),
                        InvPurchaseHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        IsExpiry = c.Boolean(nullable: false),
                        ExpiryDate = c.DateTime(),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        ScanDocument = c.Binary(),
                        DocumentDate = c.DateTime(nullable: false),
                        ProductRemark = c.String(maxLength: 200),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPurchaseDetailID);
            
            CreateTable(
                "dbo.InvPurchaseHeader",
                c => new
                    {
                        InvPurchaseHeaderID = c.Long(nullable: false, identity: true),
                        PurchaseHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherChargers = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        SupplierInvoiceNo = c.String(maxLength: 20),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        ReturnTypeID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPurchaseHeaderID);
            
            CreateTable(
                "dbo.InvPurchaseOrderDetail",
                c => new
                    {
                        InvPurchaseOrderDetailID = c.Long(nullable: false, identity: true),
                        PurchaseOrderDetailID = c.Long(nullable: false),
                        InvPurchaseOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceFreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackSize = c.String(),
                        PackID = c.Int(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        ScanDocument = c.Binary(),
                        ProductRemark = c.String(maxLength: 200),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPurchaseOrderDetailID)
                .ForeignKey("dbo.InvPurchaseOrderHeader", t => t.InvPurchaseOrderHeaderID, cascadeDelete: true)
                .Index(t => t.InvPurchaseOrderHeaderID);
            
            CreateTable(
                "dbo.InvPurchaseOrderHeader",
                c => new
                    {
                        InvPurchaseOrderHeaderID = c.Long(nullable: false, identity: true),
                        PurchaseOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        ExpectedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        PaymentExpectedDate = c.DateTime(nullable: false),
                        ValidityPeriod = c.Int(nullable: false),
                        IsConsignmentBasis = c.Boolean(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Addition = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequestedBy = c.String(maxLength: 50),
                        DeliveryLocationID = c.Int(nullable: false),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDetail = c.String(maxLength: 500),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        LastAuthorizedBy = c.String(maxLength: 50),
                        IsAuthorized = c.Boolean(nullable: false),
                        LastAuthorizedDate = c.DateTime(),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvPurchaseOrderHeaderID);
            
            CreateTable(
                "dbo.InvQuotationDetail",
                c => new
                    {
                        InvQuotationDetailID = c.Long(nullable: false, identity: true),
                        QuotationDetailID = c.Long(nullable: false),
                        InvQuotationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceFreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvQuotationDetailID);
            
            CreateTable(
                "dbo.InvQuotationHeader",
                c => new
                    {
                        InvQuotationHeaderID = c.Long(nullable: false, identity: true),
                        QuotationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        CustomerID = c.Long(nullable: false),
                        InvSalesPersonID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryLocationID = c.Int(nullable: false),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDetail = c.String(maxLength: 500),
                        ReferenceDocumentID = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvQuotationHeaderID);
            
            CreateTable(
                "dbo.InvReportBinCard",
                c => new
                    {
                        InvReportBinCardID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Long(nullable: false),
                        DocumentDocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentDescription = c.String(nullable: false, maxLength: 50),
                        ReferenceID = c.Long(nullable: false),
                        ReferenceIDCode = c.String(nullable: false, maxLength: 15),
                        ReferenceIDName = c.String(nullable: false, maxLength: 100),
                        ReferenceNo = c.String(maxLength: 20),
                        PartyReferenceNo = c.String(maxLength: 20),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        BatchNo = c.String(maxLength: 50),
                        ExpiryDate = c.DateTime(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        InQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OutQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Remark = c.String(maxLength: 150),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvReportBinCardID);
            
            CreateTable(
                "dbo.InvReturnType",
                c => new
                    {
                        InvReturnTypeID = c.Int(nullable: false, identity: true),
                        ReturnType = c.String(maxLength: 50),
                        RelatedFormID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvReturnTypeID);
            
            CreateTable(
                "dbo.InvSales",
                c => new
                    {
                        InvSalesID = c.Long(nullable: false, identity: true),
                        SalesID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        CompanyCode = c.String(nullable: false, maxLength: 15),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(nullable: false, maxLength: 15),
                        LocationName = c.String(maxLength: 50),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        TransactionTime = c.DateTime(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        CustomerCode = c.String(nullable: false, maxLength: 15),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        SupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 15),
                        SupplierName = c.String(maxLength: 100),
                        SalesPersonID = c.Long(nullable: false),
                        SalesPersonCode = c.String(maxLength: 15),
                        SalesPersonName = c.String(maxLength: 50),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentID = c.Long(nullable: false),
                        DepartmentCode = c.String(maxLength: 15),
                        DepartmentName = c.String(maxLength: 50),
                        CategoryID = c.Long(nullable: false),
                        CategoryCode = c.String(maxLength: 15),
                        CategoryName = c.String(maxLength: 50),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategoryCode = c.String(maxLength: 15),
                        SubCategoryName = c.String(maxLength: 50),
                        SubCategory2ID = c.Long(nullable: false),
                        SubCategory2Code = c.String(maxLength: 15),
                        SubCategory2Name = c.String(maxLength: 50),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        ProductName = c.String(maxLength: 100),
                        BarCode = c.String(maxLength: 25),
                        BatchNo = c.String(nullable: false, maxLength: 40),
                        ExpiryDate = c.DateTime(),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(nullable: false, maxLength: 50),
                        PackSize = c.String(nullable: false, maxLength: 25),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholeSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsFreeIssue = c.Boolean(nullable: false),
                        TerminalNo = c.String(maxLength: 10),
                        IsDispatch = c.Boolean(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        IsBackOffice = c.Boolean(nullable: false),
                        Zno = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSalesID);
            
            CreateTable(
                "dbo.InvSalesDetail",
                c => new
                    {
                        InvSalesDetailID = c.Long(nullable: false, identity: true),
                        SalesDetailID = c.Long(nullable: false),
                        InvSalesHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 50),
                        BarCodeFull = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(maxLength: 25),
                        ExpiryDate = c.DateTime(),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        IssuedQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceFreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1 = c.Int(nullable: false),
                        IDis1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1CashierID = c.Long(nullable: false),
                        IDI2 = c.Int(nullable: false),
                        IDis2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI2CashierID = c.Long(nullable: false),
                        IDI3 = c.Int(nullable: false),
                        IDis3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI3CashierID = c.Long(nullable: false),
                        IDI4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDis4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI4CashierID = c.Long(nullable: false),
                        IDI5 = c.Int(nullable: false),
                        IDis5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI5CashierID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSDis = c.Boolean(nullable: false),
                        SDNo = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                        SDIs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDisCashierID = c.Long(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        SalesmanID = c.Long(nullable: false),
                        CashierID = c.Long(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        ShiftNo = c.Int(nullable: false),
                        IsRecall = c.Boolean(nullable: false),
                        RecallNo = c.String(maxLength: 20),
                        RecallAdv = c.Boolean(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTax = c.Boolean(nullable: false),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStock = c.Boolean(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DispatchLocationID = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsUpLoad = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSalesDetailID);
            
            CreateTable(
                "dbo.InvSalesHeader",
                c => new
                    {
                        InvSalesHeaderID = c.Long(nullable: false, identity: true),
                        SalesHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        SalesPersonID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherChargers = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethodID = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        InvReturnTypeID = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ZNo = c.Long(nullable: false),
                        IsDispatch = c.Boolean(nullable: false),
                        TransStatus = c.Int(nullable: false),
                        RecallDocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSalesHeaderID);
            
            CreateTable(
                "dbo.InvSalesPayment",
                c => new
                    {
                        InvSalesPaymentID = c.Long(nullable: false, identity: true),
                        RowNo = c.Long(nullable: false),
                        PayTypeID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDate = c.DateTime(nullable: false),
                        Receipt = c.String(),
                        LocationID = c.Long(nullable: false),
                        CashierID = c.Long(nullable: false),
                        UnitNo = c.Long(nullable: false),
                        BillTypeID = c.Long(nullable: false),
                        RefNo = c.String(),
                        BankId = c.Long(nullable: false),
                        ChequeDate = c.DateTime(nullable: false),
                        IsRecallAdv = c.Boolean(nullable: false),
                        RecallNo = c.String(),
                        Descrip = c.String(),
                        EnCodeName = c.String(),
                        UpdatedBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSalesPaymentID);
            
            CreateTable(
                "dbo.InvSalesPerson",
                c => new
                    {
                        InvSalesPersonID = c.Long(nullable: false, identity: true),
                        SalesPersonCode = c.String(nullable: false, maxLength: 15),
                        SalesPersonName = c.String(nullable: false, maxLength: 50),
                        LocationID = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        ReferenceNo = c.String(nullable: false, maxLength: 25),
                        SalesPersonTypeID = c.Int(nullable: false),
                        Remark = c.String(maxLength: 100),
                        Address1 = c.String(nullable: false, maxLength: 100),
                        Address2 = c.String(nullable: false, maxLength: 100),
                        Address3 = c.String(maxLength: 100),
                        Email = c.String(),
                        Telephone = c.String(),
                        Mobile = c.String(nullable: false),
                        Image = c.Binary(),
                        IsDelete = c.Boolean(nullable: false),
                        CommissionSchemaID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSalesPersonID);
            
            CreateTable(
                "dbo.InvSampleInDetail",
                c => new
                    {
                        InvSampleInDetailID = c.Long(nullable: false, identity: true),
                        SampleDetailID = c.Long(nullable: false),
                        InvSampleInHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitID = c.Long(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSampleInDetailID);
            
            CreateTable(
                "dbo.InvSampleInHeader",
                c => new
                    {
                        InvSampleInHeaderID = c.Long(nullable: false, identity: true),
                        SampleHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceLocationID = c.Long(nullable: false),
                        IssuedTo = c.String(maxLength: 100),
                        DeliveryPerson = c.String(maxLength: 100),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Balanced = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSampleInHeaderID);
            
            CreateTable(
                "dbo.InvSampleOutDetail",
                c => new
                    {
                        InvSampleOutDetailID = c.Long(nullable: false, identity: true),
                        SampleDetailID = c.Long(nullable: false),
                        InvSampleOutHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitID = c.Long(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSampleOutDetailID);
            
            CreateTable(
                "dbo.InvSampleOutHeader",
                c => new
                    {
                        InvSampleOutHeaderID = c.Long(nullable: false, identity: true),
                        SampleHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        IssuedTo = c.String(maxLength: 100),
                        DeliveryPerson = c.String(maxLength: 100),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        TotalBalancedQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Balanced = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        ReferenceNo = c.String(maxLength: 20),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSampleOutHeaderID);
            
            CreateTable(
                "dbo.InvScanner",
                c => new
                    {
                        InvScannerID = c.Long(nullable: false, identity: true),
                        ScannerPrefix = c.String(maxLength: 10),
                        ScannerName = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                        ScannerStatus = c.Int(nullable: false),
                        DocumentNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvScannerID);
            
            CreateTable(
                "dbo.InvScannerData",
                c => new
                    {
                        InvScannerDataID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 25),
                        DocumentDate = c.DateTime(nullable: false),
                        ScannerID = c.Int(nullable: false),
                        BarCode = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        OriginalDocumentID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvScannerDataID);
            
            CreateTable(
                "dbo.InvSize",
                c => new
                    {
                        InvSizeID = c.Long(nullable: false, identity: true),
                        SizeCode = c.String(nullable: false, maxLength: 15),
                        SizeName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSizeID);
            
            CreateTable(
                "dbo.InvStockAdjustmentDetail",
                c => new
                    {
                        InvStockAdjustmentDetailID = c.Long(nullable: false, identity: true),
                        StockAdjustmentDetailID = c.Long(nullable: false),
                        InvStockAdjustmentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(),
                        StockAdjustmentMode = c.Int(nullable: false),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BatchQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ExcessQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ShortageQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OverWriteQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCostExcessQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCostShortageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCostCurrentQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(maxLength: 50),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpiryDate = c.DateTime(),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        CostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvStockAdjustmentDetailID);
            
            CreateTable(
                "dbo.InvStockAdjustmentHeader",
                c => new
                    {
                        InvStockAdjustmentHeaderID = c.Long(nullable: false, identity: true),
                        StockAdjustmentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        TotalCostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSellingtValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        ReferenceNo = c.String(maxLength: 20),
                        StockAdjustmentMode = c.Int(nullable: false),
                        StockAdjustmentLayer = c.Int(nullable: false),
                        Narration = c.String(maxLength: 500),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvStockAdjustmentHeaderID);
            
            CreateTable(
                "dbo.InvSubCategory2BillingLocationWise",
                c => new
                    {
                        InvSubCategory2BillingLocationWiseID = c.Long(nullable: false, identity: true),
                        BillingLocationID = c.Int(nullable: false),
                        InvSubCategory2ID = c.Long(nullable: false),
                        InvSubCategoryID = c.Long(nullable: false),
                        SubCategory2Code = c.String(nullable: false, maxLength: 15),
                        SubCategory2Name = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        IsSelect = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSubCategory2BillingLocationWiseID);
            
            CreateTable(
                "dbo.InvSubCategoryBillingLocationWise",
                c => new
                    {
                        InvSubCategoryBillingLocationWiseID = c.Long(nullable: false, identity: true),
                        BillingLocationID = c.Int(nullable: false),
                        InvSubCategoryID = c.Long(nullable: false),
                        InvCategoryID = c.Long(nullable: false),
                        SubCategoryCode = c.String(nullable: false, maxLength: 15),
                        SubCategoryName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsSelect = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvSubCategoryBillingLocationWiseID);
            
            CreateTable(
                "dbo.InvTempGrossProfit",
                c => new
                    {
                        InvTempGrossProfitID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 20),
                        ProductName = c.String(maxLength: 100),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(maxLength: 50),
                        LocationName = c.String(maxLength: 100),
                        DepartmentID = c.Long(nullable: false),
                        DepartmentCode = c.String(maxLength: 20),
                        DepartmentName = c.String(maxLength: 100),
                        CategoryID = c.Long(nullable: false),
                        CategoryCode = c.String(maxLength: 20),
                        CategoryName = c.String(maxLength: 100),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategoryCode = c.String(maxLength: 20),
                        SubCategoryName = c.String(maxLength: 100),
                        SubCategory2ID = c.Long(nullable: false),
                        SubCategory2Code = c.String(maxLength: 20),
                        SubCategory2Name = c.String(maxLength: 100),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossSalesAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostVsSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvTempGrossProfitID);
            
            CreateTable(
                "dbo.InvTmpProductStockDetails",
                c => new
                    {
                        InvTmpProductStockDetailsID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ToLocationName = c.String(maxLength: 50),
                        GivenDate = c.DateTime(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 20),
                        ProductName = c.String(maxLength: 100),
                        TransactionType = c.Int(nullable: false),
                        TransactionNo = c.String(maxLength: 20),
                        BatchNo = c.String(maxLength: 25),
                        TransactionDate = c.DateTime(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        StockQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty1 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty2 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty3 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty4 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty5 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty6 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty7 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty8 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty9 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty10 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UserID = c.Long(nullable: false),
                        UniqueID = c.Long(nullable: false),
                        GrossProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvTmpProductStockDetailsID);
            
            CreateTable(
                "dbo.InvTmpReportDetail",
                c => new
                    {
                        InvTmpReportDetailID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        UserID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        UnitNo = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 20),
                        SupplierName = c.String(maxLength: 100),
                        CustomerID = c.Long(nullable: false),
                        CustomerCode = c.String(maxLength: 20),
                        CustomerName = c.String(maxLength: 100),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 20),
                        ProductName = c.String(maxLength: 100),
                        CategoryID = c.Long(nullable: false),
                        CategoryCode = c.String(maxLength: 20),
                        CategoryName = c.String(maxLength: 100),
                        DepartmentID = c.Long(nullable: false),
                        DepartmentCode = c.String(maxLength: 20),
                        DepartmentName = c.String(maxLength: 100),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategoryCode = c.String(maxLength: 20),
                        SubCategoryName = c.String(maxLength: 100),
                        SubCategory2ID = c.Long(nullable: false),
                        SubCategory2Code = c.String(maxLength: 20),
                        SubCategory2Name = c.String(maxLength: 100),
                        BatchNo = c.String(maxLength: 25),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty01 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value01 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty02 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value02 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty03 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value03 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty04 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value04 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty05 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value05 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty06 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value06 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty07 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value07 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty08 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value08 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty09 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value09 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty10 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty11 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value11 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty12 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value12 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty13 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value13 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty14 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value14 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty15 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value15 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty16 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value16 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty17 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value17 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty18 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value18 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty19 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value19 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty20 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value20 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty21 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty22 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value22 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty23 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value23 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty24 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value24 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty25 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value25 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty26 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value26 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty27 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value27 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty28 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value28 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty29 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value29 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty30 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Value30 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ext1 = c.String(maxLength: 50),
                        Ext2 = c.String(maxLength: 50),
                        Ext3 = c.String(maxLength: 50),
                        Ext4 = c.String(maxLength: 50),
                        Ext5 = c.String(maxLength: 50),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvTmpReportDetailID);
            
            CreateTable(
                "dbo.InvTransferNoteDetail",
                c => new
                    {
                        InvTransferNoteDetailID = c.Long(nullable: false, identity: true),
                        TransferNoteDetailID = c.Long(nullable: false),
                        TransferNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        BatchExpiryDate = c.DateTime(nullable: false),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToLocationID = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvTransferNoteDetailID);
            
            CreateTable(
                "dbo.InvTransferNoteHeader",
                c => new
                    {
                        InvTransferNoteHeaderID = c.Long(nullable: false, identity: true),
                        TransferNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        TransferTypeID = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        PosReferenceNo = c.String(maxLength: 10),
                        ToLocationID = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvTransferNoteHeaderID);
            
            CreateTable(
                "dbo.InvTransferType",
                c => new
                    {
                        InvTransferTypeID = c.Int(nullable: false, identity: true),
                        TransferType = c.String(maxLength: 25),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvTransferTypeID);
            
            CreateTable(
                "dbo.JobClass",
                c => new
                    {
                        JobClassID = c.Long(nullable: false, identity: true),
                        JobClassCode = c.String(nullable: false, maxLength: 15),
                        JobClassName = c.String(nullable: false, maxLength: 100),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobClassID);
            
            CreateTable(
                "dbo.LgsCategory",
                c => new
                    {
                        LgsCategoryID = c.Long(nullable: false, identity: true),
                        LgsDepartmentID = c.Long(nullable: false),
                        CategoryCode = c.String(nullable: false, maxLength: 15),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsCategoryID)
                .ForeignKey("dbo.LgsDepartment", t => t.LgsDepartmentID, cascadeDelete: true)
                .Index(t => t.LgsDepartmentID);
            
            CreateTable(
                "dbo.LgsDepartment",
                c => new
                    {
                        LgsDepartmentID = c.Long(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 15),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsDepartmentID);
            
            CreateTable(
                "dbo.LgsSubCategory",
                c => new
                    {
                        LgsSubCategoryID = c.Long(nullable: false, identity: true),
                        LgsCategoryID = c.Long(nullable: false),
                        SubCategoryCode = c.String(nullable: false, maxLength: 15),
                        SubCategoryName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSubCategoryID)
                .ForeignKey("dbo.LgsCategory", t => t.LgsCategoryID, cascadeDelete: true)
                .Index(t => t.LgsCategoryID);
            
            CreateTable(
                "dbo.LgsSubCategory2",
                c => new
                    {
                        LgsSubCategory2ID = c.Long(nullable: false, identity: true),
                        LgsSubCategoryID = c.Long(nullable: false),
                        SubCategory2Code = c.String(nullable: false, maxLength: 15),
                        SubCategory2Name = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSubCategory2ID)
                .ForeignKey("dbo.LgsSubCategory", t => t.LgsSubCategoryID, cascadeDelete: true)
                .Index(t => t.LgsSubCategoryID);
            
            CreateTable(
                "dbo.LgsMaintenanceJobAssignEmployeeDetail",
                c => new
                    {
                        LgsMaintenanceJobAssignEmployeeDetailID = c.Long(nullable: false, identity: true),
                        MaintenanceJobAssignEmployeeDetailID = c.Long(nullable: false),
                        LgsMaintenanceJobAssignHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        EmployeeCode = c.String(nullable: false, maxLength: 15),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaintenanceJobAssignEmployeeDetailID)
                .ForeignKey("dbo.LgsMaintenanceJobAssignHeader", t => t.LgsMaintenanceJobAssignHeaderID, cascadeDelete: true)
                .Index(t => t.LgsMaintenanceJobAssignHeaderID);
            
            CreateTable(
                "dbo.LgsMaintenanceJobAssignHeader",
                c => new
                    {
                        LgsMaintenanceJobAssignHeaderID = c.Long(nullable: false, identity: true),
                        MaintenanceJobAssignHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        DiliveryDate = c.DateTime(nullable: false),
                        RequestedBy = c.String(maxLength: 50),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaintenanceJobAssignHeaderID);
            
            CreateTable(
                "dbo.LgsMaintenanceJobAssignProductDetail",
                c => new
                    {
                        LgsMaintenanceJobAssignProductDetailID = c.Long(nullable: false, identity: true),
                        MaintenanceJobAssignProductDetailID = c.Long(nullable: false),
                        LgsMaintenanceJobAssignHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        PackSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        UnitOfMeasure = c.String(maxLength: 5),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaintenanceJobAssignProductDetailID)
                .ForeignKey("dbo.LgsMaintenanceJobAssignHeader", t => t.LgsMaintenanceJobAssignHeaderID, cascadeDelete: true)
                .Index(t => t.LgsMaintenanceJobAssignHeaderID);
            
            CreateTable(
                "dbo.LgsMaintenanceJobRequisitionHeader",
                c => new
                    {
                        LgsMaintenanceJobRequisitionHeaderID = c.Long(nullable: false, identity: true),
                        MaintenanceJobRequisitionHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        ExpectedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        RequestedBy = c.String(maxLength: 50),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        JobDescription = c.String(maxLength: 500),
                        DocumentStatus = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        IsAssigned = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaintenanceJobRequisitionHeaderID);
            
            CreateTable(
                "dbo.LgsMaterialAllocationDetail",
                c => new
                    {
                        LgsMaterialAllocationDetailID = c.Long(nullable: false, identity: true),
                        MaterialAllocationDetailID = c.Long(nullable: false),
                        LgsMaterialAllocationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        RequestLocationID = c.Int(nullable: false),
                        RequestLocationCode = c.String(),
                        RequestNo = c.String(maxLength: 20),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        PackSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        UnitOfMeasure = c.String(maxLength: 5),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaterialAllocationDetailID)
                .ForeignKey("dbo.LgsMaterialAllocationHeader", t => t.LgsMaterialAllocationHeaderID, cascadeDelete: true)
                .Index(t => t.LgsMaterialAllocationHeaderID);
            
            CreateTable(
                "dbo.LgsMaterialAllocationHeader",
                c => new
                    {
                        LgsMaterialAllocationHeaderID = c.Long(nullable: false, identity: true),
                        MaterialAllocationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaterialAllocationHeaderID);
            
            CreateTable(
                "dbo.LgsMaterialConsumptionHeader",
                c => new
                    {
                        LgsMaterialConsumptionHeaderID = c.Long(nullable: false, identity: true),
                        MaterialConsumptionHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaterialConsumptionHeaderID);
            
            CreateTable(
                "dbo.LgsMaterialConsumptionDetail",
                c => new
                    {
                        LgsMaterialConsumptionDetailID = c.Long(nullable: false, identity: true),
                        MaterialConsumptionDetailID = c.Long(nullable: false),
                        LgsMaterialConsumptionHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        PackSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        UnitOfMeasure = c.String(maxLength: 5),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaterialConsumptionDetailID)
                .ForeignKey("dbo.LgsMaterialConsumptionHeader", t => t.LgsMaterialConsumptionHeaderID, cascadeDelete: true)
                .Index(t => t.LgsMaterialConsumptionHeaderID);
            
            CreateTable(
                "dbo.LgsMaterialRequestDetail",
                c => new
                    {
                        LgsMaterialRequestDetailID = c.Long(nullable: false, identity: true),
                        MaterialRequestDetailID = c.Long(nullable: false),
                        LgsMaterialRequestHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 25),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        PackSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        UnitOfMeasure = c.String(maxLength: 5),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaterialRequestDetailID)
                .ForeignKey("dbo.LgsMaterialRequestHeader", t => t.LgsMaterialRequestHeaderID, cascadeDelete: true)
                .Index(t => t.LgsMaterialRequestHeaderID);
            
            CreateTable(
                "dbo.LgsMaterialRequestHeader",
                c => new
                    {
                        LgsMaterialRequestHeaderID = c.Long(nullable: false, identity: true),
                        MaterialRequestHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        ValidityPeriod = c.Int(nullable: false),
                        DiliveryDate = c.DateTime(nullable: false),
                        RequestedBy = c.String(maxLength: 50),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        Viewed = c.Boolean(nullable: false),
                        IsExpired = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsMaterialRequestHeaderID);
            
            CreateTable(
                "dbo.LgsProductBatchNoExpiaryDetail",
                c => new
                    {
                        LgsProductBatchNoExpiaryDetailID = c.Long(nullable: false, identity: true),
                        ProductBatchNoExpiaryDetailID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BarCode = c.Long(nullable: false),
                        BatchNo = c.String(nullable: false, maxLength: 40),
                        ExpiryDate = c.DateTime(),
                        LineNo = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductBatchNoExpiaryDetailID);
            
            CreateTable(
                "dbo.LgsProductExtendedPropertyValue",
                c => new
                    {
                        LgsProductExtendedPropertyValueID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        LgsProductExtendedPropertyID = c.Long(nullable: false),
                        LgsProductExtendedValueID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        LgsProductMaster_LgsProductMasterID = c.Long(),
                    })
                .PrimaryKey(t => t.LgsProductExtendedPropertyValueID)
                .ForeignKey("dbo.LgsProductMaster", t => t.LgsProductMaster_LgsProductMasterID)
                .Index(t => t.LgsProductMaster_LgsProductMasterID);
            
            CreateTable(
                "dbo.LgsProductLink",
                c => new
                    {
                        LgsProductLinkID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductLinkCode = c.String(maxLength: 25),
                        ProductLinkName = c.String(maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductLinkID);
            
            CreateTable(
                "dbo.LgsProductSerialNoDetail",
                c => new
                    {
                        LgsProductSerialNoDetailID = c.Long(nullable: false, identity: true),
                        ProductSerialNoDetailID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ExpiryDate = c.DateTime(),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        SerialNo = c.String(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        BatchNo = c.String(maxLength: 40),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductSerialNoDetailID);
            
            CreateTable(
                "dbo.LgsProductSerialNo",
                c => new
                    {
                        LgsProductSerialNoID = c.Long(nullable: false, identity: true),
                        ProductSerialNoID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 40),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ExpiryDate = c.DateTime(),
                        SerialNo = c.String(nullable: false),
                        SerialNoStatus = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductSerialNoID);
            
            CreateTable(
                "dbo.LgsProductStockMaster",
                c => new
                    {
                        LgsProductStockMasterID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReOrderPeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductStockMasterID);
            
            CreateTable(
                "dbo.LgsProductSupplierLink",
                c => new
                    {
                        LgsProductSupplierLinkID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 50),
                        DocumentDate = c.DateTime(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedGP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductSupplierLinkID);
            
            CreateTable(
                "dbo.LgsProductUnitConversion",
                c => new
                    {
                        LgsProductUnitConversionID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        LineNo = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsProductUnitConversionID);
            
            CreateTable(
                "dbo.LgsPurchase",
                c => new
                    {
                        LgsPurchaseID = c.Long(nullable: false, identity: true),
                        PurchaseID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        CompanyCode = c.String(nullable: false, maxLength: 15),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(nullable: false, maxLength: 15),
                        LocationName = c.String(maxLength: 50),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 15),
                        SupplierName = c.String(maxLength: 100),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentCode = c.String(maxLength: 15),
                        DepartmentName = c.String(maxLength: 50),
                        CategoryCode = c.String(maxLength: 15),
                        CategoryName = c.String(maxLength: 50),
                        SubCategoryCode = c.String(maxLength: 15),
                        SubCategoryName = c.String(maxLength: 50),
                        SubCategory2Code = c.String(maxLength: 15),
                        SubCategory2Name = c.String(maxLength: 50),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        ProductName = c.String(maxLength: 100),
                        BarCode = c.String(maxLength: 25),
                        BatchNo = c.String(nullable: false, maxLength: 40),
                        ExpiryDate = c.DateTime(),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(nullable: false, maxLength: 50),
                        PackSize = c.String(nullable: false, maxLength: 25),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WholeSalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        IsFreeIssue = c.Boolean(nullable: false),
                        IsDispatch = c.Boolean(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsPurchaseID);
            
            CreateTable(
                "dbo.LgsPurchaseDetail",
                c => new
                    {
                        LgsPurchaseDetailID = c.Long(nullable: false, identity: true),
                        PurchaseDetailID = c.Long(nullable: false),
                        LgsPurchaseHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpiryDate = c.DateTime(),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        QtyConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQtyConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentStatus = c.Int(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        IsBatch = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsPurchaseDetailID);
            
            CreateTable(
                "dbo.LgsPurchaseHeader",
                c => new
                    {
                        LgsPurchaseHeaderID = c.Long(nullable: false, identity: true),
                        PurchaseHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherChargers = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        SupplierInvoiceNo = c.String(maxLength: 20),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        ReturnTypeID = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsPurchaseHeaderID);
            
            CreateTable(
                "dbo.LgsPurchaseOrderDetail",
                c => new
                    {
                        LgsPurchaseOrderDetailID = c.Long(nullable: false, identity: true),
                        PurchaseOrderDetailID = c.Long(nullable: false),
                        LgsPurchaseOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceFreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackSize = c.String(),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        UnitOfMeasureID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsPurchaseOrderDetailID)
                .ForeignKey("dbo.LgsPurchaseOrderHeader", t => t.LgsPurchaseOrderHeaderID, cascadeDelete: true)
                .Index(t => t.LgsPurchaseOrderHeaderID);
            
            CreateTable(
                "dbo.LgsPurchaseOrderHeader",
                c => new
                    {
                        LgsPurchaseOrderHeaderID = c.Long(nullable: false, identity: true),
                        PurchaseOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        LgsSupplierID = c.Long(nullable: false),
                        ExpectedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        PaymentExpectedDate = c.DateTime(nullable: false),
                        ValidityPeriod = c.Int(nullable: false),
                        IsConsignmentBasis = c.Boolean(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Addition = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequestedBy = c.String(maxLength: 50),
                        DeliveryLocationID = c.Int(nullable: false),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTermID = c.Int(nullable: false),
                        PaymentPeriod = c.Int(nullable: false),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDetail = c.String(maxLength: 500),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsUpLoad = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsPurchaseOrderHeaderID);
            
            CreateTable(
                "dbo.LgsQuotationDetail",
                c => new
                    {
                        LgsQuotationDetailID = c.Long(nullable: false, identity: true),
                        QuotationDetailID = c.Long(nullable: false),
                        LgsQuotationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackID = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsQuotationDetailID);
            
            CreateTable(
                "dbo.LgsQuotationHeader",
                c => new
                    {
                        LgsQuotationHeaderID = c.Long(nullable: false, identity: true),
                        QuotationHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        SupplierID = c.Long(nullable: false),
                        InvSalesPersonID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Addition = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryLocationID = c.Int(nullable: false),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyID = c.Int(nullable: false),
                        CurrencyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDetail = c.String(maxLength: 500),
                        ReferenceDocumentID = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsQuotationHeaderID);
            
            CreateTable(
                "dbo.LgsReturnType",
                c => new
                    {
                        LgsReturnTypeID = c.Int(nullable: false, identity: true),
                        ReturnType = c.String(maxLength: 50),
                        RelatedFormID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LgsReturnTypeID);
            
            CreateTable(
                "dbo.LgsSampleInDetail",
                c => new
                    {
                        LgsSampleInDetailID = c.Long(nullable: false, identity: true),
                        SampleDetailID = c.Long(nullable: false),
                        LgsSampleInHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitID = c.Long(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSampleInDetailID);
            
            CreateTable(
                "dbo.LgsSampleInHeader",
                c => new
                    {
                        LgsSampleInHeaderID = c.Long(nullable: false, identity: true),
                        SampleHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceLocationID = c.Long(nullable: false),
                        IssuedTo = c.String(maxLength: 100),
                        DeliveryPerson = c.String(maxLength: 100),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Balanced = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSampleInHeaderID);
            
            CreateTable(
                "dbo.LgsSampleOutDetail",
                c => new
                    {
                        LgsSampleOutDetailID = c.Long(nullable: false, identity: true),
                        SampleDetailID = c.Long(nullable: false),
                        LgsSampleOutHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitID = c.Long(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSampleOutDetailID);
            
            CreateTable(
                "dbo.LgsSampleOutHeader",
                c => new
                    {
                        LgsSampleOutHeaderID = c.Long(nullable: false, identity: true),
                        SampleHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        IssuedTo = c.String(maxLength: 100),
                        DeliveryPerson = c.String(maxLength: 100),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        TotalBalancedQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Balanced = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsSampleOutHeaderID);
            
            CreateTable(
                "dbo.LgsStockAdjustmentDetail",
                c => new
                    {
                        LgsStockAdjustmentDetailID = c.Long(nullable: false, identity: true),
                        StockAdjustmentDetailID = c.Long(nullable: false),
                        LgsStockAdjustmentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentDate = c.DateTime(),
                        StockAdjustmentMode = c.Int(nullable: false),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BatchQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ExcessQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ShortageQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OverWriteQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCostExcessQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCostShortageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCostCurrentQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNo = c.String(maxLength: 50),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpiryDate = c.DateTime(),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        CostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsStockAdjustmentDetailID);
            
            CreateTable(
                "dbo.LgsStockAdjustmentHeader",
                c => new
                    {
                        LgsStockAdjustmentHeaderID = c.Long(nullable: false, identity: true),
                        StockAdjustmentHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        TotalCostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSellingtValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        ReferenceNo = c.String(maxLength: 20),
                        StockAdjustmentMode = c.Int(nullable: false),
                        StockAdjustmentLayer = c.Int(nullable: false),
                        Narration = c.String(maxLength: 500),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsStockAdjustmentHeaderID);
            
            CreateTable(
                "dbo.LgsTmpProductStockDetail",
                c => new
                    {
                        LgsTmpProductStockDetailID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        ToLocationName = c.String(maxLength: 50),
                        GivenDate = c.DateTime(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(maxLength: 20),
                        ProductName = c.String(maxLength: 100),
                        TransactionType = c.Int(nullable: false),
                        TransactionNo = c.String(maxLength: 20),
                        BatchNo = c.String(maxLength: 25),
                        TransactionDate = c.DateTime(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        StockQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty1 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty2 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty3 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty4 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty5 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty6 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty7 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty8 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty9 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Qty10 = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UserID = c.Long(nullable: false),
                        UniqueID = c.Long(nullable: false),
                        GrossProfit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsTmpProductStockDetailID);
            
            CreateTable(
                "dbo.LgsTransferNoteDetail",
                c => new
                    {
                        LgsTransferNoteDetailID = c.Long(nullable: false, identity: true),
                        TransferNoteDetailID = c.Long(nullable: false),
                        TransferNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        LineNo = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        BatchExpiryDate = c.DateTime(nullable: false),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BatchNoExpiaryDetailID = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        QtyConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToLocationID = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsTransferNoteDetailID);
            
            CreateTable(
                "dbo.LgsTransferNoteHeader",
                c => new
                    {
                        LgsTransferNoteHeaderID = c.Long(nullable: false, identity: true),
                        TransferNoteHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        TransferTypeID = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        ToLocationID = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgsTransferNoteHeaderID);
            
            CreateTable(
                "dbo.LgsTransferType",
                c => new
                    {
                        LgsTransferTypeID = c.Int(nullable: false, identity: true),
                        TransferType = c.String(maxLength: 25),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LgsTransferTypeID);
            
            CreateTable(
                "dbo.LoanPurpose",
                c => new
                    {
                        LoanPurposeID = c.Int(nullable: false, identity: true),
                        LoanPurposeCode = c.String(nullable: false, maxLength: 15),
                        LoanPurposeName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanPurposeID);
            
            CreateTable(
                "dbo.LoanType",
                c => new
                    {
                        LoanTypeID = c.Int(nullable: false, identity: true),
                        LoanTypeCode = c.String(nullable: false, maxLength: 15),
                        LoanTypeName = c.String(nullable: false, maxLength: 50),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanTypeID);
            
            CreateTable(
                "dbo.LocationAssignedCostCentre",
                c => new
                    {
                        LocationAssignedCostCentreID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        Select = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationAssignedCostCentreID);
            
            CreateTable(
                "dbo.LostAndRenew",
                c => new
                    {
                        LostAndRenewID = c.Long(nullable: false, identity: true),
                        LoyaltyCustomerID = c.Long(nullable: false),
                        OldCardNo = c.String(maxLength: 50),
                        NewCardNo = c.String(maxLength: 50),
                        OldCustomerCode = c.String(maxLength: 50),
                        NewCustomerCode = c.String(maxLength: 50),
                        OldEncodeNo = c.String(maxLength: 50),
                        NewEncodeNo = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 200),
                        RenewedDate = c.DateTime(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LostAndRenewID);
            
            CreateTable(
                "dbo.LoyaltyCardAllocation",
                c => new
                    {
                        LoyaltyCardAllocationID = c.Int(nullable: false, identity: true),
                        CardTypeId = c.Long(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        SerialNo = c.String(maxLength: 150),
                        CardNo = c.String(maxLength: 150),
                        EncodeNo = c.String(maxLength: 150),
                        Assign = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardAllocationID);
            
            CreateTable(
                "dbo.LoyaltyCardGenerationDetail",
                c => new
                    {
                        LoyaltyCardGenerationDetailID = c.Long(nullable: false, identity: true),
                        CardGenerationDetailID = c.Long(nullable: false),
                        CardPrefix = c.String(maxLength: 10),
                        CardLength = c.Int(nullable: false),
                        CardStartingNo = c.Long(nullable: false),
                        EncodeLength = c.Int(nullable: false),
                        EncodeStartingNo = c.Long(nullable: false),
                        EncodePrefix = c.String(maxLength: 3),
                        GeneratedDate = c.DateTime(nullable: false),
                        CardNo = c.String(nullable: false, maxLength: 50),
                        EncodeNo = c.String(maxLength: 50),
                        IsIssued = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        LoyaltyCardGenerationHeaderID = c.Long(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardGenerationDetailID)
                .ForeignKey("dbo.LoyaltyCardGenerationHeader", t => t.LoyaltyCardGenerationHeaderID, cascadeDelete: true)
                .Index(t => t.LoyaltyCardGenerationHeaderID);
            
            CreateTable(
                "dbo.LoyaltyCardGenerationHeader",
                c => new
                    {
                        LoyaltyCardGenerationHeaderID = c.Long(nullable: false, identity: true),
                        CardGenerationHeaderID = c.Long(nullable: false),
                        CardPrefix = c.String(maxLength: 10),
                        CardLength = c.Int(nullable: false),
                        CardStartingNo = c.Int(nullable: false),
                        EncodeLength = c.Int(nullable: false),
                        EncodeStartingNo = c.Int(nullable: false),
                        EncodePrefix = c.String(maxLength: 3),
                        GeneratedDate = c.DateTime(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CardMasterID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardGenerationHeaderID);
            
            CreateTable(
                "dbo.LoyaltyCardIssueDetail",
                c => new
                    {
                        LoyaltyCardIssueDetailID = c.Long(nullable: false, identity: true),
                        LoyaltyCardIssueHeaderID = c.Long(nullable: false),
                        CardIssueDetailID = c.Long(nullable: false),
                        ToLocationID = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        CardNo = c.String(nullable: false, maxLength: 50),
                        EncodeNo = c.String(maxLength: 50),
                        IsIssued = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardIssueDetailID);
            
            CreateTable(
                "dbo.LoyaltyCardIssueHeader",
                c => new
                    {
                        LoyaltyCardIssueHeaderID = c.Long(nullable: false, identity: true),
                        CardIssueHeaderID = c.Long(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ToLocationID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 50),
                        Remark = c.String(maxLength: 50),
                        ReferenceNo = c.String(maxLength: 50),
                        EmployeeID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardIssueHeaderID);
            
            CreateTable(
                "dbo.LoyaltyCustomer",
                c => new
                    {
                        LoyaltyCustomerID = c.Long(nullable: false, identity: true),
                        CardNo = c.String(nullable: false),
                        CustomerCode = c.String(nullable: false, maxLength: 15),
                        CustomerTitle = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        Gender = c.Int(nullable: false),
                        NicNo = c.String(maxLength: 50),
                        ReferenceNo = c.String(maxLength: 50),
                        Nationality = c.Int(nullable: false),
                        CustomerId = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Religion = c.Int(nullable: false),
                        Race = c.Int(nullable: false),
                        Address1 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Address3 = c.String(maxLength: 50),
                        District = c.Int(nullable: false),
                        LandMark = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                        Organization = c.String(maxLength: 50),
                        Occupation = c.String(maxLength: 50),
                        WorkAddres1 = c.String(maxLength: 50),
                        WorkAddres2 = c.String(maxLength: 50),
                        WorkAddres3 = c.String(maxLength: 50),
                        WorkEmail = c.String(maxLength: 50),
                        WorkTelephone = c.String(maxLength: 50),
                        WorkMobile = c.String(maxLength: 50),
                        WorkFax = c.String(maxLength: 50),
                        NameOnCard = c.String(maxLength: 50),
                        CardMasterID = c.Long(nullable: false),
                        CardIssued = c.Boolean(nullable: false),
                        IssuedOn = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        RenewedOn = c.DateTime(nullable: false),
                        SpouseName = c.String(maxLength: 50),
                        CivilStatus = c.Int(nullable: false),
                        FemaleAdults = c.Int(nullable: false),
                        MaleAdults = c.Int(nullable: false),
                        Childrens = c.Int(nullable: false),
                        SpouseDateOfBirth = c.DateTime(nullable: false),
                        Anniversary = c.DateTime(nullable: false),
                        SinhalaHinduNewYear = c.Boolean(nullable: false),
                        ThaiPongal = c.Boolean(nullable: false),
                        Wesak = c.Boolean(nullable: false),
                        HajFestival = c.Boolean(nullable: false),
                        Ramazan = c.Boolean(nullable: false),
                        Xmas = c.Boolean(nullable: false),
                        FavoriteTvChannel = c.Int(nullable: false),
                        FavoriteNewsPapers = c.Int(nullable: false),
                        FavoriteRadioChannels = c.Int(nullable: false),
                        FavoriteMagazines = c.Int(nullable: false),
                        LedgerId = c.Long(nullable: false),
                        LedgerId2 = c.Long(nullable: false),
                        CreditLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditPeriod = c.Int(nullable: false),
                        DeliverTo = c.Int(nullable: false),
                        DeliverToAddress = c.String(maxLength: 50),
                        CustomerSince = c.DateTime(nullable: false),
                        SendUpdatesViaEmail = c.Boolean(nullable: false),
                        SendUpdatesViaSms = c.Boolean(nullable: false),
                        IsSuspended = c.Boolean(nullable: false),
                        IsBlackListed = c.Boolean(nullable: false),
                        IsCreditAllowed = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CustomerImage = c.Binary(),
                        CPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReDimm = c.Boolean(nullable: false),
                        AcitiveDate = c.DateTime(nullable: false),
                        LocationID = c.Int(nullable: false),
                        IsAbeyance = c.Boolean(nullable: false),
                        IsRegByPOS = c.Boolean(nullable: false),
                        CashierID = c.Long(nullable: false),
                        LoyaltyType = c.Int(nullable: false),
                        Remark = c.String(maxLength: 200),
                        SystemGeneratedCode = c.String(maxLength: 15),
                        ExpiryPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSold = c.Boolean(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        Zno = c.Long(nullable: false),
                        ReceiptNo = c.String(maxLength: 50),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        LoyaltySuplimentary_LoyaltySuplimentaryID = c.Long(),
                    })
                .PrimaryKey(t => t.LoyaltyCustomerID)
                .ForeignKey("dbo.LoyaltySuplimentary", t => t.LoyaltySuplimentary_LoyaltySuplimentaryID)
                .Index(t => t.LoyaltySuplimentary_LoyaltySuplimentaryID);
            
            CreateTable(
                "dbo.LoyaltySuplimentary",
                c => new
                    {
                        LoyaltySuplimentaryID = c.Long(nullable: false, identity: true),
                        LoyaltyCustomerID = c.Long(nullable: false),
                        CardTypeId = c.Long(nullable: false),
                        RelationShipId = c.Int(nullable: false),
                        CardNo = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltySuplimentaryID);
            
            CreateTable(
                "dbo.OpeningStockDetail",
                c => new
                    {
                        OpeningStockDetailID = c.Long(nullable: false, identity: true),
                        StockDetailID = c.Long(nullable: false),
                        OpeningStockHeaderID = c.Long(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentID = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        OpeningStockType = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        IsBatch = c.Boolean(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsExpiry = c.Boolean(nullable: false),
                        ExpiryDate = c.DateTime(),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpeningStockDetailID);
            
            CreateTable(
                "dbo.OpeningStockHeader",
                c => new
                    {
                        OpeningStockHeaderID = c.Long(nullable: false, identity: true),
                        StockHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentStatus = c.Int(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        TotalCostValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSellingtValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        ReferenceDocumentID = c.Int(nullable: false),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        OpeningStockType = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpeningStockHeaderID);
            
            CreateTable(
                "dbo.OrderTerminal",
                c => new
                    {
                        OrderTerminalID = c.Int(nullable: false, identity: true),
                        OrderTerminalCode = c.String(),
                        OrderTerminalName = c.String(),
                        TerminalID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderTerminalID);
            
            CreateTable(
                "dbo.PaidInType",
                c => new
                    {
                        PaidInTypeID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 15),
                        Description = c.String(maxLength: 30),
                        IsSalesSummery = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaidInTypeID);
            
            CreateTable(
                "dbo.PaidOutType",
                c => new
                    {
                        PaidOutTypeID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 15),
                        Description = c.String(maxLength: 30),
                        IsSalesSummery = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaidOutTypeID);
            
            CreateTable(
                "dbo.PaymentDet",
                c => new
                    {
                        PaymentDetID = c.Long(nullable: false, identity: true),
                        RowNo = c.Long(nullable: false),
                        PayTypeID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDate = c.DateTime(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        LocationID = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        RefNo = c.String(nullable: false, maxLength: 30),
                        BankId = c.Int(nullable: false),
                        ChequeDate = c.DateTime(),
                        IsRecallAdv = c.Boolean(nullable: false),
                        RecallNo = c.String(nullable: false, maxLength: 10),
                        Descrip = c.String(nullable: false, maxLength: 20),
                        EnCodeName = c.String(nullable: false, maxLength: 50),
                        UpdatedBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        CustomerCode = c.String(maxLength: 25),
                        GroupOfCompanyID = c.Int(nullable: false),
                        Datatransfer = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        TerminalID = c.Int(nullable: false),
                        LoyaltyType = c.Int(nullable: false),
                        IsUploadToGL = c.Int(nullable: false),
                        LocationIDBilling = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        TicketID = c.Long(nullable: false),
                        OrderNo = c.Long(nullable: false),
                        ShiftNo = c.Long(nullable: false),
                        IsDayEnd = c.Boolean(nullable: false),
                        UpdateUnitNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentDetID);
            
            CreateTable(
                "dbo.PaymentTerm",
                c => new
                    {
                        PaymentTermID = c.Int(nullable: false, identity: true),
                        PaymentTermCode = c.String(maxLength: 15),
                        PaymentTermName = c.String(maxLength: 50),
                        CreditPeriod = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTermID);
            
            CreateTable(
                "dbo.PayType",
                c => new
                    {
                        PayTypeID = c.Long(nullable: false, identity: true),
                        PaymentID = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 15),
                        IsSwipe = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRefundable = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsBillCopy = c.Boolean(nullable: false),
                        PrintDescrip = c.String(nullable: false, maxLength: 12),
                        PreFix = c.String(nullable: false, maxLength: 5),
                        MaxLength = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PayTypeID);
            
            CreateTable(
                "dbo.PointsBreakdown",
                c => new
                    {
                        PointsBreakdownID = c.Long(nullable: false, identity: true),
                        RangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PointsBreakdownID);
            
            CreateTable(
                "dbo.ProductCodeDependancy",
                c => new
                    {
                        ProductCodeDependancyID = c.Int(nullable: false, identity: true),
                        FormName = c.String(),
                        DependOnDepartment = c.Boolean(nullable: false),
                        DependOnCategory = c.Boolean(nullable: false),
                        DependOnSubCategory = c.Boolean(nullable: false),
                        DependOnSubCategory2 = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCodeDependancyID);
            
            CreateTable(
                "dbo.PurchaseBreakdown",
                c => new
                    {
                        PurchaseBreakdownID = c.Long(nullable: false, identity: true),
                        RangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseBreakdownID);
            
            CreateTable(
                "dbo.ReferenceType",
                c => new
                    {
                        ReferenceTypeID = c.Int(nullable: false, identity: true),
                        LookupType = c.String(maxLength: 25),
                        LookupKey = c.Int(nullable: false),
                        LookupValue = c.String(maxLength: 100),
                        Remark = c.String(maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceTypeID);
            
            CreateTable(
                "dbo.ReportGenerator",
                c => new
                    {
                        ReportGeneratorID = c.Long(nullable: false, identity: true),
                        Visible = c.Int(nullable: false),
                        TableName = c.String(),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportGeneratorID);
            
            CreateTable(
                "dbo.RestaurentReportCondition",
                c => new
                    {
                        RestaurentReportConditionID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        BillingLocationID = c.Int(nullable: false),
                        ProductMasterID = c.Long(nullable: false),
                        DepartmentID = c.Long(nullable: false),
                        CategoryID = c.Long(nullable: false),
                        SubCategoryID = c.Long(nullable: false),
                        SubCategory2ID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        shiftNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurentReportConditionID);
            
            CreateTable(
                "dbo.RSalesSummary",
                c => new
                    {
                        RSalesSummaryID = c.Long(nullable: false, identity: true),
                        LocationID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        vouchersalegross = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nvouchersale = c.Long(nullable: false),
                        voudiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nvoudiscount = c.Long(nullable: false),
                        vouRedeem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nvouRedeem = c.Long(nullable: false),
                        loyaltyRedeem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nloyaltyRedeem = c.Long(nullable: false),
                        vouchernet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vouchercash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        vouchercredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        grosssale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        refunds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nrefunds = c.Long(nullable: false),
                        Idiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nidiscount = c.Long(nullable: false),
                        sdiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nsdiscount = c.Long(nullable: false),
                        voids = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nvoids = c.Long(nullable: false),
                        error = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nerror = c.Long(nullable: false),
                        cancel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncancel = c.Long(nullable: false),
                        loyalty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nloyalty = c.Long(nullable: false),
                        nett = c.Decimal(nullable: false, precision: 18, scale: 2),
                        credpay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncredpay = c.Long(nullable: false),
                        paidout = c.Decimal(nullable: false, precision: 18, scale: 2),
                        npaidout = c.Long(nullable: false),
                        cashsale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        staffcashsale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nstaffcashsale = c.Long(nullable: false),
                        cashrefund = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncashrefund = c.Long(nullable: false),
                        advancereceive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nadvancereceive = c.Long(nullable: false),
                        advancerefund = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nadvancerefund = c.Long(nullable: false),
                        advancereceivecrd = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nadvancereceivecrd = c.Long(nullable: false),
                        advancerefundcrd = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nadvancerefundcrd = c.Long(nullable: false),
                        advancesettlement = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nadvancesettlement = c.Long(nullable: false),
                        noofbills = c.Long(nullable: false),
                        voucher = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nvoucher = c.Long(nullable: false),
                        staffcred = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nstaffcred = c.Long(nullable: false),
                        cheque = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncheque = c.Long(nullable: false),
                        starpoint = c.Decimal(nullable: false, precision: 18, scale: 2),
                        starpointErn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        starpointErnVal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nstarpoint = c.Long(nullable: false),
                        mcredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nmcredit = c.Long(nullable: false),
                        credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncredit = c.Long(nullable: false),
                        crdnote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncrdnote = c.Long(nullable: false),
                        crdnotestle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ncrdnotestle = c.Long(nullable: false),
                        CashInHand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeclaredAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivedOnAccount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReportNo = c.String(maxLength: 25),
                        Vstaffcashsale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VstaffCreditSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MasterCard = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VisaCard = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmexCard = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitCard = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NMasterCard = c.Long(nullable: false),
                        NVisaCard = c.Long(nullable: false),
                        NAmexCard = c.Long(nullable: false),
                        NDebitCard = c.Long(nullable: false),
                        LogedUser = c.Long(nullable: false),
                        LocationCode = c.String(maxLength: 10),
                        LocationName = c.String(maxLength: 50),
                        MCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        eZCash = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SMSVoucher = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RSalesSummaryID);
            
            CreateTable(
                "dbo.SalesOrderDetail",
                c => new
                    {
                        SalesOrderDetailID = c.Long(nullable: false, identity: true),
                        OrderDetailID = c.Long(nullable: false),
                        SalesOrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CurrentQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceFreeQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesOrderDetailID);
            
            CreateTable(
                "dbo.SalesOrderHeader",
                c => new
                    {
                        SalesOrderHeaderID = c.Long(nullable: false, identity: true),
                        OrderHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        JobClassID = c.Long(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        ReferenceDocumentNo = c.String(maxLength: 20),
                        CustomerID = c.Long(nullable: false),
                        InvSalesPersonID = c.Long(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCharges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineDiscountTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReferenceDocumentID = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        ReferenceNo = c.String(maxLength: 20),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesOrderHeaderID);
            
            CreateTable(
                "dbo.ServiceInDetail",
                c => new
                    {
                        ServiceInDetailID = c.Long(nullable: false, identity: true),
                        ServiceDetailID = c.Long(nullable: false),
                        ServiceInHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitID = c.Long(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceInDetailID);
            
            CreateTable(
                "dbo.ServiceInHeader",
                c => new
                    {
                        ServiceInHeaderID = c.Long(nullable: false, identity: true),
                        ServiceHeaderID = c.Long(nullable: false),
                        ServiceOutHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Balanced = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceInHeaderID);
            
            CreateTable(
                "dbo.ServiceOutDetail",
                c => new
                    {
                        ServiceOutDetailID = c.Long(nullable: false, identity: true),
                        ServiceDetailID = c.Long(nullable: false),
                        ServiceOutHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BatchNo = c.String(maxLength: 50),
                        DocumentID = c.Int(nullable: false),
                        OrderQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalancedQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseUnitID = c.Long(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineNo = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceOutDetailID);
            
            CreateTable(
                "dbo.ServiceOutHeader",
                c => new
                    {
                        ServiceOutHeaderID = c.Long(nullable: false, identity: true),
                        ServiceHeaderID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        SupplierID = c.Long(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                        DocumentNo = c.String(maxLength: 20),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentMethodID = c.Int(nullable: false),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        TotalBalancedQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Remark = c.String(maxLength: 150),
                        DocumentStatus = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Balanced = c.Int(nullable: false),
                        ReferenceNo = c.String(maxLength: 20),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceOutHeaderID);
            
            CreateTable(
                "dbo.ShiftDet",
                c => new
                    {
                        ShiftDetID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        LocationIDBilling = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        ShiftDate = c.DateTime(nullable: false, storeType: "date"),
                        ShiftDateTime = c.DateTime(nullable: false),
                        ShiftStartSystemDate = c.DateTime(nullable: false),
                        Float = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsShiftEnd = c.Boolean(nullable: false),
                        ShiftEndCashierID = c.Long(nullable: false),
                        ShiftEndSystemDate = c.DateTime(nullable: false),
                        ShiftEndDate = c.DateTime(nullable: false, storeType: "date"),
                        ShiftEndDateTime = c.DateTime(nullable: false),
                        ZNo = c.Long(nullable: false),
                        ShiftNo = c.Long(nullable: false),
                        CashInHand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitNo = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftDetID);
            
            CreateTable(
                "dbo.Shift",
                c => new
                    {
                        ShiftID = c.Int(nullable: false, identity: true),
                        ShiftNo = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShiftID);
            
            CreateTable(
                "dbo.SlabReference",
                c => new
                    {
                        SlabReferenceID = c.Int(nullable: false, identity: true),
                        ReferenceID = c.Long(nullable: false),
                        PeriodID = c.Int(nullable: false),
                        SlabNo = c.Int(nullable: false),
                        FromSlab = c.Int(nullable: false),
                        ToSlab = c.Int(nullable: false),
                        IsShowMinimum = c.Boolean(nullable: false),
                        IsShowMaximum = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlabReferenceID);
            
            CreateTable(
                "dbo.SupplierPerformance",
                c => new
                    {
                        SupplierPerformanceID = c.Long(nullable: false, identity: true),
                        SupplierID = c.Long(nullable: false),
                        SupplierCode = c.String(maxLength: 150),
                        SupplierName = c.String(maxLength: 500),
                        TotalPurchaseOrder = c.Long(nullable: false),
                        TotalGrn = c.Long(nullable: false),
                        TotalSales = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SupplierPerformanceID);
            
            CreateTable(
                "dbo.SupplierWiseStockMovement",
                c => new
                    {
                        SupplierWiseStockMovementID = c.Long(nullable: false, identity: true),
                        SupplierID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        Tog = c.Int(nullable: false),
                        Adj = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Grn = c.Int(nullable: false),
                        Sale = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(),
                        LocationName = c.String(),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SupplierWiseStockMovementID);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        SystemConfigID = c.Long(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(maxLength: 50),
                        Version = c.String(maxLength: 10),
                        CompanyName = c.String(maxLength: 50),
                        CompanyAddress1 = c.String(maxLength: 50),
                        CompanyAddress2 = c.String(maxLength: 50),
                        CompanyAddress3 = c.String(maxLength: 50),
                        CompanyTelephone = c.String(maxLength: 35),
                        CompanyFax = c.String(maxLength: 35),
                        CompanyEmail = c.String(maxLength: 20),
                        CompanyWeb = c.String(maxLength: 20),
                        LicensedTo = c.String(maxLength: 50),
                        BarcodeTextPath = c.String(),
                        GVBarcodeTextPath = c.String(),
                    })
                .PrimaryKey(t => t.SystemConfigID);
            
            CreateTable(
                "dbo.SystemFeature",
                c => new
                    {
                        SystemFeatureID = c.Long(nullable: false, identity: true),
                        SystemConfigID = c.Long(nullable: false),
                        ProductID = c.Int(nullable: false),
                        EntryLevel = c.Int(nullable: false),
                        IsMultyCurrency = c.Boolean(nullable: false),
                        DefaultCurrencyID = c.Int(nullable: false),
                        IsMinusStock = c.Boolean(nullable: false),
                        IsBatch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SystemFeatureID);
            
            CreateTable(
                "dbo.TableDetail",
                c => new
                    {
                        TableDetailID = c.Int(nullable: false, identity: true),
                        TableCode = c.String(),
                        TableName = c.String(),
                        LocationID = c.Int(nullable: false),
                        TicketID = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableDetailID);
            
            CreateTable(
                "dbo.Tax",
                c => new
                    {
                        TaxID = c.Int(nullable: false, identity: true),
                        TaxCode = c.String(nullable: false, maxLength: 10),
                        TaxName = c.String(nullable: false, maxLength: 50),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EffectivePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EffectiveDate = c.DateTime(nullable: false),
                        Tax1 = c.Boolean(nullable: false),
                        Tax2 = c.Boolean(nullable: false),
                        Tax3 = c.Boolean(nullable: false),
                        Tax4 = c.Boolean(nullable: false),
                        Tax5 = c.Boolean(nullable: false),
                        PrintOrder = c.Int(nullable: false),
                        LedgerID = c.Long(nullable: false),
                        PaidLedgerID = c.Long(nullable: false),
                        Remark = c.String(maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxID);
            
            CreateTable(
                "dbo.TempDailySalesSummary",
                c => new
                    {
                        TempDailySalesSummaryID = c.Long(nullable: false, identity: true),
                        LocationID = c.Long(nullable: false),
                        cashcollection = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cardcollection = c.Decimal(nullable: false, precision: 18, scale: 2),
                        grosssale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        chequesale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        othersales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        exchange = c.Decimal(nullable: false, precision: 18, scale: 2),
                        giftvouchersales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        itemdiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        billcount = c.Long(nullable: false),
                        netsales = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ZDate = c.DateTime(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempDailySalesSummaryID);
            
            CreateTable(
                "dbo.TempInvProductBatchNoExpiaryDetail",
                c => new
                    {
                        TempInvProductBatchNoExpiaryDetailID = c.Long(nullable: false, identity: true),
                        ProductBatchNoExpiaryDetailID = c.Long(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        CostCentreID = c.Int(nullable: false),
                        ReferenceDocumentDocumentID = c.Int(nullable: false),
                        ReferenceDocumentID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        BarCode = c.Long(nullable: false),
                        BatchNo = c.String(nullable: false, maxLength: 40),
                        ExpiryDate = c.DateTime(),
                        LineNo = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UnitOfMeasureID = c.Long(nullable: false),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SupplierID = c.Long(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempInvProductBatchNoExpiaryDetailID);
            
            CreateTable(
                "dbo.TempLocationWiseLoyaltyAnalysis",
                c => new
                    {
                        TempLocationWiseLoyaltyAnalysisID = c.Long(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        LocationCode = c.String(),
                        LocationName = c.String(),
                        UsedCard = c.Long(nullable: false),
                        CardIssu = c.Long(nullable: false),
                        UsedPoints = c.Long(nullable: false),
                        NonUsedCard = c.Long(nullable: false),
                        NonUsedPoints = c.Long(nullable: false),
                        CardInAbeyance = c.Long(nullable: false),
                        PointsInAbeyance = c.Long(nullable: false),
                        ActiveCard = c.Long(nullable: false),
                        ActivePoints = c.Long(nullable: false),
                        InactiveCard = c.Long(nullable: false),
                        InactivePoints = c.Long(nullable: false),
                        UsedCardPer = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempLocationWiseLoyaltyAnalysisID);
            
            CreateTable(
                "dbo.TempLoyaltyPoint",
                c => new
                    {
                        TempLoyaltyPointID = c.Long(nullable: false, identity: true),
                        CPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentDate = c.DateTime(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempLoyaltyPointID);
            
            CreateTable(
                "dbo.TempLoyaltyPurchase",
                c => new
                    {
                        TempLoyaltyPurchaseID = c.Long(nullable: false, identity: true),
                        Purchase = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DocumentDate = c.DateTime(nullable: false),
                        CustomerID = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempLoyaltyPurchaseID);
            
            CreateTable(
                "dbo.TempLoyaltyTransactionSummery",
                c => new
                    {
                        TempLoyaltyTransactionSummeryID = c.Long(nullable: false, identity: true),
                        CustomerCode = c.String(),
                        CustomerName = c.String(),
                        CustomerID = c.Long(nullable: false),
                        EPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RPoints = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalVisits = c.Int(nullable: false),
                        CardNo = c.String(),
                        CardName = c.String(),
                        NicNo = c.String(),
                    })
                .PrimaryKey(t => t.TempLoyaltyTransactionSummeryID);
            
            CreateTable(
                "dbo.TempPaymentDet",
                c => new
                    {
                        TempPaymentDetID = c.Long(nullable: false, identity: true),
                        RowNo = c.Long(nullable: false),
                        PayTypeID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDate = c.DateTime(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        LocationID = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        RefNo = c.String(nullable: false, maxLength: 30),
                        BankId = c.Long(nullable: false),
                        ChequeDate = c.DateTime(),
                        IsRecallAdv = c.Boolean(nullable: false),
                        RecallNo = c.String(nullable: false, maxLength: 10),
                        Descrip = c.String(nullable: false, maxLength: 20),
                        EnCodeName = c.String(nullable: false, maxLength: 50),
                        UpdatedBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        CustomerCode = c.String(maxLength: 25),
                        GroupOfCompanyID = c.Int(nullable: false),
                        Datatransfer = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        TerminalID = c.Int(nullable: false),
                        LoyaltyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempPaymentDetID);
            
            CreateTable(
                "dbo.TempPointsBreakdown",
                c => new
                    {
                        TempPointsBreakdownID = c.Long(nullable: false, identity: true),
                        PointsBreakdownID = c.Long(nullable: false),
                        RangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Range = c.String(),
                        CustomerCount = c.Int(nullable: false),
                        PointsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempPointsBreakdownID);
            
            CreateTable(
                "dbo.TempPosPaymentDet",
                c => new
                    {
                        TempPosPaymentDetID = c.Long(nullable: false, identity: true),
                        RowNo = c.Long(nullable: false),
                        PayTypeID = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDate = c.DateTime(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        LocationID = c.Int(nullable: false),
                        CashierID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        RefNo = c.String(nullable: false, maxLength: 30),
                        BankId = c.Int(nullable: false),
                        ChequeDate = c.DateTime(),
                        IsRecallAdv = c.Boolean(nullable: false),
                        RecallNo = c.String(nullable: false, maxLength: 10),
                        Descrip = c.String(nullable: false, maxLength: 20),
                        EnCodeName = c.String(nullable: false, maxLength: 50),
                        UpdatedBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        CustomerCode = c.String(maxLength: 25),
                        GroupOfCompanyID = c.Int(nullable: false),
                        Datatransfer = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        TerminalID = c.Int(nullable: false),
                        LoyaltyType = c.Int(nullable: false),
                        LoggedUserId = c.Int(nullable: false),
                        CPayTypeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TempPosPaymentDetID);
            
            CreateTable(
                "dbo.TempPosTransactionDet",
                c => new
                    {
                        TempPosTransactionDetID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        RefCode = c.String(nullable: false, maxLength: 25),
                        BarCodeFull = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 50),
                        BatchNo = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        ExpiryDate = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(maxLength: 10),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1 = c.Int(nullable: false),
                        IDis1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1CashierID = c.Long(nullable: false),
                        IDI2 = c.Int(nullable: false),
                        IDis2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI2CashierID = c.Long(nullable: false),
                        IDI3 = c.Int(nullable: false),
                        IDis3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI3CashierID = c.Long(nullable: false),
                        IDI4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDis4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI4CashierID = c.Long(nullable: false),
                        IDI5 = c.Int(nullable: false),
                        IDis5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI5CashierID = c.Long(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSDis = c.Boolean(nullable: false),
                        SDNo = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                        SDIs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDisCashierID = c.Long(nullable: false),
                        Nett = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        SalesmanID = c.Long(nullable: false),
                        Salesman = c.String(maxLength: 15),
                        CustomerID = c.Long(nullable: false),
                        Customer = c.String(maxLength: 150),
                        CashierID = c.Long(nullable: false),
                        Cashier = c.String(maxLength: 15),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RecDate = c.DateTime(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        RowNo = c.Int(nullable: false),
                        IsRecall = c.Boolean(nullable: false),
                        RecallNO = c.String(maxLength: 20),
                        RecallAdv = c.Boolean(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTax = c.Boolean(nullable: false),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStock = c.Boolean(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        TransStatus = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        LoggedUserId = c.Int(nullable: false),
                        TDate = c.DateTime(nullable: false),
                        CQty = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TempPosTransactionDetID);
            
            CreateTable(
                "dbo.TempPromotionSale",
                c => new
                    {
                        TempPromotionSaleID = c.Long(nullable: false, identity: true),
                        LocationID = c.Long(nullable: false),
                        Sale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Profit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TempPromotionSaleID);
            
            CreateTable(
                "dbo.TempPurchaseBreakdown",
                c => new
                    {
                        TempPurchaseBreakdownID = c.Long(nullable: false, identity: true),
                        PurchaseBreakdownID = c.Long(nullable: false),
                        RangeFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RangeTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Range = c.String(),
                        CustomerCount = c.Int(nullable: false),
                        PointsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempPurchaseBreakdownID);
            
            CreateTable(
                "dbo.TempTransactionDet",
                c => new
                    {
                        TempTransactionDetID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        RefCode = c.String(nullable: false, maxLength: 25),
                        BarCodeFull = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 50),
                        BatchNo = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        ExpiryDate = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(maxLength: 10),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1 = c.Int(nullable: false),
                        IDis1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1CashierID = c.Long(nullable: false),
                        IDI2 = c.Int(nullable: false),
                        IDis2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI2CashierID = c.Long(nullable: false),
                        IDI3 = c.Int(nullable: false),
                        IDis3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI3CashierID = c.Long(nullable: false),
                        IDI4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDis4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI4CashierID = c.Long(nullable: false),
                        IDI5 = c.Int(nullable: false),
                        IDis5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI5CashierID = c.Long(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSDis = c.Boolean(nullable: false),
                        SDNo = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                        SDIs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDisCashierID = c.Long(nullable: false),
                        Nett = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        SalesmanID = c.Long(nullable: false),
                        Salesman = c.String(maxLength: 15),
                        CustomerID = c.Long(nullable: false),
                        Customer = c.String(maxLength: 150),
                        CashierID = c.Long(nullable: false),
                        Cashier = c.String(maxLength: 15),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RecDate = c.DateTime(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        RowNo = c.Int(nullable: false),
                        IsRecall = c.Boolean(nullable: false),
                        RecallNO = c.String(maxLength: 20),
                        RecallAdv = c.Boolean(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTax = c.Boolean(nullable: false),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStock = c.Boolean(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        TransStatus = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        IsPromotionApplied = c.Boolean(nullable: false),
                        PromotionID = c.Long(nullable: false),
                        IsPromotion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempTransactionDetID);
            
            CreateTable(
                "dbo.TransactionDetPromotion",
                c => new
                    {
                        TransactionDetPromotionID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        RefCode = c.String(nullable: false, maxLength: 25),
                        BarCodeFull = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 50),
                        BatchNo = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        ExpiryDate = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(maxLength: 10),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1 = c.Int(nullable: false),
                        IDis1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1CashierID = c.Long(nullable: false),
                        IDI2 = c.Int(nullable: false),
                        IDis2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI2CashierID = c.Long(nullable: false),
                        IDI3 = c.Int(nullable: false),
                        IDis3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI3CashierID = c.Long(nullable: false),
                        IDI4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDis4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI4CashierID = c.Long(nullable: false),
                        IDI5 = c.Int(nullable: false),
                        IDis5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI5CashierID = c.Long(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSDis = c.Boolean(nullable: false),
                        SDNo = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                        SDIs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDisCashierID = c.Long(nullable: false),
                        Nett = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        SalesmanID = c.Long(nullable: false),
                        Salesman = c.String(maxLength: 15),
                        CustomerID = c.Long(nullable: false),
                        Customer = c.String(maxLength: 150),
                        CashierID = c.Long(nullable: false),
                        Cashier = c.String(maxLength: 15),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RecDate = c.DateTime(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        RowNo = c.Int(nullable: false),
                        IsRecall = c.Boolean(nullable: false),
                        RecallNO = c.String(maxLength: 20),
                        RecallAdv = c.Boolean(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTax = c.Boolean(nullable: false),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStock = c.Boolean(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        TransStatus = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        IsPromotionApplied = c.Boolean(nullable: false),
                        PromotionID = c.Long(nullable: false),
                        IsPromotion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionDetPromotionID);
            
            CreateTable(
                "dbo.TransactionDet",
                c => new
                    {
                        TransactionDetID = c.Long(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 25),
                        RefCode = c.String(nullable: false, maxLength: 25),
                        BarCodeFull = c.Long(nullable: false),
                        Descrip = c.String(nullable: false, maxLength: 50),
                        BatchNo = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 50),
                        ExpiryDate = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        BalanceQty = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitOfMeasureID = c.Long(nullable: false),
                        UnitOfMeasureName = c.String(maxLength: 10),
                        ConvertFactor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1 = c.Int(nullable: false),
                        IDis1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI1CashierID = c.Long(nullable: false),
                        IDI2 = c.Int(nullable: false),
                        IDis2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI2CashierID = c.Long(nullable: false),
                        IDI3 = c.Int(nullable: false),
                        IDis3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI3CashierID = c.Long(nullable: false),
                        IDI4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDis4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI4CashierID = c.Long(nullable: false),
                        IDI5 = c.Int(nullable: false),
                        IDis5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDiscount5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDI5CashierID = c.Long(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSDis = c.Boolean(nullable: false),
                        SDNo = c.Int(nullable: false),
                        SDID = c.Int(nullable: false),
                        SDIs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DDisCashierID = c.Long(nullable: false),
                        Nett = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationID = c.Int(nullable: false),
                        DocumentID = c.Int(nullable: false),
                        BillTypeID = c.Int(nullable: false),
                        SaleTypeID = c.Int(nullable: false),
                        Receipt = c.String(nullable: false, maxLength: 10),
                        SalesmanID = c.Long(nullable: false),
                        Salesman = c.String(maxLength: 15),
                        CustomerID = c.Long(nullable: false),
                        Customer = c.String(maxLength: 150),
                        CashierID = c.Long(nullable: false),
                        Cashier = c.String(maxLength: 15),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        RecDate = c.DateTime(nullable: false),
                        BaseUnitID = c.Long(nullable: false),
                        UnitNo = c.Int(nullable: false),
                        RowNo = c.Int(nullable: false),
                        IsRecall = c.Boolean(nullable: false),
                        RecallNO = c.String(maxLength: 20),
                        RecallAdv = c.Boolean(nullable: false),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsTax = c.Boolean(nullable: false),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStock = c.Boolean(nullable: false),
                        UpdateBy = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        ZNo = c.Long(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        TransStatus = c.Int(nullable: false),
                        ZDate = c.DateTime(),
                        IsPromotionApplied = c.Boolean(nullable: false),
                        PromotionID = c.Long(nullable: false),
                        IsPromotion = c.Int(nullable: false),
                        LocationIDBilling = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        OrderTerminalID = c.Int(nullable: false),
                        TicketID = c.Long(nullable: false),
                        OrderNo = c.Long(nullable: false),
                        IsPrinted = c.Boolean(nullable: false),
                        ItemComment = c.String(maxLength: 100),
                        Packs = c.Int(nullable: false),
                        IsCancelKOT = c.Boolean(nullable: false),
                        StewardID = c.Int(nullable: false),
                        StewardName = c.String(maxLength: 50),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceChargeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShiftNo = c.Long(nullable: false),
                        IsDayEnd = c.Boolean(nullable: false),
                        UpdateUnitNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionDetID);
            
            CreateTable(
                "dbo.TransactionRights",
                c => new
                    {
                        TransactionRightsID = c.Long(nullable: false, identity: true),
                        DocumentID = c.Int(nullable: false),
                        TransactionCode = c.String(nullable: false, maxLength: 15),
                        TransactionName = c.String(nullable: false, maxLength: 50),
                        TransactionTypeID = c.Int(nullable: false),
                        IsAccess = c.Boolean(nullable: false),
                        IsPause = c.Boolean(nullable: false),
                        IsSave = c.Boolean(nullable: false),
                        IsModify = c.Boolean(nullable: false),
                        IsView = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionRightsID);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        UnitNo = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitID);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserGroupID = c.Long(nullable: false, identity: true),
                        UserGroupName = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserGroupID);
            
            CreateTable(
                "dbo.UserGroupPrivileges",
                c => new
                    {
                        UserGroupPrivilegesID = c.Long(nullable: false, identity: true),
                        TransactionRightsID = c.Long(nullable: false),
                        UserGroupID = c.Long(nullable: false),
                        TransactionTypeID = c.Int(nullable: false),
                        IsAccess = c.Boolean(nullable: false),
                        IsPause = c.Boolean(nullable: false),
                        IsSave = c.Boolean(nullable: false),
                        IsModify = c.Boolean(nullable: false),
                        IsView = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserGroupPrivilegesID)
                .ForeignKey("dbo.UserGroup", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserGroupID);
            
            CreateTable(
                "dbo.UserMaster",
                c => new
                    {
                        UserMasterID = c.Long(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        UserName = c.String(maxLength: 15),
                        UserDescription = c.String(maxLength: 100),
                        Password = c.String(maxLength: 15),
                        UserGroupID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsUserCantChangePassword = c.Boolean(nullable: false),
                        IsUserMustChangePassword = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        EmployeeCode = c.String(maxLength: 15),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserMasterID);
            
            CreateTable(
                "dbo.UserPrivileges",
                c => new
                    {
                        UserPrivilegesID = c.Long(nullable: false, identity: true),
                        UserMasterID = c.Long(nullable: false),
                        TransactionRightsID = c.Long(nullable: false),
                        FormID = c.Long(nullable: false),
                        TransactionTypeID = c.Int(nullable: false),
                        IsAccess = c.Boolean(nullable: false),
                        IsPause = c.Boolean(nullable: false),
                        IsSave = c.Boolean(nullable: false),
                        IsModify = c.Boolean(nullable: false),
                        IsView = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPrivilegesID)
                .ForeignKey("dbo.UserMaster", t => t.UserMasterID, cascadeDelete: true)
                .Index(t => t.UserMasterID);
            
            CreateTable(
                "dbo.UserPrivilegesLocations",
                c => new
                    {
                        UserPrivilegesLocationsID = c.Long(nullable: false, identity: true),
                        UserMasterID = c.Long(nullable: false),
                        UserGroupID = c.Long(nullable: false),
                        LocationID = c.Int(nullable: false),
                        IsSelect = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserPrivilegesLocationsID)
                .ForeignKey("dbo.UserMaster", t => t.UserMasterID, cascadeDelete: true)
                .Index(t => t.UserMasterID);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        VehicleID = c.Long(nullable: false, identity: true),
                        RegistrationNo = c.String(nullable: false, maxLength: 50),
                        VehicleName = c.String(nullable: false, maxLength: 50),
                        EngineNo = c.String(maxLength: 50),
                        ChassesNo = c.String(maxLength: 50),
                        VehicleType = c.String(maxLength: 50),
                        FuelType = c.String(nullable: false, maxLength: 25),
                        Make = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        EngineCapacity = c.String(),
                        SeatingCapacity = c.String(),
                        Weight = c.Int(nullable: false),
                        Remark = c.String(maxLength: 150),
                        IsDelete = c.Boolean(nullable: false),
                        GroupOfCompanyID = c.Int(nullable: false),
                        CreatedUser = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedUser = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(nullable: false),
                        DataTransfer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPrivilegesLocations", "UserMasterID", "dbo.UserMaster");
            DropForeignKey("dbo.UserPrivileges", "UserMasterID", "dbo.UserMaster");
            DropForeignKey("dbo.UserGroupPrivileges", "UserGroupID", "dbo.UserGroup");
            DropForeignKey("dbo.LoyaltyCustomer", "LoyaltySuplimentary_LoyaltySuplimentaryID", "dbo.LoyaltySuplimentary");
            DropForeignKey("dbo.LoyaltyCardGenerationDetail", "LoyaltyCardGenerationHeaderID", "dbo.LoyaltyCardGenerationHeader");
            DropForeignKey("dbo.LgsPurchaseOrderDetail", "LgsPurchaseOrderHeaderID", "dbo.LgsPurchaseOrderHeader");
            DropForeignKey("dbo.LgsProductExtendedPropertyValue", "LgsProductMaster_LgsProductMasterID", "dbo.LgsProductMaster");
            DropForeignKey("dbo.LgsMaterialRequestDetail", "LgsMaterialRequestHeaderID", "dbo.LgsMaterialRequestHeader");
            DropForeignKey("dbo.LgsMaterialConsumptionDetail", "LgsMaterialConsumptionHeaderID", "dbo.LgsMaterialConsumptionHeader");
            DropForeignKey("dbo.LgsMaterialAllocationDetail", "LgsMaterialAllocationHeaderID", "dbo.LgsMaterialAllocationHeader");
            DropForeignKey("dbo.LgsMaintenanceJobAssignProductDetail", "LgsMaintenanceJobAssignHeaderID", "dbo.LgsMaintenanceJobAssignHeader");
            DropForeignKey("dbo.LgsMaintenanceJobAssignEmployeeDetail", "LgsMaintenanceJobAssignHeaderID", "dbo.LgsMaintenanceJobAssignHeader");
            DropForeignKey("dbo.LgsSubCategory2", "LgsSubCategoryID", "dbo.LgsSubCategory");
            DropForeignKey("dbo.LgsSubCategory", "LgsCategoryID", "dbo.LgsCategory");
            DropForeignKey("dbo.LgsCategory", "LgsDepartmentID", "dbo.LgsDepartment");
            DropForeignKey("dbo.InvPurchaseOrderDetail", "InvPurchaseOrderHeaderID", "dbo.InvPurchaseOrderHeader");
            DropForeignKey("dbo.InvPromotionDetailsSubTotal", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsSubCategoryDis", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsSubCategory2Dis", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsProductDis", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsGetYDetails", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsDepartmentDis", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsCategoryDis", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsBuyXSubCategory2", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsBuyXSubCategory", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsBuyXProduct", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsBuyXDepartment", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsBuyXCategory", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsAllowTypes", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.InvPromotionDetailsAllowLocations", "InvPromotionMasterID", "dbo.InvPromotionMaster");
            DropForeignKey("dbo.SupplierProperty", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.Supplier", "SupplierGroupID", "dbo.SupplierGroup");
            DropForeignKey("dbo.LgsSupplier", "SupplierGroupID", "dbo.SupplierGroup");
            DropForeignKey("dbo.LgsSupplierProperty", "LgsSupplierID", "dbo.LgsSupplier");
            DropForeignKey("dbo.LgsProductMaster", "UnitOfMeasureID", "dbo.UnitOfMeasure");
            DropForeignKey("dbo.InvProductMaster", "UnitOfMeasureID", "dbo.UnitOfMeasure");
            DropForeignKey("dbo.LgsProductMaster", "LgsSupplierID", "dbo.LgsSupplier");
            DropForeignKey("dbo.InvProductMaster", "SupplierID", "dbo.Supplier");
            DropForeignKey("dbo.InvGiftVoucherTransferNoteDetail", "InvGiftVoucherTransferNoteHeaderID", "dbo.InvGiftVoucherTransferNoteHeader");
            DropForeignKey("dbo.InvGiftVoucherPurchaseDetail", "InvGiftVoucherPurchaseHeaderID", "dbo.InvGiftVoucherPurchaseHeader");
            DropForeignKey("dbo.InvGiftVoucherBookCode", "InvGiftVoucherGroupID", "dbo.InvGiftVoucherGroup");
            DropForeignKey("dbo.InvGiftVoucherMaster", "InvGiftVoucherGroupID", "dbo.InvGiftVoucherGroup");
            DropForeignKey("dbo.InvGiftVoucherMaster", "InvGiftVoucherBookCodeID", "dbo.InvGiftVoucherBookCode");
            DropForeignKey("dbo.InvSubCategory2", "InvSubCategoryID", "dbo.InvSubCategory");
            DropForeignKey("dbo.InvSubCategory", "InvCategoryID", "dbo.InvCategory");
            DropForeignKey("dbo.InvCategory", "InvDepartmentID", "dbo.InvDepartment");
            DropForeignKey("dbo.HspRoom", "RoomFacility_HspRoomFacilityID", "dbo.HspRoomFacility");
            DropForeignKey("dbo.Location", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Company", "GroupOfCompanyID", "dbo.GroupOfCompany");
            DropForeignKey("dbo.Company", "CostCentreID", "dbo.CostCentre");
            DropForeignKey("dbo.Customer", "TerritoryID", "dbo.Territory");
            DropForeignKey("dbo.Territory", "AreaID", "dbo.Area");
            DropForeignKey("dbo.Customer", "PaymentMethodID", "dbo.PaymentMethod");
            DropForeignKey("dbo.Customer", "CustomerGroupID", "dbo.CustomerGroup");
            DropForeignKey("dbo.Customer", "AreaID", "dbo.Area");
            DropForeignKey("dbo.AccTransactionTemplateDetail", "AccTransactionTemplateHeaderID", "dbo.AccTransactionTemplateHeader");
            DropForeignKey("dbo.AccPettyCashVoucherDetail", "AccPettyCashVoucherHeaderID", "dbo.AccPettyCashVoucherHeader");
            DropForeignKey("dbo.AccPettyCashPaymentProcessDetail", "AccPettyCashPaymentProcessHeaderID", "dbo.AccPettyCashPaymentProcessHeader");
            DropForeignKey("dbo.AccPettyCashPaymentDetail", "AccPettyCashPaymentHeaderID", "dbo.AccPettyCashPaymentHeader");
            DropForeignKey("dbo.AccPettyCashIOUDetail", "AccPettyCashIOUHeaderID", "dbo.AccPettyCashIOUHeader");
            DropForeignKey("dbo.AccPettyCashBillDetail", "AccPettyCashBillHeaderID", "dbo.AccPettyCashBillHeader");
            DropForeignKey("dbo.AccOpenningBalanceDetail", "AccOpenningBalanceHeaderID", "dbo.AccOpenningBalanceHeader");
            DropForeignKey("dbo.AccJournalEntryDetail", "AccJournalEntryHeaderID", "dbo.AccJournalEntryHeader");
            DropForeignKey("dbo.AccGlTransactionDetail", "AccGlTransactionHeaderID", "dbo.AccGlTransactionHeader");
            DropForeignKey("dbo.AccDebitNoteDetail", "AccDebitNoteHeaderID", "dbo.AccDebitNoteHeader");
            DropForeignKey("dbo.AccCreditNoteDetail", "AccCreditNoteHeaderID", "dbo.AccCreditNoteHeader");
            DropForeignKey("dbo.AccChequeReturnDetail", "AccChequeReturnHeaderID", "dbo.AccChequeReturnHeader");
            DropForeignKey("dbo.AccChequeCancelDetail", "AccChequeCancelHeaderID", "dbo.AccChequeCancelHeader");
            DropForeignKey("dbo.AccBillEntryDetail", "AccBillEntryHeaderID", "dbo.AccBillEntryHeader");
            DropForeignKey("dbo.AccBankDepositDetail", "AccBankdepositheaderID", "dbo.AccBankDepositHeader");
            DropForeignKey("dbo.AccAccountReconciliationDetail", "AccAccountReconciliationHeaderID", "dbo.AccAccountReconciliationHeader");
            DropIndex("dbo.UserPrivilegesLocations", new[] { "UserMasterID" });
            DropIndex("dbo.UserPrivileges", new[] { "UserMasterID" });
            DropIndex("dbo.UserGroupPrivileges", new[] { "UserGroupID" });
            DropIndex("dbo.LoyaltyCustomer", new[] { "LoyaltySuplimentary_LoyaltySuplimentaryID" });
            DropIndex("dbo.LoyaltyCardGenerationDetail", new[] { "LoyaltyCardGenerationHeaderID" });
            DropIndex("dbo.LgsPurchaseOrderDetail", new[] { "LgsPurchaseOrderHeaderID" });
            DropIndex("dbo.LgsProductExtendedPropertyValue", new[] { "LgsProductMaster_LgsProductMasterID" });
            DropIndex("dbo.LgsMaterialRequestDetail", new[] { "LgsMaterialRequestHeaderID" });
            DropIndex("dbo.LgsMaterialConsumptionDetail", new[] { "LgsMaterialConsumptionHeaderID" });
            DropIndex("dbo.LgsMaterialAllocationDetail", new[] { "LgsMaterialAllocationHeaderID" });
            DropIndex("dbo.LgsMaintenanceJobAssignProductDetail", new[] { "LgsMaintenanceJobAssignHeaderID" });
            DropIndex("dbo.LgsMaintenanceJobAssignEmployeeDetail", new[] { "LgsMaintenanceJobAssignHeaderID" });
            DropIndex("dbo.LgsSubCategory2", new[] { "LgsSubCategoryID" });
            DropIndex("dbo.LgsSubCategory", new[] { "LgsCategoryID" });
            DropIndex("dbo.LgsCategory", new[] { "LgsDepartmentID" });
            DropIndex("dbo.InvPurchaseOrderDetail", new[] { "InvPurchaseOrderHeaderID" });
            DropIndex("dbo.InvPromotionDetailsSubTotal", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsSubCategoryDis", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsSubCategory2Dis", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsProductDis", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsGetYDetails", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsDepartmentDis", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsCategoryDis", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsBuyXSubCategory2", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsBuyXSubCategory", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsBuyXProduct", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsBuyXDepartment", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsBuyXCategory", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsAllowTypes", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.InvPromotionDetailsAllowLocations", new[] { "InvPromotionMasterID" });
            DropIndex("dbo.SupplierProperty", new[] { "SupplierID" });
            DropIndex("dbo.Supplier", new[] { "SupplierGroupID" });
            DropIndex("dbo.LgsSupplier", new[] { "SupplierGroupID" });
            DropIndex("dbo.LgsSupplierProperty", new[] { "LgsSupplierID" });
            DropIndex("dbo.LgsProductMaster", new[] { "UnitOfMeasureID" });
            DropIndex("dbo.InvProductMaster", new[] { "UnitOfMeasureID" });
            DropIndex("dbo.LgsProductMaster", new[] { "LgsSupplierID" });
            DropIndex("dbo.InvProductMaster", new[] { "SupplierID" });
            DropIndex("dbo.InvGiftVoucherTransferNoteDetail", new[] { "InvGiftVoucherTransferNoteHeaderID" });
            DropIndex("dbo.InvGiftVoucherPurchaseDetail", new[] { "InvGiftVoucherPurchaseHeaderID" });
            DropIndex("dbo.InvGiftVoucherBookCode", new[] { "InvGiftVoucherGroupID" });
            DropIndex("dbo.InvGiftVoucherMaster", new[] { "InvGiftVoucherGroupID" });
            DropIndex("dbo.InvGiftVoucherMaster", new[] { "InvGiftVoucherBookCodeID" });
            DropIndex("dbo.InvSubCategory2", new[] { "InvSubCategoryID" });
            DropIndex("dbo.InvSubCategory", new[] { "InvCategoryID" });
            DropIndex("dbo.InvCategory", new[] { "InvDepartmentID" });
            DropIndex("dbo.HspRoom", new[] { "RoomFacility_HspRoomFacilityID" });
            DropIndex("dbo.Location", new[] { "CompanyID" });
            DropIndex("dbo.Company", new[] { "GroupOfCompanyID" });
            DropIndex("dbo.Company", new[] { "CostCentreID" });
            DropIndex("dbo.Customer", new[] { "TerritoryID" });
            DropIndex("dbo.Territory", new[] { "AreaID" });
            DropIndex("dbo.Customer", new[] { "PaymentMethodID" });
            DropIndex("dbo.Customer", new[] { "CustomerGroupID" });
            DropIndex("dbo.Customer", new[] { "AreaID" });
            DropIndex("dbo.AccTransactionTemplateDetail", new[] { "AccTransactionTemplateHeaderID" });
            DropIndex("dbo.AccPettyCashVoucherDetail", new[] { "AccPettyCashVoucherHeaderID" });
            DropIndex("dbo.AccPettyCashPaymentProcessDetail", new[] { "AccPettyCashPaymentProcessHeaderID" });
            DropIndex("dbo.AccPettyCashPaymentDetail", new[] { "AccPettyCashPaymentHeaderID" });
            DropIndex("dbo.AccPettyCashIOUDetail", new[] { "AccPettyCashIOUHeaderID" });
            DropIndex("dbo.AccPettyCashBillDetail", new[] { "AccPettyCashBillHeaderID" });
            DropIndex("dbo.AccOpenningBalanceDetail", new[] { "AccOpenningBalanceHeaderID" });
            DropIndex("dbo.AccJournalEntryDetail", new[] { "AccJournalEntryHeaderID" });
            DropIndex("dbo.AccGlTransactionDetail", new[] { "AccGlTransactionHeaderID" });
            DropIndex("dbo.AccDebitNoteDetail", new[] { "AccDebitNoteHeaderID" });
            DropIndex("dbo.AccCreditNoteDetail", new[] { "AccCreditNoteHeaderID" });
            DropIndex("dbo.AccChequeReturnDetail", new[] { "AccChequeReturnHeaderID" });
            DropIndex("dbo.AccChequeCancelDetail", new[] { "AccChequeCancelHeaderID" });
            DropIndex("dbo.AccBillEntryDetail", new[] { "AccBillEntryHeaderID" });
            DropIndex("dbo.AccBankDepositDetail", new[] { "AccBankdepositheaderID" });
            DropIndex("dbo.AccAccountReconciliationDetail", new[] { "AccAccountReconciliationHeaderID" });
            DropTable("dbo.Vehicle");
            DropTable("dbo.UserPrivilegesLocations");
            DropTable("dbo.UserPrivileges");
            DropTable("dbo.UserMaster");
            DropTable("dbo.UserGroupPrivileges");
            DropTable("dbo.UserGroup");
            DropTable("dbo.Unit");
            DropTable("dbo.TransactionRights");
            DropTable("dbo.TransactionDet");
            DropTable("dbo.TransactionDetPromotion");
            DropTable("dbo.TempTransactionDet");
            DropTable("dbo.TempPurchaseBreakdown");
            DropTable("dbo.TempPromotionSale");
            DropTable("dbo.TempPosTransactionDet");
            DropTable("dbo.TempPosPaymentDet");
            DropTable("dbo.TempPointsBreakdown");
            DropTable("dbo.TempPaymentDet");
            DropTable("dbo.TempLoyaltyTransactionSummery");
            DropTable("dbo.TempLoyaltyPurchase");
            DropTable("dbo.TempLoyaltyPoint");
            DropTable("dbo.TempLocationWiseLoyaltyAnalysis");
            DropTable("dbo.TempInvProductBatchNoExpiaryDetail");
            DropTable("dbo.TempDailySalesSummary");
            DropTable("dbo.Tax");
            DropTable("dbo.TableDetail");
            DropTable("dbo.SystemFeature");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.SupplierWiseStockMovement");
            DropTable("dbo.SupplierPerformance");
            DropTable("dbo.SlabReference");
            DropTable("dbo.Shift");
            DropTable("dbo.ShiftDet");
            DropTable("dbo.ServiceOutHeader");
            DropTable("dbo.ServiceOutDetail");
            DropTable("dbo.ServiceInHeader");
            DropTable("dbo.ServiceInDetail");
            DropTable("dbo.SalesOrderHeader");
            DropTable("dbo.SalesOrderDetail");
            DropTable("dbo.RSalesSummary");
            DropTable("dbo.RestaurentReportCondition");
            DropTable("dbo.ReportGenerator");
            DropTable("dbo.ReferenceType");
            DropTable("dbo.PurchaseBreakdown");
            DropTable("dbo.ProductCodeDependancy");
            DropTable("dbo.PointsBreakdown");
            DropTable("dbo.PayType");
            DropTable("dbo.PaymentTerm");
            DropTable("dbo.PaymentDet");
            DropTable("dbo.PaidOutType");
            DropTable("dbo.PaidInType");
            DropTable("dbo.OrderTerminal");
            DropTable("dbo.OpeningStockHeader");
            DropTable("dbo.OpeningStockDetail");
            DropTable("dbo.LoyaltySuplimentary");
            DropTable("dbo.LoyaltyCustomer");
            DropTable("dbo.LoyaltyCardIssueHeader");
            DropTable("dbo.LoyaltyCardIssueDetail");
            DropTable("dbo.LoyaltyCardGenerationHeader");
            DropTable("dbo.LoyaltyCardGenerationDetail");
            DropTable("dbo.LoyaltyCardAllocation");
            DropTable("dbo.LostAndRenew");
            DropTable("dbo.LocationAssignedCostCentre");
            DropTable("dbo.LoanType");
            DropTable("dbo.LoanPurpose");
            DropTable("dbo.LgsTransferType");
            DropTable("dbo.LgsTransferNoteHeader");
            DropTable("dbo.LgsTransferNoteDetail");
            DropTable("dbo.LgsTmpProductStockDetail");
            DropTable("dbo.LgsStockAdjustmentHeader");
            DropTable("dbo.LgsStockAdjustmentDetail");
            DropTable("dbo.LgsSampleOutHeader");
            DropTable("dbo.LgsSampleOutDetail");
            DropTable("dbo.LgsSampleInHeader");
            DropTable("dbo.LgsSampleInDetail");
            DropTable("dbo.LgsReturnType");
            DropTable("dbo.LgsQuotationHeader");
            DropTable("dbo.LgsQuotationDetail");
            DropTable("dbo.LgsPurchaseOrderHeader");
            DropTable("dbo.LgsPurchaseOrderDetail");
            DropTable("dbo.LgsPurchaseHeader");
            DropTable("dbo.LgsPurchaseDetail");
            DropTable("dbo.LgsPurchase");
            DropTable("dbo.LgsProductUnitConversion");
            DropTable("dbo.LgsProductSupplierLink");
            DropTable("dbo.LgsProductStockMaster");
            DropTable("dbo.LgsProductSerialNo");
            DropTable("dbo.LgsProductSerialNoDetail");
            DropTable("dbo.LgsProductLink");
            DropTable("dbo.LgsProductExtendedPropertyValue");
            DropTable("dbo.LgsProductBatchNoExpiaryDetail");
            DropTable("dbo.LgsMaterialRequestHeader");
            DropTable("dbo.LgsMaterialRequestDetail");
            DropTable("dbo.LgsMaterialConsumptionDetail");
            DropTable("dbo.LgsMaterialConsumptionHeader");
            DropTable("dbo.LgsMaterialAllocationHeader");
            DropTable("dbo.LgsMaterialAllocationDetail");
            DropTable("dbo.LgsMaintenanceJobRequisitionHeader");
            DropTable("dbo.LgsMaintenanceJobAssignProductDetail");
            DropTable("dbo.LgsMaintenanceJobAssignHeader");
            DropTable("dbo.LgsMaintenanceJobAssignEmployeeDetail");
            DropTable("dbo.LgsSubCategory2");
            DropTable("dbo.LgsSubCategory");
            DropTable("dbo.LgsDepartment");
            DropTable("dbo.LgsCategory");
            DropTable("dbo.JobClass");
            DropTable("dbo.InvTransferType");
            DropTable("dbo.InvTransferNoteHeader");
            DropTable("dbo.InvTransferNoteDetail");
            DropTable("dbo.InvTmpReportDetail");
            DropTable("dbo.InvTmpProductStockDetails");
            DropTable("dbo.InvTempGrossProfit");
            DropTable("dbo.InvSubCategoryBillingLocationWise");
            DropTable("dbo.InvSubCategory2BillingLocationWise");
            DropTable("dbo.InvStockAdjustmentHeader");
            DropTable("dbo.InvStockAdjustmentDetail");
            DropTable("dbo.InvSize");
            DropTable("dbo.InvScannerData");
            DropTable("dbo.InvScanner");
            DropTable("dbo.InvSampleOutHeader");
            DropTable("dbo.InvSampleOutDetail");
            DropTable("dbo.InvSampleInHeader");
            DropTable("dbo.InvSampleInDetail");
            DropTable("dbo.InvSalesPerson");
            DropTable("dbo.InvSalesPayment");
            DropTable("dbo.InvSalesHeader");
            DropTable("dbo.InvSalesDetail");
            DropTable("dbo.InvSales");
            DropTable("dbo.InvReturnType");
            DropTable("dbo.InvReportBinCard");
            DropTable("dbo.InvQuotationHeader");
            DropTable("dbo.InvQuotationDetail");
            DropTable("dbo.InvPurchaseOrderHeader");
            DropTable("dbo.InvPurchaseOrderDetail");
            DropTable("dbo.InvPurchaseHeader");
            DropTable("dbo.InvPurchaseDetail");
            DropTable("dbo.InvPurchase");
            DropTable("dbo.InvPromotionType");
            DropTable("dbo.InvPromotionDetailsSubTotal");
            DropTable("dbo.InvPromotionDetailsSubCategoryDis");
            DropTable("dbo.InvPromotionDetailsSubCategory2Dis");
            DropTable("dbo.InvPromotionDetailsProductDis");
            DropTable("dbo.InvPromotionDetailsGetYDetails");
            DropTable("dbo.InvPromotionDetailsDepartmentDis");
            DropTable("dbo.InvPromotionDetailsCategoryDis");
            DropTable("dbo.InvPromotionDetailsBuyXSubCategory2");
            DropTable("dbo.InvPromotionDetailsBuyXSubCategory");
            DropTable("dbo.InvPromotionDetailsBuyXProduct");
            DropTable("dbo.InvPromotionDetailsBuyXDepartment");
            DropTable("dbo.InvPromotionDetailsBuyXCategory");
            DropTable("dbo.InvPromotionDetailsAllowTypes");
            DropTable("dbo.InvPromotionMaster");
            DropTable("dbo.InvPromotionDetailsAllowLocations");
            DropTable("dbo.InvProductUnitConversion");
            DropTable("dbo.InvProductType");
            DropTable("dbo.InvProductSupplierLink");
            DropTable("dbo.InvProductStockMaster");
            DropTable("dbo.InvProductSerialNo");
            DropTable("dbo.InvProductSerialNoDetail");
            DropTable("dbo.InvProductProperty");
            DropTable("dbo.InvProductPriceLink");
            DropTable("dbo.InvProductPriceChangeHeader");
            DropTable("dbo.InvProductPriceChangeHeaderDamage");
            DropTable("dbo.InvProductPriceChangeDetail");
            DropTable("dbo.InvProductPriceChangeDetailDamage");
            DropTable("dbo.SupplierProperty");
            DropTable("dbo.LgsSupplierProperty");
            DropTable("dbo.UnitOfMeasure");
            DropTable("dbo.LgsProductMaster");
            DropTable("dbo.LgsSupplier");
            DropTable("dbo.SupplierGroup");
            DropTable("dbo.Supplier");
            DropTable("dbo.InvProductMaster");
            DropTable("dbo.InvProductMasterBillingLocationWise");
            DropTable("dbo.InvProductLink");
            DropTable("dbo.InvProductExtendedValue");
            DropTable("dbo.InvProductExtendedPropertyValue");
            DropTable("dbo.InvProductExtendedProperty");
            DropTable("dbo.InvProductBatchNoExpiaryDetail");
            DropTable("dbo.InvProductAssemble");
            DropTable("dbo.InvPriceLevel");
            DropTable("dbo.InvPriceLevelList");
            DropTable("dbo.InvPosTerminalDetails");
            DropTable("dbo.InvPosConfiguration");
            DropTable("dbo.InvPaymentCardType");
            DropTable("dbo.InvoiceWiseSalesTemp");
            DropTable("dbo.InvLoyaltyTransaction");
            DropTable("dbo.InvKitchenBar");
            DropTable("dbo.InvGiftVoucherTransferNoteHeader");
            DropTable("dbo.InvGiftVoucherTransferNoteDetail");
            DropTable("dbo.InvGiftVoucherPurchaseOrderHeader");
            DropTable("dbo.InvGiftVoucherPurchaseOrderDetail");
            DropTable("dbo.InvGiftVoucherPurchaseHeader");
            DropTable("dbo.InvGiftVoucherPurchaseDetail");
            DropTable("dbo.InvGiftVoucherMaster");
            DropTable("dbo.InvGiftVoucherGroup");
            DropTable("dbo.InvGiftVoucherBookCode");
            DropTable("dbo.InvEmployeeTransaction");
            DropTable("dbo.InvDamageType");
            DropTable("dbo.InvCreditNoteHed");
            DropTable("dbo.InvCreditNoteDet");
            DropTable("dbo.InvSubCategory2");
            DropTable("dbo.InvSubCategory");
            DropTable("dbo.InvDepartment");
            DropTable("dbo.InvCategory");
            DropTable("dbo.InvBasketAnalysisValueRangeTemp");
            DropTable("dbo.InvBasketAnalysisValueRange");
            DropTable("dbo.InvBasketAnalysisSelectedLocationsTemp");
            DropTable("dbo.InvAgeAnalysisSlab");
            DropTable("dbo.InvAgeAnalysisSlabReportTable");
            DropTable("dbo.HspSpecialty");
            DropTable("dbo.HspRoom");
            DropTable("dbo.HspRoomFacilityDetails");
            DropTable("dbo.HspRoomFacility");
            DropTable("dbo.HspPatient");
            DropTable("dbo.HspDoctor");
            DropTable("dbo.HspChannelingCenterDetails");
            DropTable("dbo.HourlySales");
            DropTable("dbo.Helper");
            DropTable("dbo.FinancialPeriod");
            DropTable("dbo.FinancialInstitution");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeDesignationType");
            DropTable("dbo.EmployeeBackup");
            DropTable("dbo.Driver");
            DropTable("dbo.DocumentNumber");
            DropTable("dbo.DayStart");
            DropTable("dbo.CustomerFeedBack");
            DropTable("dbo.CurrencyHistory");
            DropTable("dbo.Currency");
            DropTable("dbo.CrmReportCondition");
            DropTable("dbo.CreditCardBankMaster");
            DropTable("dbo.Counter");
            DropTable("dbo.Location");
            DropTable("dbo.GroupOfCompany");
            DropTable("dbo.CostCentre");
            DropTable("dbo.Company");
            DropTable("dbo.CommissionSchema");
            DropTable("dbo.ChangedTablePaymentDet");
            DropTable("dbo.ChangedTableItemDet");
            DropTable("dbo.CashierPermission");
            DropTable("dbo.CashierGroup");
            DropTable("dbo.CashierFunction");
            DropTable("dbo.CardMaster");
            DropTable("dbo.CardGenerationSetting");
            DropTable("dbo.CardGenerationLocationSetting");
            DropTable("dbo.LoyaltyCardAllocationLog");
            DropTable("dbo.Broker");
            DropTable("dbo.BillingLocation");
            DropTable("dbo.BillingLocationAssignedCostCentre");
            DropTable("dbo.BankPos");
            DropTable("dbo.Bank");
            DropTable("dbo.BankBranch");
            DropTable("dbo.BankBin");
            DropTable("dbo.AutoGenerateInfo");
            DropTable("dbo.Territory");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.CustomerGroup");
            DropTable("dbo.Customer");
            DropTable("dbo.Area");
            DropTable("dbo.AccTransactionTypeDetail");
            DropTable("dbo.AccTransactionTemplateHeader");
            DropTable("dbo.AccTransactionTemplateDetail");
            DropTable("dbo.AccTransactionDefinition");
            DropTable("dbo.AccThirdPartyDownload");
            DropTable("dbo.AccSalesType");
            DropTable("dbo.AccSalesDownloadSetting");
            DropTable("dbo.AccSalesDownload");
            DropTable("dbo.AccPettyCashVoucherHeader");
            DropTable("dbo.AccPettyCashVoucherDetail");
            DropTable("dbo.AccPettyCashReimbursement");
            DropTable("dbo.AccPettyCashPaymentProcessHeader");
            DropTable("dbo.AccPettyCashPaymentProcessDetail");
            DropTable("dbo.AccPettyCashPaymentHeader");
            DropTable("dbo.AccPettyCashPaymentDetail");
            DropTable("dbo.AccPettyCashMaster");
            DropTable("dbo.AccPettyCashIOUHeader");
            DropTable("dbo.AccPettyCashIOUDetail");
            DropTable("dbo.AccPettyCashImprestDetail");
            DropTable("dbo.AccPettyCashBillHeader");
            DropTable("dbo.AccPettyCashBillDetail");
            DropTable("dbo.AccPaymentHeader");
            DropTable("dbo.AccPaymentDetail");
            DropTable("dbo.AccOpenningBalanceHeader");
            DropTable("dbo.AccOpenningBalanceDetail");
            DropTable("dbo.AccLoanEntryHeader");
            DropTable("dbo.AccLoanEntryDetail");
            DropTable("dbo.AccLedgerSerialNumber");
            DropTable("dbo.AccLedgerAccount");
            DropTable("dbo.AccJournalEntryHeader");
            DropTable("dbo.AccJournalEntryDetail");
            DropTable("dbo.AccGlTransactionDetailTemp");
            DropTable("dbo.AccGlTransactionHeader");
            DropTable("dbo.AccGlTransactionDetail");
            DropTable("dbo.AccDebitNoteHeader");
            DropTable("dbo.AccDebitNoteDetail");
            DropTable("dbo.AccCreditNoteHeader");
            DropTable("dbo.AccCreditNoteDetail");
            DropTable("dbo.AccChequeReturnDetail");
            DropTable("dbo.AccChequeReturnHeader");
            DropTable("dbo.AccChequeNoEntry");
            DropTable("dbo.AccChequeDetail");
            DropTable("dbo.AccChequeCancelDetail");
            DropTable("dbo.AccChequeCancelHeader");
            DropTable("dbo.AccCardCommission");
            DropTable("dbo.AccBudgetDetail");
            DropTable("dbo.AccBillEntryHeader");
            DropTable("dbo.AccBillEntryDetail");
            DropTable("dbo.AccBankDepositHeader");
            DropTable("dbo.AccBankDepositDetail");
            DropTable("dbo.AccAccountReconciliationHeader");
            DropTable("dbo.AccAccountReconciliationDetail");
        }
    }
}
