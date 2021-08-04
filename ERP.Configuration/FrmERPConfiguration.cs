﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ERP.Configuration
{
    public partial class FrmERPConfiguration : Form
    {
        public FrmERPConfiguration()
        {
            InitializeComponent();
        }
        String stConnection = "";

        SqlConnection myConn;

        private void GetServerDbNames()
        {
            List<String> databases = new List<String>();

            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

           

            String strConn;
            strConn = @"data source=" + txtServerIP.Text + ";initial catalog=" + cmbDatabase.Text + ";user id=sa; password=SYSMANAGER;packet size=4096;Min pool size=40";


            //create connection
            SqlConnection sqlConn = new SqlConnection(strConn);

            //open connection
            sqlConn.Open();

            //get databases
            DataTable tblDatabases = sqlConn.GetSchema("Databases");

            //close connection
            sqlConn.Close();

            //add to list
            foreach (DataRow row in tblDatabases.Rows)
            {
                String strDatabaseName = row["database_name"].ToString();

                databases.Add(strDatabaseName);


            }
            cmbDatabase.DataSource = databases;
            cmbDatabase.SelectedIndex = -1;
        }






        public void ExecuteSqlQuery(string sqlQuery)
        {
            try
            {
                stConnection = @"data source=" + txtServerIP.Text + ";initial catalog=" + cmbDatabase.Text + ";user id=sa; password=SYSMANAGER;packet size=4096;Min pool size=40";

                SqlConnection dbConn = new SqlConnection();
                dbConn.ConnectionString = stConnection;
                dbConn.Open();
                if (dbConn.State == ConnectionState.Open)
                {

                    SqlCommand cmd = new SqlCommand(sqlQuery, dbConn);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            #region  User Define Data Types
            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Cat' AND ss.name = N'dbo')
                                            DROP TYPE [dbo].[Cat] ;
                                            CREATE TYPE [dbo].[Cat] AS TABLE(
	                                            [InvCategoryID] [bigint] NULL
                                            ) ");
            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Dep' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[Dep];CREATE TYPE [dbo].[Dep] AS TABLE(
	                            [InvDepartmentID] [bigint] NULL
                            ) ");


            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'ExtendedProperty' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[ExtendedProperty] ; CREATE TYPE [dbo].[ExtendedProperty] AS TABLE(
	                            [InvProductExtendedPropertyID] [bigint] NULL
                            ) ");

            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Locations' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[Locations];CREATE TYPE [dbo].[Locations] AS TABLE(
	                            [LocationID] [int] NULL
                            ) ");
            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Product' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[Product]; CREATE TYPE [dbo].[Product] AS TABLE(
	                            [ProductID] [bigint] NULL
                            ) ");
            ExecuteSqlQuery(@" IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Slab' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[Slab];CREATE TYPE [dbo].[Slab] AS TABLE(
	                            [SlabName] [nvarchar](20) NULL
                            )");

            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'SubCat' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[SubCat];CREATE TYPE [dbo].[SubCat] AS TABLE(
	                            [InvSubCategoryID] [bigint] NULL
                            ) ");
            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'SubCat2' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[SubCat2];CREATE TYPE [dbo].[SubCat2] AS TABLE(
	                            [InvSubCategory2ID] [bigint] NULL
                            ) ");
            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Sup' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[Sup];CREATE TYPE [dbo].[Sup] AS TABLE(
	                            [SupplierID] [bigint] NULL
                            ) ");

            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'Terminals' AND ss.name = N'dbo')
                            DROP TYPE [dbo].[Terminals];CREATE TYPE [dbo].[Terminals] AS TABLE(
	                            [TerminalId] [int] NULL
                            ) ");

            #endregion

            #region spHourlySales
            ExecuteSqlQuery(@" drop  PROCEDURE [dbo].[spHourlySales]");
            ExecuteSqlQuery(@"  CREATE PROCEDURE [dbo].[spHourlySales]
                                                @UserId BIGINT ,
                                                @Slab Slab READONLY ,
                                                @FromDate DATETIME ,
                                                @ToDate DATETIME ,
                                                @Locations Locations READONLY
                                            AS
                                                BEGIN
                                                    DECLARE @RecCount BIGINT ,
                                                        @StrSql VARCHAR(MAX) ,
                                                        @CDateFrom DATE ,
                                                        @CDateTo DATE


                                                    BEGIN TRANSACTION InProc

                                                    TRUNCATE TABLE HourlySales

                                                    SET @CDateFrom = CAST(@FromDate AS DATE)
                                                    SET @CDateTo = CAST(@ToDate AS DATE)



                                                    --SET @RecCount = ( SELECT    ISNULL(COUNT(UserID), 0)
                                                    --                  FROM      InvTmpReportDetail
                                                    --                  WHERE     UserID <> @UserId
                                                    --                )
                                               --     IF ( @RecCount = 0 )
			                                            --BEGIN

			                                            --END
                                               --     ELSE
                                               --         BEGIN
                                               --             DELETE  FROM dbo.InvTmpReportDetail
                                               --             WHERE   UserID = @UserId
                                               --         END

                                                    DECLARE @start DATETIME ,
                                                        @end DATETIME

                                                    SET @start = @CDateFrom;
                                                    SET @end = @CDateTo;


                                                    INSERT  INTO dbo.HourlySales ( DateX, Slab, l.LocationCode, l.LocationName,
                                                                                   NetAmt, BillCount, DataTransfer,
                                                                                   GroupOfCompanyID, CreatedDate,
                                                                                   CreatedUser, ModifiedDate, ModifiedUser )
                                                            ( SELECT    d.thedate Datex, s.SlabName, l.LocationCode,
                                                                        l.LocationName, 0, 0, 0, 0, GETDATE(), '',
                                                                        GETDATE(), ''
                                                              FROM      dbo.ExplodeDates(@CDateFrom, @CDateTo) AS d
                                                                        CROSS JOIN @Slab s
                                                                        CROSS JOIN dbo.Location l
                                                                        INNER JOIN @Locations lt ON lt.locationID = l.LocationID
                                                            );


                                             --SELECT * FROM HourlySales

		                                            ;
                                                    WITH    temp
                                                              AS ( SELECT   CAST(s.DocumentDate AS DATE) DocumentDate,
                                                                            s.LocationCode, s.LocationName,
                                                                            SUM(s.NetAmount) NetAmount,
                                                                            SUM(s.BillCount) BillCount, hs.slab
                                                                   FROM     ( SELECT    DATEPART(HOUR, transactiontime) transactiontime,
                                                                                        SUM(NetAmount) NetAmount,
                                                                                        CAST(DocumentDate AS DATE) DocumentDate, LocationCode,
                                                                                        LocationName,
                                                                                        COUNT(DISTINCT ( DocumentNo )) AS BillCount
                                                                              FROM      InvSales
                                                                              GROUP BY  DATEPART(HOUR, transactiontime),
                                                                                        CAST(DocumentDate AS DATE), LocationCode,
                                                                                        LocationName
                                                                            ) s
                                                                            INNER JOIN ( SELECT CAST(LEFT(Slab, 2) AS INT) slabfrom,
                                                                                                slab,
                                                                                                CAST(DateX AS DATE) DateX,
                                                                                                LocationCode
                                                                                         FROM   dbo.HourlySales
                                                                                       ) hs ON s.TransactionTime = hs.slabfrom
                                                                                               AND CAST(s.DocumentDate AS DATE) = hs.DateX
                                                                                               AND s.LocationCode = hs.LocationCode
                                                                   WHERE    CAST(s.DocumentDate AS DATE) BETWEEN @CDateFrom
                                                                                                         AND
                                                                                                          @CDateTo
                                                                   GROUP BY s.LocationCode, s.LocationName, hs.slab,
                                                                            s.DocumentDate
                                                                 )
                                                        UPDATE  b
                                                        SET     b.datex = T.DocumentDate, b.LocationCode = T.LocationCode,
                                                                b.LocationName = T.LocationName, b.NetAmt = T.NetAmount,
                                                                b.BillCount = T.BillCount
                                                        FROM    dbo.HourlySales b
                                                                INNER JOIN temp t ON b.Slab = t.slab
                                                                                     AND b.LocationCode = t.LocationCode
                                                                                     AND b.DateX = t.DocumentDate


                                               --     SELECT  *        FROM    HourlySales


                                                    --DELETE  FROM dbo.HourlySales
                                                    --WHERE   NetAmt = 0

                                                    SELECT  DATEPART(HOUR, transactiontime), SUM(NetAmount)
                                                    FROM    InvSales
                                                    GROUP BY DATEPART(HOUR, transactiontime)

                                                    IF @@TRANCOUNT > 0
                                                        BEGIN
                                                            COMMIT TRANSACTION InProc;
                                                            SELECT  1 AS Result
                                                        END
                                                    ELSE
                                                        BEGIN
                                                            SELECT  0 AS Result
                                                        END







                                               --     SELECT  *        FROM    HourlySales


                                                    DELETE  FROM dbo.HourlySales
                                                    WHERE   NetAmt = 0

                                                    SELECT  DATEPART(HOUR, transactiontime), SUM(NetAmount)
                                                    FROM    InvSales
                                                    GROUP BY DATEPART(HOUR, transactiontime)

                                                    IF @@TRANCOUNT > 0
                                                        BEGIN
                                                            COMMIT TRANSACTION InProc;
                                                            SELECT  1 AS Result
                                                        END
                                                    ELSE
                                                        BEGIN
                                                            SELECT  0 AS Result
                                                        END


                                                END
                                                                                            ");

            #endregion

            #region spAddNewUserPrivilege
           

            ExecuteSqlQuery(@" alter PROCEDURE [dbo].[spAddNewUserPrivilege]
    @ModuleType INT ,
    @DocumentID INT ,
    @FormName NVARCHAR(45) ,
    @FormText NVARCHAR(90) ,
    @ReportType INT ,
    @Prefix NVARCHAR(5) ,
    @CodeLength INT ,
    @Suffix INT
AS
    DECLARE @usermasterid INT ,
        @usergroupid INT

    SET NOCOUNT ON

    BEGIN

        IF NOT EXISTS ( SELECT  AutoGenerateInfoID
                        FROM    dbo.AutoGenerateInfo
                        WHERE   ModuleType = @ModuleType
                                AND DocumentID = @DocumentID
                                AND FormName = @FormName
                                AND FormText = @FormText )
            BEGIN
                INSERT  INTO dbo.AutoGenerateInfo ( ModuleType, DocumentID,
                                                    FormId, FormName, FormText,
                                                    Prefix, CodeLength, Suffix,
                                                    AutoGenerete, AutoClear,
                                                    IsDepend, IsDependCode,
                                                    IsSupplierProduct,
                                                    IsOverWriteQty,
                                                    isLocationCode,
                                                    ReportPrefix, ReportType,
                                                    PoIsMandatory,
                                                    IsDispatchRecall,
                                                    IsBackDated, IsCard,
                                                    CardId, IsEntry,
                                                    IsSlabReport, IsActive,
                                                    Prefix2, IsConsignment,
                                                    IsRoundOff, IsAutoComplete,
                                                    IsUpdateProductImage,
                                                    IsAllowedInHO,
                                                    IsAllowedInOutlet )
                VALUES  ( @ModuleType, -- ModuleType - int
                          @DocumentID, -- DocumentID - int
                          @DocumentID, -- FormId - int
                          @FormName, -- FormName - nvarchar(50)
                          @FormText, -- FormText - nvarchar(100)
                          @Prefix, -- Prefix - nvarchar(3)
                          @CodeLength, -- CodeLength - int
                          @Suffix, -- Suffix - int
                          0, -- AutoGenerete - bit
                          0, -- AutoClear - bit
                          0, -- IsDepend - bit
                          0, -- IsDependCode - bit
                          0, -- IsSupplierProduct - bit
                          0, -- IsOverWriteQty - bit
                          0, -- isLocationCode - bit
                          N'', -- ReportPrefix - nvarchar(3)
                          @ReportType, -- ReportType - int
                          0, -- PoIsMandatory - bit
                          0, -- IsDispatchRecall - bit
                          0, -- IsBackDated - bit
                          0, -- IsCard - bit
                          0, -- CardId - int
                          0, -- IsEntry - bit
                          0, -- IsSlabReport - bit
                          1, -- IsActive - bit
                          N'', -- Prefix2 - nvarchar(3)
                          0, -- IsConsignment - bit
                          0, -- IsRoundOff - bit
                          0, -- IsAutoComplete - bit
                          0, -- IsUpdateProductImage - bit
                          1, 1 )
            END


        IF NOT EXISTS ( SELECT  DocumentID
                        FROM    dbo.TransactionRights
                        WHERE   DocumentID = @DocumentID
                                AND TransactionName = @FormText )
            BEGIN

                INSERT  INTO dbo.TransactionRights ( DocumentID,
                                                     TransactionCode,
                                                     TransactionName,
                                                     TransactionTypeID,
                                                     IsAccess, IsPause, IsSave,
                                                     IsModify, IsView,
                                                     IsDelete,
                                                     GroupOfCompanyID,
                                                     CreatedUser, CreatedDate,
                                                     ModifiedUser,
                                                     ModifiedDate,
                                                     DataTransfer )
                        SELECT  DocumentID, -- DocumentID - int
                                Prefix, -- TransactionCode - nvarchar(15)
                                FormText, -- TransactionName - nvarchar(50)
                                ModuleType, -- TransactionTypeID - int
                                1, -- IsAccess - bit
                                1, -- IsPause - bit
                                1, -- IsSave - bit
                                1, -- IsModify - bit
                                0, -- IsView - bit
                                0, -- IsDelete - bit
                                ( SELECT    GroupOfCompanyID
                                  FROM      dbo.GroupOfCompany
                                  WHERE     IsActive = 1 ), -- GroupOfCompanyID - int
                                N'', -- CreatedUser - nvarchar(50)
                                '2014-12-01 06:15:33', -- CreatedDate - datetime
                                N'', -- ModifiedUser - nvarchar(50)
                                '2014-12-01 06:15:33', -- ModifiedDate - datetime
                                0  -- DataTransfer - int
                        FROM    AutoGenerateInfo
                        WHERE   DocumentID = @DocumentID

            END



        DECLARE db_cursor CURSOR
        FOR
            SELECT  usermasterid
            FROM    Usermaster
        OPEN db_cursor
        FETCH NEXT FROM db_cursor INTO @usermasterid
        WHILE @@FETCH_STATUS = 0
            BEGIN

                IF NOT EXISTS ( SELECT  UserMasterID
                                FROM    UserPrivileges
                                WHERE   UserMasterID = @usermasterid
                                        AND FormID = @DocumentID )
                    BEGIN


                        INSERT  INTO dbo.UserPrivileges ( UserMasterID,
                                                          TransactionRightsID,
                                                          FormID,
                                                          TransactionTypeID,
                                                          IsAccess, IsPause,
                                                          IsSave, IsModify,
                                                          IsView,
                                                          GroupOfCompanyID,
                                                          CreatedUser,
                                                          CreatedDate,
                                                          ModifiedUser,
                                                          ModifiedDate,
                                                          DataTransfer )
                                SELECT  @usermasterid, -- UserMasterID - bigint
                                        ai.AutoGenerateInfoID, -- TransactionRightsID - bigint
                                        ai.DocumentID, -- FormID - bigint
                                        tr.TransactionTypeID, -- TransactionTypeID - int
                                        1, -- IsAccess - bit
                                        1, -- IsPause - bit
                                        1, -- IsSave - bit
                                        1, -- IsModify - bit
                                        1, -- IsView - bit
                                        ( SELECT    GroupOfCompanyID
                                          FROM      dbo.GroupOfCompany
                                          WHERE     IsActive = 1 ), -- GroupOfCompanyID - int
                                        N'', -- CreatedUser - nvarchar(50)
                                        '2014-12-01 06:17:46', -- CreatedDate - datetime
                                        N'', -- ModifiedUser - nvarchar(50)
                                        '2014-12-01 06:17:46', -- ModifiedDate - datetime
                                        0  -- DataTransfer - int
                                FROM    AutoGenerateInfo ai
                                        INNER JOIN TransactionRights tr ON tr.DocumentID = ai.DocumentID
                                                              AND ai.DocumentID = @DocumentID


                    END
                FETCH NEXT FROM db_cursor INTO @usermasterid
            END

        CLOSE db_cursor
        DEALLOCATE db_cursor


        DECLARE db_cursor CURSOR
        FOR
            SELECT  UserGroupID
            FROM    UserGroup
        OPEN db_cursor
        FETCH NEXT FROM db_cursor INTO @usergroupid
        WHILE @@FETCH_STATUS = 0
            BEGIN

                IF NOT EXISTS ( SELECT  TransactionRightsID
                                FROM    UserGroupPrivileges u
                                        INNER JOIN dbo.AutoGenerateInfo a ON a.AutoGenerateInfoID = u.TransactionRightsID
                                WHERE   a.DocumentID = @DocumentID
                                        AND UserGroupID = @usergroupid )
                    BEGIN

                        INSERT  INTO dbo.UserGroupPrivileges ( TransactionRightsID,
                                                              UserGroupID,
                                                              TransactionTypeID,
                                                              IsAccess,
                                                              IsPause, IsSave,
                                                              IsModify, IsView,
                                                              IsDelete,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                SELECT  ai.AutoGenerateInfoID, -- TransactionRightsID - bigint
                                        @usergroupid, -- UserGroupID - bigint
                                        tr.TransactionTypeID, -- TransactionTypeID - int
                                        1, -- IsAccess - bit
                                        1, -- IsPause - bit
                                        1, -- IsSave - bit
                                        1, -- IsModify - bit
                                        1, -- IsView - bit
                                        0, -- IsDelete - bit
                                        ( SELECT    GroupOfCompanyID
                                          FROM      dbo.GroupOfCompany
                                          WHERE     IsActive = 1 ), -- GroupOfCompanyID - int
                                        N'', -- CreatedUser - nvarchar(50)
                                        '2014-12-01 06:20:41', -- CreatedDate - datetime
                                        N'', -- ModifiedUser - nvarchar(50)
                                        '2014-12-01 06:20:41', -- ModifiedDate - datetime
                                        0  -- DataTransfer - int
                                FROM    AutoGenerateInfo ai
                                        INNER JOIN TransactionRights tr ON tr.DocumentID = ai.DocumentID
                                                              AND ai.DocumentID = @DocumentID

                    END

                FETCH NEXT FROM db_cursor INTO @usergroupid
            END

        CLOSE db_cursor
        DEALLOCATE db_cursor



        IF @@TRANCOUNT > 0
            BEGIN
                COMMIT TRANSACTION InProc;
                SELECT  1 AS Result
            END
        ELSE
            BEGIN
                SELECT  0 AS Result
            END
    END ");

            #endregion

            #region spPOSCreditCard
            ExecuteSqlQuery(@" drop  PROCEDURE [dbo].[spPOSCreditCard]");
            ExecuteSqlQuery(@" CREATE PROCEDURE [dbo].[spPOSCreditCard]
    @LocationID INT ,
    @TerminalId INT ,
    @LogedUserId INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @LocationWise BIT
AS
    DECLARE @UserName VARCHAR(100)

    SET @UserName = ( SELECT    UserName
                      FROM      dbo.UserMaster
                      WHERE     UserMasterID = @LogedUserId )
    DELETE  FROM TempPosCreditCards
    WHERE   LoggedUserId = @LogedUserId



    IF @TerminalId = 0
        AND @LocationID = 0
        BEGIN
            INSERT  INTO dbo.TempPosCreditCards ( Receipt, RecDate, Cashier,
                                                  Bank, CardType, CardNo,
                                                  Amount, LoggedUserId,
                                                  LoggedUser, StartTime,
                                                  EndTime, LocationID,
                                                  DocumentID, TerminalID,
                                                  LocationCode, LocationName,
                                                  ZNo )
                    SELECT  P.Receipt, P.SDate, LEFT(E.EmployeeName,15), B.BankName,
                            P.Descrip, P.RefNo, SUM(P.Amount), @LogedUserId,
                            @UserName, GETDATE(), GETDATE(), l.LocationID, 0,
                            p.UnitNo, l.LocationCode, l.locationname, p.ZNo
                    FROM    dbo.PaymentDet p
                            INNER JOIN dbo.Paytype pt ON p.PayTypeID = pt.PaymentID
                            INNER JOIN dbo.Bank b ON p.BankId = b.BankID
                            INNER JOIN dbo.Employee E ON P.CashierID = E.EmployeeID
                            INNER JOIN dbo.Location l ON l.LocationID = p.LocationID
                    WHERE   p.Status = 1
                            AND p.BillTypeID = 1
                            AND p.SaleTypeID IN ( 1, 2 )
                            AND CAST(P.SDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY P.Receipt, P.SDate, P.CashierID, B.BankName,
                            P.Descrip, P.RefNo, l.LocationID, p.UnitNo,
                            l.LocationCode, l.locationname, p.ZNo,
                            E.EmployeeName

        END

    IF @TerminalId = 0
        AND @LocationID <> 0
        BEGIN
            INSERT  INTO dbo.TempPosCreditCards ( Receipt, RecDate, Cashier,
                                                  Bank, CardType, CardNo,
                                                  Amount, LoggedUserId,
                                                  LoggedUser, StartTime,
                                                  EndTime, LocationID,
                                                  DocumentID, TerminalID,
                                                  LocationCode, LocationName,
                                                  ZNo )
                    SELECT  P.Receipt, P.SDate, LEFT(E.EmployeeName,15), B.BankName,
                            P.Descrip, P.RefNo, SUM(P.Amount), @LogedUserId,
                            @UserName, GETDATE(), GETDATE(), l.LocationID, 0,
                            p.UnitNo, l.LocationCode, l.locationname, p.ZNo
                    FROM    dbo.PaymentDet p
                            INNER JOIN dbo.Paytype pt ON p.PayTypeID = pt.PaymentID
                            INNER JOIN dbo.Bank b ON p.BankId = b.BankID
                            INNER JOIN dbo.Employee E ON P.CashierID = E.EmployeeID
                            INNER JOIN dbo.Location l ON l.LocationID = p.LocationID
                    WHERE   p.Status = 1
                            AND p.BillTypeID = 1
                            AND p.SaleTypeID IN ( 1, 2 )
                            AND P.LocationID = @LocationID
                            AND CAST(P.SDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY P.Receipt, P.SDate, P.CashierID, B.BankName,
                            P.Descrip, P.RefNo, l.LocationID, p.UnitNo,
                            l.LocationCode, l.locationname, p.ZNo,
                            E.EmployeeName



        END


    IF @TerminalId <> 0
        AND @LocationID = 0
        BEGIN
            INSERT  INTO dbo.TempPosCreditCards ( Receipt, RecDate, Cashier,
                                                  Bank, CardType, CardNo,
                                                  Amount, LoggedUserId,
                                                  LoggedUser, StartTime,
                                                  EndTime, LocationID,
                                                  DocumentID, TerminalID,
                                                  LocationCode, LocationName,
                                                  ZNo )
                    SELECT  P.Receipt, P.SDate, LEFT(E.EmployeeName,15), B.BankName,
                            P.Descrip, P.RefNo, SUM(P.Amount), @LogedUserId,
                            @UserName, GETDATE(), GETDATE(), l.LocationID, 0,
                            p.UnitNo, l.LocationCode, l.locationname, p.ZNo
                    FROM    dbo.PaymentDet p
                            INNER JOIN dbo.Paytype pt ON p.PayTypeID = pt.PaymentID
                            INNER JOIN dbo.Bank b ON p.BankId = b.BankID
                            INNER JOIN dbo.Employee E ON P.CashierID = E.EmployeeID
                            INNER JOIN dbo.Location l ON l.LocationID = p.LocationID
                    WHERE   p.Status = 1
                            AND p.BillTypeID = 1
                            AND p.SaleTypeID IN ( 1, 2 )
                            AND P.UnitNo = @TerminalId
                            AND CAST(P.SDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY P.Receipt, P.SDate, P.CashierID, B.BankName,
                            P.Descrip, P.RefNo, l.LocationID, p.UnitNo,
                            l.LocationCode, l.locationname, p.ZNo,
                            E.EmployeeName

        END





    IF @TerminalId <> 0
        AND @LocationID <> 0
        BEGIN
            INSERT  INTO dbo.TempPosCreditCards ( Receipt, RecDate, Cashier,
                                                  Bank, CardType, CardNo,
                                                  Amount, LoggedUserId,
                                                  LoggedUser, StartTime,
                                                  EndTime, LocationID,
                                                  DocumentID, TerminalID,
                                                  LocationCode, LocationName,
                                                  ZNo )
                    SELECT  P.Receipt, P.SDate, LEFT(E.EmployeeName,15), B.BankName,
                            P.Descrip, P.RefNo, SUM(P.Amount), @LogedUserId,
                            @UserName, GETDATE(), GETDATE(), l.LocationID, 0,
                            p.UnitNo, l.LocationCode, l.locationname, p.ZNo
                    FROM    dbo.PaymentDet p
                            INNER JOIN dbo.Paytype pt ON p.PayTypeID = pt.PaymentID
                            INNER JOIN dbo.Bank b ON p.BankId = b.BankID
                            INNER JOIN dbo.Employee E ON P.CashierID = E.EmployeeID
                            INNER JOIN dbo.Location l ON l.LocationID = p.LocationID
                    WHERE   p.Status = 1
                            AND p.BillTypeID = 1
                            AND p.SaleTypeID IN ( 1, 2 )
                            AND P.LocationID = @LocationID
                            AND P.UnitNo = @TerminalId
                            AND CAST(P.SDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY P.Receipt, P.SDate, P.CashierID, B.BankName,
                            P.Descrip, P.RefNo, l.LocationID, p.UnitNo,
                            l.LocationCode, l.locationname, p.ZNo,
                            E.EmployeeName


        END");

            #endregion

            #region spPOSSalesBillWise
            ExecuteSqlQuery(@"drop PROCEDURE [dbo].[spPOSSalesBillWise] ");

            ExecuteSqlQuery(@"CREATE PROCEDURE [dbo].[spPOSSalesBillWise]
    @LocationID INT ,
    @TerminalId INT ,
    @LogedUserId INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @LocationWise BIT ,
    @DocumentID INT
AS
BEGIN
    DECLARE @UserName VARCHAR(100)

    SET @UserName = ( SELECT    UserName
                      FROM      dbo.UserMaster
                      WHERE     UserMasterID = @LogedUserId
                    )
    DELETE  FROM TempPosSale
    WHERE   LoggedUserId = @LogedUserId


    IF @TerminalId = 0
        AND @LocationID = 0
        BEGIN
            INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT  t.ProductCode AS ProductCode, p.BarCode AS BarCode,
                            p.ReferenceCode1 AS ReferenceCode1,
                            p.ReferenceCode2 AS ReferenceCode2,
                            p.ReferenceCode3 AS ReferenceCode3,
                            t.Descrip AS Descrip, t.Receipt AS Receipt,
                            CAST(t.RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                            t.Price AS Amount, SUM(t.Qty) AS Qty,
                            SUM(CASE WHEN ( DocumentID = 1
                                            OR DocumentID = 3
                                          ) THEN ( Amount )
                                     ELSE 0
                                END) - ( SUM(CASE WHEN ( DocumentID = 2
                                                         OR DocumentID = 4
                                                       ) THEN ( Amount )
                                                  ELSE 0
                                             END) )
                            - ( SUM(CASE WHEN ( t.ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) )
                            - ( ISNULL(SUM(CASE WHEN DocumentID = 1
                                                     OR DocumentID = 3
                                                THEN ( IDiscount1 + IDiscount2
                                                       + IDiscount3
                                                       + IDiscount4
                                                       + IDiscount5 )
                                                WHEN DocumentID = 2
                                                     OR DocumentID = 4
                                                THEN -( IDiscount1
                                                        + IDiscount2
                                                        + IDiscount3
                                                        + IDiscount4
                                                        + IDiscount5 )
                                                ELSE 0
                                           END), 0) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   --t.LocationID = @LocationID AND
                            Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                            GROUP BY t.ProductCode,p.BarCode,p.ReferenceCode1,p.ReferenceCode2,p.ReferenceCode3,t.Descrip,
                            t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode

             -- subtotal discount
              INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT '' AS ProductCode, '' AS BarCode,
                            '' AS ReferenceCode1,
                           '' AS ReferenceCode2,
                            '' AS ReferenceCode3,
                            'Sub Total Discount' AS Descrip, t.Receipt AS Receipt,
                            CAST(t.RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                            0 AS Amount,0 AS Qty,
                           ( -1) * ( SUM(CASE WHEN ( t.ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   --t.LocationID = @LocationID AND
                            Status = 1
                            AND t.ProductID = 0
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                            GROUP BY t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode



        END

    IF @TerminalId = 0
        AND @LocationID <> 0
        BEGIN
            INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT  t.ProductCode AS ProductCode, p.BarCode AS BarCode,
                            p.ReferenceCode1 AS ReferenceCode1,
                            p.ReferenceCode2 AS ReferenceCode2,
                            p.ReferenceCode3 AS ReferenceCode3,
                            t.Descrip AS Descrip, t.Receipt AS Receipt,
                            CAST(RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                            t.Price AS Amount, SUM(t.Qty) AS Qty,
                            SUM(CASE WHEN ( DocumentID = 1
                                            OR DocumentID = 3
                                          ) THEN ( Amount )
                                     ELSE 0
                                END) - ( SUM(CASE WHEN ( DocumentID = 2
                                                         OR DocumentID = 4
                                                       ) THEN ( Amount )
                                                  ELSE 0
                                             END) )
                            - ( SUM(CASE WHEN ( ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) )
                            - ( ISNULL(SUM(CASE WHEN DocumentID = 1
                                                     OR DocumentID = 3
                                                THEN ( IDiscount1 + IDiscount2
                                                       + IDiscount3
                                                       + IDiscount4
                                                       + IDiscount5 )
                                                WHEN DocumentID = 2
                                                     OR DocumentID = 4
                                                THEN -( IDiscount1
                                                        + IDiscount2
                                                        + IDiscount3
                                                        + IDiscount4
                                                        + IDiscount5 )
                                                ELSE 0
                                           END), 0) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   t.LocationID = @LocationID

                            AND Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY t.ProductCode,p.BarCode,p.ReferenceCode1,p.ReferenceCode2,p.ReferenceCode3,t.Descrip,
                            t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode


                     -- subtotla discont


                     INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT  '' AS ProductCode, '' AS BarCode,
                            '' AS ReferenceCode1,
                           '' AS ReferenceCode2,
                            '' AS ReferenceCode3,
                            'Sub Total Discount' AS Descrip, t.Receipt AS Receipt,
                            CAST(t.RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                            0 AS Amount,0 AS Qty,
                           ( -1) *  ( SUM(CASE WHEN ( t.ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   t.LocationID = @LocationID
                            AND t.ProductID = 0
                            AND Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY  t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode








        END


    IF @TerminalId <> 0
        AND @LocationID = 0
        BEGIN
            INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT  t.ProductCode AS ProductCode, p.BarCode AS BarCode,
                            p.ReferenceCode1 AS ReferenceCode1,
                            p.ReferenceCode2 AS ReferenceCode2,
                            p.ReferenceCode3 AS ReferenceCode3,
                            t.Descrip AS Descrip, t.Receipt AS Receipt,
                            CAST(RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                            t.Price AS Amount, SUM(t.Qty) AS Qty,
                            SUM(CASE WHEN ( DocumentID = 1
                                            OR DocumentID = 3
                                          ) THEN ( Amount )
                                     ELSE 0
                                END) - ( SUM(CASE WHEN ( DocumentID = 2
                                                         OR DocumentID = 4
                                                       ) THEN ( Amount )
                                                  ELSE 0
                                             END) )
                            - ( SUM(CASE WHEN ( ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) )
                            - ( ISNULL(SUM(CASE WHEN DocumentID = 1
                                                     OR DocumentID = 3
                                                THEN ( IDiscount1 + IDiscount2
                                                       + IDiscount3
                                                       + IDiscount4
                                                       + IDiscount5 )
                                                WHEN DocumentID = 2
                                                     OR DocumentID = 4
                                                THEN -( IDiscount1
                                                        + IDiscount2
                                                        + IDiscount3
                                                        + IDiscount4
                                                        + IDiscount5 )
                                                ELSE 0
                                           END), 0) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   t.UnitNo = @TerminalId

                            AND Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            --AND t.UnitNo=@TerminalId
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate

                            GROUP BY t.ProductCode,p.BarCode,p.ReferenceCode1,p.ReferenceCode2,p.ReferenceCode3,t.Descrip,
                            t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode
                     -- sub total discont


                      INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT  '' AS ProductCode, '' AS BarCode,
                            '' AS ReferenceCode1,
                           '' AS ReferenceCode2,
                            '' AS ReferenceCode3,
                            'Sub Total Discount' AS Descrip, t.Receipt AS Receipt,
                            CAST(t.RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                             0 AS Amount,0 AS Qty,
                           ( -1) *  ( SUM(CASE WHEN ( t.ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   t.UnitNo = @TerminalId
                           AND t.ProductID = 0
                            AND Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            --AND t.UnitNo=@TerminalId
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate

                            GROUP BY t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode










        END





    IF @TerminalId <> 0
        AND @LocationID <> 0
        BEGIN
            INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT  t.ProductCode AS ProductCode, p.BarCode AS BarCode,
                            p.ReferenceCode1 AS ReferenceCode1,
                            p.ReferenceCode2 AS ReferenceCode2,
                            p.ReferenceCode3 AS ReferenceCode3,
                            t.Descrip AS Descrip, t.Receipt AS Receipt,
                            CAST(RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                            t.Price AS Amount, SUM(t.Qty) AS Qty,
                            SUM(CASE WHEN ( DocumentID = 1
                                            OR DocumentID = 3
                                          ) THEN ( Amount )
                                     ELSE 0
                                END) - ( SUM(CASE WHEN ( DocumentID = 2
                                                         OR DocumentID = 4
                                                       ) THEN ( Amount )
                                                  ELSE 0
                                             END) )
                            - ( SUM(CASE WHEN ( ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) )
                            - ( ISNULL(SUM(CASE WHEN DocumentID = 1
                                                     OR DocumentID = 3
                                                THEN ( IDiscount1 + IDiscount2
                                                       + IDiscount3
                                                       + IDiscount4
                                                       + IDiscount5 )
                                                WHEN DocumentID = 2
                                                     OR DocumentID = 4
                                                THEN -( IDiscount1
                                                        + IDiscount2
                                                        + IDiscount3
                                                        + IDiscount4
                                                        + IDiscount5 )
                                                ELSE 0
                                           END), 0) ) AS Nett, @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   t.LocationID = @LocationID

                            AND Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            AND t.UnitNo = @TerminalId
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY t.ProductCode,p.BarCode,p.ReferenceCode1,p.ReferenceCode2,p.ReferenceCode3,t.Descrip,
                            t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode



        -- subtotla discount

         INSERT  INTO TempPosSale ( ProductCode, BarCode, ReferenceCode1,
                                       ReferenceCode2, ReferenceCode3,
                                       ProductName, Receipt, RecDate, Cashier,
                                       SellingPrice, Qty, Nett, LoggedUserId,
                                       StartTime, EndTime, LoggedUser,
                                       LocationID, DocumentID, TerminalID,
                                       LocationCode, LocationName, Type )
                    SELECT
      '' AS ProductCode, '' AS BarCode,
                            '' AS ReferenceCode1,
                           '' AS ReferenceCode2,
                            '' AS ReferenceCode3,
                            'Sub Total Discount' AS Descrip, t.Receipt AS Receipt,
                            CAST(t.RecDate AS DATE) AS RecDate, t.Cashier AS Cashier,
                             0 AS Amount,0 AS Qty,
                           ( -1) *  ( SUM(CASE WHEN ( t.ProductID = 0 )
                                         THEN ( SDiscount )
                                         ELSE 0
                                    END) ) AS Nett
      , @LogedUserId,
                            t.StartTime AS StartTime, t.EndTime AS EndTime,
                            @UserName AS UserName, t.LocationID AS LocationID,
                            @DocumentID, t.UnitNo AS UnitNo,
                            l.LocationCode AS LocationCode,
                            l.LocationName AS LocationName, t.ZNo AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   t.LocationID = @LocationID
                            AND t.ProductID = 0
                            AND Status = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND TransStatus = 1
                            AND t.UnitNo = @TerminalId
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                    GROUP BY
                            t.Receipt,CAST(RecDate AS DATE),t.Cashier,t.Price,t.StartTime,t.EndTime,t.LocationID,t.UnitNo,t.LocationID,l.LocationID,l.LocationName
                            ,t.ZNo,t.ProductCode,l.LocationCode



        END


END ");

            #endregion

            #region spPOSSalesRefund

            ExecuteSqlQuery(@" drop PROCEDURE [dbo].[spPOSSalesRefund] ");

            ExecuteSqlQuery(@"CREATE PROCEDURE [dbo].[spPOSSalesRefund]
    @LocationID INT ,
    @TerminalId INT ,
    @LogedUserId INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @LocationWise BIT ,
    @DocumentID INT
AS
    DECLARE @UserName VARCHAR(100)

    SET @UserName = ( SELECT    UserName
                      FROM      dbo.UserMaster
                      WHERE     UserMasterID = @LogedUserId
                    )
    DELETE  FROM TempPosSale
    WHERE   LoggedUserId = @LogedUserId


    IF @TerminalId = 0
        AND @LocationID = 0
        BEGIN
            INSERT  INTO TempPosSale
                    ( ProductCode ,
                      BarCode ,
                      ReferenceCode1 ,
                      ReferenceCode2 ,
                      ReferenceCode3 ,
                      ProductName ,
                      Receipt ,
                      RecDate ,
                      Cashier ,
                      SellingPrice ,
                      Qty ,
                      Nett ,
                      LoggedUserId ,
                      StartTime ,
                      EndTime ,
                      LoggedUser ,
                      LocationID ,
                      DocumentID ,
                      TerminalID ,
                      LocationCode ,
                      LocationName ,
                      Type
                    )
                    SELECT  t.ProductCode AS ProductCode ,
                            p.BarCode AS BarCode ,
                            p.ReferenceCode1 AS ReferenceCode1 ,
                            p.ReferenceCode2 AS ReferenceCode2 ,
                            p.ReferenceCode3 AS ReferenceCode3 ,
                            t.Descrip AS Descrip ,
                            t.Receipt AS Receipt ,
                            t.RecDate AS RecDate ,
                            t.Cashier AS Cashier ,
                            t.Price AS Amount ,
                            t.Qty AS Qty ,
                            t.Nett AS Nett ,
                            @LogedUserId ,
                            t.StartTime AS StartTime ,
                            t.EndTime AS EndTime ,
                            @UserName AS UserName ,
                            @LocationID  AS LocationID ,
                            @DocumentID ,
                            @TerminalId AS UnitNo ,
                            '' AS LocationCode ,
                            '' AS LocationName ,
                            '' AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            --INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   ( DocumentID = 2
                              OR DocumentID = 4
                            )
                            AND Status = 1
                            AND TransStatus = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate

        END

    IF @TerminalId = 0
        AND @LocationID <> 0
        BEGIN
            INSERT  INTO TempPosSale
                    ( ProductCode ,
                      BarCode ,
                      ReferenceCode1 ,
                      ReferenceCode2 ,
                      ReferenceCode3 ,
                      ProductName ,
                      Receipt ,
                      RecDate ,
                      Cashier ,
                      SellingPrice ,
                      Qty ,
                      Nett ,
                      LoggedUserId ,
                      StartTime ,
                      EndTime ,
                      LoggedUser ,
                      LocationID ,
                      DocumentID ,
                      TerminalID ,
                      LocationCode ,
                      LocationName ,
                      Type
                    )
                    SELECT  t.ProductCode AS ProductCode ,
                            p.BarCode AS BarCode ,
                            p.ReferenceCode1 AS ReferenceCode1 ,
                            p.ReferenceCode2 AS ReferenceCode2 ,
                            p.ReferenceCode3 AS ReferenceCode3 ,
                            t.Descrip AS Descrip ,
                            t.Receipt AS Receipt ,
                            t.RecDate AS RecDate ,
                            t.Cashier AS Cashier ,
                            t.Price AS Amount ,
                            t.Qty AS Qty ,
                            t.Nett AS Nett ,
                            @LogedUserId ,
                            t.StartTime AS StartTime ,
                            t.EndTime AS EndTime ,
                            @UserName AS UserName ,
                            t.LocationID AS LocationID ,
                            @DocumentID ,
                            @TerminalId AS UnitNo ,
                            l.LocationCode AS LocationCode ,
                            l.LocationName AS LocationName ,
                            '' AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   ( DocumentID = 2
                              OR DocumentID = 4
                            )
                            AND t.LocationID = @LocationID
                            AND Status = 1
                            AND TransStatus = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate


        END


    IF @TerminalId <> 0
        AND @LocationID = 0
        BEGIN
            INSERT  INTO TempPosSale
                    ( ProductCode ,
                      BarCode ,
                      ReferenceCode1 ,
                      ReferenceCode2 ,
                      ReferenceCode3 ,
                      ProductName ,
                      Receipt ,
                      RecDate ,
                      Cashier ,
                      SellingPrice ,
                      Qty ,
                      Nett ,
                      LoggedUserId ,
                      StartTime ,
                      EndTime ,
                      LoggedUser ,
                      LocationID ,
                      DocumentID ,
                      TerminalID ,
                      LocationCode ,
                      LocationName ,
                      Type
                    )
                    SELECT  t.ProductCode AS ProductCode ,
                            p.BarCode AS BarCode ,
                            p.ReferenceCode1 AS ReferenceCode1 ,
                            p.ReferenceCode2 AS ReferenceCode2 ,
                            p.ReferenceCode3 AS ReferenceCode3 ,
                            t.Descrip AS Descrip ,
                            t.Receipt AS Receipt ,
                            t.RecDate AS RecDate ,
                            t.Cashier AS Cashier ,
                            t.Price AS Amount ,
                            t.Qty AS Qty ,
                            t.Nett AS Nett ,
                            @LogedUserId ,
                            t.StartTime AS StartTime ,
                            t.EndTime AS EndTime ,
                            @UserName AS UserName ,
                            @LocationID AS LocationID ,
                            @DocumentID ,
                            t.UnitNo AS UnitNo ,
                            '' AS LocationCode ,
                            '' AS LocationName ,
                            '' AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            --INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   ( DocumentID = 2
                              OR DocumentID = 4
                            )
                            AND  t.UnitNo=@TerminalId
                            AND Status = 1
                            AND TransStatus = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
        END





    IF @TerminalId <> 0
        AND @LocationID <> 0
        BEGIN
            INSERT  INTO TempPosSale
                    ( ProductCode ,
                      BarCode ,
                      ReferenceCode1 ,
                      ReferenceCode2 ,
                      ReferenceCode3 ,
                      ProductName ,
                      Receipt ,
                      RecDate ,
                      Cashier ,
                      SellingPrice ,
                      Qty ,
                      Nett ,
                      LoggedUserId ,
                      StartTime ,
                      EndTime ,
                      LoggedUser ,
                      LocationID ,
                      DocumentID ,
                      TerminalID ,
                      LocationCode ,
                      LocationName ,
                      Type
                    )
                    SELECT  t.ProductCode AS ProductCode ,
                            p.BarCode AS BarCode ,
                            p.ReferenceCode1 AS ReferenceCode1 ,
                            p.ReferenceCode2 AS ReferenceCode2 ,
                            p.ReferenceCode3 AS ReferenceCode3 ,
                            t.Descrip AS Descrip ,
                            t.Receipt AS Receipt ,
                            t.RecDate AS RecDate ,
                            t.Cashier AS Cashier ,
                            t.Price AS Amount ,
                            t.Qty AS Qty ,
                            t.Nett AS Nett ,
                            @LogedUserId ,
                            t.StartTime AS StartTime ,
                            t.EndTime AS EndTime ,
                            @UserName AS UserName ,
                            t.LocationID AS LocationID ,
                            @DocumentID ,
                            t.UnitNo AS UnitNo ,
                            l.LocationCode AS LocationCode ,
                            l.LocationName AS LocationName ,
                            '' AS Type
                    FROM    TransactionDet t
                            INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                    WHERE   ( DocumentID = 2
                              OR DocumentID = 4
                            )
                            AND t.UnitNo=@TerminalId
                            AND T.LocationID=@LocationID
                            AND Status = 1
                            AND TransStatus = 1
                            AND SaleTypeID = 1
                            AND BillTypeID = 1
                            AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate


        END ");

            #endregion

            #region spPosSalesVoidError

            ExecuteSqlQuery(@" drop PROCEDURE [dbo].[spPosSalesVoidError] ");


            ExecuteSqlQuery(@"CREATE PROCEDURE [dbo].[spPosSalesVoidError]
    @LocationID INT ,
    @TerminalId INT ,
    @LogedUserId INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @LocationWise BIT ,
    @DocumentID INT
AS
    BEGIN

        DECLARE @UserName VARCHAR(100)

        SET @UserName = ( SELECT    UserName
                          FROM      dbo.UserMaster
                          WHERE     UserMasterID = @LogedUserId
                        )
        DELETE  FROM TempPosSale
        WHERE   LoggedUserId = @LogedUserId


        IF @TerminalId = 0
            AND @LocationID = 0
            BEGIN
                INSERT  INTO TempPosSale
                        ( ProductCode ,
                          BarCode ,
                          ReferenceCode1 ,
                          ReferenceCode2 ,
                          ReferenceCode3 ,
                          ProductName ,
                          Receipt ,
                          RecDate ,
                          Cashier ,
                          SellingPrice ,
                          Qty ,
                          Nett ,
                          LoggedUserId ,
                          StartTime ,
                          EndTime ,
                          LoggedUser ,
                          LocationID ,
                          DocumentID ,
                          TerminalID ,
                          LocationCode ,
                          LocationName ,
                          Type
                        )
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                @LocationID AS LocationID ,
                                @DocumentID ,
                                @TerminalId AS UnitNo ,
                                '' AS LocationCode ,
                                '' AS LocationName ,
                                'ERROR' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            --INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 7 )
                                AND Status = 1
                        --AND UnitNo =@TerminalId
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                        UNION ALL
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                @LocationID AS LocationID ,
                                @DocumentID ,
                                @TerminalId AS UnitNo ,
                                '' AS LocationCode ,
                                '' AS LocationName ,
                                'VOID' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            --INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 5 )
                                AND Status = 1
                        --AND UnitNo =@TerminalId
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
            END

        IF @TerminalId = 0
            AND @LocationID <> 0
            BEGIN
                INSERT  INTO TempPosSale
                        ( ProductCode ,
                          BarCode ,
                          ReferenceCode1 ,
                          ReferenceCode2 ,
                          ReferenceCode3 ,
                          ProductName ,
                          Receipt ,
                          RecDate ,
                          Cashier ,
                          SellingPrice ,
                          Qty ,
                          Nett ,
                          LoggedUserId ,
                          StartTime ,
                          EndTime ,
                          LoggedUser ,
                          LocationID ,
                          DocumentID ,
                          TerminalID ,
                          LocationCode ,
                          LocationName ,
                          Type
                        )
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                t.LocationID AS LocationID ,
                                @DocumentID ,
                                @TerminalId AS UnitNo ,
                                l.LocationCode AS LocationCode ,
                                l.LocationName AS LocationName ,
                                'ERROR' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                                INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 7 )
                                AND Status = 1
                                AND t.LocationID = @LocationID
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                        UNION ALL
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                t.LocationID AS LocationID ,
                                @DocumentID ,
                                @TerminalId AS UnitNo ,
                                l.LocationCode AS LocationCode ,
                                l.LocationName AS LocationName ,
                                'VOID' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                                INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 5 )
                                AND Status = 1
                                AND t.LocationID = @LocationID
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate

            END


        IF @TerminalId <> 0
            AND @LocationID = 0
            BEGIN
                INSERT  INTO TempPosSale
                        ( ProductCode ,
                          BarCode ,
                          ReferenceCode1 ,
                          ReferenceCode2 ,
                          ReferenceCode3 ,
                          ProductName ,
                          Receipt ,
                          RecDate ,
                          Cashier ,
                          SellingPrice ,
                          Qty ,
                          Nett ,
                          LoggedUserId ,
                          StartTime ,
                          EndTime ,
                          LoggedUser ,
                          LocationID ,
                          DocumentID ,
                          TerminalID ,
                          LocationCode ,
                          LocationName ,
                          Type
                        )
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                @LocationID AS LocationID ,
                                @DocumentID ,
                                t.UnitNo AS UnitNo ,
                                '' AS LocationCode ,
                                '' AS LocationName ,
                                'ERROR' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            --INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 7 )
                                AND Status = 1
                                AND t.UnitNo = @TerminalId
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                        UNION ALL
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                @LocationID AS LocationID ,
                                @DocumentID ,
                                t.UnitNo AS UnitNo ,
                                '' AS LocationCode ,
                                '' AS LocationName ,
                                'VOID' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                            --INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 5 )
                                AND Status = 1
                                AND t.UnitNo = @TerminalId
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate

            END





        IF @TerminalId <> 0
            AND @LocationID <> 0
            BEGIN
                INSERT  INTO TempPosSale
                        ( ProductCode ,
                          BarCode ,
                          ReferenceCode1 ,
                          ReferenceCode2 ,
                          ReferenceCode3 ,
                          ProductName ,
                          Receipt ,
                          RecDate ,
                          Cashier ,
                          SellingPrice ,
                          Qty ,
                          Nett ,
                          LoggedUserId ,
                          StartTime ,
                          EndTime ,
                          LoggedUser ,
                          LocationID ,
                          DocumentID ,
                          TerminalID ,
                          LocationCode ,
                          LocationName ,
                          Type
                        )
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                t.LocationID AS LocationID ,
                                @DocumentID ,
                                t.UnitNo AS UnitNo ,
                                l.LocationCode AS LocationCode ,
                                l.LocationName AS LocationName ,
                                'ERROR' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                                INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 7 )
                                AND Status = 1
                                AND t.UnitNo = @TerminalId
                                AND t.LocationID = @LocationID
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate
                        UNION ALL
                        SELECT  t.ProductCode AS ProductCode ,
                                p.BarCode AS BarCode ,
                                p.ReferenceCode1 AS ReferenceCode1 ,
                                p.ReferenceCode2 AS ReferenceCode2 ,
                                p.ReferenceCode3 AS ReferenceCode3 ,
                                t.Descrip AS Descrip ,
                                t.Receipt AS Receipt ,
                                t.RecDate AS RecDate ,
                                t.Cashier AS Cashier ,
                                t.Price AS Amount ,
                                t.Qty AS Qty ,
                                t.Nett AS Nett ,
                                @LogedUserId ,
                                t.StartTime AS StartTime ,
                                t.EndTime AS EndTime ,
                                @UserName AS UserName ,
                                t.LocationID AS LocationID ,
                                @DocumentID ,
                                t.UnitNo AS UnitNo ,
                                l.LocationCode AS LocationCode ,
                                l.LocationName AS LocationName ,
                                'VOID' AS Type
                        FROM    TransactionDet t
                                INNER JOIN dbo.InvProductMaster p ON p.ProductCode = t.ProductCode
                                INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                        WHERE   ( DocumentID = 5 )
                                AND Status = 1
                                AND t.UnitNo = @TerminalId
                                AND t.LocationID = @LocationID
                                AND CAST(RecDate AS DATE) BETWEEN @FromDate AND @ToDate

            END



    END
 ");
            #endregion

            #region spSupplierWiseReorderProducts

            ExecuteSqlQuery(@" drop PROCEDURE [dbo].[spSupplierWiseReorderProducts] ");

            ExecuteSqlQuery(@"CREATE PROCEDURE [dbo].[spSupplierWiseReorderProducts]
    @LocationID INT ,
    @LogedUserId INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @FromSupplier VARCHAR(15),
    @ToSupplier VARCHAR(15)
AS 
BEGIN
    DECLARE @UserName VARCHAR(100)
  
    SET @UserName = ( SELECT    UserName
                      FROM      dbo.UserMaster
                      WHERE     UserMasterID = @LogedUserId
                    )
    DELETE  FROM TempSupplierWiseReorderLevelProduct
    WHERE   LoggedUserId = @LogedUserId
	
	IF @LocationID = 0 
        BEGIN
            INSERT  INTO TempSupplierWiseReorderLevelProduct
                    ( ProductCode ,
                      ProductName ,
                      ReOrderQty ,
                      ReOrderLevel ,
                      Stock ,
                      LoggedUserId ,
                      LoggedUser ,
                      LocationID ,
                      LocationCode ,
                      LocationName ,
                      SupplierCode,
                      SupplierName
                    )
                    SELECT  p.ProductCode,
                            p.ProductName ,
                            t.ReOrderQuantity ,
                            t.ReOrderLevel ,
                            t.Stock,
                            @LogedUserId ,
                            @UserName  ,
                            @LocationID ,
                            L.LocationCode ,
                            L.LocationName,
                            s.SupplierCode AS supCode,
                            s.SupplierName
                    FROM    dbo.InvProductStockMaster t
                            INNER JOIN dbo.InvProductMaster p ON p.InvProductMasterID = t.ProductID
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                            INNER JOIN dbo.Supplier s ON s.SupplierID=p.SupplierID
                            WHERE
                    --  T.LocationID=@LocationID
						 t.ReOrderLevel >= t.Stock
                            AND CAST(s.SupplierCode AS VARCHAR(15)) BETWEEN @FromSupplier AND @ToSupplier
                    
        END
        
        
        IF @LocationID <> 0 
        BEGIN
            INSERT  INTO TempSupplierWiseReorderLevelProduct
                    ( ProductCode ,
                      ProductName ,
                      ReOrderQty ,
                      ReOrderLevel ,
                      Stock ,
                      LoggedUserId ,
                      LoggedUser ,
                      LocationID ,
                      LocationCode ,
                      LocationName ,
                      SupplierCode,
                      SupplierName
                    )
                    SELECT  p.ProductCode,
                            p.ProductName ,
                            t.ReOrderQuantity ,
                            t.ReOrderLevel ,
                            t.Stock,
                            @LogedUserId ,
                            @UserName  ,
                            @LocationID ,
                            L.LocationCode ,
                            L.LocationName,
                            s.SupplierCode AS supCode,
                            s.SupplierName
                    FROM    dbo.InvProductStockMaster t
                            INNER JOIN dbo.InvProductMaster p ON p.InvProductMasterID = t.ProductID
                            INNER JOIN dbo.Location l ON l.LocationID = t.LocationID
                            INNER JOIN dbo.Supplier s ON s.SupplierID=p.SupplierID
                    WHERE  T.LocationID=@LocationID
						AND t.ReOrderLevel >= t.Stock
                            AND CAST(s.SupplierCode AS VARCHAR(15)) BETWEEN @FromSupplier AND @ToSupplier
                    
        END
        
        END
");

            #endregion


            #region spReportGen
            ExecuteSqlQuery(@"DROP PROCEDURE[dbo].[spReportGen];");

            ExecuteSqlQuery(@"CREATE PROCEDURE [dbo].[spReportGen]

--By Sanjeewa
    @ProductCodeFrom VARCHAR(20) ,
    @ProductCodeTo VARCHAR(20) ,
    @CompanyId INT ,
    @LocationID INT ,
    @UserId BIGINT ,
    @Report VARCHAR(2) , -- 'SL','PU','ST'
    @ReportType VARCHAR(3) ,-- 'SUP','CUS'
    @Locations Locations READONLY ,
    @Dep Dep READONLY ,
    @Cat Cat READONLY ,
    @SubCat SubCat READONLY ,
    @SubCat2 SubCat2 READONLY ,
    @ExtendedProperties ExtendedProperty READONLY ,
    @Sup Sup READONLY ,
    @Amt BIT ,
    @Qty BIT ,
    --@CVal BIT ,
    --@SVal BIT ,
    @DisplayType VARCHAR(3) ,-- 'DTL','SUM'
    @DateFrom DATE ,
    @DateTo DATE
AS
    BEGIN
        DECLARE @RecCount BIGINT ,
            @RecCDept BIGINT ,
            @RecCCat BIGINT ,
            @RecCSub BIGINT ,
            @RecCSub2 BIGINT ,
            @RecCExt BIGINT ,
            @StrSql VARCHAR(MAX) ,
            @CDateFrom DATE ,
            @CDateTo DATE ,
            @Ext1 INT ,
            @Ext2 INT ,
            @Ext3 INT ,
            @Ext4 INT ,
            @Ext5 INT ,
            @RecCSup BIGINT ,
            @RecCLoca BIGINT

        BEGIN TRANSACTION InProc

        SET @CDateFrom = CAST(@DateFrom AS DATE)
        SET @CDateTo = CAST(@DateTo AS DATE)

        --SET @CDateFrom = CONVERT(VARCHAR(10), @DateFrom, 111)
        --SET @CDateTo =CONVERT(VARCHAR(10), @DateTo, 111)



        --SET @RecCount = ( SELECT    ISNULL(COUNT(UserID), 0)
        --                  FROM      InvTmpReportDetail
        --                  WHERE     UserID <> @UserId
        --                )
        --IF ( @RecCount = 0 )
        --    BEGIN
        TRUNCATE TABLE InvTmpReportDetail



        --    END
        --ELSE
        --    BEGIN
        --        DELETE  FROM dbo.InvTmpReportDetail
        --        WHERE   UserID = @UserId
        --    END
        SET @RecCDept = ( SELECT    ISNULL(COUNT(InvDepartmentID), 0)
                          FROM      @Dep )
        SET @RecCCat = ( SELECT ISNULL(COUNT(InvCategoryID), 0)
                         FROM   @Cat )
        SET @RecCSub = ( SELECT ISNULL(COUNT(InvSubCategoryID), 0)
                         FROM   @SubCat )
        SET @RecCSub2 = ( SELECT    ISNULL(COUNT(InvSubCategory2ID), 0)
                          FROM      @SubCat2 )
        SET @RecCExt = ( SELECT ISNULL(COUNT(InvProductExtendedPropertyID), 0)
                         FROM   @ExtendedProperties )

        SET @RecCSup = ( SELECT ISNULL(COUNT(SupplierID), 0)
                         FROM   @Sup )


        SET @RecCLoca = ( SELECT    ISNULL(COUNT(LocationID), 0)
                          FROM      @Locations )
  ---- **********


        IF ( @RecCSup > 0 )
            BEGIN

			--DELETE FROM InvTmpReportDetail WHERE SupplierID NOT IN (SELECT SupplierID FROM @Sup)



                IF ( @RecCDept <> 0
                     AND @RecCSup <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep ))

                    END

                IF ( @RecCCat <> 0
                     AND @RecCSup <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat ))

                    END

                IF ( @RecCSub <> 0
                     AND @RecCSup <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.SubCategoryID IN ( SELECT
                                                              SubCategoryID
                                                              FROM
                                                              @SubCat ))

                    END

                IF ( @RecCSub2 <> 0
                     AND @RecCSup <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.SubCategory2ID IN ( SELECT
                                                              SubCategory2ID
                                                              FROM
                                                              @SubCat2 ))

                    END



                IF ( @RecCSup <> 0
                     AND @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            H.SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            MAX(p.CostPrice), MAX(p.SellingPrice),
                                            MAX(p.AverageCost), 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
											INNER JOIN InvPurchaseDetail D ON P.InvProductMasterID = D.ProductID
                                            INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                                  WHERE     H.SupplierID IN ( SELECT
                                                              SupplierID
                                                              FROM
                                                              @Sup )
                                                               GROUP BY ProductID,ProductCode,InvProductMasterID,ProductName
                                  , DepartmentID,
                                            CategoryID,SubCategoryID,
                                            SubCategory2ID,h.SupplierID

                                            )

                    END



            END
        ELSE
            BEGIN

                IF ( @RecCDept <> 0
                     AND @RecCCat <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat ))
                    END

                IF ( @RecCDept <> 0
                     AND @RecCSub <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.SubCategoryID IN ( SELECT
                                                              InvSubCategoryID
                                                              FROM
                                                              @SubCat ))
                    END

                IF ( @RecCDept <> 0
                     AND @RecCSub2 <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.SubCategory2ID IN (
                                            SELECT  InvSubCategory2ID
                                            FROM    @SubCat2 ))
                    END


			-- **********
                IF ( @RecCCat <> 0
                     AND @RecCSub <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                            AND p.SubCategoryID IN ( SELECT
                                                              InvSubCategoryID
                                                              FROM
                                                              @SubCat ))
                    END

                IF ( @RecCCat <> 0
                     AND @RecCSub2 <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                            AND p.SubCategory2ID IN (
                                            SELECT  InvSubCategory2ID
                                            FROM    @SubCat2 ))
                    END

			---- **********



                IF ( @RecCDept <> 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   )
                    BEGIN


                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep ))

                    END

                IF ( @RecCDept = 0
                     AND @RecCCat <> 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   )
                    BEGIN

                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat ))
                    END

                IF ( @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub <> 0
                     AND @RecCSub2 = 0
                   )
                    BEGIN

                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.SubCategoryID IN ( SELECT
                                                              InvSubCategoryID
                                                              FROM
                                                              @SubCat ))
                    END

                IF ( @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 <> 0
                   )
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.SubCategory2ID IN (
                                            SELECT  InvSubCategory2ID
                                            FROM    @SubCat2 ))
                    END

                IF ( @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   )
                    BEGIN

                        INSERT  INTO dbo.InvTmpReportDetail ( CompanyID,
                                                              LocationID,
                                                              UserID,
                                                              DocumentDate,
                                                              DocumentNo,
                                                              UnitNo, ZNo,
                                                              CustomerID,
                                                              CustomerCode,
                                                              CustomerName,
                                                              SupplierID,
                                                              SupplierCode,
                                                              SupplierName,
                                                              ProductID,
                                                              ProductCode,
                                                              ProductName,
                                                              DepartmentID,
                                                              DepartmentCode,
                                                              DepartmentName,
                                                              CategoryID,
                                                              CategoryCode,
                                                              CategoryName,
                                                              SubCategoryID,
                                                              SubCategoryCode,
                                                              SubCategoryName,
                                                              SubCategory2ID,
                                                              SubCategory2Code,
                                                              SubCategory2Name,
                                                              BatchNo,
                                                              CostPrice,
                                                              SellingPrice,
                                                              AverageCost,
                                                              GrossProfit,
                                                              Qty01, Value01,
                                                              Qty02, Value02,
                                                              Qty03, Value03,
                                                              Qty04, Value04,
                                                              Qty05, Value05,
                                                              Qty06, Value06,
                                                              Qty07, Value07,
                                                              Qty08, Value08,
                                                              Qty09, Value09,
                                                              Qty10, Value10,
                                                              Qty11, Value11,
                                                              Qty12, Value12,
                                                              Qty13, Value13,
                                                              Qty14, Value14,
                                                              Qty15, Value15,
                                                              Qty16, Value16,
                                                              Qty17, Value17,
                                                              Qty18, Value18,
                                                              Qty19, Value19,
                                                              Qty20, Value20,
                                                              Qty21, Value21,
                                                              Qty22, Value22,
                                                              Qty23, Value23,
                                                              Qty24, Value24,
                                                              Qty25, Value25,
                                                              Qty26, Value26,
                                                              Qty27, Value27,
                                                              Qty28, Value28,
                                                              Qty29, Value29,
                                                              Qty30, Value30,
                                                              GroupOfCompanyID,
                                                              CreatedUser,
                                                              CreatedDate,
                                                              ModifiedUser,
                                                              ModifiedDate,
                                                              DataTransfer )
                                ( SELECT    @CompanyId, @LocationID, @UserId,
                                            GETDATE(), '', 0, 0, 0, '', '',
                                            SupplierID, '', '',
                                            InvProductMasterID, ProductCode,
                                            ProductName, DepartmentID, '', '',
                                            CategoryID, '', '', SubCategoryID,
                                            '', '', SubCategory2ID, '', '', '',
                                            p.CostPrice, p.SellingPrice,
                                            p.AverageCost, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0, 0, 0, '''',
                                            GETDATE(), '''', GETDATE(), 0
                                  FROM      dbo.InvProductMaster p)


                    END

            END

                -- UPDATE DEPARTMENT
        UPDATE  b
        SET     b.DepartmentCode = T.DepartmentCode,
                b.DepartmentName = T.DepartmentName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvDepartment t ( NOLOCK ) ON b.DepartmentID = t.InvDepartmentID

                         -- UPDATE CATEGORY
        UPDATE  b
        SET     b.CategoryCode = T.CategoryCode,
                b.CategoryName = T.CategoryName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvCategory t ( NOLOCK ) ON b.CategoryID = t.InvCategoryID

                         -- UPDATE SUBCATEGORY

        UPDATE  b
        SET     b.SubCategoryCode = T.SubCategoryCode,
                b.SubCategoryName = T.SubCategoryName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvSubCategory t ( NOLOCK ) ON b.SubCategoryID = t.InvSubCategoryID

                        -- UPDATE SUBCATEGORY2
        UPDATE  b
        SET     b.SubCategory2Code = T.SubCategory2Code,
                b.SubCategory2Name = T.SubCategory2Name
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvSubCategory2 t ( NOLOCK ) ON b.SubCategory2ID = t.InvSubCategory2ID

				-- UPDATE Supplier
        UPDATE  b
        SET     b.SupplierCode = T.SupplierCode,
                b.SupplierName = T.SupplierName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN dbo.Supplier t ( NOLOCK ) ON b.SupplierID = t.SupplierID
                --AND SupplierID IN (SELECT SupplierID)
                --         FROM   @Sup )




        DECLARE @Loca1 INT ,
            @Loca2 INT ,
            @Loca3 INT ,
            @Loca4 INT ,
            @Loca5 INT ,
            @Loca6 INT ,
            @Loca7 INT ,
            @Loca8 INT ,
            @Loca9 INT ,
            @Loca10 INT ,
            @Loca11 INT ,
            @Loca12 INT ,
            @Loca13 INT ,
            @Loca14 INT ,
            @Loca15 INT ,
            @Loca16 INT ,
            @Loca17 INT ,
            @Loca18 INT ,
            @Loca19 INT ,
            @Loca20 INT ,
            @Loca21 INT ,
            @Loca22 INT ,
            @Loca23 INT ,
            @Loca24 INT ,
            @Loca25 INT

-- SET LOCATIONS FROM VARIABLES


        SET @Loca1 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 1 )
        SET @Loca2 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 2 )
        SET @Loca3 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 3 )
        SET @Loca4 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 4 )
        SET @Loca5 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 5 )
        SET @Loca6 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 6 )
        SET @Loca7 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 7 )
        SET @Loca8 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 8 )
        SET @Loca9 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                       WHERE    row = 9 )
        SET @Loca10 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 10 )
        SET @Loca11 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 11 )
        SET @Loca12 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 12 )
        SET @Loca13 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 13 )
        SET @Loca14 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 14 )
        SET @Loca15 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 15 )
        SET @Loca16 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 16 )
        SET @Loca17 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 17 )
        SET @Loca18 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 18 )
        SET @Loca19 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 19 )
        SET @Loca20 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 20 )
        SET @Loca21 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 21 )
        SET @Loca22 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 22 )
        SET @Loca23 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 23 )
        SET @Loca24 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 24 )
        SET @Loca25 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID )
                                            AS 'row'
                                  FROM      @Locations ) AS temp
                        WHERE   row = 25 )




-- LAST PURCHASE DATE

	;
        WITH    cte
                  AS ( SELECT   MAX(d.DocumentDate) AS TopDocDate, ProductID,
                                SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1502
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                AND d.LocationID IN ( SELECT  LocationId
                                                      FROM    @Locations )
                                AND h.DocumentStatus = 1
                       GROUP BY ProductID, SupplierID)
            UPDATE  t
            SET     DocumentDate = cte.TopDocDate
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID


----------------Qty01 - LAST PURCHASE  QTY

;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY, d.ProductID,
                                SupplierID, MAX(d.DocumentDate) DocumentDate
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                                                              AND h.DocumentStatus = 1
                                                              AND d.LocationID IN (
                                                              SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                                INNER JOIN ( SELECT MAX(CAST(DocumentDate AS DATE))
                                                    AS TopDocDate, ProductID
                                             FROM   InvPurchaseDetail
                                             WHERE  DocumentID = 1502
                                                    AND CAST(DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                                    AND DocumentStatus = 1
                                                    AND LocationID IN ( SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                                             GROUP BY ProductID ) b ON d.ProductID = b.ProductID
                                                              AND CAST(d.DocumentDate AS DATE) = CAST(b.TopDocDate AS DATE)
                       WHERE    d.DocumentID = 1502
                       GROUP BY d.ProductID, h.SupplierID)
            UPDATE  t
            SET     Qty01 = cte.QTY
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID


----------------Qty02 - TOTAL PURCHASE  QTY

;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY, ProductID, SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1502
                                AND h.DocumentStatus = 1
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                AND d.LocationID IN ( SELECT  LocationId
                                                      FROM    @Locations )
                       GROUP BY d.ProductID, h.SupplierID)
            UPDATE  t
            SET     Qty02 = cte.QTY
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID

-- delete zoro purchase qty


-- ************

----------------Qty03 - TOTAL PURCHASE RETRUN QTY
;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY, ProductID, SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1503
                                AND h.DocumentStatus = 1
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                AND d.LocationID IN ( SELECT  LocationId
                                                      FROM    @Locations )
                       GROUP BY ProductID, SupplierID)
            UPDATE  t
            SET     Qty03 = cte.QTY
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID




        DECLARE @GROUPofCompany VARCHAR(30)

        SET @GROUPofCompany = ( SELECT  GroupOfCompanyName
                                FROM    dbo.GroupOfCompany
                                WHERE   IsActive = 1
                                        AND GroupOfCompanyName LIKE '%MANJARI%' )


        IF ( @GROUPofCompany = 'MANJARI' )
            BEGIN
-- ********** Qty05 UPDATE SALES AND RETURN

			-- galle sales

 ; WITH    temp
                          AS ( SELECT   td.ProductID,
                                        ISNULL(SUM(CASE WHEN DocumentID = 1
                                                        THEN td.Qty
                                                        WHEN DocumentID = 3
                                                        THEN td.Qty
                                                   END), 0) SALES,
                                        SUM(CASE WHEN DocumentID = 2
                                                 THEN td.Qty
                                                 WHEN DocumentID = 4
                                                 THEN td.Qty
                                            END) SALESRETURN
                               FROM     TransactionDet td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    [Status] = 1
                                        AND TransStatus = 1
                                        AND BillTypeID = 1
                                        AND SaleTypeID = 1
                                        AND CAST(td.RecDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                        AND td.LocationID = 2
                               GROUP BY td.ProductID)
                    UPDATE  b
                    SET     b.Qty04 = ISNULL(t.SALES, 0),
                            b.Qty05 = ISNULL(t.SALESRETURN, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID


			-- nugegoda sales
;
                WITH    temp
                          AS ( SELECT   td.ProductID,
                                        ISNULL(SUM(CASE WHEN DocumentID = 1
                                                        THEN td.Qty
                                                        WHEN DocumentID = 3
                                                        THEN td.Qty
                                                   END), 0) SALES,
                                        SUM(CASE WHEN DocumentID = 2
                                                 THEN td.Qty
                                                 WHEN DocumentID = 4
                                                 THEN td.Qty
                                            END) SALESRETURN
                               FROM     TransactionDet td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    [Status] = 1
                                        AND TransStatus = 1
                                        AND BillTypeID = 1
                                        AND SaleTypeID = 1
                                        AND CAST(td.RecDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                        AND td.LocationID = 3
                               GROUP BY td.ProductID)
                    UPDATE  b
                    SET     b.Qty08 = ISNULL(t.SALES, 0),
                            b.Qty09 = ISNULL(t.SALESRETURN, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID


--****************** Qty10 UPDATE Stock QTY

				-- manjari  HeadOffice  06

				;
                WITH    temp
                          AS ( SELECT   td.ProductID,
                                        ISNULL(SUM(td.Stock), 0) AS stock
                               FROM     dbo.InvProductStockMaster td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    td.IsDelete = 0
                                        AND td.LocationID IN ( 1 )
                               GROUP BY td.ProductID)
                    UPDATE  b
                    SET     b.Qty06 = ISNULL(T.Stock, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID


				-- manjari  galle stock  10

				;
                WITH    temp
                          AS ( SELECT   td.ProductID,
                                        ISNULL(SUM(td.Stock), 0) AS stock
                               FROM     dbo.InvProductStockMaster td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    td.IsDelete = 0
                                        AND td.LocationID IN ( 2, 6 )
                               GROUP BY td.ProductID)
                    UPDATE  b
                    SET     b.Qty10 = ISNULL(T.Stock, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID

                -- manjari  Nugegoda stock  11

                ;
                WITH    temp
                          AS ( SELECT   td.ProductID,
                                        ISNULL(SUM(td.Stock), 0) AS stock
                               FROM     dbo.InvProductStockMaster td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    td.IsDelete = 0
                                        AND td.LocationID IN ( 3, 7 )
                               GROUP BY td.ProductID)
                    UPDATE  b
                    SET     b.Qty11 = ISNULL(T.Stock, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID





            END
        ELSE
            BEGIN

;
                WITH    temp
                          AS ( SELECT   td.ProductID,
                                        ISNULL(SUM(CASE WHEN DocumentID = 1
                                                        THEN td.Qty
                                                        WHEN DocumentID = 3
                                                        THEN td.Qty
                                                   END), 0) SALES,
                                        SUM(CASE WHEN DocumentID = 2
                                                 THEN td.Qty
                                                 WHEN DocumentID = 4
                                                 THEN td.Qty
                                            END) SALESRETURN
                               FROM     TransactionDet td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    [Status] = 1
                                        AND TransStatus = 1
                                        AND BillTypeID = 1
                                        AND SaleTypeID = 1
                                        AND CAST(td.RecDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                        AND td.LocationID IN ( SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                               GROUP BY td.ProductID)
                    UPDATE  b
                    SET     b.Qty04 = ISNULL(t.SALES, 0),
                            b.Qty05 = ISNULL(t.SALESRETURN, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID


--****************** Qty06 UPDATE Stock QTY

                IF ( @RecCLoca > 0 )
                    BEGIN

				;
                        WITH    temp
                                  AS ( SELECT   td.ProductID,
                                                ISNULL(SUM(td.Stock), 0) AS stock
                                       FROM     dbo.InvProductStockMaster td
                                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                                       WHERE    td.IsDelete = 0
                                                AND td.LocationID IN ( SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                                       GROUP BY td.ProductID)
                            UPDATE  b
                            SET     b.Qty06 = ISNULL(T.Stock, 0)
                            FROM    InvTmpReportDetail b
                                    INNER JOIN temp t ON b.ProductID = t.ProductID


                    END
                ELSE
                    BEGIN

						  ;
                        WITH    temp
                                  AS ( SELECT   td.ProductID,
                                                ISNULL(SUM(td.Stock), 0) AS stock
                                       FROM     dbo.InvProductStockMaster td
                                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                                       WHERE    td.IsDelete = 0
                                       GROUP BY td.ProductID)
                            UPDATE  b
                            SET     b.Qty06 = ISNULL(T.Stock, 0)
                            FROM    InvTmpReportDetail b
                                    INNER JOIN temp t ON b.ProductID = t.ProductID

                    END

            END

        DELETE  FROM InvTmpReportDetail
        WHERE   ( Qty01 = 0
                  AND Qty02 = 0
                  AND Qty03 = 0
                  AND Qty04 = 0
                  AND Qty05 = 0
                  AND Qty06 = 0
                  AND Qty07 = 0
                  AND Qty08 = 0
                  AND Qty09 = 0
                  AND Qty10 = 0
                  AND Qty11 = 0
                  AND Qty12 = 0
                  AND Qty13 = 0
                  AND Qty14 = 0
                )

        IF @@TRANCOUNT > 0
            BEGIN
                COMMIT TRANSACTION InProc;
                SELECT  1 AS Result
            END
        ELSE
            BEGIN
                SELECT  0 AS Result
            END


    END
");
            #endregion

            #region AddNewUserPrivilege

            ExecuteSqlQuery(@"
EXEC [dbo].[spAddNewUserPrivilege] 2,10009,'InvRptMissingItem','InvRptMissingItem',2, '',0,0;
");


            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 8,19011,'SaveReportLayout','SaveReportLayout',2,'',0,0;
            ");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 8,19009,'PivotView','PivotView',2,'',0,0;
");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 2,8007,'Sales Refund Report','Sales Refund Report',2,'',0,0;
            ");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 2,8008,'Error Void Report','Error Void Report',2,'',0,0;
");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 2,8010,'Bill Wise Sales Report','Bill Wise Sales Report',2,'',0,0;
            ");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 2,8011,'Customer Credit Statement Report','Customer Credit Statement Report',2,'',0,0;
");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 1,40,'FrmDayEnd','FrmDayEnd',0,'',0,0 ;
            ");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 1,41,'FrmLevel','Level',0,'',3,3 ;
");


            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 1,42,'FrmPriceLevel','Price Level',0,'',3,3
");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 2,9006,'InvRptSupplierWiseStockMovement','Supplier Wise Stock Movement',2,'',0,0;

");

            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 1,9006,'InvRptSupplierWiseStockMovement','Supplier Wise Stock Movement',2,'',0,0;

");


            ExecuteSqlQuery(@"

EXEC [dbo].[spAddNewUserPrivilege] 2,9007,'FrmGLTransactions','GL Transactions',0,'',0,0;

");


            ExecuteSqlQuery(@"

    EXEC [dbo].[spAddNewUserPrivilege] 2,1514,'FrmCustomerDiscount','Customer Discount',0,'',1,1 ;
");

            #endregion

            #region spCalculateCurrentStock
            ExecuteSqlQuery(@" DROP PROCEDURE[dbo].[spCalculateCurrentStock]; 
");

            ExecuteSqlQuery(@"CREATE PROCEDURE [dbo].[spCalculateCurrentStock]
AS 
    DECLARE @LocationID INT

    BEGIN
	
        BEGIN TRANSACTION InProc
---Create TempTable
        IF EXISTS ( SELECT  *
                    FROM    sys.objects
                    WHERE   object_id = OBJECT_ID(N'[dbo].#tempCurrentStock')
                            AND type IN ( N'U' ) ) 
            DROP TABLE #tempCurrentStock
		
        CREATE TABLE #tempCurrentStock
            (
              [LocationID] [bigint] NOT NULL ,
              [ProductID] [bigint] NOT NULL ,
              [BatchNo] [nvarchar](25) NULL ,
              [Qty] [decimal](18, 2) NOT NULL
            )
	
        IF EXISTS ( SELECT  *
                    FROM    sys.objects
                    WHERE   object_id = OBJECT_ID(N'[dbo].#tempCurrentStockUpdate')
                            AND type IN ( N'U' ) ) 
            DROP TABLE #tempCurrentStockUpdate
		
        CREATE TABLE #tempCurrentStockUpdate
            (
              [LocationID] [bigint] NOT NULL ,
              [ProductID] [bigint] NOT NULL ,
              [BatchNo] [nvarchar](25) NULL ,
              [Qty] [decimal](18, 2) NOT NULL
            )
	


        DECLARE db_cursor CURSOR
        FOR
            SELECT  locationID
            FROM    Location
        OPEN db_cursor   
        FETCH NEXT FROM db_cursor INTO @LocationID
        WHILE @@FETCH_STATUS = 0 
            BEGIN 
					
				---Opening Stock
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  sd.LocationID ,
                                sd.ProductID ,
                                sd.BatchNo ,
                                SUM(sd.OrderQty)
                        FROM    OpeningStockDetail sd
                                INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                        WHERE   sd.DocumentStatus = 1
                                AND sh.OpeningStockType = 1
                                AND sd.DocumentID = 503
                                AND sd.LocationID = @LocationID
                        GROUP BY sd.LocationID ,
                                sd.ProductID ,
                                sd.BatchNo


				--GRN & Purchase Returns
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  pd.LocationID ,
                                pd.ProductID ,
                                pd.BatchNo ,
                                SUM(CASE pd.DocumentID
                                      WHEN 1502 THEN pd.Qty + pd.FreeQty
                                      WHEN 1503 THEN -1 * (pd.Qty + pd.FreeQty)
                                      ELSE 0
                                    END) AS QTY
                        FROM    InvPurchaseDetail pd
                        WHERE   pd.DocumentStatus = 1
                                AND ( pd.DocumentID IN ( 1502, 1503 ) )
                                AND pd.LocationID = @LocationID
                        GROUP BY pd.LocationID ,
                                pd.ProductID ,
                                pd.BatchNo


				--TOG IN
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  td.ToLocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                SUM(td.Qty)
                        FROM    InvTransferNoteDetail td
                        WHERE   td.DocumentStatus = 1
                                AND td.DocumentID = 1504
                                AND td.ToLocationID = @LocationID
                        GROUP BY td.ToLocationID ,
                                td.ProductID ,
                                td.BatchNo
						
						
				--TOG OUT
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  td.LocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                ( SUM(td.Qty) * -1 )
                        FROM    InvTransferNoteDetail td
                        WHERE   td.DocumentStatus = 1
                                AND td.DocumentID = 1504
                                AND td.LocationID = @LocationID
                        GROUP BY td.LocationID ,
                                td.ProductID ,
                                td.BatchNo	
					
				--Stock Adjustment (ADD)
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo ,
                                SUM(ad.ExcessQty)
                        FROM    InvStockAdjustmentDetail ad
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 1
                                AND ad.LocationID = @LocationID
                        GROUP BY ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo
					
				--Stock Adjustment (REDUSE)
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo ,
                                ( SUM(ad.ShortageQty) * -1 )
                        FROM    InvStockAdjustmentDetail ad
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 2
                                AND ad.LocationID = @LocationID
                        GROUP BY ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo
					--Stock Adjustment (OVERWRITE)
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo ,
                                SUM(ad.ExcessQty)
                        FROM    InvStockAdjustmentDetail ad
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 3
                                AND ad.LocationID = @LocationID
                        GROUP BY ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo
						
				--Sales & Returns	
                INSERT  INTO #tempCurrentStock
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  td.LocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                SUM(CASE DocumentID
                                      WHEN 1 THEN -Qty
                                      WHEN 3 THEN -Qty
                                      WHEN 2 THEN Qty
                                      WHEN 4 THEN Qty
                                      ELSE 0
                                    END)
                        FROM    TransactionDet td
                        WHERE   [Status] = 1
                                AND TransStatus = 1
                                AND td.LocationID = @LocationID
                                AND ( DocumentID IN ( 1, 2, 3, 4 ) )
                        GROUP BY td.LocationID ,
                                td.ProductID ,
                                td.BatchNo
					
					
                TRUNCATE TABLE #tempCurrentStockUpdate
					
                INSERT  INTO #tempCurrentStockUpdate
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  LocationID ,
                                ProductID ,
                                BatchNo ,
                                SUM(Qty)
                        FROM    #tempCurrentStock
                        WHERE   LocationID = @LocationID
                        GROUP BY LocationID ,
                                ProductID ,
                                BatchNo
					
					
					
               
					
                TRUNCATE TABLE #tempCurrentStockUpdate
					
                INSERT  INTO #tempCurrentStockUpdate
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty
                        )
                        SELECT  LocationID ,
                                ProductID ,
                                '' ,
                                SUM(Qty)
                        FROM    #tempCurrentStock
                        WHERE   LocationID = @LocationID
                        GROUP BY LocationID ,
                                ProductID
					
					
					
                UPDATE  InvProductStockMaster
                SET     Stock = 0
                WHERE   LocationID = @LocationID
									
	
                UPDATE  ps
                SET     ps.Stock = cs.Qty
                FROM    InvProductStockMaster ps
                        INNER JOIN #tempCurrentStockUpdate cs ON ps.ProductID = cs.ProductID
                                                              AND ps.LocationID = cs.LocationID
	

                FETCH NEXT FROM db_cursor INTO @LocationID   
            END   

        CLOSE db_cursor   
        DEALLOCATE db_cursor 
	
	
	
        IF @@TRANCOUNT > 0 
            BEGIN
                COMMIT TRANSACTION InProc;
                SELECT  1 AS Result
            END
        ELSE 
            BEGIN
                SELECT  0 AS Result
            END


    END
 ");

            #endregion

            #region DayEnd_DateRange
            ExecuteSqlQuery(@" IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DayEnd_DateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DayEnd_DateRange]; CREATE PROCEDURE [dbo].[DayEnd_DateRange]
    @DateFrom DATE ,
    @DateTo DATE
AS
    DELETE  FROM InvSales
    WHERE   CAST(DocumentDate AS DATE) BETWEEN @DateFrom
                                       AND     @DateTo

    INSERT  INTO dbo.InvSales ( SalesID, CompanyID, CompanyCode, CompanyName,
                                LocationID, LocationCode, LocationName,
                                CostCentreID, DocumentID, DocumentNo,
                                ReferenceNo, DocumentDate, TransactionTime,
                                CustomerType, CustomerID, CustomerCode,
                                CustomerName, SupplierID, SupplierCode,
                                SupplierName, SalesPersonID, SalesPersonCode,
                                SalesPersonName, GrossAmount,
                                DiscountPercentage, DiscountAmount, NetAmount,
                                SubTotalDiscountPercentage,
                                SubTotalDiscountAmount, CurrencyID,
                                CurrencyRate, DepartmentCode, DepartmentName,
                                CategoryCode, CategoryName, SubCategoryCode,
                                SubCategoryName, SubCategory2Code,
                                SubCategory2Name, ProductID, ProductCode,
                                ProductName, BarCode, BatchNo, ExpiryDate, Qty,
                                UnitOfMeasureID, UnitOfMeasureName, PackSize,
                                SellingPrice, WholeSalePrice, CostPrice,
                                AverageCost, DocumentStatus, IsFreeIssue,
                                TerminalNo, IsDispatch, IsUpLoad, IsDelete,
                                GroupOfCompanyID, CreatedUser, CreatedDate,
                                ModifiedUser, ModifiedDate, DataTransfer,
                                UnitNo, Zno, DepartmentID, CategoryID,
                                SubCategoryID, SubCategory2ID, IsBackOffice )
            SELECT  td.TransactionDetID, l.CompanyID, com.CompanyCode,
                    com.CompanyName, td.LocationID, l.LocationCode,
                    l.LocationName, l.CostCentreID, td.DocumentID, td.Receipt,
                    td.RefCode, TD.RecDate, td.StartTime, td.CustomerType,
                    td.CustomerID, '', '', ISNULL(pm.SupplierID, ''), '', '',
                    ISNULL(td.SalesmanID, 0), '', '', td.Amount, 0 AS disper,
                    ( td.IDiscount1 + td.IDiscount2 + td.IDiscount3
                      + td.IDiscount4 + td.IDiscount5 ) AS disamt, td.Nett, 0,
                    0, 0 AS curid, 0 AS curRate, '', '', '', '', '', '', '',
                    '', pm.InvProductMasterID, ISNULL(pm.ProductCode, ''),
                    ISNULL(pm.ProductName, ''), 0 AS barcode, td.BatchNo,
                    td.ExpiryDate, td.Qty, td.UnitOfMeasureID,
                    td.UnitOfMeasureName, pm.PackSize, td.Price,
                    pm.WholesalePrice, pm.CostPrice, pm.AverageCost,
                    td.Status AS status, 0 AS freeissue, td.UnitNo,
                    0 AS dispatch, 0 AS isupload, 0 isdelete,
                    td.GroupOfCompanyID, td.Cashier, -- em.JournalName ,
                    td.StartTime, td.Cashier, --em.JournalName ,
                    td.StartTime, 0 AS datatransfer, td.UnitNo, td.ZNo,
                    pm.DepartmentID, pm.CategoryID, pm.SubCategoryID,
                    pm.SubCategory2ID, 0
            FROM    TransactionDet td ( NOLOCK )
                    INNER JOIN InvProductMaster pm ( NOLOCK ) ON td.ProductID = pm.InvProductMasterID
                    INNER JOIN Location l ( NOLOCK ) ON l.LocationID = td.LocationID
                    INNER JOIN dbo.Company com ( NOLOCK ) ON com.CompanyID = l.CompanyID
            WHERE   ( DocumentID = 1
                      OR DocumentID = 3
                    )
                    AND Status = 1
                    AND TransStatus = 1
                    AND SaleTypeID = 1
                    AND BillTypeID = 1
                    AND CAST(TD.RecDate AS DATE) BETWEEN @DateFrom AND @DateTo

    INSERT  INTO dbo.InvSales ( SalesID, CompanyID, CompanyCode, CompanyName,
                                LocationID, LocationCode, LocationName,
                                CostCentreID, DocumentID, DocumentNo,
                                ReferenceNo, DocumentDate, TransactionTime,
                                CustomerType, CustomerID, CustomerCode,
                                CustomerName, SupplierID, SupplierCode,
                                SupplierName, SalesPersonID, SalesPersonCode,
                                SalesPersonName, GrossAmount,
                                DiscountPercentage, DiscountAmount, NetAmount,
                                SubTotalDiscountPercentage,
                                SubTotalDiscountAmount, CurrencyID,
                                CurrencyRate, DepartmentCode, DepartmentName,
                                CategoryCode, CategoryName, SubCategoryCode,
                                SubCategoryName, SubCategory2Code,
                                SubCategory2Name, ProductID, ProductCode,
                                ProductName, BarCode, BatchNo, ExpiryDate, Qty,
                                UnitOfMeasureID, UnitOfMeasureName, PackSize,
                                SellingPrice, WholeSalePrice, CostPrice,
                                AverageCost, DocumentStatus, IsFreeIssue,
                                TerminalNo, IsDispatch, IsUpLoad, IsDelete,
                                GroupOfCompanyID, CreatedUser, CreatedDate,
                                ModifiedUser, ModifiedDate, DataTransfer,
                                UnitNo, Zno, DepartmentID, CategoryID,
                                SubCategoryID, SubCategory2ID, IsBackOffice )
            SELECT  td.TransactionDetID, l.CompanyID, com.CompanyCode,
                    com.CompanyName, td.LocationID, l.LocationCode,
                    l.LocationName, l.CostCentreID, td.DocumentID, td.Receipt,
                    td.RefCode, TD.RecDate, td.StartTime, td.CustomerType,
                    td.CustomerID, '', '', ISNULL(pm.SupplierID, ''), '', '',
                    ISNULL(td.SalesmanID, 0), '', '', -1 * ( td.Amount ),
                    0 AS disper,
                    -1 * ( td.IDiscount1 + td.IDiscount2 + td.IDiscount3
                           + td.IDiscount4 + td.IDiscount5 ), -1 * ( td.Nett ),
                    -1 * ( td.SDIs ), -1 * ( td.SDiscount ), 0 AS curid,
                    0 AS curRate, '', '', '', '', '', '', '', '',
                    pm.InvProductMasterID, ISNULL(pm.ProductCode, ''),
                    ISNULL(pm.ProductName, ''), 0 AS barcode, td.BatchNo,
                    td.ExpiryDate, -1 * ( td.Qty ), td.UnitOfMeasureID,
                    td.UnitOfMeasureName, pm.PackSize, td.Price,
                    pm.WholesalePrice, pm.CostPrice, pm.AverageCost, td.Status,
                    0 AS freeissue, td.UnitNo, 0 AS dispatch, 0 AS isupload,
                    0 isdelete, td.GroupOfCompanyID, td.cashier, --em.JournalName ,
                    GETDATE(), td.cashier, --em.JournalName ,
                    GETDATE(), 0 AS datatransfer, td.UnitNo, td.ZNo,
                    pm.DepartmentID, pm.CategoryID, pm.SubCategoryID,
                    pm.SubCategory2ID, 0
            FROM    TransactionDet td ( NOLOCK )
                    INNER JOIN InvProductMaster pm ( NOLOCK ) ON td.ProductID = pm.InvProductMasterID
                    INNER JOIN Location l ( NOLOCK ) ON l.LocationID = td.LocationID
                    INNER JOIN dbo.Company com ( NOLOCK ) ON com.CompanyID = l.CompanyID
            WHERE   ( DocumentID = 2
                      OR DocumentID = 4
                    )
                    AND Status = 1
                    AND TransStatus = 1
                    AND SaleTypeID = 1
                    AND BillTypeID = 1
                    AND CAST(TD.RecDate AS DATE) BETWEEN @DateFrom AND @DateTo

				-- UPDATE DEPARTMENT
    UPDATE  b
    SET     b.DepartmentCode = T.DepartmentCode,
            b.DepartmentName = T.DepartmentName
    FROM    dbo.InvSales b ( NOLOCK )
            INNER JOIN InvDepartment t ( NOLOCK ) ON b.DepartmentID = t.InvDepartmentID
    WHERE   CAST(b.DocumentDate AS DATE) BETWEEN @DateFrom
                                         AND     @DateTo

                         -- UPDATE CATEGORY
    UPDATE  b
    SET     b.CategoryCode = T.CategoryCode, b.CategoryName = T.CategoryName
    FROM    dbo.InvSales b ( NOLOCK )
            INNER JOIN InvCategory t ( NOLOCK ) ON b.CategoryID = t.InvCategoryID
    WHERE   CAST(b.DocumentDate AS DATE) BETWEEN @DateFrom
                                         AND     @DateTo
                         -- UPDATE SUBCATEGORY

    UPDATE  b
    SET     b.SubCategoryCode = T.SubCategoryCode,
            b.SubCategoryName = T.SubCategoryName
    FROM    dbo.InvSales b ( NOLOCK )
            INNER JOIN InvSubCategory t ( NOLOCK ) ON b.SubCategoryID = t.InvSubCategoryID
    WHERE   CAST(b.DocumentDate AS DATE) BETWEEN @DateFrom
                                         AND     @DateTo
                        -- UPDATE SUBCATEGORY2
    UPDATE  b
    SET     b.SubCategory2Code = T.SubCategory2Code,
            b.SubCategory2Name = T.SubCategory2Name
    FROM    dbo.InvSales b ( NOLOCK )
            INNER JOIN InvSubCategory2 t ( NOLOCK ) ON b.SubCategory2ID = t.InvSubCategory2ID
    WHERE   CAST(b.DocumentDate AS DATE) BETWEEN @DateFrom
                                         AND     @DateTo
                         -- UPDATE Supplier
    UPDATE  b
    SET     b.SupplierCode = T.SupplierCode, b.SupplierName = T.SupplierName
    FROM    dbo.InvSales b ( NOLOCK )
            INNER JOIN dbo.Supplier t ( NOLOCK ) ON b.SupplierID = t.SupplierID
    WHERE   CAST(b.DocumentDate AS DATE) BETWEEN @DateFrom
                                         AND     @DateTo
                         -- UPDATE Customer
    UPDATE  b
    SET     b.CustomerCode = T.CustomerCode, b.CustomerName = T.CustomerName
    FROM    dbo.InvSales b ( NOLOCK )
            INNER JOIN dbo.LoyaltyCustomer t ( NOLOCK ) ON t.LoyaltyCustomerID = t.CustomerId
    WHERE   CAST(b.DocumentDate AS DATE) BETWEEN @DateFrom
                                         AND     @DateTo

 -- add subtotal discount per


		INSERT  INTO dbo.InvSales ( SalesID, CompanyID, CompanyCode, CompanyName,
		                            LocationID, LocationCode, LocationName,
		                            CostCentreID, DocumentID, DocumentNo,
		                            ReferenceNo, DocumentDate, TransactionTime,
		                            CustomerType, CustomerID, CustomerCode,
		                            CustomerName, SupplierID, SupplierCode,
		                            SupplierName, SalesPersonID, SalesPersonCode,
		                            SalesPersonName, GrossAmount,
		                            DiscountPercentage, DiscountAmount, NetAmount,
		                            SubTotalDiscountPercentage,
		                            SubTotalDiscountAmount, CurrencyID,
		                            CurrencyRate, DepartmentCode, DepartmentName,
		                            CategoryCode, CategoryName, SubCategoryCode,
		                            SubCategoryName, SubCategory2Code,
		                            SubCategory2Name, ProductID, ProductCode,
		                            ProductName, BarCode, BatchNo, ExpiryDate, Qty,
		                            UnitOfMeasureID, UnitOfMeasureName, PackSize,
		                            SellingPrice, WholeSalePrice, CostPrice,
		                            AverageCost, DocumentStatus, IsFreeIssue,
		                            TerminalNo, IsDispatch, IsUpLoad, IsDelete,
		                            GroupOfCompanyID, CreatedUser, CreatedDate,
		                            ModifiedUser, ModifiedDate, DataTransfer,
		                            UnitNo, Zno, DepartmentID, CategoryID,
		                            SubCategoryID, SubCategory2ID, IsBackOffice )
		        SELECT  td.TransactionDetID, l.CompanyID, com.CompanyCode,
		                com.CompanyName, td.LocationID, l.LocationCode,
		                l.LocationName, l.CostCentreID, 1, td.Receipt,
		                td.RefCode, TD.RecDate, td.StartTime, td.CustomerType,
		                td.CustomerID, '', '', 0, '', '', ISNULL(td.SalesmanID, 0),
		                '', '', 0 , 0 AS disper,
		                 ( SDiscount )AS disamt,
		                ( -1 )* ( SDiscount )AS Nett, 0, 0, 0 AS curid, 0 AS curRate, '',
		                '', '', '', '', '', '', '', 0, '', 'Subtotal Discount',
		                0 AS barcode, td.BatchNo, td.ExpiryDate, 0 Qty,
		                td.UnitOfMeasureID, td.UnitOfMeasureName, 0, 0, 0, 0, 0,
		                td.Status AS status, 0 AS freeissue, td.UnitNo,
		                0 AS dispatch, 0 AS isupload, 0 isdelete,
		                td.GroupOfCompanyID, td.Cashier, -- em.JournalName ,
		                td.StartTime, td.Cashier, --em.JournalName ,
		                td.StartTime, 0 AS datatransfer, td.UnitNo, td.ZNo, 0, 0,
		                0, 0, 0
		        FROM    TransactionDet td ( NOLOCK )
		                INNER JOIN Location l ( NOLOCK ) ON l.LocationID = td.LocationID
		                INNER JOIN dbo.Company com ( NOLOCK ) ON com.CompanyID = l.CompanyID
		        WHERE   DocumentID = 6
		                AND td.ProductID = 0
		                AND Status = 1
		                AND TransStatus = 1
		                AND SaleTypeID = 1
		                AND BillTypeID = 1


		                AND CAST(TD.RecDate AS DATE) BETWEEN @DateFrom AND @DateTo");
            #endregion

            #region TempCustomerCreditSettlements
            ExecuteSqlQuery(@"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempCustomerCreditSettlements]') AND type in (N'U'))
DROP TABLE [dbo].[TempCustomerCreditSettlements];
CREATE TABLE [dbo].[TempCustomerCreditSettlements] (
    [TempCustomerCreditSettlementsID] [bigint] NOT NULL IDENTITY,
    [CustomerCode] [nvarchar](15) NOT NULL,
    [CustomerName] [nvarchar](100) NOT NULL,
    [CreditLimit] [decimal](18, 2) NOT NULL,
    [Outstanding] [decimal](18, 2) NOT NULL,
    [ReceiptNo] [nvarchar](20),
    [ZNo] [int] NOT NULL,
    [Date] [datetime] NOT NULL,
    [Time] [datetime] NOT NULL,
    [CreditAmount] [decimal](18, 2) NOT NULL,
    [SettlementAmount] [decimal](18, 2) NOT NULL,
    [BillTotal] [decimal](18, 2) NOT NULL,
    [Paytype] [nvarchar](20),
    [LoggedUserId] [int] NOT NULL,
    [LoggedUser] [nvarchar](15),
    [UnitNo] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [LocationCode] [nvarchar](10),
    [LocationName] [nvarchar](50),
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.TempCustomerCreditSettlements] PRIMARY KEY ([TempCustomerCreditSettlementsID])
)

            ");


            #endregion

            #region TempSupplierWiseReorderLevelProduct



            ExecuteSqlQuery(@"CREATE TABLE [dbo].[TempSupplierWiseReorderLevelProduct] (
    [TempSupplierWiseReorderLevelProductID] [bigint] NOT NULL IDENTITY,
    [ProductCode] [nvarchar](25) NOT NULL,
    [ProductName] [nvarchar](50) NOT NULL,
    [ReOrderQty] [decimal](18, 2) NOT NULL,
    [ReOrderLevel] [decimal](18, 2) NOT NULL,
    [Stock] [decimal](18, 2) NOT NULL,
    [LoggedUserId] [int] NOT NULL,
    [LoggedUser] [nvarchar](15),
    [LocationID] [int] NOT NULL,
    [LocationCode] [nvarchar](10),
    [LocationName] [nvarchar](50),
    [SupplierCode] [nvarchar](15),
    [SupplierName] [nvarchar](100),
    CONSTRAINT [PK_dbo.TempSupplierWiseReorderLevelProduct] PRIMARY KEY ([TempSupplierWiseReorderLevelProductID])
)

");
            #endregion
            
            #region Account Table

            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAccountsTB]') AND type in (N'P', N'PC'))
                            DROP PROCEDURE [dbo].[spAccountsTB];");


            ExecuteSqlQuery(@"


CREATE PROCEDURE [dbo].[spAccountsTB]
AS
BEGIN

 

IF object_id(N'[dbo].[FK_dbo.AccAccountReconciliationDetail_dbo.AccAccountReconciliationHeader_AccAccountReconciliationHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccAccountReconciliationDetail] DROP CONSTRAINT [FK_dbo.AccAccountReconciliationDetail_dbo.AccAccountReconciliationHeader_AccAccountReconciliationHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccBankDepositDetail_dbo.AccBankDepositHeader_AccBankdepositheaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccBankDepositDetail] DROP CONSTRAINT [FK_dbo.AccBankDepositDetail_dbo.AccBankDepositHeader_AccBankdepositheaderID]
IF object_id(N'[dbo].[FK_dbo.AccBillEntryDetail_dbo.AccBillEntryHeader_AccBillEntryHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccBillEntryDetail] DROP CONSTRAINT [FK_dbo.AccBillEntryDetail_dbo.AccBillEntryHeader_AccBillEntryHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccChequeCancelDetail_dbo.AccChequeCancelHeader_AccChequeCancelHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccChequeCancelDetail] DROP CONSTRAINT [FK_dbo.AccChequeCancelDetail_dbo.AccChequeCancelHeader_AccChequeCancelHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccChequeReturnDetail_dbo.AccChequeReturnHeader_AccChequeReturnHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccChequeReturnDetail] DROP CONSTRAINT [FK_dbo.AccChequeReturnDetail_dbo.AccChequeReturnHeader_AccChequeReturnHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccCreditNoteDetail_dbo.AccCreditNoteHeader_AccCreditNoteHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccCreditNoteDetail] DROP CONSTRAINT [FK_dbo.AccCreditNoteDetail_dbo.AccCreditNoteHeader_AccCreditNoteHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccDebitNoteDetail_dbo.AccDebitNoteHeader_AccDebitNoteHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccDebitNoteDetail] DROP CONSTRAINT [FK_dbo.AccDebitNoteDetail_dbo.AccDebitNoteHeader_AccDebitNoteHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccJournalEntryDetail_dbo.AccJournalEntryHeader_AccJournalEntryHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccJournalEntryDetail] DROP CONSTRAINT [FK_dbo.AccJournalEntryDetail_dbo.AccJournalEntryHeader_AccJournalEntryHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccOpenningBalanceDetail_dbo.AccOpenningBalanceHeader_AccOpenningBalanceHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccOpenningBalanceDetail] DROP CONSTRAINT [FK_dbo.AccOpenningBalanceDetail_dbo.AccOpenningBalanceHeader_AccOpenningBalanceHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccPettyCashBillDetail_dbo.AccPettyCashBillHeader_AccPettyCashBillHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccPettyCashBillDetail] DROP CONSTRAINT [FK_dbo.AccPettyCashBillDetail_dbo.AccPettyCashBillHeader_AccPettyCashBillHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccPettyCashIOUDetail_dbo.AccPettyCashIOUHeader_AccPettyCashIOUHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccPettyCashIOUDetail] DROP CONSTRAINT [FK_dbo.AccPettyCashIOUDetail_dbo.AccPettyCashIOUHeader_AccPettyCashIOUHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccPettyCashPaymentDetail_dbo.AccPettyCashPaymentHeader_AccPettyCashPaymentHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccPettyCashPaymentDetail] DROP CONSTRAINT [FK_dbo.AccPettyCashPaymentDetail_dbo.AccPettyCashPaymentHeader_AccPettyCashPaymentHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccPettyCashPaymentProcessDetail_dbo.AccPettyCashPaymentProcessHeader_AccPettyCashPaymentProcessHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccPettyCashPaymentProcessDetail] DROP CONSTRAINT [FK_dbo.AccPettyCashPaymentProcessDetail_dbo.AccPettyCashPaymentProcessHeader_AccPettyCashPaymentProcessHeaderID]
IF object_id(N'[dbo].[FK_dbo.AccPettyCashVoucherDetail_dbo.AccPettyCashVoucherHeader_AccPettyCashVoucherHeaderID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[AccPettyCashVoucherDetail] DROP CONSTRAINT [FK_dbo.AccPettyCashVoucherDetail_dbo.AccPettyCashVoucherHeader_AccPettyCashVoucherHeaderID]
IF object_id(N'[dbo].[FK_dbo.HspRoom_dbo.HspRoomFacility_RoomFacility_HspRoomFacilityID]', N'F') IS NOT NULL
    ALTER TABLE [dbo].[HspRoom] DROP CONSTRAINT [FK_dbo.HspRoom_dbo.HspRoomFacility_RoomFacility_HspRoomFacilityID]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccAccountReconciliationHeaderID' AND object_id = object_id(N'[dbo].[AccAccountReconciliationDetail]', N'U'))
    DROP INDEX [IX_AccAccountReconciliationHeaderID] ON [dbo].[AccAccountReconciliationDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccBankdepositheaderID' AND object_id = object_id(N'[dbo].[AccBankDepositDetail]', N'U'))
    DROP INDEX [IX_AccBankdepositheaderID] ON [dbo].[AccBankDepositDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccBillEntryHeaderID' AND object_id = object_id(N'[dbo].[AccBillEntryDetail]', N'U'))
    DROP INDEX [IX_AccBillEntryHeaderID] ON [dbo].[AccBillEntryDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccChequeCancelHeaderID' AND object_id = object_id(N'[dbo].[AccChequeCancelDetail]', N'U'))
    DROP INDEX [IX_AccChequeCancelHeaderID] ON [dbo].[AccChequeCancelDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccChequeReturnHeaderID' AND object_id = object_id(N'[dbo].[AccChequeReturnDetail]', N'U'))
    DROP INDEX [IX_AccChequeReturnHeaderID] ON [dbo].[AccChequeReturnDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccCreditNoteHeaderID' AND object_id = object_id(N'[dbo].[AccCreditNoteDetail]', N'U'))
    DROP INDEX [IX_AccCreditNoteHeaderID] ON [dbo].[AccCreditNoteDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccDebitNoteHeaderID' AND object_id = object_id(N'[dbo].[AccDebitNoteDetail]', N'U'))
    DROP INDEX [IX_AccDebitNoteHeaderID] ON [dbo].[AccDebitNoteDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccJournalEntryHeaderID' AND object_id = object_id(N'[dbo].[AccJournalEntryDetail]', N'U'))
    DROP INDEX [IX_AccJournalEntryHeaderID] ON [dbo].[AccJournalEntryDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccOpenningBalanceHeaderID' AND object_id = object_id(N'[dbo].[AccOpenningBalanceDetail]', N'U'))
    DROP INDEX [IX_AccOpenningBalanceHeaderID] ON [dbo].[AccOpenningBalanceDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccPettyCashBillHeaderID' AND object_id = object_id(N'[dbo].[AccPettyCashBillDetail]', N'U'))
    DROP INDEX [IX_AccPettyCashBillHeaderID] ON [dbo].[AccPettyCashBillDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccPettyCashIOUHeaderID' AND object_id = object_id(N'[dbo].[AccPettyCashIOUDetail]', N'U'))
    DROP INDEX [IX_AccPettyCashIOUHeaderID] ON [dbo].[AccPettyCashIOUDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccPettyCashPaymentHeaderID' AND object_id = object_id(N'[dbo].[AccPettyCashPaymentDetail]', N'U'))
    DROP INDEX [IX_AccPettyCashPaymentHeaderID] ON [dbo].[AccPettyCashPaymentDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccPettyCashPaymentProcessHeaderID' AND object_id = object_id(N'[dbo].[AccPettyCashPaymentProcessDetail]', N'U'))
    DROP INDEX [IX_AccPettyCashPaymentProcessHeaderID] ON [dbo].[AccPettyCashPaymentProcessDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_AccPettyCashVoucherHeaderID' AND object_id = object_id(N'[dbo].[AccPettyCashVoucherDetail]', N'U'))
    DROP INDEX [IX_AccPettyCashVoucherHeaderID] ON [dbo].[AccPettyCashVoucherDetail]
IF EXISTS (SELECT name FROM sys.indexes WHERE name = N'IX_RoomFacility_HspRoomFacilityID' AND object_id = object_id(N'[dbo].[HspRoom]', N'U'))
    DROP INDEX [IX_RoomFacility_HspRoomFacilityID] ON [dbo].[HspRoom]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccAccountReconciliationDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccAccountReconciliationDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccAccountReconciliationHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccAccountReconciliationHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccAccountReconciliationDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccAccountReconciliationDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccBankDepositDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccBankDepositDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccBankDepositHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccBankDepositHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccBillEntryDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccBillEntryDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccBillEntryHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccBillEntryHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccBudgetDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccBudgetDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccCardCommission]') AND type in (N'U'))
DROP TABLE [dbo].[AccCardCommission]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccChequeCancelHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccChequeCancelHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccChequeCancelDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccChequeCancelDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccChequeReturnHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccChequeReturnHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccChequeReturnDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccChequeReturnDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccCreditNoteDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccCreditNoteDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccCreditNoteHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccCreditNoteHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccDebitNoteDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccDebitNoteHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccDebitNoteHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccAccountReconciliationDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccJournalEntryDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccJournalEntryDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccJournalEntryHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccJournalEntryHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccLedgerSerialNumber]') AND type in (N'U'))
DROP TABLE [dbo].[AccLedgerSerialNumber]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccLoanEntryDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccLoanEntryDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccLoanEntryHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccLoanEntryHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccOpenningBalanceDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccOpenningBalanceDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccOpenningBalanceHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccOpenningBalanceHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashBillDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashBillDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashBillHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashBillHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashImprestDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashImprestDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashIOUDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashIOUDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashIOUHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashIOUHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashMaster]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashMaster]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashPaymentDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashPaymentDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashPaymentHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashPaymentHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashPaymentProcessDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashPaymentProcessDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashPaymentProcessHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashPaymentProcessHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashReimbursement]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashReimbursement]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashVoucherDetail]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashVoucherDetail]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccPettyCashVoucherHeader]') AND type in (N'U'))
DROP TABLE [dbo].[AccPettyCashVoucherHeader]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccSalesType]') AND type in (N'U'))
DROP TABLE [dbo].[AccSalesType]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspChannelingCenterDetails]') AND type in (N'U'))
DROP TABLE [dbo].[HspChannelingCenterDetails]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspDoctor]') AND type in (N'U'))
DROP TABLE [dbo].[HspDoctor]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspPatient]') AND type in (N'U'))
DROP TABLE [dbo].[HspPatient]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspRoomFacility]') AND type in (N'U'))
DROP TABLE [dbo].[HspRoomFacility]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspRoomFacilityDetails]') AND type in (N'U'))
DROP TABLE [dbo].[HspRoomFacilityDetails]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspRoom]') AND type in (N'U'))
DROP TABLE [dbo].[HspRoom]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HspSpecialty]') AND type in (N'U'))
DROP TABLE [dbo].[HspSpecialty]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoanPurpose]') AND type in (N'U'))
DROP TABLE [dbo].[LoanPurpose]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoanType]') AND type in (N'U'))
DROP TABLE [dbo].[LoanType]


 

CREATE TABLE [dbo].[AccChequeDetail] (
    [AccChequeDetailID] [bigint] NOT NULL IDENTITY,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [DocumentNo] [nvarchar](25),
    [DocumentID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [ChequeDate] [datetime] NOT NULL,
    [AccLedgerAccountID] [bigint] NOT NULL,
    [BankID] [int] NOT NULL,
    [BankBranchID] [int] NOT NULL,
    [ReferenceCardTypeID] [int] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [PayeeName] [nvarchar](50),
    [ChequeNo] [nvarchar](15),
    [DepositedBankID] [bigint] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [ChequeType] [int] NOT NULL,
    [ChequeStatus] [int] NOT NULL,
    [TransactionType] [int] NOT NULL,
    [DocumentStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [LineNo] [int] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccChequeDetail] PRIMARY KEY ([AccChequeDetailID])
)
CREATE TABLE [dbo].[AccChequeNoEntry] (
    [AccChequeNoEntryID] [bigint] NOT NULL IDENTITY,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [DocumentNo] [nvarchar](25),
    [DocumentID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [CardNo] [nvarchar](15),
    [AccLedgerAccountID] [bigint] NOT NULL,
    [ChequeStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccChequeNoEntry] PRIMARY KEY ([AccChequeNoEntryID])
)
CREATE TABLE [dbo].[AccGlTransactionDetail] (
    [AccGlTransactionDetailID] [bigint] NOT NULL IDENTITY,
    [GlTransactionDetailID] [bigint] NOT NULL,
    [AccGlTransactionHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [AccLedgerAccountID] [bigint] NOT NULL,
    [LedgerSerial] [nvarchar](25),
    [DocumentID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [PaymentDate] [datetime] NOT NULL,
    [ReferenceCardTypeID] [bigint] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [DrCr] [int] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [TransactionTypeId] [int] NOT NULL,
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [ReferenceLocationID] [int] NOT NULL,
    [ReferenceDocumentNo] [nvarchar](25),
    [AccTransactionDefinitionID] [int] NOT NULL,
    [ChequeNo] [nvarchar](15),
    [ReferenceNo] [nvarchar](50),
    [Remark] [nvarchar](150),
    [DocumentStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [IsReconciled] [bit] NOT NULL,
    [TempReconciledStatus] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccGlTransactionDetail] PRIMARY KEY ([AccGlTransactionDetailID])
)
CREATE TABLE [dbo].[AccGlTransactionHeader] (
    [AccGlTransactionHeaderID] [bigint] NOT NULL IDENTITY,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [JobClassID] [bigint] NOT NULL,
    [DocumentNo] [nvarchar](25),
    [DocumentID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [ReferenceCardTypeID] [bigint] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceLocationID] [int] NOT NULL,
    [ReferenceDocumentNo] [nvarchar](25),
    [DocumentStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccGlTransactionHeader] PRIMARY KEY ([AccGlTransactionHeaderID])
)
CREATE TABLE [dbo].[AccGlTransactionDetailTemp] (
    [AccGlTransactionDetailTempID] [bigint] NOT NULL IDENTITY,
    [GlTransactionDetailTempID] [bigint] NOT NULL,
    [AccGlTransactionDetailID] [bigint] NOT NULL,
    [GlTransactionDetailID] [bigint] NOT NULL,
    [AccGlTransactionHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [AccLedgerAccountID] [bigint] NOT NULL,
    [LedgerSerial] [nvarchar](25),
    [DocumentID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [PaymentDate] [datetime] NOT NULL,
    [ReferenceCardTypeID] [bigint] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [DrCr] [int] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [TransactionTypeId] [int] NOT NULL,
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [ReferenceLocationID] [int] NOT NULL,
    [ReferenceDocumentNo] [nvarchar](25),
    [ChequeNo] [nvarchar](15),
    [ReferenceNo] [nvarchar](50),
    [Reference] [nvarchar](50),
    [Remark] [nvarchar](150),
    [DocumentStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [IsReconciled] [bit] NOT NULL,
    [TempReconciledStatus] [bit] NOT NULL,
    [AccTransactionDefinitionId] [int] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccGlTransactionDetailTemp] PRIMARY KEY ([AccGlTransactionDetailTempID])
)
CREATE TABLE [dbo].[AccLedgerAccount] (
    [AccLedgerAccountID] [bigint] NOT NULL IDENTITY,
    [LedgerType] [nvarchar](max) NOT NULL,
    [TypeLevel] [int] NOT NULL,
    [ParentIndex] [int] NOT NULL,
    [LedgerCode] [nvarchar](200) NOT NULL,
    [LedgerName] [nvarchar](100) NOT NULL,
    [BankID] [int] NOT NULL,
    [BankBranchID] [int] NOT NULL,
    [Remark] [nvarchar](150),
    [AccountStatus] [int] NOT NULL,
    [StandardDrCr] [int] NOT NULL,
    [StatementType] [int] NOT NULL,
    [IsLock] [bit] NOT NULL,
    [IsActive] [bit] NOT NULL,
    [IsDelete] [bit] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [AccountNo] [nvarchar](50),
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccLedgerAccount] PRIMARY KEY ([AccLedgerAccountID])
)
CREATE TABLE [dbo].[AccPaymentDetail] (
    [AccPaymentDetailID] [bigint] NOT NULL IDENTITY,
    [PaymentDetailID] [bigint] NOT NULL,
    [AccPaymentHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [DocumentID] [int] NOT NULL,
    [DocumentNo] [nvarchar](25),
    [DocumentDate] [datetime] NOT NULL,
    [PaymentDate] [datetime] NOT NULL,
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [ReferenceLocationID] [int] NOT NULL,
    [ReferenceDocumentNo] [nvarchar](25),
    [SetoffDocumentID] [bigint] NOT NULL,
    [SetoffDocumentDocumentID] [int] NOT NULL,
    [SetoffLocationID] [int] NOT NULL,
    [SetoffDocumentNo] [nvarchar](25),
    [ReferenceCardTypeID] [bigint] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [PaymentMethodID] [int] NOT NULL,
    [ReferenceLedgerID] [bigint] NOT NULL,
    [LedgerID] [bigint] NOT NULL,
    [AccLedgerAccountID] [bigint] NOT NULL,
    [BankID] [bigint] NOT NULL,
    [BankBranchID] [int] NOT NULL,
    [Remark] [nvarchar](150),
    [CardNo] [nvarchar](15),
    [ChequeDate] [datetime],
    [IsOverPaid] [bit] NOT NULL,
    [TransactionType] [int] NOT NULL,
    [DocumentStatus] [int] NOT NULL,
    [DepositStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccPaymentDetail] PRIMARY KEY ([AccPaymentDetailID])
)
CREATE TABLE [dbo].[AccPaymentHeader] (
    [AccPaymentHeaderID] [bigint] NOT NULL IDENTITY,
    [PaymentHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [JobClassID] [bigint] NOT NULL,
    [DocumentID] [int] NOT NULL,
    [DocumentNo] [nvarchar](25),
    [DocumentDate] [datetime] NOT NULL,
    [PaymentDate] [datetime] NOT NULL,
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [ReferenceLocationID] [int] NOT NULL,
    [ReferenceCardTypeID] [int] NOT NULL,
    [ReferenceLedgerID] [bigint] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [SalesPersonID] [bigint] NOT NULL,
    [CollectorName] [nvarchar](100),
    [CurrencyID] [int] NOT NULL,
    [CurrencyRate] [decimal](18, 2) NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [BalanceAmount] [decimal](18, 2) NOT NULL,
    [AdvanceAmount] [decimal](18, 2) NOT NULL,
    [ReferenceNo] [nvarchar](50),
    [ManualNo] [nvarchar](50),
    [Remark] [nvarchar](150),
    [DocumentType] [int] NOT NULL,
    [AdvancePaymentStatus] [int] NOT NULL,
    [TransactionType] [int] NOT NULL,
    [DocumentStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccPaymentHeader] PRIMARY KEY ([AccPaymentHeaderID])
)
CREATE TABLE [dbo].[AccTransactionDefinition] (
    [AccTransactionDefinitionID] [int] NOT NULL IDENTITY,
    [TransactionDefinitionCode] [int] NOT NULL,
    [TransactionDefinitionName] [nvarchar](100) NOT NULL,
    [IsMultiple] [bit] NOT NULL,
    [IsDelete] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccTransactionDefinition] PRIMARY KEY ([AccTransactionDefinitionID])
)
CREATE TABLE [dbo].[AccTransactionTemplateDetail] (
    [AccTransactionTemplateDetailID] [bigint] NOT NULL IDENTITY,
    [TransactionTemplateDetailID] [bigint] NOT NULL,
    [AccTransactionTemplateHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [PaymentDate] [datetime],
    [ReferenceDocumentID] [bigint] NOT NULL,
    [ReferenceDocumentDocumentID] [int] NOT NULL,
    [ReferenceLocationID] [int] NOT NULL,
    [ReferenceDocumentNo] [nvarchar](25),
    [SetoffDocumentID] [bigint] NOT NULL,
    [SetoffDocumentDocumentID] [int] NOT NULL,
    [SetoffLocationID] [int] NOT NULL,
    [SetoffDocumentNo] [nvarchar](25),
    [Remark] [nvarchar](150),
    [ScanDocument] [varbinary](max),
    [ReferenceLedgerID] [bigint] NOT NULL,
    [LedgerID] [bigint] NOT NULL,
    [BankID] [bigint] NOT NULL,
    [BankBranchID] [int] NOT NULL,
    [PaymentMethodID] [int] NOT NULL,
    [CardNo] [nvarchar](15),
    [ChequeDate] [datetime],
    [IsOverPaid] [bit] NOT NULL,
    [TransactionType] [int] NOT NULL,
    [DocumentID] [int] NOT NULL,
    [ReferenceCardTypeID] [int] NOT NULL,
    [ReferenceID] [bigint] NOT NULL,
    [AccLedgerAccountID] [bigint] NOT NULL,
    [DrCr] [int] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [CreditAmount] [decimal](18, 2) NOT NULL,
    [DebitAmount] [decimal](18, 2) NOT NULL,
    [DocumentStatus] [int] NOT NULL,
    [IsUpLoad] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccTransactionTemplateDetail] PRIMARY KEY ([AccTransactionTemplateDetailID])
)
CREATE TABLE [dbo].[AccTransactionTemplateHeader] (
    [AccTransactionTemplateHeaderID] [bigint] NOT NULL IDENTITY,
    [TransactionTemplateHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [CostCentreID] [int] NOT NULL,
    [DocumentDate] [datetime] NOT NULL,
    [PaymentDate] [datetime],
    [DocumentID] [int] NOT NULL,
    [DocumentNo] [nvarchar](25),
    [JobClassID] [bigint] NOT NULL,
    [TemplateName] [nvarchar](50),
    [LedgerSerialNo] [nvarchar](25),
    [ManualNo] [nvarchar](25),
    [ReferenceID] [bigint] NOT NULL,
    [ReferenceLedgerID] [bigint] NOT NULL,
    [SalesPersonID] [bigint] NOT NULL,
    [ReferenceCardTypeID] [int] NOT NULL,
    [CollectorName] [nvarchar](50),
    [BalanceAmount] [decimal](18, 2) NOT NULL,
    [AdvanceAmount] [decimal](18, 2) NOT NULL,
    [DocumentType] [int] NOT NULL,
    [TransactionType] [int] NOT NULL,
    [Amount] [decimal](18, 2) NOT NULL,
    [CurrencyID] [int] NOT NULL,
    [CurrencyRate] [decimal](18, 2) NOT NULL,
    [ReferenceNo] [nvarchar](20),
    [Remark] [nvarchar](150),
    [DocumentStatus] [int] NOT NULL,
    [ScanDocument] [varbinary](max),
    [IsUpLoad] [bit] NOT NULL,
    [IsRecurringEntry] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccTransactionTemplateHeader] PRIMARY KEY ([AccTransactionTemplateHeaderID])
)
CREATE TABLE [dbo].[AccTransactionTypeDetail] (
    [AccTransactionTypeDetailID] [bigint] NOT NULL IDENTITY,
    [TransactionTypeDetailID] [bigint] NOT NULL,
    [AccTransactionTypeHeaderID] [bigint] NOT NULL,
    [CompanyID] [int] NOT NULL,
    [LocationID] [int] NOT NULL,
    [AccTransactionDefinitionID] [int] NOT NULL,
    [TransactionModeID] [int] NOT NULL,
    [DrCr] [int] NOT NULL,
    [AccLedgerAccountID] [bigint] NOT NULL,
    [LedgerPercentage] [decimal](18, 2) NOT NULL,
    [IsDefault] [bit] NOT NULL,
    [IsDelete] [bit] NOT NULL,
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.AccTransactionTypeDetail] PRIMARY KEY ([AccTransactionTypeDetailID])
)


CREATE INDEX [IX_AccAccountReconciliationHeaderID] ON [dbo].[AccAccountReconciliationDetail]([AccAccountReconciliationHeaderID])
CREATE INDEX [IX_AccBankdepositheaderID] ON [dbo].[AccBankDepositDetail]([AccBankdepositheaderID])
CREATE INDEX [IX_AccBillEntryHeaderID] ON [dbo].[AccBillEntryDetail]([AccBillEntryHeaderID])
CREATE INDEX [IX_AccChequeCancelHeaderID] ON [dbo].[AccChequeCancelDetail]([AccChequeCancelHeaderID])
CREATE INDEX [IX_AccChequeReturnHeaderID] ON [dbo].[AccChequeReturnDetail]([AccChequeReturnHeaderID])
CREATE INDEX [IX_AccCreditNoteHeaderID] ON [dbo].[AccCreditNoteDetail]([AccCreditNoteHeaderID])
CREATE INDEX [IX_AccDebitNoteHeaderID] ON [dbo].[AccDebitNoteDetail]([AccDebitNoteHeaderID])
CREATE INDEX [IX_AccGlTransactionHeaderID] ON [dbo].[AccGlTransactionDetail]([AccGlTransactionHeaderID])
CREATE INDEX [IX_AccJournalEntryHeaderID] ON [dbo].[AccJournalEntryDetail]([AccJournalEntryHeaderID])
CREATE INDEX [IX_AccOpenningBalanceHeaderID] ON [dbo].[AccOpenningBalanceDetail]([AccOpenningBalanceHeaderID])
CREATE INDEX [IX_AccPettyCashBillHeaderID] ON [dbo].[AccPettyCashBillDetail]([AccPettyCashBillHeaderID])
CREATE INDEX [IX_AccPettyCashIOUHeaderID] ON [dbo].[AccPettyCashIOUDetail]([AccPettyCashIOUHeaderID])
CREATE INDEX [IX_AccPettyCashPaymentHeaderID] ON [dbo].[AccPettyCashPaymentDetail]([AccPettyCashPaymentHeaderID])
CREATE INDEX [IX_AccPettyCashPaymentProcessHeaderID] ON [dbo].[AccPettyCashPaymentProcessDetail]([AccPettyCashPaymentProcessHeaderID])
CREATE INDEX [IX_AccPettyCashVoucherHeaderID] ON [dbo].[AccPettyCashVoucherDetail]([AccPettyCashVoucherHeaderID])
CREATE INDEX [IX_AccTransactionTemplateHeaderID] ON [dbo].[AccTransactionTemplateDetail]([AccTransactionTemplateHeaderID])

ALTER TABLE [dbo].[AccAccountReconciliationDetail] ADD CONSTRAINT [FK_dbo.AccAccountReconciliationDetail_dbo.AccAccountReconciliationHeader_AccAccountReconciliationHeaderID] FOREIGN KEY ([AccAccountReconciliationHeaderID]) REFERENCES [dbo].[AccAccountReconciliationHeader] ([AccAccountReconciliationHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccBankDepositDetail] ADD CONSTRAINT [FK_dbo.AccBankDepositDetail_dbo.AccBankDepositHeader_AccBankdepositheaderID] FOREIGN KEY ([AccBankdepositheaderID]) REFERENCES [dbo].[AccBankDepositHeader] ([AccBankdepositheaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccBillEntryDetail] ADD CONSTRAINT [FK_dbo.AccBillEntryDetail_dbo.AccBillEntryHeader_AccBillEntryHeaderID] FOREIGN KEY ([AccBillEntryHeaderID]) REFERENCES [dbo].[AccBillEntryHeader] ([AccBillEntryHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccChequeCancelDetail] ADD CONSTRAINT [FK_dbo.AccChequeCancelDetail_dbo.AccChequeCancelHeader_AccChequeCancelHeaderID] FOREIGN KEY ([AccChequeCancelHeaderID]) REFERENCES [dbo].[AccChequeCancelHeader] ([AccChequeCancelHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccChequeReturnDetail] ADD CONSTRAINT [FK_dbo.AccChequeReturnDetail_dbo.AccChequeReturnHeader_AccChequeReturnHeaderID] FOREIGN KEY ([AccChequeReturnHeaderID]) REFERENCES [dbo].[AccChequeReturnHeader] ([AccChequeReturnHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccCreditNoteDetail] ADD CONSTRAINT [FK_dbo.AccCreditNoteDetail_dbo.AccCreditNoteHeader_AccCreditNoteHeaderID] FOREIGN KEY ([AccCreditNoteHeaderID]) REFERENCES [dbo].[AccCreditNoteHeader] ([AccCreditNoteHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccDebitNoteDetail] ADD CONSTRAINT [FK_dbo.AccDebitNoteDetail_dbo.AccDebitNoteHeader_AccDebitNoteHeaderID] FOREIGN KEY ([AccDebitNoteHeaderID]) REFERENCES [dbo].[AccDebitNoteHeader] ([AccDebitNoteHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccGlTransactionDetail] ADD CONSTRAINT [FK_dbo.AccGlTransactionDetail_dbo.AccGlTransactionHeader_AccGlTransactionHeaderID] FOREIGN KEY ([AccGlTransactionHeaderID]) REFERENCES [dbo].[AccGlTransactionHeader] ([AccGlTransactionHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccJournalEntryDetail] ADD CONSTRAINT [FK_dbo.AccJournalEntryDetail_dbo.AccJournalEntryHeader_AccJournalEntryHeaderID] FOREIGN KEY ([AccJournalEntryHeaderID]) REFERENCES [dbo].[AccJournalEntryHeader] ([AccJournalEntryHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccOpenningBalanceDetail] ADD CONSTRAINT [FK_dbo.AccOpenningBalanceDetail_dbo.AccOpenningBalanceHeader_AccOpenningBalanceHeaderID] FOREIGN KEY ([AccOpenningBalanceHeaderID]) REFERENCES [dbo].[AccOpenningBalanceHeader] ([AccOpenningBalanceHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccPettyCashBillDetail] ADD CONSTRAINT [FK_dbo.AccPettyCashBillDetail_dbo.AccPettyCashBillHeader_AccPettyCashBillHeaderID] FOREIGN KEY ([AccPettyCashBillHeaderID]) REFERENCES [dbo].[AccPettyCashBillHeader] ([AccPettyCashBillHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccPettyCashIOUDetail] ADD CONSTRAINT [FK_dbo.AccPettyCashIOUDetail_dbo.AccPettyCashIOUHeader_AccPettyCashIOUHeaderID] FOREIGN KEY ([AccPettyCashIOUHeaderID]) REFERENCES [dbo].[AccPettyCashIOUHeader] ([AccPettyCashIOUHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccPettyCashPaymentDetail] ADD CONSTRAINT [FK_dbo.AccPettyCashPaymentDetail_dbo.AccPettyCashPaymentHeader_AccPettyCashPaymentHeaderID] FOREIGN KEY ([AccPettyCashPaymentHeaderID]) REFERENCES [dbo].[AccPettyCashPaymentHeader] ([AccPettyCashPaymentHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccPettyCashPaymentProcessDetail] ADD CONSTRAINT [FK_dbo.AccPettyCashPaymentProcessDetail_dbo.AccPettyCashPaymentProcessHeader_AccPettyCashPaymentProcessHeaderID] FOREIGN KEY ([AccPettyCashPaymentProcessHeaderID]) REFERENCES [dbo].[AccPettyCashPaymentProcessHeader] ([AccPettyCashPaymentProcessHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccPettyCashVoucherDetail] ADD CONSTRAINT [FK_dbo.AccPettyCashVoucherDetail_dbo.AccPettyCashVoucherHeader_AccPettyCashVoucherHeaderID] FOREIGN KEY ([AccPettyCashVoucherHeaderID]) REFERENCES [dbo].[AccPettyCashVoucherHeader] ([AccPettyCashVoucherHeaderID]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccTransactionTemplateDetail] ADD CONSTRAINT [FK_dbo.AccTransactionTemplateDetail_dbo.AccTransactionTemplateHeader_AccTransactionTemplateHeaderID] FOREIGN KEY ([AccTransactionTemplateHeaderID]) REFERENCES [dbo].[AccTransactionTemplateHeader] ([AccTransactionTemplateHeaderID]) ON DELETE CASCADE



SET IDENTITY_INSERT [dbo].[AccTransactionTypeDetail] ON
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (1, 0, 27, 0, 2, 0, 1, N'ADMIN', CAST(0x0000A43A011405D5 AS DateTime), N'ADMIN', CAST(0x0000A43A011405D5 AS DateTime), 0, 89, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (2, 0, 27, 0, 2, 0, 1, N'ADMIN', CAST(0x0000A43A01141F8B AS DateTime), N'ADMIN', CAST(0x0000A43A01141F8B AS DateTime), 0, 91, CAST(100.00 AS Decimal(18, 2)), 1, 1, 2, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (3, 0, 48, 0, 2, 0, 1, N'ADMIN', CAST(0x0000A43A01143D5E AS DateTime), N'ADMIN', CAST(0x0000A43A01143D5E AS DateTime), 0, 90, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (4, 0, 28, 0, 2, 0, 1, N'ADMIN', CAST(0x0000A43A01145A48 AS DateTime), N'ADMIN', CAST(0x0000A43A01145A48 AS DateTime), 0, 38, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (5, 0, 37, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0115F8B7 AS DateTime), N'admin', CAST(0x0000A43A0115F8B7 AS DateTime), 0, 35, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (6, 0, 37, 0, 2, 0, 1, N'admin', CAST(0x0000A43A0115F8C9 AS DateTime), N'admin', CAST(0x0000A43A0115F8C9 AS DateTime), 0, 35, CAST(100.00 AS Decimal(18, 2)), 1, 1, 2, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (7, 0, 38, 0, 2, 0, 1, N'admin', CAST(0x0000A43A01167088 AS DateTime), N'admin', CAST(0x0000A43A01167088 AS DateTime), 0, 35, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (8, 0, 38, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0116708E AS DateTime), N'admin', CAST(0x0000A43A0116708E AS DateTime), 0, 35, CAST(100.00 AS Decimal(18, 2)), 1, 1, 2, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (9, 0, 40, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0116CF2B AS DateTime), N'admin', CAST(0x0000A43A0116CF2B AS DateTime), 0, 35, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (10, 0, 40, 0, 2, 0, 1, N'admin', CAST(0x0000A43A0116CF36 AS DateTime), N'admin', CAST(0x0000A43A0116CF36 AS DateTime), 0, 291, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (11, 0, 77, 0, 1, 0, 1, N'admin', CAST(0x0000A43A011729B6 AS DateTime), N'admin', CAST(0x0000A43A011729B6 AS DateTime), 0, 235, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (12, 0, 77, 0, 1, 0, 1, N'admin', CAST(0x0000A43A011729BC AS DateTime), N'admin', CAST(0x0000A43A011729BC AS DateTime), 0, 235, CAST(100.00 AS Decimal(18, 2)), 1, 1, 3, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (13, 0, 77, 0, 2, 0, 1, N'admin', CAST(0x0000A43A01176894 AS DateTime), N'admin', CAST(0x0000A43A01176894 AS DateTime), 0, 235, CAST(100.00 AS Decimal(18, 2)), 1, 1, 2, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (14, 0, 56, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0117CAAB AS DateTime), N'admin', CAST(0x0000A43A0117CAAB AS DateTime), 0, 36, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (15, 0, 56, 0, 2, 0, 1, N'admin', CAST(0x0000A43A0117CAB3 AS DateTime), N'admin', CAST(0x0000A43A0117CAB3 AS DateTime), 0, 36, CAST(100.00 AS Decimal(18, 2)), 1, 1, 2, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (16, 0, 57, 0, 2, 0, 1, N'admin', CAST(0x0000A43A01183733 AS DateTime), N'admin', CAST(0x0000A43A01183733 AS DateTime), 0, 36, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (17, 0, 57, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0118373B AS DateTime), N'admin', CAST(0x0000A43A0118373B AS DateTime), 0, 36, CAST(100.00 AS Decimal(18, 2)), 1, 1, 2, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (18, 0, 59, 0, 1, 0, 1, N'admin', CAST(0x0000A43A011883A5 AS DateTime), N'admin', CAST(0x0000A43A011883A5 AS DateTime), 0, 36, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (19, 0, 59, 0, 2, 0, 1, N'admin', CAST(0x0000A43A011883AB AS DateTime), N'admin', CAST(0x0000A43A011883AB AS DateTime), 0, 292, CAST(100.00 AS Decimal(18, 2)), 1, 1, 1, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (20, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A01190E5F AS DateTime), N'admin', CAST(0x0000A43A01190E5F AS DateTime), 0, 49, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (21, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A01190E67 AS DateTime), N'admin', CAST(0x0000A43A01190E67 AS DateTime), 0, 50, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (22, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0119237D AS DateTime), N'admin', CAST(0x0000A43A0119237D AS DateTime), 0, 51, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (23, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A01193C21 AS DateTime), N'admin', CAST(0x0000A43A01193C21 AS DateTime), 0, 52, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (24, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A011954F8 AS DateTime), N'admin', CAST(0x0000A43A011954F8 AS DateTime), 0, 53, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (25, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A01197415 AS DateTime), N'admin', CAST(0x0000A43A01197415 AS DateTime), 0, 54, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (26, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A011995EC AS DateTime), N'admin', CAST(0x0000A43A011995EC AS DateTime), 0, 55, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 0)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (27, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0119B49F AS DateTime), N'admin', CAST(0x0000A43A0119B49F AS DateTime), 0, 56, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (28, 0, 186, 0, 1, 0, 1, N'admin', CAST(0x0000A43A0119FA72 AS DateTime), N'admin', CAST(0x0000A43A0119FA72 AS DateTime), 0, 56, CAST(100.00 AS Decimal(18, 2)), 1, 1, 5, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (29, 0, 187, 0, 2, 0, 1, N'admin', CAST(0x0000A43A011AAF7D AS DateTime), N'admin', CAST(0x0000A43A011AAF7D AS DateTime), 0, 108, CAST(100.00 AS Decimal(18, 2)), 1, 1, 4, 1)
INSERT [dbo].[AccTransactionTypeDetail] ([AccTransactionTypeDetailID], [TransactionTypeDetailID], [AccTransactionTypeHeaderID], [TransactionModeID], [DrCr], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [AccLedgerAccountID], [LedgerPercentage], [CompanyID], [LocationID], [AccTransactionDefinitionID], [IsDefault]) VALUES (30, 0, 187, 0, 2, 0, 1, N'admin', CAST(0x0000A43A011AAF84 AS DateTime), N'admin', CAST(0x0000A43A011AAF84 AS DateTime), 0, 108, CAST(100.00 AS Decimal(18, 2)), 1, 1, 5, 1)
SET IDENTITY_INSERT [dbo].[AccTransactionTypeDetail] OFF


SET IDENTITY_INSERT [dbo].[AccTransactionDefinition] ON
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (1, 1, N'Transaction', 1, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (2, 2, N'Discount', 0, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (3, 3, N'Expense', 1, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (4, 4, N'Advance', 1, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (5, 5, N'OverPayment', 1, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (6, 6, N'Consignment', 0, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
INSERT [dbo].[AccTransactionDefinition] ([AccTransactionDefinitionID], [TransactionDefinitionCode], [TransactionDefinitionName], [IsMultiple], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (7, 7, N'RoundOff', 0, 0, 1, N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), N'ADMIN', CAST(0x0000A3B000000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[AccTransactionDefinition] OFF

SET IDENTITY_INSERT [dbo].[AccLedgerAccount] ON
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (1, N'1', 0, N'1', N'ASSETS', N'ASSETS', 1, 1, 0, 0, 1, N'ADMIN', CAST(0x0000A3B001088BAE AS DateTime), N'ADMIN', CAST(0x0000A3B001088BAE AS DateTime), 0, 1, 1, 1, 0, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (2, N'2', 0, N'2', N'LIABILITIES', N'LIABILITIES', 2, 2, 0, 0, 1, N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), 0, 1, 1, 1, 0, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (3, N'3', 0, N'3', N'EQUITY', N'EQUITY', 3, 2, 0, 0, 1, N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), 0, 1, 1, 1, 0, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (4, N'4', 0, N'4', N'INCOME', N'INCOME', 4, 2, 0, 0, 1, N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), 0, 2, 1, 1, 0, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (5, N'5', 0, N'5', N'EXPENSES', N'EXPENSES', 5, 1, 0, 0, 1, N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), N'ADMIN', CAST(0x0000A3B001088BAF AS DateTime), 0, 2, 1, 1, 0, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (6, N'1', 1, N'101', N'NON-CURRENT ASSET', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B1E291 AS DateTime), N'admin', CAST(0x0000A43600B1E291 AS DateTime), 0, 1, 1, 1, 1, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (7, N'1', 2, N'101001', N'FURNITURE & FITTINGS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B20DE6 AS DateTime), N'admin', CAST(0x0000A43600B20DE6 AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (8, N'1', 3, N'1010010001', N'FURNITURE & FITTINGS - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B22734 AS DateTime), N'admin', CAST(0x0000A43600B22734 AS DateTime), 0, 1, 0, 1, 7, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (9, N'1', 3, N'1010010002', N'FURNITURE & FITTINGS - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B265D6 AS DateTime), N'admin', CAST(0x0000A43600B265D6 AS DateTime), 0, 1, 0, 1, 7, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (10, N'1', 2, N'101002', N'RENOVATION', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B285AB AS DateTime), N'admin', CAST(0x0000A43600B285AB AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (11, N'1', 3, N'1010020001', N'RENOVATION - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B35B72 AS DateTime), N'admin', CAST(0x0000A43600B35B72 AS DateTime), 0, 1, 0, 1, 10, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (12, N'1', 3, N'1010020002', N'RENOVATION - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B38787 AS DateTime), N'admin', CAST(0x0000A43600B38787 AS DateTime), 0, 1, 0, 1, 10, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (13, N'1', 2, N'101003', N'EQUIPMENT', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B3C58D AS DateTime), N'admin', CAST(0x0000A43600B3C58D AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (14, N'1', 3, N'1010030001', N'EQUIPMENT - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B3EB27 AS DateTime), N'admin', CAST(0x0000A43600B3EB27 AS DateTime), 0, 1, 0, 1, 13, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (15, N'1', 3, N'1010030002', N'EQUIPMENT - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B3FDB7 AS DateTime), N'admin', CAST(0x0000A43600B3FDB7 AS DateTime), 0, 1, 0, 1, 13, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (16, N'1', 2, N'101004', N'COMPUTER', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B41265 AS DateTime), N'admin', CAST(0x0000A43600B41265 AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (17, N'1', 3, N'1010040001', N'COMPUTER - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B42739 AS DateTime), N'admin', CAST(0x0000A43600B42739 AS DateTime), 0, 1, 0, 1, 16, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (18, N'1', 3, N'1010040002', N'COMPUTER - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B445FA AS DateTime), N'admin', CAST(0x0000A43600B445FA AS DateTime), 0, 1, 0, 1, 16, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (19, N'1', 2, N'101005', N'POS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B46A5A AS DateTime), N'admin', CAST(0x0000A43600B46A5A AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (20, N'1', 3, N'1010050001', N'POS - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B47EC1 AS DateTime), N'admin', CAST(0x0000A43600B47EC1 AS DateTime), 0, 1, 0, 1, 19, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (21, N'1', 3, N'1010050002', N'POS - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B491E7 AS DateTime), N'admin', CAST(0x0000A43600B491E7 AS DateTime), 0, 1, 0, 1, 19, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (22, N'1', 2, N'101006', N'SOFTWARE', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B4AA7F AS DateTime), N'admin', CAST(0x0000A43600B4AA7F AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (23, N'1', 3, N'1010060001', N'SOFTWARE - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B4C05B AS DateTime), N'admin', CAST(0x0000A43600B4C05B AS DateTime), 0, 1, 0, 1, 22, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (24, N'1', 3, N'1010060002', N'SOFTWARE - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B4CFCC AS DateTime), N'admin', CAST(0x0000A43600B4CFCC AS DateTime), 0, 1, 0, 1, 22, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (28, N'1', 2, N'101008', N'SECURITY SYSTEM', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B5303E AS DateTime), N'admin', CAST(0x0000A43600B5303E AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (29, N'1', 3, N'1010080001', N'SECURITY SYSTEM - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B54B03 AS DateTime), N'admin', CAST(0x0000A43600B54B03 AS DateTime), 0, 1, 0, 1, 28, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (30, N'1', 3, N'1010080002', N'SECURITY SYSTEM - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B55E6C AS DateTime), N'admin', CAST(0x0000A43600B55E6C AS DateTime), 0, 1, 0, 1, 28, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (31, N'1', 2, N'101009', N'HOARDINGS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B57E97 AS DateTime), N'admin', CAST(0x0000A43600B57E97 AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (32, N'1', 3, N'1010090001', N'HOARDINGS - COST', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B59CC4 AS DateTime), N'admin', CAST(0x0000A43600B59CC4 AS DateTime), 0, 1, 0, 1, 31, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (33, N'1', 3, N'1010090002', N'HOARDINGS - ACC DEP', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B5B0FE AS DateTime), N'admin', CAST(0x0000A43600B5B0FE AS DateTime), 0, 1, 0, 1, 31, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (34, N'1', 1, N'102', N'CURRENT ASSETS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B5E7F9 AS DateTime), N'admin', CAST(0x0000A43600B5E7F9 AS DateTime), 0, 1, 1, 1, 1, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (35, N'1', 2, N'102001', N'TRADE STOCKS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B60295 AS DateTime), N'admin', CAST(0x0000A43600B60295 AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (36, N'1', 2, N'102002', N'NON TRADE STOCKS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B617F3 AS DateTime), N'admin', CAST(0x0000A43600B617F3 AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (37, N'1', 2, N'102003', N'REFUNDABLE DEPOSITS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B66B17 AS DateTime), N'admin', CAST(0x0000A43600B66B17 AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (38, N'1', 2, N'102004', N'TRADE DEBTORS', N'', 7, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B684B1 AS DateTime), N'admin', CAST(0x0000A43600B684B1 AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (39, N'1', 2, N'102005', N'CARD RECEIVABLES', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B69BC6 AS DateTime), N'admin', CAST(0x0000A43600B69BC6 AS DateTime), 0, 1, 1, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (40, N'1', 3, N'1020050001', N'SAMPATH - CC RECEIVABLE', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B6B86C AS DateTime), N'admin', CAST(0x0000A43600B6B86C AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (41, N'1', 3, N'1020050002', N'HNB - CC RECEIVABLE', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B6CB3B AS DateTime), N'admin', CAST(0x0000A43600B6CB3B AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (42, N'1', 3, N'1020050003', N'NTB - CC RECEIVABLE', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B6DAE5 AS DateTime), N'admin', CAST(0x0000A43600B6DAE5 AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (43, N'1', 3, N'1020050004', N'HSBC - CC RECEIVABLE', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B6EF17 AS DateTime), N'admin', CAST(0x0000A43600B6EF17 AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (44, N'1', 3, N'1020050005', N'DIALOG RECEIVABLE', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B703A4 AS DateTime), N'admin', CAST(0x0000A43600B703A4 AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (45, N'1', 3, N'1020050006', N'MOBITEL RECEIVABLE', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B71A4B AS DateTime), N'admin', CAST(0x0000A43600B71A4B AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (46, N'1', 3, N'1020050007', N'I  BUY RECEIVABLES', N'', 11, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B7316C AS DateTime), N'admin', CAST(0x0000A43600B7316C AS DateTime), 0, 1, 0, 1, 39, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (47, N'1', 2, N'102006', N'OTHER DEBTORS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B7D778 AS DateTime), N'admin', CAST(0x0000A43600B7D778 AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (48, N'1', 2, N'102007', N'PURCHASE ADVANCES', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B7F133 AS DateTime), N'admin', CAST(0x0000A43600B7F133 AS DateTime), 0, 1, 1, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (49, N'1', 3, N'1020070001', N'ADVANCE - FASHION LANKA', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B809AE AS DateTime), N'admin', CAST(0x0000A43600B809AE AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (50, N'1', 3, N'1020070002', N'ADVANCE - RAGUL', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B81EED AS DateTime), N'admin', CAST(0x0000A43600B81EED AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (51, N'1', 3, N'1020070003', N'ADVANCE - LIFE STYLE', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B84121 AS DateTime), N'admin', CAST(0x0000A43600B84121 AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (52, N'1', 3, N'1020070004', N'ADVANCE - SUGUNA', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B85E79 AS DateTime), N'admin', CAST(0x0000A43600B85E79 AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (53, N'1', 3, N'1020070005', N'ADVANCE - TITAN', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B87BFF AS DateTime), N'admin', CAST(0x0000A43600B87BFF AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (54, N'1', 3, N'1020070006', N'ADVANCE - MARK APPARELS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B899CC AS DateTime), N'admin', CAST(0x0000A43600B899CC AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (55, N'1', 3, N'1020070007', N'ADVANCE - LEAD', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B8C9AB AS DateTime), N'admin', CAST(0x0000A43600B8C9AB AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (56, N'1', 3, N'1020070008', N'ADVANCE - OTHER', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B8E7C8 AS DateTime), N'admin', CAST(0x0000A43600B8E7C8 AS DateTime), 0, 1, 0, 1, 48, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (57, N'1', 2, N'102008', N'STAFF RECEIVABLE', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B92F6E AS DateTime), N'admin', CAST(0x0000A43600B92F6E AS DateTime), 0, 1, 1, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (58, N'1', 3, N'1020080001', N'STAFF LOAN', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B95333 AS DateTime), N'admin', CAST(0x0000A43600B95333 AS DateTime), 0, 1, 0, 1, 57, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (59, N'1', 3, N'1020080002', N'STAFF CREDIT RECEIVABLE', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B96A7E AS DateTime), N'admin', CAST(0x0000A43600B96A7E AS DateTime), 0, 1, 0, 1, 57, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (60, N'1', 3, N'1020080003', N'SALARY ADVANCE - SYSTEM', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B98535 AS DateTime), N'admin', CAST(0x0000A43600B98535 AS DateTime), 0, 1, 0, 1, 57, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (61, N'1', 3, N'1020080004', N'SALARY ADVANCE - MANUAL', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B9A1C7 AS DateTime), N'admin', CAST(0x0000A43600B9A1C7 AS DateTime), 0, 1, 0, 1, 57, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (62, N'1', 3, N'1020080005', N'PAYMENT CONTROL A/C', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600B9DD69 AS DateTime), N'admin', CAST(0x0000A43600B9DD69 AS DateTime), 0, 1, 0, 1, 57, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (69, N'1', 2, N'102010', N'PRE - PAYMENTS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BB06FB AS DateTime), N'admin', CAST(0x0000A43600BB06FB AS DateTime), 0, 1, 1, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (70, N'1', 3, N'1020100001', N'PRE-PAID BONUS', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BB3736 AS DateTime), N'admin', CAST(0x0000A43600BB3736 AS DateTime), 0, 1, 0, 1, 69, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (71, N'1', 3, N'1020100002', N'PRE-PAID RENT', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BB509A AS DateTime), N'admin', CAST(0x0000A43600BB509A AS DateTime), 0, 1, 0, 1, 69, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (72, N'1', 3, N'1020100003', N'PRE-PAID - OTHER EXPENSES', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BB7D8D AS DateTime), N'admin', CAST(0x0000A43600BB7D8D AS DateTime), 0, 1, 0, 1, 69, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (73, N'1', 2, N'102011', N'BANK MASTER', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BBB902 AS DateTime), N'admin', CAST(0x0000A43600BBB902 AS DateTime), 0, 1, 1, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (74, N'1', 3, N'1020110001', N'AMANA - CURRENT A/C', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BC0F5C AS DateTime), N'admin', CAST(0x0000A43600BC0F5C AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (75, N'1', 3, N'1020110002', N'AMANA - SAVING A/C', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BC3ADC AS DateTime), N'admin', CAST(0x0000A43600BC3ADC AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (76, N'1', 3, N'1020110003', N'COMMERCIAL - NOLIMIT', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BC544A AS DateTime), N'admin', CAST(0x0000A43600BC544A AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (77, N'1', 3, N'1020110004', N'PABC', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BC6A9E AS DateTime), N'admin', CAST(0x0000A43600BC6A9E AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (78, N'1', 3, N'1020110005', N'SAMPATH', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BC8A8A AS DateTime), N'admin', CAST(0x0000A43600BC8A8A AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (79, N'1', 3, N'1020110006', N'HNB', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BCA9D4 AS DateTime), N'admin', CAST(0x0000A43600BCA9D4 AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (80, N'1', 3, N'1020110007', N'NTB', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BCC646 AS DateTime), N'admin', CAST(0x0000A43600BCC646 AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (81, N'1', 3, N'1020110008', N'SCB', N'', 8, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BCD9EF AS DateTime), N'admin', CAST(0x0000A43600BCD9EF AS DateTime), 0, 1, 0, 1, 73, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (87, N'1', 2, N'102012', N'GV IN HAND', N'', 1, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BD865B AS DateTime), N'admin', CAST(0x0000A43600BD865B AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (88, N'1', 2, N'102013', N'CASH IN HAND', N'', 9, 1, 0, 0, 1, N'admin', CAST(0x0000A43600BDB0C6 AS DateTime), N'admin', CAST(0x0000A43600BDB0C6 AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (89, N'2', 1, N'201', N'TRADE CREDITORS', N'', 10, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C00203 AS DateTime), N'admin', CAST(0x0000A43600C00203 AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (90, N'2', 1, N'202', N'NON TRADE CREDITORS', N'', 10, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C01C0B AS DateTime), N'admin', CAST(0x0000A43600C01C0B AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (91, N'2', 1, N'203', N'SUNDRY CREDITORS', N'', 10, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C032DC AS DateTime), N'admin', CAST(0x0000A43600C032DC AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (92, N'2', 1, N'204', N'ARAPAIMA POINTS PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C044BD AS DateTime), N'admin', CAST(0x0000A43600C044BD AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (93, N'2', 1, N'205', N'STATUTORY PAYABLES', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C0828A AS DateTime), N'admin', CAST(0x0000A43600C0828A AS DateTime), 0, 1, 1, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (94, N'2', 2, N'205001', N'VAT', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C0A638 AS DateTime), N'admin', CAST(0x0000A43600C0A638 AS DateTime), 0, 1, 1, 1, 93, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (95, N'2', 3, N'2050010001', N'VAT COLLECTED (PAYABLE)', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C0D2A4 AS DateTime), N'admin', CAST(0x0000A43600C0D2A4 AS DateTime), 0, 1, 0, 1, 94, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (96, N'2', 3, N'2050010002', N'VAT PAID (RECOVERABLE)', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C0E556 AS DateTime), N'admin', CAST(0x0000A43600C0E556 AS DateTime), 0, 1, 0, 1, 94, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (97, N'2', 3, N'2050010003', N'VAT - PAYMENT - IRD', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C10F01 AS DateTime), N'admin', CAST(0x0000A43600C10F01 AS DateTime), 0, 1, 0, 1, 94, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (98, N'2', 2, N'205002', N'NBT PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C12EA3 AS DateTime), N'admin', CAST(0x0000A43600C12EA3 AS DateTime), 0, 1, 0, 1, 93, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (99, N'2', 2, N'205003', N'WHT PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C15F21 AS DateTime), N'admin', CAST(0x0000A43600C15F21 AS DateTime), 0, 1, 0, 1, 93, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (100, N'2', 2, N'205004', N'ESC PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C1798A AS DateTime), N'admin', CAST(0x0000A43600C1798A AS DateTime), 0, 1, 0, 1, 93, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (101, N'2', 1, N'206', N'STAFF PAYABLES', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C1CCC4 AS DateTime), N'admin', CAST(0x0000A43600C1CCC4 AS DateTime), 0, 1, 1, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (102, N'2', 2, N'206001', N'SALARY CONTROL', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C1E7E8 AS DateTime), N'admin', CAST(0x0000A43600C1E7E8 AS DateTime), 0, 1, 0, 1, 101, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (103, N'2', 2, N'206002', N'EPF PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C1F856 AS DateTime), N'admin', CAST(0x0000A43600C1F856 AS DateTime), 0, 1, 0, 1, 101, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (104, N'2', 2, N'206003', N'ETF PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C2087A AS DateTime), N'admin', CAST(0x0000A43600C2087A AS DateTime), 0, 1, 0, 1, 101, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (105, N'2', 2, N'206004', N'PAYE PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C2197A AS DateTime), N'admin', CAST(0x0000A43600C2197A AS DateTime), 0, 1, 0, 1, 101, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (106, N'2', 2, N'206005', N'UNCLAIMED SALARIES', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C2345E AS DateTime), N'admin', CAST(0x0000A43600C2345E AS DateTime), 0, 1, 0, 1, 101, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (107, N'2', 2, N'206006', N'BONUS PAYABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C24E61 AS DateTime), N'admin', CAST(0x0000A43600C24E61 AS DateTime), 0, 1, 0, 1, 101, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (108, N'2', 1, N'207', N'CUSTOMER DEPOSITS', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C26CE7 AS DateTime), N'admin', CAST(0x0000A43600C26CE7 AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (109, N'2', 1, N'208', N'CANCELLED CHEQUE ACCOUNT', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C29827 AS DateTime), N'admin', CAST(0x0000A43600C29827 AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (110, N'2', 1, N'209', N'GV REDEEMABLE', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C2B3EB AS DateTime), N'admin', CAST(0x0000A43600C2B3EB AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (111, N'3', 1, N'301', N'CURRENT ACCOUNT', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C30EE2 AS DateTime), N'admin', CAST(0x0000A43600C30EE2 AS DateTime), 0, 1, 1, 1, 3, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (112, N'3', 2, N'301001', N'N.L.M - CURRENT', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C325C7 AS DateTime), N'admin', CAST(0x0000A43600C325C7 AS DateTime), 0, 1, 0, 1, 111, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (113, N'3', 2, N'301002', N'M.M - CURRENT', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C40556 AS DateTime), N'admin', CAST(0x0000A43600C40556 AS DateTime), 0, 1, 0, 1, 111, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (114, N'3', 2, N'301003', N'HAFIZ - CURRENT', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C42939 AS DateTime), N'admin', CAST(0x0000A43600C42939 AS DateTime), 0, 1, 0, 1, 111, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (115, N'3', 2, N'301004', N'DEEDAT - CURRENT', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C44F63 AS DateTime), N'admin', CAST(0x0000A43600C44F63 AS DateTime), 0, 1, 0, 1, 111, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (116, N'3', 1, N'302', N'DRAWING', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C4692B AS DateTime), N'admin', CAST(0x0000A43600C4692B AS DateTime), 0, 1, 1, 1, 3, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (117, N'3', 2, N'302001', N'N.L.M - DRAWINGS', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C4877C AS DateTime), N'admin', CAST(0x0000A43600C4877C AS DateTime), 0, 1, 0, 1, 116, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (118, N'3', 2, N'302002', N'M.M - DRAWINGS', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C49936 AS DateTime), N'admin', CAST(0x0000A43600C49936 AS DateTime), 0, 1, 0, 1, 116, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (119, N'3', 2, N'302003', N'HAFIZ - DRAWINGS', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C4B134 AS DateTime), N'admin', CAST(0x0000A43600C4B134 AS DateTime), 0, 1, 0, 1, 116, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (120, N'3', 2, N'302004', N'DEEDAT - DRAWINGS', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C4BFD6 AS DateTime), N'admin', CAST(0x0000A43600C4BFD6 AS DateTime), 0, 1, 0, 1, 116, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (121, N'3', 1, N'303', N'INCOME TAX', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C4D472 AS DateTime), N'admin', CAST(0x0000A43600C4D472 AS DateTime), 0, 1, 1, 1, 3, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (122, N'3', 2, N'303001', N'INCOME TAX N.L.M', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C4FA52 AS DateTime), N'admin', CAST(0x0000A43600C4FA52 AS DateTime), 0, 1, 0, 1, 121, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (123, N'3', 2, N'303002', N'INCOME TAX M.M', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C51390 AS DateTime), N'admin', CAST(0x0000A43600C51390 AS DateTime), 0, 1, 0, 1, 121, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (124, N'3', 2, N'303003', N'INCOME TAX HAFIZ', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C52AD2 AS DateTime), N'admin', CAST(0x0000A43600C52AD2 AS DateTime), 0, 1, 0, 1, 121, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (125, N'3', 2, N'303004', N'INCOME TAX DEEDAT', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C53D0A AS DateTime), N'admin', CAST(0x0000A43600C53D0A AS DateTime), 0, 1, 0, 1, 121, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (126, N'3', 1, N'304', N'RENT INCOME', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C55128 AS DateTime), N'admin', CAST(0x0000A43600C55128 AS DateTime), 0, 1, 0, 1, 3, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (127, N'3', 1, N'305', N'PROPERTY EXPENSE', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C573B9 AS DateTime), N'admin', CAST(0x0000A43600C573B9 AS DateTime), 0, 1, 0, 1, 3, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (128, N'3', 1, N'306', N'RETAINED EARNINGS', N'', 3, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C58C72 AS DateTime), N'admin', CAST(0x0000A43600C58C72 AS DateTime), 0, 1, 0, 1, 3, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (129, N'4', 1, N'401', N'SALES - TRADING', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C705DC AS DateTime), N'admin', CAST(0x0000A43600C705DC AS DateTime), 0, 2, 1, 1, 4, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (130, N'4', 2, N'401001', N'SALES - DL', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C7255D AS DateTime), N'admin', CAST(0x0000A43600C7255D AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (131, N'4', 2, N'401002', N'SALES - DG', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C73575 AS DateTime), N'admin', CAST(0x0000A43600C73575 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (132, N'4', 2, N'401003', N'SALES - ML', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C74B81 AS DateTime), N'admin', CAST(0x0000A43600C74B81 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (133, N'4', 2, N'401004', N'SALES - MG', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C75D3F AS DateTime), N'admin', CAST(0x0000A43600C75D3F AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (134, N'4', 2, N'401005', N'SALES - BR', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C76E92 AS DateTime), N'admin', CAST(0x0000A43600C76E92 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (135, N'4', 2, N'401006', N'SALES - HP', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C77C7B AS DateTime), N'admin', CAST(0x0000A43600C77C7B AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (136, N'4', 2, N'401007', N'SALES - NG', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C78A5C AS DateTime), N'admin', CAST(0x0000A43600C78A5C AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (137, N'4', 2, N'401008', N'SALES - 7MP', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C79657 AS DateTime), N'admin', CAST(0x0000A43600C79657 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (138, N'4', 2, N'401009', N'SALES - WW', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C7B92B AS DateTime), N'admin', CAST(0x0000A43600C7B92B AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (139, N'4', 2, N'401010', N'SALES - NBG', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C7D240 AS DateTime), N'admin', CAST(0x0000A43600C7D240 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (140, N'4', 2, N'401011', N'SALES - NBL', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C7FB12 AS DateTime), N'admin', CAST(0x0000A43600C7FB12 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (141, N'4', 2, N'401012', N'SALES - RM', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C8184D AS DateTime), N'admin', CAST(0x0000A43600C8184D AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (142, N'4', 2, N'401013', N'SALES - YPM', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C82FD0 AS DateTime), N'admin', CAST(0x0000A43600C82FD0 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (143, N'4', 2, N'401014', N'SALES - KDY', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C840D9 AS DateTime), N'admin', CAST(0x0000A43600C840D9 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (144, N'4', 2, N'401015', N'SALES - PALLU', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C85040 AS DateTime), N'admin', CAST(0x0000A43600C85040 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (145, N'4', 2, N'401016', N'SALES - KG', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C864DB AS DateTime), N'admin', CAST(0x0000A43600C864DB AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (146, N'4', 2, N'401017', N'SALES - RP', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C87A7F AS DateTime), N'admin', CAST(0x0000A43600C87A7F AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (147, N'4', 2, N'401018', N'SALES - WWP', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C895C3 AS DateTime), N'admin', CAST(0x0000A43600C895C3 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (148, N'4', 2, N'401019', N'SALES - WWG', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C8B196 AS DateTime), N'admin', CAST(0x0000A43600C8B196 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (149, N'4', 2, N'401020', N'SALES - KL', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C8BF40 AS DateTime), N'admin', CAST(0x0000A43600C8BF40 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (150, N'4', 2, N'401021', N'SALES - KCC', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C8D3F1 AS DateTime), N'admin', CAST(0x0000A43600C8D3F1 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (151, N'4', 2, N'401022', N'SALES - PD', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C8E422 AS DateTime), N'admin', CAST(0x0000A43600C8E422 AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (152, N'4', 2, N'401023', N'SALES - EXHIBITION', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C8F7EB AS DateTime), N'admin', CAST(0x0000A43600C8F7EB AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (153, N'4', 2, N'401024', N'SALES - KKM', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C926EA AS DateTime), N'admin', CAST(0x0000A43600C926EA AS DateTime), 0, 2, 0, 1, 129, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (154, N'4', 1, N'402', N'N.B.T', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C98AFA AS DateTime), N'admin', CAST(0x0000A43600C98AFA AS DateTime), 0, 2, 0, 1, 4, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (155, N'4', 1, N'403', N'OTHER INCOME', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C9B866 AS DateTime), N'admin', CAST(0x0000A43600C9B866 AS DateTime), 0, 2, 1, 1, 4, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (156, N'4', 2, N'403001', N'SALES - MATERIAL', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600C9FA72 AS DateTime), N'admin', CAST(0x0000A43600C9FA72 AS DateTime), 0, 2, 0, 1, 155, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (157, N'4', 2, N'403002', N'ARAPAIMA SUBSCRIPTIONS', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600CA1D34 AS DateTime), N'admin', CAST(0x0000A43600CA1D34 AS DateTime), 0, 2, 0, 1, 155, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (158, N'4', 2, N'403003', N'INVESTMENT INCOME', N'', 4, 2, 0, 0, 1, N'admin', CAST(0x0000A43600CA2E55 AS DateTime), N'admin', CAST(0x0000A43600CA2E55 AS DateTime), 0, 2, 0, 1, 155, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (162, N'5', 1, N'501', N'COST OF SALES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CA72AE AS DateTime), N'admin', CAST(0x0000A43600CA72AE AS DateTime), 0, 2, 1, 1, 5, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (163, N'5', 2, N'501001', N'COST OF GOODS SOLD', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CA8E48 AS DateTime), N'admin', CAST(0x0000A43600CA8E48 AS DateTime), 0, 2, 1, 1, 162, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (164, N'5', 3, N'5010010001', N'COST OF GOODS SOLD - DL', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CA9F33 AS DateTime), N'admin', CAST(0x0000A43600CA9F33 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (165, N'5', 3, N'5010010002', N'COST OF GOODS SOLD - DG', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CABF0B AS DateTime), N'admin', CAST(0x0000A43600CABF0B AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (166, N'5', 3, N'5010010003', N'COST OF GOODS SOLD - ML', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CAD19A AS DateTime), N'admin', CAST(0x0000A43600CAD19A AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (167, N'5', 3, N'5010010004', N'COST OF GOODS SOLD - MG', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CAE149 AS DateTime), N'admin', CAST(0x0000A43600CAE149 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (168, N'5', 3, N'5010010005', N'COST OF GOODS SOLD - BR', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CAF537 AS DateTime), N'admin', CAST(0x0000A43600CAF537 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (169, N'5', 3, N'5010010006', N'COST OF GOODS SOLD - HP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB0798 AS DateTime), N'admin', CAST(0x0000A43600CB0798 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (170, N'5', 3, N'5010010007', N'COST OF GOODS SOLD - NG', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB202E AS DateTime), N'admin', CAST(0x0000A43600CB202E AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (171, N'5', 3, N'5010010008', N'COST OF GOODS SOLD - 7MP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB42C9 AS DateTime), N'admin', CAST(0x0000A43600CB42C9 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (172, N'5', 3, N'5010010009', N'COST OF GOODS SOLD - WW', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB5652 AS DateTime), N'admin', CAST(0x0000A43600CB5652 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (173, N'5', 3, N'5010010010', N'COST OF GOODS SOLD - NBG', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB6765 AS DateTime), N'admin', CAST(0x0000A43600CB6765 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (174, N'5', 3, N'5010010011', N'COST OF GOODS SOLD - NBL', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB7FA4 AS DateTime), N'admin', CAST(0x0000A43600CB7FA4 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (175, N'5', 3, N'5010010012', N'COST OF GOODS SOLD - RM', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CB9664 AS DateTime), N'admin', CAST(0x0000A43600CB9664 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (176, N'5', 3, N'5010010013', N'COST OF GOODS SOLD - YPM', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CBABF2 AS DateTime), N'admin', CAST(0x0000A43600CBABF2 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (177, N'5', 3, N'5010010014', N'COST OF GOODS SOLD - KDY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CBC2C8 AS DateTime), N'admin', CAST(0x0000A43600CBC2C8 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (178, N'5', 3, N'5010010015', N'COST OF GOODS SOLD - PALLU', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CBEE5A AS DateTime), N'admin', CAST(0x0000A43600CBEE5A AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (179, N'5', 3, N'5010010016', N'COST OF GOODS SOLD - KG', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC0826 AS DateTime), N'admin', CAST(0x0000A43600CC0826 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (180, N'5', 3, N'5010010017', N'COST OF GOODS SOLD - RP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC18C0 AS DateTime), N'admin', CAST(0x0000A43600CC18C0 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (181, N'5', 3, N'5010010018', N'COST OF GOODS SOLD - WWP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC2ABB AS DateTime), N'admin', CAST(0x0000A43600CC2ABB AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (182, N'5', 3, N'5010010019', N'COST OF GOODS SOLD - WWG', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC41BD AS DateTime), N'admin', CAST(0x0000A43600CC41BD AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (183, N'5', 3, N'5010010020', N'COST OF GOODS SOLD - KL', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC51D9 AS DateTime), N'admin', CAST(0x0000A43600CC51D9 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (184, N'5', 3, N'5010010021', N'COST OF GOODS SOLD - KCC', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC665F AS DateTime), N'admin', CAST(0x0000A43600CC665F AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (185, N'5', 3, N'5010010022', N'COST OF GOODS SOLD - PD', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC768B AS DateTime), N'admin', CAST(0x0000A43600CC768B AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (186, N'5', 3, N'5010010023', N'COST OF GOODS SOLD - KKM', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CC8D30 AS DateTime), N'admin', CAST(0x0000A43600CC8D30 AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (187, N'5', 3, N'5010010024', N'COST OF GOODS SOLD -EXHIBITION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CCB4CE AS DateTime), N'admin', CAST(0x0000A43600CCB4CE AS DateTime), 0, 2, 0, 1, 163, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (188, N'5', 2, N'501002', N'PURCHASES MATERIALS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CCF3A5 AS DateTime), N'admin', CAST(0x0000A43600CCF3A5 AS DateTime), 0, 2, 0, 1, 162, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (189, N'5', 2, N'501003', N'DISCOUNTS RECEIVED', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CF2A40 AS DateTime), N'admin', CAST(0x0000A43600CF2A40 AS DateTime), 0, 2, 0, 1, 162, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (190, N'5', 1, N'502', N'ADMINISTRATIVE EXPENSES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CF587A AS DateTime), N'admin', CAST(0x0000A43600CF587A AS DateTime), 0, 2, 1, 1, 5, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (191, N'5', 2, N'502001', N'STAFF EXPENSES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CF7887 AS DateTime), N'admin', CAST(0x0000A43600CF7887 AS DateTime), 0, 2, 1, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (192, N'5', 3, N'5020010001', N'GROSS SALARIES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CF939C AS DateTime), N'admin', CAST(0x0000A43600CF939C AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (193, N'5', 3, N'5020010002', N'ALLOWANCES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CFAF11 AS DateTime), N'admin', CAST(0x0000A43600CFAF11 AS DateTime), 0, 2, 1, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (194, N'5', 4, N'502001000200001', N'TRANSPORT ALLOWANCES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CFC455 AS DateTime), N'admin', CAST(0x0000A43600CFC455 AS DateTime), 0, 2, 0, 1, 193, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (195, N'5', 4, N'502001000200002', N'ATTENDANCE ALLOWANCES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CFDA48 AS DateTime), N'admin', CAST(0x0000A43600CFDA48 AS DateTime), 0, 2, 0, 1, 193, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (196, N'5', 4, N'502001000200003', N'OTHER ALLOWANCES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CFEB58 AS DateTime), N'admin', CAST(0x0000A43600CFEB58 AS DateTime), 0, 2, 0, 1, 193, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (197, N'5', 4, N'502001000200004', N'VEHICLE & FUEL ALLOWANCES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600CFFB06 AS DateTime), N'admin', CAST(0x0000A43600CFFB06 AS DateTime), 0, 2, 0, 1, 193, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (198, N'5', 3, N'5020010003', N'E.P.F', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D02722 AS DateTime), N'admin', CAST(0x0000A43600D02722 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (199, N'5', 3, N'5020010004', N'E.T.F', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D07C04 AS DateTime), N'admin', CAST(0x0000A43600D07C04 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (200, N'5', 3, N'5020010005', N'BONUS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D086B6 AS DateTime), N'admin', CAST(0x0000A43600D086B6 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (201, N'5', 3, N'5020010006', N'TRAINING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D091CD AS DateTime), N'admin', CAST(0x0000A43600D091CD AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (202, N'5', 3, N'5020010007', N'STAFF RECRUITMENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D09E56 AS DateTime), N'admin', CAST(0x0000A43600D09E56 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (203, N'5', 3, N'5020010008', N'MOTIVATION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D0AB93 AS DateTime), N'admin', CAST(0x0000A43600D0AB93 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (204, N'5', 3, N'5020010009', N'ENTERTAINMENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D0BC27 AS DateTime), N'admin', CAST(0x0000A43600D0BC27 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (205, N'5', 3, N'5020010010', N'MEDICAL EXPENSES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D0CE1D AS DateTime), N'admin', CAST(0x0000A43600D0CE1D AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (206, N'5', 3, N'5020010011', N'UNIFORM', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D0DEE2 AS DateTime), N'admin', CAST(0x0000A43600D0DEE2 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (207, N'5', 3, N'5020010012', N'TEA & MEALS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D0F17C AS DateTime), N'admin', CAST(0x0000A43600D0F17C AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (208, N'5', 3, N'5020010013', N'ANNIVERSARY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D1260F AS DateTime), N'admin', CAST(0x0000A43600D1260F AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (209, N'5', 3, N'5020010014', N'GIFT & WELFARE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D1447A AS DateTime), N'admin', CAST(0x0000A43600D1447A AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (210, N'5', 3, N'5020010015', N'IFTHAR', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D156C5 AS DateTime), N'admin', CAST(0x0000A43600D156C5 AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (212, N'5', 2, N'502002', N'UTILITY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D18C05 AS DateTime), N'admin', CAST(0x0000A43600D18C05 AS DateTime), 0, 2, 1, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (213, N'5', 3, N'5020020001', N'ELECTRICITY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D1B04F AS DateTime), N'admin', CAST(0x0000A43600D1B04F AS DateTime), 0, 2, 0, 1, 212, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (214, N'5', 3, N'5020020002', N'TELEPHONE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D1C927 AS DateTime), N'admin', CAST(0x0000A43600D1C927 AS DateTime), 0, 2, 0, 1, 212, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (215, N'5', 3, N'5020020003', N'MOBILE PHONE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D1D980 AS DateTime), N'admin', CAST(0x0000A43600D1D980 AS DateTime), 0, 2, 0, 1, 212, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (216, N'5', 3, N'5020020004', N'WATER', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D1EC07 AS DateTime), N'admin', CAST(0x0000A43600D1EC07 AS DateTime), 0, 2, 0, 1, 212, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (217, N'5', 2, N'502003', N'RENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D20570 AS DateTime), N'admin', CAST(0x0000A43600D20570 AS DateTime), 0, 2, 0, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (218, N'5', 2, N'502004', N'SECURITY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D22374 AS DateTime), N'admin', CAST(0x0000A43600D22374 AS DateTime), 0, 2, 0, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (219, N'5', 2, N'502005', N'GENERAL EXPENSES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D2458C AS DateTime), N'admin', CAST(0x0000A43600D2458C AS DateTime), 0, 2, 0, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (220, N'5', 2, N'502006', N'MAINTENANCE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D25D26 AS DateTime), N'admin', CAST(0x0000A43600D25D26 AS DateTime), 0, 2, 0, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (221, N'5', 2, N'502007', N'STATIONERY / PERIODIC', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D27DA6 AS DateTime), N'admin', CAST(0x0000A43600D27DA6 AS DateTime), 0, 2, 1, 1, 190, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (222, N'5', 3, N'5020070001', N'STATIONERIES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D29DF5 AS DateTime), N'admin', CAST(0x0000A43600D29DF5 AS DateTime), 0, 2, 0, 1, 221, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (223, N'5', 3, N'5020070002', N'PERIODIC', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D2B41D AS DateTime), N'admin', CAST(0x0000A43600D2B41D AS DateTime), 0, 2, 0, 1, 221, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (224, N'5', 3, N'5020070003', N'POSTAGE & COURIER', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D2C1A4 AS DateTime), N'admin', CAST(0x0000A43600D2C1A4 AS DateTime), 0, 2, 0, 1, 221, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (225, N'5', 1, N'503', N'SELLING / DISTRIBUTION EXPENSES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D3F094 AS DateTime), N'admin', CAST(0x0000A43600D3F094 AS DateTime), 0, 2, 1, 1, 5, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (226, N'5', 2, N'503001', N'MARKETING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D40916 AS DateTime), N'admin', CAST(0x0000A43600D40916 AS DateTime), 0, 2, 1, 1, 225, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (227, N'5', 3, N'5030010001', N'EVENTS & PROMOTION - NOLIMIT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D4D123 AS DateTime), N'admin', CAST(0x0000A43600D4D123 AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (228, N'5', 3, N'5030010002', N'EVENTS & PROMOTION - GLITZ', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D50267 AS DateTime), N'admin', CAST(0x0000A43600D50267 AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (229, N'5', 3, N'5030010003', N'BRANDING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D52444 AS DateTime), N'admin', CAST(0x0000A43600D52444 AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (230, N'5', 3, N'5030010004', N'CSR - NOLIMIT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D532BC AS DateTime), N'admin', CAST(0x0000A43600D532BC AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (231, N'5', 3, N'5030010005', N'CSR - GLITZ', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D548DD AS DateTime), N'admin', CAST(0x0000A43600D548DD AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (232, N'5', 3, N'5030010006', N'ADVERTISING SCHOOL /INSTITUTION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600D55D05 AS DateTime), N'admin', CAST(0x0000A43600D55D05 AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (233, N'5', 2, N'503002', N'PRINTING / PACKAGING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DC9486 AS DateTime), N'admin', CAST(0x0000A43600DC9486 AS DateTime), 0, 2, 1, 1, 225, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (234, N'5', 3, N'5030020001', N'PRINTING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DCA790 AS DateTime), N'admin', CAST(0x0000A43600DCA790 AS DateTime), 0, 2, 0, 1, 233, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (235, N'5', 3, N'5030020002', N'PRINTING - GV', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DCC31E AS DateTime), N'admin', CAST(0x0000A43600DCC31E AS DateTime), 0, 2, 0, 1, 233, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (236, N'5', 3, N'5030020003', N'BAGS & BOXES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DCDB33 AS DateTime), N'admin', CAST(0x0000A43600DCDB33 AS DateTime), 0, 2, 0, 1, 233, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (237, N'5', 3, N'5030020004', N'HANGERS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DCF1DC AS DateTime), N'admin', CAST(0x0000A43600DCF1DC AS DateTime), 0, 2, 0, 1, 233, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (238, N'5', 3, N'5030020005', N'PRICE TAGS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DD054C AS DateTime), N'admin', CAST(0x0000A43600DD054C AS DateTime), 0, 2, 0, 1, 233, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (239, N'5', 3, N'5030020006', N'SECURITY PIN & STICKERS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DD1910 AS DateTime), N'admin', CAST(0x0000A43600DD1910 AS DateTime), 0, 2, 0, 1, 233, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (240, N'5', 2, N'503003', N'TRANSPORTATION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DD386C AS DateTime), N'admin', CAST(0x0000A43600DD386C AS DateTime), 0, 2, 1, 1, 225, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (241, N'5', 3, N'5030030001', N'DIESEL', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DD4B33 AS DateTime), N'admin', CAST(0x0000A43600DD4B33 AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (242, N'5', 3, N'5030030002', N'PETROL', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DD6582 AS DateTime), N'admin', CAST(0x0000A43600DD6582 AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (244, N'5', 3, N'5030030004', N'PARKING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DD8D3B AS DateTime), N'admin', CAST(0x0000A43600DD8D3B AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (245, N'5', 3, N'5030030005', N'TRAVELLING', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DDB657 AS DateTime), N'admin', CAST(0x0000A43600DDB657 AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (246, N'5', 3, N'5030030006', N'VEHICLE MAINT.', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DDD190 AS DateTime), N'admin', CAST(0x0000A43600DDD190 AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (247, N'5', 3, N'5030030007', N'LICENSE & INSURANCE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DDEBC5 AS DateTime), N'admin', CAST(0x0000A43600DDEBC5 AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (248, N'5', 3, N'5030030008', N'OVER SEAS EXPENSES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DDFC6D AS DateTime), N'admin', CAST(0x0000A43600DDFC6D AS DateTime), 0, 2, 0, 1, 240, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (249, N'5', 2, N'503004', N'SALES PROMOTION (STAFF)', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DE125E AS DateTime), N'admin', CAST(0x0000A43600DE125E AS DateTime), 0, 2, 0, 1, 225, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (250, N'5', 2, N'503005', N'DISCOUNT ISSUED', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DE2E93 AS DateTime), N'admin', CAST(0x0000A43600DE2E93 AS DateTime), 0, 2, 1, 1, 225, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (251, N'5', 2, N'503006', N'COMPLIMENTS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DE5A7E AS DateTime), N'admin', CAST(0x0000A43600DE5A7E AS DateTime), 0, 2, 0, 1, 225, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (252, N'5', 1, N'504', N'OTHERS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DE904B AS DateTime), N'admin', CAST(0x0000A43600DE904B AS DateTime), 0, 2, 1, 1, 5, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (253, N'5', 2, N'504001', N'FEES & CHARGES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DEBDBE AS DateTime), N'admin', CAST(0x0000A43600DEBDBE AS DateTime), 0, 2, 1, 1, 252, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (254, N'5', 3, N'5040010001', N'BANK CHARGES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DECF9D AS DateTime), N'admin', CAST(0x0000A43600DECF9D AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (255, N'5', 3, N'5040010002', N'CREDIT CARD CHARGES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DEE257 AS DateTime), N'admin', CAST(0x0000A43600DEE257 AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (256, N'5', 3, N'5040010003', N'FINES AND PENALTIES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DEEE4D AS DateTime), N'admin', CAST(0x0000A43600DEEE4D AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (257, N'5', 3, N'5040010004', N'LEGAL FEES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DF0262 AS DateTime), N'admin', CAST(0x0000A43600DF0262 AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (258, N'5', 3, N'5040010005', N'BUSINESS & OTHER LICENSE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DF14FF AS DateTime), N'admin', CAST(0x0000A43600DF14FF AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (259, N'5', 3, N'5040010006', N'STAMP DUTY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DF2EB9 AS DateTime), N'admin', CAST(0x0000A43600DF2EB9 AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (261, N'5', 3, N'5040010008', N'BAD DEBT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DF70B4 AS DateTime), N'admin', CAST(0x0000A43600DF70B4 AS DateTime), 0, 2, 0, 1, 253, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (262, N'5', 2, N'504002', N'DONATIONS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DF8A6D AS DateTime), N'admin', CAST(0x0000A43600DF8A6D AS DateTime), 0, 2, 1, 1, 252, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (263, N'5', 3, N'5040020001', N'DONATION OTHERS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DF9FF4 AS DateTime), N'admin', CAST(0x0000A43600DF9FF4 AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (264, N'5', 3, N'5040020002', N'DONATION - SOCIAL EDUCATION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DFBE5A AS DateTime), N'admin', CAST(0x0000A43600DFBE5A AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (265, N'5', 3, N'5040020003', N'NATIONAL DISASTER', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DFCE92 AS DateTime), N'admin', CAST(0x0000A43600DFCE92 AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (266, N'5', 3, N'5040020004', N'COMMUNITY DEVELOPMENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DFDA7F AS DateTime), N'admin', CAST(0x0000A43600DFDA7F AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (267, N'5', 3, N'5040020005', N'DONATION - T & M', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DFE569 AS DateTime), N'admin', CAST(0x0000A43600DFE569 AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (268, N'5', 3, N'5040020006', N'DONATION - SJ', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600DFF677 AS DateTime), N'admin', CAST(0x0000A43600DFF677 AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (269, N'5', 3, N'5040020007', N'DONATION - DM', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E001CA AS DateTime), N'admin', CAST(0x0000A43600E001CA AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (270, N'5', 3, N'5040020008', N'CHARITY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E00DB1 AS DateTime), N'admin', CAST(0x0000A43600E00DB1 AS DateTime), 0, 2, 0, 1, 262, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (272, N'5', 2, N'504003', N'PROFESSIONAL FEES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E02C43 AS DateTime), N'admin', CAST(0x0000A43600E02C43 AS DateTime), 0, 2, 1, 1, 252, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (273, N'5', 3, N'5040030001', N'AUDIT FEE', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E04418 AS DateTime), N'admin', CAST(0x0000A43600E04418 AS DateTime), 0, 2, 0, 1, 272, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (274, N'5', 3, N'5040030002', N'LAWYER FEES', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E05192 AS DateTime), N'admin', CAST(0x0000A43600E05192 AS DateTime), 0, 2, 0, 1, 272, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (275, N'5', 3, N'5040030003', N'CONSULTANCY', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E05C58 AS DateTime), N'admin', CAST(0x0000A43600E05C58 AS DateTime), 0, 2, 0, 1, 272, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (276, N'5', 2, N'504004', N'TAXATION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E06F31 AS DateTime), N'admin', CAST(0x0000A43600E06F31 AS DateTime), 0, 2, 1, 1, 252, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (277, N'5', 3, N'5040040001', N'ECONOMIC SERVICE CHS', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E086D6 AS DateTime), N'admin', CAST(0x0000A43600E086D6 AS DateTime), 0, 2, 0, 1, 276, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (278, N'5', 3, N'5040040002', N'ASSESSMENT TAX', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E090F1 AS DateTime), N'admin', CAST(0x0000A43600E090F1 AS DateTime), 0, 2, 0, 1, 276, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (279, N'5', 3, N'5040040003', N'PARTNERSHIP TAX', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E09D9E AS DateTime), N'admin', CAST(0x0000A43600E09D9E AS DateTime), 0, 2, 0, 1, 276, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (280, N'5', 2, N'504005', N'DEPRECIATION', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E0ABD7 AS DateTime), N'admin', CAST(0x0000A43600E0ABD7 AS DateTime), 0, 2, 1, 1, 252, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (281, N'5', 3, N'5040050001', N'FURNITURE & FITTINGS - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E0C587 AS DateTime), N'admin', CAST(0x0000A43600E0C587 AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (282, N'5', 3, N'5040050002', N'RENOVATION- DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E0D10D AS DateTime), N'admin', CAST(0x0000A43600E0D10D AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (283, N'5', 3, N'5040050003', N'EQUIPMENT - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E0DB78 AS DateTime), N'admin', CAST(0x0000A43600E0DB78 AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (284, N'5', 3, N'5040050004', N'COMPUTERS - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E0E864 AS DateTime), N'admin', CAST(0x0000A43600E0E864 AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (285, N'5', 3, N'5040050005', N'POS - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E0F909 AS DateTime), N'admin', CAST(0x0000A43600E0F909 AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (286, N'5', 3, N'5040050006', N'SOFTWARE - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E107D9 AS DateTime), N'admin', CAST(0x0000A43600E107D9 AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (288, N'5', 3, N'5040050008', N'SECURITY SYSTEM - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E12268 AS DateTime), N'admin', CAST(0x0000A43600E12268 AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (289, N'5', 3, N'5040050009', N'HOARDINGS - DEP', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E12FCB AS DateTime), N'admin', CAST(0x0000A43600E12FCB AS DateTime), 0, 2, 0, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (290, N'5', 2, N'504006', N'STOCK ADJUSTMENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E13C77 AS DateTime), N'admin', CAST(0x0000A43600E13C77 AS DateTime), 0, 2, 1, 1, 252, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (291, N'5', 3, N'5040060001', N'TRADE STOCK ADJUSTMENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E15682 AS DateTime), N'admin', CAST(0x0000A43600E15682 AS DateTime), 0, 2, 0, 1, 290, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (292, N'5', 3, N'5040060002', N'NON TRADE STOCK ADJUSTMENT', N'', 5, 1, 0, 0, 1, N'admin', CAST(0x0000A43600E1624C AS DateTime), N'admin', CAST(0x0000A43600E1624C AS DateTime), 0, 2, 0, 1, 290, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (293, N'2', 1, N'210', N'ACCRUED EXPENSES', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43A01109B37 AS DateTime), N'admin', CAST(0x0000A43A01109B37 AS DateTime), 0, 1, 1, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (294, N'2', 2, N'210001', N'NBT - PURCHASES', N'', 2, 2, 0, 0, 1, N'admin', CAST(0x0000A43A0110BA23 AS DateTime), N'admin', CAST(0x0000A43A0110BA23 AS DateTime), 0, 1, 0, 1, 293, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (295, N'1', 2, N'101010', N'MOTOR VEHICLE', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700E99492 AS DateTime), N'nasooha', CAST(0x0000A46700E99492 AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (296, N'1', 3, N'1010100001', N'BUSES', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700ED0054 AS DateTime), N'nasooha', CAST(0x0000A46700ED0054 AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (297, N'1', 4, N'101010000100001', N'COST - BU ND-6000', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EE8940 AS DateTime), N'nasooha', CAST(0x0000A46700EE8940 AS DateTime), 0, 1, 0, 1, 296, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (298, N'1', 4, N'101010000100002', N'ACC DEP - BU ND-6000', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EEB03F AS DateTime), N'nasooha', CAST(0x0000A46700EEB03F AS DateTime), 0, 1, 0, 1, 296, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (299, N'1', 4, N'101010000100003', N'COST - BU NA-8250', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EEE037 AS DateTime), N'nasooha', CAST(0x0000A46700EEE037 AS DateTime), 0, 1, 0, 1, 296, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (300, N'1', 4, N'101010000100004', N'ACC DEP - BU NA-8250', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EEF3B4 AS DateTime), N'nasooha', CAST(0x0000A46700EEF3B4 AS DateTime), 0, 1, 0, 1, 296, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (301, N'1', 4, N'101010000100005', N'COST - BU ND-7833', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EF101D AS DateTime), N'nasooha', CAST(0x0000A46700EF101D AS DateTime), 0, 1, 0, 1, 296, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (302, N'1', 4, N'101010000100006', N'ACC DEP - BU ND-7833', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EF24F4 AS DateTime), N'nasooha', CAST(0x0000A46700EF24F4 AS DateTime), 0, 1, 0, 1, 296, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (303, N'1', 3, N'1010100002', N'CARS', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EF5D27 AS DateTime), N'nasooha', CAST(0x0000A46700EF5D27 AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (304, N'1', 4, N'101010000200001', N'COST - CA KR-8222', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EFE06E AS DateTime), N'nasooha', CAST(0x0000A46700EFE06E AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (305, N'1', 4, N'101010000200002', N'ACC DEP - CA KR-8222', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46700EFF50D AS DateTime), N'nasooha', CAST(0x0000A46700EFF50D AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (308, N'1', 4, N'101010000200005', N'COST - CA KR-2444', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C0D539 AS DateTime), N'nasooha', CAST(0x0000A46800C0D539 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (309, N'1', 4, N'101010000200006', N'ACC DEP - CA KR-2444', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C13206 AS DateTime), N'nasooha', CAST(0x0000A46800C13206 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (310, N'1', 4, N'101010000200007', N'COST - CA KV-0077', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C2B9F2 AS DateTime), N'nasooha', CAST(0x0000A46800C2B9F2 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (311, N'1', 4, N'101010000200008', N'ACC DEP - CA KV-0077', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C2CBD3 AS DateTime), N'nasooha', CAST(0x0000A46800C2CBD3 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (312, N'1', 4, N'101010000200009', N'COST - CA KY-0555', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C2E397 AS DateTime), N'nasooha', CAST(0x0000A46800C2E397 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (313, N'1', 4, N'101010000200010', N'ACC DEP - CA KY-0555', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C30A5E AS DateTime), N'nasooha', CAST(0x0000A46800C30A5E AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (314, N'1', 4, N'101010000200011', N'COST - CA KX-6321', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C370DF AS DateTime), N'nasooha', CAST(0x0000A46800C370DF AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (315, N'1', 4, N'101010000200012', N'ACC DEP - CA KX-6321', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46800C3811B AS DateTime), N'nasooha', CAST(0x0000A46800C3811B AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (316, N'1', 4, N'101010000200013', N'COST - CA KY-3773', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00980858 AS DateTime), N'nasooha', CAST(0x0000A46B00980858 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (317, N'1', 4, N'101010000200014', N'ACC DEP - CA KY-3773', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0098206C AS DateTime), N'nasooha', CAST(0x0000A46B0098206C AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (318, N'1', 4, N'101010000200015', N'COST - CA KR-4442', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00983CD0 AS DateTime), N'nasooha', CAST(0x0000A46B00983CD0 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (319, N'1', 4, N'101010000200016', N'ACC DEP - CA KR-4442', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00984E99 AS DateTime), N'nasooha', CAST(0x0000A46B00984E99 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (320, N'1', 4, N'101010000200017', N'COST - CA KL-4447', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0098796F AS DateTime), N'nasooha', CAST(0x0000A46B0098796F AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (321, N'1', 4, N'101010000200018', N'ACC DEP - CA KL-4447', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00988944 AS DateTime), N'nasooha', CAST(0x0000A46B00988944 AS DateTime), 0, 1, 0, 1, 303, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (322, N'1', 3, N'1010100003', N'JEEPS', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0098C091 AS DateTime), N'nasooha', CAST(0x0000A46B0098C091 AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (323, N'1', 4, N'101010000300001', N'COST - JP KW-1155', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0099A598 AS DateTime), N'nasooha', CAST(0x0000A46B0099A598 AS DateTime), 0, 1, 0, 1, 322, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (324, N'1', 4, N'101010000300002', N'ACC DEP - JP KW-1155', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0099B9DF AS DateTime), N'nasooha', CAST(0x0000A46B0099B9DF AS DateTime), 0, 1, 0, 1, 322, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (325, N'1', 3, N'1010100004', N'LORRIES', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00E851DC AS DateTime), N'nasooha', CAST(0x0000A46B00E851DC AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (326, N'1', 4, N'101010000400001', N'COST - LO 227-3323', N'ATLAS', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00EF904D AS DateTime), N'nasooha', CAST(0x0000A46B00EF904D AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (327, N'1', 4, N'101010000400002', N'ACC DEP - LO 227-3323', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00EFAF15 AS DateTime), N'nasooha', CAST(0x0000A46B00EFAF15 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (328, N'1', 4, N'101010000400003', N'COST - LO LJ-0216', N'MITSUBISHI', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00EFE48F AS DateTime), N'nasooha', CAST(0x0000A46B00EFE48F AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (329, N'1', 4, N'101010000400004', N'ACC DEP - LO LJ-0216', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00EFF94B AS DateTime), N'nasooha', CAST(0x0000A46B00EFF94B AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (332, N'1', 4, N'101010000400007', N'COST - LO LK-4847', N'MITSUBISHI', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F0D0BB AS DateTime), N'nasooha', CAST(0x0000A46B00F0D0BB AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (333, N'1', 4, N'101010000400008', N'ACC DEP - LO LK-4847', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F0E58D AS DateTime), N'nasooha', CAST(0x0000A46B00F0E58D AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (334, N'1', 4, N'101010000400009', N'COST - LO GK-0467', N'ISUZU', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F183D7 AS DateTime), N'nasooha', CAST(0x0000A46B00F183D7 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (335, N'1', 4, N'101010000400010', N'ACC DEP - LO GK-0467', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F1A05F AS DateTime), N'nasooha', CAST(0x0000A46B00F1A05F AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (336, N'1', 4, N'101010000400011', N'COST - LO LA-8078', N'TATA', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F1F0C0 AS DateTime), N'nasooha', CAST(0x0000A46B00F1F0C0 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (337, N'1', 4, N'101010000400012', N'ACC DEP - LO LA-8078', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F20C50 AS DateTime), N'nasooha', CAST(0x0000A46B00F20C50 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (338, N'1', 4, N'101010000400013', N'COST - LO LB-9230', N'TATA', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F22D60 AS DateTime), N'nasooha', CAST(0x0000A46B00F22D60 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (339, N'1', 4, N'101010000400014', N'ACC DEP - LO LB-9230', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F2699A AS DateTime), N'nasooha', CAST(0x0000A46B00F2699A AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (340, N'1', 4, N'101010000400015', N'COST - LO LD-2177', N'ISUZU', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F29627 AS DateTime), N'nasooha', CAST(0x0000A46B00F29627 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (341, N'1', 4, N'101010000400016', N'ACC DEP - LO LD-2177', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F2AC0E AS DateTime), N'nasooha', CAST(0x0000A46B00F2AC0E AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (342, N'1', 4, N'101010000400017', N'COST - LO LG-0539', N'ISUZU', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F2D0DB AS DateTime), N'nasooha', CAST(0x0000A46B00F2D0DB AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (343, N'1', 4, N'101010000400018', N'ACC DEP - LO LG-0539', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F2EB8A AS DateTime), N'nasooha', CAST(0x0000A46B00F2EB8A AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (344, N'1', 4, N'101010000400019', N'COST - LO LG-0538', N'ISUZU', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F30EA9 AS DateTime), N'nasooha', CAST(0x0000A46B00F30EA9 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (345, N'1', 4, N'101010000400020', N'ACC DEP - LO LG-0538', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F32440 AS DateTime), N'nasooha', CAST(0x0000A46B00F32440 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (346, N'1', 4, N'101010000400021', N'COST - LO LH-6514', N'ISUZU', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F347A3 AS DateTime), N'nasooha', CAST(0x0000A46B00F347A3 AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (347, N'1', 4, N'101010000400022', N'ACC DEP - LO LH-6514', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F35BDB AS DateTime), N'nasooha', CAST(0x0000A46B00F35BDB AS DateTime), 0, 1, 0, 1, 325, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (348, N'1', 3, N'1010100005', N'MOTOR BIKES', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F67306 AS DateTime), N'nasooha', CAST(0x0000A46B00F67306 AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (349, N'1', 3, N'1010100006', N'THREE WHEELERS', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F6B1F6 AS DateTime), N'nasooha', CAST(0x0000A46B00F6B1F6 AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (350, N'1', 3, N'1010100007', N'VANS', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B00F6CBD1 AS DateTime), N'nasooha', CAST(0x0000A46B00F6CBD1 AS DateTime), 0, 1, 1, 1, 295, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (351, N'1', 4, N'101010000600001', N'COST - TW YS-7063', N'BAJAJ', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B010FF89A AS DateTime), N'nasooha', CAST(0x0000A46B010FF89A AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (352, N'1', 4, N'101010000600002', N'ACC DEP - TW YS-7063', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B01101350 AS DateTime), N'nasooha', CAST(0x0000A46B01101350 AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (353, N'1', 4, N'101010000600003', N'COST - TW YR-6010', N'BAJAJ', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B011035D1 AS DateTime), N'nasooha', CAST(0x0000A46B011035D1 AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (354, N'1', 4, N'101010000600004', N'ACC DEP - TW YR-6010', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B011048B1 AS DateTime), N'nasooha', CAST(0x0000A46B011048B1 AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (355, N'1', 4, N'101010000600005', N'COST - TW YT-8721', N'BAJAJ', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B01106A69 AS DateTime), N'nasooha', CAST(0x0000A46B01106A69 AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (356, N'1', 4, N'101010000600006', N'ACC DEP - TW YT-8721', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B01107ADB AS DateTime), N'nasooha', CAST(0x0000A46B01107ADB AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (361, N'1', 4, N'101010000600011', N'COST - TW QN-6434', N'BAJAJ', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0111C113 AS DateTime), N'nasooha', CAST(0x0000A46B0111C113 AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (362, N'1', 4, N'101010000600012', N'ACC DEP - TW QN-6434', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0111D26E AS DateTime), N'nasooha', CAST(0x0000A46B0111D26E AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (365, N'1', 4, N'101010000600015', N'COST - TW QX-4335', N'BAJAJ', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B01129E3E AS DateTime), N'nasooha', CAST(0x0000A46B01129E3E AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (366, N'1', 4, N'101010000600016', N'ACC DEP - TW QX-4335', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46B0112AF77 AS DateTime), N'nasooha', CAST(0x0000A46B0112AF77 AS DateTime), 0, 1, 0, 1, 349, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (367, N'2', 1, N'211', N'LOCATION CURRENT ACCOUNTS', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A140BB AS DateTime), N'nasooha', CAST(0x0000A46D00A140BB AS DateTime), 0, 1, 1, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (368, N'2', 2, N'211001', N'CURRENT ACCOUNT - HO', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A28DF0 AS DateTime), N'nasooha', CAST(0x0000A46D00A28DF0 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (369, N'2', 2, N'211002', N'CURRENT ACCOUNT - DL', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A2A8BE AS DateTime), N'nasooha', CAST(0x0000A46D00A2A8BE AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (370, N'2', 2, N'211003', N'CURRENT ACCOUNT - DG', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A2B3BA AS DateTime), N'nasooha', CAST(0x0000A46D00A2B3BA AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (371, N'2', 2, N'211004', N'CURRENT ACCOUNT - MG', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A301CA AS DateTime), N'nasooha', CAST(0x0000A46D00A301CA AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (372, N'2', 2, N'211005', N'CURRENT ACCOUNT - NG', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A30D54 AS DateTime), N'nasooha', CAST(0x0000A46D00A30D54 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (373, N'2', 2, N'211006', N'CURRENT ACCOUNT - BR', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A31818 AS DateTime), N'nasooha', CAST(0x0000A46D00A31818 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (374, N'2', 2, N'211007', N'CURRENT ACCOUNT - HP', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A32833 AS DateTime), N'nasooha', CAST(0x0000A46D00A32833 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (375, N'2', 2, N'211008', N'CURRENT ACCOUNT - ML', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A33874 AS DateTime), N'nasooha', CAST(0x0000A46D00A33874 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (376, N'2', 2, N'211009', N'CURRENT ACCOUNT - 7MP', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3437A AS DateTime), N'nasooha', CAST(0x0000A46D00A3437A AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (377, N'2', 2, N'211010', N'CURRENT ACCOUNT - WW', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3507E AS DateTime), N'nasooha', CAST(0x0000A46D00A3507E AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (378, N'2', 2, N'211011', N'CURRENT ACCOUNT - NBG', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A35E34 AS DateTime), N'nasooha', CAST(0x0000A46D00A35E34 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (379, N'2', 2, N'211012', N'CURRENT ACCOUNT - NBL', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A36D74 AS DateTime), N'nasooha', CAST(0x0000A46D00A36D74 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (380, N'2', 2, N'211013', N'CURRENT ACCOUNT - RM', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A37A44 AS DateTime), N'nasooha', CAST(0x0000A46D00A37A44 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (381, N'2', 2, N'211014', N'CURRENT ACCOUNT - YPM', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A38639 AS DateTime), N'nasooha', CAST(0x0000A46D00A38639 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (382, N'2', 2, N'211015', N'CURRENT ACCOUNT - KD', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A39C2E AS DateTime), N'nasooha', CAST(0x0000A46D00A39C2E AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (383, N'2', 2, N'211016', N'CURRENT ACCOUNT - KG', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3A8E2 AS DateTime), N'nasooha', CAST(0x0000A46D00A3A8E2 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (384, N'2', 2, N'211017', N'CURRENT ACCOUNT - RP', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3B8BC AS DateTime), N'nasooha', CAST(0x0000A46D00A3B8BC AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (385, N'2', 2, N'211018', N'CURRENT ACCOUNT - WWP', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3CAA2 AS DateTime), N'nasooha', CAST(0x0000A46D00A3CAA2 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (386, N'2', 2, N'211019', N'CURRENT ACCOUNT - WWI', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3D988 AS DateTime), N'nasooha', CAST(0x0000A46D00A3D988 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (387, N'2', 2, N'211020', N'CURRENT ACCOUNT - KL', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3E503 AS DateTime), N'nasooha', CAST(0x0000A46D00A3E503 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (388, N'2', 2, N'211021', N'CURRENT ACCOUNT - KCC', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A46D00A3F025 AS DateTime), N'nasooha', CAST(0x0000A46D00A3F025 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (389, N'1', 2, N'101011', N'DISPLAY UNITS', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00AC2437 AS DateTime), N'nasooha', CAST(0x0000A46D00AC2437 AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (390, N'1', 2, N'101012', N'GENERATORS', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00AC4808 AS DateTime), N'nasooha', CAST(0x0000A46D00AC4808 AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (391, N'1', 2, N'101013', N'LAND & BUILDING', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00AC6F6D AS DateTime), N'nasooha', CAST(0x0000A46D00AC6F6D AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (392, N'1', 2, N'101016', N'RENT ADVANCES', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00AC9D5F AS DateTime), N'nasooha', CAST(0x0000A46D00AC9D5F AS DateTime), 0, 1, 1, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (393, N'1', 3, N'1010160001', N'RENT ADVANCE - SHOWROOM', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00ACC1C5 AS DateTime), N'nasooha', CAST(0x0000A46D00ACC1C5 AS DateTime), 0, 1, 0, 1, 392, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (394, N'1', 3, N'1010160002', N'RENT ADVANCE - SQ', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00ACD1FC AS DateTime), N'nasooha', CAST(0x0000A46D00ACD1FC AS DateTime), 0, 1, 0, 1, 392, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (395, N'1', 3, N'1010160003', N'RENT ADVANCE - OTHER', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A46D00ACDEBA AS DateTime), N'nasooha', CAST(0x0000A46D00ACDEBA AS DateTime), 0, 1, 0, 1, 392, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (397, N'1', 4, N'101010000700001', N'COST - VA 252-7676', N'TOYOTA - HIACE', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B6EB68 AS DateTime), N'nasooha', CAST(0x0000A47200B6EB68 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (398, N'1', 4, N'101010000700002', N'ACC DEP - VA 252-7676', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B6FF27 AS DateTime), N'nasooha', CAST(0x0000A47200B6FF27 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (399, N'1', 4, N'101010000700003', N'COST - VA PC-5654', N'SUZUKI - BUOY', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B73C37 AS DateTime), N'nasooha', CAST(0x0000A47200B73C37 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (400, N'1', 4, N'101010000700004', N'ACC DEP - VA PC-5654', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B74DE5 AS DateTime), N'nasooha', CAST(0x0000A47200B74DE5 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (401, N'1', 4, N'101010000700005', N'COST - VA PC-8726', N'TOYOTA - SGL', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B77276 AS DateTime), N'nasooha', CAST(0x0000A47200B77276 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (402, N'1', 4, N'101010000700006', N'ACC DEP - VA PC-8726', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B783E2 AS DateTime), N'nasooha', CAST(0x0000A47200B783E2 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (403, N'1', 4, N'101010000700007', N'COST - VA PF-0221', N'NISSAN - VANETTE', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B7BB3E AS DateTime), N'nasooha', CAST(0x0000A47200B7BB3E AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (404, N'1', 4, N'101010000700008', N'ACC DEP - VA PF-0221', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B7D4DF AS DateTime), N'nasooha', CAST(0x0000A47200B7D4DF AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (405, N'1', 4, N'101010000700009', N'COST - VA PF-0123', N'NISSAN - VANETTE', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B806DB AS DateTime), N'nasooha', CAST(0x0000A47200B806DB AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (406, N'1', 4, N'101010000700010', N'ACC DEP - VA PF-0123', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B815C1 AS DateTime), N'nasooha', CAST(0x0000A47200B815C1 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (407, N'1', 4, N'101010000700011', N'COST - VA PF-1130', N'MAZDA - BONGO', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B83B53 AS DateTime), N'nasooha', CAST(0x0000A47200B83B53 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (408, N'1', 4, N'101010000700012', N'ACC DEP - VA PF-1130', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B84D4C AS DateTime), N'nasooha', CAST(0x0000A47200B84D4C AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (409, N'1', 4, N'101010000700013', N'COST - VA PD-8111', N'TOYOTA - KDH 200', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B88453 AS DateTime), N'nasooha', CAST(0x0000A47200B88453 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (410, N'1', 4, N'101010000700014', N'ACC DEP - VA PD-8111', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B89905 AS DateTime), N'nasooha', CAST(0x0000A47200B89905 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (411, N'1', 4, N'101010000700015', N'COST - VA KX-1234', N'TOYOTA - VELLFIRE', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B91E51 AS DateTime), N'nasooha', CAST(0x0000A47200B91E51 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (412, N'1', 4, N'101010000700016', N'ACC DEP - VA KX-1234', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B92E7F AS DateTime), N'nasooha', CAST(0x0000A47200B92E7F AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (413, N'1', 4, N'101010000700017', N'COST - VA HJ-9445', N'TOYOTA - HIACE 182', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B96849 AS DateTime), N'nasooha', CAST(0x0000A47200B96849 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (414, N'1', 4, N'101010000700018', N'ACC DEP - VA HJ-9445', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B9AB11 AS DateTime), N'nasooha', CAST(0x0000A47200B9AB11 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (415, N'1', 4, N'101010000700019', N'COST - VA JB-9912', N'TOYOTA - HIACE 182', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B9E757 AS DateTime), N'nasooha', CAST(0x0000A47200B9E757 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (416, N'1', 4, N'101010000700020', N'ACC DEP - VA JB-9912', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200B9FBB1 AS DateTime), N'nasooha', CAST(0x0000A47200B9FBB1 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (417, N'1', 4, N'101010000700021', N'COST - VA PA-3665', N'TOYOTA - HIACE', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BA2B1D AS DateTime), N'nasooha', CAST(0x0000A47200BA2B1D AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (418, N'1', 4, N'101010000700022', N'ACC DEP - VA PA-3665', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BA3FA4 AS DateTime), N'nasooha', CAST(0x0000A47200BA3FA4 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (419, N'1', 4, N'101010000700023', N'COST - VA PD-9669', N'TOYOTA - CR-42', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BA83B4 AS DateTime), N'nasooha', CAST(0x0000A47200BA83B4 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (420, N'1', 4, N'101010000700024', N'ACC DEP - VA PD-9669', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BAFF41 AS DateTime), N'nasooha', CAST(0x0000A47200BAFF41 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (421, N'1', 4, N'101010000700025', N'COST - VA PE-7776', N'TOYOTA - CR-42', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BB29F6 AS DateTime), N'nasooha', CAST(0x0000A47200BB29F6 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (422, N'1', 4, N'101010000700026', N'ACC DEP - VA PE-7776', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BB3B59 AS DateTime), N'nasooha', CAST(0x0000A47200BB3B59 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (423, N'1', 4, N'101010000700027', N'COST - VA PE-9019', N'TOYOTA - CREW CAB', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BBEE68 AS DateTime), N'nasooha', CAST(0x0000A47200BBEE68 AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (424, N'1', 4, N'101010000700028', N'ACC DEP - VA PE-9019', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47200BC007C AS DateTime), N'nasooha', CAST(0x0000A47200BC007C AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (450, N'5', 3, N'5030050001', N'DISCOUNTS ISSUED - GV', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47300C5653D AS DateTime), N'nasooha', CAST(0x0000A47300C5653D AS DateTime), 0, 2, 0, 1, 250, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (451, N'5', 3, N'5030050002', N'DISCOUNTS ISSUED - ARAPAIMA', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47300C5827D AS DateTime), N'nasooha', CAST(0x0000A47300C5827D AS DateTime), 0, 2, 0, 1, 250, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (452, N'5', 3, N'5040050010', N'MOTOR VEHICLE - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B84F46 AS DateTime), N'nasooha', CAST(0x0000A47400B84F46 AS DateTime), 0, 2, 1, 1, 280, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (453, N'5', 4, N'504005001000001', N'BUSES - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B867D8 AS DateTime), N'nasooha', CAST(0x0000A47400B867D8 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (454, N'5', 4, N'504005001000002', N'CARS - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B873F2 AS DateTime), N'nasooha', CAST(0x0000A47400B873F2 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (455, N'5', 4, N'504005001000003', N'JEEPS - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B888D7 AS DateTime), N'nasooha', CAST(0x0000A47400B888D7 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (456, N'5', 4, N'504005001000004', N'LORRIES - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B89A27 AS DateTime), N'nasooha', CAST(0x0000A47400B89A27 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (457, N'5', 4, N'504005001000005', N'MOTOR BIKES - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B8BA75 AS DateTime), N'nasooha', CAST(0x0000A47400B8BA75 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (458, N'5', 4, N'504005001000006', N'THREE WHEELERS - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B8D3B0 AS DateTime), N'nasooha', CAST(0x0000A47400B8D3B0 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (459, N'5', 4, N'504005001000007', N'VANS - DEP', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47400B8E1B5 AS DateTime), N'nasooha', CAST(0x0000A47400B8E1B5 AS DateTime), 0, 2, 1, 1, 452, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (460, N'5', 5, N'504005001000001000001', N'DEP - BU ND-6000', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400BC23AF AS DateTime), N'nasooha', CAST(0x0000A48500C8BBE4 AS DateTime), 0, 2, 0, 0, 453, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (461, N'5', 5, N'504005001000001000002', N'DEP - BU NA-8250', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400BC3E77 AS DateTime), N'nasooha', CAST(0x0000A48500C8C1C0 AS DateTime), 0, 2, 0, 0, 453, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (462, N'5', 5, N'504005001000001000003', N'DEP - BU ND-7833', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400BD6E32 AS DateTime), N'nasooha', CAST(0x0000A48500C8C79C AS DateTime), 0, 2, 0, 0, 453, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (463, N'5', 5, N'504005001000002000001', N'DEP - CA KR-8222', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C2C4AE AS DateTime), N'nasooha', CAST(0x0000A48500C8D0FC AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (464, N'5', 5, N'504005001000002000002', N'DEP - CA KO-7322', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C2D5E7 AS DateTime), N'nasooha', CAST(0x0000A48500C8D6D8 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (465, N'5', 5, N'504005001000002000003', N'DEP - CA KR-2444', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C2E82F AS DateTime), N'nasooha', CAST(0x0000A48500C8DB88 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (466, N'5', 5, N'504005001000002000004', N'DEP - CA KV-0077', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C2F72D AS DateTime), N'nasooha', CAST(0x0000A48500C8E164 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (467, N'5', 5, N'504005001000002000005', N'DEP - CA KY-0555', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C304FA AS DateTime), N'nasooha', CAST(0x0000A48500C8E740 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (468, N'5', 5, N'504005001000002000006', N'DEP - CA KX-6321', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C31480 AS DateTime), N'nasooha', CAST(0x0000A48500C8EE48 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (469, N'5', 5, N'504005001000002000007', N'DEP - CA KY-3773', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C3241C AS DateTime), N'nasooha', CAST(0x0000A48500C8F2F8 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (470, N'5', 5, N'504005001000002000008', N'DEP - CA KR-4442', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C33708 AS DateTime), N'nasooha', CAST(0x0000A48500C8F7A8 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (471, N'5', 5, N'504005001000002000009', N'DEP - CA KL-4447', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C34635 AS DateTime), N'nasooha', CAST(0x0000A48500C8FC58 AS DateTime), 0, 2, 0, 0, 454, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (472, N'5', 5, N'504005001000003000001', N'DEP - JP KW-1155', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C35EC2 AS DateTime), N'nasooha', CAST(0x0000A48500C905B8 AS DateTime), 0, 2, 0, 0, 455, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (473, N'5', 5, N'504005001000004000001', N'DEP - LO 227-3323', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C39140 AS DateTime), N'nasooha', CAST(0x0000A48500C90DEC AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (474, N'5', 5, N'504005001000004000002', N'DEP - LO LJ-0216', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C3A063 AS DateTime), N'nasooha', CAST(0x0000A48500C9129C AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (475, N'5', 5, N'504005001000004000003', N'DEP - LO LH-8546', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C3AFF7 AS DateTime), N'nasooha', CAST(0x0000A48500C91878 AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (476, N'5', 5, N'504005001000004000004', N'DEP - LO LK-4847', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C3C017 AS DateTime), N'nasooha', CAST(0x0000A48500C91D28 AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (477, N'5', 5, N'504005001000004000005', N'DEP - LO GK-0467', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C3EB78 AS DateTime), N'nasooha', CAST(0x0000A48500C92A0C AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (478, N'5', 5, N'504005001000004000006', N'DEP - LO LA-8078', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C3F938 AS DateTime), N'nasooha', CAST(0x0000A48500C92EBC AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (479, N'5', 5, N'504005001000004000007', N'DEP - LO LB-9230', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C4091B AS DateTime), N'nasooha', CAST(0x0000A48500C9336C AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (480, N'5', 5, N'504005001000004000008', N'DEP - LO LD-2177', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C41791 AS DateTime), N'nasooha', CAST(0x0000A48500C93CCC AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (481, N'5', 5, N'504005001000004000009', N'DEP - LO LG-0539', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C43FEE AS DateTime), N'nasooha', CAST(0x0000A48500C943D4 AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (482, N'5', 5, N'504005001000004000010', N'DEP - LO LG-0538', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C44F16 AS DateTime), N'nasooha', CAST(0x0000A48500C949B0 AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (483, N'5', 5, N'504005001000004000011', N'DEP - LO LH-6514', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C4614B AS DateTime), N'nasooha', CAST(0x0000A48500C94E60 AS DateTime), 0, 2, 0, 0, 456, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (484, N'5', 5, N'504005001000005000001', N'DEP - MB GE-2612', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C49C08 AS DateTime), N'nasooha', CAST(0x0000A48500C95C70 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (485, N'5', 5, N'504005001000005000002', N'DEP - MB BAR-9927', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C4AEB8 AS DateTime), N'nasooha', CAST(0x0000A48500C96120 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (486, N'5', 5, N'504005001000005000003', N'DEP - MB HQ-3809', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C4C6E7 AS DateTime), N'nasooha', CAST(0x0000A48500C965D0 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (487, N'5', 5, N'504005001000005000004', N'DEP - MB MZ-4069', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C4D890 AS DateTime), N'nasooha', CAST(0x0000A48500C96A80 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (488, N'5', 5, N'504005001000005000005', N'DEP - MB TD-0864', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C4EEE2 AS DateTime), N'nasooha', CAST(0x0000A48500C96F30 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (489, N'5', 5, N'504005001000005000006', N'DEP - MB UD-4194', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C50138 AS DateTime), N'nasooha', CAST(0x0000A48500C973E0 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (490, N'5', 5, N'504005001000005000007', N'DEP - MB UD-5570', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C51365 AS DateTime), N'nasooha', CAST(0x0000A48500C97890 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (491, N'5', 5, N'504005001000005000008', N'DEP - MB UK-7406', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C521DB AS DateTime), N'nasooha', CAST(0x0000A48500C97D40 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (492, N'5', 5, N'504005001000005000009', N'DEP - MB WM-5736', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C53419 AS DateTime), N'nasooha', CAST(0x0000A48500C981F0 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (493, N'5', 5, N'504005001000005000010', N'DEP - MB WM-5743', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C54463 AS DateTime), N'nasooha', CAST(0x0000A48500C986A0 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (494, N'5', 5, N'504005001000005000011', N'DEP - MB XY-2825', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C55214 AS DateTime), N'nasooha', CAST(0x0000A48500C98B50 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (495, N'5', 5, N'504005001000005000012', N'DEP - MB XY-2908', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C55FBC AS DateTime), N'nasooha', CAST(0x0000A48500C99000 AS DateTime), 0, 2, 0, 0, 457, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (496, N'5', 5, N'504005001000006000001', N'DEP - TW YS-7063', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C582F7 AS DateTime), N'nasooha', CAST(0x0000A48500C99A8C AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (497, N'5', 5, N'504005001000006000002', N'DEP - TW YR-6010', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C5939F AS DateTime), N'nasooha', CAST(0x0000A48500C9A068 AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (498, N'5', 5, N'504005001000006000003', N'DEP - TW YT-8721', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C5AD7D AS DateTime), N'nasooha', CAST(0x0000A48500C9A518 AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (499, N'5', 5, N'504005001000006000004', N'DEP - TW YW-3486', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C5D3C9 AS DateTime), N'nasooha', CAST(0x0000A48500C9A9C8 AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (500, N'5', 5, N'504005001000006000005', N'DEP - TW QN-2066', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C61D35 AS DateTime), N'nasooha', CAST(0x0000A48500C9AD4C AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (501, N'5', 5, N'504005001000006000006', N'DEP - TW QN-6434', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C62B64 AS DateTime), N'nasooha', CAST(0x0000A48500C9B328 AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (502, N'5', 5, N'504005001000006000007', N'DEP - TW QX-4334', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C639E3 AS DateTime), N'nasooha', CAST(0x0000A48500C9B7D8 AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (503, N'5', 5, N'504005001000006000008', N'DEP - TW QX-4335', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C646B9 AS DateTime), N'nasooha', CAST(0x0000A48500C9BC88 AS DateTime), 0, 2, 0, 0, 458, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (504, N'5', 5, N'504005001000007000001', N'DEP - VA 252-7676', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C68C03 AS DateTime), N'nasooha', CAST(0x0000A48500C9C840 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (505, N'5', 5, N'504005001000007000002', N'DEP - VA PC-5654', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C69A90 AS DateTime), N'nasooha', CAST(0x0000A48500C9CCF0 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (506, N'5', 5, N'504005001000007000003', N'DEP - VA PC-8726', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C6A891 AS DateTime), N'nasooha', CAST(0x0000A48500C9D1A0 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (507, N'5', 5, N'504005001000007000004', N'DEP - VA PF-0221', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C6B6F9 AS DateTime), N'nasooha', CAST(0x0000A48500C9D650 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (508, N'5', 5, N'504005001000007000005', N'DEP - VA PF-0123', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C6DFAB AS DateTime), N'nasooha', CAST(0x0000A48500C9DB00 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (509, N'5', 5, N'504005001000007000006', N'DEP - VA PF-1130', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C6EF97 AS DateTime), N'nasooha', CAST(0x0000A48500C9DFB0 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (510, N'5', 5, N'504005001000007000007', N'DEP - VA PD-8111', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C6FFBC AS DateTime), N'nasooha', CAST(0x0000A48500C9E460 AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (511, N'5', 5, N'504005001000007000008', N'DEP - VA KX-1234', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C70F09 AS DateTime), N'nasooha', CAST(0x0000A48500C9EA3C AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (512, N'5', 5, N'504005001000007000009', N'DEP - VA HJ-9445', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C7241D AS DateTime), N'nasooha', CAST(0x0000A48500C9EEEC AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (513, N'5', 5, N'504005001000007000010', N'DEP - VA JB-9912', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C73260 AS DateTime), N'nasooha', CAST(0x0000A48500C9F39C AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (514, N'5', 5, N'504005001000007000011', N'DEP - VA PA-3665', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C74E2A AS DateTime), N'nasooha', CAST(0x0000A48500C9F84C AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (515, N'5', 5, N'504005001000007000012', N'DEP - VA PD-9669', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C75CEB AS DateTime), N'nasooha', CAST(0x0000A48500C9FCFC AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (516, N'5', 5, N'504005001000007000013', N'DEP - VA PE-7776', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C76E3F AS DateTime), N'nasooha', CAST(0x0000A48500CA01AC AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (517, N'5', 5, N'504005001000007000014', N'DEP - VA PE-9019', N'', 5, 1, 1, 0, 1, N'nasooha', CAST(0x0000A47400C781DD AS DateTime), N'nasooha', CAST(0x0000A48500CA065C AS DateTime), 0, 2, 0, 0, 459, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (519, N'4', 2, N'403008', N'MISCELLANEOUS INCOME', N'', 4, 2, 0, 0, 1, N'nasooha', CAST(0x0000A47500A69CCD AS DateTime), N'nasooha', CAST(0x0000A47500A69CCD AS DateTime), 1, 2, 0, 1, 155, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (520, N'2', 1, N'213', N'AROWANA POINTS PAYABLE', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A47500AAF5C3 AS DateTime), N'nasooha', CAST(0x0000A47500AAF5C3 AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (521, N'5', 3, N'5030050003', N'DISCOUNTS ISSUED - AROWANA', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A47500AB2FDC AS DateTime), N'nasooha', CAST(0x0000A47500AB2FDC AS DateTime), 0, 2, 0, 1, 250, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (522, N'2', 1, N'214', N'GIFT CARD REDEEMABLE', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A47500B7B879 AS DateTime), N'nasooha', CAST(0x0000A47500B7B879 AS DateTime), 0, 1, 0, 1, 2, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (523, N'1', 2, N'101015', N'OTHER 2', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48200B8DD09 AS DateTime), N'nasooha', CAST(0x0000A48200B8DD09 AS DateTime), 0, 1, 0, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (524, N'1', 2, N'101014', N'OTHER 1', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48200B9C2B1 AS DateTime), N'nasooha', CAST(0x0000A48200B9C2B1 AS DateTime), 0, 1, 0, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (525, N'1', 3, N'1010110001', N'DISPLAY UNITS - COST', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48500AF1EF3 AS DateTime), N'nasooha', CAST(0x0000A48500AF1EF3 AS DateTime), 0, 1, 0, 1, 389, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (526, N'1', 3, N'1010110002', N'DISPLAY UNITS - ACC DEP', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48500B08B85 AS DateTime), N'nasooha', CAST(0x0000A48500B08B85 AS DateTime), 0, 1, 0, 1, 389, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (527, N'1', 3, N'1010120001', N'GENERATORS - COST', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48500B0C6EB AS DateTime), N'nasooha', CAST(0x0000A48500B0C6EB AS DateTime), 0, 1, 0, 1, 390, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (528, N'1', 3, N'1010120002', N'GENERATORS - ACC DEP', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48500B0D4BD AS DateTime), N'nasooha', CAST(0x0000A48500B0D4BD AS DateTime), 0, 1, 0, 1, 390, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (529, N'1', 2, N'101017', N'RENT - REFUNDABLE DEPOSIT', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A48500B99FC7 AS DateTime), N'nasooha', CAST(0x0000A48500B99FC7 AS DateTime), 0, 1, 0, 1, 6, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (535, N'1', 2, N'102014', N'CASH - SALES', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A49500AE1A5B AS DateTime), N'nasooha', CAST(0x0000A49500AE1A5B AS DateTime), 0, 1, 0, 1, 34, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (536, N'5', 3, N'5030010007', N'SIGNAGE & OTHER', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A49500E9626D AS DateTime), N'nasooha', CAST(0x0000A49500E9626D AS DateTime), 0, 2, 0, 1, 226, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (537, N'2', 2, N'210002', N'ACCRUED EXPENSES', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A496010D7722 AS DateTime), N'nasooha', CAST(0x0000A496010D7722 AS DateTime), 0, 1, 0, 1, 293, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (538, N'1', 4, N'101010000700029', N'COST - VA PG-1957', N'TOYOTA HIACE', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A49700E35CBB AS DateTime), N'nasooha', CAST(0x0000A49700E35CBB AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (539, N'1', 4, N'101010000700030', N'ACC DEP - VA PG-1957', N'', 1, 1, 0, 0, 1, N'nasooha', CAST(0x0000A49700E377EA AS DateTime), N'nasooha', CAST(0x0000A49700E377EA AS DateTime), 0, 1, 0, 1, 350, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (540, N'5', 3, N'5020010021', N'OVERTIME', N'', 5, 1, 0, 0, 1, N'NASOOHA', CAST(0x0000A4A400DFA80E AS DateTime), N'NASOOHA', CAST(0x0000A4A400DFA80E AS DateTime), 0, 2, 0, 1, 191, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (541, N'2', 2, N'211022', N'CURRENT ACCOUNT - LOGISTIC', N'', 2, 2, 0, 0, 1, N'nasooha', CAST(0x0000A4C700C12C39 AS DateTime), N'nasooha', CAST(0x0000A4C700C12C39 AS DateTime), 0, 1, 0, 1, 367, 0, 0, N'')
INSERT [dbo].[AccLedgerAccount] ([AccLedgerAccountID], [LedgerType], [TypeLevel], [LedgerCode], [LedgerName], [Remark], [AccountStatus], [StandardDrCr], [IsDelete], [IsUpLoad], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer], [StatementType], [IsLock], [IsActive], [ParentIndex], [BankID], [BankBranchID], [AccountNo]) VALUES (542, N'5', 3, N'5030050004', N'DISCOUNT ISSUED - GC', N'', 5, 1, 0, 0, 1, N'nasooha', CAST(0x0000A4C700EA14FA AS DateTime), N'nasooha', CAST(0x0000A4C700EA14FA AS DateTime), 0, 2, 0, 1, 250, 0, 0, N'')
SET IDENTITY_INSERT [dbo].[AccLedgerAccount] OFF





END



");
            #endregion

            #region Exec Account Table
            ExecuteSqlQuery(@"
            exec [spAccountsTB]
");
            #endregion

            #region Exec customer Table
            ExecuteSqlQuery(@"ALTER TABLE [dbo].[Customer]
        ADD[IsActive][bit] NOT NULL DEFAULT 0
");
            #endregion

            #region   paid in paid out

            ExecuteSqlQuery(@" IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaidInType]') AND type in (N'U'))
DROP TABLE [dbo].[PaidInType] ");

            ExecuteSqlQuery(@"CREATE TABLE [dbo].[PaidInType](
	[PaidInTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](15) NULL,
	[Description] [nvarchar](30) NULL,
	[IsSalesSummery] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[GroupOfCompanyID] [int] NOT NULL,
	[CreatedUser] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedUser] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[DataTransfer] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PaidInType] PRIMARY KEY CLUSTERED 
(
	[PaidInTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


");

            ExecuteSqlQuery(@" IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaidOutType]') AND type in (N'U'))
DROP TABLE [dbo].[PaidOutType] ");

            ExecuteSqlQuery(@"CREATE TABLE [dbo].[PaidOutType](
	[PaidOutTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](15) NULL,
	[Description] [nvarchar](30) NULL,
	[IsSalesSummery] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[DayFrom] [int] NOT NULL,
	[DayTo] [int] NOT NULL,
	[GroupOfCompanyID] [int] NOT NULL,
	[CreatedUser] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedUser] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[DataTransfer] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PaidOutType] PRIMARY KEY CLUSTERED 
(
	[PaidOutTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

"); 


            ExecuteSqlQuery(@"  TRUNCATE TABLE PaidOutType
 
");
            ExecuteSqlQuery(@"  TRUNCATE TABLE PaidInType
 
");


            ExecuteSqlQuery(@" SET IDENTITY_INSERT [dbo].[PaidOutType] ON
INSERT [dbo].[PaidOutType] ([PaidOutTypeID], [Code], [Description], [IsSalesSummery], [IsDelete], [DayFrom], [DayTo], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (1, N'001', N'Paid Out', 1, 0, 1, 31, 1, N'admin', CAST(0x0000A5B600000000 AS DateTime), N'admin', CAST(0x0000A5B600000000 AS DateTime), 0)
INSERT [dbo].[PaidOutType] ([PaidOutTypeID], [Code], [Description], [IsSalesSummery], [IsDelete], [DayFrom], [DayTo], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (2, N'002', N'Bank Deposit', 1, 0, 1, 31, 1, N'admin', CAST(0x0000A5B600000000 AS DateTime), N'admin', CAST(0x0000A5B600000000 AS DateTime), 0)
INSERT [dbo].[PaidOutType] ([PaidOutTypeID], [Code], [Description], [IsSalesSummery], [IsDelete], [DayFrom], [DayTo], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (3, N'003', N'Salary Advance', 1, 0, 1, 31, 1, N'admin', CAST(0x0000A5B600000000 AS DateTime), N'admin', CAST(0x0000A5B600000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[PaidOutType] OFF
");
            ExecuteSqlQuery(@" SET IDENTITY_INSERT [dbo].[PaidInType] ON
INSERT [dbo].[PaidInType] ([PaidInTypeID], [Code], [Description], [IsSalesSummery], [IsDelete], [GroupOfCompanyID], [CreatedUser], [CreatedDate], [ModifiedUser], [ModifiedDate], [DataTransfer]) VALUES (1, N'001', N'Paid In', 1, 0, 1, N'admin', CAST(0x0000A5B600000000 AS DateTime), N'admin', CAST(0x0000A5B600000000 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[PaidInType] OFF
");


            #endregion

            #region Exec LoyaltyCustomer
            ExecuteSqlQuery(@"ALTER TABLE [dbo].[LoyaltyCustomer] ADD [Discount] [decimal](18, 2) NOT NULL DEFAULT 0
");
            #endregion

            #region Exec TransactionDet
            ExecuteSqlQuery(@"ALTER TABLE [dbo].[TransactionDet] ADD [InvPriceLevelID] [bigint] NOT NULL DEFAULT 0

");
            #endregion

            #region Exec TransactionDet
            ExecuteSqlQuery(@"ALTER TABLE [dbo].[TransactionDet] ADD [InvPriceLevelID] [bigint] NOT NULL DEFAULT 0

");
            #endregion

            #region Exec SystemFeature
            ExecuteSqlQuery(@"ALTER TABLE[dbo].[SystemFeature] ADD[IsPriceLevel][bit] NOT NULL DEFAULT 0

");
            #endregion

            #region Exec spSupplierMovement

            ExecuteSqlQuery(@"  DROP PROCEDURE [dbo].[spSupplierMovement]");

            ExecuteSqlQuery(@" CREATE PROCEDURE [dbo].[spSupplierMovement]
    @UserId BIGINT ,
    @DateFrom DATE ,
    @DateTo DATE ,
    @SupplierID BIGINT
AS 
    BEGIN
        DECLARE @RecCount BIGINT ,
            @StrSql VARCHAR(MAX) ,
            @CDateFrom DATE ,
            @CDateTo DATE ,
            @Ext1 INT ,
            @Ext2 INT ,
            @Ext3 INT ,
            @Ext4 INT ,
            @Ext5 INT



        BEGIN TRANSACTION InProc

        SET @CDateFrom = CAST(@DateFrom AS DATE)
        SET @CDateTo = CAST(@DateTo AS DATE)

        --SET @CDateFrom = CONVERT(VARCHAR(10), @DateFrom, 111)
        --SET @CDateTo = CONVERT(VARCHAR(10), @DateTo, 111)



        --SET @RecCount = (SELECT    ISNULL(COUNT(UserID), 0)
        --                  FROM InvTmpReportDetail
        --                  WHERE UserID<> @UserId
        --                )
        --IF(@RecCount = 0)
        --    BEGIN
        TRUNCATE TABLE InvTmpReportDetail



        --    END
        --ELSE
        --    BEGIN
        --        DELETE FROM dbo.InvTmpReportDetail
        --        WHERE UserID = @UserId
        --    END



        IF ( @SupplierID != 0 ) 
            BEGIN
                INSERT  INTO dbo.InvTmpReportDetail ( CompanyID, LocationID,
                                                      UserID, DocumentDate,
                                                      DocumentNo, UnitNo, ZNo,
                                                      CustomerID, CustomerCode,
                                                      CustomerName, SupplierID,
                                                      SupplierCode,
                                                      SupplierName, ProductID,
                                                      ProductCode, ProductName,
                                                      DepartmentID,
                                                      DepartmentCode,
                                                      DepartmentName,
                                                      CategoryID, CategoryCode,
                                                      CategoryName,
                                                      SubCategoryID,
                                                      SubCategoryCode,
                                                      SubCategoryName,
                                                      SubCategory2ID,
                                                      SubCategory2Code,
                                                      SubCategory2Name,
                                                      BatchNo, CostPrice,
                                                      SellingPrice,
                                                      AverageCost, GrossProfit,
                                                      Qty01, Value01, Qty02,
                                                      Value02, Qty03, Value03,
                                                      Qty04, Value04, Qty05,
                                                      Value05, Qty06, Value06,
                                                      Qty07, Value07, Qty08,
                                                      Value08, Qty09, Value09,
                                                      Qty10, Value10, Qty11,
                                                      Value11, Qty12, Value12,
                                                      Qty13, Value13, Qty14,
                                                      Value14, Qty15, Value15,
                                                      Qty16, Value16, Qty17,
                                                      Value17, Qty18, Value18,
                                                      Qty19, Value19, Qty20,
                                                      Value20, Qty21, Value21,
                                                      Qty22, Value22, Qty23,
                                                      Value23, Qty24, Value24,
                                                      Qty25, Value25, Qty26,
                                                      Value26, Qty27, Value27,
                                                      Qty28, Value28, Qty29,
                                                      Value29, Qty30, Value30,
                                                      GroupOfCompanyID,
                                                      CreatedUser, CreatedDate,
                                                      ModifiedUser,
                                                      ModifiedDate,
                                                      DataTransfer )
                        ( SELECT    0, 0, @UserId, GETDATE(), '', 0, 0, 0, '',
                                    '', H.SupplierID, '', '',
                                    InvProductMasterID, ProductCode,
                                    ProductName, DepartmentID, '', '',
                                    CategoryID, '', '', SubCategoryID, '', '',
                                    SubCategory2ID, '', '', '',
                                    MAX(p.CostPrice), MAX(p.SellingPrice),
                                    MAX(p.AverageCost), 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '''',
                                    GETDATE(), '''', GETDATE(), 0
                          FROM      dbo.InvProductMaster p
                                    INNER JOIN InvPurchaseDetail D ON P.InvProductMasterID = D.ProductID
                                    INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                          WHERE     H.SupplierID = @SupplierID AND CAST(h.DocumentDate AS DATE) BETWEEN @CDateFrom AND @CDateTo
                          GROUP BY  ProductID, ProductCode, InvProductMasterID,
                                    ProductName, DepartmentID, CategoryID,
                                    SubCategoryID, SubCategory2ID,
                                    h.SupplierID)
            END

        ELSE 
            BEGIN

                INSERT  INTO dbo.InvTmpReportDetail ( CompanyID, LocationID,
                                                      UserID, DocumentDate,
                                                      DocumentNo, UnitNo, ZNo,
                                                      CustomerID, CustomerCode,
                                                      CustomerName, SupplierID,
                                                      SupplierCode,
                                                      SupplierName, ProductID,
                                                      ProductCode, ProductName,
                                                      DepartmentID,
                                                      DepartmentCode,
                                                      DepartmentName,
                                                      CategoryID, CategoryCode,
                                                      CategoryName,
                                                      SubCategoryID,
                                                      SubCategoryCode,
                                                      SubCategoryName,
                                                      SubCategory2ID,
                                                      SubCategory2Code,
                                                      SubCategory2Name,
                                                      BatchNo, CostPrice,
                                                      SellingPrice,
                                                      AverageCost, GrossProfit,
                                                      Qty01, Value01, Qty02,
                                                      Value02, Qty03, Value03,
                                                      Qty04, Value04, Qty05,
                                                      Value05, Qty06, Value06,
                                                      Qty07, Value07, Qty08,
                                                      Value08, Qty09, Value09,
                                                      Qty10, Value10, Qty11,
                                                      Value11, Qty12, Value12,
                                                      Qty13, Value13, Qty14,
                                                      Value14, Qty15, Value15,
                                                      Qty16, Value16, Qty17,
                                                      Value17, Qty18, Value18,
                                                      Qty19, Value19, Qty20,
                                                      Value20, Qty21, Value21,
                                                      Qty22, Value22, Qty23,
                                                      Value23, Qty24, Value24,
                                                      Qty25, Value25, Qty26,
                                                      Value26, Qty27, Value27,
                                                      Qty28, Value28, Qty29,
                                                      Value29, Qty30, Value30,
                                                      GroupOfCompanyID,
                                                      CreatedUser, CreatedDate,
                                                      ModifiedUser,
                                                      ModifiedDate,
                                                      DataTransfer )
                        ( SELECT    0, 0, @UserId, GETDATE(), '', 0, 0, 0, '',
                                    '', H.SupplierID, '', '',
                                    InvProductMasterID, ProductCode,
                                    ProductName, DepartmentID, '', '',
                                    CategoryID, '', '', SubCategoryID, '', '',
                                    SubCategory2ID, '', '', '',
                                    MAX(p.CostPrice), MAX(p.SellingPrice),
                                    MAX(p.AverageCost), 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '''',
                                    GETDATE(), '''', GETDATE(), 0
                          FROM      dbo.InvProductMaster p
                                    INNER JOIN InvPurchaseDetail D ON P.InvProductMasterID = D.ProductID
                                    INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                                    WHERE   CAST(h.DocumentDate AS DATE) BETWEEN @CDateFrom AND @CDateTo

                          GROUP BY  ProductID, ProductCode, InvProductMasterID,
                                    ProductName, DepartmentID, CategoryID,
                                    SubCategoryID, SubCategory2ID,
                                    h.SupplierID)
            END

                -- UPDATE DEPARTMENT
        UPDATE  b
        SET     b.DepartmentCode = T.DepartmentCode,
                b.DepartmentName = T.DepartmentName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvDepartment t ( NOLOCK ) ON b.DepartmentID = t.InvDepartmentID

                         -- UPDATE CATEGORY

        UPDATE  b
        SET     b.CategoryCode = T.CategoryCode,
                b.CategoryName = T.CategoryName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvCategory t ( NOLOCK ) ON b.CategoryID = t.InvCategoryID

                         -- UPDATE SUBCATEGORY


        UPDATE  b
        SET     b.SubCategoryCode = T.SubCategoryCode,
                b.SubCategoryName = T.SubCategoryName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvSubCategory t ( NOLOCK ) ON b.SubCategoryID = t.InvSubCategoryID

                        -- UPDATE SUBCATEGORY2

        UPDATE  b
        SET     b.SubCategory2Code = T.SubCategory2Code,
                b.SubCategory2Name = T.SubCategory2Name
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvSubCategory2 t ( NOLOCK ) ON b.SubCategory2ID = t.InvSubCategory2ID

				-- UPDATE Supplier

        UPDATE  b
        SET     b.SupplierCode = T.SupplierCode,
                b.SupplierName = T.SupplierName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN dbo.Supplier t ( NOLOCK ) ON b.SupplierID = t.SupplierID
                --AND SupplierID IN (SELECT SupplierID)
                --         FROM @Sup )


  
 
----------------Qty01 - VALUE01 - TOTAL PURCHASE  QTY

;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY,
                                ISNULL(SUM(D.NetAmount), 0) VALUE, ProductID,
                                SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1502
                                AND h.DocumentStatus = 1
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                       GROUP BY d.ProductID, h.SupplierID)
            UPDATE  t
            SET     Qty01 = cte.QTY, Value01 = cte.VALUE
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID


----------------Qty02 - VALUE02 - TOTAL PURCHASE RETURN
;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY,
                                ISNULL(SUM(D.NetAmount), 0) VALUE, ProductID,
                                SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1503
                                AND h.DocumentStatus = 1
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                       GROUP BY ProductID, SupplierID)
            UPDATE  t
            SET     Qty02 = cte.QTY, Value02 = cte.VALUE
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID

-- TOTOAL NET PURCHASE

        UPDATE  dbo.InvTmpReportDetail
        SET     Qty03 = Qty01 - Qty02, Value03 = Value01 - Value02


-- STOCK - stores - qty 4
        DECLARE @HOLOCATIONID INT
        SET @HOLOCATIONID = ( SELECT    LocationID
                              FROM      dbo.Location
                              WHERE     IsHeadOffice = 1 );
        WITH    temp
                  AS ( SELECT   td.ProductID,
                                ISNULL(SUM(td.Stock), 0) AS stock,
                                ISNULL(SUM(td.Stock
                                           * dbo.InvTmpReportDetail.CostPrice),
                                       0) AS CostValue
                       FROM     dbo.InvProductStockMaster td
                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                       WHERE    td.IsDelete = 0
                                AND td.LocationID = @HOLOCATIONID
                       GROUP BY td.ProductID)
            UPDATE  b
            SET     b.Qty04 = ISNULL(T.Stock, 0),
                    b.Value05 = ISNULL(T.CostValue, 0)
            FROM    InvTmpReportDetail b
                    INNER JOIN temp t ON b.ProductID = t.ProductID


-- OUTLET ISUED



;
        WITH    temp
                  AS ( SELECT   td.ProductID,
                                ISNULL(SUM(td.OrderQty), 0) AS Qty,
                                ISNULL(SUM(td.NetAmount), 0) AS Value
                       FROM     dbo.InvTransferNoteDetail td
                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                                INNER JOIN dbo.InvTransferNoteHeader th ON td.TransferNoteHeaderID = th.InvTransferNoteHeaderID
                       WHERE    th.DocumentStatus = 1
                                AND th.LocationID = @HOLOCATIONID
                                 AND CAST(th.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                       GROUP BY td.ProductID)
            UPDATE  b
            SET     b.Qty05 = ISNULL(T.Qty, 0), Value04 = ISNULL(T.Value, 0)
            FROM    InvTmpReportDetail b
                    INNER JOIN temp t ON b.ProductID = t.ProductID


-- SIH - outlet store + sales outled

;
        WITH    temp
                  AS ( SELECT   td.ProductID,
                                ISNULL(SUM(td.Stock), 0) AS stock,
                                ISNULL(SUM(td.Stock
                                           * dbo.InvTmpReportDetail.CostPrice),
                                       0) AS CostValue
                       FROM     dbo.InvProductStockMaster td
                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                       WHERE    td.IsDelete = 0
                                AND td.LocationID != @HOLOCATIONID
                       GROUP BY td.ProductID)
            UPDATE  b
            SET     b.Qty06 = ISNULL(T.Stock, 0),
                    b.Value06 = ISNULL(T.CostValue, 0)
            FROM    InvTmpReportDetail b
                    INNER JOIN temp t ON b.ProductID = t.ProductID



 -- sales 
;
        WITH    temp
                  AS ( SELECT   td.ProductID,
                                ISNULL(SUM(CASE WHEN DocumentID = 1
                                                THEN td.Qty
                                                WHEN DocumentID = 3
                                                THEN td.Qty
                                           END), 0) SALES,
                                SUM(CASE WHEN DocumentID = 2 THEN td.Qty
                                         WHEN DocumentID = 4 THEN td.Qty
                                    END) SALESRETURN
                       FROM     TransactionDet td
                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                       WHERE    [Status] = 1
                                AND TransStatus = 1
                                AND BillTypeID = 1
                                AND SaleTypeID = 1
                                AND CAST(td.RecDate AS DATE) BETWEEN @DateFrom
                                                             AND
                                                              @DateTo
                       GROUP BY td.ProductID)
            UPDATE  b
            SET     b.Qty07 = ISNULL(t.SALES, 0),
                    b.Qty08 = ISNULL(t.SALESRETURN, 0),
                    b.Qty09 = ISNULL(t.SALES, 0) - ISNULL(t.SALESRETURN, 0),
                    b.Value07 = ( ( ISNULL(t.SALES, 0) - ISNULL(t.SALESRETURN,
                                                              0) )
                                  * b.CostPrice ),
                    b.Value08 = ( ( ISNULL(t.SALES, 0) - ISNULL(t.SALESRETURN,
                                                              0) )
                                  * b.SellingPrice )
            FROM    InvTmpReportDetail b
                    INNER JOIN temp t ON b.ProductID = t.ProductID
                            
-- *****                         
        UPDATE  dbo.InvTmpReportDetail
        SET     Value09 = Value08 - Value07,
                value10 = ( ( Value08 - Value07 )
                            / ( CASE WHEN Value07 = 0 THEN 1
                                     ELSE Value07
                                END ) ) * 100
 
 

        DELETE  FROM InvTmpReportDetail
        WHERE   ( Qty01 = 0
                  AND Qty02 = 0
                  AND Qty03 = 0
                  AND Qty04 = 0
                  AND Qty05 = 0
                  AND Qty06 = 0
                  AND Qty07 = 0
                  AND Qty08 = 0
                  AND Qty09 = 0
                  AND Qty10 = 0
                  AND Qty11 = 0
                  AND Qty12 = 0
                  AND Qty13 = 0
                  AND Qty14 = 0
                )

        IF @@TRANCOUNT > 0 
            BEGIN
                COMMIT TRANSACTION InProc;
                SELECT  1 AS Result
            END
        ELSE 
            BEGIN
                SELECT  0 AS Result
            END
    END



");
            #endregion

            #region Exec spStockMovement

            ExecuteSqlQuery(@" DROP PROCEDURE[dbo].[spStockMovement]; 
");

            ExecuteSqlQuery(@"
Create PROCEDURE [dbo].[spStockMovement]

--exec spStockAging 1,1,'2014-01-01','2014-01-01','2014-01-30',1,'110100450015','110100450015',1,1,'Admin'
    @CompanyId INT ,
    @SelectedLocationID INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @GivenDate DATETIME ,
    @TypeId INT ,
    @StockId INT ,
    @FromCode VARCHAR(20) ,
    @ToCode VARCHAR(20) ,
    @UserId BIGINT ,
    @UniqueId BIGINT ,
    @CreatedUser VARCHAR(30)
AS 
    DECLARE @FromId BIGINT ,
        @ToId BIGINT ,
        @LocationId INT
		


    BEGIN
	 
	
        BEGIN TRANSACTION InProc

        IF EXISTS ( SELECT  *
                    FROM    sys.objects
                    WHERE   object_id = OBJECT_ID(N'[dbo].#tempProduct')
                            AND type IN ( N'U' ) ) 
            DROP TABLE #tempProduct
		
        CREATE TABLE #tempProduct
            (
              [ProductID] [bigint] NOT NULL ,
              [ProductCode] [nvarchar](25) NULL ,
              [ProductName] [nvarchar](100) NULL ,
              [CostPrice] [decimal](18, 0) ,
              [SellingPrice] [decimal](18, 0)
            )
	
        IF EXISTS ( SELECT  *
                    FROM    sys.objects
                    WHERE   object_id = OBJECT_ID(N'[dbo].#tempCurrentStock')
                            AND type IN ( N'U' ) ) 
            DROP TABLE #tempCurrentStock
		
        CREATE TABLE #tempCurrentStock
            (
              [LocationID] [bigint] NOT NULL ,
              [ProductID] [bigint] NOT NULL ,
              [BatchNo] [nvarchar](25) NULL ,
              [Qty] [decimal](18, 0) NOT NULL
            )
	
	
	
        INSERT  INTO #tempProduct
                ( ProductID ,
                  ProductCode ,
                  ProductName ,
                  CostPrice ,
                  SellingPrice
                )
                SELECT  InvProductMasterID ,
                        ProductCode ,
                        ProductName ,
                        CostPrice ,
                        SellingPrice
                FROM    InvProductMaster
                WHERE   ProductCode BETWEEN @FromCode AND @ToCode

        DELETE  FROM InvTmpProductStockDetails
        WHERE   UserId = @UserId
	
        IF ( @TypeId = 6 ) 
            BEGIN
	
	
                INSERT  INTO InvTmpProductStockDetails
                        ( ProductCode ,
                          ProductName ,
                          CostPrice ,
                          SellingPrice ,
                          StockQty ,
                          GrossProfit ,
                          GroupOfCompanyID ,
                          CompanyID ,
                          LocationID ,
                          GivenDate ,
                          TransactionDate ,
                          TransactionNo ,
                          TransactionType ,
                          ProductID ,
                          DepartmentID ,
                          CategoryID ,
                          SubCategoryID ,
                          SubCategory2ID ,
                          SupplierID ,
                          CustomerID,
                          IsDelete ,
                          CreatedDate ,
                          CreatedUser ,
                          ModifiedDate ,
                          ModifiedUser ,
                          UniqueID ,
                          UserID ,
                          DataTransfer,
                          AverageCost,
                          Amount,
                          Qty1,
                          Qty2,
                          Qty3,
                          Qty4,
                          Qty5,
                          Qty6,
                          Qty7,
                          Qty8,
                          Qty9,
                          Qty10
                        )
                        SELECT  tp.ProductCode ,
                                tp.ProductName ,
                                tp.CostPrice ,
                                tp.SellingPrice ,
                                0 ,
                                0 ,
                                1 ,
                                1 ,
                                @SelectedLocationID ,
                                GETDATE() ,
                                GETDATE() ,
                                0 ,
                                0 ,
                                1 ,
                                1 ,
                                1 ,
                                1 ,
                                1 ,
                                0 ,
                                0,
                                0,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                @CreatedUser ,
                                1 ,
                                @UserId ,
                                0,
                                pm.AverageCost as AverageCost,
                                0 as Amount,
                                0 as Qty1,
                                0 as Qty2,
                                0 as Qty3,
                                0 as Qty4,
                                0 as Qty5,
                                0 as Qty6,
                                0 as Qty7,
                                0 as Qty8,
                                0 as Qty9,
                                0 as Qty10
                        FROM    #tempProduct tp
                        INNER JOIN InvProductMaster pm ON tp.ProductID = pm.InvProductMasterID
                        WHERE   tp.ProductID NOT IN (
                                SELECT  s.ProductID
                                FROM    InvSales s
                                WHERE   s.LocationID = @SelectedLocationID
                                        AND ( s.ProductCode BETWEEN @FromCode AND @ToCode )
                                        AND s.DocumentID IN ( 1, 2, 3, 4 )
                                        AND ( CAST(s.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate ) )
    
    
            END
	 IF ( @TypeId = 7 ) 
            BEGIN
	
	
                INSERT  INTO InvTmpProductStockDetails
                        ( ProductCode ,
                          ProductName ,
                          CostPrice ,
                          SellingPrice ,
                          StockQty ,
                          GrossProfit ,
                          GroupOfCompanyID ,
                          CompanyID ,
                          LocationID ,
                          GivenDate ,
                          TransactionDate ,
                          TransactionNo ,
                          TransactionType ,
                          ProductID ,
                          DepartmentID ,
                          CategoryID ,
                          SubCategoryID ,
                          SubCategory2ID ,
                          SupplierID ,
                          CustomerID,
                          IsDelete ,
                          CreatedDate ,
                          CreatedUser ,
                          ModifiedDate ,
                          ModifiedUser ,
                          UniqueID ,
                          UserID ,
                          DataTransfer,
                          AverageCost,
                          Amount,
                          Qty1,
                          Qty2,
                          Qty3,
                          Qty4,
                          Qty5,
                          Qty6,
                          Qty7,
                          Qty8,
                          Qty9,
                          Qty10
                        )
                        SELECT  tp.ProductCode ,
                                tp.ProductName ,
                                tp.CostPrice ,
                                tp.SellingPrice ,
                                0 ,
                                0 ,
                                1 ,
                                1 ,
                                @SelectedLocationID ,
                                GETDATE() ,
                                GETDATE() ,
                                0 ,
                                0 ,
                                1 ,
                                1 ,
                                1 ,
                                1 ,
                                1 ,
                                0 ,
                                0,
                                0,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                @CreatedUser ,
                                1 ,
                                @UserId ,
                                0,
                                pm.AverageCost as AverageCost,
                                0 as Amount,
                                pm.ReOrderLevel as Qty1,
                                pm.ReOrderPeriod as Qty2,
                                pm.ReOrderQty as Qty3,
                                st.Stock as Qty4,
                                0 as Qty5,
                                0 as Qty6,
                                0 as Qty7,
                                0 as Qty8,
                                0 as Qty9,
                                0 as Qty10
                        FROM    #tempProduct tp
                        INNER JOIN InvProductMaster pm ON tp.ProductID = pm.InvProductMasterID
                        INNER JOIN dbo.InvProductStockMaster st ON pm.InvProductMasterID = st.ProductID 
                        WHERE  pm.ReOrderLevel<= st.Stock AND st.LocationID = @SelectedLocationID

            END
        ELSE 
            BEGIN	
	
                INSERT  INTO InvTmpProductStockDetails
                        ( ProductCode ,
                          ProductName ,
                          BatchNo ,
                          CostPrice ,
                          SellingPrice ,
                          StockQty ,
                          GrossProfit ,
                          GroupOfCompanyID ,
                          CompanyID ,
                          LocationID ,
                          GivenDate ,
                          TransactionDate ,
                          TransactionNo ,
                          TransactionType ,
                          ProductID ,
                          DepartmentID ,
                          CategoryID ,
                          SubCategoryID ,
                          SubCategory2ID ,
                          SupplierID ,
                          CustomerID,
                          IsDelete ,
                          CreatedDate ,
                          CreatedUser ,
                          ModifiedDate ,
                          ModifiedUser ,
                          UniqueID ,
                          UserID ,
                          DataTransfer,
                          AverageCost,
                          Amount,
                          Qty1,
                          Qty2,
                          Qty3,
                          Qty4,
                          Qty5,
                          Qty6,
                          Qty7,
                          Qty8,
                          Qty9,
                          Qty10
                        )
                        SELECT  s.ProductCode ,
                                s.ProductName ,
                                s.BatchNo ,
                                s.CostPrice ,
                                s.SellingPrice ,
                                SUM(( CASE s.DocumentId
                                        WHEN '1' THEN s.Qty
                                        WHEN '2' THEN -s.Qty
                                        WHEN '3' THEN s.Qty
                                        WHEN '4' THEN -s.Qty
                                        ELSE 0
                                      END )) AS Qty ,
                                SUM(( s.SellingPrice * ( CASE s.DocumentId
                                                           WHEN '1' THEN s.Qty
                                                           WHEN '2'
                                                           THEN -s.Qty
                                                           WHEN '3' THEN s.Qty
                                                           WHEN '4'
                                                           THEN -s.Qty
                                                           ELSE 0
                                                         END ) )
                                    - ( s.CostPrice * ( CASE s.DocumentId
                                                          WHEN '1' THEN s.Qty
                                                          WHEN '2' THEN -s.Qty
                                                          WHEN '3' THEN s.Qty
                                                          WHEN '4' THEN -s.Qty
                                                          ELSE 0
                                                        END ) )) AS Gp ,
                                1 ,
                                1 ,
                                s.LocationID ,
                                GETDATE() ,
                                GETDATE() ,
                                0 ,
                                0 ,
                                s.ProductID ,
                                1 ,
                                1 ,
                                1 ,
                                1 ,
                                0 ,
                                0 ,
                                0 ,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                @CreatedUser ,
                                1 ,
                                @UserId ,
                                0,
                                pm.AverageCost as AverageCost,
                                0 as Amount,
                                0 as Qty1,
                                0 as Qty2,
                                0 as Qty3,
                                0 as Qty4,
                                0 as Qty5,
                                0 as Qty6,
                                0 as Qty7,
                                0 as Qty8,
                                0 as Qty9,
                                0 as Qty10
                        FROM    InvSales s
                        INNER JOIN InvProductMaster pm ON s.ProductID = pm.InvProductMasterID
                        WHERE   s.LocationID = @SelectedLocationID
                                AND s.DocumentStatus = 1
                                AND s.DocumentID IN ( 1, 2, 3, 4 )
                                AND s.ProductCode BETWEEN @FromCode AND @ToCode
                                AND ( CAST(s.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate )
                        GROUP BY s.ProductId ,
                                s.ProductCode ,
                                s.ProductName ,
                                s.CostPrice ,
                                s.SellingPrice ,
                                s.LocationID ,
                                s.BatchNo,
                                pm.AverageCost
			
			
                IF ( @StockId = 1 ) 
                    BEGIN	
			
			---Opening Stock (As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  sd.LocationID ,
                                        sd.ProductID ,
                                        sd.BatchNo ,
                                        SUM(sd.OrderQty)
                                FROM    OpeningStockDetail sd
                                        INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                                        INNER JOIN #tempProduct tp ON tp.ProductID = sd.ProductID
                                WHERE   sd.DocumentStatus = 1
                                        AND sh.OpeningStockType = 1
                                        AND sd.DocumentID = 503
                                        AND sd.LocationID = @SelectedLocationID
                                        AND ( CAST(sd.DocumentDate AS DATE) <= @FromDate )
                                GROUP BY sd.LocationID ,
                                        sd.ProductID ,
                                        sd.BatchNo


			--GRN & Purchase Returns (As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  pd.LocationID ,
                                        pd.ProductID ,
                                        pd.BatchNo ,
                                        SUM(CASE pd.DocumentID
                                              WHEN 1502
                                              THEN ( pd.Qty + pd.FreeQty )
                                              WHEN 1503
                                              THEN -( pd.Qty + pd.FreeQty )
                                              ELSE 0
                                            END) AS QTY
                                FROM    InvPurchaseDetail pd
                                        INNER JOIN #tempProduct tp ON tp.ProductID = pd.ProductID
                                WHERE   pd.DocumentStatus = 1
                                        AND ( pd.DocumentID IN ( 1502, 1503 ) )
                                        AND pd.LocationID = @SelectedLocationID
                                        AND ( CAST(pd.CreatedDate AS DATE) <= @FromDate )
                                        AND pd.ProductID BETWEEN @FromId AND @ToId
                                GROUP BY pd.LocationID ,
                                        pd.ProductID ,
                                        pd.BatchNo


			--TOG IN (As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  td.ToLocationID ,
                                        td.ProductID ,
                                        td.BatchNo ,
                                        SUM(td.Qty)
                                FROM    InvTransferNoteDetail td
                                        INNER JOIN #tempProduct tp ON tp.ProductID = td.ProductID
                                WHERE   td.DocumentStatus = 1
                                        AND td.DocumentID = 1504
                                        AND td.ToLocationID = @SelectedLocationID
                                        AND ( CAST(td.DocumentDate AS DATE) <= @FromDate )
                                        AND td.ProductID BETWEEN @FromId AND @ToId
                                GROUP BY td.ToLocationID ,
                                        td.ProductID ,
                                        td.BatchNo
					
					
			--TOG OUT (As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  td.LocationID ,
                                        td.ProductID ,
                                        td.BatchNo ,
                                        ( SUM(td.Qty) * -1 )
                                FROM    InvTransferNoteDetail td
                                        INNER JOIN #tempProduct tp ON tp.ProductID = td.ProductID
                                WHERE   td.DocumentStatus = 1
                                        AND td.DocumentID = 1504
                                        AND td.LocationID = @SelectedLocationID
                                        AND ( CAST(td.DocumentDate AS DATE) <= @FromDate )
                                        AND td.ProductID BETWEEN @FromId AND @ToId
                                GROUP BY td.LocationID ,
                                        td.ProductID ,
                                        td.BatchNo	
				
			--Stock Adjustment (ADD) (As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  ad.LocationID ,
                                        ad.ProductID ,
                                        ad.BatchNo ,
                                        SUM(ad.ExcessQty)
                                FROM    InvStockAdjustmentDetail ad
                                        INNER JOIN #tempProduct tp ON tp.ProductID = ad.ProductID
                                WHERE   ad.DocumentStatus = 1
                                        AND ad.DocumentID = 1505
                                        AND ad.StockAdjustmentMode = 1
                                        AND ad.LocationID = @SelectedLocationID
                                        AND ( CAST(ad.DocumentDate AS DATE) <= @FromDate )
                                        AND ad.ProductID BETWEEN @FromId AND @ToId
                                GROUP BY ad.LocationID ,
                                        ad.ProductID ,
                                        ad.BatchNo
				
			--Stock Adjustment (REDUSE) (As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  ad.LocationID ,
                                        ad.ProductID ,
                                        ad.BatchNo ,
                                        ( SUM(ad.ShortageQty) * -1 )
                                FROM    InvStockAdjustmentDetail ad
                                        INNER JOIN #tempProduct tp ON tp.ProductID = ad.ProductID
                                WHERE   ad.DocumentStatus = 1
                                        AND ad.DocumentID = 1505
                                        AND ad.StockAdjustmentMode = 2
                                        AND ad.LocationID = @SelectedLocationID
                                        AND ( CAST(ad.DocumentDate AS DATE) <= @FromDate )
                                        AND ad.ProductID BETWEEN @FromId AND @ToId
                                GROUP BY ad.LocationID ,
                                        ad.ProductID ,
                                        ad.BatchNo
				
			--Sales & Returns	(As @ FromDate)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  td.LocationID ,
                                        td.ProductID ,
                                        td.BatchNo ,
                                        SUM(CASE DocumentID
                                              WHEN 1 THEN -Qty
                                              WHEN 3 THEN -Qty
                                              WHEN 2 THEN Qty
                                              WHEN 4 THEN Qty
                                              ELSE 0
                                            END)
                                FROM    TransactionDet td
                                WHERE   [Status] = 1
                                        AND TransStatus = 1
                                        AND td.LocationID = @SelectedLocationID
                                        AND ( DocumentID IN ( 1, 2, 3, 4 ) )
                                        AND ( CAST(td.RecDate AS DATE) <= @FromDate )
                                        AND td.ProductCode BETWEEN @FromCode AND @ToCode
                                GROUP BY td.LocationID ,
                                        td.ProductID ,
                                        td.BatchNo
				
			---Opening Stock (From Date - To Date)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  sd.LocationID ,
                                        sd.ProductID ,
                                        sd.BatchNo ,
                                        SUM(sd.OrderQty)
                                FROM    OpeningStockDetail sd
                                        INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                                        INNER JOIN #tempProduct tp ON tp.ProductID = sd.ProductID
                                WHERE   sd.DocumentStatus = 1
                                        AND sh.OpeningStockType = 1
                                        AND sd.DocumentID = 503
                                        AND sd.LocationID = @SelectedLocationID
                                        AND ( CAST(sd.DocumentDate AS DATE) <= @ToDate )
                                        AND ( CAST(sd.DocumentDate AS DATE) > @FromDate )
                                GROUP BY sd.LocationID ,
                                        sd.ProductID ,
                                        sd.BatchNo


			--GRN (From Date - To Date)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  pd.LocationID ,
                                        pd.ProductID ,
                                        pd.BatchNo ,
                                        SUM(pd.Qty + pd.FreeQty) AS QTY
                                FROM    InvPurchaseDetail pd
                                        INNER JOIN #tempProduct tp ON tp.ProductID = pd.ProductID
                                WHERE   pd.DocumentStatus = 1
                                        AND pd.DocumentID = 1502
                                        AND pd.LocationID = @SelectedLocationID
                                        AND ( CAST(pd.CreatedDate AS DATE) <= @ToDate )
                                        AND pd.ProductID BETWEEN @FromId AND @ToId
                                        AND ( CAST(pd.CreatedDate AS DATE) > @FromDate )
                                GROUP BY pd.LocationID ,
                                        pd.ProductID ,
                                        pd.BatchNo


			--TOG IN (From Date - To Date)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  td.ToLocationID ,
                                        td.ProductID ,
                                        td.BatchNo ,
                                        SUM(td.Qty)
                                FROM    InvTransferNoteDetail td
                                        INNER JOIN #tempProduct tp ON tp.ProductID = td.ProductID
                                WHERE   td.DocumentStatus = 1
                                        AND td.DocumentID = 1504
                                        AND td.ToLocationID = @SelectedLocationID
                                        AND ( CAST(td.DocumentDate AS DATE) <= @ToDate )
                                        AND td.ProductID BETWEEN @FromId AND @ToId
                                        AND ( CAST(td.DocumentDate AS DATE) > @FromDate )
                                GROUP BY td.ToLocationID ,
                                        td.ProductID ,
                                        td.BatchNo
			
			--Sales Returns (From Date - To Date)
                        INSERT  INTO #tempCurrentStock
                                ( LocationID ,
                                  ProductID ,
                                  BatchNo ,
                                  Qty
                                )
                                SELECT  td.LocationID ,
                                        td.ProductID ,
                                        td.BatchNo ,
                                        SUM(CASE DocumentID
                                              WHEN 2 THEN Qty
                                              WHEN 4 THEN Qty
                                              ELSE 0
                                            END)
                                FROM    TransactionDet td
                                WHERE   [Status] = 1
                                        AND TransStatus = 1
                                        AND td.LocationID = @SelectedLocationID
                                        AND ( DocumentID IN ( 2, 4 ) )
                                        AND ( CAST(td.RecDate AS DATE) <= @ToDate )
                                        AND td.ProductCode BETWEEN @FromCode AND @ToCode
                                        AND ( CAST(td.RecDate AS DATE) > @FromDate )
                                GROUP BY td.LocationID ,
                                        td.ProductID ,
                                        td.BatchNo
				
				
                        UPDATE  ps
                        SET     ps.Qty1 = cs.Qty
                        FROM    InvTmpProductStockDetails ps
                                INNER JOIN #tempCurrentStock cs ON ps.ProductID = cs.ProductID
                                                              AND ps.LocationID = cs.LocationID
                                                              AND ps.BatchNo = cs.BatchNo
                        WHERE   ps.UserID = @UserId
			
                    END
            END
			
					
        IF @@TRANCOUNT > 0 
            BEGIN
                COMMIT TRANSACTION InProc;
                SELECT  1 AS Result
            END
        ELSE 
            BEGIN
                SELECT  0 AS Result
            END


    END

");
            #endregion

            #region Exec InvBarCodeConfig
            ExecuteSqlQuery(@"CREATE TABLE [dbo].[InvBarCodeConfig] (
    [InvBarCodeConfigID] [bigint] NOT NULL IDENTITY,
    [CostCode] [nvarchar](15),
    [TextFileOrder] [nvarchar](15),
    [IsPrintLGD] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.InvBarCodeConfig] PRIMARY KEY ([InvBarCodeConfigID])
)

");
            #endregion

            #region Exec DTSConfig
            ExecuteSqlQuery(@"CREATE TABLE [dbo].[DTSConfig]
    (
      [DTSConfigID] [bigint] NOT NULL
                             IDENTITY ,
      [InvDepartment] [datetime] NOT NULL ,
      [InvCategory] [datetime] NOT NULL ,
      [InvSubCategory] [datetime] NOT NULL ,
      [InvSubCategory2] [datetime] NOT NULL ,
      [Supplier] [datetime] NOT NULL ,
      [SupplierGroup] [datetime] NOT NULL ,
      [SupplierProperty] [datetime] NOT NULL ,
      [UnitOfMeasure] [datetime] NOT NULL ,
      [InvProductMaster] [datetime] NOT NULL ,
      [InvProductStockMaster] [datetime] NOT NULL ,
      [CashierPermission] [datetime] NOT NULL ,
      [CashierFunction] [datetime] NOT NULL ,
      [Customer] [datetime] NOT NULL ,
      [SalesPerson] [datetime] NOT NULL ,
      [TransactionDet] [datetime] NOT NULL ,
      [PaymentDet] [datetime] NOT NULL ,
      CONSTRAINT [PK_dbo.DTSConfig] PRIMARY KEY ( [DTSConfigID] )
    )

");
            #endregion

            #region Exec spBinCard

            ExecuteSqlQuery(@" DROP PROCEDURE[dbo].[spBinCard]; 
");

            ExecuteSqlQuery(@"Create PROCEDURE [dbo].[spBinCard]
    @CompanyId INT ,
    @SelectedLocationID INT ,
    @FromDate DATETIME ,
    @ToDate DATETIME ,
    @TypeId INT , -- 1 - Product, 2 - Department, 3 - Category, 4 - SubCategory, 5 - Supplier
    @FromCode VARCHAR(20) ,
    @ToCode VARCHAR(20) ,
    @UserId BIGINT ,
    @UniqueId BIGINT ,
    @CreatedUser VARCHAR(30)
AS 
    DECLARE @FromId BIGINT ,
        @ToId BIGINT


    BEGIN
	
	
        BEGIN TRANSACTION InProc

        IF EXISTS ( SELECT  *
                    FROM    sys.objects
                    WHERE   object_id = OBJECT_ID(N'[dbo].#tempBinCard')
                            AND type IN ( N'U' ) ) 
            DROP TABLE #tempBinCard
		
        CREATE TABLE #tempBinCard
            (
              [LocationID] [bigint] NOT NULL ,
              [ToLocationName] [nvarchar](25) NULL ,
              [ProductID] [bigint] NOT NULL ,
              [BatchNo] [nvarchar](25) NULL ,
              [Qty] [decimal](18, 0) NOT NULL ,
              [CostPrice] [decimal](18, 2) ,
              [SellingPrice] [decimal](18, 2) ,
              [TransactionType] [int] NOT NULL ,
              [TransactionNo] [nvarchar](20) NULL ,
              [TransactionDate] [DateTime]
            )
	
        IF EXISTS ( SELECT  *
                    FROM    sys.objects
                    WHERE   object_id = OBJECT_ID(N'[dbo].#tempSummary')
                            AND type IN ( N'U' ) ) 
            DROP TABLE #tempSummary
		
        CREATE TABLE #tempSummary
            (
              [ProductID] [bigint] NOT NULL ,
              [Type] [int] NOT NULL ,
              [Qty] [decimal](18, 0) NOT NULL
            )
	
	
        DELETE  FROM InvTmpProductStockDetails
        WHERE   UserId = @UserId
	
        SELECT  @FromId = InvProductMasterID
        FROM    InvProductMaster
        WHERE   ProductCode = @FromCode
	
        SELECT  @ToId = InvProductMasterID
        FROM    InvProductMaster
        WHERE   ProductCode = @ToCode
	
	
        IF ( @TypeId = 1 )  -- Bin Card Report
            BEGIN
	
		---Opening Stock
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  sd.LocationID ,
                                sd.ProductID ,
                                sd.BatchNo ,
                                sd.OrderQty ,
                                1 ,
                                sh.DocumentNo ,
                                sh.DocumentDate ,
                                sd.CostPrice ,
                                sd.SellingPrice
                        FROM    OpeningStockDetail sd
                                INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                        WHERE   sd.DocumentStatus = 1
                                AND sh.OpeningStockType = 1
                                AND sd.DocumentID = 503
                                AND sd.LocationID = @SelectedLocationID
                                AND CAST(sd.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND sd.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY sh.DocumentDate

		--GRN 
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  pd.LocationID ,
                                pd.ProductID ,
                                pd.BatchNo ,
                                ( pd.Qty + pd.FreeQty ) AS QTY ,
                                2 ,
                                ph.DocumentNo ,
                                ph.DocumentDate ,
                                pd.CostPrice ,
                                pd.SellingPrice
                        FROM    InvPurchaseDetail pd
                                INNER JOIN InvPurchaseHeader ph ON pd.InvPurchaseHeaderID = ph.InvPurchaseHeaderID
                                                              AND pd.LocationID = ph.LocationID
                                                              AND pd.DocumentID = ph.DocumentID
                        WHERE   pd.DocumentStatus = 1
                                AND pd.DocumentID = 1502
                                AND pd.LocationID = @SelectedLocationID
                                AND CAST(pd.CreatedDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND pd.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY ph.DocumentDate
		
		--Purchase Returns
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  pd.LocationID ,
                                pd.ProductID ,
                                pd.BatchNo ,
                                ( ( pd.Qty + pd.FreeQty ) * -1 ) AS QTY ,
                                3 ,
                                ph.DocumentNo ,
                                ph.DocumentDate ,
                                pd.CostPrice ,
                                pd.SellingPrice
                        FROM    InvPurchaseDetail pd
                                INNER JOIN InvPurchaseHeader ph ON pd.InvPurchaseHeaderID = ph.InvPurchaseHeaderID
                                                              AND pd.LocationID = ph.LocationID
                                                              AND pd.DocumentID = ph.DocumentID
                        WHERE   pd.DocumentStatus = 1
                                AND pd.DocumentID = 1503
                                AND pd.LocationID = @SelectedLocationID
                                AND CAST(pd.CreatedDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND pd.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY ph.DocumentDate

		--TOG IN
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice ,
                          ToLocationName
                        )
                        SELECT  td.ToLocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                td.Qty ,
                                4 ,
                                th.DocumentNo ,
                                th.DocumentDate ,
                                td.CostPrice ,
                                td.SellingPrice ,
                                l.LocationName
                        FROM    InvTransferNoteDetail td
                                INNER JOIN InvTransferNoteHeader th ON th.InvTransferNoteHeaderID = td.TransferNoteHeaderID
                                                              AND td.LocationID = th.LocationID
                                                              AND td.DocumentID = th.DocumentID
                                LEFT JOIN Location l ON l.LocationID = td.LocationID
                        WHERE   td.DocumentStatus = 1
                                AND td.DocumentID = 1504
                                AND td.ToLocationID = @SelectedLocationID
                                AND CAST(td.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND td.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY th.DocumentDate
									
		--TOG OUT
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice ,
                          ToLocationName
                        )
                        SELECT  td.LocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                ( td.Qty * -1 ) ,
                                5 ,
                                th.DocumentNo ,
                                th.DocumentDate ,
                                td.CostPrice ,
                                td.SellingPrice ,
                                l.LocationName
                        FROM    InvTransferNoteDetail td
                                INNER JOIN InvTransferNoteHeader th ON th.InvTransferNoteHeaderID = td.TransferNoteHeaderID
                                                              AND td.LocationID = th.LocationID
                                                              AND td.DocumentID = th.DocumentID
                                LEFT JOIN Location l ON l.LocationID = td.ToLocationID
                        WHERE   td.DocumentStatus = 1
                                AND td.DocumentID = 1504
                                AND td.LocationID = @SelectedLocationID
                                AND CAST(td.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND td.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY th.DocumentDate
								
		--Stock Adjustment (ADD)
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo ,
                                ad.ExcessQty ,
                                6 ,
                                sh.DocumentNo ,
                                sh.DocumentDate ,
                                ad.CostPrice ,
                                ad.SellingPrice
                        FROM    InvStockAdjustmentDetail ad
                                INNER JOIN InvStockAdjustmentHeader sh ON sh.InvStockAdjustmentHeaderID = ad.InvStockAdjustmentHeaderID
                                                              AND ad.LocationID = sh.LocationID
                                                              AND ad.DocumentID = sh.DocumentID
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 1
                                AND ad.LocationID = @SelectedLocationID
                                AND CAST(ad.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND ad.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY sh.DocumentDate
								
		--Stock Adjustment (REDUSE)
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo ,
                                ( ad.ExcessQty * -1 ) ,
                                7 ,
                                sh.DocumentNo ,
                                sh.DocumentDate ,
                                ad.CostPrice ,
                                ad.SellingPrice
                        FROM    InvStockAdjustmentDetail ad
                                INNER JOIN InvStockAdjustmentHeader sh ON sh.InvStockAdjustmentHeaderID = ad.InvStockAdjustmentHeaderID
                                                              AND ad.LocationID = sh.LocationID
                                                              AND ad.DocumentID = sh.DocumentID
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 2
                                AND ad.LocationID = @SelectedLocationID
                                AND CAST(ad.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND ad.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY sh.DocumentDate
                        
          --Stock Adjustment (OVERWRITE)
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo ,
                                ( ad.ExcessQty ) ,
                                6 ,
                                sh.DocumentNo ,
                                sh.DocumentDate ,
                                ad.CostPrice ,
                                ad.SellingPrice
                        FROM    InvStockAdjustmentDetail ad
                                INNER JOIN InvStockAdjustmentHeader sh ON sh.InvStockAdjustmentHeaderID = ad.InvStockAdjustmentHeaderID
                                                              AND ad.LocationID = sh.LocationID
                                                              AND ad.DocumentID = sh.DocumentID
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 3
                                AND ad.LocationID = @SelectedLocationID
                                AND CAST(ad.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                AND ad.ProductID BETWEEN @FromId AND @ToId
                        ORDER BY sh.DocumentDate       
								
		--Sales & Returns	
                INSERT  INTO #tempBinCard
                        ( LocationID ,
                          ProductID ,
                          BatchNo ,
                          Qty ,
                          TransactionType ,
                          TransactionNo ,
                          TransactionDate ,
                          CostPrice ,
                          SellingPrice
                        )
                        SELECT  td.LocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                SUM(CASE DocumentID
                                      WHEN 1 THEN -Qty
                                      WHEN 3 THEN -Qty
                                      WHEN 2 THEN Qty
                                      WHEN 4 THEN Qty
                                      ELSE 0
                                    END) ,
                                8 ,
                                td.Receipt ,
                                td.RecDate ,
                                td.Cost ,
                                td.Price
                        FROM    TransactionDet td
                        WHERE   [Status] = 1
                                AND TransStatus = 1
                                AND td.LocationID = @SelectedLocationID
                                AND ( DocumentID IN ( 1, 2, 3, 4 ) )
                                AND CAST(td.RecDate AS DATE) BETWEEN @FromDate
                                                             AND
                                                              @ToDate
                                AND td.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY td.LocationID ,
                                td.ProductID ,
                                td.BatchNo ,
                                td.RecDate ,
                                td.Cost ,
                                td.Price ,
                                td.Receipt
                        ORDER BY td.RecDate			
		
								
                INSERT  INTO InvTmpProductStockDetails
                        ( GroupOfCompanyID ,
                          CompanyID ,
                          LocationID ,
                          ProductCode ,
                          ProductName ,
                          TransactionDate ,
                          TransactionType ,
                          TransactionNo ,
                          ProductID ,
                          StockQty ,
                          UserID ,
                          IsDelete ,
                          GivenDate ,
                          CreatedUser ,
                          CreatedDate ,
                          ModifiedUser ,
                          ModifiedDate ,
                          DepartmentID ,
                          CategoryID ,
                          SubCategoryID ,
                          SubCategory2ID ,
                          SupplierID ,
                          DataTransfer ,
                          BatchNo ,
                          CostPrice ,
                          SellingPrice ,
                          toLocationName,
                          AverageCost
                        )
                        SELECT  1 ,
                                @CompanyId ,
                                tb.LocationID ,
                                pm.ProductCode ,
                                pm.ProductName ,
                                tb.TransactionDate ,
                                tb.TransactionType ,
                                tb.TransactionNo ,
                                tb.ProductID ,
                                tb.Qty ,
                                @UserId ,
                                0 ,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                0 ,
                                0 ,
                                0 ,
                                0 ,
                                0 ,
                                0 ,
                                tb.BatchNo ,
                                tb.CostPrice ,
                                tb.SellingPrice ,
                                tb.ToLocationName,
                                0
                        FROM    #tempBinCard tb
                                INNER JOIN InvProductMaster pm ON tb.ProductID = pm.InvProductMasterID  
			
							
		---Opening Stock
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  sd.ProductID ,
                                1 ,
                                SUM(sd.OrderQty)
                        FROM    OpeningStockDetail sd
                                INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                        WHERE   sd.DocumentStatus = 1
                                AND sh.OpeningStockType = 1
                                AND sd.DocumentID = 503
                                AND sd.LocationID = @SelectedLocationID
                                AND ( CAST(sd.DocumentDate AS DATE) < @FromDate )
                                AND sd.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY sd.ProductID


		--GRN & Purchase Returns
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  pd.ProductID ,
                                1 ,
                                SUM(CASE pd.DocumentID
                                      WHEN 1502 THEN ( pd.Qty + pd.FreeQty )
                                      WHEN 1503 THEN -( pd.Qty + pd.FreeQty )
                                      ELSE 0
                                    END) AS QTY
                        FROM    InvPurchaseDetail pd
                        WHERE   pd.DocumentStatus = 1
                                AND ( pd.DocumentID IN ( 1502, 1503 ) )
                                AND pd.LocationID = @SelectedLocationID
                                AND ( CAST(pd.CreatedDate AS DATE) < @FromDate )
                                AND pd.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY pd.ProductID


		--TOG IN
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  td.ProductID ,
                                1 ,
                                SUM(td.Qty)
                        FROM    InvTransferNoteDetail td
                        WHERE   td.DocumentStatus = 1
                                AND td.DocumentID = 1504
                                AND td.ToLocationID = @SelectedLocationID
                                AND ( CAST(td.DocumentDate AS DATE) < @FromDate )
                                AND td.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY td.ToLocationID ,
                                td.ProductID ,
                                td.BatchNo
				
				
		--TOG OUT
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  td.ProductID ,
                                1 ,
                                ( SUM(td.Qty) * -1 )
                        FROM    InvTransferNoteDetail td
                        WHERE   td.DocumentStatus = 1
                                AND td.DocumentID = 1504
                                AND td.LocationID = @SelectedLocationID
                                AND ( CAST(td.DocumentDate AS DATE) < @FromDate )
                                AND td.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY td.LocationID ,
                                td.ProductID ,
                                td.BatchNo	
			
		--Stock Adjustment (ADD)
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  ad.ProductID ,
                                1 ,
                                SUM(ad.ExcessQty)
                        FROM    InvStockAdjustmentDetail ad
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 1
                                AND ad.LocationID = @SelectedLocationID
                                AND ( CAST(ad.DocumentDate AS DATE) < @FromDate )
                                AND ad.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo
			
		--Stock Adjustment (REDUSE)
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  ad.ProductID ,
                                1 ,
                                ( SUM(ad.ShortageQty) * -1 )
                        FROM    InvStockAdjustmentDetail ad
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 2
                                AND ad.LocationID = @SelectedLocationID
                                AND ( CAST(ad.DocumentDate AS DATE) < @FromDate )
                                AND ad.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo
                                
        	--Stock Adjustment (OverWrite)
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  ad.ProductID ,
                                1 ,
                                ( SUM(ad.ExcessQty))
                        FROM    InvStockAdjustmentDetail ad
                        WHERE   ad.DocumentStatus = 1
                                AND ad.DocumentID = 1505
                                AND ad.StockAdjustmentMode = 3
                                AND ad.LocationID = @SelectedLocationID
                                AND ( CAST(ad.DocumentDate AS DATE) < @FromDate )
                                AND ad.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY ad.LocationID ,
                                ad.ProductID ,
                                ad.BatchNo                        
			
		--Sales & Returns	
                INSERT  INTO #tempSummary
                        ( ProductID ,
                          [Type] ,
                          Qty
                        )
                        SELECT  td.ProductID ,
                                1 ,
                                SUM(CASE DocumentID
                                      WHEN 1 THEN -Qty
                                      WHEN 3 THEN -Qty
                                      WHEN 2 THEN Qty
                                      WHEN 4 THEN Qty
                                      ELSE 0
                                    END)
                        FROM    TransactionDet td
                        WHERE   [Status] = 1
                                AND TransStatus = 1
                                AND td.LocationID = @SelectedLocationID
                                AND ( DocumentID IN ( 1, 2, 3, 4 ) )
                                AND ( CAST(td.RecDate AS DATE) < @FromDate )
                                AND td.ProductID BETWEEN @FromId AND @ToId
                        GROUP BY td.LocationID ,
                                td.ProductID ,
                                td.BatchNo
			
                INSERT  INTO InvTmpProductStockDetails
                        ( GroupOfCompanyID ,
                          CompanyID ,
                          LocationID ,
                          ProductCode ,
                          ProductName ,
                          TransactionDate ,
                          TransactionType ,
                          TransactionNo ,
                          ProductID ,
                          StockQty ,
                          UserID ,
                          IsDelete ,
                          GivenDate ,
                          CreatedUser ,
                          CreatedDate ,
                          ModifiedUser ,
                          ModifiedDate ,
                          DepartmentID ,
                          CategoryID ,
                          SubCategoryID ,
                          SubCategory2ID ,
                          SupplierID ,
                          DataTransfer,
                          CostPrice,
                          AverageCost
                        )
                        SELECT  1 ,
                                @CompanyId ,
                                @SelectedLocationID ,
                                pm.ProductCode ,
                                pm.ProductName ,
                                ( @FromDate - 1 ) ,
                                0 ,
                                '' ,
                                tb.ProductID ,
                                SUM(tb.Qty) ,
                                @UserId ,
                                0 ,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                @CreatedUser ,
                                GETDATE() ,
                                0 ,
                                0 ,
                                0 ,
                                0 ,
                                0 ,
                                0,
                                0,
                                0
                        FROM    #tempSummary tb
                                INNER JOIN InvProductMaster pm ON tb.ProductID = pm.InvProductMasterID
                        WHERE   tb.Type = 1
                        GROUP BY pm.ProductCode ,
                                pm.ProductName ,
                                tb.ProductID
			
	
            END
	
        ELSE 
            IF ( @TypeId = 2 )  -- Stock Movement Report
                BEGIN
	
	---Opening Stock
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  sd.LocationID ,
                                    sd.ProductID ,
                                    sd.BatchNo ,
                                    sd.OrderQty ,
                                    1 ,
                                    sh.DocumentNo ,
                                    sh.DocumentDate
                            FROM    OpeningStockDetail sd
                                    INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                            WHERE   sd.DocumentStatus = 1
                                    AND sh.OpeningStockType = 1
                                    AND sd.DocumentID = 503
                                    AND sd.LocationID = @SelectedLocationID
                                    AND CAST(sd.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND sd.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY sh.DocumentDate

		--GRN 
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  pd.LocationID ,
                                    pd.ProductID ,
                                    pd.BatchNo ,
                                    ( pd.Qty + pd.FreeQty ) AS QTY ,
                                    2 ,
                                    ph.DocumentNo ,
                                    ph.DocumentDate
                            FROM    InvPurchaseDetail pd
                                    INNER JOIN InvPurchaseHeader ph ON pd.InvPurchaseHeaderID = ph.InvPurchaseHeaderID
                                                              AND pd.LocationID = ph.LocationID
                                                              AND pd.DocumentID = ph.DocumentID
                            WHERE   pd.DocumentStatus = 1
                                    AND pd.DocumentID = 1502
                                    AND pd.LocationID = @SelectedLocationID
                                    AND CAST(pd.CreatedDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND pd.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY ph.DocumentDate
		
		--Purchase Returns
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  pd.LocationID ,
                                    pd.ProductID ,
                                    pd.BatchNo ,
                                    ( pd.Qty + pd.FreeQty ) AS QTY ,
                                    3 ,
                                    ph.DocumentNo ,
                                    ph.DocumentDate
                            FROM    InvPurchaseDetail pd
                                    INNER JOIN InvPurchaseHeader ph ON pd.InvPurchaseHeaderID = ph.InvPurchaseHeaderID
                                                              AND pd.LocationID = ph.LocationID
                                                              AND pd.DocumentID = ph.DocumentID
                            WHERE   pd.DocumentStatus = 1
                                    AND pd.DocumentID = 1503
                                    AND pd.LocationID = @SelectedLocationID
                                    AND CAST(pd.CreatedDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND pd.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY ph.DocumentDate

		--TOG IN
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  td.ToLocationID ,
                                    td.ProductID ,
                                    td.BatchNo ,
                                    td.Qty ,
                                    4 ,
                                    th.DocumentNo ,
                                    th.DocumentDate
                            FROM    InvTransferNoteDetail td
                                    INNER JOIN InvTransferNoteHeader th ON th.InvTransferNoteHeaderID = td.TransferNoteHeaderID
                                                              AND td.LocationID = th.LocationID
                                                              AND td.DocumentID = th.DocumentID
                            WHERE   td.DocumentStatus = 1
                                    AND td.DocumentID = 1504
                                    AND td.ToLocationID = @SelectedLocationID
                                    AND CAST(td.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND td.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY th.DocumentDate
									
		--TOG OUT
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  td.LocationID ,
                                    td.ProductID ,
                                    td.BatchNo ,
                                    td.Qty ,
                                    5 ,
                                    th.DocumentNo ,
                                    th.DocumentDate
                            FROM    InvTransferNoteDetail td
                                    INNER JOIN InvTransferNoteHeader th ON th.InvTransferNoteHeaderID = td.TransferNoteHeaderID
                                                              AND td.LocationID = th.LocationID
                                                              AND td.DocumentID = th.DocumentID
                            WHERE   td.DocumentStatus = 1
                                    AND td.DocumentID = 1504
                                    AND td.LocationID = @SelectedLocationID
                                    AND CAST(td.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND td.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY th.DocumentDate
								
		--Stock Adjustment (ADD)
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  ad.LocationID ,
                                    ad.ProductID ,
                                    ad.BatchNo ,
                                    ad.ExcessQty ,
                                    6 ,
                                    sh.DocumentNo ,
                                    sh.DocumentDate
                            FROM    InvStockAdjustmentDetail ad
                                    INNER JOIN InvStockAdjustmentHeader sh ON sh.InvStockAdjustmentHeaderID = ad.InvStockAdjustmentHeaderID
                                                              AND ad.LocationID = sh.LocationID
                                                              AND ad.DocumentID = sh.DocumentID
                            WHERE   ad.DocumentStatus = 1
                                    AND ad.DocumentID = 1505
                                    AND ad.StockAdjustmentMode = 1
                                    AND ad.LocationID = @SelectedLocationID
                                    AND CAST(ad.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND ad.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY sh.DocumentDate
								
		--Stock Adjustment (REDUSE)
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  ad.LocationID ,
                                    ad.ProductID ,
                                    ad.BatchNo ,
                                    ad.ExcessQty ,
                                    7 ,
                                    sh.DocumentNo ,
                                    sh.DocumentDate
                            FROM    InvStockAdjustmentDetail ad
                                    INNER JOIN InvStockAdjustmentHeader sh ON sh.InvStockAdjustmentHeaderID = ad.InvStockAdjustmentHeaderID
                                                              AND ad.LocationID = sh.LocationID
                                                              AND ad.DocumentID = sh.DocumentID
                            WHERE   ad.DocumentStatus = 1
                                    AND ad.DocumentID = 1505
                                    AND ad.StockAdjustmentMode = 2
                                    AND ad.LocationID = @SelectedLocationID
                                    AND CAST(ad.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND ad.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY sh.DocumentDate
                            
        --Stock Adjustment (OVERWRITE)
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  ad.LocationID ,
                                    ad.ProductID ,
                                    ad.BatchNo ,
                                    ad.ExcessQty ,
                                    6 ,
                                    sh.DocumentNo ,
                                    sh.DocumentDate
                            FROM    InvStockAdjustmentDetail ad
                                    INNER JOIN InvStockAdjustmentHeader sh ON sh.InvStockAdjustmentHeaderID = ad.InvStockAdjustmentHeaderID
                                                              AND ad.LocationID = sh.LocationID
                                                              AND ad.DocumentID = sh.DocumentID
                            WHERE   ad.DocumentStatus = 1
                                    AND ad.DocumentID = 1505
                                    AND ad.StockAdjustmentMode = 3
                                    AND ad.LocationID = @SelectedLocationID
                                    AND CAST(ad.DocumentDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND ad.ProductID BETWEEN @FromId AND @ToId
                            ORDER BY sh.DocumentDate     
								
		--Sales & Returns	
                    INSERT  INTO #tempBinCard
                            ( LocationID ,
                              ProductID ,
                              BatchNo ,
                              Qty ,
                              TransactionType ,
                              TransactionNo ,
                              TransactionDate
                            )
                            SELECT  td.LocationID ,
                                    td.ProductID ,
                                    td.BatchNo ,
                                    SUM(CASE DocumentID
                                          WHEN 1 THEN -Qty
                                          WHEN 3 THEN -Qty
                                          WHEN 2 THEN Qty
                                          WHEN 4 THEN Qty
                                          ELSE 0
                                        END) ,
                                    8 ,
                                    'Sales' ,
                                    td.RecDate
                            FROM    TransactionDet td
                            WHERE   [Status] = 1
                                    AND TransStatus = 1
                                    AND td.LocationID = @SelectedLocationID
                                    AND ( DocumentID IN ( 1, 2, 3, 4 ) )
                                    AND CAST(td.RecDate AS DATE) BETWEEN @FromDate
                                                              AND
                                                              @ToDate
                                    AND td.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY td.LocationID ,
                                    td.ProductID ,
                                    td.BatchNo ,
                                    td.RecDate
                            ORDER BY td.RecDate	
		
								
                    INSERT  INTO InvTmpProductStockDetails
                            ( GroupOfCompanyID ,
                              CompanyID ,
                              LocationID ,
                              ProductCode ,
                              ProductName ,
                              TransactionDate ,
                              TransactionType ,
                              TransactionNo ,
                              ProductID ,
                              StockQty ,
                              UserID ,
                              IsDelete ,
                              GivenDate ,
                              CreatedUser ,
                              CreatedDate ,
                              ModifiedUser ,
                              ModifiedDate ,
                              DepartmentID ,
                              CategoryID ,
                              SubCategoryID ,
                              SubCategory2ID ,
                              SupplierID ,
                              DataTransfer ,
                              BatchNo ,
                              CostPrice ,
                              SellingPrice,
                              AverageCost
                            )
                            SELECT  1 ,
                                    @CompanyId ,
                                    @SelectedLocationID ,
                                    pm.ProductCode ,
                                    pm.ProductName ,
                                    tb.TransactionDate ,
                                    tb.TransactionType ,
                                    tb.TransactionNo ,
                                    tb.ProductID ,
                                    tb.Qty ,
                                    @UserId ,
                                    0 ,
                                    GETDATE() ,
                                    @CreatedUser ,
                                    GETDATE() ,
                                    @CreatedUser ,
                                    GETDATE() ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    tb.BatchNo ,
                                    pm.CostPrice ,
                                    pm.SellingPrice,
                                    0
                            FROM    #tempBinCard tb
                                    INNER JOIN InvProductMaster pm ON tb.ProductID = pm.InvProductMasterID  
					
							
		---Opening Stock
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  sd.ProductID ,
                                    1 ,
                                    SUM(sd.OrderQty)
                            FROM    OpeningStockDetail sd
                                    INNER JOIN OpeningStockHeader sh ON sd.OpeningStockHeaderID = sh.OpeningStockHeaderID
                                                              AND sd.DocumentID = sh.DocumentID
                                                              AND sd.LocationID = sh.LocationID
                                                              AND sd.DocumentStatus = sh.DocumentStatus
                            WHERE   sd.DocumentStatus = 1
                                    AND sh.OpeningStockType = 1
                                    AND sd.DocumentID = 503
                                    AND sd.LocationID = @SelectedLocationID
                                    AND ( CAST(sd.DocumentDate AS DATE) < @FromDate )
                                    AND sd.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY sd.ProductID


		--GRN & Purchase Returns
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  pd.ProductID ,
                                    1 ,
                                    SUM(CASE pd.DocumentID
                                          WHEN 1502
                                          THEN ( pd.Qty + pd.FreeQty )
                                          WHEN 1503
                                          THEN -( pd.Qty + pd.FreeQty )
                                          ELSE 0
                                        END) AS QTY
                            FROM    InvPurchaseDetail pd
                            WHERE   pd.DocumentStatus = 1
                                    AND ( pd.DocumentID IN ( 1502, 1503 ) )
                                    AND pd.LocationID = @SelectedLocationID
                                    AND ( CAST(pd.CreatedDate AS DATE) < @FromDate )
                                    AND pd.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY pd.ProductID


		--TOG IN
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  td.ProductID ,
                                    1 ,
                                    SUM(td.Qty)
                            FROM    InvTransferNoteDetail td
                            WHERE   td.DocumentStatus = 1
                                    AND td.DocumentID = 1504
                                    AND td.ToLocationID = @SelectedLocationID
                                    AND ( CAST(td.DocumentDate AS DATE) < @FromDate )
                                    AND td.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY td.ToLocationID ,
                                    td.ProductID ,
                                    td.BatchNo
				
				
		--TOG OUT
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  td.ProductID ,
                                    1 ,
                                    ( SUM(td.Qty) * -1 )
                            FROM    InvTransferNoteDetail td
                            WHERE   td.DocumentStatus = 1
                                    AND td.DocumentID = 1504
                                    AND td.LocationID = @SelectedLocationID
                                    AND ( CAST(td.DocumentDate AS DATE) < @FromDate )
                                    AND td.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY td.LocationID ,
                                    td.ProductID ,
                                    td.BatchNo	
			
			
		--Stock Adjustment (ADD)
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  ad.ProductID ,
                                    1 ,
                                    SUM(ad.ExcessQty)
                            FROM    InvStockAdjustmentDetail ad
                            WHERE   ad.DocumentStatus = 1
                                    AND ad.DocumentID = 1505
                                    AND ad.StockAdjustmentMode = 1
                                    AND ad.LocationID = @SelectedLocationID
                                    AND ( CAST(ad.DocumentDate AS DATE) < @FromDate )
                                    AND ad.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY ad.LocationID ,
                                    ad.ProductID ,
                                    ad.BatchNo
			
			
		--Stock Adjustment (REDUSE)
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  ad.ProductID ,
                                    1 ,
                                    ( SUM(ad.ShortageQty) * -1 )
                            FROM    InvStockAdjustmentDetail ad
                            WHERE   ad.DocumentStatus = 1
                                    AND ad.DocumentID = 1505
                                    AND ad.StockAdjustmentMode = 2
                                    AND ad.LocationID = @SelectedLocationID
                                    AND ( CAST(ad.DocumentDate AS DATE) < @FromDate )
                                    AND ad.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY ad.LocationID ,
                                    ad.ProductID ,
                                    ad.BatchNo
			
			--Stock Adjustment (OverWrite)
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  ad.ProductID ,
                                    1 ,
                                    ( SUM(ad.ExcessQty))
                            FROM    InvStockAdjustmentDetail ad
                            WHERE   ad.DocumentStatus = 1
                                    AND ad.DocumentID = 1505
                                    AND ad.StockAdjustmentMode = 3
                                    AND ad.LocationID = @SelectedLocationID
                                    AND ( CAST(ad.DocumentDate AS DATE) < @FromDate )
                                    AND ad.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY ad.LocationID ,
                                    ad.ProductID ,
                                    ad.BatchNo	
		--Sales & Returns	
                    INSERT  INTO #tempSummary
                            ( ProductID ,
                              [Type] ,
                              Qty
                            )
                            SELECT  td.ProductID ,
                                    1 ,
                                    SUM(CASE DocumentID
                                          WHEN 1 THEN -Qty
                                          WHEN 3 THEN -Qty
                                          WHEN 2 THEN Qty
                                          WHEN 4 THEN Qty
                                          ELSE 0
                                        END)
                            FROM    TransactionDet td
                            WHERE   [Status] = 1
                                    AND TransStatus = 1
                                    AND td.LocationID = @SelectedLocationID
                                    AND ( DocumentID IN ( 1, 2, 3, 4 ) )
                                    AND ( CAST(td.RecDate AS DATE) < @FromDate )
                                    AND td.ProductID BETWEEN @FromId AND @ToId
                            GROUP BY td.LocationID ,
                                    td.ProductID ,
                                    td.BatchNo
			
			
                    INSERT  INTO InvTmpProductStockDetails
                            ( GroupOfCompanyID ,
                              CompanyID ,
                              LocationID ,
                              ProductCode ,
                              ProductName ,
                              TransactionDate ,
                              TransactionType ,
                              TransactionNo ,
                              ProductID ,
                              StockQty ,
                              UserID ,
                              IsDelete ,
                              GivenDate ,
                              CreatedUser ,
                              CreatedDate ,
                              ModifiedUser ,
                              ModifiedDate ,
                              DepartmentID ,
                              CategoryID ,
                              SubCategoryID ,
                              SubCategory2ID ,
                              SupplierID ,
                              DataTransfer ,
                              CostPrice ,
                              SellingPrice
                            )
                            SELECT  1 ,
                                    @CompanyId ,
                                    @SelectedLocationID ,
                                    pm.ProductCode ,
                                    pm.ProductName ,
                                    ( @FromDate - 1 ) ,
                                    0 ,
                                    '' ,
                                    tb.ProductID ,
                                    tb.Qty ,
                                    @UserId ,
                                    0 ,
                                    GETDATE() ,
                                    @CreatedUser ,
                                    GETDATE() ,
                                    @CreatedUser ,
                                    GETDATE() ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0 ,
                                    0
                            FROM    #tempSummary tb
                                    INNER JOIN InvProductMaster pm ON tb.ProductID = pm.InvProductMasterID
                            WHERE   tb.Type = 1
			
			
	
                END

	
	
	
        IF @@TRANCOUNT > 0 
            BEGIN
                COMMIT TRANSACTION InProc;
                SELECT  1 AS Result
            END
        ELSE 
            BEGIN
                SELECT  0 AS Result
            END


    END

");
            #endregion

            #region Exec Productmaster IsWeightable
            ExecuteSqlQuery(@"ALTER TABLE [dbo].[InvProductMaster] ADD [IsWeighted] [bit] NOT NULL DEFAULT 0");
            #endregion

            #region Exec CustomerDiscount

            ExecuteSqlQuery(@"CREATE TABLE [dbo].[CustomerDiscount] (
    [CustomerDiscountID] [bigint] NOT NULL IDENTITY,
    [CustomerID] [bigint] NOT NULL,
    [CustomerCode] [nvarchar](10),
    [ProductID] [bigint] NOT NULL,
    [ProductCode] [nvarchar](20),
    [DiscountAmount] [decimal](18, 2) NOT NULL,
    [DiscountPercentage] [decimal](18, 2) NOT NULL,
    [CustomerSellPrice] [decimal](18, 2) NOT NULL DEFAULT 0
    [GroupOfCompanyID] [int] NOT NULL,
    [CreatedUser] [nvarchar](50),
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedUser] [nvarchar](50),
    [ModifiedDate] [datetime] NOT NULL,
    [DataTransfer] [int] NOT NULL,
    CONSTRAINT [PK_dbo.CustomerDiscount] PRIMARY KEY ([CustomerDiscountID])
)");
            #endregion

            #region Exec Level Updation

            ExecuteSqlQuery(@" ALTER TABLE[dbo].[InvPurchaseDetail]
        ADD[StockCode][nvarchar](25) ");
             ExecuteSqlQuery(@" ALTER TABLE[dbo].[InvPurchaseOrderDetail]
        ADD[StockCode][nvarchar](25) ");
            ExecuteSqlQuery(@" ALTER TABLE[dbo].[InvTransferNoteDetail]
        ADD[StockCode][nvarchar](25) ");

            ExecuteSqlQuery(@"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAccountsTB]') AND type in (N'P', N'PC'))
                            DROP PROCEDURE [dbo].[spAccountsTB];");
            ExecuteSqlQuery(@" ALTER TABLE [dbo].[InvStockAdjustmentDetail] ADD [StockCode] [nvarchar](25) ");

            ExecuteSqlQuery(@"
            CREATE PROCEDURE [dbo].[spLevelUpdation]
            AS
            BEGIN

                DECLARE @var0 nvarchar(128)
                SELECT @var0 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.InvPurchaseOrderDetail')
                AND col_name(parent_object_id, parent_column_id) = 'LevelID';
                IF @var0 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[InvPurchaseOrderDetail] DROP CONSTRAINT [' + @var0 + ']')
                ALTER TABLE [dbo].[InvPurchaseOrderDetail] DROP COLUMN [LevelID]
                DECLARE @var1 nvarchar(128)
                SELECT @var1 = name
                FROM sys.default_constraints
                WHERE parent_object_id = object_id(N'dbo.InvPurchaseOrderDetail')
                AND col_name(parent_object_id, parent_column_id) = 'LevelCode';
                IF @var1 IS NOT NULL
                    EXECUTE('ALTER TABLE [dbo].[InvPurchaseOrderDetail] DROP CONSTRAINT [' + @var1 + ']')
                ALTER TABLE [dbo].[InvPurchaseOrderDetail] DROP COLUMN [LevelCode]

            END
 
            ");

            ExecuteSqlQuery(@"
            exec [spLevelUpdation]
            ");


            #endregion

            #region Exec CustomerDiscount colum -CustomerSellPrice

            ExecuteSqlQuery(@" ALTER TABLE [dbo].[CustomerDiscount] ADD [CustomerSellPrice] [decimal](18, 2) NOT NULL DEFAULT 0  ");

            #endregion

            #region Add_MigrationHistory

            #region Mig - 20-01-2016

            ExecuteSqlQuery(@"

    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201601200720500_AutomaticMigration', N'ERP.Data.ERPDbContext',  0x1F8B0800000000000400ECBDDB72E348923678BF66FB0E6979BFD595CACC999EB199FD4DA2A42A76EBC01659597FD78D2C120C891881000B07A5D8AFB617FB48FB0A1B81030990200EE1EEC183DC6CACA74A457C1E0844B87F7E088FFFEFFFF97FFFEB7FBDCDBD0FAF328CDCC0FFEF8F9F7EFAF9E307E93BC1D4F59FFFFB63123FFD5F7FFDF8BFFEEFFFF3FFF8AFABE9FCEDC3B7E2779FF5EFD4937EF4DF1F6771BCF8CFBFFC257266722EA29FE6AE130651F014FFE404F3BF8869F097B39F7FFE8FBF7CFAF417A9203E2AAC0F1FFEEB21F163772ED37F51FF3A087C472EE24478B7C1547A51FE77F55FC629EA873B3197D14238F2BF3F3E0C273F5D3D8C7EBA14B1F8F8E1DC73851AC3587A4F1F3F08DF0F6211AB11FEE76F911CC761E03F8F17EA0FC29B2C1752FDEE497891CC47FE9FEB9F777D899FCFF44BFC65FDA0D1247C5CBD9E7AC12B3511F1520F2F7DC9FFFE78EE38EAFF0235410FD251F3E2AA37D4A22E652C5CAFFCAC7AFAEF7259F983FAD3280C16328C970FF2A913E2F0F2E387BF5451FFB209BB02ED8CA85FE8BF3F0EFDF8DFBE7CFC7097789EF8EEC9D5FC973ED4380E42F98BF4652862391D893896A1FA1EC3A94C27666B6CDB23311F462B742DFAAF524C6508451F04F385F0971598CF67BD616E02271D1414671044F1404D7928A148978193CC15121447AD5F192A55246B010D667C0B107DA4681F4384D3BBA0C0507A4C29E38F1F6EC5DB8DF49FE39952D35F3F7EB876DFE4B4F8430EFB9BEF2AD5AD9E89C3A455CAFD42FA0AF87CAE977821EC523AEE5C781F3F8C42F54FB951F8EBC70F6347E8E11BBC8B1744F4522EC341089B73E2010EA34289C86921E422083C297CE31D36562A348960AF3D8C7E5BDC04023CA61BD797EB256BF8091CE7176F120A3F120E9E1AFF250C92C5FD1392BE1D8452DB29452FC286FDF9F56784FD998B523C47AE96A5FAE789E24DBD87AD6895FBE4DA1977210B65E09AE5A54BE249F6DAE0FFF59735B132A25B9995C7A45B6BDE8045B7BA321162BAC584A893BA46D90F2B2B82B5BBE47518CCE1404854AAC069643F6718EC47ADE41B397D9661BEA4A1CBD70E9BD2265FEA09B243AB2C9137B95062626229BFBBF16C1A8A1FC22316F49BAF0CB7E7FE4B4E07B33F6522C9C52D4219A92561495EFEB5066521669B7DFD4510C036671D05726366113057BE22BD86BB157E223C7A390F722EC297466F1583561EA2D7C3BEC57BF42D14D29D78759F539ED92B32AA96ED83F4D23F44337791C5AD7F6AA6F78FAD909AC13D045EABA3D086F4380E92D0D1F31AA0C04D44F82C6373BFEC42F82FB9B50105BFB7700C7DB05A1C5B9E9781F05602AC31A719E68C7D38AB21DEF71725B713D4A626BF0748423042AF4C64DE23913134C6A0D068ADCD3134C63D6D17AE3166C3693DF879945146BD5690628C0A6620A219161AADA9B418E978C71188925AD6A553CC029805208733B61CCF9D418C2D8AF0B8E3F14AC0A2E35375C189AE8F820311AEE7A9BF874B5818A28A62CA7BB651ACB19EBEA2DB6D6381C829E4E6A9F23C3D26393DBC323D7B5C2A5B2359D216BA527050561447C73634105A34E7C0B9DD9D08C3BCFE999873A921FAC5125B7125D717E1B2224CFD63BDB0E363744CC29884B519CA9D0CACFAB3C76DBEB0C5BEDA9F58D1A732F3EAF05841D8C0AC0B166FDAA61810D665BFE48E395237A4BF05DF079E8822E8046197EB49F71549B7E89580A3A4129CF2C141126AB602375239CE43795054A99BE321BC19491DCBD0B551C6834C8911CAF6A3883A9BE7466924D592989154F6D08FC533DD229F88B7EC653ED18B38A317F1995EC4177A115FE945D0797A927A777045A4A99891586A433491E11C6AD47228A5A1DC608A631FD9A7669FFA387CEAB6B40689535D97CEE8E18B1B3BD5896279C072CA1284A93BBD01D1FC4D117DE95C6EE484EEA2357ED9691F1CB7FB8DEAEC5EBBBEF01DE5ACFC530AE8696CE4D359D987C7306F1952C689323C3AAABD2D8B8E736FCBA223DFDBB2E858F8B62C3A3ABE2DEBDF2CCAFA778BB2FE6A51D67F5894F5E9679BC26C6A8E4F84EEBAB2CE5E5922A1AF68C5B11A4697D2936B8B68EA76B0FBC2EE8B9DEA6C5D80A096C7DC8DF42E3324F65510436ABF0D628DDC0BFFE590AA43D6B3409AD738329DC8BA8C75598B2E9BC93F133950AEA4F440A9FF6D20539D560B64AB00C044FA510521F8B409D6699393C9D458326AC7737A163B20962915FAF3B89C0D620A721814A4251B54B6B22D09A16D83FCB80BA09216EAFC5C5D72A8FBC3D014D1362602FF02A58BEA81F6C1BFD04EBE30A9EB6F53B9F706D764EC5C6E6C858FC20AF73744082608C1F8ECC1EC9CAA3EB7E70F63AB4F9CA2F96C3D6140A1574908FF053A571AE34229066786665E0FEE74E5482CA5D4FF486E6A6C79E9D9797939DD5A018777F6349B130D0E5468290E06232A5D59001FD62152B5E321BADC0B8D89A92D627A17A495B920669A6380A86909E39D72D3F7CE28ED74D624C9401C929963C5CF8ABF8BE27F907112C22E08DA060299804D20BBA1F17ED28FCAB27069C2B19426E8253898E9D417D73F70FDC3E144560ED09D679EF31E794EA7FA874C8F76AA7F285BFDC75D0035F50F1D9EDB5DFFD0E5619CFA87322602C94348416D02ED83E421D73F3073E4FA07AE7F602BFC7EAC702F4314CAA9AB7CB3185803B101636A846A60AC99A0DEB2DB0DD00A92CDCF89C51A0EB77000B9C71EB699A433E868D4251C403B8B9CC4097526344C680E83D0B4851536CCECCE98C2C6EF1E6B18C7563CA1CB3375DDABBB3D08ED5FBDF5EA50FA064B14F5E63B14F48DB95623D241F6B03E3E0268B771F2A9D3CDC338558C6230457BFF579CB41A934026814C0277858E766796C858605D46A9177D34658197F23B420C6F03C59003D6A0D8A280BD45B706F05688CC294F8CBE1D18FFE1701B87DB0E9069A1BB1D4CDD98BAB559D95DC46DE3678FDB646393B67578A22E74D7E53168E06EF39D81940D14B6EBCD7208281B132C0EDA71D0EEB8482B07ED3868C7CC8F991F02F36B89D9D150BF9A785D1FC6684AFD7EF14ACD1C4011BB1A24430AB803C9160D3412DF1ABDABA032C16C9B2ED4B34F65A645CDB30EF2C07C7EDB21D20DCF4D44729F37E81E7CF06EA36FCE708AC4C00FFE38027A9C766BA4160EF43A4EC52E3CB9BE8BA2362D1DCCECE6C1209DB27DB79EC5307A904EE03BAE27C15813395FACD1AA6FC99E0F7B3E689E4F0D37DDE5FCD4FCF4B19EB26F3A413D9EAC8B83F7791C1A0FAF9B0F04A708141737F21F4EB601D6E106B3DF694BAEC3F50A6C0586DF5FB1C41E48F821523EA6544CA9BAC430770694ED70AA9A00B30925430C346BFF062FD8ACD1F002CE05DA1E83CEDD86D02FF08C13CEE608F9BE592B47C83942CE11728E90F718293D393FC948762E8A43E6EF3664BE33F103544EEC37BE47BFB18FCFF437E5B2F9C24B6F3B00D5E66C03197A4AF540B69C2413E9AD7BBB0CCA5E8755E6FE9EAB9EB13D385B04E2D03D88EC4033B190B40C935886FAD769E2C4C3B9587778BF707D112E2B9F55FD63FD673D3E22C884E83D12A29640FAB679DE1546DFFEE5632D63D90CA2777EAEAE2CA1FBC3D0A2849A898093415049820973A22183CCDBACD638F0813D0B07F6BA1C033BA8E613D4C42E09F530E1BC20C779282FE2233E2E7884914335AD7E81874F6D998E321DB542475BCA3AE8F9684D49477F326BCA472BD10B432ABA15013160A13DA32878043413ACA5356C8C9D3A6C6367F4CD73287937F2557A30A53412A16660FE54BE01396F3A1703F5428DE6AE9B963092ADFFB9C908D2C8DEBA3EDE60EE34C685D254CE0C1E9CB44205F2BD86C20462E14F4538858715F568A42614E50D691ACF522EDC0B943E0CA37327765F251CE7527A3246C0C1A145F9D7A7CFBD33FF7A8FFCAB3F05C91DF264FEDD3824B60D0422239B40B618097A48A5D9A676E536471575C3E946B41D9432C3D1F52C58584FCAC3F61DB5302FE4B3EBA36CF215E4953F55AB03A71233944FEE5B0B95C4597A6C61D8C2B4589840F8F0F29B0D1453DBB28D62CDD5ED2BBABDF6A140E4D40DA75C1A3E88E51E897E5C9663EA856B14EA0A148CF530100B977EA86A16652823EA7A9989D2755E218B56CA85F044A9261C5F8878239E2CEA37E0F222667B47CCF640F53535D406C2F6EC57D63037636E7670DC8CD8209E479124AF1A0E7EF8F939533AC3AE633BB7811FCF6AA499ADA82B7F8A0B589034D20A1CB52E5F5D470E663ACD4D26E53E9EC99058463EE7B7329E0553B4F30BA753C0769D0621E5D08F94714B62B05AD7E64F3F8F81334AC24510E10C498673942129851D008F2EDE05F74FF9B28C14DE3F81B9DBFB8536ECC2BB7A8B4341AD217F098523312621558ADE120D4FF94A61AC7688FE48487D08AC94030CA3B1F4A757731D1F05BA6829C8F974AAAC436469DCE339F880F0447A72310B7C0BE7D1952FAC1CB751B04816E061DF05B1FBB4BC904FCA59D01BFA522C819E3AAED77F1B84F1B378967A3F40DFB5C042F2A133302B3CA610466F4739CEC271163B7196FB85F47D3515791412945BABC5328CB9ECC4B21579311C406BB66D0397E33A564231877BF81CA9C8E5D0CF821F6216E2C62DF344EE1CC316D6828505E533761A0FB885B59FDB604BC8198EF799E1E023A9ECFCB269A631CD1F9A0F8DD6BA753BCF8DD69AA8C70698CAE9D19E4FD79D21ED0B013D495AF4DE8584012A1886E4640BC31629E929B8D5DDCFF198DC9C181F39FC8ED7DC67D9C23218CB38787AC29AEA2A1AD63C67A858935C1DE3BEDB469EF06D4634B52638E1461C14ECBE9B5B1D000C318EAA0380DE16F47DDEB37EF2F506AACD9BBB7F95E148B8F086E2D50B090E273F7E291741E4B2EFCBBEEF1185A52B8E09CCD30385A17B3A48E89E1E7B668D48D8FD2AD9C3630FEF10D3F8388C16CDB7182BA74197F3461B7366A49A3C4F3A4A57EA7F6DE2891DDB72B5483BA6D6A0764E76521F9799BE5A9062F1A2A70E87158EF19E27B8CF927FE9DC9660B81B07EB52B11FC47E90253F48C6F17220A2D985EB79B0BCD73692A94F548F64CD333211DF9E092BA3B2D77562DE125244F8788A50B9713ADBBF0659875C0353A3897715C0D4FCF4B1DE406D16BFF478B2EE329F3E8F43AFF3A99B0F040A000B8B9A584B220AC0C6DA4A887435E738B6F46ABEF082A50487A294BB29654BEC88A8B53ED73C5BEDB8F76EC3CAD45DF7EE7F238FCEC549E8CB29795FBFB1D2519EB558E38945003930C68EC1F138062DA5F1763C839A927813C702EC190CE70BDD5E02273E580183FA075B60B65C8403E3F3C8EC399F566A66104509B9D53E7F552B43FF9E5A9052A3D422ECA454DF311566AEC25CE530B88A999DBEFF0DC946174060FB5C06B21EBEEB21BD7B024F819E6448F0F82244D827288E28FFC6C6858D0BBD23BC5275AD6EF0EA978FB5DA7FA713DCF65C6372ACF561B4D4D87A22E086152731D6C30AD118D693B481C86E34566E8C9359C74E554EB381CFFB0B109C5A724629729433A04C6D99DA1E1BB5ED9AE221E3B64DE99DCEC418CC6D6F4514C3896D860265B56B94E62F7EB2799C230B690CA34BE9C9F576675DCDBA9A38C68DD2A3AD160CAABCF6D7B5CD7004DD63DEA8DD0268500F4C91E39F86B177E6FFA09AF572EF00EE0EB78DC6DDE1D651A503E788452737F556D0F9DD6A71668881D3E2ECD07B8F219E94E7F80EFB0CC7EF33E0A4F050DA7E1952603A9F8149B8954C1E67AEAC26603971CACED4F19D98B35CE67D22A94CA6BB4C774F8EEE764D675622BFED29CD0AE97B6C02AA4F6D767DBE31C5D919042DD599E3AA79746414A1A6102A98485EC116E6BE9C839E03E99D57C8F169D20BA8E027EBE070968189317600FC3D84FC8F2204CF7C96F9EC61F05904DA861AC5DD220778B46DFF315D663E1C923DB8902CD3B6C3A36D1CCFE47826F33FE67F0717CFAC049E3A87352BBCA72EB0B809DB18E4EC89D625E4D917122D00FA20DDF9F7248C64DAB71B48A12B6050EEBC05668B341F18AFE573B216A92D567900FAC55C7BAC3740A6FBA8F7F8E20CA9A9A2D208AA71A176FD4C6D2B2C578F2741D5B9BDE061B6170C8217F6D520392D76B0D8C13AC200FBB720716632C42988A88041DD822D30EBB1F49E23E85EFB90037374FE405C0FAE4B38DD00F7FBAB4B40BB8BF9280A1CF88CE19ECE18E6468C9314CCA14F8743774D5254185C6B72A2F2EBC79D2477673AA2EBF38D2D533B83A0B54EAD4E128E6F8153AED39380D3F916EC027016E3700A74F8CC24BB60940D680EDC95A0BFAE9043EC2662D8D3604FE3BD7B1A5DEBA0ACB91A4DB54EBDFD15535763AC3464A4FF64E85DAC9E3774282ACFDBF22156EABD9BE096D063F1069732724277A10748BDFF2EE5773746ED75AB34D1141932E77E18253D0FD209B2E2201CB333116F172292D37BFF32841A9F6174EEC4EEABEC87D3678FA6CA51387A615DCA27D777D32566B65F6BB10CF7EE4EACE68F83B78F6B073050BB08B63E6A615B9CB14F3F77DBD7BD17D76DE2C5EEC2EBB9BCEA90B8DB34732D1B9511A5ED3391F385225B12541CB1130FAEB6B6F16C5110C0205AAB246AB0394A7A20312F0E71751D29F758C62F6CB0DD63D952786BEC08BF78A915BF717D112EBB05CCBB2E759414010ECA56A58521064EA505EA4185432FDB1846F7AF321C09171CB72C1B6A1D8239884C1FFA791CBCE405F2FD3E97E1A06FC0D16E3A250BCA50F7B7D1B124EEA1C38EECBB70645B92063B5DA75D69839D0F3C36799A9BC9034394BA6A25532868CDD2EE9943F3FA41954B00A798D4EB67CFFC283CF3E3ABA3C2EABA5F2CD49600388A89B05BFB752BFCC4861C34028CEC89A699CB910CA38D0D7F0887F80781E74947695B1BCBCE4E51D1F9F4D5829442C1C01D4A54EF94DA534A42BDFCE0343EC779289B08B2EAB266D57344F56598FE1D6D300FCB7B1C460FD2518B45CDA762C37A6CEC8DB2374AEF8DB654B1EDD71DADA968837AB618EE685A9B8594805E6121B8A115AC7DB8A03D06D02BE9AC904ED2AD35AF79EAFC4D304EE122C4B59123ED199872351CB548C5331DB5D2554E4F22F162B87DE77229B6EBF4E5526A968DAC927ACEC802E5CFD9B2365A5EB920D33C9BDB578329C1FB29D9B4E472B182620545E3780C92280EE632AC77328AFFFA98AAAE92DF50F90F5B99A9EA7FAD4B36350D692295A71D2855E4CAFA51A53F50FF7DB935ACEA7FD91AD7C67F0665C18A773451E8C5B3264ABDFCAC2DC55EC8DC8B722F844FDC785D186F1AF0CBA0F6632B562F028EAF0E0245AC9D388BE623BD4C8BE190FEB4B7D2D90CBCBB9EA746773E9D86328A3E91C7F92BE2CEEC8AFB6C49DC44D182C52CF09B56004E5FDD5CE06DF0DDF5AC49BBD660C4A2AEE63A58442DE541EA46BEDA21D6C7C7ACECD90D91C34163060265555A11527DAF6C415A682CAD18B812172E6DE9AF0D79E40A6C431EB9062BE4D9536185444B3AAC10674389E5277ADDB94B98764D8BA86965E8CC40108A70492BE63E89A358F8D3F463EC35F18B642E85FF72198A27CA9C7BEE76CC4B115DBC4CAD7ACC9D2773DDF3E0D28D1CD2F2814256BA65C8A565BB4651753798C2F87371C45E867384C88D7A778C414DC4DBF0F21318E32E68B2A7288559E948CF1046DA6489F146FA1961A44D361C6FA45F1046FAC5CA48BF228CF42BF548AD859453884DFD679E421B27D142470910AA6D2E3CE1BCDCB8518C0176132C8517836B7686517E40C7F3821F18E3C289E85F84C10B42EA3DB7EE697E009C38EF94766AE38179A4F6046F55BA8F6732C481D2056E1E4A819B495B1BCE2FD562717E69431940524B9B5566F589A7BED9AE749D360F6BE3A735E3ABFC62F740AB3FEB3BE28AFE6A1EF1C64F6B465CF9C5EE11577FD677C42BD5DD3CDAD2CF6A46BACED4ED1CE5FA27A0F2C1EA770624F356B6D334A3D7D1F8E2A7F552C12DB9BD8E05EA10DEC1151C6C61D9C2525570F4B5673B6B3AEACD9E91EEAD5A2C03DDBBC5EEFBEADE9EEE01E2CD0665C13875153D04B6A85A9C0D1FCCE76EA423A8A4E7AB4A8D4761BA7018D540814E0C4977810486E39DB10D621BB4571BD4D743D96983EA1D19231BB4F6430CEC4F254CD5D7F6F48871E1D668A305E7F6520FB892BE1F7F8195282B51CBA1B2CEF5CE9BB1921DE5D0C85ABD6B2467A736DF0EF61869F2F3240E0AC538F49F02A3A3361B1846C76E6A306CA977B5C8134FC2C93056079CEB209C0F8125061A03C76131103C916FB17D23A39CA327B7A96AEC338647980A69AA66C090A23942F63C6C158C93A7D2941866268B9D8960BF35D6403D8970A5C4A5D489732C9C32298364F3170BCF95A1FA0FD3C441280FD06D547F576A5EFE0323175F1CF2C678D907B908C2D8CA96CB44C1D5F3281846B7C29F8ACCEC82178E1B2D44ECCC1EA4233C0F8E77219C174DAD10D6B46E310545D1185023348C503ABFA88DA57E9E2D0384C95184CC7DF62BCD73CC035641E24FEF9F9E10A2555A352ABF06C34DD2150E6A99CB5C0F55CB4FCD479815F10CFD5FEF11C1EE93D893085F0227DA77239641D2C45DB00EB634DD628077783EED5FEE1ADD84943F6AC2E54B8FDAA2F05A5B8D9E9A2CD12714375E375E6F66D5FF8ED27A3DEF116843CEA1F4D96F99579C666F944995A22A7444DFC445F3041D36C008C9C849008619C742313477FD018D91AEFC290ACE37E125D529C2FE06A984D2DC512D27EA0B8923F522EE54B9EDBF7C4BDB9D6230ACF977D78713598EF6CA7718EDED476ED2CB598CF9CDEA6A17238AD3F162183C96B3656A4D1A0AAC46BE974454267A3F59285B87906D1D3EB675E8D8DE61631BA77E2D1D64BED6E79EC8A57062954DAD25536B6A644DCDAB6DC3BA1F73D8EEF812194325F9EF275B384EEAE70F237D9ADCF50542D09FB5376B6F2BDA7B1444A60A5C3D6AAAC3F3476D4581B14291F030645FB5C8FA8AF515EBAB620B667DEC8A7285F348E76BE5747D659A91266B0335D2715D40AD91D8EA600EE786BAB1D41755B1F261E5737CCA0741D5202816AB079C716F14D98B5B5D086F71AD692A60F1C2CC668211E2CE66820F22108DA4B25A62C42852DA42C42842DA3AF5221D5BB5DD5B3BED07749144AEAF169E1589854EC96A5E5BD41A46DDAB06BF7F2ADE91FE1346B16E559D1F33A41786C32D75F902461FB638705E5636FF4098EA30D27784DD3F3DB90E182B6B79A5C8C0ACE1DB22B5F00D7EF8D684E96FE6597C395DA59D2CAC881ACBF0557DF9C14C1F01238B0E55A490D71A2155E916B47844ADA8946698053F1E82751D19BB9DEC7652B89D694B4A236F73D5CCB2B793D9B10D2662882A95D8D6358BA8F0488BDE8B43C8912B5621165448DEB357D7F4EBD3359989BC099E4D94CA2E2C1335D384652BA8553B06F00ECA4F69548EC9011A09437114957385D71852C029AF488FC1D08BB9F2F56F2D086205CD0ADA8282D6DB265761A906CCB4D058C63AF062D445B509D0A8AB6A1BA02DA28896C44C3515462B058D941E735233B15649668A3A536C5868ACBD587B59D75E685A0B4D5BED414BE16A97BBA05623983422924F22F1E20CD44A8F8E4CA361CC44836E349F890CD4CA4CB036666D6C491BDF8A2836BC4B7BF5B4A9DE5D3F6D53D96A597045BB9792940EAD2368A28FE497F58D02D78FD3D3F064226E5D5FDF3E984A8A600BE0415E4A39B73066BE2381EDCD29D99B68E6CAF03AF11DD3B2C80D0833CBB30561CBFC1432DB6A8D488C4721FC52464EE82ECA452AF6CEEEDD87D3CAE2326982ADA3E5E08A1FACEA9A8AFE67BDC97A934E6F9A5F94557A1EA031B7AFC922569757F385172CA5225BFA484C0A89B1F9BB6A611A0DD84F0D9FD1F07904354C4B7CCB4E1A59711C8E2539779C52692D5B12B624076F4946FA2C6F7A4314C09CAC410036A50A727C99C1F425A0C7C50B3B07BF72398A7E04EBB6CDD68E9EFF2D48425F7838A1A9B6D07E4BE40DE754CDFE2902B393C365276A0A98FEACE80FCE0D7938342A0B98361F743AA48829D33EA67D1668DF4CF8CF723AD148C358CE2F656C44FCB6618CA85F3D8C2DF237CA2F348092AD0C662FE710D427D9CFF907919EBBB84ED67795984D5E4E2FACE7312FF4652B18E7A5F1ABAA69045FBD2DDC7059AFA55A347310D1A57BCF5F9F49F14761E9B82B3A7AE9222574EC0BE109DF919422880F68AA051BDF3FDD4A112521D8A5AD80B5BA44385D085ED5BF5E0B475919B2391A5E0E3F0189F7A5BBEE0E4230BEBCE08352C4F01352FC44419DC167F38C7E3629450CCFF066F3337C363FD3CF26A588E167BCD9FC423A15B4E8E944538A187EC19BE8AFF065FB957E3629450CBF22CD267133D1B19A0C68CC637C092DEC1E5F82BB125E0E23B2691A93575D5E2A09480BE64EC674E3C4CAD7605DAEAC3BEB61444FF55D4918380FD291EEA2F9BA6412B756DFF534171D7277DD70E035712DE4BE38240D1C6F81435E988BB4397318EAE93DBC1BDCD4C64089D05E88486A5714C39D855AAD87E007146218E15C389CA1DCDD372C2C9C2B175339E7D357E88027E28DBC3DD5647DFF10609823FA0B20F38E75D0C166D7045F2C8126201671023C96F107F414346E1ACD34ADB3DBDE94D3C26648E97850E6DA24A63C8CD41FE641DAE63CBDE51E7CBDE30A0FEC3EAE87069B983557CDFB2F033F589A2503AEC4B4A0A2B8C0010A36719D972E19BB0E4382772D1829838371DD7D2CE76AD797EF7327EB013B12CE0B70F30D95D7E63BD2FBFBFD04EC45C7F2C7E605CE269E4C0663A302ECF45A5A8E67EE538CD0C1432C156FC631E7184435CFF363F93019DADAD400297DA50A015A309361812ECF302AE61889A5D65908F51C6B2468494715C95655C7A65764543EBBDC0AC618C0102B8B3C414C1875C47098F715913AB0CA6E0C357A78C1C6A7C64296CF54574DBE807B24CEE49F8934735CD0421079CCA4B121214D0F87D69A2B9AC30159C53E0E3334E232D393884DD436F8DC6B2CA140C22945B41D99895122334661102C4F3C6F480BFF92C328BBFD6012FC72737AD18F030A58B0A7C79E5E0F4F2F98E78723C7CE4CCE85918FB78161E4DDD56034BF2EEA4D7215D9FBE9BBB53188BD90196ED2C467856C9C15CAD685A1AE299694818AE9B61A31350BD6FD61F9E0F7A59AB4ECBD68A4ADFBF39AAEAB24BAB2EFCCBEC8A62B2A7144E2DDFED9494ED31C62CA3988BB3D71CE4EB75EEE8923A6ED764F1C296DD77BE248F95D7ECFD701B9A8CA55A2E4D226E26D78093CCE9362000FB1A418C0A31B29C617040C602DBEC27890CF6E14677DD9EF92F9771992EBC35AA9E4DAB1562ABDAEAC93FA652F52BF524B4D0B53EF9FAEDDC811DE3FA5809663E15E73DBDB0F44B9AD969D49762601158A77E2D57DCEEFB2DEE1567DFCF020BDF427D1CC5DE8921AEFE9A7F57F7ECC168D2B151FB80E83F943E0551E5FFFF7C7892EC2D16B3E68F8D1384842A7C740AB4BB776B0D59FD40F78D76FB606BDF3877D075E441DA3DA3117FFF571F562EBB16EFEB7AD316EFDA06E6C3D4209ABA560144D28FBE7FD030ADDBD7B8A98424B30A02BF334B04C99FC968000917C362B6C56A8CCCA4AF762599542B7355A9542431A29C00D1363A004B737425F45D8772BE129C3AA642485D84724920E6C537943FF554D48102EE1A47C14203412BE157EF2249C3809C17A7818FDEA8672A4F6C94C44086883700E07F9C57D8ABF0589335B6B170058BABCBD1B397DC680BB09B473EB3A08131FAAEF289E65F94C02002D88166E2C3C4CCCF3C54284D2435D6E0F328A45A26C478C3A52A41E9538E486E9C8A9D31190DFB8494B5A1D4C236A52787A6617BBAFCB5EFAD291EE2533A83524186E4431F4BDE4790BE17B49F4E2E523CD042384E0CD041F44C61249A3B6242C71FAA6B7E42B715AC0B7A42B712C673985D8B2E988EA0CC825163A25BBD3B645AD61DC6B9B172C779287B3BD14FAFD5331A9F46B06352F64AB7C0929A194369358D18A03E1DACAF391627AFFF454EA076B5E2FAD6BE415FB98357C5B9CA0C265F0C3B7264C7F33CFE2CB5D08E72559581185E5FAAD58EB887A5BAB7D340B7E3C0401385072EE38595443FD833E910A2DCBE7983C3BC1B57E153C0DB9E9F2EECC531AA621D5EA37BCE33C7BD42C01B97AB479D71DDEB556B88E2E8A5F8B220BE50817CE69321D2916D3BC6B0A54D3DBE98892B6DAC9A61FCA376FC452FC1008F992F3240E90C0FEF00FE16CDF4DF0DC428C705CBFBFF99E15391B7D200C67368916727DDED1F0CA91C0B90BCE10303E23607C41C0F80AC318284DB8E615865ACC7F0D4A8ED5FE7A648C63DD2B99EEB2820C9FAE7D7F1E18499F2713F24BE04D07CADCD04A19C70B5A01DAA16F8A447FF92B82DED2429AA2CE68429A22CC68429ACABAD184345571A309F9371B42FEDD8690BFDA10F21F3684E87635B45226C2F5C8B7BC1642BEE5B510F22DAF85906F792D847CCB6B21E45B5E0B21DFF25A08F996D742C8B77CBA19C9B7BCB7706094500100CFD329CAB728C7DE4C3D4B8D536E6462DCEB7814844D1DF5505AAD5F946F7E319B37ED940F12704689E3CDF21DC69BBB477543397563EDCFE8D680B722320DF1D6E018C57B77E0D80AFEA60D12A19D97567D6EC8BCB755562A9B2F70B3D502EE527EC744CB6F5E828779B1D2D838794CD6A9AC531B75EAFC412E14CB1804BEDA9C86E5A1DB2866FAB40EE5D85269DA1E74B505669F2C0943E93B66FD9AF2678D3E4FE9596B75BCB9CCB6CA31949BC2325179D3DC724913998ACB455E07E15C34F17CA4ABD03269E3E5FC7BD0584D89E154244B054B7AA7E458A61D1949659C47C1138A223FB413294C0B981674B031BFBA517ACC11606A720888C52941D8363CE07B43590FB2DE61BDD35DEF640DE6AFA59CEAA26133C553C530D33CDB18B61C91E2CAE2C663352891DF4212CADA28A6ACADAC0FA5C8E86E7DDE9A4C86FA82D3E61B74713A7F3ED34FD7BDE3240BD1E2D2E088BA8A67AEFA7DBACE8945694F5B8BA0FF44ED87215105D177B8ED70D811E91B75ECCB8974D16218BCBAA5ABB2C8045DEA7E86AE437F7564DBC9471C295DCEA4E2486A3D948A23E67A7D233361A1EB93A565AD245953416B59F45A682D8B5E11FD2ABEBB7122BCF12C582C4AB7D49009D417CC8E42D78232FA877A2D1BF6363F74402F47319548FB2CBFBBF1ECFC552940F5EDECBC61BE38CEE9157BE525BF89D09536DE2F164F4F91B5F5924AFBBB1FFCF0748A957EC7F94F5E2295F92F5DFF46486CE64F41186B07C9823573E28D8F661AF7D5501BFB180255517010A041E079D2C97B9CC2E16EA5EE5FE64FDDA8A4EA2180E78B851461F91A565334BD1FCEBFAB99DBB87B9ED0CA3E279E523016F5E77540EF37DFAAD97B15B16CEAF18076A229BD287EFA256DD8412FF09F411266D78E597C3951D97C74F2D427B345246A53FA7BACE9E1E0B7E4E0F7EACF5BC1EF4BB14CAF2D30097A17CF9A04BBCBCF1E5BB50DF2EDA3C55420DD6BA9E0A2F48B42D71EF10DF3E93B8FD558E51CA9DA01E7BED20C05E9632824C457ACBEA0310CFC9268353943FF57511A0BF6EAD00D6ADCA7385D24B2E737EDAEFC8AAC577A3F8C910AAC201829C22D04DB393FF035D7C51B3427E1705A2D2137D9447B7768BB0F395F6062796A4560E11538F01B8D3A75E4A368D1CEB497696F55F387EEABA1C64F9F34D2F4AB27AD69F854E25E1A0967A291EA32FABABCAD451418D5C66A49485DAE279B6B663044712D00592E1BC7DA9CDC8DB0B9AE9A8B750AE562191B39651CC562734E6DCEAF14E30D9652663D5F4DCC7A15C1C4BC6F23D832F3856470B022C7D90B6128844FDC78ADDFCCB67701B51FF6712923F7D9B753F858653A66B385CA637ACB9E8BF0E5986A29FBC650F10895996466587B63587DA952856CB9BED037BD7511DBC6C0700E01DEBABE3B4FE645CB02B2C0AF7A4D2B7206E18D3B77E9F047CE8C56C0B9E364CD2D2825A8B7200CF1E3F806977221C2B87C855BDDBD22285D8B526AC767D2D8A1B1E5D094C8A4FEAF10CF66030AE2E2D44035CF016248732D7A3F714D54766F44979B2F18C2B91D84A336ACE4AC2939885683A8B17DC46838B67238DA97632B1C5BE1D80AC75638B6C2B1158EADD4E2D88BADA0B542CC2F2CDDA8B4314062EF85BD9706EFE55A9911DF718537F423F59F12D33EA67538265ECD2E1C5B91993AF97BF176EA06D2E2AED0DCEEDECEC091EE72E5680DEB3B7BFA6E2443379882545D0601D2726B086BD5B4989DCB56EF01AFAA5F41A58765704777E5E3AC4EF5AF8EF298D508E32482BD2EAB3B567716D4DDAFD25B989D10C89E34516EEB276DE9B44CE25E685A267A3F7164AC1302F070B0E10D227C208043AAC821D52EBB950F04B0F53E0EEB1D24A1B71C0B4F4646267CFDB8911DAF3E6ECD41514FFD6FF0B719AB1F532FA622D86BE18A9542144E04A859D69D8CCFE7743903DD6D64504EDC989107569DAC3A9B5467B4D07DC07CA93BDB6499944B192BD264A64977A21929D646346B4E53A47B35280CF045881BEFB29728F57A10E5F569CD275A8B2F5F5E4B761F55D61A9CFEC8362B5956B2CD4A365321863A75AD7F0C546857E5851A3A47509719CA7ECABE53D108F59319D02144BDCCC63F5E489D1768ECEB8AB29F5782BADD8D7886D5B6565FB290390CE436C26207915B39759D75461C63F175A913D6E9322D08B6E63A443B51965C876027A69CA658278A9C930B4236DFB08123C34E7CF8D7205AB8B1F0AEA5BC142B5D8A1E312889B9739F6784159F811F255E2CF4C5B2B4AF549544FB5669EB6D25855CC027320923912AE15B19CF36AA254CBA26A6B7D643695CFAD2385039AF3CECEAEE036B59C91918F670ED78B8CA4D7475E5B8998B9B3F6DE8E3969EB6E5E47616D909662F6E6E2E1BC1CFCD918ED7D1D53BEBFEE9C20DE31978B395AEDB343C8A908870EA8AB62416D2C1C75C58EEA6D82AFD60F70ED953B1E6432259B7161712454AB30789548ECFB4916923D34663DAF81004F36BE164B72F9A71C732842181DC84B0C522FBC96DD37619CE7E8E61E5C2BBC5EF8998202B5156A2EF5E89C2CA776A901054EA1ECA768CC4B743828B800E4B45B16A61D5D2AE5A00BA04A03C6C6B0B0CF5B017EEA505EF27F4A6259733FEF6DA5D69ED4E98AA6B3DCC8F53817260D620DD0554E935E6C26CB04C0D9642BA13AFEE73BACA1B88DEC70F0FD2CBAE999EB90B3529D27BFA2937278FD51F5E87C1FC21F0D6E6A6F2DF1FC74112A6F747070D3F9A88F059C6E6B6755D5E67666057CF1B5AD9CAF3B64C6D0FA11D81F662747B562C12196033B5DA798D0EFDD7F36779EE0B6F19B9913E2BF6201741184F34B4C9A26D043459C5AD80CD4A06311F1C06D3C4898753D8A2CE615A96344E595A2EAB853AE2C85AB79683CED01AC9CA240DD46A780EC22574D8058E95418F93EF58E32E41D91EFA19E2D8CFEC2C96208A47A1EBD039268AD1E8D353B442264A277A234580662292FF5857FF9B91EC142D1F37184C6BF84F70883338C46738C41738C4578EFFB13B4516FFDB665738A44F2B7638D3AB9807EA7E97CA5D2CF74A305585700CDEB2BC659BB7EC8508F5DB196ED5FC694367ACF4B4AD80C28105518B96D46107F7B365ADE42D28B1701A0F1EA21CB8476D9A79E3FAE0D66985570EADD2EEE495A39CDDECE694E31CBA4D160BCFC56A08D82CEB42C4CEAC7101A2BC92523F561CBD0BE518A907C00B6B10F8AFEA5FAF45DA1D80CA9FBB7A5BB8E1B27E53363F59F2D7F01B1C094FF88EA414A12C8BF342867EEF4DE91D7E7A09EA35AC4415AC08D19BF2FEE9568A2809C157A457C0A8157F45989598EC304AB5325DEE4069C91719AF5C36E9494711BC82684513395F1893D456646302DB09D916B9C562A5050E6EB6AA85CA385696B1F601F1E992F93AFF26BC443E08FFD9DC03AB874359D155386BF5555AA08EA1D055EC68099380187FD9AFBB09C62242D3925548E4C5645B2FBED30565A06451FCAAFDEBD8229167B81556E950B3655F7EDCD61257624B5973A8A3D92D874BD4F531178EB382B04B39B1EE65BA0BFCAB3767A6B7755A1E03AC74E48A49CE17D0544C56144B6DC964E5178F6BFDE7CAA85C39D9F0B3556D645140D9F4DBA2D8B2C70BAC4B3BD231D5BF43A9FEE3B16C42AAAFB0E357756FB0EBA7752FD0C7B8953E879979AB1A0A0303D7C7D220760AED5ACB45D4E77325FEB42D131B1236244486A45D09430DC966257E17A363AA874BFADD5011972B2FCD34F10682456FA3BB58AC9251A2D2FCB57CD6EBACD759AF9BEBF5FA1355606A5DA3D3DB58B8A96F70D6E10DCE1E3774FFCEB7D8FC658B93B0F573A8A350C6865BA833B8893AB36CA37A5947B4D301E476EA8C0D151B2A36540686AAA2B629357DB3CDDA69188CF31DA19CBAF15D10CB4B691A15AA6098663E3631AC95F5865A287DCDEA8374A4BB88A9C59CCFCB77F95115D391E163D5A1A0A8125D2A55A90C3651FF422909784FFAF23566C6EFF3870F2C734EF56ABF4F63A68B7E9553B02E5218605D9463B02E625DC4BA689FBAA857964BE8DE4269C98B61966B05609AE5AA00347F32CC9B9A57EFBD7B637FDE9FA7D5E71B66377D49995A1CE1A475A4661FB306C9F0ABEE40B2651C0AF1E0FE71ACFC69A8CE3BB02028AAFFD28D9CD1DA3947FF741A9FF2C674308D1E8437EEDCA51BE0C899D10A38779C8C23534A18AD8F8CE09F76C26142C368BCF41D2A77E817F729FE1624CE4C86CAC0BE0CCCCF5AD72019DAC01D48B6284E750469A016AA5B5753DB70EE8A242AAE05EF251CAF05AB8DF4E436DD5AF205E3CE9FF5A74A2BF8C9B6734990322C8E5A4BA5E6A2E8D2D4BBB84AF72D95283768ED0DD282958D1A5E9F3F8E4518AB8F08F611933054F33756EF263C285886922D21E0F103F541076542B9DFAB12F4B9ECE9BD0F1B0CE79924E799DACCDBAE64538D217EAC7DBC9278EAF8545D12AAEBA3068514258C5B112946B0B3C86FEB978F3B78D2CED76E7CACAECCA2F3B3D09A8BAD4F07E67A2B7E04237A1D69161ECBDB94BD177AB63908AE9C608BC6160D66D13205AA3566170D4F60D79AF57B2793B817BBD6F2CEBB9F31B168BBDFD7D09C6552E0F62CC3811BB4358EC58A42A3C889F568C88135B9CB5F0D23236E2A39F361515EC34AD005CFE73ED1F00D56A4241F3142540229B8910FA8BA60C9DAE154A421CD253C0C568C4AA9ED2482414D022C2D360EBC29261652F64243E5C9E046058BD4705F49DB6A656838017F40FB756A1014CEFC20A752CE25DAE72DF0903E710167EF331712313E758105FEDC0510CA27D7EDECD2E6C32335858A0C429D6676BED9F9B6E17CAF63A3FB89AD36C794BBC5656903E9C8AEB7C10BEF0EA11BBADEC5ED2AD9D5C47017BC8A0777C5B7F16CB9E48041F4F1CA0BEC5FA598C2EDF981B9E7D89DE30FA69FBB59BCA819F32E997F97A136D0947591F99089AB2FD1FCB561B469F44CE94FB186305C3FA652EF914A014D6CA6E1F14CECDA62E098D8AE1688D4C49EA4193CD2AB583AE6CD2D9AEEE2A610F03D2A42FDB3DA0581EB481C95E2460BDDC31E05ACB42D88CDB4DDC0BAB29A5144FC46BAB65F0BB024C6C2ACDDC73A8930D32E5F44266422DEB219FB442FE28C5EC4677A115FE8457CA5174126E14E526FC1EC8009ED39964C06461DF76026FF4C24F168531918A32DD905F04DB9964AD4145B96A1F49DE6D3F12894A6CC1E2C10A89C5AD878AFA5666A1319CEA1FC3287C2588B97D2735F65A84F5344CD97C5A0ACA3AAB8BBE1A0A5B60443E63739731DAFADAF03EA2E59D1722487620B184AD1D122481CF7911CF7B19442AB260ABA547356E31E8F2D70BB924C7D505AD24EBDA0081251F7A1128B9D8D2A81E2C5CB3640F71834EB351293E4542AE02443739CA1E20C15344355EC12CE50315339EA0C5549CD23DB5EEC5C552F83446F7BD93472AE6917CED5DB22BDBA1765504D37A89B85680E2CDAC3B92FCE7D71EE8B735F9CFBE2DC17E7BE3AF21E8BB92F0ECBB3B37BDCCE6E212ABF4A0225CEBC8D097775EB31F7E0E99A0CA44F6CB28CCF8E34C7984F27C68C77429CCD2E9BDDD331BB5821E67ACB816776F71A603E79B3C8A722904C79B152340C740A4E36FECA5EFD4994056E01D24F0EB338667127C7E2BAD7346EBBFF5DEA1AB7D9CB6307D85DF58D26682D758E4690D07AC7BFBBB182F62F8429F95D031832DD2A40F37AC1A3B56BA97BB9E07A2D5EFF3B7C7FF70D932CCEA7D3504611B5A5523A7C3E0A42609B40EE29CDF6EBE0ED571FAD7B132C85A7FE08BE2A701BC8500BD703D90A320C92280EE608F1841C07CE67D1AE1CEC2997D8C51D05AE1F1316AE1CD4158498118D03BACCB6782FBED970B5A01FCA9FF8F02E4F14E194FE866C2D05AEF70A3B00061A46BF24EE74E009B52A111A8EF6BDB570B76DC0B99AA52565381C50731E45031AD79481903E0C469F34FFDD8DE4586DAA6822E7A677FF6CE118F2975A1C5BF4A50359C0F8E4D455B4327242F51A6EE399769C9ECB0636B9CFEACCCBBF572AD16C6D6EA018AECC1A145BEBF242F82FF0C654ABE1EF25525292BF9F5009F9C5F1A3201A04FE93FB9C8402E00A6EC2982ED71A185BEB1591F9DF056760967D177C46C0F88280F1154840D390711F8C9EEB571FD9717DE1156173E315BC0164BE866B808E6D1517AF3004968F0F47F4E6FCE2EEFCF68A5C8C8E25AE67834CCCE8F74B72197F0B7D4FADAC19B9200E464B0E46AFFE5CABBF43E53BDDC857E9DDB8516CAABB2B20A67A7B0BC45A00FA540BD12AB30AF605C2609A38E08A99F580D27F227368399FC72AD4B60A05AB4FB0EAB4A936D752F7131B58896F090D7CFA99EFBA663DC67AAC5D8FA506FE3C8AE45CE1192BB30A8AB146DB42B1A7D690784E0AD3967022528D3D67AF17DC21BC92CEC8C3C7D0F3B5A398F65EE19A77D4426DC92B1D444017A5DFE5FEE9568A2809C1EB914D229B44AB26F1EA2D96FE54D9927C0430D3B8890633917568B64CE5A66C1C3FA09F4C9CBC6087A5562A8AA17AB79108A58F5076D8A63ECF3DAF08564550253A8C1EE49F891BF2C5C2ACD68F5CAD67EC0E55B7A790B80A7E0579640E11C464F545EE3847AC8F581F1DA03E42D44388FAC7BADEA15318E9ABE80F4BBD123342674D1C6B2CD6585635D68DEBBFC014954680E9A702E1C8E85069F43801D5CEE26C78CCAC89581359D54459B7BF0BD7F3D4B414C10D7D2604A69E76C2C2745623AC2D45B6211EA5D8A8F4760795406B3B2AD17A300C51CC19B59C5553222DED93556976DFEDB325AB895460D22C4BFFEFBD9F9F66238F68CB8508638C0E5803A57B9E8310EC938D93EF04506778B1258D82A023FB74BC697B4D9C1B615073B323E1BC8CDD7FD9E2B3C379A94BDF85EB8B70D9AD8CBEBD04570DFB56C6B375FF7E32AAA884D1D6C2A69742D18A387F552CE45992D62B8C654A58685FE4F799F25422F530AD985BD777E7C99C5648BA348BFB71E85E45BCE957B125C7E2948DE81B816E4C9E05890FD91D7159C132B110CA92A25CC4A872C70AC131827327765FC1818C61742194E187C3A83FCC83F2317DC088127FEA21BCD97528E5308A1204A8CB502CCB16DDF4EAD20CC6C26E1A46D91D78F0571F047EE43EFBF3520508044C2913FD04C227198CC19FC3E97006B76D1C134DE5A02F3356DA4278709CBBC0BF7A7366C27F9648B38C122E2DD8372AA5BF15E1B3EBD3132E6239A965FF6544865FDCC07A23A7CF70A72C6D658303C53174C931F4D59F5B63E81801738CE8F81E727A7B39D9C0C1670E3E372D4AA4E073CF55891C8DEEABF4383CCDE1E9C30E4F1B764FE07835C7AB395EBD4308C7AB395ECDF16A8E57EF1A11C7AB395ECDF16A8E5773BCFA94E3D5F7B1BE831375742924E2102DF57EE2C8BD7C8791FB0F0D7721164195DA2B0F8BFFF8B8194AAF5C65B8FB57ABFB048B2B0A1B7E5ADC66D875E0150D5F3BFACA2F9A5FA1E5A75BEFD1F6FBBA97E99C3F597D1283BC493946D6375FD23DBE8697272964EEA5E15F217CE2C66B06038B4DEE27B6BE7A9125F49E1DC5C163E1682F3C0A7CA497693149FA206E5F75B6998ACA0E9EE4B75036E78830C65C95D79425C299A3AABCA63C11AABC89A2E48B59E0DB4FD7E403B80DBEBB1E82F44EC2AED7EE1595A4ABB9703DF2AFF720176A9968B75FC76DAC6CE20D91C301F66552759EDE52DA7939E599AA970A971DD40BD2519A8ABC26F54221AF49BDA0CA43542FDD04DA512785340BFA64C5D8689280ABEA84C6DD8C72C5DD4A54353E45256E1444B168EB328D226922DE86979F60F44661DC05E4952FE948CF10464A5E35938EF433C248C92B6ED2917E4118E9172B23FD8A30D2AF1646FA209FDD28CE6E14A3671A9B026D708EFC9EBA6AFD8571946EEAC637EEDCA5CB4C0F66F2CF44DA9051CD769ACD483EB9FA462C8410A89A5C8C41B5478071165616A8BA4822D75764AF1C31A835818834659ACB8EC805A679F1811B3A58619D346E0EBECE072FF38003A5757EF355D248AD7B7E5B78814068E77AE105CE0BCAFDCF49B4481BC01D4ADE9213339213333B0A7157F90A8A0C4D91A9E890A12992207D534BE9DA6E1EFDC64F6B465EF9C5EE51577F663AE2E2CFDD06BDFE75C3B88B1FB50F7DF5CBBAD1F74E2265330AC824AD4C9F693AA9A3EDC4CF29A582717C7C086D68F1176802E87C97149BBFA3367F37CF51B18BEA2D5FE907BBCDC7CE1F6D65F477FFB26F6142F3B08D4DDECE528AF6D176361AA549303119A5C74D0CC6C6E35C82C02508A7588260B90281401C798690EB0FB8FEE03DD51FF43ECCCC05095C90C005095C90C005095C90C00509CD23E582042E48E082042E48E082042E48E08284AE389C91919C91D90CCF772848D8FCD56339A750CDCCECFC5D5D7266F78FFBE6674ACF36E6F9CB326A9FA94F33D5FC742BE7DFF67BFC4A0B60B6ACE905DA4B2EFAE49F46D0CEA19B188699A82D0C5BE9A8D1E9770E3DE58E9E23EEB1C93D36DB78779F44773314F7B2EC9250E65E96DCCB927B59767B15EE65C9BD2CEB85702FCB52E0877B59768844712F4BEE65593F8E83EA658913314DC7F35A3267A64059E2A52929F11529A5C7BD3277C9E15E9987DB2B935313925313BB022A7449899A18787B06A3EB1BB477B3DC12B7F148C35B54BB55B6BE47F5E7A0807E758C06D1FC2DDBD43794DFD3B8E1C5F12B82F772B6A432829680349F4264C3C286C5F0103E62A3E14DE5DCB531B169BA752BAB6D9671B576ECAF5B75148EBAED54B337083C4F3ACA547CB25986B9967A29759C41946348F68477ABC7C73A6E5395BD3AACB107D94489AA4D39677B595267DD9614C9CC9EED71459DED71459D11AD28A546537BA1F86B7A9CD68E92DA926AEBA0DA2EC1E427D67609263FBAB625D8E222DE946D475D6D49DDD7E23ADBD7E23ADBD7E2B2A9212FA548CB03360F3218B0C27F4A11DE3F15070C947737D706A69C9A3173F0EE82FBA7ABF9C20B96524670A85BE1CCF4088147495659B2FBA7DF7F9DC0C086BE13CCE544BC5DBB9E856F9E850B2E9679F859C9589794911FD128849F3B69EEDEA2E461F44DC4E5035D8360014E413641E2D18B6824A2681184F16816C441041DF40E34C4F10E2E2F07EA0FEE93EB088CBC7B058F82C04517A1F0A7A863DE402419B5E6F1BE74E465E02419D3852FE9464CC4B1DFB88E3610936038D78B113AEC5D70982316DF515748058F66553F0C3096C4260CE2082FB5EE74BF27CA3BBBFFE1EB98127CB88D988863FFC700753994E14856C3F8663C1CDFA742D006BD854932724E3C70E2C134F1D0BB972B24486FE762400ECF73789EC3F31C9EE7F03C87E7393CCFE1790ECFDB14CCE1790ECF137E730ECF73789EC3F31C9EDFB943393CBF63C41C9EE7F03C87E7393CCFE1F9530CCFAFABF2D36E168399F09FE5A58C85EB5D8A34706410AF6F053509E477026DF6E5F00E48D50EE65729A632EC3A9816331964AA0ABA61F35182BB2B613676EB24CA4AC0A7A07BF42DF90B49285AE1DE9BD2B76ABA933F2CF483F2A6567A29A997B122679084A1FACA4ABB382F6442507B1EA89941D2116B241B6A622DCD8AA6B87A7A924EACCFC2A1ECE091857E4E0F741D20B0C869A115C1CDC0DD72DCD8D8C4393202864833E3AF11ACD9AEB162340970D8EC24B09360E62420BB07C88EC181B804EC0CB033C0CE003B0307EF0CA49D21E993B14CA6994C775A8D956A5BD3768D28ED4E31D976891FB43619DA993DE8774934F37BE6F7AB3F77E3F7E568361ACBDF0C91A370FD7E71773CC68FB49DB0D8BD26680335F20D1A6012C540B22447CAA891E9C9AAEEBC765A0D4C9AC59B8431CD9EBEB9EE06E1E6BA49F07C774FFDE26C31D9629A594C645B896C25D93EB27D64FB8836AF58368D93396CBAF663BA6E5CFF05C1646918045355C0B0893A8C544FBE258BF76BCAC1E0A47B28E3F15C52CB0AD6B282CD2443F56BF6DFA0EA758D624BBB222921BE9BB533164EAF93AD54AFE1706A92AC8679497DAC8C3C4BA25B26882665862626486C8849149158D2CB499A8EB1E2C8B89A7F979E1BCD5ACECCE208BB76E965FC2AD7575E9209C99E251773ABD457F92E3B324177D2A14F95E646AE3174802429B38ED78A93A59720118B1BCF8205BD90E61BB891847852BED28B99C837820F634023B3AB22EF028C8ACB2A168C526E635926967D0760D5AD3BD5C8025279108663805AFB96DD9E5BEF62F60C6063E507D023E3C58641D0697B0C70B757297E418C967060A65DD6B1056656FB00C596E258D13DDA4FB69CC71493B7A4FE0EC4B8EECF641592314C16A6F963BB74BA76491F15C9AEC7049AA63510D03A5581382F7B183620FD2C3807F04C2493A568E90F995939F975EBFAEE3C99D30A7990F7E1548637F2751D4BA612F28F44E4FB9656CEA8D293952B00D8A01FB941CF33B2F02AAB3212D0A46F20B14D3F109B8E94BDB7137DC400B4D0EA1BB3EE999E9CA4EFFB0BDD5163DCE33C6C4BD9965AB4A5FA8F301BAA1160B6B340687E51F440AD168773F1949969D352F51FE04BB3B7C968391FFF09E9CE1CE7A543DF2E9C9B2F586FB2DEB4A93775207F10F8AF32D40C02A641AB58305DBA8D6539FD05AF4B8E9CD05D20DD8FB7CFDA87EC33C4D7425F18C6C1BD0308EE615989AD6A1D3E50C89686C2D2CC03AD07B34ABCE8DCF3821F45A0263237390DA0E6B6A705D496112A0FA66B82EDA8026CABB7C302643DF41EF59042BA13AFEE73BA845AF7D0C70F0FD2CB36F3CC5DA48CE0E9A7ED9F3DB62BAD0FBAC1C143E0D58A697FFE7122C267A94F920400907190840E86628616156CEA2988EAE57202CCD44336A7FB8A0E65D2F7121B1A46E7491C9C2F161EF8F2ACD58B748BEFB55548887047C2A1A548CEDFA169DBE6E136F0A7023C09C36892C80805E87739F591A02633E5DFE2405D872E0ACE581FD8C2414A703E5CB600B2C582B40870C0560B01696CC562C081CB16040E56B12890D012AC0F9A2D8D542795E1BA2A97EC71A5994C1ECE9792B1F0FC7943E9ABB5672C7F8560FAFEC572359F8102C17004D90A37169F3D6E28BBD811C6D20B0053F90968E5678F1BCA1E89A5CEB3DFCA78164CA1846218A93FBCBAD3B5DF64AE58947F51727110D0CA393373A06FC24BE4836E5308D67759743605A40B018B377A21976E945E176E47CA88BE89FE2870FD382283B7942B5613B6F0C4F256465169B2C8C40D44347365684B1C56DE61183D88A7270F0167E83BCA04CA7FC4609ECCF143C9F1C37E0981C309271691405038B1884942E747CF7EFBDC6C3DF15817AFAD9F972ECF3686583B01D485577BCEC745B2FCDF4503AFAE33527EA6FF9CB43CDD6556DA2090E665DDB8ADCFCCAC9F329B9BC6E7BBCE4E3308D2FC8CB23A943E93933F623633BB1FEE3A2D0D08487352EA87D7675E4A8F99CD4D3340D7F96941C19FA333C3493A03CF521D82C134D5C220CC5381AFE87AD7292A3DD27F769A1FEE32312D080873B2566A3D66A5F250FF79697BBCCBCCB46220CCCD2F32FE67FE8F5D67A6F448FF79697EB8CBACB42020CC49AEEDA31EAB257FC468A9343EDB65469A011026A4ACB77A4CCAC663FD67A61DA0CBF47440C19D23B32982CE10CA0491CECF248875E0ABF3CCA4BF379A935D4F769C8D9D8FA3D5A56C7B9588C582292066A1E00A908B04914A61300A2E38AEC7713D705D2079B0AA2980D72BDA85A5732B912B1CAD5B8644D2BB9B90AC799134AF9A58AC3B0C14D43F087BC3B07E67FD8EA5DF6943EF1D747CD7E83DA6962FC5E1F1F47CF55616244DDFE7AA17D6F57D1434DE253AACED1B45B1B63F2C6D4F9B4EECA8F1BBE52431757E1E0B4554F8A3F5A979246D3FEA7A0E9F557D1FEDDC795A5B91509B0C28BC87B28AC1361C6C971A45B15D3A2CBB3422AAE4E868911A1028CC51B9AC03CF246DDCC38864967ADDEEC8A6A98F8246BC3893D57DA32856F787A5EEA90BD43AAAFD8E656E44AAFF8C46F79FD128FF0EF7F1B2F637D4FEE0BB8E59FD378A62F57FB0EA9FA8F4B6BF0168ACE0C5B200E55A301CE55F4244D2FB1B88ACF2B1FADC20517D4A455F3D946AD808D4DE19DA42D4F95CFF2F9B3F367F758BE4A0CC1FE5B18A0E46AF63593096BDAB9EB1C0B178154C249BB785C9560FC9EAE165DAD9EEB1DD63BB77AC768FFAE05C07DBD7F9F01D96F52B9FA2C3B17D254424CBB781C8760FAB3DB38C473895070A09B5F240E191561E287CD258A49A58046BAD602C1AEC9234B6D98DA2D8661F8ECDA63CD2DDC15E773C148E65AD47ABF3D248C67A0D8864ABAB806CAAF1AE66C0B0D3A8469AD442B327CD9E345BE563B5CA23B2A6221D6C723300B649DEEC308263973750918C730D2A5B68240B8D592AC3C68F8D1F1BBF63357E369A477530833D5A5011D8421253486209D910921942B6836C07D90EB21DA4EA10D8CF0ADA338259BB4034F397C2E119BE151C9B3CACE82CED3D29A767668691FA82DF5D5F4E0B11A09B88DCE97510FEF20D8AC5C68F8D1FA2F1236802DBCDE0B5F690059B3AFD67A87DD31850A35660D8B26415C1FBBDC157CBD57F6A1AC1CF24D7F85ABAB60BEB622BD6EAEF51ABF7526B4AA9CE4464ACD1F2C74D9559E9716B7AACB34C2B3C3C87D98B42CD65B7A8529A0BD1B1FC8F02672F135808C799C1B68F15C503B5C443700BF2CBC049B64E7C0070EE8286773FC37877A57364287D47D28B2A5E0A45838F93C5C273E13E7F8183B3C8BBC9422258AD04258A881DEED30B21DC496A098324D4FB0D6EDD721CD27AB9F5C1111BFB632DCD8AD6CF03B836DEAC9065E3BD4AB1693B4AEDFB9EDEEECCF2EB9DD978BF114E496E0ED332436754C1042DDB8A95BB106D96BBE33BB689899D592343FA4242E5AFDE166EB8AC274CFB4B72A3D67B57C0F6E22F8D84F33276FF657FA38CA5E72949A3D075E84CF8EFB3C09363F530AD18ED43D14A387F95A162985A101DDFC95D94712CE2248211B461741D4A398CA2041C6C1CEAAB17175A07C1917E5BDC04022141C661540EA3DA0CA366892860303503018654D720B603AB5D25B7174EE480BF4A313DB9BA89F71CCEBB71FD52240FE43B809759748161B1DAA9378A5EC4BDE2406D2D0D089FC2CC0180CEA1B91B711F2AFD40E94B50626BFE45899F85E0487B3E0C025FD1DEF85A38CA829049B9109EF01DDAB922F70FAC7853E7AFCFA40E0847ED8D3E7D5E9D5488231334116FD9AB7CA21771462FE233BD882FF422BE1E71360833E0A006E117782BC6E0FA42F387125D52FF58CF972C666F738AD95AF37586950AE520030719F23F370519327F181864583BD580204357CF1C3FC8C0318146A4BF05DF079E883A9CEE3CB5D8C241D6EFD824CCC462EEE3990C07335D4D1F9EC4B11F66CBEF8A2DAF441C311FB7146DB474D84147838BFD9E9D1EA59AB791586AD33091E11C7CEC318352FAC90DA640AB7F4CB576AB4ADC959D4562085BC0E0167DF66A865734C17F0D5C9B45CA38150038C9F6071927E1F6A93493DECCEC09B327BCFA7393279C267E5072EE2524A04FBC8164DB31EE25BE730A3E45659FFB8832D237F2557AE049D6202DA5AB281AE8F8E20CE439E713C80B5BC8D8E622C827EB3412C31D8A8877265EFA1D105082A07BF9208B5DEC943A70829D13EC1C323C9490211FB744AFDE3C9E8A82F6582B92C5E462030EB11C6A8805A5E2602386000DB1ECAFF68083215C80D02EE9A00A10AEDE16D2C1D29B4D85FA666934D4E1A54D31D576C6C8CDE9669D7EE43EFB7A94CA8774575C05709690DCB52BD568D097689C8E9BCA6EDDBB72EBE82B41CEA74A0F2918BACD21B5CF402981DEF77D907F263252CAFF62494DC22FA5E7BECA7089D67B8E2B578E276C517CFC3C5DDCB4D4505BD6A117C8D868B767A5F0EB10AB586E44149F27F12C08DD7FD95049C3682D0D77EC260769392C24DF6158E8434B17F8EDCA9268672BF8ED10C9E34E886A2BF8EE4FD6B682EFF138B415FC3F923CA004AA3CDA40310C89D5A0D80A87F516DD5A6DB442E4E09A8D4A232C66425E0AC375248756A07090B519564A68B834834B3338867728313CFAF0D4A1553BB08BF61E5D3423F70494B5AFE1E210F7C47EB69E9D09CED4F70CD1D28B1C24511CCCE1AB516D2DDD2D39520C31DA584C804F87A3E28A383B627DC0AD8C67C114E15CE1097661E0260C4CDB8F8DB69F421386E34D261F7F26F4E8D2931693B7EC20B283D8EC203EC84510C617AE3F10E1D4D03DAC60183A875B18B65CC393F5E5B07AA7603777C175300A301939A1BB2897BF59BB8D67A5CFD1BAD40C2FF772836949BEFE43937CAA1BB5AD59C691C8B49835797C4B1A48B8A5366788C7194EA44D0075167CE853A2DF27C7DED4C29283835533C91E077B1C6D1E47D11BCED8DD28379733F235BA77A7C373344AEF4DBC24D2724C39BD0EE00704CC6ECDEBB31CD2D485E14A489F355C04AB676D399A1D055AF1567398BD7819B9EC161A49E3AAA1C567739CBD4C60211C6706F71A8E388E94F0919D134F0DB8488F0266CF431D993C4F5D365DA667BB7032DE05CE7EF4572E7C3F7E3056138002C7CE8DF4992CA419EB6066714A214A5056A6692DCE866AE7E2E5C3CC256F96475B98BB4D91DCE1AC9C205F88304649A4AC906C6893B5342B3C517D82E7205C822D7B8E6363860A5936E647ED30AC292A41D931DEDFF73451678833756679AACE6CCC15E7947A4DD7856863BB1DDF119AA9FA42E219985F994D99BE403D1C5801DB4B00A943D36C9A8D6225D7F7FB2CF0A47643A88FA5526746CF5F65A80833E9C5D7B81D4B749A751845C96A4E4C1370BA2D90EB0BAF51037DC249192A7F6181713F0556F2D12C5B51AF672AE7FC8C3EE985D215F74F4FA5756E3A9E3F7CE0A143CECA4ACECAAEFEBC330D07EA61524280A4E4ECF72EE925B6AD98257B093E6668251784711E1BC989CA0B50AD13D2DCA9B9564F2172EB43E9E261A78149BBC786E2189A3B686319BA2D8C8E66759177F3E14BB35A48A4F208A6475EC17832ED94ACF8E0E7AFCFA46EEBF072F809667587CAEDA33B9A3B2C92509422869F06229A21A4D115D4197C36E94E21AF669352C4F00C6F363FC36793EEC0F56A3629450C3FE3CD26DDC1703D15B4E80EEDC9763D3B7813FD15BE6CE94ED8AF669352C4F02BD26CDAA84B1946E34BF8F51DE34B6890707C09758115025DD38F31798BBE4B250169DD5CB89EA79F07CFA87A152C9C682EC0556848D3338E4518A3D4835EF953141C8C28FB78E63E2184EA1FA45AC01E541F6428360A93B59CF3E92B385744DE7A65184DF48D88E0615A28825336210E9C17E8607F5B4CD586585F1660BC5BC149C53FA0A151BCC2EFD3AB03E526B66622B81BD6BEEB8B8BA43D5A5A08B99AD752F13169D130564103370B965C0360B70600D4287823F96D5A0360BF413067EDDB91DE6F7360D4E399588720110FBA9D6633DC90BBE132FF3F36FE7F0ADD702DB52CB27EE32A4EE7F1A33AFDB8D5AF17FD0653AC369516BB35F46C216425BC8F95FDC08BF961E55150D2040797FC000767F14E5FA46E254E636B9D9738C49B7C398E22398E62378E927306482025878044524A10B642290FC10F704DBE5862580E629A9BD7B512565F602C78A594A5BB881B36E9ADCED0C2D9785DBC6A7FE50E5BAC018B539951D346528AF3012E84FF329C02277F26FF4C24CABA2B8A2A10CA143AD455E04C61FB211E1C3957693F29FDCFE4A2B27284E921D42360777F83BB286012CE5C90B960172E9846E941547015E73766821D3305C839B51162FB3CF304498BAA3DEC66B3EA0B4CFB2D50E3E818F577C060F5EDD165946E41E7D36928A3F541277B2D3E73C9677B93FC997C72AFE6CD97CDE1709F89F4E46216F8F42CEB36F8EE7A1862FA92EC7929F578E1FA225C7613DB1A5B44E9A3A278D1DC8DB42B3C76666ADB225CDACA748BE956FEE77ABA355F7872E8033B9994418C49D726883DDEA525233634C95E84ABA39A6396387D442CDD738595C63DEA0611A7D1870EB5718B9D862B36EACDB05AD0D097CB607431E20427B32CFB2C0B582BBEC92B002C6B1F15E35A3293222B34630F97FE1C4FC11B56E6356B363569EE1B8B423EA5E72A96B1CCC3E2E4E230ABF7514B41E9B9455A176BA1B9D7146973D8D8E0568A9399903121B34DC8EE931821EEB5420151B20ACA5147BED49B30CB3B8CD0175295CFB1C4BE2CF4E6E4101887C00E80A672088C19D791322E841858856140181747C10E921F1D5F148C43411C0A321350C4838E21E6642510B4875BE499013103B2C0801C4523CC994FF6B429E3593F6D8DE96422950E7B72DF1A0D15C64DB29930FD2FF072ED36537FEEC4CA06436B3DF32163E89E6D9ED385501AAC5DBD4D60EB5723C0D67081606B1D33CB4661D92857B463B2D13A9568F0F61B9724EF3F14731FBACFFA3E53ACCFCBC486894D8B71D0F73B1B5A05F5A8A939C81FB5C66794BCFD1CCB53825B880DCD793C4B0E1FD6E1195654ACA85A1495BEAFE07CFA3F4914A7340294FBAFC3325565BBB0ACE936B301B41704547139EC6DA32C009BD71B5DC05AFDF0B755866CDCBC91F4EED0B49C82520079FDC3D59B23A38852C2781684BA7B2FE934BDCAF0F7D08D4985D8A8B228C9C8BF4C2272754C2F71F5A52CCA2C3629B5484B67FE8EEB526EF3DBB24FE42260E4A2A628FE26BC847C4E68851C5A9D10FB7AECEBEDC5D783551DED7263E0BEDE1E2A90D8273BD824C9C195ECA4252AF4B63015931B441BA2283D8BE6738B1807212D1EEAA417851E29D800BC114B682FB83B1186A95A6A34B2EFF4AC1D333A667496185DF27DA0C6F71C84CB33DD695ACD4AC1177E7723E30C6433AA29CB6B47B5C5F736C44377D6C6CB612409D670E02BDE4A23DB4FAEB63400CED976B11E8AF5492766EBC1D6C39AF520311E24B6E3944D0782E520301BFBB61AA76D3470943DBB1C6C34EC188D899C2FD283E74AF6936B7A37D5068AA159A841B16507900A53729816158B1255CA45B568539C339258E6B1C069991F9CAB6073595626E8522E441863B4705B23D958446B6956A6098BCD74A4322853D491B6E04C104DA0C0C634752778E833058ED0F488A960CF555B0805E9E292D767E232B067D22BA7A9DB1D111FB34F394D7AE50DB1A0E2EA73D2C9FA96BE0AE564B1CBC22E4BFEE75A9765BEC8C96F9A08CD4AF92353CFA516CCD481D90966CB8F39B02A9549D09186A3ACE45FDC57E9E3F4716177B0E9ABEA0D2E1CFD59B524E0125983D19762B49755A39CE22EBD13CA723C91F2652B27128819169AA34FE0E761FA4170ACC5C243B8B41BEB86E0D42013DF4AF48912FC8C12FC3325F8174AF0AF94E0FF4609FEEF94E07FA504FF0FD24DF43319BAF6A6A07A44F1803F13F0D99B72C685EA6D3987C80EB93587FC412E8210D66E6003C5DC05DF4479A7BE3786B6433D6961AFB85F9F93AC9C093498BE3FA0870AB118708163273391C9B2930D44A2F6058E956C602ECBCA0471148A93C95C94C039F70EE238E77E6839774BA1660E0D1F94D3FD8F78F9335D18303D374C88AF474F1767CC464F1AC7FC992E90998D9E3450FA335DA4341B3D6924F667BA506C367AD250EFCF74B1DE6CF4A4B1E49FE982C9D9E84983D53FD345ABB3D19346C37FA60B8767A33FD6707B3A7A427C3D7A625B4B88AF474F6C6B09F1F5E8896D2D21BE1E3DB1AD25C4D7A327B6B584F87AF4C4B696105F8F9ED8D612E2EBD113DB5A427C3D7A625B4B88AF4B38886D2D21BE1E3DB1AD25C4D7A327B6B584F87AF4C4B696105F8F9ED8D612E2EBD113DB5A427C3D7A625B4B88AF474F6C6B09F1F5E8896D2D21BE1E3DB1AD25C4D7158DC4B69610FFEA2D5E9942AA1A2325E3CC828CCF16647CB120E32BB50C2EB2935C64B7FA736D915D8E7F17C4125667B705645A6A570B64ABDACE447A7744EE19DDA994EF9DF68CC6B87300A9B86B18A58506D0226F6BF78D28314DD778F42E1BA06D6C7022D51523E1BC40B7EA515F1B65E56EAD63BA4A07F52699B4B086F8E0E59DA4EED2B13EAB8E65D5309A8FB363C08E4177C70074074C3DFF053A06F66F7F611ADF19E96FC1F78127A20E1D4AD81DE8B0E2340CFA55286477AC403FBAC51B544641D44DDA2794F6266844E03488115FD9C2EC8BD9570BFBD27F05F2AEC27C001857370B84CFB5D2B76F300218275DCCF674E76F597021938F58E6517DBF5E770E86F7D90A997BB90AA010AEFFADD1941FF745006C80D800911BA01BF92A8DF280E98326EA6AF5A02D5D950ADC8BA24A25B396622DC55A0AA8A59EA3E2ECB591AE5A3F6EA4B1AA8F5BD35BCF117EB3C8BDE8C1F77171136B42D684A69A5021DD8957F739551C4D7AE0E38707E9A5BF8A66EE22CDFE3FFD54F9C5E35A5DB93252131406F387C0DB04AAFEEC7122C267A9238041FB6FC741123AFD5E60DD3C231D53FD3B943A6C3C96357EF51576FCAAEE0D76FDB4EE05FAD8A2D2E730B34655BD6E608FFA18063C8BD4B98B0F8D19E9DCD6870D091B123624757AB85D09430D49A15BBB189242659BEAE1927E3754C41BADBB0C3471AFE65FA8CE01DFECCA7A9DF53AEBF54A7484845AD7E8F436166EEA1B9C757883B3C70DDDBFF32D367FD9E2246CFD1CEA2894B1E116EA0C6EA23A745D44B55144778BECDB4EB535806443C5868A0D55B3B2EF62AB009ABED966ED340CA69AFE56B87E2C7DE13BF26FC1F7F328729FFDABF9C20B961270D8B213B0A155E8066CCB56608CA6D51AD509E102EF6635F0BE0BB331CE696296A5165B02BA5E0B9CBD102926064C0C7AE8E65D3C61F7138F9DCCDB6648138C57E75DC241A13E68C3C4E23112F3D35E40B34CCB40981C3422F1E92F1C8DEA7AEEAB446A68F020FF4C64A436C0C592DAAC6C1D08A39FF7233C49743CE7F19897312F330813EC4C251F1E41AB090AE1B13EE0A48EB2763E06735A7972D7A80B2EDD3AA33DD0BA12DE3E901474B7221F91F5567011C9EF16EE3E3970CFC170100E9F678FAC5EE38871D4F29D33FAD36847E5E93D4A294277151BBBFF92A402C0B720971B5D353142A46B87D19A6A1D573FB1438BB4B333C4CE1051907A7F7CBDA3FF63E202E0F0751DBD52DA44CF23628C7A0B1585ABD7A2EE87A91B0CE5A8A834169DC40E581F192DBD7A5B4807CB362036E13DED98B55A749732724277A1B742E30B72ECDABC8B756695E494CB1699F8D1B622B855830B5DE19D7B5E6EDF8091C57A386392B21BCE1E3B311D4387F0E126F449329EF71C3CCCE900D6546EC0B5BC81FA47BC57A027172772BF808D3EA7EF3C26CDD72F70BC9BE3DD1CEFDEAD81D9ED79776E4F6BBCBB9E6CEF8E76D7FFFEB1C12FD9AEF231C0A8AF44310182D79FEC98322CE71018C136F59E289D43F6E0AC46ADDF2901E672E5D30AF9326361C6D239FAD95050BB2FCA529B8C87701F2865518E4F94CC17689C650B0F485A6AF16CB3168341306D61DA82405BE8C76D230A7B8494888906138D2E46A923D3D87AE2B1D106D7538D7E204DE1919E4858F1912DB1786403257D5E8BB747B2819E406722D315E9F832E8F459614ED83649E2842DA73A39D5C9A94EE6F3C7CCE7BBE53AF741E71B4287868E0194CEE7056F2854BE8205A4F15B58B6297CCF0174A6EF392E53F713A3EEEF9CF4722521D36BA6D74CAF995E9F26BDAED096366A5DF9F1E32E56B72B1BDFF1E9A6D8785708ACA07875765058344AE6BD27D92463D1CC7639E3DE28E9D04EB67F139E3B55EB7CA456713005CE26B789351679B0458C47580EF1CD953FE0C7EC8751BACDF8BC3ED34D7ABAD9B132C30EDF6C08DEF6A5ACA67C338F675D88D899DD057A230A655720B1DB064443EED982688B818286F14E79E8F1985FA4F8F08508CBB1615390748935A8EF2F24D70A36D15DFAC8136594143928481ED53D91660EE364B1F05CB89FCE17513243B4D3D1293703576FB1F4A78A24E42350DEBB7A591021AA858431A29D9096291142327BC71BE123779C23D647AC8FF6E4B1E60BF65644F1EEC448930678DC06A9B8A9BD9EAD7352FB0120B9A88A62BEC034B0468029DC02E1C8F46B69F4360A574AE2F41FA8F7342B6356C656C9E1380DC4DD051861B22A164C3B6D6359D6537D0760753F9E6A880D23F482646750A32CE6C1A8E3093A161BA641D376ED42BAC7322FB470255BD4776E51716C298E15DDA3FD64CB69C572A2A57CACA8BF0331AEFB335985640C938569FED82E9DAE5D8A03E7258FA1C14CD31A08689DAA40B60C14DB8016DDA43F0B67835BB480EBBBF3644E2BE441A607C76EE4ABF4A885FC2311F9EEA19553AD194697C2015436AB76CD6A5E16024FE9949180867503892DEB815856A412223B31400CC046DF0AF50C008ADEA02727E9FBFE3222C3C77406D996B22DB56A4B7558283B5DAE7702CC9A56B160F6741BEBC88A26BADDD4FAA9E34DADFBCCA4D9693EC04EAA7D2BB195FBE5260D6C69F02D4D123A331119D73FE78F9BDA93D2E3D64C486799569CBB1CA6A576EF53B7DA3D33D938857C7B726A3B5EF84A338185701BA59078DEFBF1357EB0783B02AAFF8C15E0287070167937592D6BBA2B396E2528F40DA6DDC8D102463274D48715CF74DCAF1045FC4677925A42D63FCF815BB71CE7A1BC9BD0675D2E4418EB4D6B637FACA559D1FA6AE29E8310891F749365E3BDC6C9779BAF561267F9EDCE2CBFDE998DF7430AC38C301BAE9AC9B662E5361A07509DCD39BED60247D316A002B6177F69B317ACB58D622532F7FB2CF0E4583D4C2B863E8E79FE2A43C530B5A023C9695D87520EA32801072C8791A2BF0BAD83E048BF2D6E0281D07D8C13761C46B51946851D1BAC800043AA7B3828D853724B686DFD2ADC0FD64A38EF540F1B1E579F7773324D7EA90225B66621477E2184C2B6B344F2B9B2238C1BA275A7FECFA4B49F63E5666DEABE4F14C1F10A71648226E22D7B954FF422CEE8457CA617F1855EC4D723CEC1D83DC68FD4AEE702C3FF677F5BB2BFBDFA7393BF0DBA4365DBBF04F8DBF66F4D61F7B813125F977250A52C36592CB198FB7826C3C14CB7400CA353A0E44C61DF15855D893862926C89D85ABAC04787608BFD9E7AAD64F336124B6D1A26329C830F8366502384CBAF8EAAECEC785AD1592C9F5DD104FF35706DD6EBE224C371F2CE0F324E425F634097027BC2923DE1D59F9B3CE134FB83927E2E21017DE20D24DB8E712FF19DB3D1292AFBDC36D2C05806953C337A02D94B0B79BE5C04F9649D463AB143C167D7668C8750D7A05F07BA8F51CB42389DCAE9548E451D4A2C8A8FB4A1D7E2E17AC69CD86577D6B63B8B92DDDDF0D7A0EEECFEF2BCEC7872B2B75D12CA4E578B1E2BDF7BF5B6900E96EA6C2A8E36CB5AA00EEF9BF0DCA9DAD118A99061A4FCB2C87DF6F5282F44E44608C697DCE129A5C4E933E2A7E3BCB1B3F3AE9C1DFAC4FBF954E9A1527743829E1B3AC04B2981DE237C907F263252CAFF6249CDC32FA5E7BECA7089D6F58A0B058EC7992F3E7E9E9D6B5A6AA8CDB2D0EB116C34FAB25267738845031C1B91EF3036F2A1E5BEF0ED5476B4F3DAF0ED38C1E34E88EAA5E1DD9FACBD32BCC7E3D00BC3FF91E4511550A9C3068A615CA806C5564CA8B7E8567F7F85C811262E6D28AF342E6BD87BBD818DA64276AA000EB2B1C35ECA390EB2C0826B22B82682C384871226E49A08F49A08AC8E7098010476FCE53B74FC8D9C5E5041448D8707717AED1742B08BCA45103D43DF160FBC01277BE8BFEAFEB791A2C551973BD52C5683ACF217887517B7329E05D363F2574EA972824B1AD857E19286132C6938DE3A83A372458F3FA37F8469761CCFDD6231033BF6921DFBD59FEB1CFB75A308439FBEDA69C2C09DEFD3AA02CF932FBD37F192484B25E4F43A8097AF9969A03ECB612CE60B4F0E61B50D5510C365B10D622BC89349462B6B285E84434636AA1A2C75E3E2E209792A6507A80501766A186C049DB04A1BE83DCE433BA9CCA49B49773796054AA66DF30A00CBB29F4ACB2433293AF5FCD7E1B7A4ACFDEC46951D5122A793A629C6B9CCB588FD65893A7A7198993CD4E41B3DB74823CE16AA838187D1F87C14133226645042769FC40871AF150A889255508E3AF2A5DE8459DE6184BE70BA351E4DEC8B4FDE70088C43607D7D44665CCCB82C322E841858856140181747C10E921F1D5F148C43411C0A321350C48338E6C43127664027CD80E2C079399FFE4F12C5A94A05459EEAB04CD9D02E2C6B9CC86C00EDE1A82A2E932E1B41296CEE56BFBD7B2D28A5292470966D748D899D19A500F2E8DBD59B23A38852C2781684FA0419E9342976FD7BE8C6A4426CC4F84A32F22F93885C1DD34B5C7D298B328B4D4A2DD252C5295630D24E78B6A94DFABE23EA569A2D2187D4A3F89BF012F239A115C2516AF6D18EDA4783C5AA77B91F701F6D0F716BF6A54E3A808D1AE84D039BF4362C15931B321BA2283D02BA0EEA7B2805B6D00207DBC3DF00BC11CBDE4DB5371314220C45B9B703E1597D8E9633133B312636992FF28864BA3541D1F25A2C4326B613CB16133B30D234090A24FDEFD4CBF817F755FA38C9689C70770E332819202A9B978B6A99669CBC7FBABB45DA9A484B022E9135183D33688FCE9D7DC59D2094E5782251301B81ED4BB910618C71226CA0BED673102EA138E3E43B01D4191C0BA74FE44091E2600EC7490D2671EF03BAD67F0AFC8C129CAEDD9F02A76BF4A7C0E95AFC29F07FA304FF774AF0BF5282FF07E926FA992E4D12C1F58832D47F26E01C4B7AA040FDEDC9A53355581DE4D85D96EC2EAFFE5CEB2EE7F877412C61BEF21690A9A35C0B64CB4B3691DE1D91D31F9CFE68F82008696FA4F084B55A1525A6A904A4B71BF94C7CF3D84978DBF9D7D5132F8ACEC0D01573D4258816EA3415B69D8AAAE3AAFF422D7FB271D6D7C6F9212CCB8CDBD43AD51AEC91B04762CF2301D551D5136FA04762BF828AFD87CE48EFF73629DC32AC7CC56918F472A2C36FF347FFB5F02CFC69309E232C44E2082DF321BB7C28ADA78031A142A1033850379B80CF7ECAD52454B519D4B76604C21F25E12288CCBEE3FA71A36F587DDCD6F72B896DA975FAD4ED13F626A92BF93875668769DAD81CB139B2618ED46E32B643F9B3A6CACBB6E52964EE4D6D6991ACB35867B1CE02EAACCCD53E8F22F7D997D375B8C94C8BED4233D36B4D68F634DDA105F2C64A3138315431B08261056345C144F1B93F7D50FBEF87994A593F6FA644AACFDB4A4CDC044BE1C54BAC2AEF7B6F3A10E194BEE8E44EFEB02348BF513E392D2412EDBD2C8A536F77E5EB9F5BF962B644B572DF33A4A3B76AB3222938364F6C9E1ACD53A6A695CA3BF7BC9CEA99D9A91A203383B503C816E1D592D370C21466B256A60F883396A12BBC46E586E372B7DA3D1C311D94358EA0CC6F623F8115F17129E25C75E943C0E6672E76C30195721D9C2DA7C24C7E3BE628944FEE5B9342C2D2AFD9F3C0BDAF70C6B10863354AE889804C19638C2A43C21D57EB77F98CD1FDA1588E3847EE919C47A3F9A2F7808651762905DCAA9E3BB1FB0AB6AA58D6B956C1E114541A0750EFC4ABFB9C3EDA7DB01F3F3C482FFDF768E62ED258E9D34F0DBF7F6CD0EC915A2F61307F08BC66998D188F13113E4B1DAD0D8040E320091D54F30A28206E5E2E28E6D57E3131C5EA3F21F36A6C1489CDAB31DA119A57B46C94FAC8B7228AE10B9CFD43F60FCDFDC3DE667E659A0FCDCE17E6196CE70BC200B5F3295145F1A04B4840EBBE81643B19578C00CFB4F77A215BE71EB241B137F76EBD39B6A5EFD1961A1B09143F7043B1428DC47EBC3F44EB80A784F18FBC1F40A50092942EA71271B276F385172C25B80B03AB7856F116557C9E8387E8F652059BA952EF5C0487ABCD1BB582FA470AEADAB1C88CE66044217CE2C69E046A841C4AFF5B63E492C40150DF7D0ABE2AC2756CD8396B16E82EDD17C22BDDC207FBB4D0C21CADFDEE9F2EDC701DDB35EF4DF60C5CAF0FD2739F4BF78218A20807388EF3E9349451F4897A35E472CE2CC9F94C2DE7D28D14F2FA588361D715E14F6F2D10CFABB98EAA110B9928A2B898057E93FE45A236DF5D8F5CCAB5684AB5E0545D87CFC277FFD57E4110862CC749165624FD1E842FD93624D72A6B51E48A652D8A5CB768515676AC16646DD76A617676AE966461F7EAFFBDF7357127F741D1B29FABA011420C59A3DCFB602A85D831363F888130A8F12248B09A4CB47C11F7D5F5309A185DCBB9F0E4F934F16220D22D12CE60E67A4A61FA4098EC5BA0B277DF775F65188970095F29AE3F139EF8D5F5A7C99DFCF14F2942E8D69ACC843B0AFC67E141917E9791788182FC2AFEE75A46B1FB0A1FCF83988B7F09708DFFFF9E8B088A712D5E83D0551FFD753013BE2F3DE0EECBE1D412884642FD17E86ECEF11EC4D40DF2112241DE8A67F12FD79740B81B397D863BE505CA19D0AE8572EAC637EE9CF01E8F4CC648866E30854DDDA572FE95FE9900ABC25630B9D34B6EAAF2408C5279A57EE6C68A53FAD3DF1653F578F4CD1515BE6BBAA7AB90E33958490CA371122D74700F812F5D78C279B971158D4300CB16A33E71F703030E27C9835355B08AF7CDC53ACA76E1FAA9B5EE12116F811F05AEBFA636E86AE28A18FF81187F183DC84B773E872F0657AF86832A231D46E7DFE55294D497F9967990CF17CBD1FD18BCDC453443B89F2FCF5D69086864DACAA1F9F15229C2F92A6186937FEAE269926F9F71E08135B2BE49015A34FE870F3CD4F5201DE92E2C545F7071807C87C5011FDA6BA9C7C9C2737505506AFB779750977FF7B891C5AF2B976EFCFDAE2350CD0F611C77AABCAE79094419065006B10963AB1402B91511567F8862F58DD5EA1B021D404BBD912C842FB9FD3A9B91833723255360CB86EC385ED3CDF018D990FB85F4D5574EEFD7363F46B38D626241EA516C19905E625BB2E6A517C1A9B3B67F8DCC215D3C867AB54DF9E3C0FDDE93BD486984738BA8525D4A7721B486A4BEFF11E9723B4BB7A6A2DE99785CD7450EA32C2203FD524D1504ED9BEC04AE80D5AFF14D7809F96BD00AC1B832997D80F7E803189164F36384F5AC104292ED1F1F44A4B427CB9C8EF7EAC883E3EA13B56C3D7A3B958AC98D950D51943CB6F9524C8C5B36E9D723AE8BC677D9301739212EA21DE1890CE7AE2FCC627565002306B209D0FC9678E4A322B825F5DFF5E06B0F892D89111C89DDE795B5116BA3BD6BA39170A743E3FB00D74F9BE8A1EAD3B694908D92A34B1939A1BB683976F71987B58C15D18CC6C97C2EE13135D63AAC752C699DFB2486A89DFC7153BD537A9C150F2B1E563CEF45F12CD3D8968CCDF44EF1B499DA293F6D2BE0FB10FC802657D4C0B774A501CCF93C487CBA735A17C22B57F8E3E7C290CE2AA7C5D54D7680A455115E476E94630B1885EE17AEE775B3E12D1F562D080C1CA5271A23AB1DAD6EEF65EFBF80EB5267F2CF5D5D20DBCCB65AD0C2F3CEA7AF50CB9D01355F38463283396782C7C4FBD62FF89A11B604A5683A1767A725A7174BD82EC64837FD01B54EB57DC200FDC6104ACABA35D73BC320FCB87C57F3AFD8AC1877F3B39A6813ACD829DAA1B861F4DBC20BC47412FC728395E5D6662B5D0A10B889FE2D749A26AEF3D2858C7608B14337F178E63EC55010E5438AE5950F3F85976AC7FE14A5AF17A2973BC00DD18F03FC90E2715BE18F92581B919092381C13DBEABE237589E048084742EC4442CCC3AFAB788081EEE9164A40D73BE0031CAD5E024DB3E46134FEE12EC0DA00A10AA7BCAC29BA4F3C25FE543F020F25635D73A2A9DA20588083DB23B556E20E0BE88C6201A94F74DD787D1CC9B25DE1B331646378F8C6306D0E72A1E6FA651AFCF08D8C6215C2C8386E4358CB1208FF59EAB3AE7465AD5AC2BAF5193A3EEF70DEE14D3B3C3B0DA93DCF4BA95BBB09DF316AB6510B64B4DB7701D972C8AF8356D718A724327BBD7B5FFD7F11C69A8C43CD798138502FFE1CC0AB0F0ABC71F29D10F28C590CEB384A1D9784CE4C4412C66336418C745B1D087319DEE7BCCF11F6F9EA40976900AF0260B2BFB7006C71969B20784916E5601655623593A426029AF7D33095238980FBC9DA2A28DACEC9A188E1980C6B392B5A6E118471AE2A02A303FB1B10669A6E0BC2168FF9A6A8C477E8058969A180152F8FB7336FE7C6ED1CC52251A421CEB6D420F0A76E7A4EC16863EF0033DBE20D60B6363B567D6E5E5D84059707A9706EA15AC77FE0CD5DB3880ABCB9D97702A8B343A88E8EFA575475DFCBAB933F861D8B2B00467B761360AFFB744F9F18A916FF35489C99BE16CB93CF6110D1F5C8F74B92C0439EBA91437A9EC4AF11623CDA073995922E20E56F89301BA99715CE528FB6560C68F1FA926E21E4221CB5DBC865A455846452D2ED5DDE7DE812C2B48A8750856C08302C14A6571E2E8EEA88E847BA25C27423BA94DFBD026F36421986845D4DFD0ABCD9081D7D80D1A31B62151F6422C88D036C94CA1ED06D19ADA51782700A3604984DC142B8D32021541C1B024C977C3423B548CAB77F7A2297E2D78A319F92CCCC516A824D19666315D357AD53427DAAF995707AEBE500C74C3BC5B5623066D9096D8C7A5314C25CDB19F88624D0B82365463C59AE58221BF8B62843CB17044FDF5DCF0392A5DC21218F0500E971AA754349B8AEB644182AF5F4883DA142AFE01BCF66B8D035C894C638937015FA56847C1384747A6BBECCA67D4EECF5FB1B020C1730F12071C638F503C2534AFE8600D028A398928FD608314DB544B3A1FFAB20A44A0AD013EAF31337087AC838CDF4DE3F7768632A591EB1B9CD36468DD2373BCE4D26263BE13CA61494A519F52D8974EFE2468254C0F95CBE910AB894DFDD9854C2DDF67730D31D779BB36D08B339A786305B33678673133C570B3C4C61B24C625B33048C529142564B21104E59CA80325122FF20851FDF8EBF117B3E5C2725B94E6AF5E7ADDA8AB4B021EDA9637E9BE726864985451D86AD228B5E625B36F4EA35F8D2A32E955E58F79C4287437E5DE475282525FE2009754921A588BCE3A90511E493457E21A39DAB2D0FF2564F2B7751FEA24B4B881DF8CBBC5061244347DFA5FD4CF73A8528E2371A27DFD3FBC42EA9AB3C26E22D7B954FF422CEE8457CA617F1855EC4573A0F5E52AF5C8C4B5BB10E9261DE7EC8DE9964EF6CF5E706EFCCFC1AD93A97C4DC3BB37F852C7B53ED487F0BBE0F3C114587E24ED9BBFA730FB78DAE3A8003277BE8BFA6FB4AF1CB087EC203F51EDDBC89E5AD8C67C114BA186C72756231F7F14C868399089F255DF1B145BF8379FABBE2E92B1147EE09143B24756609D3EAE837635BB9587A35EEE3BA089E5D2176859A5C2119BEBA8E1CFA803C5515C2C811DA86B0E507E5A291F254C57BB06365234D75216267D6A88E5176F4D164C3E81330E7AF6A9B3D4B2DE838D22F763246367C31AC44124795994A3195A2A45280A0F2367F30A652F643CAB9681CEE9383DD273173292BEC649C2C161E42239AABF9C20B96126CB9ED459E0F37C64B6FABD3580F2527B5149DC1B4F358DC232FBB02DE24C7AC8359473BEB5076121CC1596100784705E39863384C3C38885387431EC429AC06078A385064B8803850C48122A66C4740D9C091A20A4B31A76C471E2B3A598AC5B11D8EED1C706C27156083AF7210091844B258BCC4E487C94F13F9D1371A5CCAD888F4E4CF1A919DD2B3B6480E16A158E3E4178300F714CE8D03D98C622CBA1552F634069A52E1613C5E46B19CA30CF1DA0B049DA51E46E9A0AFD6EDB94CCD458183F98D151CE24C1690E860288BE70F683C62DCFFC696FA1D4ADCAE0DE3EA12338ED3CF5418DB09632361F326CCEDD5B247AAC9CC8D995BD37654182B3FC2685B96018CB6E72680AD6D5A2FD440B18F64E8C243077A1EA04A435FADAD71602893008EA1C94FF0E3D6F5DD793287EAB01C4CBCE180B16265C54AAF58F3E8AC520E4F413817A6EA751BC648C9D6C3584B0C2085AA0B9CB6C69C28EBAD10A6FFAD716D63084BA3AEA324746622926939026CA652BC5FD6ADDC0128E9C17B2497A5F7F6F9DD8DA45A7CCECB6DF09A5DC100D8445B6090AD540B766C1B0AA9DC278769D996389759E7B25A76258EAC49008CCA9D4FFF07C80AF50A83162EF8C03108E855E7D831532B0BAD6367661C61F4C55B04BD06BB6BF334D23808FC27F7D94881979E37D2D91BCFDB52D375EAD5BC28B3958860DC5B2043BD0C9AC8158A0F92794D36DE2817753E9D86328A3ED915776657DC674BE226CA835ECC02BFE9E37DC6B846239777AD75AC154957735D6E4F9C4DCF65FD2EBF534BBA51CADE8FE474425E8A7D2142FDE3897C8B959A9C911BCC5FBED14AEC69DBAEA58893D0CCC52F03985BB71280352FA49759B5622AD5E7099737F2B57297AE51FCF236F1E265D62ADC591541191722CB27A1F00A38E85BAAD1B97E12559C03F378687A588328DD37D110E687984A8F9BEC8C8DC76D651652B1567C945492150705CB859BB8CE8B046F730EE27310DF42107FA2B68E91D67A33D3566F76B5D41BCE05577D358078C3F1FBFACB1DD1B709BD7A7A924EECBE4A9BB25076939A9F4F507DAA30CE10303E23607C41C0F80AC518A9B51D6FA6734C029F72FA8C10ED17EE1407C952EDFE303A4FD737E7FC992E1C035D90F3C5A5F2359669CA749CCCD526591A11883A20234AB10BC85688A0D66D30B99959443327F03C6DEF02BA0BCA1D114E2D8879D627C6492F06CE2E9D271511E806EF116271C0B608F9E6CC844FC8A09EDDA7F835BB5594F64DDC58CEA7D457497D773DAF22C16CAFF932A69D0CF289F803C55EB0B5676BDF62ED87FE6B1EB8CE3BDE5CBD2D5C65620111CF5654531ED08E6A392D6E368C4EA9B5D3EB1AB075C302DE4D0B4D5737ECAFA6EC4254CA3CA9FA507D218935E935AD9674AD1E6BCBD8C2DBE7509EDA47BE4795FC9ADCA32CACAA118254F0C99110E64696B851614375A1F44DB0145EBC3CF785B78CDCC8941835409AB2A216C8BDC649B842B66C7822391D88700AE4870A611845090C458F6514B87E1CC170EE021FE7B572208C31A533E49F7F97CBF4CC128C0AA6E3C142CB7201F0C9CA7030E66AE80BA431154818A32A96D4087A88888D3C1BF956239F9ACC74D99A5BF53586B919AF62D8B2DB83EA86C5BFE014B3D51DD66DBCAC17582F74D40BF98956A86AC861A0DAA104632DD659CC006B08D610AC21B6F6642A47A4E9765D9E20CD0B26760202B5463DA0358291EF482B0E7D21CC8A438FA56BAE8829D803317EA5F5838DEEC1DF14520CEC84ABFDCBC6BC0AD21AD1626C2CC63BD7417F9D5EEA306F436DD844B58A60AAF0AA08B634DC43F0039AF05203D78F433509F91D1E5E3908869F234231FE0FD291EE226ED80B34C702D052EE384D52315A69EAC6BE5BEBD2B00107068ED2178D4AEE33C987BD10FECB101AB64FCB194DF2E9C3482D68E179E7D35768CE33036A9C419AAD7129232774170D723B1E16EFCBACD234528BFDA539ACF3DB62AA8DC9C512B66E309AFE83BB07AF882EB0DF7F81A33170905A9C8A338CC60AB8A100ED9AC606AE69CD6735D1261319CE5D5F74384DDC66EC32D7B2E797ECC72853B7E52294E2651AFCF08D696515C6985B6EC3580BC1F515DD62067445BAEEB44AE7716A09EB961D34F8D6FCFBC14645BA4903A4F40BA6CE2BD9A470C85272C872F5E71D1A3552933D75631D96302E62AAA298EBD34D146BFEFA9E1C44251727C79139884DE3C7E03DDAED699C2394BDAF3E7E99449075AC6A0BF775741DF71A7FB9099E9F33D50665E26B24F22F9CDE7983720BCA953F45C1C10AD4601D60C0E3E49D4A27519443C7CA49143BFB47BF30565F8B8810B82E8300EC2187AF397CCDE16B0E5F1387AF4D3E2A87AF397CCDE16B0E5FBFEFF035A54B363022517DC96E7A158239CDD58F03086EF1B8B5C079A76B3D3A6EB3DE66D7CAF65E9D7ED7C29A9AC3E34B6BEA0D8F2FADA9353C8AB411E625054742FA8F2C2469E5A43AE561FE3B199F4E7810E58B7274F0C0A28328B736588C0EB6640F0CE2FA7D3955A9BE1E1644AC020178D6369065C665E73E361AE2A63ECB3E09E3B57A0A3679EDE10A1A12D3DEAB8846EE5886AE688E0BD108366F92A49BFA90F180F3D76752FCE3A55FC40906D4D65215B016438A74A599FFAAFEF55AD98D20249BA3E1E5F0138CC80C2FDDF52D6804E3CB7B7B528A187E42CA9228A833F86C9ED1CF26A588E119DE6C7E86CFE667FAD9A41431FC8C379B5F48A782163D9D684A11C32F7813FD15BE6CBFD2CF26A588E157A4D97C28D339F47146633519D044E8F8129A191F5F8273E29743BA13C5E34BEA06DB974A02D282218EE91D5634EAF04A2AF613384FAFA3980BF0598C02873ACE8AD5ABA0C0691C2F4EC12ECAE6B4959838B830365666E7424452BBA28750CFB559A96874EF62564584548B740FAF09EA2207A1786A22DE88A31FC368B2BEE51A30CC11FDBD73439C9B67B322A993A891C2AF123239CC445973958E0765AE4D02BE161AC5E3A57F27383501A597C52F650A83799076B482143495418CD36D9B20B6526D5837938D29EFD85ACD0EB947A7FEF5C9C582EFB716F3D657F093EA9B40C66BB20EC85A0AB8BFF0B6880C9F57E7F3EA6D2FCFE7D5BBCA3A9EF3EAC5A531FA6E8B0719E86B886FE4ABF4F2F210533DDB026BAA753BC05A2EC3D94B1DCB68AF75B4E95DD594343B17917E59BA0078D93D3D604FC15EA1A8E5FB658EAE0CB2503E360E7F17B25AAB52886B2F710A2F71AA2EB9E4924B2EB9E4924B2EB9E4D27AE093AB3A1B973D5775725527577572552757757255275775928C93AB3AB9AA93AB3AB9AA93AB3AB9AAB31689AB3A1BDE89AB3AB9AA93AB3A6B30B8AAB37D65EDB5AA7318ADEADBCED394D814BAF8567860F7713D349AF28C4ABE6B2DCB2409570F659489DB0DC5E9384EC7713A8ED3719C8EE3741CA7E3381DC7E9384EC735CE26A7E3381DC7E9384EC7197F704EC7713A8ED3719C8EE3741CA7E3381DC7E9384EC7713A8ED3719C8EA34FC7C1B370F0E41BE7DC38E7C63937CEB971CE8D736E9C73E39C1BE7DC38E7D63A9B9C73E39C1BE7DC38E766FCC139E7C63937CEB971CE8D736E9C73E39C1BE7DC38E7C63937CEB971CE0D34316BAEAA5962AA0E411F4CFF16BA12D326B45877C34F5CE7A54BC6AEC390A0FB557F34D78FE1CB6818CBB9DAF5DA376824D118C66C249C17E0E61B2AAFCD77A4F7F7FB09D88B8EE50F114EC19E4C06D312A1C7695E2BC357D791839908098D63450A316718CFDCA718BE172EC552F1661C73DE9FA89A541F3CB8CFB3380216206420C01A843588AD3204AC5844E92570DA399BCBC7D9FDE6F2314229C3E8DC7164048E4E2AD3249248C261C6E2150125BDCE6109C7F9E6CA1F70944BE9C918FC567C2788E43B41567FDEB233DA8499989622CED3D79A6CC5876A5F05CF8060C492782BF256B4B115D58CA44BC4683F160F1B6DCAF2C3B6A8DD4AE85E0811EF69DED3A0E0E39D78759FD38DB06B5D8F42F7D5F5E4B35434F9417AE96FA399BBD06EB3F7F453CDEF1ED72AE083BE9DEF21F0EA01D73F7C9C68D75B7BDD41975F8F832474C00AAAF4661055B5860129AD2A8C2DF565E01677D4875020F6F5D8D76363C4C6A8CA29094D506154BA99A0C260199BA05B1129556D6A79B2A74D0DCEFA695B76066933631587E9496821EC2855325A4E7EFEA99C6D24CC3745D18F209CDA782F142BAFCD72EC6258423DA481F0E3C14CDFA9BC391130DCDB2442C7C5B19557F385172CA5B471BB23DB65B6CBDB6AA0837FB8614033C55B35CB353FA9F509EB7E57E70D761F756152BA0C7FF5DB0EEFB1FDDB9617AA7900ECE7C25D5CB877BB1FC7B60FCDB1EC225F07E19CBDE3F7E61DDF88659034551CDDEA5A5236D26CA4098C7466AA70CD739DBFDC64C6118CD8DA5683ADD90A0A6ED62A50C767DFD07C392CE75C697FE51B393154E3B22A645568AC0A8154BF593936F806465AF29B9CB98E274DB462FEA889162C3D6A4BEB3DC867378AC3146B0F1D76F237DE4BAAFFCA7F767D89F1D22DCA6726A24846F482F2C9D442A8455D27D26B9143D344EB56BC90BF9CD2BAD2A316F2FFB3F766CD71E348DBE85F99782F4FC49976CBF62C5FCCB9D062776BC6B63492BBFB9DB951505590C4CF55640DC9525BF3EB0F7702C8C4922058C52A21C2E15065020F402CB9616B46DF79B48916F1705DD1645ECC6DA9004BE49D95F71BAB3CFB7106C20D5B47D9374D55FD1C130EABACC13AF2BF8DEF34CFD3455CEBD5B684D3C5A2FC579D85B9618B3459C4AB86FD338B962CBB53B12F5811C52BD941FB902CFFD01842E36007BBAAE9AACA6ED32396FDB85D15F166155782A49C84FF23DB44574933A1FE705A87D3EA13F48B6809BBA06CBAE5449FD54786CD9FD564913FEBFF01B52D4D3C96555655B43A2F2DCDD2688A9302DA837189BC89565E7B472A05B53BF5254173B46AFFBEB632E7826D585299905E7B63AACFE86B2B0D2F538FFDED076E961A27EF59947C2B4B4AF3B8183E9B235A4C544B08C5A404B97737156D2B8E4F3B9070BAC9466C61CB1159012C1B80274FD389D8A27E2BBAA30913AF56A572CC5EB80FEC483693C59C5D3551C49C3B9C261655564C1131D98413C4BE556DC79C88E8616AD8B7A2CF2AEE66529C3FB1FF6C5973027DF83E9E6A3135AC41141304E6DFDD1CB1AF3B3E5360CAE9260BB99D2DC723C41D3F6BC8EDEAB9AEBB9C3E37ACD86689FC950DD57AFA588068A70F9F7FD7D3C7A6EEBAE9C3A79C7AFA10DA993424795C5FD387D0AE9EEBBAA3E993B16575F0B560DC37F6349BA96303A09A3652DE1D4E1AAB5A2B268C946EC2E942695BDBE127617A982894B6F45ACBDD4C910B762F7F5E4FB2982016D915D343CAB9BBD96153657C6E48C9A69B1A8456B51C7212E2F8794168459F55DCCDA4F869C5ED8F1C3E50205B4C0E028C62922008BB9B2894EAE31306493ADDA471686DCB9189208F9F400EADEBBBBABB994C7F2FDB3A89E410074FB5984AD6208A8904F3EF6E1ED9D71D9F4530E5749388DCCE966312E28E9F41E476F55CD7DD4C9FABB290244E1EDBC79E860F951816938808A5984A28CAEE6613F523F03985269E6E5A39B6BCE58045D1C7CF2FC796F65FE9DD4CB46B56142FD5EDF755F87CF858816C31C908308A098620EC6E7A51AA8F4F2D24E97413CBA1B52DC727823C7E4A39B4AEEFEAEE78325D5EFD827C6749A54C2513886922F5F9F7308F8C7537CCA23EE50E26916D3B53C7648FEB7106D9B6ABE7BAEE78FA5C472FD5C5BFC897B61CCA34B205334D2701670F53CAFA3B0C534B48BD83E9456D7FEAD015F03D4E356A7B4F50EFFD4CBBB2DAD5A966F587B7091C262111DA724A0AA8FB9B99D48FB39BA742A6DD4D57C79E729C044269FEE7B063CF4CF7313B9ED8BFA6DBC513CB90EF6F3994A96C0B669ABC02CE1E66ADF57718E6A9907A071394DAFED4512CE07B9C8BD4F69EA0DEBB9976FC2D236CBD5945FC7221C2B4987C8E908A29A844DBDD2C74FD207C2E2A334C371D47F688E5E05696327E5E8EEC81693E600713B47B29EEEE34639172CE09A9B069343C706A1A612A506C2857550273D0CB9045CBB6EAC432FDC8D18636E6B8B2773950BA3FB0FBF991CE15927B1F3A223A3286C4DA4E3C98D0DAD8F4AC90D1D7F0425BDE536D7639E05A3FE2332B9ED2A579C009C9BD0F38111D1970626D271E70686D6CBA58C8E86BC0A12DEFA9363B18705F5996C5459ABDE875A1980C1B607D0ACA08936077AB0EF1C277A40FF1063D1C853874B7517A0C9FEA5B2E0DC8C8C8510E48DFF208D4C2A617FB4CBEE41068650FB5D8C5804AF3E2BC84CAD85D73A1460C6E5CE53A1E498C0EAA3EDD8EBC59B4629861D6DC1932914BAA6B1E2B13A8CF3F76506A9AC3474576302EC54B5E2CC6A62A03363EC5B43B1AA3CA0AEE7C9C9A9ACA6688C04B78468C5753D3F8AAD00EC66D7741DE5DD785AAE12027C4C6699786A29C01AEFDF0F23AF09D46A6AAF27642CBC7505475CBE81AEC60ECFD9C6F6ED2747D57FDF731AA6E7429D4E30F4B8C8DC1361D6508A2D0C8306CD3F555958A78F3C73F4AA622A12D2E93E7B2C5A3ACA87CBCBBF2D77954B0C734D3A9104D1EAC6584E43B5222BA2A222D3C24984A9758B499CDD41160464E618B36F254A51DCCE9B216B7DBFBAE13EFF80ED58C114516C528E65253A6B9A61CDA50DCBFDE317F8AE588E9B28D1FC2862EF4529F9D8FDF933B69B8D98D2D399B791C9FB80F6450183E983593666EE359F545966388CBE97558AB7AD557B57633BA7F8A1F8A76DB4373ABFD9D483C4BD36FF51B579AD1678BA118F7203B71F05B178FCF04EC63E73823A89F69390E1184F1D3843A227CD7751E7347BFDA6B0BB0A759A35C1DC6BEF110E70B79C119C93EFD4C212F445BD772E773A49FF4EEB34407619E272AF16E3F53B4E5BBCE155F8E2CB19E7318F236FD79D883FEBAFC86A728EF36C6E14CD3F64D7748F3A410D176170772FD20E32C13334C17371AD923F4612D96E2751EBAF4C0341FB0F309DA5DE6CF5DC9A44E409BA82ED0E6090B51F732699D3ECE387961A69D4CE0313D459F07B034AF93794CCF4CF7313B98D8B7DB4D394C9ACF2DABBDDC2E8AC6A6564F5875166C2276A97734E13495C327929068A289636E319B31D4A18C1CF8E6161A5F995DACBA3FE642EDEF4A423FD654A34397095D8D97D29356E57565216391AFFFEC6203361F63336CB86C6357ED2DBAD24B8D7630967F49E2E2EAE1338BF26DC60892D8900F1BD142961DC9645335F727982D1BD0661C095023C7B6658379AAD63E84B5380CAD45A8D830530B6CB1346494EE6E32F911DAE807ED7A70DB75EA418DED5EEF707F77D5D50D6E5D3EC5E8569B08DA81AD2D496F8CF41F324D10D6B219766E5CD8B4D8A1D8178269D4FEA15F4250E6200E4B83BC5594810C48B1DAD30F45B44214C7C847E0DFD80B9E2AB4CB3883DDF8B31F7C2E236F5EC36E5E63EE68079C51212B73D0C25A8461A7D3C03B52BFC68FDE47646A8CBEDDBBB26DDCB5755A9186ED093DA90D1E9FAE56E9EFDDC903EDE208194CB11C22E1EC6E0184FE01CA8080AE09275BF370EE00CB8501097FFCBA867383FBACF08E671AFF5DD5B0C9EF90216F33486D804C330C601077CFD02A63982D3B98EEA36716E53BF73EAB2823E4F067D4D9F6E57FF9530923E69401CA7256F12823E795A942C733B32CBF742E73CB72A41CC7EC124FAE8D9C5F5A30C20C531F73749863FA4A1DD72CB3FAD639CD33AB11731C33AD5D77F030CDD4488439D6827898609AEA1CD7EC327FE89CA69679941CC7BC920EAE8E9C5B7A34C2FC723FE4EC50ADE39A67761F3BA7B966376A8E6EBE9DF89D70189CDB8CA31EC776A9D8D1CE39DDD7CE74D2E946CEE1CFBAEE2B2FE2B181453D92E55CE340464E3343758E6786D97DE85C2697DD2839FC7935389FE3679609CB726E0930236797B14AC733BF6C3F752E33CC76B41CFE1CFB8915FFEA8E2C8D9B617A24CBF9C5818C9C5D86EA1CCFDCB2FBD0B9CC2CBB5172F8F3AA8DEE8C575C5A20CB5935608C9C54FACA1CCF9CB2FACEB94C29AB1172F8338A7727C74F2B339AE5DC9280464E308B6A1DCF2CB3FFD8B94C35FB517354F3CDEB74F335DBBC4EB6D734D70E6EAABD8299F6352DA2D5F839A682B19F5D35C2F879A5ACC851CD28D357CE682E9946C601CEA2F6F2A3AB6CD9BF602B932DAE1722C0A8661144D8E1FE7942F515730F269D70BB3CBDB56D472644F63091E8ADEBBBBABB3901CAEDF32A7F59BC8DA0C9A33805BAF3B7117455C44F354FFC3682459BD98C1E0166FC2152531B79AAD2AE4E320F1B3DF80ED58C114516E55966A76D439A72684371FFA690F9532C478CA74BE4CD5DE8A53E3B1FBF2777D270B31B5B7236F338266DC63114A6BA2D62C66F23D87D91E518F2F736825DAFFAAAD66E46F7E72A374BA264C1FE9EDE9749E2C7A4B5AA14DC0FEBCD2A7D61C67B427D802B668A1A777776CCF86FC327A639E774A690B7FEB29C03EAF2C6CF546FFD33D1B7EC6F7A778B53F567AA1AA39D4EC4094080264C6D0195A819C7D6D27E92EE4000F99CD70E8D30D359ED30E80E7C4E172C2BA1AA03CDCD8500BC5C9379566ADA0150397F71AC5D2A6697AF51CD733CFD942A78445F580F6BBC0C1FD37344DB4F52FBDD4EC90A6ABBDE0C1F7787336DB4AB0BA261520230B23275AA947E6EC16699A70A1DF3E9C4A10D70FCCD4CB7F1344DFD773B376FD87FB62C2FA0406A190445690965988D02CAEEF5A3ED47E867AF90787AB5486C79E2B815D0FDCD39624BFBAFF44E6F8CFEF0BDA80A5B7695FE355A6DD9DD27F9A267CD082501E96F954631DC2E99B6AC0E3E5DAE75975C8F7A45BD0247964465B2857423C0A81A7D6FCBEEC4EA2B3A6967CBEE6EAD6D2918FC2FBBBBB5AEEFEAEE428AA52FD1AA78398FB2E54F2C6199E0C2603CE3B472044427981A6B57B3CCF56BB0F9A64E3FD5A41BD91756E3595DC6D83938B2ED27A9FDEEA6E4EDB61C0ED55686A85A506EEBB9CD8B74AD7B70C526B366AAF1F9CC4A9B5EB2665AB4690C5381F2664DDEDEF05C8EB8E778C51E597ED7D3D42FD6E872A1EFD5C00C14734B5F1EF6A447AEBCEC7BDF5103AB6FB199967DA6B1CFD4D874A6870AEDE205A6BCBA6D5AF88A8AA11DC7487AD508761FBC58218A613BD78DD586CFB01D205E764E1BFACD475D763E5A876B9C89C31666348F5FC27DDB84620F7A44ABBF678F435BDDB7B31CE31FCA3CA5959296864D5C1A8A6D353EDC5C5FDC5744F6BD0063BACA70CB8A36E9E96251FE4BB74971C31669D962AB5870A8FED064E006983E07329AED0A6CCC5B4A819DCB652EF02C4ABE954D9FE671A1FD2E908E08AEFD0690CE0A3C5EAD4A72F6A2AFB7988A04ACAFB398CA0A78BB2CA7B0BEBA5C121BC8CA0F3A4FD7EB38CF1B098A818A89AC609FAA88ED79B5AB60A56D0598900AAF6D0E98D01EDE02980AF925AD7ABC3AE0A0016D12BDD8A3DEB0629BE927394C4885B7680D3EA1157CC69671C1BFC78E834BC968D0FA669192D9405FB07B8B4A4BA948C0DA2A4BA96C807F5AD58F7B470BA3F24152920BD0D61E49E9F8055FD97A63FF15556A9B82FE5EDA234964A11660422ABCB69D60421BF84FAC14FE59ABD015C8421A7BD0DB7A1DEECB767DAFAC334C68059F4689B9B9A55424606D434BA96C80AF4A3B338993C7B36855E9156DBDD1B40E8568BF014D6B53C875F4525F36A6FB02210D01545B63218D15282BAA986DFE54594DFAFAC294E402F475872949055CAE3719B715435F86909856CCD52F96457409A9F076ADD42724C1378E9E09BBF3C509C056431E4DEC528C5D13B9CF863667E92C2F589E933E4AC833A250D2270A794885DEB0787DBFCD7256C1984A1312938AF935DD2E9E869D04FA6284C42EC5D8B59D90D8A698DB68C5F2F68D2F0CB9E7DB8009A6D4439CC485DA4F44D3120BA92CB55564B0AE95E91D0BD37684323DB5B012D5FAABFAB4E6423216A18025DD9879585E8400C3FA9C2548BD5CA2436A17B10C70ADACF8CC8AA77489C109098C705F5996C545AAF0BA3BAE85BBBD2DD276C5985D260F29DAE6521A236815B83A8BD1F9D4B2EC20CA9153CA08254CCDB6425241D865DEA0AD52B1AE2B8E09A234A84A33B60B13376751D8F23CCD8BF3B2BF33FCFB4C99A8C55A146286CCD26FF8A46A38E6291565CB61F3FFA7F411C3E2B6320869ADD087CD0FDD5795FCA2FC487402EB32108BB32E8602AFB61707AE0550FE14B3ECE33659A8068294C416522D1939BE2DD835CB34E15A90C80CFB14258F6CF935BA5FB1CB82AD4BBD8302C36424E8C19836A10F29CD05F451E9DB52FEAD514528A7B101DD4409AE2F1A9E595BE88516413AD543E3EA4157272189B96A3A41672DE1CEABF09162C6352C33441D7CADE667A520343318496701BEBE619B342BCED364A9B459612A0B6327CB58B2508C8E8669313CDA843FC779637C28A1FA149646D847C6CA765AA08A5C4E6304BD885E6E8B2843676CC73383A48B6D359FD5C143318519308B9F154035C708D09D82AFDA0097CB620A6BC00B56591F5167C1EB90A5A4D645E8308D201FE3EAA06F1CAD2E93BCE46C55F3024B670F5EEA9E18B7DCA52446C89FD96A83F774C33103A4DB6CF5523BBC1808CF3521E59B4A4725AC32042BD9AD8B12E8129BCB29A74339E515B80DD306E6BA1C5C8A60C9C0B501BA49D3F5C7A8DA1B5060920AA4A0216A5B114D6887AF41B481B8DDB06AA0AABE98631BB02E93E7D347769A44AB973CCE6F57D17DA372B0FAA9D2D6669143497665D8009F45D9225DA2B368E0DA01E5DF58D117CF566C51B0656F93A896F5EC72D22B509F70BAA96C4FAB5287E4638AB2FE48318B4D91DC1D8A28FE702196196BB85B4F01C6DFAD68861B6E8352D64EB8B18B887862843CB16A407EB781AA11F93434D09F19AA18E53456DD13ADA3726028EC0C21810D5C6744705148052E92D2A6809FE287A28D659FA5E9B773B5384152120B503ADC483222B4DA51C1D211C1BB83626AA5A84BEF58983AFAAD4BEF58987052D3B644E1B4A27BB1D40F15CE78928AADA7C603CBF4FB844C7946146AFBA9308F4DA1FF888B327392977A5F51449BA24C6083D74632CDA20726B4814FE305FB2DCE59B3F0A556BE209D0D781BADAAE2138DA8C59041220BDC343F4F9387F8719B29C33548324BE8AF557CB0B432B483134B67819E95CDF8893DB3D5A73857A95031110DD6086907579F563FCD73B6BEC7DD43988A002C1DA5579A3C8A93F7EE253587F669A5B55706908B2414452DE2538C2F46892908808D3E96177BAAE9AE2D05CDD6E42216ADFF1A4B73E176BBD9AC621CACE3598328AD24218139A05CDDF4AAAE16C7B68132B619BC6AC200FA4B1217570F9F59946FF170BC9080F2B9DAC90DD39967B5153019751865B58C6CD65A1A89DEF808FAA1A9C834A65862816E4535F60CF10BF94C638A2516482DCA2C1EFB6424682B65E530F0DA6DC1A94DF78B691D0AB183A70017E942B3428526A4C0B713DADCA97C4A42019A20019782005849CCD2ECAC966134A62996D6B210E121A16A77C3EFBA654B8B3C84524D1D2DBE19E5F839FA2E51A6A79776B67DF9DF21A866539E98C3AD443E34685B262D9C8821B423CEBEC83E835B7942BCD2B64C6290D300A1087B9A73D14B169E40B42954C8402F4F7AF5DEA644290BBD4CE125709B12850CF4F2BA8B9D6D3F904F4F2F0DBC1A6B5324C834AA5C9762DD4B6DDF15B42CAF4D4D28C9468A5BABD636EAA880EBB9F648FA814C0E1D5BC58BE94162FBC8B06338D83E06EC18F8FDE7B61C38FAC395301509585B6B29950D70B3AC7C1627554452012BA4B103ADCEFF6AA6C490C06A754FB16B63605962687B854B610DA8ED0D2E8535601B1ED621B649EC21CB0A2A8D652E851DE07AB36297FAE12D26A2C01A9A934F640F7BB5D51CF282A948C01615EE5359012FAABD429902AF635AE35C4445A4C56A1258E0C5FF55CEC09265055139C4A7CBFFBBCD0BFDB93B555A8742F4DD83A5A56D367839B18F226B72D906913908A7721D8BADD6BF7ECAD2BC32391F62854F051259E0AE377CB0443B225469AD4A69F497099F4F65056CBBB2EBB69C6BBD86EBB670DBE552AF548A290C887F4FEFF3F35594E7A89828B935D31C5157ADEAD9ADE609EF87E281786B87FB13FFA4A8028C10A7101EC1D32C13D847046444CCFF070F2D9A316D5EC1430BB279CBCDAD78F5F037BC4EE5569CF0C412A154211FBDF0EA6AFB388FF546BE39975DC1AA87931425AA1E067229CAF071AA1795EC8B020F7218CA42DE64B12F4CF7DA887DB9F4F694DEF1D016243D5B412EC4AA15A5073EAC9777CFA262F1F425FDF07D1347BABB5FF43908055AEF92303EAC605DA46A39474C4100342FA2A9D23A1462074F01D62FA2A10929F08645343C25A100F39A972AAD5521EAE89FC0B547D28F125AF48FCBA1150BC4E89FEA050F2D3625FA87BFBD605380FD175844FF602A12B0B6D6D4E85F99451FA8131258D9A3C6F010484481D57E3D313CD4E7D08687602A12B04585EDC3435516DB188A2AAD4321FA6F708AA19419AD7D7F555AAB42AC3C743421155EDB4A0E1E3A974B333B492E7A75C15D29D83629EEA3736C2B2865B55A9E0508E5768F11D77A7C2A939E26CB1B96B0DF71E8816F01865CB581A3220929F0F0DD1D6D21F05D1997A234E358F7208F7D519779AEBB50174F492EC0EA33B894D605686E49028F99D841728FA628C242D8F32C06ECEA22C8387934C856988A04AC6E6498CA0C5C995ADD190314934F6084BB8EE2E5A552460D5C2BA05247EB905AB60594EEDE13C25D276DD2AA31344815DB064AFD692F769F95C649919F652CFAB64C7F4765A194C40CD9A8FBEAB85F73997FA4BA67034B699E1E9D7D5FD74855673E8D55ADDBF70516CA939842020BB86A3DA295B5F82D0052120BC8BC88B6D51B081657A228139B8BA957956FB7EB7529AB50683E81792B7C95D8E015CA6908A06A3126A73183B2EC395E681D2029893DA4A69A62125B48ADE323A721801A2B6AEFF2DC3EC50F2A79D9F1EC409408E6ECF5DD0BEDC44561F80466B8EEC806CB1ED26C1DA94061326BE8FAE0621D394B9F95B7A42A139B8B79C90BB66E8E1A62C002DB0AEB238B0AC5811C218111AEBE1D433DA839B605D477FC9AC8E8BB392F5B6F2ECA425E443107B1F07416E8D60712C4C44E91F30A42D867D01AA4A7EDD5148A52F95D0620875591759EC674509631A42181B6BADD846B1B6BE5F2700792AB0E65B802D466B02A4E6F4C8A29EC00CD661C92CC123A1FAE6E53038B89EC702D9A814F640B5B4D48355EC3B543121FA0D054524C6807DF6D2C566D900489EC6065CB57094D3691AB5CBCE6B96169655ED5BB3BD44736AC7259946CD717D48E1092F7AD8DA2E34989459891298037F1E39309B24B6340AD96BA30A48A6ECE3C3C6D0A0172DB03C8E883AC6A3C3E950572B7128902DA1E41961EDC44B188F5421F403400DB1F88FB953DC50B5CBEB42C00C1BDA337E0E85F98BB33BE91C781B6C58F4414EA5C7F78F724E438E0FE9DCABE252D1EE4FB61B2DA74CF575AD446B5ADF207B143ED3A1B3CC577A7782410ED58DBDCDA66B304517418F6E6A0BE9B6CCBC3BB046B1B2F1D21BE2F7887BE78887782454E7D839801548D0F9E4E3434BD45498A66076DE1A3D1E1738677AAE70AD1A6B7CFAF6D166B184537A0CF37EA7BC2BE48BC3FD036F2D725FCD38777A78AA70D355D6293DFA27D2C60B45D223DF568D3253645EABA446A232F5D223DBB78778A3E06897787555E7DBBD840A8BA013E2C69E804ABC2141D00DBC447F34B4F48DE9D628F5AA28D6F9353DB1A16008A8687AF63EADBDDA624BCD5615BF86874E4E5CB3B99AC6F7C0A82B66908408ACEC01FFCD47708A554BC63F0B6F2D139F0B9CDBB53C563A068D7D8E7D73691358CA25BD0E745F5BD625F24DE27681BF9E812F451CB3BC8D0770C1545DB5644304527A95EF6D4F713B56CBCB7546DE7A3C3907731EF64B2BEB32808DAC62200293A097F0E54DF459452F1EEC1DBCA6BE7F4CF71DE9D2A1E0BD5778D31BF5D1399604CDDC23F3F6AD92BC6220D7DC2B791D72E119EFFBC4338965D638D63D75EB670A6AE929F42B5EC2EEBE20DDD26B7E1145D273C6B8AD5557EA0D5AA23A9A8A47625825B76F2B5F4262CADAFA975B2EB79B9EDBD0E00E16DD63B8463D9E5D638760D6A0B67EA56F99D5ACBFEB42EDED083721BFAE83AE56BAE773853DF81AE68DA7674045574A6EEB95B7D7FBAD603EF555DDB8EEED86EFBF55DF3EA2DEC2B3181FAB38574588B727BC135AD27C2600DD2BCDAEBEFC3A53776352D20A6B4F8062183873611F190C6911F14F6D74AD2D3C19A5612535A7C9590C1432B8978482BC9EF248F6EA5FE2D64E52C9252A8BF424C88B586F02CB3A63D24A45D4C25EE4D68CD0019525974E6F015E307C680853486A6595D9AA43F6E75C73D408A340A964EF3294872B461F8B361BAA6C1F030B9327CC3E8A6111F5DD5378F32ADFA935459B066824FC46ADA4A093C717B753B4FEEFA676A613B8134EACF909362EDA2DCECA2479AB821DA3708EFC437136163A0E9D49F8125C71A65781D51D3262818D22EA6A71FE9AD73C9BF2A7777293E68071B49975CFD799A5C58935D4A4FE1691A4E878CB49FF47D3E5A8FBBF8892B1F1D619AD4DA2F546452349D74FF95BEF154D03B6FBB933BF1B7B9FD400EDB0F9533DAB423B8D38B828F37A6B69FDCDA13BC867777A978DC0F6D5CEBECDA96B04551343BF6F29FBEE9AD0BC4FB017F267117DDA1741DADF38E6A17A57B39492F289D4F2499FFF6EFC780530F6873DBB68A0EC4DC0BCAA1E95AE2BE7A42BCB1E80E676A828023D06CDB8D026AEE39708F9375FF91EA61EC4FD0B69E3B165EBF72A74E60DDC14EA8B60DEC026EEE70F4C21AEB4E77AA93B1F3D1B61F3D00BAD34277C3D9C75E5BC08ED5A456378E3A13D611DCB3789A06D760E20D297FDB78E75C7A52EF4E78B30F71D475E935AEB6261BEAC0C3D700758EBC0E1D6948F1D9C2D16D283C226837024D59D4DF6AC88935A6FC0AA2A6254DE8FB1A95D23B8D16E352CC41183B6213F81F9B223ED2A0FAEE726BCD7E36A04F53A2CDA9CDA2FD5E5D4E4583DA894B13B67EAAF34F1C7A6D53E9CD547D6B8A89EDBE55C8E3AD054554A4EDE4C762FD6969638B919BCBBEAD889A7906ADA49BA8EAC4846FD34D4EC7E6D2CDC94926E42578A0F1EE123EF525BF0D891AFD741CAD494D865318F6F0954ABD294F2F57A9DD29EF6B8EEB3ABE8CFA5AAD3BF825A66EB3C2B06B3A1B285377010CEB8EB32ADDD069FE8C32A466FC7BA1EE1D654221359601CCB2B3740FA18EADC1BE3B4C5CA672EF323D0EB9C9B470846E53BFD132BE16FBEEBAD69318D76F1A107273A9B1083DA6B8D26564F9FBEE2B6941D3BDBF0C40E436D3E311FA4DF37891877ACCA8FF4EBC75208A34A6E53040B72E342E2CBBD4649F9DC8BD21ECDE7F06105283E9B12C7B4DF332F2C8F2F7D957C2EBDDEEBD658421B59709CDB2C7B42F938FAEC33E7B8D7B01DDBDCF0C20A4D6D26359F697E65DF791E5EFB3AFAEFBE7E3DDBB4A8F416A292D9465470D18D47ED297BECF6EE215EAA8BEB20022359919CFB2D724206AD759D46326FDE7ABFB3CF79EAFCE1BD777F3ECBAAF6911AD46759A1281DA502A20FB8EAA111CBA4859F24E3B07BEC8762793F55B772808FA26B20752750EFA109DA16308A52A3A066D2B1F2B9F5C904C7A81195DFB5426D7AE53AA7229D63F6DF7E9EB90F1F563AF7BA3C5079AB9F2D5CBF0786AC31A2F9A49B9746CBB4F5F03BDF3B63BB993DFCF36B51FC861FBA172469B76D487530CF8AA8D0C7EF7E92B9EB56E858D820B9E06475B7D3CAEB6ED46C32B7A50FB18B9BE3BC75709EF74AB3E986A28747E525D8EEA3BBAB75DAC07020595DCE60470C22010509DC602A55EF6234131385D474081BEC57E87F24C02C005CBD0AA0E90CA3EC6B12CBAD6A512AA0E55B6A9CFEE04CFCEDFE14CC33C7602B36A4B1AA6A14775B8D6BD4BAC91BE7B417ACFFD7B53DDD59B17701CB60CBB896A8B62D57E966086AE1450ACFBCEB66C7DA7C96DE7714BF387EFA5145FB2E575BB45EED768B56577F23E61FD26674B0C9B6DC97650FA8DD02886EDBE68CB0AE0FD753DC5D673C4F596C9FA494541D037913D90AA87A8B10762A98A6E9928F6A07E93F84EFF9232D24DAE589AA67384C4AFB0D0BDD6ACBDD5C2B112584F6ADBD45777F22F1DDFC18797955DA7CF676C216D764D97C80F389BFB425F92A6DD55D703B91C52826F20DD71EF2C214794B419D4DFACCD871E4F32BFCE4428003B50A37C4ECAAD19A5722B86AA01B1A4FA2F4372A81A8DD05E18AAA2A514EF5A8D6DAA6197B97D9B21796C3F136635B7A2DDAD41C6727CB5EBDF7E68104AFFA114B8A5F4ED797FFBE176F1C4D6514BF8DB0F659205DB14DB68F5395DB255DE313E479B4D9C3CE643CE96F287DB4DB4283FE6FCFFBDFD9F3F7C5FAF92FCFFFB9FA7A2D8FC9F1F7EC86BE8FC8FEB7891A579FA50FC7191AE7F8896E90F276FDEFCF5871F7FFC61DD60FCB01084ECDFA4DAF6251569163D32895BDDACB4641FE3ACB4B1A322BAAF5FDD3C5FAE41B20F37D717F7D56FF6BD107BFF6F7D037745E9DF1D53EBEF0AA6DA5FDFE1547FB72F5B5F7EFD6359833F5675543E3FD600CBB843637F2CBFBF92FE7553306E5850014BC8DB45B48AFAD335565F7C7951B66CBADAAE13DBD4F2E8D7964C28D65B99285663E3D87EED90DABEE4F69E30B9088E6C8FD5090E198CA7536AD6DD83072BC773EC112FD2C5B61AB4321E4FB747EBDFCB56C1A20946E05B9733B23C5537A20908FD595ADC5F52A9275B9A3D4AF5E843297F4ED7D5F017C12416A166AB3457604A2CC258CBCE336994D514824C40AA43AFC765DEC908B614B1440E7D16DD1651B1CDF199D4F128F5FC65F3298D401D3B2A410A954A561E671D8D249191177A1049AC48655F927887A55C02E412C675C6A2822D2B4B4D1AD53C838C571A0E0CC56B18F678A561173FC45805450E1D115651E410467B692575F7BB48635DE040C4BFFD20D94AB291F603B0D224335A360647998A5D9CC5BBA9882F8B8C30155580F3339E68C50683CDD56083D359E4508C9C56E5414889451211EC6396AE817868A9FB3250BB5CB232E4E9A4B1FE892D1F59D68E64648003FE7ECDBACA0861D5876AEC3B559A3D1B8FCD0BCA18A6C4B2C7FC2D2E9E9659F47BB4C26021D71EF997A454FFABF8BF6C79FEF41FB66518BE2A0DA5944DC6F2B2A7F4C5281291DBFE5CD9F4E7EE2D8F8002A67BBB23E88A24235A1D2D044FE3E07ACAA24A6010CCC028D9462B196CA0526AB68EB26F72A51ADAF1B84CC105092E885F17E42C4ABEB5F2D2478C1AC0B9B91B16301AF307E4464C20348D7D571B8B1889DFD670D9203CA93C15344D7051F611350D316B6D7F7A8929FB89B4CE5DC9FB898B065321980A93990A3E6294006EB4A9E0108FDC819235161194F81EE38C338FE45563431DC793B824E4EAA55B35B2C4DDB58AF61D67781DD1014E147EAEDF375238240D33981266BC604A4C644AC4AB55C9CD5EBCC41C44304733C204A213D2625E4C50C3148469AD871F85CDD74DB91E8AA408E609DA9ACD614AB654432B921C87C1D28C8F667551AE9FCC23F43A8AE782D45B0F55E8A11228CA68079FC0015F89BB0F63EA4B9435876744208E4C58AA5D44493736A4055A81733C4655307E82F13391F1E3258A22828D347E5C2228D39A0F06F8609A5822FE3DBD3F5F45792EE3F1F43DEFF762F133261A440E6DE440B4814AF8DA2DB20BAD27127A759B5546001C701C9D8E7603E5BDC0390ED3B231F76EEBFB11C0E288C4DBAB69E9C9F42B0D8B3CC7EC3F8141E88D38AFA379E85635894747BD66D9A2ECD2E8519E2408DF1EFD6BF4BDA9D28F222A4F77403B51A021B7A659A0BD55A0BD75427BA7407BE784F65E81F6DE094D01467245183A003972D88BD6A15C472F9598FCCAB2B52C53241619B39C8E71BA44313B5670E0CCC8C1817BA50EDCB6B40FFC6C97E3901C5D372D82CE6FE332624E9BC426D8DD6DCE7C91C51B187642D8C7E0B1F9F7883EC6D5758BA549FB2F164953436291C2FD139E0D69BA16532E22878AD8D8064DEE1F316029C118FC13133EC94A84D9DF9AF0497623CCFECE844FB22461F6F7267C926D09B3FFC984FFA771F87F36E1FF791CFE5F4CF87F1987FF5713FE5F47CEAF37C609F6666409E6293C720EFF689CC43FD27CBDEA51021E44F284207BD7BEC2657EC1564CD63C0335D8DD1678C1EE9EB9DD5D2DCA9603661DE7798CBF7C6D6F798B586EB6B7094363858959D10D787202DA3E303CB22972F611271DBE09895B4BBCC395A241F605D9E759F63D5597429F5717F0AF7CAC1B433C47196881A39383203B260BD14484316E2C647409B38D4B843DF823F7E01FF17EF6633B64386D74AB9111E010634F0D2B26166D18AC97576FBDF858378178E3AD1787351498DD60BDB8ACA7980B195BC2CEECB057642585EB06F66909040D1B34EC6BD4B0FE74EB78ADEAAC4F0D9AD44987BE22CDE3D7FF9DC637F7173B68C704144F1C7D2E1E64157DC722F27494B352062D9E30AC81E3A09D0FE458DC75F4C26AE105763076E4BD78F5CDE17AB6C4BA1930771D816ABEA8EA3BEC4B1B3A150DB3AE440E618D7DB89B1D5612308FC7123C36CB3B5C5E15ECE3F9DAC75FD2EAB060F572DE780BB9C17A1963222B218C36729B53692473FC63B0925F994DEBE7B2C41DAC86F8B400427425688F796B8F1B566C332FEFB340BC316A448F63D4257C76A5429113512585AE90D125CC566F85DD17F3D87D518DACF3A7EA6D54D9E9E139613F07113FECE738881843B087823D349D3DE46FCD89C71B6F0F39AF3FF1D90DF690FB7E0E5D21634BD89965F78AECAEB09F23ECE75023050D1B34AC670D9BB1655C7A4B859F3D1D129AA37635A2E834929419D3474812D2C8D616300E5DA89E5AA32249823E3DB4A8C3A1ED8798E016BB1DE9F59DD92953596DD9B9AC516ACAEE235CAFE17D8B6065052B6B2A2BCBCBAA8E8436D6CA7259D199DC463114102C205BC4B9DFC83C670B6D9ADB805FAFDD37CF53CE73BB9135D847C13E7A5DF6D105BBF7178492C0DCAC232388C63892F222B61192827200400B3F0A9BAF9BD2B2435204D3EBD04C9BF91A092138148243F3357EA636DE8371158CAB898C2B1FB127096CA471E510799AD83C31C007D327449D42D4E9C00CCA1075A28CE1B91A5EC1300A86915FC3E8A71577E0DF47E40901743390AC80344612921F319414A90853D25CCCE832E47A2ACD3E45AA609E295A75C2232FBC91A2365FF66FAEF93327DB57ED20A0C0385E636D2E3128E906974BC9EE40D8338C13EE3AEE39515C12545369383B1EDA5C2C04DDF2102731F619BA740419ECED18DF3C0F75CEDDFCBFCC6FD8224D16F18A01349E4390156CBD197262DF8DA7082E8B192FB82C3B70597CC47311400F2E8B435C3718F90712837D1D77231D9A01EE39C61996DEDDEAEFD9C49DBB51160C9C60E04C1E93ADAC70EF71D90AD45B6C1607A3C5672B0CBB186D9772549C162BCE4B5921FA1C0C538B560DD1E7107D0ED1E7399ACA21FA6C853FE778709B4D811662CBC7105B56AE6A2C812E55A60B8E9E192F387AD3387A7F4FB75912AD3E54D7C7FBD87B03F1DCDC3B1B1CCD9C84D911E3164F4409EC9A0A195B825449A5DB83270A5ECFA16D393E348B7F5A0FD293D53313AFA4B92A03C31239842FAB4E4160800283E0BF66E972BB282ED7917C71B6C8391E8B33D853C19E9ACE9EF2B13100E28DB7A71CB605ECC40A311712EC9C7D6F3B0847BFDC8F7EF93C6A34C76D0BE7DBAC2A1B4E2F8E4E47BB812A4FE0841D9F186A494CBADC22A6C8095697055EB0BA666E75094EE638834B8072B3B50C10FB5C8E858FEDF2744260BD4CFF893D336965972353964DB34ADD274BF65D5E36E518D42F3D4F97E89736742A5AF53786D6D0EDD1E6FB26B80F55D60E4C4C93492C82222BA26419654B18C6113924C4825573174E068945518EA5D9FF4D568D0D8D8272BA28E26726E374540AD2055B3159250CD47DA8FD7608C8C617470E2684192F9810539A10AD5BB75DDF8F0DDC40BC31C6841EC76851F0D99566859C68EFAE3CD0B922E718C23EFE6E57F11B00A9B645A810659E3DEA439C94A64939C8CED8639C407983F11DD03F24CB725269E0F90494E511F6107F8776254F0F1ACC8C1734D8441A2C8D126FFB38243047DD6502D1292E312FA6B5600A8A18D7C28FC2E6EBA65C2C41521C83420B4F60CF71E5E1A6AC07C41BA854246CBD40E49044ADDCAFC4FE3C8F36B1A252128BE0F62605CB588E6EAF907904B32A2D2BD36597AC2A9145C43C2B1960ABB1C8212046DFB1CFE6C89450155231873A859D24C19C7BA5E69C8F6D2412D84873CE6103C9C40691013E185BC1D8DA99B1E56733C5699E33D4FA10189496FB3D69CF21CA4DC731088ABD0AD17C4E93E24989AC48625FC68764A92F014D4037F2E016139143585B62D973BC60E74F5126EFA19558F69857C513CB30448141596FAD1BEA332B9ED2A53C2D01737FDB6BFC6D97FA5807FED8659297EA6C5B006989F169BA07DBABCFD36968D7DB6C93E62820C722D690656BB4862D9D58C3522EA64BA47A2DDD1EED4B7AF5D00EBABCCCFD2FC93E43D88499B3A9746AB4FAF0BDC8225480E02928667FB4605863080C8AE95B4AB3D58B1216E39356BEB3A234F2AA9E821A1E7277BD7FE032BF65C9F2C3BA8A154A1E19C720E88F2AC3E972594A72C9651439D41ADEAE73AC7E3599B2C6B2629BA73401F25260909CD9D2D1BA4E37DB0DA81ECFA1CCCD227E7839630FA52B504DC48BE82597A7279662FF6EFDE7342B1EA347568D65B92D441E656E36F930B794E7D011D576089E825E02D0A21C3D844B2CF042B864E6E192AB0D4B9292D2C6167DAC81A1906EA1134B284D00054540C228CA7414B3C9A2280FE5C0DA2A8343CA74218C337DD0E5D04E257BDC543393B3C3735FFDF814432BB6A305A3C08C178C829D18053E565250482F4681C3AACA0ED5A75551414D87D516756FCC78B5E5351D0D0D5E7C50D87355D8DD4DA91EBC7701CA4D411B20348A59C8892864C0272FDFE1D02370875A29CD08C00F6AFDD094F001DD7A1C6ED875FB1ECF37EC96C2307D78503512E4BA22DB9530A624550740AEEB37C84D0FB9C71B75F363884FBE39050F0E22EC7DC41BA7BD02E2B82F1FA86601B807BCA51150EA9BC3113F81A3535CADAB67965D473170B6063A61C3807871BDB4694066EEDBCDBC609B348F715091155C570BBCE0BA1E86EBEA23C62C408D725D1D62CA133A815AE8E05C5A214E73AD63705583ABBA4357756A97660223DFB7BB741BAD58B5A33947FC5191459136AB155B94CAA0FA298B1B8145C09CF9A59E7EDCCE76C112039358849A2D9F5598126B7FEB543EAFA4F5B9E205FD1B9143EE8556C2A357D3A1298ED52D0B2E5470A166EB42B1A278398FF2A7B378B5F2B20608011DDD291B209D5305F363AE159E8A60E09A8B195D865C4FB5A388A70A6EDDA139621EE3DB33DE0D7B1B6E4C0FAAF675AA5A2F314B08E841D5BAC42F77A39C2C8A090A706F71CDBEE971DD85B0EDB13FAC37ABF485812FE7E9A4982463305EC391C37EE25DEE270E31DD7D98749757BFA037ED0D64CA1717DB2C614BFC9242914788F2A4A5822A5668384FE639F48EA24FC29EF3600A0753B8E14F6E0A5FAE37D51D0B5E034F02E64883D8806563130B103AB318243C06AB754AABB06D30548B892C8AD4CCB7B81E1339046DFD5C766774BFC25121D71EB9943D28264FDFEF7A5CB0ECDCACF56009044BE0B5590257BFF8B5023ABCB116801AC74AFB77D9B59A9F4FE4A05B95858C2D41AAA439B427243A06FB65CED198698F2ECC79E12868B4A0D10E41A3795DE5E9F1C66BB4316B3C53EA017321C7AB69A6F494FDAEF484D59879E8FF83B8DD2578FE34FCD9AC4A94021633DA3872B002CDC8C10A7CE556E0E7282FBC99800DD848FB4F056263FC35797596DF90E2188CB24370B1FD3D3C1FC46010831389419FB78CA1982385E2887BC750089D881C73139955613E4A422A6C76FBC71C54B72ACC4749F3D536D39D71F07B3CDCAF331C0E9B1F9D131BEE4533947458F7A2CDED3452772959BA0482526251B6BFCCF3A6AE39DEB1A539D9ED7CA43B8488826FF4BA7D23AF8B853EEEB3B2C40A1EC4317B10AFE7F2AB6996D3C2B1B8E0DB1D836F37DF4B9FE6B7741AECE3601F07FB58E48FB78FCB4F5AB03C9F62094180F6632D1B200946B38064613B83F4EE26B4B6688FE5AABFC2DA6300E9477FB59DFF30A2DCD7E44684858860ACEECE580D0B053AE4B985F383691B4CDB60DAF646C424A6ADCF40B001321879AFDDC80BD15D1FD1DD60961E9B591A62A82186AA430A866630342732346F58BCBEDF6639AB8AF764610A98234D4B03968D4D2940E88C4990F018ACB970F475BC35E7773D7DEAA7977CAED74F69C74EF5BEACBF3096DFDD914D2EB067B3A75246502BA8F07B5525E67E2DC870199FD7CBF8D2F49BAE9720FB906DFD609707BBFC95DAE5BFA6DBC513CBBC6E6A103047DAE5062C1BBB5C80D0D9E520A183FDA22DCC47494885CDE16B90F0183C8EB0492044630F391A1B360958B5BEB2D50F7BD3413843B8DF3384AD4AC44C7E8915FC088BBE097E44F0237A0BD3AF1FE165EB88016B2ED6B65D61C1AE0FFB422CC75138F5177CA403F6917C7B01F37BBAEE75ECA609D676B0B683B52DF2E9D6F66DB46279053BCEC0EE61DC6C6A4D768D19DDE7422C6781E720E6B49B1BE8B87D752E58BEC8E24DA5B6A4C0169A8230F8D87D5C682F76C55390A6F4D250842209D938C25A5F6251FA7491369B5130B10EB914C1FE35FA7E16E56C79955C64B278177914D4D345113F83CB6F3BEA9CC4472DD4A24535582FD8439CC4D55FE344090AE926562CA13422064540C48D329D7DB7A310E7E9521A079A6423CB821E93261965387FDEAE8A78B302037AA053D0C2CDD0C1969AA72DC54D97AF6CBD59959FEC6313841276B45034C1D9094611452F1C615A27A1A52FD2537978CD95B15A6DDA10440DC1B557155C0BD7251B4A3AACEB92FD84EC4A62D2952FD54DE0B88C6774510261EF637BC75C37514C758C618E9B332EF3AB67965D473108C30E74375BA40A5B29ED8F9AB9AF65C5A98FEB785F4A99F469A28BEC5C76256ACAAE977A9A201986257288B13F0C5060846510ABBE09AE7B70DD07E7CDBBEB3E66EB11016E5E4EAD7591C1893E42277ACE7BA5FCDE05DF8DD926462E0C6C81B3EFBD5C9FA3640BF106EAFE4CC0291DBA7A89F5BA94E988D72DB2E6636297502BB62855011C52126BBFFB834E97CF2A4C89459FE9D0C31239FB77DB3C3906DBAC1A29506D71743ADA0DB43D058EC3585706F5F611549AC659F11FAAF2E7FE5CE6376C51F661692D96F661F62223CADCE05899F1826335BD63556F6EF2BB1EDA438E77A8345096CE548F6070A48474CECACBBCF6E9580EACAD957B28A43B06576D6FDB7FB0039C087BA791CF4923B34DD6D2FC5E94F3347A94C425E4D2B60B3D44DB15B86BA72787AD47167841CDCE5ACD967D3146A596D95DD4279A4D2940CAD44068B43482182A73C02D91039586045DEA81BA6B2F260897205C66295CCEB77991AE472D8474100E42469D551DF66872C020CA40A704519A5C50E8881C3AE2D7B89077444B2C3A26122314380EB50451329143B1F34BE36D513431562C9809D80491C792A53C9D3A1A212C1AAF56E5583C5D2E3396E73F4A815199E98A7BA2C33D71C77DABC37DEB80FBB5D43C9BA734612830C725237F4EEF6379EC4B2C32E6C7E83B0A58D3EDD13EACAB008000D492280641753768E5AB54E775E050C7F8CEE897E730188B24B0C74710C91862159A3ED557734843D9F5B22A73662FF884855C67E4132D3269CE4A79DF6A9149B3B6CBAB98B6089B8E8D4D5C9947470553576050F7557D8AD731BAADAA6550F71F62783C83B6389C6651F68240CA3C7BD4AB6D911751B22C659D082930F6B7C853ED4DBDC8A207B0D0D893E956C9E51A048924166529FC7BBCDEAEAB9B4B2EE27C01D7F1D00474FC7A0CEA4B909250476A693BC5E9121BAA1D87BC05E42BCBD6AA73B82D8B3A3FD15A0A1CC28C8ABE5F5E4872BFA39150BEA410A5A611EB7282D485A41FEA72214A4D23D6E52D52179246A9CB8528358D589777485DDE91EB02516A1AB12EEF91BABC27D705A2D4B4DD878D3EC6DFD912972B8049C1BDDDE69BCA8502EBD51C838277B68A16DF3EC5790111051605F353FA12AD0AB0FEDD932958EDDEEBD52AFD1DD65062EE23AC7796A5DF605463A0D2B5681D0A5485497A262DA43A3EC45BEA952C2ED20C442E05065993CDF8A98EABE28965389CC4A26D3659A19B4D56E4CD26D4DB2842603A04A645FEA481E97AE078884ED7382342D48AFCBB96C2425675D89A633B62C3C016C20ECB68415A0569255B1A23A49580E320AD0CF9776D450959A1B442D88ED8505A216CD2AEB5759CE7719A20DBAB251E3DEA0216DD0406451A2A11251671F3318B3728A6C0DA878D19E47F90FFB394FF9DF71A8FB968B377811D04BF26EFAE5C71CF0102E46E3C91E58009D584C40AA2C8022F88A2398BA2D36D91FEC41296951F7A993CA463B68E4A502EDB488D104A7122E504A205E19306CA76C5A091C3D30983C4EB11E88F69B6BE94627B1D8D8602E5DD40A5217D65DF0B88D450091670C61E62693B4047A3A29C6030A475B44A8D7C62C963F1245BF803DD1EED76FB00BEADA311946837AA816A113934C4F3158B3208D792694AAF5A1D824AAFA1D291A0961739B435ADCD6615B38AB1DC2EC06A196053B0AB5BA47E2B2D05F64FB82025F2682B5CCDC925AC15441E6977569A15D84C13395444282B793A61F6A697F9E7285946B5B52ACE6191451A4D71BE898AC553E9A246AB1518511297B4B2192DBE5546035CD71C18A495C828830B90358D20B9CAF4B286E86894BAA0E78BC9C78ACBA9B58AEE9BD100261DC721B5529AE4F16302CF674B2C526423DD26CBAB870710D6E8E9A4984625404BAB1C7302441E6D5DAF1CFDAC1551C846283C05A9DECD32F765F2F315A836CF72C2BCDA16E5372B713BF63E62479FA297742B55ADA339EC9F1B7963EC9E9C83FA2AC978CC15FE2D82832BA0CCA9DC13D16440AFC38CA9173395D2F1FAE13B149935918603ADEA814A4342CE5FF454A2369097185B1A6D27A79F5B4C61FB0C54C24C032E3C35DEDEED8CBA569C3CC6F8A4C000FB98A56B101468A934A4AFF275572D8DE07F1451698CC572D373647BAC0FC91222F5447B9C5FA3D51669248E4CC4929BA927D247057AA1A6C4A3E8A9B22AF1B2748A7FFAB5BE6D4A5658804DB386D6F771826C5CEBE921DC68C60BE1C6A92C8AFA72EA314B1F038AAB61A1C8ACB52DBCDEB6EDFB16701813907994DDA5552E442F73744244093D91E572120B3F81E572F20A3F71E572D24A71C2CAE9641538FB443CF3849DC8A29FC4FA58ED5E07F5A09DF309CB5D41FFCC56FF8C543C8E2A87A66CFCA8065C2990D5813727ADCCF30F80F28FDD6F0C1DEF2C5EE6D591B7388940F078A00771698117C4E5ECC5E566CCA6800AE11A02580A4D34A74E4E951930D1D992F7619E438C20A982A40A92CAB7A46A6E78E996C14FF36AD18F2D877714C6C83013B68B74A3632AA58C090A08329B0C042927C2194ADBF70B19B7ACBA275F8A7AB7B420072DF0821C3C2039E84FEA8D9771CE12CDB344F17FC534F4B35DB76375F9A0BF2D7242F8D57FF8753EE1531F17CF4D79C5627D13C1D9368F93B2BF2036C2A6CF8066E3A17A66F17CC2782965DDD543573769D0483C9A9552DD57D89CA304660AC7DAA7E553AD2A83CD563589B479AF4817DF7A912EEFDF1399FBB0A72EF3EAE181AB87877801D0788E3D62734DC675246FFCE6E9048B22FD3DC1F1440E6DC6AC5495044C4AF462F16DBB81903C9D627767CF65C39F3F4599BCB346623962623B34D0047BD94ED8D92AD7B834ABE8A459F894FE7E93CA3B65787AF040CC78C10399C203A96FA11AE378D4002EFE8622A37A9F83AF5BB49A3CC8721B47A7A241BB8AA7875085055E1014731614D5A6E36AAF7FA3013FA58F2364467BCB1F80749022F6506A658F23C097A8D4E928A605826255147D4F7CFD64297292A8A313D0BA2B7A65348E4E32049127715D1EC3ADF7E6A7F00B890E7CB22865BE8C335083F4B6C00BD27BEED2BB3D505F4BAD46A494C9AA70C7981BF874B82E37F2D1F074724109831DA7D12676701C81407795E15F52F414BBC0A121D68746CA2FC3E426CFA3CA4F152EE406796A8117E4E9E1C853DF72D497FC1C2937ADE4A5939C9C46B27D4975B24DE412C666F3DC6803815DBD8026A04A4FAC2D44CE1CE471FBA90D84A62DC40441DE5BE005793F7779FF39CA8B718F29F6208E925D955927149B3C980C1F38F4B0021E54A02221775CF754A2E807E1579763FBF85B1C2E8F705CA77152D40798452C9E4E98807152BD3254679696C12516E56CC605636B553D2177D7A73E822A08AA60A6AA207F8A59F6719B2C46EED993909C948201412D33858C503D0036614F559B0BCA64914347BC60F9228B37702F0B9A80B0432A036FD0B624DA5E2570D96E4BDBCFCE1A44ACF7C4203DCD78417A4E273D47BFFCC2C1B8CB4DEABB2F5C2E85C47478F5E5C37AB34A5F58697055073BEA980A264B34C98268D6632082902C06A1D34375787C2988D3C5026C861DA8414118F18282380005715D1D77AD5F6219AF25062C7755A1C330E88B21AB42698809F6B7DA5857465147379DA65262D49786F2FCF754BE5977A0DA23FD3DDD6649B482EA4F605022ED3084F5817C8C6822ADAC800B1A5E217BA3EF08CC403D4C5BC1D7DB4CBEAC8E26102801F5C4E028073B28D8414D5F3C45C9235B7E8DEE57ECB260EB0B568CB184209A8B2D6483A21C753033B035F024044BA1BD395D7EE5702093B190970D790645F23D40AC9E48386F10D547143E6EE5A7100406654DBF56DBF23A7E4BA4D4AB583CC99B0D7AE23E76077FF8BE89B3172843783A416AA6B9B430D850EC114E9F1F21484FA48C4C705AB225D96380A74E88EF9B9C95B464015F4CE1E98496414E03D20F00FE92C4C5D5C36716E55B780E17301D71A1558DB029A32A792E7F7E8C16A5AC958797C02258341797D205020D858210CB7710B4241A46BD6E8E007574DA37293C548945C23C0150A4AB11AA6F011031ED7A85BE3D10A08E4EFB26753B9DB8B6D35B0045BAF8A1FA160011D32E8FE8DB0301EAE8B46F52B7D35BD7767A07A0DE51BF1140D424877642803A3AED9BD4EDF4CEB59DDE03A8F7D46F041035C9A19D10A08E4EFB26753BBD776A271FD709DE965F23BBB60D8D60915D006BEC8268D35DC88DD25048083940207E05BABBEBD6657BD7459949D1DB12CB1EF30B2BA4AA35947DC583FDBE7B59DD028545B5783AA12FA3E61D4F30AA383AC533AB9F3E973DB39648AB55BE8E40FBF3743A1A8E45B231BB539AB2BBCDD1E96838D6BE561CDA4C2812A9D567F8D24E3914A113DB13293E5BCE2A67055E953BD0695E91AC173A1AE1DBD2DF65909644D172F8CB90F417219B1C5FAE4053B7542AD2E9F21983AAC984D580E83BE62073644A5B7D95DFAD6849A4FA5C2B9EDD9258244BA5BA8D0A982A0D91302AEB1714CFA4A8C440254982622BDB1C2DCD1EE5DFF2E8FE376D6C4FB7AAE01E11376906E48080C0218CB4AA165847080C426F4039FA6FAA14BDCC4BC23AADEFE2AD1F1D5ECA8316F24951E7262F12C31E184EB55556D3CDC66CEFF554999A3D9B2257AAB8BFBCECD911892BCADD7DE9321E6012EA172FBEC1458B814AACA12C197A22AD77E30479BFB82713B00AB62E0509F22A2FCFA0ECDA58C8EBBC2D89F27DE7553479F58FABAFF217720C8A4C67BF230F6A72643256F503456B18A4758F83BB72EFF6297E0046604F24ADE6472F1F90B7E75B2A55FFA3B6A9C02168B5665152E5AC002E19B97E0E14F8098049C645C5A9CC23A31A6E7B56A79AE5CAFA75F45215EC6F717D001CB9BEAE03B2E9F821BF6E0888A976EBB6956563311C8EBCEB05C476F1125DD1A4851A8199794B35337D05A5E6BB49D44F0061DE81C507304B1A12654C26DFE46BD73A1A4578B3FF6C19B2E38BA3D3032E20BC2130C86117D0541D75F79B599A4DBCD0B6E3E954A36489472596871896F07B21A0FFC041970FB96140E0CC251053280331854320C6479843E53FBBB9CEED8D96B0830506450235B7A47F4D7FFA248B209E735C818DF905208203181CC0C37300D3757BDEEA76F1C4D6D118D74F827271FA8C10CA0E917282AE40F8949D89626E4495A229DC4B80E6169E822456C22532125E38DD21E0ED4D049523251EF3CE653BD8DC240E9E533351BDBDC2E6FFA5A4B61AA87C1A18643C541A0D0C82AD253FB0256D88C6F823D04F0CE8A4EDC420F75B033A69136E78EDCE5E641ED36B77BFB1FBB64145209E4E99AFDCE378F28C1558A42D2E9717D2B8EC6844941304853422EB1C6F1114DA68AC72BC435048DBC1EB1CEF1114D266E932C70D7B8CF3A2B942F8CB767DCF32D8DA689A91A5C0DE40D38C2C05F6169A666429B037D134234B81BD8DA6216EB1BC7AF818E725F75F2C922C36844DB32E7CBFEDE8E725C6E088044764968E4867748F72453A10276F449D79974E44970FF323449E0B2AE64D88BC204C2CF0823099B3301106CCA8E08638F41CA48A0960F73342CC0BA50CC6774587D206E35324CE65F25C36739ABDC842876390F6ADA6E058624DA2607C8E92ED43E9DE6D33200A051605F3E73863D7DB6CF114E50054E49176B166E0EDDF9A44C1F8297E287E4DB78B275918482C1266FD8CCBEA135B3E22A8229382FB29AD3C847821430E74529F646577468F0CD99A2CF148A869BE898B68A5C14652504A38DD6CA28CAD34C3144B41DB869317D1B6540485FA2BF034A4EFF0768B982FBB255817AFD0BAE8D692473D3CDB40383D34ABCA6ADE51E265E7A5C73598AE06D008113974446878889CB036D046D1C2DA804D341FF39A017BC46A966131CB6506348F9EA96716CF27EF9F53830336612C96B2F2EAA1FB6E69404ABCFD4662FD877DFCC476EB53CABD8290D024E63ECCA5D29465D1F2EAE101DC1B277228BBECAA3D96D791FC64214F279822E9EF098E277268B371A5AA2460DAE39E458B6FDB0D84E4E9FB30AD7B9BE25A616B5C1347F453FAFB4D9A02AF75A013B4E662D1F890E51FD5891C79EE62FC10C234E305276392F59072048E7BE5B141705A0951E454EBC33A0354863DD965FFBB0F6FE5103C0C5F7BE0FDEDCAAF0264D1B23D3F0E63671C8BB0DA3EC1B1F2FA7601ECC5628141FAEEE825FA3D02C1E59E4CD2A9DB2255E0092C7BCC7F27F269A9642FA7243EA58F9835F348B53BFE9EAC204E4FB4C7F17671DA36DF30F9F0474FA4D8918B2FE9896C41363422CA5B0485E4E1D739DE2128A41D39758EF7080A69C7CD7929D1A0D1D1D008332B794EA103D11109BE839773BFB7457571A3141EEA89549C130C87346A5A17BCE2E1CE79CB2158B6E96A59BD628C404A2CCAD76E10B8816A8F54F98D52EBB7241AC609C420B57B95E12DC420CDD52AC33B88419AA95586F71083344FAB0C7F82187FA262FC1962FC998AF11788F1172AC65F21C65FC963EC0D32C8DED07635C62BB0B9B426D130C0D6D19A44C3001B436B120D036CFBAC49340CB0A9B326D130FE04314823B5CAF06788411AA95586BF400CD248AD32FC156290466A3DA0DE20838C3452571B69C5BC2690F29F00009AED13E71BE8FD0F541A123CD43A5009DEC6759A4936664B22C4EDE05DDA67D4CBB42BE7E17C2B5F32D31143C4CA8C1722565344AC32B68C8BCA1AACAE85F91CE523C357089C4B2CCB0A4633F0406E10E552A4A104F3936FF02EE486465A98EF5E069557E67BBA43B0BCF93C65AC7C603B605FB07B0D74CF75416E2FD357837309F6B314E66BC92588F120C6BD8AF1F50DDB9466CD799A94337BE4C3C700CC49849B41D4434ECE0BC53796625FEB15951A51A81981339FE1B2CD32962CC6DD20D060385D21A0CCAA6CE136077C8462A013FAABCD85DDEFC573E888CA678ED10474FC8F69B696B79CC83C3AEAEDCBFA3E5DE1A81D8F60186D5FCACE475C268E4E5981AAAF0282700283606CE4E903541403751FC640389215CC8A799A15AD10F839CEEB433AA395850288A03394082621D7665469108E4D17A07ED4D26B119C41480521E555483577B27E646C7956BF1131424C89504E72CA04A11626624ED5836B3C9FB417A07E784F5E3BE7E9743424DA2F7028A2B4F9BAEA17FEDD0DC71EF18B7C82F00BEDE8E04F2C59CA53A0A311C4A6BC6FEA94B65BEA6AB1D86E90ADE13CDD1EED43F11427F122961FDEE6E934BF17B975B9A7125AE9A8CFEB4C71C754F9F33906CF0D0C54D25A5B91C50BC9AB1CA884D1E5E104CF2CCF3689101F690FDEDDB007ACE73932090B9F2A02C305EF4485479A3343B6B72A3CDADE9AE83E2EB6D1EAF629ADD5AEB49B0370093E77C1D6D719DC913690EDB1FE59D60188D49E48DE6D8BEEB325E1947A21AF6CBFDFE2E2E9F4B99C816543C11A6A925176A7366D7F2ABF0DC5D11D6BFE6B94C54C5BE93E05650F5BF4F090A33D26B1A898FF48D2DF57D5321586CA31297B261F56DBD28F848F3F881CD272E3439A15D5F5DD60BD71605064E3A240DB5260D0F0D05920306878C82CE7C834AC1264C516CDFA0A40149834DCCFACBA182459C6391072089B867DBAD9B028834F13C93C7BD46A309FDE972D88BE0D09B914FDF1B82DA96038F174BA6CFA98CAB704F20C8A3D51C4CFA55F93CB26454FA67CE9A27E1571F9AE3E389CCBDF2B73ED91FF956EB3E61E7D09546038D43442C63D601270CB2643E7BAC0D8D79A5E88C98770D72CC35D17D14B7DC9E988305707E110DE526755377093431EF83C7D5F937CCA677BBAEF53BCFC82B049D879DD0B32644B250439BC3C7D587FC96D593A5B238F17CA4C9210F6F4B04F9343DD17229310F24896AAEF9658D4BA6255A4A08C7EA4AD6C8ECBE4E748AE094FA7F4647D62B11E0BF0C16991371F51DBC5C6EB6BAAC7085C01C845EC1A008C51FF3A1F18F7804B5F0150613AAE4E4460CFBFC02179BADE6FBCF2A374FCAEC47C65EB8D0A51E6D15057A5D8D221CB7C7A0BC0EBDB450E251A8E5F6DE476A751B0D883C5EE538D64F1F338F55103B8A80D454665D3D6E98148EFA9844EAAF3C009C9D3A9688872E0E8BB5ED8BD61E528AB42B0C823CD03232C81B6C6F0512E0DB633631DC9417F8111824E16784185CD59857D28CDBDF485B1E6A6BA11AA4C047250692600B500E2F3C913027229A2ADC9ABC2744383AA53E4D011BFC6852CF124161D13AA64914398122C8F1F1364A393C03874257FC3D651F64D866A68C1543866530131121CCC035F274E3EC749BCDEAEBBF3B4D2C7C94C026EF45D832B332946C2A7781DCB079F3A22214EB0784280062A61BC2F16CD296A69C00F64125659050054D3F6613C5EB04D9415F039089E6E8FD6E854683CF1F460D89AF182613BA161CB591955091E2C5C097184A96B443259691280CA50459239D96F48D44766EECF2E6CAC2DB08BA5250657DD022F48B44390681E44D80899451752C17D0EEEB3192FB8CFE6B115DCE7E03E07F7F958DC67DF0FC1354F1D61EF3EF09C60BE9AF182F93A81F9FA314EA2641147ABCB242F136C47DE6586C13998B57630AA4EC072CB134595C6BEAB31046806AB538D2B099AB2EA54BB36F882AF1E84DDBC85DD35CBE274E943CE354863449C0AC1280D9A8C4AC136B0E93B45FDDD33D257076E3E95580E98F5167658578CEF80FE2141E60AE45276CDA68BD2BD2C6B556CA588A8C40AB2D6022FC8DA39CBDA9FD96A336A176E03E020595519554DDBA49707FC40B5EFA4260F3402793A150D1A7A3CFDD0238C213668C2985F6CB09D1930422830820AB3C00B2A6CD62A2CDD66AB97DB683566714F0362A3CB74B9951374C804B49AC822751EFB5FD06B15C91EE37615DD8B100D851E9C9DF34BB55F5871BA9642D11D8DB08B2B5EADCEE1A204470E62D18C17C4E2146231DF54D7DA24ACBAA2A159C2B8604569D68C9192D69836429300A694A14A0C2052B5290966555E1D1E2E3F0529606010E692542928E1F0142E25201356E2B9A0C217E9641E6521AEBEF853765B387290A766BC204FA791A7CDFC1E273F1B0C3771A9CABB2B598583B923215B62393A150DD98A2630A8785012F3F45D87746E37AC8A6783DB3907B20396F2611E3C052500F558DD94DC58E6200625F2F617D6FACC96F162588995251BE052B73256F318DE042EF342186EAE21B4B1775CFB082CFE9CE69BB888561F19BB88A4C92FF39C50BFC48F4F8512B7E5922CB87CBB2AA2EAE92DA4CA08DB151BA9389AC01EBFBE55B4CC28820E543AD28F381469AE5E47B5B0F8CC8A27B88E0C9884984AFD7828D840D753895F8BC3492CB2AD815C22C133F6B1CD75BE776885107DF09DE6EA3B5D97E3B92C6F9CF3D482B8794FCACC1AF7A9CD83F84F1C8722CA51B83158C8ED6E3C838C87785122878C08FD2881B16B47AA9A6C570F6771563C81B933300806F0C8A78C7EDA46D9328E90A50D9143476C8D701CB46706F7C39FB17E7C2E4C309B82D964375A83D93485D97493A6EB8FD1A27980688CE9A403B2B39FF4081A238ACF885852329B100FD400BBA376B990532202878EA80CB7A20982680DA23588D6DD88561F3B232CF0E882D665470492DF20769D76425814E3A50C0C947ABC77AEF23148B520D5FC4BB5F172CC5D709125954234ED434E5439A0D53750694830A033506948700D79A012E5B5BCB8D51329ABF03E4E1FCF5726D7E306AE3B71E460FF5AE0054D31734D316C1D1AA32D9428762A43935DA337FA5C88F210780E7BA264C8B17850A148AC39EDDBA2CBAB3D8DDFCBE4F9F4919D26D1EA258FF3EA80CA0DDBA4A3DE7F54417EAD9F7FA68F6E229EB24B7430F260352626ACDE65E972BB282EA567E93832190B7B898A6390F1A085253008E2BBBF834AFE5C91E38288DDFB2AF208AAB5544B8F69F622D792A7D3D1600D450E41406DEF555594584E98882895994EB8279ACA9E38D7F6445BDD1372DFA739F6683B4726D492D50FB722702287B0F29916D1EA7A5B3DC89EB37FCABB94219788DC560B07E69984362885A3B494DD926818271083B4825D65780B31486BD755867710E31D15E33DC4781F9C141BBCE0A4ECC4C8F36ADE79B1E9C61872B2DAC15310D619B3740D4F6F0F548AD085381D2D8803335E1007D38883B3285B9476D33831D082B84D7F6566CDB46FF320CE1AC73986D069775B6E06BE55E4908E014CF1A0B69747A6FD5FC3F7294EC0D9B68E46F7DCE55DC603F9783CF7DBED66B38AB1DBBC448E3DE259542C9EE44EE889141CA4523D918293B35F921874274FA7CCD0E4B9FCF931AA4F124B5354601176CE7EDFC4D90B9C053CDD1E0DF87844BFEEACA4250BE883F274C2F82AD285B4D6D592EC31AE564B85F32E72F6130B28EBA00E0700E63E630CD568BF7AF8CCA27C0B150C603AE26A509D31A1B443D894207D2D8EE4187D4B9C97B9967F6345EFD0B0155B94C674675BE45FD97ACCABB97605B89A790EC05A13D088879A8756B9F665EE75B994CB51680282B1B040EC840575BA549E16320373F54D3A739930BF46AB2DBB8992C7D10E0F8EEA636AE8D0ACE7C300629C046252C2AE8E2A4B150A9176750C6422D657F90E8A8E48C5819B7B06F2218C4DDF525C44F63B4647CA6D11883056E992FA58C66B90EDDDD86857FEE291C2BC5B40749B18EADC9A49D02FDCC201CFB308166CF2CC2DAC435491B9CF15ED2E1F1C642267D7DB272FF32F69F2E1FBE2A99A7BF58612C91B00ECB069D1022F2C00209C3909D141328C93A2DCAB734E7254977FD7526F9ABD46434E28FB64DEEEA55F90504142CD53420D7BBCC65A7ADC6E313721A505D048297EAF1E1453129764F579B72477B03B108A3FC00CF22FC8BF20FF10F977E24B000220B2044410EC44E0895E069E9085E044E275BAADC77C5EAD343C09E23088C3200E85A85FFD70FB97B460176CA4CF2A403986FFF4103ACB8DCF89996F329F3294AB6CE0CD879E4A11270B166F0A599EB4447B9CD3357CD3A7A39177A2A0DB50F6B7688BEC56234EC36AF382DC5B1D8D1259CD9F6278613047266C57064F90501F1EF977227D504D20D4A0123EF2B7F4C4790AA49FD998B79565A8B1020985B01248654EAD406AF941200581A4EDF58314487B0CC547D56D1815EEC8507C8FE3188AD7E4D785E2FB6C58285E6052C6725F1769440FF429FD9AFD8D86E65513C66A9D172DEAFD69A3860502E8363EAC80340305C98F8C18452AC22EEA1640C6E6E9AF5DF150ADACD7A5C0C62B9D8B385F5C03DFBA23D270C0EBAA3D717756F979F6295EC7F223311D91B259E909011AA884F9B4583486A934A5063209EB5ADE06DED1F663F65CE6B72FC94256570D6D4ECAEAA7F8A1F835DD2E9E587696A6DFCE471F294400DD94951590465921F91165A548458A627318755C545F4C9F84A034BAEF17B5464FA521C1B8F540A5215D67EC21FE0EB13A3A21DA3CB44FBD55548A3603AE137229BA17E56003F7D92992D89751562A2E25D64B993B4EA593EC328F80DA54099AD0028372802BCA8A72D2C9EA95A71384E536CBCA96BA2D3F2B5A810081CCA41C96AAF27C62C9A3FC2A89C821A8ACB2379197C939F23ED657AA438BCBAB4436045B6258A731E385759AC94D827AF878B3076AB4D1C68002659FFA59CE0D75359EC2BD04A8C3F11461FD39C8B520D7C01CFF1CE5051BF37C3906375AB2A960EC445B935B2FDB8634AE0ECEA1BB52F3BD31A6FD26D994E6C80E588DCDAC40EC98645CCCEF9358FB34F80FDB99F4EBA6B55541FC1F91B31F77AAAD8366943A8F51DC3105CCFDB9E35D558AA8D8E6782D5B1621EE9DAA6492C8218CC674B55461CA3C1AAA22DA2AB16898EDB20E983A228B8689DD38C4D36968FFC6EAF66F7AADA02937502946FF92B13553F630C6A7A32B7A1A61D3B1153D8EB0E9D858CFCB3C3A2A180102838E074782C8A1386FED257CD7599C948E8BECC4C9DCE0165AE005B7F070DCC2EE5EEED16FE0E96047BB8926383BF74A44D1FB5930AD9BC9AC2DD2537978CD7F66D1D2E41CC3B4C7E0564E736DE8DC2EFADC4D28E4CB767DCFB24ABF00F7476291DD006C7791C4DA9FAB7299E3429DA7D3C710E6F9C8BC601898F18261B033C3A0510DDE0D8306D69B61A0829B97CAB42EF2E85574B82B7C9C09D1DD6F0DA2341C9D12DF2CFF2E87791A2F18AC23E492F6826EAA9B69912F17384E7308332010F6BC62DDA55ACE73B4E63C83B6DBB6CA8341CA3C3AAAAA1930BE3DFA555145E19FA2ACBADB54C01539842870F4BDF948E951279EEE8076A24023BDF1D4E77AAB4023BDF6D4E77AA74023BDFBD4E77AAF4023BD00D5E75280911C0F860E698E4C323F977181EE06E718543C6CEBA3C821203EB1FF6C1956439E41C5436B28709C6423B85D5FE6ED7A0BCE0D2B2D69962C80572D30DCF4A10C29F3E8BA10D8141C9D52C797CA70F8CA32F0F6B9C4226362C3466211BE9AADE26796559B8173F9867099E78AFAE5F21C342A9680104E604FF162053A9F233B8CCEDED85398AADA8423CA3396E3B46BC35BA82504474270E44083235759E9934FB474C2617B0B93683169B1120ECA2E602265181535D114EEB364CD8750424552866388DF842596B0C4327E89A59B20F212CB400F5644B022347D7E4456C444EB2C1CB65F2BC2CF8ACBEE7429ADF0A0C5C39A891EEDC3F74DFD1E1BFAF225C721217A7C49F350E243613D27ACE784F59CB09E13D673CC78613DC76D3D2744AC83AFF9CA7DCDAE82ED1DDD3E03D6107AB4A7690369E7684224BD9F89A77712ABE6A23D96ABFE0A1BEF1A4F1F5CDC10A83EC440B5FF23C1C18008064430202415318901E129546D03394F554A2AFA55A8F07056609C89D18D0CECB67B99F78AE2B6AF28FE716C3B104176653BB9CDC160400603321890904F3720FF1117E5F04EAA7B54C6998B2D5089E3661BEAF26B0CC1211B62F5894CFB8E1CF2C15B53659E0B6AF55B85DAF0089185CDE97299B15C92311C996462AEAFD34C5E11E9A9BB56B3E18A9E2038E72A383FA52FD1AA04F6F5A012C47393A336381A790AB32372154F4418E3DBBC48D7C8AB261C9D8E066D379143915E737A9EE93A8D934212EF1D8DE864A2DEE51CA2FFFE9CE9F9BD36D87D097C004AE4D0360B5DCFE821A86634DEC08B0938BA3DDAE867A5A26C091EFF6869341444A2F454CA8C69A42500131814ABE8A76DBC3C5F45E5A859CAA691C0A260529E8632496268358B1CC28AD6E5B9B48E551148810824F4808F84FDD912D551E5DFE29CDD462B967F65EB91CF5B0038374BC20246634880DC881D81A63954357DC1F24556961CC343D41C836414CBEA422148F73770DB4DC5BD541C336A0D587663D608A219B1525E64BC2229ECFBF32C4ABEC9981D8DBCC3BBAA0294B280E9840BA3138039A50BBFC7D19CE6E769F2103F6EB368BC4327A3390E68238A6E444B99B1218D24D9A333F0253D0126724D23A2BC455048BBBEEB1CEF1014D26EEF3AC77B0485B4CBBB79DA5E8E0635B499CD9FEAC84A9C442B1F3B18CD70D653C888A39F4452767C1A2189F63591BAAA5C4AEE014F2788F06BE973AF4953E0ECCBE9E70FD214686904AF3E2FBD6EE96B3A1A41C9FD261FB4FA8DD4AE7FCF92D575243F093350433CDA8C17E2D11309DFAC74A63EB167B6FA14E7C548C92B60394A5D03864EE20A5931690B12846D54C6B6D4B623D109C9D2E576017A862353B0BA3AD47FC9881233AC1D5AE005597D30B2DA979C1E2BA31DE5B35799D2E543E21A12CF0515896A48BCB0BB2148A820A1BA595CABF2D33C67EBFB151B2BA6043057596500D10A2C212F2AB5408A7D994375264C06720C329EEAD37D7C77975959673181337EB58AAFC56F128CA87F5E206FB3AA538DFA920AC7F8354D22E772C0BE798C4FDB5A71F5F09945F916FA28801914A1055E508487A1083F7C2F58B264CBF68B623F1A51427D19A519CD60660D2963A8352596D27E24C8B9A1EAC053B89700CD7F3C057134833D3D0395B2F69A31F8747543A348D1D3D5AA8B3CC9BBC1251E05F586FD671B6770A7D1400F92DE022F48FA8394F42FB5AD3789B46FAC489F225F814897FB3590BDF0EF93EFC767DABDFE8238962DE6D05241660699792032D3BFACF4272347CBC60967F8CEE5575DC9AAC945788E4CB55E15888019E49E055E907B8721F73EC5C9372FE2AE021A25E57000B3C0A9F2A9854CC7DD6B28BCAA8432B43C309D706154003083C0B2C00B02EB30045673A9E059BC5A95DC3E1E541DC1F121C550740C9C24DA08A86679A704530B416D16C2F10F11009C04816C17035279B324E0EF6F4912BD56C3E13E8D36CB090A443A32D0DF4654E5942EB497798EA8271A54F7BABED5A0928E3BB45DA9D487545D58FD7F95B447FC444489453960B789B202BD164EE010B45729F91FD30C6E06E5E8F668B7DB7B15A0C472C23CD1809EB8CA0BD54137914B429EE4461EBF4FC34CB5907D1D2DBEDDC6FF05A7E73A2ADD8E5E837BF5440E6D7771A9603EB3E209BC5020B26898C8AE5D8E6C8F55BFDE8480F1747BB4D367565A160C6EB2101884F1C76AF58CD44FE4D823FEF694AE581EAD188229F308D66E9CC4EBED1AC11439F6881FE3EFA589DCBE3E23424A2C422DA3EF555D7054C024E3625F2F701CBFFE5A71D5A53291738BA84AD224A35810F59C6AF6FD4AF603CF212382ED463C9D8C768DBCA522B1488BE38B227E06BE7947A5209D556FC1CB402D91825312D629BC2E406090EAB54D962BF0851D9582F43163EC32CFE59D7002831417C9A21730963932C1066CB2A8E607C2A6D4B379C84DAE6647A5209D976E75FC98ACC1BE0E8945C32CA77C740FBB9863907AE5FC16F4484522F4C6029C856D49947A7C8DBECBF5A849148CDB5222442B19A6A35290BEA4C987EF8BA7287964585B03F63EE2839D45A9B5639589285A297B8C1359053534074B0783034CA26EFEE91AD1C53F914E2877EF877E62CB47E861402EC16AACEEB5C1612556880D5B8CC6101B9E3E36EC6539AB81F210F5750FF186106808818610A81931844043083484404308D462FC8510680881861068088186106808815A2085106808818610A864CD8410A88710E855513D2AA8ADB22209B10C4DE5313E45BFFBB8402884824328D86328B80B248C080177100EA15F75D6DD0444BA5C302E2B72E8885FE34256A2128B8E09A39422C7A196E02A039143098994A6D8A2F2CCF234811545D80491571D7A93A653472384CD9BCDD6ED0B7952B41B305D71E5A8BCCC74C57DABC32585BCDBAC5F4BEB6BF39426F27A04E092913FA7F7B13CF6251619F3A36C2BF3747BB40FEB2896ACE5964451E39BB2CD2B37AB72A1E150C7F8CEE897E7F0251B2401C5847E6148A539326561625556217BC1A714E43A23CBCF0300AE33B2FC6400E0D29115130B61D3B1B1A925F3E8A86072090C87C50A18BD97580ECB7EBE1FDDC63C67C024CCAB342F22EC16538E6E8FF635FA7E7921CDA78E4642F99242949A46ACCB095217D2BCABCB8528C4673EEA72DF227521CDD4BA5C88427C2CA42EF71D5217D2632175B91085F8E4485DEE7BA42EA42747EA72210AF1E19232C70D7B8CF3A2795B469EB708DB1D1BE8313401493B567E0AB65828B1486EF0322E3EC56BF9224B8141C07B62FFD9320C8F6750F1B0550791436EC5EAE111189C1358D456446B2970761D8E6997A5CFB6799C94160374A8D004649DBA6C617254AD725CE2C2F3799C2D64834260D0B57F1D8252B9E73DD31E170FC53987F734913D17CC4ACA8287477B222548FECB669546E0C2BD8E4A5A105BA58B6FF0EEBE9E4C5A60D8E69BFACE19B0C63030F6B11410C2A0210C3A4118B41E381E62A135CE8880A822FFAE65AF90551D24E5D88ED8D09243D8BBD6ED415A0569354B69F5E931F7B06EC3A138482A6D6EA52D376402069DC80A6B38D6B50C6B380A6658C3096B38610D478F15D670C21A4E58C369275058C331D725ACE184359CB08613D670C21A4E58C3096B38610D2744454354743651D16B4FB79AC8506EF151038426487AADBBD504E39395DDEC6E3539A4BB48AEC3AD21BC0C3CF25B43A658B4083771484B0BE1260ED3D80E3771849B38AEC34D1C5AC470130709E73ADCC4116EE22061869B389441166F3771F80AAFD4A53F0345C491A981D65C96852D916E9F861B3CC20D1E8777834708588680A5C780A520DF46442B051C8750A521FFAE63184256185B44D88ED8307E87B077BD1819965782B49AA5B4E2629DEDA7C4638416847B19B70B5D8DB2CBC0AEFFDDE8ED768B126AC516E5E7FF08C59622C988322E58E521463036A04F39A244E526417DCA1125F6BB388D250A2947948805D31569DC4B39318F8F93B1E3E3C47A7C9C781A1F27D6E3E3C4D3F838B11E1F279EC6C789C5F838218F8FCBA4A8176CD8F2BA3EB981C80F45921165E0DBC935C9C6977562571669A15705F2D6AE2CD25E5400A21C7FFA94EE25229243916444197623E3C4C7C838B11B19273E46C689DDC838F13132D492499F92B27920AA971491051089658FF92F1665570FDD1ECAD2EF5857321AC6A775E9085B2AD2AB870FEBCD2A7D614C0A5B4A2C1AE6E768F154550C420E1C8206E89709AE1E7EFBF9AB24FA652665C42CD235FB1A7DFF18AF90412231A92EEED94B1BA22BC7C1B09904737C5529E9259E2EEAF546537148328AEBFD6B54F05BCFCFD30D588B4193D897612C6124FE657E1DE5F926CD8AEBA7B44873B9FA329762ADA871DD512FF3F38B8BF3CA997C8817883D89F10981053EAF1C5B9078A485CED23D5F6A6B8DA5206CAA1373CBBBEB009752F7CA3C4ED8825DA48B6D635AC2418EA7A16DBBD39731B684CBFC53BCA814C3D7F4725D0D3DF913009BB0E14B873C02B7AC5474AF1D35904FA8359F571A31328F34D66FCEB121D29309A31A4372C0B9CC2F2AF918DF6F4B87E8EAF7A48AA9C00AE269083690B18CB1255CE6FF3CD70E07C0B6C7E6B34A8341629116943FDD5EDE5ED5D99595C6D3102268727E398E86F04378DD022F84D7E71C5EF7195BF71058778FAACFFD86FE104F0FF1744A29219E1EE2E9219E1EE2E9F412433C3DC4D3433C5D8F19E2E9219E1EE2E9219E1EE2E9BA52423C3DC4D3433CDDFC1D219E1EE2E9219E1EE2E9B555FE7CDD5C54511FB93FAF9F2EBF604514AF2EA22AE63322BE6EC47608B83B60AABD1503943CB9AC3250BC2504EE67162D5946285FCE40D0DC692325C1A67E8E4EB0D3DBEB4EE4D39503998CE5EDF2A56BCF171175D6A3ECE2F2743A1A944222C71EF16AB554DCF82272083108F6BB0251E490EAA8BEAB0530493555E30226419B6DB3ACEC8A521E2DA4C36B22C71E71AA8381E5472A26A3C87141845352E6B9A0C28929F3EC513F3C3CB045F1314BD7703EC93C9788992A5846B23B6EA443ED35611FD6642761C0ED101C9DE2C1C2D870472349EB05CBE5504F47A4D862954E84D7D4F2747A4BDD1651B1CDF1D6EA78C19A37E3056B7EB7D6FC3476BC5F0BDE8BED4EB0DABDD9EB044B3DD8E8C1460F36FA6BB7D1EB5BE8E4A1D91383B51BAC5DAAB5EBEB82695FD7264E632F73EA14BB470661075BDC8C176CF15DD9E27CB4D6B745CE63FBB2CBF598738D6C2BA6B0D3DCF56B815766D879D9FAD0981039FBD26973B79AA7B177FAADDBAAC6441338E07B7AD96F1ADD5ABDC0F3097D97E713F15D9EAFE9E3972B11A625056D6CC60BDA78B7DA781A3DEC57037BD1BD9345A982BE0DFAF698F5AD3FCD18569182AE3C345DF9294EBEF9D39115DA78DD88A358EAC42AB341177649820E9C7A1DA99DF8DDA7A1526160122385487430ECDAB5C20B12FA502474FD25A3EEC100682E3761D880D8C8E786A113CF438AFD48ACF064A41294F864A4DF3B507C3E72E8FF19C1FAF49CB43AD790285FB82A89F2E73534124ABA8528358D82B22D0D871719A62552D6ECA5936E3581E0A1AEEFD92ACE9FE0E15C91638FF83106CF2792F2FFCCE4E7FA1A0AC1FE63C963212DC17634829E2C27257C6C6BA052F66BC8FB291A0A41FE4645596C02AF34E9C96459FEB13447AA87583081DEF30833FE29DD4833BDA61010C083B2D4C7646F578CC94F1F763442F49D7D870DD3136768C334AFBF7D493D6E5414214799332628B3512322A84D1B988E3C29F4457928674247E61539D0DEB60E79336AA7DAE8D6BCC989048F39FA88C0B1750079642079A2407537136513B3A3EE3BB0EC6B9B620852BCEA204537A0BDAA762F4A7D8C3A372BF2512ADCA0BC83DA36D76CCE716F5FA2F53014B73F45D7E5C1149DCCDBB7FA0C6AEF75ABBDEAB4C9E7282F3CED31E2F0C6293F1D8E85FE1BB26B54A09828E893A9F549DDE0C8F5DF03998885E01C4F34FE739CC4EBED1A4114391457F12A5BB2EC137B96A3BF22878CF8CF6D544F621474609271AF915B5625565829B7C00BDAF840B471BBA8E86D3B130F384E1F6B812C1432975FA391A55441254FAE92BD2E6FFBDD78BCB32DB8AA1DCE68827D6E75F669B07C8CBFB3E54FD2B1E79EB86FB73428EBA0AC67AEAC2B602F4ABABEE6698C72C601CC4AB9CAA756C61D97AC98AA8CCA3B5706A6136E4550E2364C8A0280C7F3E967F2AFA3C537F4122F8111449F055E107D8721FAAA98FD799A3CB32C2FED612F4250841C250E4D5066C12822A845244CB7AFEDBEF9228B37F07082C0D8FF824DD356C5C7A87AAF4BB661055608E24DAF1EFCECF0094A262819EF4A669D5622ABDD6C79BA5AA5BF77C197D1CA86006DAD7548987AF5A381C2F590210341B07070BAA53339C53104E9FACF52C1A209829034E3052139B190F4B478CF838D94836ECBF6AF53F04CB23AD034141A82E1590E9868F8856751ECD8D36D919E6E362BF03E15C770A82316D5024CCA4683284342F81C99B0612D41A4564FA4B4DDE7345946A0E13A2A05E9EB96E508544FA660FDC696098AC63148757B2A5D4CB476038382F7318B11B08E4A41BAAD0E6F2158039D84B6C57AB3A3D2C7C5D718BC562C701CC6070629B09CC609862A319DC60B5A5B91491F371828CF71193F18A6C8A38F231473EBD2FBCD98A9451D04054C2A6E29F854A83DCB1EB31D8C8ACA422E1919ADAECCB347ED87B9A2C618DF011DAD35E4125AA39B46AA9646F80EE8786B032E61BDBB9EA98A4A03261517ADAEC422D81CAD0450D41661D3B1D11A0326652789465600261517AFEDD651565C472F9517F399154FE912D88A329322814BC273BC94DD489E4EB29057AB2190241BC9028F880A172B393205EBD768B56537D5A58C321CCF21C7CBEBCC68BCBCE51010A3EF2A4481430817C479FD943A0229B1E898D78A670D303E61BCA77152C8F7F7B7B45D2F97975FB259452F9F599E635F29F0087E74943FC52C435165DE3ED65A2EF39BE8E16105903A2A05E93259945A90FD53DE6F2D724270D28C1782933B5CC1F1B25FCA1276C4CA8D028FBA6A53C3D8AED8F489C36A8D0D1A16E1A307F682D80B626F5AB177B67DF9DFEEDA39AF824F07EC26FAF48804E1C70359883F39791080366865ABA9DA586291308145D9D1825035E305A1BA3BA13A5C62EA5DACAAA1DD05AB0E93285AD517BB5A6508E2D506AD6C37753B036610B141C41E9F88BD6EF6A17B97AF0A5C77E1AA04244AD66B7C3FBE397590A9366865A3295A58E49010B5E714303E09FD0608859E18647E90F9C727F3B95BF2BDCB7D0DB6BBECD78212E5BFE64902BB1C410FD8A0950DA76969C80D923648DAA396B427538A5A00EE45D622A8EEC216BCD5629925885B1B3451A082B646D841E006817B5C02B71BDE17B1DFED071A5C3731AB052448580EC742B84AA9835CB5AA99C28075335D811825CA503FFBFBA6DD83D8E53E5D57FFE3C81D2F680F335ED01EBBD11EC3628F6FFDA14576D3200648820E11902CB408481FF4880D9AFF873A832E09BA24E812016F36BAE42756FCCBD30B82B6B86E7A440B48D0221C8E850E9152070D628356369A626155E49010B50BAB189F840E17567B220907A8BA8E466B3D44E17164129649ED2992389581293F841DF49F192FE8BFDDE8BF561CF976A4D4B06EDA4F8747507E038C85EE131307D56783A6D07B4E4A6FAA2B4FA1AEA32ABAE0D0058516149A80371B85C62F9EFAD66A066C37D5660425E83709CB42C9213982A6B341D3ADE1BB2FE007CD12344BD02C02DE1C35CB848A650ABDE251AD90B54A502A6E4A45A353824A092A25A8942351295FD3225AF9562628A8B31A51A0D114480D62A73AFAA44169D8A0BD5E017D9997CD7F1F276C29F53547A7A0FD1AADE2E5C734FBE957198FE7040562C60B0A646205E2F1EAB6518F5DEA206C84B5FAC14BD7D70184AC9A17171C9FBD1C3257240D76C3262C4B78B9CB333C551984D76C85D7365B3C4539901434B1A500B19458CADC3A61D566C2E414C722881105A01B9A4FCBB4CD04C5A6C020E341512930F6653977B9E0E78A1C3A22FC6091436941DFCF11754FC083EDCD1C9D8E263F5BC9D3294AB0945A2C598057300506BD7650F08A1C4A886EB359C5D0BFE4E974343802450E1D118E4091433204F21CDDDAC6338EDBD3FCC250408E4C98D1DBAC1AC9506073743A1ADCD522725C0E40C05129F35C50E1C8947984AF6F43E288C2123874444465091CA7A03E36CDEF5D6BCA65C526FBBD87FA9E682B7C32A2C627DA2A9F50EB7CED71DF599B09751D0706190F751707863DDE5984A88B9E48C129164FB29EED89F6381FBE6FE2EC0579458FA3EF6EB96AAA5D834256D897089B3042A2C5B7DBF8BFF2F0E8A98419E6FDB9F4DF9ED215BB8D560CC1947934ABD6D713F1A7CFACF4F8589557441318749BF1B6888A6D8E5B8D1D8F1298F998317699E7F20335028314E889F34D355B41A8A7A753D07ED97C4A231047EFA82100658117025008678E01282F07FE04AC71D1281586454CAAC9AA894C0D09E8F1291C7C0C3257B19F59B4C4976941826358A57D5D719C4F710242381D6D3F56FD657E8629CB33AAA6F465354F65A79E9533A7CA2E43F2744AAB3556BCDC6C1D755F5EC255568A06E02A0CD4DDF91B95F106307A22358E030FD0F2748AB4494AE3B7F8182D4AAD238B1B81451959AB2859C08FE5E9FBF100FC7B3DA7CF8F983FF148F52542ECB48EEBD43BBA3A0410F591B8F6C85FA3EF4D757E143179BA03DA8902EDC409EDAD02EDAD13DA3B05DA3B27B4F70AB4F7FB8A8D4FE37B97C4A4CB2D8D3E81B3CF75A5D6A8C1768148ACE0419BF182073DAD07DDF8667E3CE8066B9C07ADC2D8971FAA070F1EAE1DE2DFD3FBF355948313473CFD38FCE5B9EF5398CA8EF56B695E154F2C3B7F8AB2C74A3689AEA1C89A8BC51D2CD83958B07D2E05D8BEAC615FB1263F5B8BABF85D37DA9B234120BC27B1292BA02F9590FBCAB2355096228B8C594ECC385DA2981DEB78F6EEF4DBE47AB5A1507ADA8423CA3396E388EF693F60AFFD92E73486A8087BDFBEABBF95D91B566C33F4C085C809FEA5192FF897D3FA977524DFE7322D0738CED3D40259B89B5C7E8DCF29A5A23B9E9A62469721D7D3E8414BA982B37B288B9D9FD83303E3A727127190531603F938DC787FCB92F35C56F4BB04D8E6423F55E61DCBC2A2BFAD9E551EE82B35B463DB8630C57276589A0D4BB3C71ED87A4DC796FC6C393B9405685FA1C1B0EC1CC202071616F0B9F6CC017A080B8C58859ED891B6282638EB6165FA0057A63F7CDFB0052AC3450E09D1E34EE576A9495D4D34813D7E7D33592990B0652E99470920957E551E3F2655D54A9F2D964C218CBF3FD78B5BDC572FFB3BADFAFB75B7C25E82E377B97CEE25385D96B3B7D47622D440258C3C5699F2008A23EFC7A9BC61FFD9B2BC147B6752FC4F6050BE73153FB3EC45653F60FCB003E298C2005D0FB74B7468EF77BCE3DDE7E067C7CFDC77347C8AF2E2745B3CA559FC5F2842209752C721A75C4F9EE35A57680662FC107231E38590CB3421977F6E4B0DC6DDCB3D2ADC2281B9855A8C209A308B941709B12029EC3BD8003F0A9BAF9B324084A408819BA97759F80DDBF8DB3BF0DA56E9A7581D3E8C7571FFFB13C2AA7858153FF6108DCF00C69C579D8353109C82899C021F6BB012D848A7C061ED7562B3DA001F4CF6B0D66A8A322AA3816EF8E7DBBC48D77028F27492635ADDFD9997A65B0E470FE4EE73CDB98FFC424481438EAD7F66C553BA5444EC07E6FE0DF0C94E5A7B5E710D6BA3C76B78CFF59CF5E1AE1A1EEA6AD77C57A77CAFC405272C38617E9DB01BB649B3E22C4ECEA36C39CE0513A0DC1C300384C678147222E623E007F768770E8D097524BA3FC3BECBC7F245166F902D4E58020775A054818E1B3D2E2FE07958C074C2AD084ADC86B93F75781D957F2B4121773F2B7BD7B37F02668E4FB7CCFBE4ADAF13D5970940694904F7790B4F6477B47DADF3FA7A7FD6D7E6AE603807C3D9B7E1DC5D7334D66AEE705C4D66757EADBDACBABF093029B3BEAF8B34F3073A056D550DF88F29DCC42CB1281285FAA0D0FE46581DF11E35B65004BB61A5C86A0ADFAB02F7C49D281894034E78CC383C66BC7FEFF7B53C665CEBE9A83E01F435963B1930E90B8D50AF889C7D2D5D76B910D12070E88888701038945D68AFEDA169CD6AB2F352329711F97499E9848B3480CCDCFFF2EF21EDBFF4B9B427EFD654B5832E9D7B69D867A8D25064CDDC8FE075CF79C385549EE38278384F9283DEE1E874B40379E01C2AAB7BB7EF3EE447D3358D70E2DC0AE129F659C6E1C353ECEAFCE129F6F0147B8230F6BDC5C7F753ECD5C50C7112ADE409CCD349F1CE237FD8BD9AA0725B75344A7DCECA5979F5F00086AEC8B147FC772255AA2684152B335E58B19A703DC1C7017C0E68C4E282C3C17B2E9F6AA1C1E550BC06D619B3AB8FF23490C40DDBD1A60FC8CFEF1DF9761F991C2D688964D7E1E376256DDB1618FB37B6E77F91FB3C9DA75B96C5D0241CA884CD42E1AD7B2D5A6DAF2FE1A6AC81BCAF2D55F3BF3AC3BF937AFAFC88B97F8F54D7EFF2E2523AABD5502808710E206A120D63819C1BE3E9B46F3A8FF22764554F6291304F0014E9FC59F52D00A22639B41302B4209F88ABBE40DD4E27AEEDF41640914ED655DF02206A92433B21400BF259BFEA0BD4EDF4D6B59DDE0128D299C1EA5B00444D7268270468413EC5587D81BA9DDEB9B6D37B00453A0D597D0B80A8490EED84002DC8E733AB2F50B7D37BA776F2BDA07D99DF5EC0DBA81B1A41EF5D00CBEC82F892E805703C2F883EECC5650E10885F81DF50E47235D1459949D1F7128B60FFC4AB15B65F95A7D37C7E0C8DA7132308EB08DF69D2D2298BAA68CB39B5DA6D116505DC8EC591093E4DB284483D71D721DBDBA7F801C0F4448A0CB861257D254B818E4AD9A257E580FBF33A2A15E974F98C41D564C28282C773F29779994D6EA89A44AA8F6ADF8CC422C9F1225D7C0382BC211246E666597AE6F2DDBF039534EFC022137D71E9DFF260FAB7DB1D2DFEB64E1EE216B070051F8A7634378178BDBDA35D1655DEDE81F0F7BDD90EFB7899B7CF2D7CFE968DC3D58661A9F560965A7D5C6BC8018D586A75B8CE70A2C54B0D6C5810B5407C3DD717FA3F9FE4F7D4CF14E74B0EEEBABE4C7D5F5F162EECA3A11DBD993ED70BFBFCDC55B183E7BCBC5F0F3AF7B33FE06640EB2B04473E9C75200F734D758F83CF00B4DFB0BDFF8096DF85004FA1ED1906EDC78622FDEE44AFDD3E2C0A2030A801775D78014F11822066E4100479C54190D63AF1100569914684419408A638489B511508E1D8048993FE0EAC808644B20B31D5C591095BED10739A6E4BB71B11D1DD89B4CD0860EADC52E74C29B159BC2980186F887B8B0979B4ADFC581B7E2DB4D29445AC5B628DA2E4DBE5521E440D8DD0D24FD5B3CF889AE0E8F46D0260515E60EC63B380AF43041FEA7B4BAABF656371A05397D2C13BBA1C79D78BE9D3DCFAE3CF13196B61070B2E58705358707520DB870157038DB1DF140046F3CDFB9B42877611945F13E627962CE541DCD1F6170CE39A4715CF91D8BB0E119F2E9719CBE5632403958C74822291961FDA3C6F5124D2D2C387357834A62511C23A6CC5364F6922EF0B1CC814117E1FAF80F06E6804B36F0DD6A25A1229F4E5E9B283527BAFE33C2F67ECEDE2A91C7FC89A37E00703C266AC0403621A0362BD59B1CBC4CFAD033C96AB19A1C7D05A127C56D49890135074579557750581C8232D0F7595D2ECE49113848D3768A8CDE3A97F5F67CCFD6EDF99CFC9F0395F2235D5CD0853DC65E07B3B91DFDB1BC2C3E9C1AA0A56D518ABCACF06631E6B9C55E5B4CD7842FBA4C9ABDA6D2CF282D533BD8531F1FBE6C7B2394C3528D0049428447585CD57A9ED072A65C1A9790BB88DC74AEB4E228F3E3AFC6DF89E6ADBA44FCBA5DE0B0A0CE6814A5E7A07CBA61D757F91D939BFD01CACB3609D4D619D5D6D0B7F41AF1E6C8C7DA601311A687D5EA58526A4984DE0ABAC95C1B2145204233084BEC685BEFC5EF91702612110160261166326985AAFDBD4F21709EBC1469A5ACEB1B0C94C96100D3BE6685888EE1C7774A7CED30573704481BB9FB8918F38CF540FDD0663261833B3366616519240938166C3E01896B68B2AB3CE6669F260B6CAC021D8284DA6EB8C3DC4D23D93128B8C59FD40111B0645D39E2E8A520BCA9AB6A3926B869E6E1159535B157B1FF5D500F631F2311CD2E8C701CC33A0CAA79E051D37D8D5876657FBB75B1522D3495EFA7A32741A1BE92A8B1FAB270B55FD8BF1830566C60B16D844BA28FE2F1B1943AA9E7575533F684E9DDE2933600AA72513E451990339C4D65369488899D55377ED49FA3B7713644D90359E654D7535FDE9F2FF6EF3A236227CEC15C0201DA5911D944E3C610898BC52A523881D9BA23C94036BAB0ED4ABD2050760EA1D06D338131ECD7F71687C869A174B40E81DAFCF21D65B3390DD0C1D751F7B2C3E7C5FB03C07501C99D01B4F6956DD260BD00406E12B9F59F65B16171050E4EC6FDF0697AD6DB16D54CB7E25BA9CCCA9ACBE3D4DA5C1844EE575C3DD541C48B7FBBD4CF37F14D7EF63B6F37E7274BA7D4D79F16BB4DA225FDD92C95F8DC0899CE3D83714DCB8E0C61D881BE7651F1206E9C58D73D993B43B87C7AAA8E058CDC0199AEBCA4ABD0B46A167651E11B5D5AB4A6489BF8F1D423B3B9FA81A066882FDEDFB99DAD196B27F8A5E64B585A720EC448BB2AC1623D24EB481BCEB887A30F08281F7CA0CBCEDFD79F9998F69F672525D885C323BE59EFF16E760CD8E66EAA9C1316C4BA38F0AAA33FFF458982168CE41888C8800204002D9B4683E5757C3A78CC1D643138D64AE4EC8A22DE0BA2157143572C33DDCC5DCCBBCB4D6D8A290913A6A503766BCA06E265737536A9B29948D475D43563507A4697C6A8332AF0676B486D12A9811FA45AB5EF6A55D7CE984E0CC04ED3257EDF295AD37F591F7F25B1E62F01012499B18B0ECD487114423F9A4BC88004452EC674F4A9B09CA538141C683725460EC2B8CDDE5829F2B72E888F083450E61F6B24D941568685CE0B820C2EF96792EA8F0DB651E415E2B8C06378B416D2EB8DA0A6A43C1D54AD018603E7CF183B09474E10EF758C72146244E9F1FB1FD548FF4BD548FF0B1E39E688FE3E3C26CECCC3A4F27D99D795E3F97A2BC3247E012A459FB00B624C77A2A71374D5D0D643B4D4B0F96B6192F58DA1359DAEB4D6B8BD58B803EB6F7DB415ADADD96583AF31B85C0AC7065C263D8B3F135551BA7328F2090E26796C019C491832383F646250CA245D5E4F05D46C074C295772748ACDD6F1FE62A00470C601ECB365DEFDBE2BD3C7FECDFADF4EBAA4DEC0679752B369B15F24E324F27B4A2D7A75F6B3D064F8CF45492E12FBD06D8504808270081F4026099FE2D4020BDFC57A67F0710DE1111DE0384F744843F01843F1111FE0C10FE4C44F80B40F80B11E1AF00E1AFD411F5060EA937148CCAE407271F7287C7C9FFB3C54E50B454A243DA4688A12FDA31C2128D055E701CE7EF38DEB04D9A7939112E8139FB8A7A10BD93C8E7C5BD4339C531B8857E44A8FF2DF27EB7F057C7E164A48E668F32F6DD7BBFA662970B8B65F31C3A22F47245CEBECCD92E17B27E2370E888F08B454E086284D5B969DCE6435A8D0D6B93616DD27F58F07585EF7CBB88A5CFFC064666DE904233F5594019A527D2EA02633C6F48419EA6D813AC2ED460D11B182D7A430A1735C5BEC5EA420D3BBD8171A737A4C05353EC3BAC2ED400D61B18C17A430A6135C5BEC7EA420D85BD81B1B037A4605853EC9FB0BA50836A6F6054ED0D29ACD614FB67AC2ED4F0DC1B189F7B430AD035C5FE05AB0B35D0F70646FADE90427D4DB17FC5EAB2F390615DAC8CD21369754122E274B92BA3F4445A5DA0DCFD912E7765949E48AB0B94BB3FD2E5AE8CD21369758172F747BADC95517A22AD2E50EEFE4897BB324A4FA4D505CADD1FE9725746E989B4BA40B9FB235DEECA283D91561728777FA4CB5D19A527D2EA02E5EE8F74B92BA3F444DAD21D94BB2774B92BA3F4445A5DA0DC3DA1CB5D19A527D2EA82AC69D2E5AE8CD21369758172F7842E7765949E48AB0B94BB2774B92BA3F4445A5DA0DCFDFFD97BB7E6C671246DF8AF4CCCD5EECD3B5DAEAADD992F762F7C28776BC6078DEDA9DEE99B0D98822DAE29524D522E6B7EFD07F0209104780090295152464CF49401F1014882994F1E90383397BB4D944DA3D95C54B97B662E779B289B46B3B9A872F7CC5CEE3651368D667351E5EE99B9DC6DA26C1ACDE6A2CADD3373B9DB44D9349A253CA872F7B3B9DC6DA26C1A87E37CFB481B02336F31423853108C649CF8FD6705C1483289DF7F51108CE489F8FD5705C1480A50289E42F1C0A1F862567751CA41A2F10A9E65407E004E574C5EB95C1796D7FE68F8FBEE1F0472047DAD40FD2F8E21BB800A05EA7A0CDE0648B55BC898F424C9423CCD8CB4A271F7D1A3EC92B6B2CF4AA749DC0766E7DDB8A35B53E6BD29CBA26833E2A90A4B35B91EAEE23EF4990263AF778E55033C0B46B66EAA34DF6E007B54719B8EAAF798CB6D3A789778FEA1F07C8802DE2A9E3BCFB728DDDD4F905B7F442C7CD8CCA059F85FA3E7CB8025CA2EDA6A3B71FAEE9528BFCBB63558F60D47556A5A0F2EAE0D5464BB771C4B7CA022DBD32869856CF6ED938B8C997951696EE26DC4DBEC795BB6991F82B0E980CCA89A1E610049D3692D4DB79D3A6C5786B8A2604F4B43B0A524A34B2E87399794CB623DB45FBA1BDE575EA566BCD77BCC11E55F7AC4BC67D73A8FB41369A7516AA71BFECE5DA285D9F516A2A7E5BA567B58FE5C3186CB4603BB5A5EA229F7B96D36C452054DA599A40C49199232F29B784D8A6D66BE0BD5D9C2AC6D444ED7D5AD1FF9F62245FCD4BB0C04C76BD2BE8F54E934F8140E60032D093A1274C72DE8B65FAF9BA4DBE2D8C9BAAEEB772D990E69933B49289250C72DA1B69BFE5DD958A57C809D90EA04E890521D9528D45E236606CEF60EADC005C93F927F2724FFCEA004A002642C013508C344A0528846D36D240491C4EB2156B9217148E2F0B8C5E12DF3C394872CF4F85FA3E7F324F15FC36F8B6510ADB9FB6EA241F87692D306B743E6F5C36944E1B08B0C56A4F124A067D07253FA94C9DE1F53F624E53BC2EC61C2C91A2BBF94E69BA8B69BA3A9DCA6DE43DABE1F8FB4FDEEB4BDF35E824E5C38ED6EBAB7605FBA6CF8A0A43D69EF413F1A6055753FF0DFB96EAB6CBDC7C43EFE7DC51321E02F1A5B2E6B1D0EFB0A5AF3FFED9EE99873D88F6D0F07B117622FF8EC659A9731C07255D4E0E1B84C0FAC21A5A9A10D6436CA356E04A7730AC0E39393029F664D477C90C56991B6F196C708E417A5A055DB0DD608F3DE1EFD7F3517C8A6D50CC9BDA849AD7A461DACD165890958AE63FC854AC6EC04249A4A341593A64A4BD84F7CA9D4E13D6D0A3804451D003A989A2958BDFC4C7B852D39ED1D1E74ECF1124458CA84E3831B2B01FBF6B1E49E56EED67B8C10B505EBEC6AD51D9A0F4EAC922B9E78B1BF94EB585941B5BE7D938363F3C94D92DCFCE5B3662ED2B69DA8533F1E51272CEA94F2D867C17910147A0EC6B1A747B5254B43D13A59921E444B8FDA7F6AC28B860D08339A76DA1D04B0FDA7C7C0BE4ECB3D57D08EB647A8E9B6C656E7ACFD8131BECA7836CD666F7DBCB57FA12B8D9D9653F6786B1E9353979CBAC330C9A94B96C9295B2630DE5C3D2A946562E5BFDD316F1F3A205909942BB93B86479988C7E3F52436406C00870D08F29CAC164B683AA0C0BAF181017003088182D2C108B4BF35A704BD43028D47A48048C11044E86309A09D70632615A4844909E32861BDDE810C1C2AB060FAD82174A8A00CD3C72EC1C3DE2181C6DB0FEB38251630E6002264E08CC25C2E7C673C612E0A255128A90F85782BF1D643E2AD4556092451AD41BA91D41EA801D4AD86D041DB94DF9913D3CEA100C65167DB4B4695DF11113D34227A5A648F72928848F6BD0922924424894836F0C6422421239035481022E91079DC01E51A3414513B8A34EE888CC16E11FDCE027F263ECDA958BE5163EB5FB3CFE0AEA99CDC91254A8D397EFCDDE73F9ADB56CBB6E1289324FB82D4FDAF9B662274FD7844E870085DE1A7B860A937BF8BE49264428802F8073B80EDC89D116007C5EBC0D110BD9E5F1B7B8A860C0B36E62951BF63538C905ECA0B16AB1ECA4DA3094EB6229B3845E3BEA8268C07C635F08CE70183F4458E7B87F0E36AB90C7CD50AAEB69B102F3A038968D7A869D7B78F9487333E2BEF4858C62BC72332BB909D88D740C47EE6A5056AA75EAD3FDF8F2E6D9FD8F05B701D71E013B37852243349668E5C660A6AF706222225909344D403F47FC6F2BAF6AFB7ECDD6B42839C446B52C3B6D30A5736B4E2E69D24B006E091C03A0C81F59845F0EE2240AF5A1DD24988F541F58BB33A42BB60537F672C3EBA8702180751089C902F0EC62303A9D6B0BC33D075758FCB87597E894DEF50D9BAEF001F943F93143C2978B1A041553B88527751E7FD8ADC4985F7286F52DBFD331B73623C94683D0CC50DA7E8CA6B748AAED9B76FF5496AEFB4D55E1A796FB72C495D3380553C37E5D7853340FF6D2FEF5081F51F913EC1D627D9036F88C3BCE95882DFB77EE82F560B0D62BDC7C4BCCBB652DDF0771E34EDBA6A8F31E2DF572CFBF0B4A0DB4E635C5DB270A38B3CC303F048831E88062DF25AC0425A5540371DDA0934408956AEEFD0A28D5F911A4557A3A01956B01B64F0B71AE06ECD80DF92034958AEFD0F3EFB795A47DA34EEDB9424654DCA7AE4CA5A3A9BF25DE289500A20EABA0EE9A4B0FBA0FA55761DA15D69ABBFDB8F2A6B3DD1D1F238472C4F2346D18153B364E1D4034C689A940C29196025B38ABD394B94846A33B5D202325093B45EDDA53C8A8B74FAA2D265A0225A00EDD020EDC4E222352DB2D6618C27FFD0E2E51DFBB263DB0F3CB43DE9B0BC4EBDE17ACF3E6DED31977C802E050F6FAFC27A17CAABD41558EF3147545760BDC78808C016FBF5134F5E33E5B1275E007B55CA5CA8FDE6E8BA0937FB86A3DE712D60A5D9E08BCEEAB579AAC0AEB49BA33DA8ECA7D66362742C599CCA6F435D95CD3E1B54756536FB0CEE5EDCDB6B14EB1456ADC71C51A3B26A3D265FE473FB34954E2B5CDDC7FE0C30DFB3CE099F39CCF8AC73CA67A6738634BAA7C0F52E8BCBD41BAE7598A41D1DF34EF7B1EE51AF5DAABE4B4DB7C10A01AB9E09EFE8F8751E05FC91055C83D9ECDB8F73E7FC9D0B8B8FCB6BEB68B58EFD7BFFAF63CE2749B2523C3C950E2377919F2CE5D7AA388C36ED2668FF58DE446CD6C42A5B29CA31008F1C509A9E313AA04076A9D5B0DCBC5136FBD26A977678A6AC76A27582BB205726D65A7754FD01E54CE0FB714E673FDBF8EB6DC3326AB80AF4AEDC5C121D0563D368EAF380AA842F7EDEF112D55EE3FBED40D7FFC2642D9F4EE5ACF3F7571DC77F35E5F7E4CFCC7C2D4F51CA821241F1C4347A87233FB18F7C3A9FEA98D5760BB4B316B4332BB4CF2D689FADD0BEB4A07DB142FBDA82F6755FFEEA71EF4B9E24173A23F8C2D402266B93AC4D1C6B13E200893A969BB569716404AACDD60D4ED6E030443A16622C317D2C7E09CB00EFD3398F2FE72C7E95B2A96E1AD6BBC6C28489598E81596EAE6A01DB174B85E29330877548CF59B9DA33534A75AC35BA4DA2856B29E49E78BC509465BDCB1873AAD99CDAE83A9E3C9763AB44059D3BB7D17EE17BE4ABA89AEE7DDB947051CC079EAEE250F271F525557BC8BEECC723FB12D7BECC3CF99021CD0AA09BA5D90934C0DCAC5CDF6173367E656E78760CE33C46739EBD1674E35764EC628719614D5DB860DB388365B001A7E22AEDAD36FB8E258C0597EC87117A46387E1B30744FA13B0ADD1DBB83E594B69A8CF960790A2C92E17700861F6474B1020860F839C419914DA501C3903946B1C79DC41EC57A6E0B3F36BA8CF247B9A795E4F59E7D65A4162185F6696A7F301CFF3B0BFC99104BBA7046B3CF841008AB2AF15F4339B50B96F849931BA8FDFB336D2A41DCF6F0AE557417D69CA198F1F19B349031E3F399F87A957A58DB568395C7A5B350535A6BD3BC1FA3ED81FFBEE289107B174AF1E14A87C97D06FE3B8FD76D2C42D74F91EE6332B3CB375C8462B46FBFEC3BDE78364C66C7D823D7E46E207703ACBBE1EF2B21B7A56280883137C0ECDC0CBD201DC656E35A8DCDA5F9C5F017DC03EF845D9D5BAB7344F30B725A9C6A0CD975C3E69863C7632E218211993D8CEDD0638E97C3C4B629064D31E86377D8500CDA34060D57F608C7C024B390CC4224B3102202DD0073340B2D22CFC886550F3C196D1469EEF3AE029FE404BBE77512BECB3A908920A989BA7AD4DE7D46DC371E6F15B1D6631C53B8E5E93C9AB5442AB69DFB3735D0761203479A29267CBC2606C5844F23863B76F3EF5063A3638E654299C2D011603282C908863582B7BBC1DDECDF2D8E9DE9DB757D87D5DBBECD5DE934F96A3773697CB4DB7613B4402EF8EB48CD016A74614AA8FDADB047B658067C02127CAF63D9ADB43E8C8ED556BF5497EDACFCC0C09ECDAED54337FBCCB2B38B49B53A86D41F90EF063BE00E55EDE76803F7230E8E1FD221B4D01E18D8603BA48539E6AD98C4DB89B7E3B02A88D8551DCB8D555944AE50F9497EAD1EBAD947ACE7E0634CC75201AF6D51687F606237262B3E7B6A3CFB6DABB9D7318F88E9BD8E65DF3E636558912D48E692B9A415C2BC6D354E509D35B959D9BA3FCFE598FDBDC4CE889D61B0B3FB550AE7F4DA80B9F0B30E905E82B6B9B695A1D57E311AC79798550FB3ACFD824820B9BEDC5C5FA7B34B841C61E40823AA350C8FA81632D582F3846DC01CA996B52F0C8DB29037EC98BD61E4DD396EEF4E764DE9CCD123D67AC96F446486C8CC41919934F2DECE67FFB74AD24C1C42788F749096C466185417BDD121E8484EDBEF0CA8CE90A100C65167DB4EDDDA7E47540BDBE78443DB000F70AC2F0D21F39AC527743F30783BC07550526FAEF16F95ADFBF0BA7DFBF078922850956683B7318F62B9294B41AB7518DCA5E0CBBFC67EAA02D67BF6E7C9AB5C563CB115CB647F2B7AF36756636D9E67DF68EA0FADC62B977BDF70CAEF76EFDD86F52F627854614B2A8FFBCC1B3C4F77927E67C14A73D745B3F15D6BE0EA3DE449EE7927647C91F115C2F893759020C6978D6F797766CAA0A1C81C1A810933D65325326F668B766CF619A216DAB015B9D1BF0F4FEFCEF24C916AB3809FE48C6C1E372EBF61EBA6DAD2FFC220A2C0E298A975192ACDE413EF46265A769AB4EC69B12C5C7ED93708E113D742DAD1B281501DB44C8BA0A165ADBF3B06BAF41495D7C9BF9B0AB4DE67208CFC771EAA5F4FA5793FDEE8E2A24B458DD53A8CF1D44757EB30781B5210B0AC5E905A0541E9B4C26D128346D7EEFD6D9509A82B46E93C16BF16B41FF98A2F599C6ACD945A8FC1F313CFFB358A55A15569377882ABE736C0469715E65907E899292A6479C34BC15BA3858A566D37A4CB6A7064D33A1C49FCBC51C42E6F31423853108C4AD689DF7F56108CCAD489DF7F51108C4AD389DF7F55108CCAD189DFFF8782F01F8608FFA920FCA721C29F15843F1B22FC4541F88BE98AFA495D523F1979FB13F54B29DB8C6206BFAF74C182A2D5C8A84A12D1F6E2EB72D7CB0E934441A8026764EE91B9076CEE15B3BA8B520E62EB29789686DE009C2E2B4FB95C67E2697F64C8613B07811C41EFD5D7FFE2186C5472E9EB7A761D4D86B4C3E17235C4256DE9104AA78975F6AAB3CC5ECD4F731AB30D5A3C70F9885859AA56CD7AD1FFC688172AAC703F996AB0B978E2E71DC93D6AEF3165206165E540EF1585DD4ED2A6D5EA3DFB0E044D92EC9B6D9A1845235918FD786461E05B1810493E2A9EBB856191DED34FCD5B7F44FC7FD8CCE830A0F15813E53AD3D5FE6EF63924C61C4B4139A0441C78F63166AE35E6441BF2E112C31A3BC3723F56A28AE4C6AA8C8F96E852309A6E3BCDD5AEB77065C1BED646C4C2E92A5E4689D3BAD8A2D8AC89AEABDB99E4E622954CD6BA4CD8E9E642351348E9B4C2950DADB879E7AEB521E92DD25BE3D45BE2CB7055580584A554325451C5153A7964AE94CAABF49268DB638EA89741DB1E12402480480055BC52E749E2BF867CB6F52A3989A436502B21351CACCF27A762B479E9F4BF3C1E2FE0A3103C5EC35D51B691581B8047626DDC622D49CFC3D9030FF90F2741B685B1125D5D97B78B8EED55AAF8A8F79908A4350BD2755B4EB6A6DB204D21985DB278D674F7569A4D5CA93F74589566B3791537A4524CA5D36C8EADB84AA7D17CBF859EB848F324B71D46F3D4E3D53A76CD85B3C5AB934EB50E521DFD78A43A5054472E0985B4390F8282AE39E9100D9E95321984D327FF6B97B76901E547066B5C5C9B7902668D255E6937495B2BF45113ADD26E427A639F054D61B86D35BBCB268EB97ED20B671BC99C9B2B8D9CCDA28DE8FC003C92C90722937F162421AF5EE1BE51A31DD54D3EF7A30D90D24D900E59ADFBA9992CEB1B0C669469CC5FFC0F15B96C3743BBE1E16B3A57D1CA7633B4C794C5A978BF3AA95EED3395EEBA59D67B4C11DB66AAF69A22EBDE4FBDC74003E4AB4527B61A5D87AB7527497ECE41535F96AD2648E75EEABF2B9AB76CDD870ED70A989624CFEE9F62BB4DC7A495DC937BDB51A1B49271A2EF1E56C290C1604621AD445AC9452B01877AC49BBD6549AA5FEDDB1EB2EA06E091557720565DC698200DBA0AA09BD6EC041AA0302BD777E8CAC6AFAC485A86D1AB951BBF32134C1D37E37417F019FEF954946FABD24C66C738CD0E5232A46410950CA47D56010450320E56D9AE447FBB19668D0D29A8F1B6A9C36C48848A9FC36EAFFBB65806D19A2BA965D576520403F048111C82222822C7001AA0407210FDAD087D321F238B0B86E6B62746D9664595D73DF969D00259749963CABFF490798F916769D6FC12CA36838C2DDF5372B5F2A6FDE987BB4C6FB24039BBACD6B1AF9C0E29B7EE5F2EFCB8E9CEAC75186452BC361644D660F2F403FF55397261DB6A80C49AC5AEF216837B99CD629E248D62B7DB5663A4332D9251E1DBE29ACF5A24A302B8577E92C67E33897DDB6AE04461E1EC566166DB56132E25FD440D1A953519B058C19496F3286CEED3DD369BE8FD67BF2934CBB6E128D7ACE17ECF1A0CF25AE35716FAFFD21C4552EF3140F4BCD5528757691F8EF66B14BFE52BB0F1A9D43A6CF0CEDAF08CBE99ED659FDBF08CBE1C799966A5569ACDB05A566CA3CB0C53B772ABED6668CA0ADE349AE8C105BF0F25236AAAC16DFB3EE33C1B335C937969E31A9457DC37BEAF6DAB814C043DB2B348126F4EACD26C900FBA8C56BAFDEAD57683E7EFBFFB81AEDE4AADC340EAF2050BF8F96C15A40DC07A8F813668C1BBB542BB9CFB81103D61F36EB7CDA66FA295CB69BA0D184718FAEFC2E06371F3ECDD6A87C15CFD702E9A7FF1C3D9EA8EFFF82767CD63BB743F30D0FF73E64FA3F09535C473B5DD40FAF18435884DD1341CE317F67FD73C49FDF7E6946A1D26CC76C1FEC59A5F70D9381CE77F16ACB1F8F2161366F31EC993B09FDE2FE72C0C79D0E4394AB739B65802C9942DA5CB410B5EED37477F60333F2A66D73240E327E663DCB257F62F3FE42DF8956E03CECD67AFAA0DB86D35473AD3431931ADCB98CFFCF4C65F340F3DA87598E24D79EC474DAD5CEB31B07A84252984D653D321BD6DB6C02ACCAF16C84DAFB98D2F44A15200BADE6520777938FBC772269440F2DD671AFEAAFD812DFEE322E942CFBA4DD8D4E32A594A779012B5AD7498E05D04CC7BBB11C6AE8A58EB32C1CCD7A4DCF9F343456D74EE2322A00B569B87AA377EA6056BFA7A1A5D0698D3C80F9BB46AD368C0957538DFCC711E74380FE63893E4815FF98B45F3DD95AD26EFCE972F4A35036A1DFBCABA9B24E7CF7CCD1461556D377B6AAF17EBE9FDA3FADCCA7613BB2E996BCEE4AA341BA70BA955E06A1DBB8E683EAE85AC5A6C1230D5D081F607A616A8F6D3AAF518C9F328504579D6361C45568B6F3AE9CBB6E128BF850D88ACC1E41D7ADC5F6A4E63DE3453CCB61F8F62B67831DBC7D532F0E5A82CF6DDEA1235E1D6F6C1DB6E941E015CBDB82588DBFC89794E285690186E7BF7030F3265FD38F7974DC466DFAE03D9AA5BD0D421A8F30552CD65033C12CE6316CEF7C26C157FC11C90AE825948E62120AD1145E5DAE607A2FF8589386885B6C6ACCE499F9CA9FFC5BE3220718E8B802D720F7F6C44F51DA8A697DA6B20284FE8E09229E0217CB0075DC31DD306758015D4218358879D8DFF98B74992FB069AAFA26CDD57FC7BDCC72ACA697C67C14A33BBA2D978761AB87A8F818403390C946834D168241AEDBC39490573A4D1A69B92F0096907B435E629D1A84338B16DEC84FE294A59D0A2EB9A7D86A8856E6B456EF41BA22B2475DB6AE2B5DBD1F9716D8B4BFB83319863745804519563A62AD2A27DE2F1C20F9993B3AF8A634350BAAFEF34D3CBCB145AD2EC3434FFCB4B3585C6D56E4B6CD9D4819D771B6884964761F714486A91D41AA5D49A327F36713D656B0B6221AFBA2E6EF5766EAE511C9EB51E135342D9916B288CAE78E2C5FE52DD7655EB30CAA261014F1E578B05573D6DF53E124403F048108D5D10DDAF52004954A0588AA2D6ABBB645171914E1855BA481A913422697420D2689DB9BE78EA248C4A102B59D47E71BB282AAF512551B5C7C06713FD50FC4B799341689AADF5C2716D2E18CF17D12A6CEC3E2ADB4C02AC819ACDBE6934F0B6AB5FC8A3F996DD2C93589B5EBC47CF3A605A3D4C22F7851F04BA65546D3778734261E9D0AAED463E598D17D6F0FE58F8D6CCF22CDB0CDEDB9CFFAEAB18576D3751CF6221B220389FBD373574A5C368AD8B8B34B9F445AB31BDD1521BA3F48350122BD575546D3758E9D90EB8D945831F559A779D1FFB5BF361FF6657B00AA61CD1A622951257A8F79823C215D4C223929213A4AD2428ED2041AD6F57FDD07F338ED681FA39A1B7504D927F2C8388CD9EA29F6F9A22A8DA63A327A5E6100CAC4D5D6EBA0D9E257B0E1495B26934C0F1BD3795C36D5B0D3DE4CA819965A381349AFB2F8A12DF341A197C6CFD2D54368795ADA6B256CB2D6A3D633329E477E56E5348147BA3427F758F55212F6A312BCA2E239BA0BC5015DD4AA715AEAAD4954E23A31DB85401B93EC8F53156D787B313766DED806DB97217BE85423CB4C83843AE07649F4C92C71F7E934B6D1A0D188542C88CB377942FE2C1C29A7C598533C987547372DB638208774283A47B97D152716D6FDB0D5652EC4B5F9B6609D47B4C10F975F398A7B2CD40BAB10FDDD9569566D25F03F0487F8D5A7F65F52A2EC41B799B453F5C0E276F20D9E8B33E84D6EFBD7EA1A293D46E13491EBEF2EB385A34C5F9A6D910AB596E6BD34832A01F8F6400860CC8B73D4AEBF18ACB02622CF49C8A63E8006DCA630CC469A7019ACB5BF67CAA3F1AFEC2AF239DFDBC6D3521C27206F7A1F87F16A7F2993439B1DA6F8E7E2916F46BD4CC4B507BCD911F57CFDDE0B51F38E19FF50E6054AD91442A89544891BA8ABD394B78463A1C795515CA9659F563B40AD1E6A58A00D5FD80F81509031206DB84877C8F99A3A7B0866321057AAEEFC8D7D85ED6BA3FCFDC837813456FABA52EF8B96D3745FB1B5FEBC0B266532CCDB6C95A87492607EDE523F976C4F26D19C56951523572A939D040B292713D08EDDF68ED4255CE29DDC3DFE8773FF11537FEA6D1306342B5342BCD2403FAF14806A0C88024652BC104D2FC4BB98CC2992F53839CA4410BA6955C188CD52E215A205459D1F1C37DE52817095A6DA09A6E93785BE643D39F41A5741AB97D0A37975261A4D66392A99DFB86D454ED6DBB419ED7D6D9A4567F7B76C63CEB003DDB475679A2CB6B4BDAF3DAF6258B361BAC58BC76913F551C1B99D37D7DAB9CA95EA6C89666E7BEE409CC8A82DC39F11EADBCB93C832BE0AF71D43C8246ED1D8E1C562EAEA3D67B8CE63AF3134FDD9E53EB309BA11E30B44414973DF019E70B657E65B3D9EC7460A1155A902747EB001B5D0633EC006DF619AFC890AB2F79D36E8CE6896F430B977798E36529997AC4A26B3866F669A99F49A57938569C6539353EE34DA3C1BBD50285164813FD2736B1FA62FD96EFD5B7414BF46089D5CC5AC0422BB4F7C86F3EFAA2C9487E2820A1310A8FE36649D7A2C960261A90D018C5935B271B278E956D0673D1C184E6388578D34A521B19AA979E664F396DAEBDACC5E0090BC9B5648DA96C1A4D9EB10E28B4405A327F16AD1AB7B5693498911628B44092FA4215D5DB5603E993B297173D5CA3CB440AB58336FBCCEE3917FCEA5D97ED465FA01E2EB4C363B377F9F5C6723F73334FB7D96730CB2E58A5D362B6EAFD37BA6CE6AA79A8D6A8F57BF49AA76E6BBAAD9FAE02AEEBB77CC6ED13DFF4DA3EE98E695B6017D7264268075CCD62D2749BCFBB0D5CD76F801E452FCF7ED03CFEB6D26CCCAFB5CCDAC6FAD45B9EE6723A6E1EC859693696CF0A586885E6653BEE1B32B9683391C71A98D01C47DC42BC9449C3CA732A9B2DB0BEC5610B5CD66387F8BD798CB6D269F64675B71D5ADDF74267572ECC2DCA500B145A20E9702CE6A39D8ECD6C6661D40C176D1A8DE6A3010A2D908A4B9254A184D50EF399A980A125A2740B4EC25F58931954DB4DA20B9E68E4335D959C669F49AE47A6E767F7E1B9A731A235DD26D8329CA45604295B0D22D21DECBAD9678A9AEFF17D6CC1ADF61A4458B3E8913C79AF115FADB41BC5E3998AB56D1D8E74BEE01F2AD2B6D564353EFBA90A55691E8E75D7F6B8EEEC9ED79DFE81DDD93CB13BFD23BBB37966772D0FEDCEEAA9DD44AFBAA4804AB379AC45DDAE5FEF3147947FE911F31E836FEA52F124174D063EB5DF5490B2CD20E679FBF85DC771ABED94D932E08D52660B7C34390BB86645609C4FA66C4259C494FB215A3FB2C695BA626ECDFEE1AFB503D81A733BA396337A34FD061FDF091DD433053CEF10F6D01FB8F30EAF63CE15A04DA3C1D35FC532754B81AAB61BA45DB1AC4EA682566D3746D3DE6AB3CF6CBD419D0388717EE2619C1C097F02E2CF326AAEB34E6B1D065F6E11BE9DF2D8132B99BD36E6A9EB3747D79AD38D3EA374B8EC5CA92B6D485AED1D8EFCC43EF2E97CAA6356DB2DD0CE5AD08C76A36EAEFADC82F6D90AED4B0BDA172BB4AF2D685F8D4C38AE5D309566032D0C722627DC361B9C23E8C8BC21F306C5BC713E31B409E564DE989E168A6B2C740093013200F1AFD1F365C092A489576DDF9709027BEE28F689939B5AD2CD375369375076E17BF66108CA97A8AB47ED357FAA7027A516A5056F793A8F662D7507B79DFBA7D9B044F83E9DF3F872CEE257DEA012F59EB1980344AFC740AF3757B580ED93AA97EB2BB3E054D6DEE87690C0AD350B6CCF1486D8CDBF9944AB7E18C379D7646C90B101696CF0F8DDF7F824740FA5D4916C4C8D3E8476475FED42C5D050BB4D9C88D9C59DC80EB893B0C53852BBC98EC10EA45CB0D49B37A5FFA6F1F00332906185F3772EBE632EAF6DA4DA543BF61F52C0087F40DB27B0610F72E012A7224E95E1ED9953B9FB6FEB482E9CCAD87B8BC84F8A8B3B911D70EF57692774AD9F58153E83795C2D9781A6A844B57D38DAB7C53288D65CB9D76AFBBE7CCD87E36385640999434861A8DBD65D7B727058021C8B291283664DB657B61273E9C723E682C75C84828472076DA0ECB94B07443F11E8F4DBD4FA47E31222FA424EA15E3438A750A976DAD25767E4641A70CFE464222753EFFB24AA46540D9EAA41799936504E54CDD2CF84447AB03C4DA744A6C81744BEA07DF882B26B5AD9A9DA4B5E262C2F137466145121A242905448D63BBFE2A90B052A206CA84FEBA5AD2AB0B842518195F67DD187ED55C5F9036DA09B6E838F09B0B478FEAC94355F69B6C07AF29B953C1A5D869842FAC7E9E33A49F9A265AACA2F868F701D44ACA1B08B26136593CDE25BB37C53B5DDF09EC5352DEF59D36D8EDDF9341BFDE6E8EDB82E882DCBAAD63B1CF9B7A612FECD4CF93EEA8E8C786C3F32A2EB6B862BFD057378813979DAA7CA72D557B6CACA505369BF638BAF1760CDD1817B4441C7494103F6BC31865CBEEB2A8ECDF7DD7D7DEBF759BD4CF9DE9B9D168663EB861FC3B81E8F7D8DE763D36A2091C44D2902A96833E06071B490573568D8A6D5C4D9A1E2946D667C2EFA71EB87FE62B550295DA5CB18937DB462965D24C707E0911C1FB51C2FBCD042A4BC44F182394A7315CD46A60F41E973B7572E6EF3BC377EB22F977E79955AA8B3DE638E28FFD223E63D86AEE9E92AF6E62CE159D285C639DDE83744FFB9599C7CDB6A8894150CD06015EDA3FBF67EF5132EBE01EFED367ACF8E0B00F802154C87EF700056DF4A5420DA3E1DED0FF7F5654266551517A91F79ADC3184FFDC46B1D265FCE6BF39331F2759ECFFEAF91B1241B0CDE9C7CE98D9796379970A3B049878CA4875A30DCB448388E6F7ACC259C21B3DFECEB17EE4B8267CED7CB287CF15F1D647607CA1031DD7979EBB3AE5CA548CB46DF5E25269884FBCEE3449EB65DC3DA341AA7C2A8F3AA7518E39DCF66314F924F5ACC6DA72DEE5917AE51E99AFAA59FBB708D8AD814973E099378398F42FDC3ADF41A235FB30F2D66D66E8CF66D2133F47578458F31E2AFFC598B97B59B64977A3C4CF8EC49C930DDB69B2455C49E50324FFC239DB2B451675FE934D0D5DF3B9135DD2393FAD79CA5ABD8C95AAEE2580BFED6EBBB257F71995EF4573A0DB4F7E8358A7876F1FA86BF374F2CADB69BF8F46E5741BACE8B727B8D6C2DA5D3C087C45F98B8B6BC54C94254BB8DE6EC87AB4443B6EB3D2688D9D6902658D1389A6FF6893D07DC798F5705C5E27BEDBCBAD52EDB5ED45C098D2E035B4F5EA81A159566432C950B559AF7653D3DF9DE9B9A73B46D25EFFD003CF2DE6B7A4624D53E5C0888B8DC4A8C69AE6A170F1FAAD8FA3015571F3A61F5612EAA3E7482EAC3D855C63EA62D054B1B5D06D4E4E5857BA9FFCEDB90B53FB0C057BF964697D173502BAB9AD65455ABA99AD651552BA89AD64E55ABA69AD64B552BA51AD5489DC67E986AC22AD5760335CA67AFAA0B7CDB6AB2FFC29FE9D1EA3DBBDE893049CEB315DB54C8652BA9F60178A4DA47ADDAF962792598FD3A8B5A3EAE16E21B593BA8FA21704394FF309C5651A9BB5C21086D3FDA9725210FA2F5A220906AB2E9406EF699A0C6B376D47ADF70D457B9595E3D51B7D26C30C3ECD87215ACDA3E1C2D9245E21335365F6D1F8EC63FBC390B9B2C69DB6AF0C4FC97B438C95E333BB57738B29FF2C54C7B6A54BD6738E2B31F041AB84AF370AC90A79AFBDDB60E47D2DFA3CDFDFDA64AFCDF4C453D296252C4C08A7812BE170EE73C37253BC2DAC5F0AE6116B575BE7D2C7DA1E8ECDD8B16A05D7ABA1B4BA7B4FBAF30F6FB0F191A6CCC532A72A09C4031F8A80ADB232B708FC4808C135D304D32E6A6D10407A692965CD26245AB9E9B4ABB497C18A2FA90529FC0B02401DE89AA90A7DD8E23BBA9151134DB915C21C4C046CBC04AB599C804E19B68CD82747D1EB2609DF88E3CAC441E003C908419217631B00E201DFDEAF93965B1B6238AAF7276C9E2C6CEEE6DAB814411BF9F24C9AA214E36AD66739A46BEDC0EA0CCAA6C1F8E761785FA9BAC7518E3E926D8E8327C76E1F9335F677B7ED42758E9336086D93CDA70D55E839CF72CDCA03ED26ABB299AEE81D67B0C347AC85A6658EF3147D4CDB2D967FEF54D9B0AA9D641FCA31F8FF8071AFFC8F469B1B61D09C716CA9A61744174538AED957A0E51EF3758CA3A9970692E0CE0AB08C29E574CC285840B927029F6CF02C99702CD51C4B4A20C9132C5C55D82A6F213034A57CEAA4EE536AD246D06CC93A4CD494B9B6C762CCB2F9029163C5EC3C81D15D74D020DC11B208B54980EA9A4FFB1B90C505D1EF51E7344D5E551EFD9979CFAA6637FDFCCD9DF830EE7C11CA75690427BFEBCEE0786F8DFFDC46FCEB5D661E6FA680665CA36431475856C5A0DDC3BBED79C4ED1342A5956D40077AB855B07B294565D005DE2697B9D4E1ED57B0D3EA3E88752BA3A6F3249FECD1E9EA6EC7AD96CE0DBD27C813627BA04AA036FD3681037D3943D3555FD0FDCE3FEB2714B9BC6BDE50900561C86A9502ACB26EB9651B5DDE0CDB180EBD0AAED4639099A02EF86F7C7C2B7C9ACB924F33683F79665546AB873A5DD24922B16220B82F3D97B33985BE9305AEBE222F55195AD068499275EEC2F1B5CB96C34A01B59CC485575D5768395BE9C490BE5A2913250693658A19AC311CC0F4570AD79BC2171CD5AC595767334F985E9F1F29E7D12643C43597284B4D5C84B3B8CBCD6B70B90E5FAC4E3851F324D1EDEB6DD440BE5768FF2826B1DE3A27E994D701173F6368B7E84AEFCAF8E664B02FB503A9960FD622D1D547F621A076DC577C27E9049F7B20C6C43456C9B0DB19AC54B368D86381A143B39A5D0D74697E97BC8EC44DD1B283AC620F9C84578A22EC26994885732F353E93A7096AC5D5883056B3748B75CAD5EAB17ABCD5FECDE0E1497A88B6ED3686C016AED3F53BB46B56A4C9D511AC6B869DDB5730CC6077113BDBEE672A5C9ADEB3D36886D7886F6479C6A0E60D9369B5859331569D3B82F1F07ECF18CD03C7AFCB98E436DCBFDEA1F38CF6E15CB5EFD58FB77AB97B6281FF2F2929797BCBCE4E5252F2F7979C9CBDB85485E5E37766AE7E5DD9D2D74D942472E3BF9C87E996A7646802B45D5810C27A7FAAB7B68A9BCA88590965D063412F8780BA82DD89B5DE5F2C24F0A0BA8F559A29E75A01AD5B2AB5DF9B903D5A8BEDD14B88CFEB13ABCE0B767BB6E91BFE369E331E72DE4AC2267D5A938AB54AE32CA507452C918067159D5F1EC99411F4E0F47A85FDEC216D41F196B2790B22DD01C44E85C156BD368CC65AE5741A0E53379C7EECD6BA8F2348F3CF699E238D8B61AC870D04237B24A4B8316642D060ECDF7571564D368B2321552B1733601E39CC52ADB53BB54551F9A6E937510BE8B3FAF85888A9A3CB1DE65E07CBB9A34AC89BCC504C16F1EF654349961643516354065BBD93DB5B8961B5D4698670A94915524EF4581F0CD8EACDA3C0F0D50D96E764FEDCFE9CCF6397D56A08CEC3C792F0A846F7604D7E6796880CA76B37B6A7F4E9F6D9FD31705CAA85ABBBC1705226BB2784E1AA0B2DDEC9EDA9FD317DBE7F4558132AA492FEF4581C89A2C9E9306A86C37BBA7F6E7F4D5EA393DA82E08E330CCA3B89B6604266F3309562AFCE9CA90855D29E1B22BC3B0DBD5A419D2C85A4C10B495802BCD062C575CD4F2B61B5DBBF5A88CD73B30EE202C8CD7302B09BF60CAF3AFB69BA3E9B1AC427120BB69CBABF458FB4A1500F3B48ED0EB07E58DBE600997C68AF20D56DA779D9C01912654E614E8330D2CD20CEEB56906F7E6484AFA8355F2C313FBD0EE12DF369B3CABA7E649B34593D17CA6D0674C4DF4E73E1A1FF998674CE8F3280E318D0237A9C02EF97F77491AD92C742FA2D6B1DBB407D822CEF051B027F51E9F8CBD93CADD5DB6DCD73E231B71B488B23228D999206E518D2A966D44A31BA3339A51BD541BC968FE605F56C1A372E0CEA3E1513B9B5BD1DB639A6E23EC175F05CCDAC6B5768BE22E605B449B78B66BB81FA7731D372FD7AE65DD8F0CDE71DF188EF8B45DD4E05DD07651DA2E3A8031EE51D296E74DC8C2F30F3C92E795DEF0771E14717737B16B083E50081BA37689E41E309D801E70C9FE121FA6E02983D919B60AE1ADB61BA3658F4B8B57F49898A18A596C6C148F3DD5EEF4CE74283F31758EF51E7344758EF59E510967D0CC3490B434979CB4FE8434CA46EBC6A16CB4C1B105CA466BC570CD4683F5F0516E1BE5B6F5DF13E5B60DBB27CA6D1B764F94DB36EC9E28B76DD83D516E5B3B02E5B6F561526E1BE5B6516E1BA7DC36CA6DA3DC36CA6DAB35526E1BE5B68D25B76D926CD26FCEB3A0C1ACB968D57E8BCC1F8D0F7BDB6135DBD6698E29E05173FE6F66E812F5D023DA843E862275AE6615400982B4FF8C22211409A148084542FA502812B271BD5124641826454286615224641826454286615224640026454228124291108A84502464301645423A70281232E049532464C87C28124291108A845024043712021600718E7BD8863BBAA31C14DCA0E046BD95821B14DCA0E046172605370663527063182605378661527063182605370660527083821B14DCA0E006053706635170A30387821B039E34053786CC87821B14DCA0E0C6110737FA39A6646E7EF8DA463537DD2672E55953C0B76C1C8E93D58A6B3B5153E934989FEFBD69E2159B56C3193625C3A6D1ECEDFA61AA5B8245B30156CA174290486ADF40AB7618AC64E6BD35BEDAA2C9E4FE2EA53739F8DBFD53F30E2B1D26329DFF60F14C21E8DB66632CF987162DEF308A7BBCFB1EBF9CB3B8A9551B5D96983A0EA1FD8101FEDC7F5148E0A6D1E43D5FB1B560C6CD975CB69AEA7F2D37ADF58C319CFBE0BFCE8102BA7A28B3986E1BC680B06E7E69476477FB837D39242A9351C3B24AA715AE2A1A944E2B5C9DE743D36DF2F99D7B1E4F144761D96AA490D82AE18A3ACA1B8DCC01F6AEC0E46D262859B5E67513A76C3541FAEEF31F4D9CBCCD48CCF1803719E8B6750C6601D5FA56118FBED6B7D48A0E8A475E6EA16BF49775F99B7441FD7D78ADE843A60F799C1FB27864D9A271F898DB20867CD1EDD7B67E90E525CAB75DED30F8C0CBCB54F6D5E8A2CF7D001E7DEE07F1B94F63FFDD0FF8ABCB515E03C04C4440174AEFC7BBBDB8552CD47F626548A198A9D0028D0C3F32FC48819002415320B72C49C5A49CF4861E63A0BA68BBB84BC2E6D7E844ECB6C760ADEA3F27ABEF08360B4BDE919EC99A9258794DB1AD438D062A9D26719E24F911C50DDFFDB6757F9A53EAB1D457B549D96A8224A770C9C2F4722E8F0ED4DF73FBAF4C47BA5D250346D2FD6A1F3AE9DB6219446BCE553F7ABD87B45C3F1E6939242D076521391B47B67651B749646B0DC1EB526CFBEA3A8A174DC8B28DACAA53B2AA6ED83A5A35121ACA36D235FD78A46BD0754D49FAC1944E2BA0B1F6E9401AA6863600DDFAA8F6B37D2A2668F302D6D013E258106FAF997BB7692581D68F47020D41A07DE773DF0B5C6873816021B15AAF6C7BBAC505CD455F691EFEA61EF8AB9FA4717E4471738F4AA36F386A3115D5A753EB3030BEC3573FE4CDF96D5B0DBEC6394B129E34A12ACDC677A9EE04A8751890FE150F54B06DABC117CDDE9A5F72D66224139AE793174DA66FED922D99E7374B6834FB4CD27DC5820C5FF5B04AE770DC5FB9B4D3EA70659BC9F7B460F15BF33BCADB289432008FF4E428F4E47992449E9F897E4559FE922C1FA268F1BFF23FD7E23B0BB22FAD452FEA7FDCD481C5AF34EA77D678643ABCFF7D9299FDBAEC3CED532F20CAAB9B1F450D59F3DBE6CB908F72334BCB1B788C56B1A7230F5D37D09C78A5D9688E975138F3E59BFEC324B95B05C17FFFF185054D878CD953F9AF3F6917D0F03576F32AB76EC91264DF3E521ECEF866F6DF59B0E2FFBBED2F026B6DEBCF1CA8B9367B1006AC59D33918AEE7E6E58AADD684D75DE0B8AA8D6FD16CC5F7C0B7DF71EBCFE1BF108BC7ECFE99446B168875BA5A06BED4022C5EFF6FD1566E474DDA3F8D41172B9F43FD174396FF80714CD7830AA97A285A476D5EE6BAF687DC9FE1275DBFBCE5DEBA6A5B00AC67DB07D8BFAA4BF621E691326107C4CD9F6CE84DD1B2F93B291BE4B264AF3C334A92ED758FDE5CB0EDEC2926C20690F451968BF4E324956BFE99253CFFC91FFF201ECEBB3FE3B1B01AD6E2F35CE41FC5E3EFC165E067DB40CB1FDCB2D07FE149FA14BDF1F0BFFF78F6D34F7FFEE31FCE039F25D2E0085EFEF8878F45108A3FE669BAFCFFFEF4A7241B20F97F0BDF8BA3247A49FF9F172DFEC466D19FC4A57FF9D3A74F7FE2B3C59F926416549743C5D5502C8273CF13FF93DB151FB8178552D7B2A26228F383FA52FAAFBF71E52D976FFF81BF0C42D4BDC926EC7F35166A3FA2BCA1FFFEE3B32FECBDB490263F73F1CA25A79FB254C845F14C27339EDDFD1FFF2097A3DC0DBD59927FEA1B7FF8E0E6D85AF85F389BE51F9D137CC5EACA716C40AA7E587B14599CF352BC81BC68A43D4E7597A23D8A58AF3CE6A1C75538CB47AD20024F14E82DC80DD5518910BEB3D89B3341486FD9C70D0F5FD3F97FFFF1D3D72A6A1AAF7A41EF973C1472B3DCF69C63CFB8E72F5820459CF85722662EA0855093BA48749F994F3D8812FC51AEE2CBD8E501234F2F2BC693C9095994A05CB0F65F5159FAC3FE8627C93F963711739ACD4DE1637578EC9EF77350AF780D219E55E795C3A757F559757C7F5F7F32FDFE6ADEAB62E1897FA759792CC359D61D57A0D3AC7BB01CE759775E0D7D2B559795152FCAF532242FDA6A7A285ED4C61D76C28B88B8B4AED89217402CFF8D1680FA98F8751C2DDC8140384F89D24354CE8C898A58B1377CF6CAE362E93A2FD3DD301FA9A4B97C20BBA1403B225A7C2986499147F9D54FE7B398FD6001F240FF0885120EFC7FF1D9E5FC77BEE2E8C32D639E70599B6A27E3156FEBB23A88CD07B37D1FCE50CD270E00D878A6CE881BE30D5C92DDB270951FE3010A5B86913BCD4363E2372E638338FDE972FA0B16BE15A2CCC9C3A9E058F2772D0E2E6B1F30A4B91D20416739E89C0C80161C6057DE893942513C97D8AC69548ACFDDCB46AA9354A710F14E4E30ADAAB0549D3D2A0743759296DBA59B6BFCFE24B926A0BC4902479EB4010687ABDCF08CDB53B0422BE2F436DBD44F5A99B4728162A295FD2010EDF1DACD9CADA3D86A641505591FF70D6861C8969014C76A7D4A4120E7C367E3CAE84153F2F94AC8E346CEEB010866A37BA5552C91809C0063E71C772CCEF70A42930331A3B05C4125B6807EF64316AFFF6DC13EFEFDB0E9067104E2086B37BB5DD58C2E1C6157492AA4D07B71FE1A3D5F062C499C9F0D74860BF7DF813E32B90A60BED6154CC6CDE52A960AD7551217280FD5296139B1474ACF7246F5C8631F211E0E4DD720125293043B6A511CE4BCA361A695732E9186DA9CF0F9097F8833FC213EE30FF1057F88AFF843E0D9211CFBEBA0D4A10C75CAD6526BC87326DDF44F0124848D1FCD201419D97564D7EDD9AE5B0972E298C75481B0B5E81A10953B05B7E58AA12AE5B50767831C9A71076A4B5DFB210B3D4190FFC999DBEE36E804FAFC95BA4BE51C27D7C9391A1ED553C7C2E37CEA5878E44F1D0B8F05AA63E1D14175ACFFD8E158FFB9C3B1FEBCC3B1FEB2C3B13EFDB4CBC17629393E219A8B51CA82EA8888B60A06F5DF96A2B3A7C744B18962BB506C195E152F7EE127F233B124D975104B9AAD8260126D16BE8D2BE0BDBD75545FF778251949A113964273FEFB8A5F0A138E074E315C15C8561A69817023B943C63C5C7B9FD2AF2DD2AF0FD5058FA3660E662B17B81729170DE0BBC3C8D54F0C607C0CC0C9E1AF020130805DE57B0F19D35C1411AF305205B4799982C6A4490E5C9300E81000EDB133BD717CE218CDA682957730B9B2F9628180828F5FB3F0CDED5149840BF1C97B73205D38B62D4153B6E6C5695CB0FA01C9E8CB37E5F259FDD58E733F54FE0C24B89350CA50DCB949E3B0DFE3214C07C333A9C40B7143576E781765FBA59CC86181E1C40E2B1827430F4F8AD6A114F4C2712D8F430D916C3E75D9FCC0D355EC56845E057292D24DA05D7880BBC73C5CE94F31E011C680E552BB9CCB93D528D07C68E610059A896610CDB0A5190041822A1000CDD86DA0B97B4CDB403391170A34E3693CD224A44946A249623EF305DF4F1D83CD0D185B2DA28141D621BD235A68900D26E98FD6953D6E7B75B4615AE8524748C7E0C22B60209E31EE73634FA1A436B10D621BA56674661B6EAEF15E3D8DC7368819B4E18CB3CEE5C8F90A6A79C563274363D9A0662EFDD9901A711681036221C4428E97855CF16700974703C592836850702948EF80E6FE8E0D24919AD6A73E6EFA303A954CFE09F24FEC3B8B1C86ED12D120A2E1E6EDD0A85717A2B12B5F07B102727590AB6364BC8A5C1DA7476888819C2E03F939A8ECF674727768902C99480B122E1B1934A8B9EBA3064B44A7E349C16678574900300518E11EBCE25414A003DB5A19CEDE8FCD1AB9F7A3B1717E3203A18663CF5505F67029B384DF6BE4793559FFE2873E8028C4D953329431DB6CFF397E6A3B491EB817859E1F70279C27BE586E91EAF746949B28B735E57672FCB5904B57CABDB364A7E3E3B1E00EBB53A8203166C6B92B7FD8898531F149DEB87808E97BD2F715CF92A493706E368906E76A2BD176EE6ED30FECE87203F2E4917790BC8307CBAFC83B380AAE47DEC183208E07E8C72B90C93F7834FEC15617B593D0202BE474AD90BF46AB386441568BD529CEAF0259DA1E7A205CB363C898E69F6A1595587CEB1A1F77DAE06833FBC0AD1F24C53E6EF69DEFAC461E244B69461E43FC395B79E964C1B6A52CC52B7CF64316AFFF6DC13EFEFDB02919911422295B450A40529C02A343543B2649213AD1FE94686FC4B8F6460C4BC1DFE3DE536C8AB18AE53C5D755681F2505D8E87B30F63EC5E23F1C8C2120D863E11E921D2E3427A6AC69D25DF510C440BAAD3636442B39C7C383946F3F52B5FE13017ACC0B8E1EF3C70F976A62C96CA3B9CF10F27A694DDDB6534EBF6C99FFDF49325B4FC77B78CB5801ED32188184AA458DA003A2465E18CC5335797879C09978AA8FA15D8D9DD829BBFB928A04972EEA5FE3B77C3B8E2014F1D31DC9569F19EC1036DA4A44F5D491786D36AF16CED9950819CD47513085767035BB71A2566C5C047E4DD00DA86AF3A002C8164601A0CEC451849A127D6DB0517D7837CB91BC86FE1CC0F5F61F29D62FEE27FE8D897D5EA22B17FC2623F62A17BC8BC81622BF05514640BAD6F408B406609497EEDD6454DEE6828BF71985661ED0C5189811D3586398677E9E34F75120A99C213EC18F753246EA51C0B77940B16B04AEE24FC20EC03F96161DF01A507101B1B191B73CA0DD070101736B6ABAC00A24E449D76459D9035D6799270F454BCE847586C7CC2D3BCD20D721B85E95C339ACD6AF916CE20E14A06859A4A2096E0BBEF71E4B3B5EFD3398F91C7289EF82D4FE7D10C28FBF750926CAE333F1C9F8489504EABD451104B5D25AF764799AEE26594404C87C70B80E908791B39EDC1B98BEE5F8A859608B47F3A0510EF9752F9B2E0DB471A336C69F773CC3CEEFE00320117AC81D0845112A77EF82A5F0ED006578CD0F32479E4E1ECDB42FA101D8C9F0CE07C3613423DC199E2E3C269DFDA130FF8721E85F0BB1C85ED28EC9F69B45C2D9D667817A5FECBFA82BF08762EBFC52BB676B26921ADE3DB284E5FD92B978BD9E51E4B1C20F33307DB0999280703D76FE47A20D7838BEBE17EC9C350E899C2D9E6140ED26259BA215AB1709D110387350F103580C9D7D1BAE461AB338C6DD323541EC5B837258ECBB57EE357791B1518200DE9A0219D5CF4AD5AC05D43EECA5D4F8A8C9CF647E5B43FDD2D63643B926674D18C65FD3D179BB18661A909150C5C0DD8339CB96D5800922A6D5DCAE3D67EE32F6A49C514815FF9234FA39717B0C75A878379A63926CC03ADCF6F9725AAF65E7C15BBEA11426C1EC8C70475F2267499AFFA765E0790F1EEE895DF0178A5D6BC006C9F62191674BA7FE7F194F96EB545EB7583C711ACBCE2CB28F1C9B822E36A1CC69593BB51312CEC8DAB5DB917C916EAC1012F0F4646151955FB0CA902D14C38C6FF28A8BC4C614CAA4FCC5A000501F7848C947F76F3B99FCC15EFE1D465DBCD5631ECF4FED9FB0E46C13B5061508AF5D8CE5370350D8A97566800775E3F4AAB858C0D32369C8C0D9EA6EB4B96CC2FFC20708BE7A848B686871E09D9FC1832A84584A70A4BB64DEB421FB74902E5103D94DC3B2A294B7A6AC47ACACD35A697C8AE7A6A676E3252283B75966D9E37900EF8B65806D19ABB3B2B845DC3B9CEB960576C989216A143DA27E625C4AED374FF0F74F74BBA8A433E43AF04F528444AB03367D241F97CC821424473244473B258CACDC1303E911A982BDD54C07019E788D82134192B9E24B6EA4A9215BA5A397F178B41FE1E7B202122B087D84D50E754891AE95AD2B563D3B5F7FF00D2B32590B38EAD02EDC8A3D331A643E041A01E9F9B68E40E06F0CCE783891C904A209500A51260DCFC35F9E7A81276EEE43F4AE10D6DC581F9FAC937BF7FD5791405054ECCA23C2C5FB390A900BB85883111631A1763BA6549EA4E97721457AEB445A9DCF2113BA60FCDE08338D894840E099D394825182D98AB08DA756D9881E33A78F260774822C18E4828432727A3ED741C51B939DA2F4945684EAD08CD6164F797F562A299A338AB5751D967099591173B01DB3948CE02E2EDE3E4ED302116906A2303E928366F271ADC86732AF547502310B49D848C9263DC9EB1E394CD830834117F24FE78E4FC514CC0E34902EAFEAD6102B1490573B7A4B26778779F703100926B1816FD08A9317988898CD93B348FDE7F7B180E566259C4B246CDB2409D758A4E876359FB72DD114D21C75BFF62813A879338D5B8381539B8C8C145D48BA81710F57AE0FEE27915273CAB81E8C8B96A60AE644B01C3655923E241B40F0A081C2C6A087C34007010129AF3011ED90534A361C94E0650EA52B32AF7BA915147C1CAA84CD038CB0445D11BD17262D3C4A647CFA6BF472B6FCE639838710DCC954D2B603BF259F68CEB10122E90C90DDABAEE295A4B9E458AD6F63E3DE73B3D8CB82F6DACD9F5C69A424391DFB8E36113D33D68A60B13AB57A81C00D3DD79749EF82879A2FB5709ED872152BF4B520FC7720FFEE013F2A11245258A7AF414353BDD5C3659B2D2CDF59644B4763D2EF7DCC81AFD70A6CE9572E2573CF1627F29950FF052BAE2E26B86AD20273EA2193466413CDC03FD0FDC8BF2840108B9F8C43E2E58C267F7E155EC221D27C9B997FAEF7C3886C9F757393FFC8ABFF8A19FAD23BB6F518B65F95DB662555E09F407AA1DF3329A719785A005D551F83A39F8E9278B8572BB0A527F19182C151D0A156124850E22509EB8B07BC54C9D02ACAD78EE8245C5C3250006439B475A35E0E4DC6AFD0CF6E0F8A0635A0D6649C509475D9C10C7BDF1E8B1B09C72892DA09FFD90C56BCB8CCF7299C238728160EA3159071088B02C60FEF0C823BC93E4FE9DC753E63B79ABAA8A56FA2DF61E63014E7707F44143D79FBF8A2F0D58EBCE9DE2B97303BB208074CA50D1015B0945D6E4A15B934E490C9D56128C35B9AB540632F88EC0E01B7996055875D57285F63A3ECD251A6A26C82D0B5708B0701C0BDAC2C9C24A531E27D52F771CFB302FA320E09E90A2088B6837D906E7B3F71D8C524A0357EB04D0D0C126DEAB58AE33576E58A03C54E53A5AC2499F4C1949CA099C2900EFDD81302E26C903F7C48BF7C357C13FE335192A64A86C502C0D952C290328E4B5C10230506A58BB334E3A86750B7309A8E3B37806E63ED8BF0FF72D45CE6E3868BF608E2658AB27962B7BC5D3DE3239E285AD82D44DE5508605A91A5B55231EA9955A11D759A990E23A5C752147A9265A0D081D0DC645C9B5423A049C240349065BC970B94AD26861E7192FAFB59110D56B71A544391286A428B19FFC749B3F69E745C88150C4CE66968EFE98CB48F0242FCDFD7CA6331DF2E188B73E3359E51A8F9C1F04C2283F9FCD629E249FA0FD7D35F43354F4CF38E84F42552CE751A8BC3B2B5F4A017A1B3DFB0128E235FB0081FBB690063504D2039785D3A4A520D3EA31567F6384C9658FB3CF7C0D6060D6679DAF04A0CA7B82D608C8788DF43537E0A13FE7063CF4F75CC2C37ED0252AE0175D42427DD2C566207FE1238606B2EC31DC316470338A59BCC61DE67E9526290B6742A8EE233C61A70458F87615B317CCD84F413F1715C78F5B5C417CCDFE62B5900500AEFCC4430D5D9563659F02FA68F9D720689F1FCD5CC859B9E58EC70B670B53DCB7FB849ED8C7E4EA9323C25DD4AD98CCE3FCD9B4CE9CA7D5ADD02CA7F5D9795ADD8AD0725A5F9CA7F505635A5F9DA7F515785A582EA86BFF83CF9A92C8CECFFDB84A96D210748CD05E04CC7BBBF193D415E8265AB320758AF14E9222CB3708A21FAEF371F7F65DC4D11B44FCAB50A299F3D0317EA575181B33AA38F6D3285E3B238DAF3AFA7D3AE7311096CC80089C33204CF79793D3999CCE3AC1E1E279DE481E5BF7B34E746139A0B3B17ABDD067F6FEDD6C000A5C910C3905195253D1363244D1F1A632A48B248057A0AC8E6518C93238FE2CC7EF1521161F40B458F889F445A0E6C9568AFAB8088249A201B2CE13E5FE1200C89D6E91B825716B2D6E37B6958DA8AD1966A662B6C3AAC3482882B34231120E36E028348F24044908FB1CC3551A95DFE2247C89ACF20D1B1856B9871A0C5CB121DED22AE0AEA4036653E775142F264E41118960C80007E33EF18F145C6A09F2F8E22BB1E51AEC67633E9C617647508C41A542C82F76793F8FAB97CAED5A395BCB2FC451D44B9CCB8033C74295575CBAFB2130AA1AD736F6B05C063E8F45C76CE539063264DD985F85BAE67F778D1E949B445C6FF0812FA338C5F86072645719388D26C92D0B858A8BDC36D58915E1274B967A736180B12070C3BA60DE9B54C18E8B546E68764190D7BBC9F649E2BC5D517C23E2E7F9EB767C1C5198F8AF617567A7A58D1DADC2D9FDCB8BA3812DA59960ADAE0458465724472B44482DC3C4726679D47012FE720F0474BF4AC56DEEDB2171C3D6D14AE1036E25DB6C58D4608A9B154FF3AD0A1D1797DA10DACAA5B83C56CA97E94BB762F8646E6AC9F26E7D7CF23FCD0BBC15D5211060C753A9AFF7B9596CF8C7F4BF96092053FC4D95521F5FC7D102C22CE64F9133CC63CA04FFF1B7EFCB1AE95B3803C1F9CE8255FD1141BF836C84CAB3C35A4EE8A7958B1BF167C240FDF97B56C9C695D72C9EFDD08D2C9217ED44BD68DBFAACD62C6353DDD58A68E86AC342130DC8D34531BCEC39328A8B1D692F0BD21E16A4BD2BB07B56A0369600EE79B996A9BB204814922165E2A44C6CD588AD02D981EA4011F943AC2D1B812F80FF7620F978A8A6E12491FB7EFC9039FA62491C9238741087D328B19588E2525BA1585C8AEBBE03F33A19789C86492B922B24578E59AEE4352BCA20ED7922C35A7CB6AD426E2571FA40AD64D110504CF6561F7F1C55DE1FB92C104DD283A4C718A40780AC00900CD85BA2202BA76298832576AF4968910867E10234C135F1019AE0EECC09E8FCEDEBDC788EA05A879E23A6B63695F33E1BE4126DD93EE48B55E2876249600C507E7979925AEFB76D9CA826B1EE5FCA3B007FFC492AEBA1E59BD2E0B121E88E8C76BA56684823EF6DA3B0F64C9C26892CE77DFFF2E27B4E38F99E78A1DBE6CD176757F62AFA118202CAE71D004F522636AE9660708F3C7E176FE1525C8F98F9511B053D350020CDADE454536089203EC479F4E321DA667890E14186C770C323AB0263656F6CEAC7189B192D9567C01D0DD938FDC5166C72032432865D405E04FA98AD3FE6A248954C5F9559DEB9C6B9895E6D3EEF362C9B0FBE0B0BD1C1A01DD6FD986A79F564D6145EA64065ED4957A041A7175AC481071DC86D6EEE869E10C7F0B82436496C5A8B4DB9D40BB193C9A55C503CF2549AF15695A9BA00AD2A55F501E21229A0504D2651DCF7BE4A9C2CD15EDCFB5692588ACF5C2081C1911C2239042487C0E40F98DCD999BC8194147791FA715B5566C84F6FCB2131364FE792C8FDA6DB249AC34DE79018374DF292E4A593BCBC65496A7970D5E66A5BC9B8BD1A5F1CCA115C4521CAE1574336F65AF8C1D0CF339846E231667B17D186B8F5437940433692D3F9D70FFC8AF3C50E664C255E49C88F4EC827739FC7D7ABD0B3CD8C6A40D8897B050257E69723F5675798CBEC12FB8A275EEC2FABF17BB0CD29F771E5103FDB228AD2D1EA98E600915A5093B924BC4878990A2FFB12F795EB1DC456A3C03D96CCFAB65806D19A0BB22233CA339781FB273C5C105A482953497866C1642124212EEBABDA164EA93F1002FBDCF32A297924B04960EF41604FE56EB2AC52BD83D4DE823888EE3AC8618479B2893B6F422CB509C0394E49F223DA565D84DAD1F8D76815872C30F47E0C7305F7BA6A2CB2D7D11529A9683C5712FB38290EE07ECC853B8FC89D617DBB03F6E20D238A4314C79AE2CC59F8CA674F126992F2C5154FAD488E0A634573F430B844675A54E5756616390E4686B178D02889CB2CCB87BE5E55AB615BDD7BA18FA1E33E17B25CB7D12E3BB82C490BDC6F1F4B3F5EF77DF6437776A169F7F3F75754FC695CD977058E5EA99C0F8E7DC102167A1C7308E4DD49FF08FDF4FEE596B36415BB1B4B35B40184DE7C9987EFE2CF6BE609998EF64C265713A713DD2757FE766B36C2EC8AE036E610934F5086B8C03A737D9867F80F137388C919E0C3FCECFA303FE33F4CCC21269F011FE617D467818B9E3D69CC21265F009FF457D765FB15FF61620E31F90AF530914BA13D8AA7E1E21978BC724B1A7DBC722CC5743549D01ECF237A62D99518016AA5DCF1146FA230EE7E9813EB64E52177CFA1ACDBEF8E529CD66B407C074F2E59304D1CC712C8202D6810332F7724BACEAF04824E2384FAA80A1CE0C737BEA33FC43A06F1475EB0844BB310C4B674532D0FD10F3780EC2C6EC7A3E07284BBFBCE056471264F067B3E7B7799DB13FB402F86F2B42DB56F39C529FEC940457D229789E627B85DAC5DC575CAD29553FAF76FCEDB1221833D76E1897635518D3C5A6589CAB9003C640827EE24110D8B282BAB9A9D21EA74FECF06CBDD7CDBCECBE5196D19635129D2E9BD65211FA7A598C5EDCBCACF6E504FBEF7A60B3DD9CC086017F13416D7391E359AF285F8E0AB276B4295E79B32EFCDE96393C7A0861E0FFE76FFE464A9A6FC47EDA83E3BF99C8120A4F11C5F25B4C7B9FF92426C9267EB6F6EA73DE7CAD99D5116F16730DB2287CB8E1384E0F0B5F0B85B8E468EE4507CDB2AC360CAD652020124196C915CF30CEA48B8A906358BC53A81715DF76A58E2200B8722948AE8BA83B06691BC3BE3CA9D75978BE372C8BDF4646E7CB63A92E9CDBD8AD79CFFBEE230960388FD5FF8267AEA6B596CC71E90ED6391429D273A1B522F037E303B0AEB5DAD15B74F7BBBC4314C4F1BF21140BB2952003705885F00C6462DEA19BABEC0499217907E8A7EBE39266FC0A84C78B294C8521A6029458B6277D7A337E70B6665233530ACAC230D46E566114E7EA90D875298A6310606C9A0C226B40FC3E5DB976FDCF2932F178BC597AE5967F01F38CC3125C56C91E48384C6100BCAF138DDA73C411CC073863E42F7C94F1623589C806500DBFD40AC617776FED5F11C5EAF3DE1CA0AE957FE5CBC0610B8DA315920884FEC6372E5B4F1204370CAB6CF109C52CC33842FCE084EF9C202E181BFFA499A579EBD5B2D9E790C2D2AB483400B0EED20E0624437C8975D0CF21578902C8DEEFEE5DA4F3C16FC9333B71413CB93D806927FE723D4C87A20EBC1DA7A703957DAED00E99D9D14BD1D486701282ADA105347FDED30E94BA62FD9FA4BAEBF789BAF595D3AA65F74E7E283FEAAEB830DFAB2CD8347833EEE6181D949F82EEE348AD76ECA7E1A3956B5BB65E1EA45182CABD849D04C925FFC984F57F291248E4897B1D3A99393E467FF25FD1EADBC79B5FE921550B63E831B3E7B7585BA8924C9F53DC7871C8BF7C55E7935FFD212294A967ECA0228BCF3E592C53C005B4E0F3C49D94A08C8146C8600F59FDC353269D103D2A29B83A82DF46735C467AA395BC283081133775A58CE15C39D5E6263F8D32D3CC526B8261E1F13DC9DF98A9D3F739DD7D8B5DAA4CE7FEC5A1653E7497615C5552770EFE28508A4400F507E79F9F14CBDDFB6F1114D45D6D140788B652DC0EE5FCA2704FE7AED3C8043B121829C008EC46CAFE34605EE993709C6CAD9ECFEE5A55213CC2E714966A909DD396FBE382B43EE2AFA118202CAE71D004FF282796FAB25181C0495DE309C29F0F72396ED3CFAF110454E36E4B9E7E5469FF887DCDEE09C98468EB81335212EE5F2B13C4B2EBFD4CE99BEB9B4BE6CC759DDDDD286302132FD24C9181A26A71728C1587A98D8ACD876EA22FA76B3BF34DB8AEC7E2CA9B86BB6663F98A317F57C95460040BF85E348F0BE895E75CADED526F86B1860C036F6CED93EB955B2E4D59C76BBFAC39177179D41807C8600F90201F2D511E452C8B82A77B7134FE17B5463EE7BDA81F898CA526D782552737CBCAAA185DD9C5D8F36C8CF51309347B0E28EF2982E7107900663B77BEFCB9F4D8595C4EC76EDD96176BBF5EC30BB53B5EC30BB33B3EC30FF0301F33F1130FF8C80F917044CB9131714F489F901F4872431A13F248909FD21494CE80F4962427F481213FA439298D01F92C484FE902426F48794AD79E80F29587A2EE4455CEE94C52DA8C9B2EA33B1B1712446756BA55509B2691477D7CA302F747851AD7F6C55C744D880972B27973939F94ED5C917F3999F4ACA2C0B80DCB2C4D6E3A7C1B172FFB5E0E0FA02B3E227CE3BB8373B6CD1EC828D733F7F4CEE15904ABC2BFE0C0A57141507F00D42C4DFDC833E241F4F563E2E1EF85228FDCB28145F9CED09B80A8A9D6CD4A11C429444CAF336590EF49E5671CC43CF6EFB7871ADD53BA95C8B99EF560CD39F6F622C330AE4A1E7C95A48A56284EB285EB06EF26C53A53F077F5C2F9EA39E64286362BE5AFBE12BEAE9248F3C2BAA823AC67912BD8088DAB1242293323E55655C7CECBFF849B6FFC441D617102E22BF02B103C9EF789E0C893212212442B6D51AAF399FC9E4423B1952C7B013222A062E932F0FA6EA494337F75F96C020AFBF7C2EFD494FE6E91A77DB3D6C5090E2FDCCFA8E4EB22805F40A7EEFF79EB75AB25E766F81FC2D9DFBA1EFF9DB1383A190A5D52811C11FEF90FD33F6B8DDB1417B5CF08A539D057F9CCFC488A377BF52FE1C0AF74A165CF1BD1E3BD26219F76EA6B1001DB645C90278C01E250BD4EBED49567029722F38EB4B00637DC75B68F04F790B0DFE35FFC2842DBD62C1E33C5A2E2BD587A1F0E5F939B573EDA180FF2E268DA03D8A6C607058A14413C9767FF5D3F9F9BB101AE2B9A3CCBF788FE7E0A2AE760BDF59EC7384D9A7ECE525C17AB519F8DFC2E84720C34DE02B3D7C0956C2E6AE96CB87D3B98B97284EE505F0D2DB4B1B0FDCC6BB26611ADF8E2D4C4D5CD8825C4641C03DC95C9DEA8548A85B2E1F7438F3938A7CB4053B5F2E398BAB27BCD820C9457CFE2C9E54E3383A3885F3BA0AC4278E279FAE2370FBE7563C8A77614176EF7EB54BD8CF4E809B7DC9B62183E3FF335AC59759B974BCA9B3DAA700062F1E3792C65443887B4C0620C7DF893AFEAED83AABA569E3F02BAFB571F455AF3D84503DE82926E5CD431D9221F092EC2556169B791001F94C4839C147314FBE008ABABA9F79922340BD050105787FF5BBB37AA300474A894733097F619589209CC02DB74866CBC3E424DBE112AE74F0678588ADE45C0DC14ADA2908BB096A389E8D55CE5A1374B02CA50E589E0AE8DE9C777BF3C512142C104B000CB004722D91DD5ED607A00827D1CDD3A19BB1FF6E2984B32BAD84EFE64A64A19B8D8351352F47368DFD0E33FC06446A8D3304C55BE3323B87F705D58D912946D91196B33B8C64AC47CB149FED826D3DD9A91FAEC943422A6BA72AEB9BA064D19AF3BCE69A8DEAAA23D8A8301501579595E3B9DBC4051086562CB19FFC742B725C2689A260AF78E2BF8628294675DD6D7964BA85A21E08BD60F1DB1872948679BF2C0880093031009B0353AACA5F203DFB218BD77B2B7179EB87FE62B5287771A2B9C4C4C2D8C93897F18DBFF0F1F0A7DE1C778073CFCB77FC628E20EE02D1F9E94E4CAFF892C569F534057D4167F3020C19D9A07D05449EDDC9738505C95E1716DD8072A1D31AA8CA1300F70F6D47437112D9114D0332D75775DDA2B433D9E5245A1C458B8B2C71111EBBB3C2C97826E3998C67329EC97826E3998CE7C3309E810A0415670755C3D774580991E4C124F95A08FDD0F359300913D1B5B2ADD4A5C3B121CF6D388866B76E480C46AD1BA797145B1C1B38841BDA9CB244A6384919572933E5B11FCD9C044C0EE1245BB610C8095F90153E36B3774DD5DC006529D5B073FB16C2AC47F1A727EC3A31C37495B8DC2C892D125BD662EB171E2CED9251F32B6D84D4F64A5CD9948F83C173726414779F7132AAAD9FCEB69033659F1E83FB6CD8B12BD9774AD9A7A4A3F6ABA3A2551CAC1F59C0132B45B5BDDC4A5BD52F47A6D302E67F9CDFC7A3F831F07A197C9829DE59A6E693BEE3E9F902CFB72B77415F561DEC748C3209B63F9808B664294B82845C6EA6CF7DDC573C15BCC24ECEB5A25989BD4E3464E29EC8EDA402D4FDE095C62D603823B76354D71C1473DFA2570FA8822A919F977904DFA24612ED74255AFEE55A0AB0ED676F21AFDA640682CF134236E53028699019B2735A530EB3032F87D599C74B2EBDB13DC5CBCCBFB60DEED0534FCEAC2AAFC952B539ED8596BD781B8F6FF9CCF7B6B13DA35531CCA522D3E8643441E2BA2C8E414E2AF3B531C847650DDBEDA232871DAD5F49534BD80A07CE05F74B942CFD9405D79C5FB18D44813FBB7B3BCC9DFF3A474CCC8AC26415A44C1EAD847B4BF59170EF2A2BCC2846411FE013DA085396C9B75B9ECEABD159AB1A40D9718ACE2C24BB6720AC82188D2BE972440597C80B4EA6958B69254C175FA669DAD956C5D596C655E56A5CEBAA75203B1C0CFBAA807636B00A9C915A58F2A3B87FB9F0E374EEFC6D548EADB1F290AF583CF3597F8CC066134C815DB070A4F8F3699B22FD27A8009A37CE3AA1F7FC1473D0BEE3536C9255891A1135226A54D09387285A5C332F3F6EC58E1F55212C495213029729758F669ADF5A00A16C0B28B087BA546DF80EC9B2F64743B2EC6065995B3E80060940B2ED2C0F60D0A01698EE6905E3113624284E5B503848060751B09B6F1FE463C720341217C56B2381ABC14FB0621A529222464E066CC8B488938F48CC66CB1132B041149124BF09FFF9DF5EF3B2EB864DB4CA36B3C64EB56CAEB7D42FB5EB71954CC750B64818EAC63827C946F5988BA4C18B6A12BE9FBFF2F39005EBC44FE4EE8407BE8CE2F44942DBACB24E409B65D70B58F988C1035E71345B79E964E6B8040B1CB0036A0A3C1DCFB13BCC605367C6F956B75060777B295EE66B14AF9DE7560281CDEC71F50C36B90A16C6FCCE20277806F76EA3A47EE030FCC97E3C3B10117790A72865C174259F43C2FFBECD7CB53A654B6215B3768492D2F2932BC0992BC06757802FAE005FC98D43647E8362CF8D60089194C4EE2C682BCF71EA52C5D1A2BA59D54E92B922D0B777BADFDE85B8694933ECBEB9E26A4B8BA37235AE993B223F5A59CD316E5A55E6A9C690A7BB766F9531DF58095A16EBC60FDDEBB69456A6735A65BB95E9B8BDA8C3DE74DDD3B55A2E03DFB814D0B00342526FDEB37CCC272C240398F173218C857F84BEFB9BBF8CC277F1E735CBF677621939DF3E967EBCEEFB6E86DC78C5AC812FFDC002167A1C7308A104BC3734F4FB60866F15E38F206E6327A6F74E06915FE9FDCB2D67C92A763F76B086062CAA6BD8600EC2499249531C07B410836F3CDDD8363CE09EE05625A949E4A9E3D624B017D99A200E42C6258F30BCAF44B18C600CE20F1ED84A947691330FB15F9DDF59B0E20F2C7CB5B74BF47020EBB00E879C052287915E02BCCC0539C253848CBF36D9CF0EB170C0E4591D127801ED46829DE4221A2A1F1D2D959D4BCA323A64B9B8379134BB855CBD1C77D18AC12A015367DBAD23E8E75CA1AAC0365C065079655685FEEFA2F0DB8780129F559683E0908645A95CE48176D1E095E377EC445A5D4C5808B52E39037F006857E686FBF99F25FA210923921F243FECE5472563C6528054138CEC244803019D19B50F069B0FE59CB8B98527814402E9E404D299BB443A731749673B91499D3210380B12502E9D916022C1741A82293FEAF52E4AF915B735B66A18B64EA4260672F64F2C87024F7179E01EF7972930EAF902F5C4E2226E8F860F132C03F99E648C76FBD2ED9C86C9DC07280B592D5C6F7D3BBF85AE1950997031793176B2E5176E75F86313C359B61418245B48B6906C81952D46EE5D26778D67B13B4BF7EE06C0D6BD5B03A8BC32F8C3AB36B7DAF5E19A1F248FBB35352F3BCF79A61F98677B3CB81EC9F29DB520E10AF37250F7B21B24BE01E8C7916B0010C97DE527DE746B2F82BF34898F79849C3BABBD8C6FFC858F37C3A937C71DE0DCF372D28A39C2749B560A9FE50C446526C9E33AF470CC939FFD97F47BB4F2E63CBE88A2B74BFB2D4F1A244B1DD782844850EA8366AE403751BA79969DE9D5E6FE53898BE19795B862D9BFF8DDD588BF98AAE6CA53CD92FBD0BEB5CA4042EC7B621D544A32818F26EEC51782692D86F2A399CB4229E6EC9AC2F798B238F5C35747DB6B15C7E2C93D8ABB62811B548E91AF1BA7DC44F11A6B47A9EEABEEAADC2D35BB0F5DA6412186D30D3134D58BBB92DD6829370DAB5376D0EAB5391C86666C8E41D14B122D27275A6E59223E5577D992E3B80B972D0E7A9645BFD1B06F9B6044C5168A9B320ACF9801E7FC0F608E18560914393D52EB06C69828E6EB4CDE412C806232F555E9B413B48608F2A45C6DC07246294B57890BD0530423651EA360068704E54D9358451C42957F76750E0562BD9086EDBC7E73AEE622514078CB039F71BEE0402FB044837A89251EEC8B2C51DD5F6689E4FE424B2490972A0B2964A5A5A6B1980BAFD4E4A4ED6DBDC864B660992D65E9D2FC281777F3A58EE76EC6A878B8E68CC1D04E464D09FE0B673300A13C220307B60ADC788AB50D33AF0D41EF568B671E4B318C994651CC19395903884B4F92A6F0B3516FE5FA71A7E4A42849512A021B4E516E15008CA26C53283B5094C7A7CB0EB232EA99F15709AA6CCBC29E0087C58B7F8B451EF91E8791177EB294C5EC40C02AEB1F59AFEED60329D45D9220DF91CCE09303EC68981D3CB5FB54FA5BC597F8CA13B4419ED847FEC43EE10F71863FC467FC21BEE00FF1157F08B411EE38F627986791E226ABE663B8E7835DCEF9EF2B8E3CD76C0CF7B9567482E3493138891582F5F298875EDF363473AE526505F044A8600808B35E4B82F5C4E3851B072C80DC57D0150FFC771ECB3CCAA4AFEEABF9FBAFA3DF4D2E7BE3DDC6437CE773DF0BFAF739DAAFDD0D2D0661EF0AAC33410672B890AB845C257A1C4757C97D3CE3317460A1020AE7346980EEDC73D2393E489C211BE1F81C34146CA060835BB0A1FC4028D8401A749C1A143AE2D05005801A748FB107D26F14382881BE7D2CB34359406635ECEC2B13DB7D444E000A62501083821814C4A0200605312888B1BB2006796EC9EE1CA3DD590E54D4C10571DCAA98EE56A71E736746E790E19D1C7ED501C8A8ED4621A7EDC1386DA1763792FA24F53976F509E5B5D5AB0238F5B9079FED716B37CA1937FF4ACB152161DCEEF7683D9A276B2B1F4C3A968208FE28883F117F3A3AFEF4373F158B31BC60B664690B60C98CEA00957B84E640DB81300E10DBA2CBBF0D16D530E376793E9BC53C4980659AF8E617D3284EC7A7D2A8CA06093617C17613AD59201A9D8FB050812C059D1E08D7EEBB5C2569B48030F10A2057D6627E10C62058646B631A897B458CCA8FE6200C48B3723C472295B745076C6CD6F243F50D8FF00C0F16CFC0CF5093A0AEF2AB14E28E3093E4E7953FBB0C9858818EC5C8CC8EC86897EC86B5A9873CF0BBC9253009119AB96759F4619A7008B9CBF1573FE18FE23B489EF8C2B678B98263C920B438B8046290BE367E8DD8597B3CF162316B5FDD5A69551ED1421D9A2CB322A174239EEC165903C5728969507017D8050BDF008A956C668D61DB57E0518C7BD4C3FCA6517219852FFEEB2A660E665013C6767D69607017181833BE8BCEDC79E85DF41902E40B04C857579296C5108D400C17AE4CD6F74316E4693E89FDD26D00D92F5E0DD0212CDF72DA13A794D1C914469D5EDC9DDF7E0381927EAEED3D39414D7FBD02C1F96B1C06E2B5CF41C0C88379BA1ECC692CE8FE0D7FE7C18D9FA4B6B2AF06622BF7141064AFE5F1E593D49EA23BDF8DA3D9CA730F9A6FA794FD0BCD20A3600E89421851E82C069D4520BEF8DB8E8562CC6ED07B6DD94F3FD1517124408E4380640AF33C49F842E0594B911A8AB5285150B0E509145BC870FA03053642A9E799B8E1ED60CA32DA6930C4208BB47913498A7BDA9AE696E4A0BB1AAF925A0B3E94BC97FB975BCE9255ECBEBC481D913A025047DF3E521ECE84882FC677534B4D3437F5A443C35553CD110DC9EF9065D21CC2309A333056C8AAD90140339F3279403D30E824390F82D24F92B808B349F2C07F5FF9319DAC4662B5F3CBD88758CD4913A86CCD206105EC06F2308C01134DE10CDDF26C48BC9078D99F7801142B80E264476204F1F3CFEE40BE4DE0D59653282C74122E245C0084CB8D1FBEB9C91489E0264A4A84C3202295491BBAF90C7C70121DC15824A14142034068E4C58E2EFC20F0C3D7D29E9789E26E92A415D64DBC74C2E2CA9CC6A000291D953BDA537C65C8B21EB2E7D91AF50C187653C941827FC204479DF9671C4D641AB41FB44F47FCF73E2C369840FB43F992C52948898F4B21045EA3D8DDC2785C3D63609D017A3E248CB3786A2DAD607C8F40B5E161A37053E6BD3DFAFF42A27C9345A5A290407EF64316AFADB278651055A89D5B9ECEB7357BA18895C0C64DDECB0E77C01DE2FC5D68F8578E1A6C7EE499EEC7BD915FE751C0137131EE30B77EE82F560BDC41AEFD0F41848B02F878B7C23EE4ADEC6A9C1D3EB2297E5DB2C6C3DBC1880FF9592F792E26F22098F920C510D35A197584BCE7732FF5DF9DECFB4972210F457583100D8BA8BA1FD67226AB701638DECD75CCF92449568E3057315B5716BAD5C16139C40EBE9A49921F64E376CB975198F8AFE1A29208600B248485BCC2F1155C3E3A3D7E4FB37DCE78124FECC3ED2E1E850860811BC65D147EFB10642E7CE5008FD5D92558126358BA7DCB62711D3E75421E27D3D13F4FD1F0CB33D16EF8EC15C064CA6A3D006191AB985CC599AB12C22F0CE104DE59940923019C9CAA27EB541DB43E6CBDAAC30406B955C9AD3A1AB7AA51C09FFCAAE45725BF2AF955C9AF4A7E55F2AB72F2AB925F95FCAA7A0CF2AB925FF500FCAAD9D1EDC0F3CB302127895398855CCA27EA522E9D1736AEE4AAE3C3D485DCEE3481761D97236114612AB19FFC74ABD65C7C48281ECCCD2CD76ED5EE05C14A9927CDA8240A4D673A480AC91D6806AB5CE376CF33C38B5396FA1CE4C613ACC377BBC82DEEBF0EDFED24B7877F12046A398F42706776817F1B3DFB8109B8C1DCAFB7741608F8DB421ED00EFCA41FF852BC41693549F316E353698C30B9743C4F41C792D71C65EA82C08B29C7EB411FA94DA67A0DBEFB237586EFFE48EDE16D3E52137C948FB40487FF4A3774012EEAB083C356EBB63310FA344A52D65F52D2E26054F631B9FAE4A27D05C25D041D95CEA675E63C2DE8787636ADCFCED3828E8467D3FAE23CAD2F18D3FAEA3CADAFF0D37AE0AF7E92E6A75880EBD0263E82362D0E35A9074F2DCDF6999FDEF88B6D014470E7CFE59CFFBEE2BB18A31EB970388C461EB9E0EC0F110FD67D42433C3F16EB270FE75FAC123F147CA66A23B6E8155BE53D2B86EA3BFCD6183F0B555DFAB107638367BE30C7A2F580CE43202C2981FBCEE2B3A97CF08F651031C772711741E4BD391FA0B74A9659059B7D8717C8977AE2BED46C01B838543712C8D6ABAA1361587ED56C2C4373C47C805EEA64E1AFA21AF724424626426E5E1397884CE5721BF1D1B89CE2321497D9435C06372CE38A0EEDF0A5A08C069882322D2358056506EE44A1A84C2F3C4565282AD3F261525486A232DDD3A2A8CCF069515486A2325D0F96A2321495A1A84C1B2A4565C8A54A2ED5AD5373EA5A34A58961E95C5530703DACD3432B9A72B8D54DA65480E4040A9074C6470CB1A8D80715FBD00E41C53E0C690E15FBB01C878A7D50B18FCA10532AF66134132AF661B90EA8D887FAF88FA7D887BBAB269BC77B4537D980E47ED96EAFE6571BC73ED50E691D876A878CBB7608F9404FD4075A9356360E5045DC997A3F7BE425B4EBB3361C4686696D805EB71F25A79314397C2952717F96038F2D49DD32B86C28210C32402EA320E09E906E9F10D34CB6835C716915B1AA758B36D6D0543DAB2CD7FA509BBC4BFCA1005DDD4DECB35D2C81B3A14BC0FD599DED6E059CED6E059C01AE8049986601144169B2CD1928424019042985BB6D1CE85CEEB671A093BA9571F0D65873281449A00CB2A37570B6A37570B6A37580286BAE38CBE26E354FBB2577F92767F1FD4B992128D8F8424AE2AA43D406F52EBA7FF9B65806D19AF3C415E8967973393BA784CF8D47FAFEE5D75F9E5CA026A1172DF813FBB8F603F8779B1B6C17EBC209245EF336B7023AB7B21CEBDCCB625D78034D92EF2CAD264B5F464B27CF7D079CA3AA4DA62C4996519C4EE7511A252E93D423B9CEEFF2EAEA52340873CF63AEE1A71A161459492E84ED38039B63030D6C96927586DCE35791B7CA999BDB92ECC2739DEB8DEF49A9FC144D167241B94CB305CA7986EC19EC8DD7B0E056E5C3A5EB2B6E40B8CEE84ACA2FFF7925AC85FB1FA1741FB84DAF0BCF75AE7FBF047BBD5528B0B7FB78F33879BCCF804126A9E081CD943CA7E439B5F49C42B84D71AAAD93C3941CA6E430258729394CC9614A0E53729892C3941CA6E430258729394CC961DAFE3191C3941CA6E430258729394CC9618AE2309D84EFD37CEB79B649F5323B3BF88AA7CC0FAE58E66EB0F0A0F682DAB8560781D6ED16E86477ED147EE16CC6E3B62998EAA92897336E5F603149F7620756754D10CB780CB2640BB2045ED7B20406F9ACEF83197E11853BFE6307951A82D94EAA1C889BD9C93897AB38166F59C80EEF0D6D10D85D8DE2D1407DF25B2884AF7E0B8EF1E17F7B79E15E7A1D470B902F74BA834A0A0F785B3821586129F11CAB01FA557FA5BD2AF278E2E4AFCB55B4BC1E4BE53CA62C5D39CD917838F1F026BB0566E0C0DC7BAFAC9BF836F16DE2DBC4B777CCB7B3DA48E0613AE2AFC45FBB575D2D1BD0BA789173652F38BA5B51E8FA320C560E7122D144A2F5FE59302ADD74FA8210EA6E4F3234AD06F93C60F8B3244D97E236AAAAD9CAC20791F787416881D9C22661567D86968A06EF802938FD23CF6FB8713CBFE1297ABDBB07BE43D260A4C19A7A015877016B2DD257A4AF485FB57C36005A86420CA45B6075CB8D1FBE01E8140903A04B4A18D2217B8A3D141F5C7973DD51028BF803A60B993220492C8288C57C5C57A998F7B90AC52D0AAE4C84122074C0951118509D0025DE683B214DA8CF363A2677D78038F2E5CE67A6C8265BA8680505B5126A7B0D83B55236C659E17C5B3CF3C04FE6BA9D765680D73E0CCE2F7C7B648F1350AE8C40A06EC567AC3B99DE0AEC8E7B3051AB4292ABD6A71D5A2ED5AF055D9095E821201FE7D1120648737E9E1D50C0F93B0CD413FFB07C501644233FFDE52E82C8EFAA63B9910E156B27D4A36FD87D32F9E33318A1D2194048236C5E4E7EDE559FD1617486EDC6070AE2AA85F75A96DF4EAFE0DAB19771488AD4175BF3970CEBC332AC378B1444D3C1E8B89D6B37D26B6D531997231447728D55D1C1EA8F12CD5D7FC06922D21987A933643EF82D4B52D7CC870A90A3E6A80351A46A4F023A7B0F867B648603A305A9F07786EC64BBC64E4E81DFE981DF2B567CA2B8E34CB14FFDA61828A95D77B55B04A6DCB343AA488E8AB781449A775F9A172A6A89EE4D0381832FB20A995089CF27B04F1987CCE327E547CACF59F9C94637A52711DC945D8950B94D24C7A41C01E3C4EE0ABC6C30585903C534C679DD53E6BD0DAA0E434781F7229370C2104ED2837C1985EF3C96AAD74D4CD5B1DC04968AB593B00A40BE62E2C5FED2F4409A3D84B5F3A79B5E33790808F9A746E09F8210E9F53C8CBD070449291C9A5258445276E54953C97910443F4AAF4362AF1D3A40EDD5440F28AEBEA84EA12D7A73B82EA2CDADC1C09148219112BA465D9BDF9A8BD0A078ABBB684032F273700C137F929CAFD2E87CB90C9C0EAFD8CC51E353310E0DB3B8D76D3B68A346D82B0E86F9146EA370C69C1ECF24795AF1C419E4573E0B01609EE6C2547287B98E7D678C47B967C21D65E5FE82F297FCE46F3F31A717ED0EB479D900732A5FB83B54FED2DD71CA170F80B4827871F9EBCF644F15CA5668E47042024180154B0A6C72051ED0EC36EB146C7E1B44A8E7572E7FB827582202CD30FFAAC0A697C301CDADFC52C166570242CD6F05FAE5E67040732B8E15BEE5E93C9AB9D1A249221ADEFDD9D624B11397E741B0F55DB8225563387620DF59B0E20FB2B89593F4CE3D9119189EBB937DE00F72E527D9699EBB19658A5FB8781A89D59EA0C1E38428C5F359066C7DCB93A4F26CA0D02F5932F7798C840EE1309F240FECE52570C498849ED092FCEFA91335273F19F9C96A0E6DF91350B77B0608E972DF0092BBDD1EC5DD934492832447F95D5EACD6FF53D61402921D554820E9D18424F9618F229E2558412A81F577C46D2B24A848505545C0B6BE1BA0A8AA178D0312565D95E8485C198A18C0B27E24B04860ED50604DF34451406935DDA69E0289AA695B322BC92943C9D2FA24CDA1800F8B5BAD1FAA1F11B4D823A94A52758752B552061750B2360AF50249D7CEF2BF24610DA50C643165125A24B4F623B4CE70A4D6198ED8D2541A27B9652FB7DC0BB793E022C1B523C1552EDA2B1F2AB058410412570D4492540E9F2B14B7C2944FF5C419DB9DB7BB4BF429873A5FC8FF92D826B18D2EB6B70E7338C15DC30412DD0A26096F7B14C02809896F12DF5DC824BE51C5F7CF3CFD67F14F20E15D410412DD0D4412DC0EE9783C858A1C0928D8C89100448D1C097C545F8678B410FA46E0EC50E5544623AD435A67475AA790417016C3161048E7D40149E5D8A340E91B586583AA69C8A6219BA60B99B40BAA76A946C0E0544C031548CF685049D9D8A380063F498C9318EF422631BE2B318E22C5518438C97048194E229C443889F08316E14F51CA1CCE7CD7C2C189ED0D1C096C070F0F6E7999E313919344BCBD673FE4B3ED22B02CDCE4CFAEA3F8E7EF2E3824B049606735635DA5B4C47015CD2506AE3CAE0D875A2F58C2CAA6EE012CCEDCC029BA4587F7903C7192272B79D389B528292EB7952295CB910548EB48FBA071050886202BA07B459845D97318F259A260DC7C896D78F783C40F50D57B98B340071E017A667C9B9B4346C191410F17053BE9B504325C8DC38AE2E6D0A66C6208B650D949826CF41C9F1977C7B147B85CC5F2EB71550F050A6ACEC336251C61ED6FC1314471E16C469877098D30EB8A971C45D83CEF66EE67B8933F43983D54425381D3FB00CEACCFA4C5501517AC5FB99D19BFB20B967AF31E8EF0C59C627EFB58FAF11AE2041ACC40126C665B0D0D83B7CBB3831FFD7F812FDA9D9C97F9EB3C0AF8A3B8187718FCD345CFDF852DFBCAE540783A1DF0C4FAEB98F349926C0BEADBB9BC655578292BDC50FEB1BC8998A3F39D1C65E428737794E5A1484777590EE2E834DB82ECC675D6369E4568B540FC85B3D97145564FC44B543F1BDA8D4EBB2FA8E4C255C10C61B3E6120EB84EA3F8602422C0F3CA59B6CB0383E3E9F7B1100198641D135B72244CFCDC1184BA0BF2320A05314DAF9927D406DA28172C60A187FBACD019FC4EEC9DF3F7575413813CC756AFBEC83C2B87431BE8897DE4B7F2097F8833FC213EE30FF1057F88AF071C91807309882984255A892388D2B31FB278FD6F0BF6F1EF7B0D09167472409ACD9955BC8D2CFF13B7FC736BD5D1F2DF9ABC0E967F9BDD8C65F9939DDE86F3D7E8F9326089660BD17119FCE34CDED82597451EE63E9DF3F852BCA8571E1F45663E11D99322B29B210E982AE3780171F2BEA507B6FC9AF31D5B584FA5388EFD89C70BC75D473990903D7E347352DE879364B549A7DC2850103DAFC0BA97D741CBFBDC68FBF03DF211F34A2162DEEE61E6079EAEE2C6A6184B6A4306E7891B9C59680424DE5C4172343D1B48BBB13F3B07B50F3F67B064DBB63EFDF1C4676FF83B0F1C9FAD84E84D8434972D2337DCD1C3AB471002DD4170B21802FD611D470CB42D61D52AC820C1DC3ECE91E671EC26724FF1628A17939B6D2C6E36DAC1069D8538E6F8788B43D24E0D52789CBC15E8DE0A901879C32E77F556EC3A5A4E6E050A99F3B186CCBF7D2CB90725048765819B048740A797555B135FB27BC449D67F0B13FF35947314069C5FA9223ACEB4854A3E017E3AC1F19887644E9D9439859FB5703E131248C0E07D1C5CD27ACC11F06DCE07FEFB8A2742EC5FAC81B9F4150FFC771EAF814A5751D2C521F805CA975E844EBB57947D852CE0540E84525E188947E34AB7B861497ABE4AE751ECFF0B417C4C922D38DC3421B64D92C7E5743D2E7F5F09DDB32D8B6EE96D69A0587A5A3428B85E96DE01CDF3413690E4B469C381CA0581D199E8490D941130B630F44863F03B4987A0103C85E0C96734169F11BE3B6464716D3235C8D4089D02BB1A82ED626AEC2AA04B76010573DB9C7EE0235CAE92345A00AC32F1A5C872A989607249759938BE181881557A660143C6B73C9D4733E7DD5647B8919CF69113BB3E34767D0CFBC80F35E8786071B37147B7F0E27A648F9DAE3DF6C097519C5EF8E1258B6796D6580DC3D2165330702DB123B49CC02A37C0569680A5FB25184FBCD85F56B394A0CEB6D88859B80A18932B8CA3E92AF0B2A11BDEEA78512C7D3365B904C1823FDAD3790686A2308A0E0166661FC99E62EC40EB24C444BF5F1DFA0E78ACE38FDD73C8884F9F329F2ECB355993E96ABD272B26DD52300A9A43576E15F6953FF040CEF03A72CD55363FA2C9E455674E71CBB79C5D6BF98237D7E29A482DC3ECC3D0A2D3ADE974EB9187F1C6BDDB33D3792CDBD5F3E42FDCF1CAD86255F8DBEDDE008A5196402822A2C046B1D64EFDDC71C8C872050BE3296CD111E425A5648E33F4D64CFADCC1B36B0E49F579B6F1C4F210787727F7C11F56EFAE330FFDD47B009DF98CF8102AE8B8CFE10CF2419CE13E8933844771BC0EFF6135BDFA39DF99F12B1B1245F8624E77E18EF9C4742DC3EE0DAAA161381ADAAA9BBA2EDA9D84517E9D470197DC1A7B531976D0E9FC9DC78216A29EB509B9575EC6AF2649B232F08E6A1C0B3C5EF8210B7A24C5278B388CA0BF4BD732DF10D11C7327B25E046C1F916DCD73EFEDFEE5A5B2846D66F25BE8BA0F88A25BA71BDDCA7C204E45022A082EE18F5D1507E81CCC38A09FCF9D36FFB42E6010673FC86E47289BA2C85483A67C05E9BF165741B2D3F1EC83DFD529F2FD568EB9ED0467E43CF2D8EF255716CB07BDDE051D10D2C3E604EF9E1D7802D6D1141CD9899D7BFEFE8A6A1A4EAE269F5CB4E644D85B783BE2266530037388C9A74B96CC2182A902EBCCF561E2EDFDDB3C4CCC212667800FF3B3EBC3C4DBE5B8799898434C3E033E4CBCED98F259E0A27BB8FB49E5D3017CD25F5D972DDEB6D6CDC3C41C62F215EA61EE22BD61923C5EB9D5517FBC7273D23D5EB959AEE27ABC2DF68FE875ABAEC408500BE6C20F0209E0F840C59DC0A0240BE69EA004F5701E5316A720897CDFC219088EBB83FB71EEBF38FBC81FB858BB818B08C81110F24425ECF9ECDD29D8825ECA609288311CA7B8830C2921E9D3C87B7399E83F9672AD6FEB3BDB7F898E81B8DF9C5D9550C9B8C7971E48151BED86A09A32FB4E3B2D83DF40F119D014CF1DE5A3A2669242240650414C0AA9EB718C43EA4EC5301B4165DB90FAAE8A60520CBC13E7540A6082EE6F03DB4706B91DE9386B40C654049208FBA111F66328028953EF64E727D04154D73DA02D6B4A914AE043DEC0AABEE1ED64EFAA49B227073A4C7401CAF10613A50070C18F2EACE0EE1C85D94790998010255C6514605C071E921783BC187A1C632F46A1E15DDC1805848B1FA30281EBC878887EB8A799B3B5BBE447269E459E27626202C41A17B295FBCBB4F919FEDB827DFCBB3129563C427B0EF8D7753B18E9B1A78A2A49B47AD0172C7C9BCC5C1FF25C9EF60DB288CA0C02C7407D5B1281D5336AD9416285F52D2B8C23FF0D029707D1672388A283179272E5F4EECC95E8D4A9D3A9CC0DEDC4A6368E6C6B32D5E20A47090A4D6D4A7799C2EB84DF382A3D8AC7393359500E3E1CA727E84E5887B832CD0BA19CCF66314FB69B58C06AF415C06758C09FA19FC4B785E6B81D2B0DFFC403BE9C47210C5FB88D9EFDA01F6A18555B54E24302E9D90F59BCB69A16448507A1A6177E22ADA1476F2E96B7F3F171A4FB4F56F72F96019F848E6516AA20D60CA009824D02E47890D516F2F953B2491BCE14A8CA01CE992330A1B283DEEB7E1C65AB606B4CECA634C42EB277C0AA65D011F244904E8E203926CD36B9810341DA5DEAAC1C8FE84CEBDA1B77CAEBE1E5028105C2F282374F7D5522CD296271C270E12B854687CC5106CC7FC357F7592AE00E8A07CD40163EC2973AEEB3A089FE9C3AFDB95FA5000EA20D8A1301AAA11CA28B48DC0091AA361C641F915D4EC46178867650848F1C44E4201A056324071131A4B13124000F518D1AB83024F2118D83CE8CDC47448E127294A80394DE92F17B6430FC26F887EC12DF20BEE1C0373C1686F63C23BFDA965F6CAF46E615F94042DABCF81F3DFAC3F47D17D8F20F83BCD561EAF4DC4B85E27349ED2B66E72E2354D2308896592C45B9E6DD96A344705B922502EEB224863A78B1017D52A05C4F115F769EC5DA09987BF73DDCC772062C807991C42C4E9859C8533D2DE5B8B8D45680179722130A310ACA5E1F81DBCB242C36F9E0D836107B0F48429CB0849085B0CF67FFB74AB2F3E6DD62C23A2C5B19D286852C54860D6B1128AE03937FB50D072A5C0CCB82410EE3AB2F81DB8AEEB22F3F867ACC5C1672C71C003D82FEEDC3E3498239C2E33C8A65A949D4C7F4CEE35F633F451D641771FACA18C59B59B14250E38FB879533B1CB3FC48B187C4D9407560A7B1C29D9B7A24674642A7C524E97716ACD01F0AEE20234B3421038E0C384003CE2D65A5CD487137E07696BE4276D618A304FBCD08C97220F0D557364CA1C3763114A635D0B1290C648F19DEE638706460BBBD0177C3D66E459BEE581C6772A5470F1EDD2626624EC49C9C98D3EAF952CCEE358AD767B2B6A990DAA58AFED54FACE366DDA8B66CAA1F159757350675FB521A3704E25FDFE2B91FE253991B4A84B1827F5A91C64922E811F75212D924B2B7F2CF4A64A3486C14817D6CF21A425C63C86A64517D4892DA5DCA12B92649ED22A99FF86299ED701523BFF8B6677A34502C65B1060557F842E5301438BD82CDDCA75120F7CA348BBD5C302AA744E9BD778B23EB0A688C9BBFE24B16A7204594B65008EF7F0B8EF114C0B4FB60D56EFE0406AB758BFB473246119E8209BF717B10EE56BE9159EEF428FAAD729BF2F2EFAFC8B935AFA8275162572141DE689B1180EC14821D1DA98CFAB0BE67B782F9B088B99F2A735F2C0B769845AAF214E8C496C06BC16C797C2B182E9D1F51F4FF291ACC5ECD17EACFFE3B0F614A309CB201947D9ECC932F49023BBDEE2D1478587B48CAA8F9EECECA8C4156D2916462EE24B91A99D7C099B618C611A8790100B65C06102777821D4C98A94CE4632C3E61829F61827FC604FF8209FE1513FC3F30C1FF1313FCCF98E07F41FD887E424397C60DC459C2BFAFDC771354830358F74B412C32851D4DE107BE8C62B76DD10D147BE3B7897232562F88DC02CD28474B63AE9FD46E739FEE27478391D71208C55B9F43A384AFA00F03C7085F15D018F77FD2DE9B538F5D52049B22B814C1D5E2E3784CC9C3392A9B5158E03FE1F9B1B25D8188F872F6788EB27CF6A88EB89FF03C71F9EC513D7D3FE1B9FAF2D9A3BA127FC2F325E6B347F555FE84E7ACCC678FEA0CFD09CF1B9ACF1ED5DBFA139EBB359F3DAA3BF7273C7F6E3EFB43F51767B347C497B347D6B588F872F6C8BA16115FCE1E59D722E2CBD923EB5A447C397B645D8B882F678FAC6B11F1E5EC91752D22BE9C3DB2AE45C497B347D6B588F832070159D722E2CBD923EB5A447C397B645D8B882F678FAC6B11F1E5EC91752D22BE9C3DB2AE45C497B347D6B588F872F6C8BA16115FCE1E59D722E2CBD923EB5A447C999287AC6B11F1BF7DA41B550894392320CFE0213FC3437E8187FC0A0C49295D279CD255A0DF452977CBEA52806C13BBB440B8B95D43C67480A4AAABAD0BFC84AAAE8214DA86CA459A2459F4DE251318ABC6BE401D56B97E601C1E779BF991A42B4C99F7E6F6111EF4B9283B393CE6A00E8F803D2B21CB5441DE90B78BC3C961B4271D934DD41D96BA3B1D73A0A7AA8ED47D57071C10CF1E82F3D7E8F9326089A6380411F6DEA5256180CBFD239D22E0FC7AF14E0D9846C95070F303EFA114F371D0143AA88088CF29101FD9EA48794AD1EE407634DA018BE36437DC29968D775B987F8B83DF54C9396C5E5195AF98BE9B76AE03FD5ECA91302A6D97D8F2AF1E6D399E3ADB24D749AE5B4A8B1BFECEAD624FD9853672627321AE90C886C1901019308907120F27211E5E93722FAB9590D85E6E252AEA97230B8CD704A1B61C86043AC4A3404806910CB29741DB0FD3520AD5BF6C0B39D4251AA0259141C10A0BE96150B182E407C98FA3901F95921C9602A45189C5428274D67241203374B61909241248E3174867EE12E9CC5D2469AA2A21C8243A1E97041309A6310BA65B26F078C8428FFF357A3EFFFFDBFBD6E6C67124C1BF32319FEEEEC3F6B6ABFB6E2FA2F722FC28576BB6AAECB5DCD533FDC5414BB0CC3145AA49CA65CDAF3F800F1100F14682966C444CF494C544662291482432134055A5ABFCE37A93153BE47150C108B1A31133431CD6B4B9F0606F3D455462ED9574AEBCA3922990330E709526BDEA7BAB658F28C4FA1E57B9B8CA8D2D29E0EAE65ED36B69EBA758CDE23A23C3136B7C5DA6789AA5CF08E8ACD90DFA738B2AACFA673B60B336AAF40597EAA1178D1E4D09755CCEE3724E2F58D7ED895DF03D2B831770711FE19D7E8DD7B01037AC3256601C89EBA9DFBBB0AE5A7E4F1ECADB38FB9C91B917920439C03E4FFF858212F07CB6893E52AD5E286D350EF6B4F6911D553FB0A0537400A303D83A1A643F88159CACEC80419D115610E74F88754AD7CF8081E375CD601C16F008CF617B3E1F5F36680165A300AF143AE6300F56A10B542DCA7443945AC37E0CF7981C666EB79368192B1DA2CFB0C762E533E075344DB2D32CEBD61ACF5891189DB397204717DA3D30A5EC1210E271BF3D9FE3FD8483BA0519466C1C3211BBFF639DBCFC4F4726C157F4377201E11457AFBCA7B061BC8E3186246348328624E3F6226E2F84AE2ED8F6C2330869EA8887DF5EC42D800C4F2C2D730A13C69AAD2309E2C5F531AE8FD831ACB6EB0DD80239C2E7B9420AF14DB3441A908E6B645C237DD6487036A788271DFAFA1B97B5B8AC51B61B24AD34C207B7AC4D9D583220ED9E598A6BE69B482D85CFAEC4C4474C7CC494414C19C49441F41D0FCC77EC4A1640FC460697A7CF38C2358DBFA821EBEE2B7688A39F28C373F87EE27BF2B062F947F4E5A22F177DB9E8CB1D9F2F0792DA1AF92BFEBEDCD429ADE872C57416BC670478C8EC5B92A54BACE1D7585D8BA597E8E2154747568E72E879C56F29FAEE77DE6D563553251E9A8B6E8D9B5BD3EDE4CF927AF1F8B520CA94600BE713A852607474713418C33A3A56C4A3BB73346B035428EC2C29E93098339646BD94B6E827FB2BE9CDFC2813B306B2130F1925828E93040F6BBD91F386F3ED6693A5007BBFF8D041F464003C998F2F35CA9778E5EFE8E3FDDFD6E975730D4A3F5F468A7212670622E726E94800D412D944F312CD8BA7795169DF97A4C293ED8EFF41A587E35E3BD82FEC683DF9992B82C1CF3AF5188EC318514C07484853D8C90FC093205AA56895009C9E79938BF95A40046E585C7E86648C6B1293A223FB9A13ECED857C404203508B016C18002E7E723471B17EEEF076757457D3C4B517F611328B5529AE77C7B9DEC1AC74306BDCE4AB5B5CD764AC1C56B16C18CB75A80B1DECFAD163F35F3FE056A2B8661CE79A51178BA73688E3B96C0C883C570E1651D8C5231A68299E661C629E4F33E9D33C5D6FD76189DCA0E64CC467F48CB2D044FE7B9B7433292C1DB6F0109C4A8C20C6D5116275ECD2F8FEE9071A93E7FAC8618A0BE46B2D9050351EC1835E20E8347B35F78A61109310DE9FB84C5FD0F2D37530FC705BB1B8F8C5C50F60F123B194F64023D16EBFE58FC5E5B7008E711D4746DEF465A41FFFDDBEA41536EE35CD31D6B8059CD6A4B319C9570F8DC745E1B816852DE974E55C34DA357735FD54F3C0D65E4AE935764E1D126D05D78F3FBBA2B62CDF9A70BFA77A23C9B7F33DEE00C56B50DBD4033FD91CEE6E5DD07D21D826BD4764A98D46C9C10EB556197FB47F337392FB1FD36A41085CA37281C72D5985F3837A52817BF41585A6D05E42B4F05D1E3A2C37F454019739DA24654D666400DD1F908730C5582CABA2B45D3E6D5007E07ABEBD0FC838853D2CEF2761993F09C03DD44EFFDAE922381BD421960AEECC2ED04981833FC37B3CC76F196C21FC76FE4E3928A59D240EF3FB6391A1396E1C964CF8A8D5E933DECBAE10217414C986CB12A159556DBD8253B30ABB761B622BFCB0FCB6F95C249E97C7C4EC490C94F907CAFC4E1D31483C8366939D33D2D0B38DD10C3D8817E949F519244AF4860F2B1DD9DDAE707E6DF07B9443E2263EC591DF018D714FA3329DACA62116AF003277E357415DF818D975BB98E9FEB6A893AC27178CD06DF2D276E5C7F0244EC293F8109EC44FE149FC7CC41983690F0DBB5CDA71E6BB7D8FDBE6B86DF6BA427EBC5FF4D8364F75697CDCE4EAF0C4DBE25FB3F2614A47333099ABFA1195E778A056A8ACDE82D71CBDCC77E565EE491CB11F1BC6FB0CF3A801898BF6B3B9D9360693CA75B22396FF16956BCFD36D2DA26BEF873D8EA842E968AE910A5734B95FEDF3E7220D5894099130F6CFD1DEA07A5BE6A4BDDF08C70D67DC7036791290642D85C973EBC9619A66FFA924EA9EBB6DD0C6BDAD54FA50A70B4196BCE049C33790D89B2005D691082EACB7916993952D8E2E57333BBE33451A15F871DDA38AF1C464620CF3C430CFEB06618E68737F60AF5DC73467DC7542ED3A41729DDCFECA77D73975D6336E0F63EA1301A73EB14E83653F3FBE6CD002CA0E02BEE0DDC5F941D9837B157C56E17D5495AE72C2E35952A595E782197C7742A586C36786DFCE4E2BEE4CDED5CE247C02FA74892D1075455A80EB0C48BC352485F0DBB71BF4E71655D8EC9FED80DDE90B94A5CFA8DC015DE113F3E7C7B0C5EE07BDCB82A935CAFDA620E0AC7C802B8D42D4901C56E63CC61EDE6FECE1BFB7D80413A3EE95EDE6B038C61C0458C2C61BB404EDF7987B94317C21C3F3CEB2DB31B3FDFA29E729AE4F9926497CA007E15F25A77F8019F898338F39F318993A94C854CC9943E7CC212EC282DBFCC68D6BDCB8E65E0973C176CD67E33A55A23CEE3263925C16490D778CC85792B3FC99DCC55961C7B5123DD2E328521883D587BB01F3F05F50FD582C8F6743F196B2E931CD1D371331CDFD06D3DCC79A8C3EA29DE291A57E0F3D41EBBF630E97DE8E3BE8F7BB831E0ECC3B6E9ED913F70EFB66E9917DE8FD32D555D821BF4119E1F0B2F02D31B2371336433D4FD69B0CCDFC92FC2C12C7211F23091B2969E9C1E5F77BFE63E04586072ABD1FE64EA05834F046D2EDC7F8BAF114C11CB0947EF8ADDC819DE28CBEF0FBF585D965DDD341F2CA25E91C8C300E527467A4BA7764E99F83BFE66E3CBCCEB508D5162D6FD5127578F3B00F7FB5692A70EC90592BC04453F8E5BE89AF4E50AAEA7542E7FD9E2489EECF7B777FAEB6354080688FC5CB0162B01C63880877203A55323C8163444E97BC1D4964289EC78801A218208A01221DE6E82185F1900022448C6BE0E321C518D161B833071E238A819218281913E8A3253122132332D1DF38387FA32E164FA7CB7F6EABBA31825E7119112E57DF43862BB0076246D62158C3228E3E8E0C0F54C806D657D2CD66A3F34DAC0A604381BC043EC59D1CF5E2312481E051AC8F2F0B54552129CC1F8B921CFF092A26ECFDFE5EA675502253C4CA281ADDC86C93CE5087A7B81FA90969F6933434C930458C6021BC69A29A66371C9B3DC4F2261EA7810E4D57F5B724DB06174A582231D81B375F87B9F9F20BF9CA3618FE9BAFC9C2BF718FF426E2C0A011D52686187EE969C874EBCF14A4427AF2A12E3D0E5F5C0A7FA708EC9E9B43F739D9D92C0D82187F5296097D501EEEF0730C3947AFE730BD9EDBF5A60BF235D3C92BE42CC4E5E8F5487185F57A0EC83FB92D7A3CE46F602DFD943EA31C26C90A1422EEF09C538B02D0B2D361D64AD1215DDDCCCDA4B95D8520F61AEE0115F8C26B12903AF9D9A3F3209AF446E23C53846E2FD026296B90233AE778B85645B9F34634DFDE87C07502800CE82ABB73EC69166B0044CD9216F82479B8FBC930F270379361E4E1EE24C3C8C3DD46869187BB870C23FFDF2191FF9F90C8FF2324F2FF1B7412FD7BB874400560487ECBD33FB7408FBEE3DF1ED2704B16C4955871A3FA8E37AA1DF6AF458DFC76A92344AE5B5421A2B0FB53139A1E2863945FAAE0EF28CA0F9294858A0B842AA6C058011F613E7D5E057E67E84DEC8DBBC124824FFAAB46BD35E4A86BE226281CC4B8A729F939B20A25D8829C294E714E710A0566D985BC4AB7311A71DB10B70D7B2C8EDB06AF921EB19BECB96D98AA9827FAF82678DECBEB31B025419D6A1134C0A52D077FAB19F8C8402DBF6FC31939F4BA9918D28CBE09846FD2940EF87925BDF5F5F04704063C941B42D74A00152384BC4ABF48F2EB6DB9292AB7511A9A3B8D10DB3CE0E85094B455383FFEEC83DEB2A0E915178B68E2A389F7321CCEB6BD6BEB6A3226B0E63D9950C682608C96225A8A776129DA5DDF6955A5AB1C2D8788869BED906173B3262A6C41EDCB210587E678762F6A9FD91D2D44B4101E16A2AA4FF3E50D9E5EDFDD6CC2D0DECD0AB0EDC3C6AB3F17BB24AB776005B757D9F23C2997E065045FD1F7207809BF5DDFB5DE951BD7E1B063DE3FE60B8C3784B403613670094F5CCEFDE1C902645EA2E17FB786BF3585D8CC9C6659E712B9AD0002446E4B810451405F90106BB6B44BCF9560BFA4F8229AA3324D328D2572D8471AAC270E588DECA603DE765310BDE2681CC5C8A6338E9DB1218711DDABC3E5E83C0DA5085D5817DA8CAA03D2EB123DA42F6A43E264F5DAD65E73176399D74959A7F9CABB80B93599FE4CB57880D93218840FB663B0573E98D3BCB6FB228BDE83FBFFB3AABD2EDD6F213B5DD4E9B3D74206B1180AAD0E50D1974B48CECF987BD4ECA9E50062CCA7AADF0B32984769CC0FD192BF65330E1484C763F925A96A00AD8DFB85B85F8058629A051F64AB4061F25C58384CD3C4D87BBA80AB8AB21FB635634025B12D4FD1B33D62CF369AED68B629530561B641F6034AF319622B0069AFE1EC22F4D9C1D7C8F2B920353B0CE210B35F6FB26287FC8FA646DB1B6DAFB7EDEDF2663E4697AAE670B5B6D282901066D6E08D69AB9C638842D91EF76D5A67C86B527688C85F9A7890BD738B0766E9793973BA08B01E8432DD5F9B6530C9A857665E35594D0CCDD5C3595A0E0130F7AB4E565E7A768332DC87E1926D271CC9C28B87D3E5B24455F523F0A877684FC2A0FD008CF622ADEA321D4A5A9DF20149BEFC02EF537D5C93A80C2CCE5BEC026D1E8B5C6DDC5CD6F2FB3483467A99A883C20E5579E52AC9D37F99DC6F6F8D7AB1D86E4220FEBD289F5AE5879EA90366E8C93A60869EAF0473888941F0869A1C047790094210C34F12F2DFAB9CB87ED0FB12B8FCC77EFFEF19D22318AE726F6F00F00EB5AE5C1680A9F9A6D85A9F32351AC7F439CDFC2F0EB844EB2443A7CB6D567BE1F90282E5FC31CDB0C1CABD90B42207F533F39C3C345F25E5CE5F21D2FC31C9925FD37CB9FD8ABEFF0325A5CFECB97D4CD2EB225F25990F96DF51953CF920F835F9E725AAEAF4D98F8F9B649DFC2BF12AE2FCFB3AA97CDA5F26CF057952F5F6F9FC31C9739479CDAE0E191EE8EA3AC15FFCE66A87ED2659A645C71D08C22FC92AF9579A232F649FD17205B03FECD19CF82E4E255AA6F5E7741DF022E996C6352AD362E923BA0BBC11C5F6E5D6AB8C638FA4DBA441AF375D0000DBAF85FF023B47F9F2B70D695E7D4B13C6977499B42CBAF9DACB02CCAAF9B6DA903091A75F7396258BA7CF786FEB8BA8D53372C2E1BB2F2AFFF0BB7F02761F4B5A274300076BE97D9AE3157614D834D2CEEB02CF992AD84CFF1818FF4D60FCB3EA065DA4EBB5DFC0A764E40FA8966B569DDEA35D421924B74971835667BBEBABB9975227D523C4CB2E5D7A81E0F08B6D86384638DF6163B6DEE7362CB30846F1B66613177C36CC8BCCCB90920B7BFDAA2EFFC87DCBEF6FD002A51BF8DC74CCAFBEADFCAAD4C6CCB79B2C25E50D78D5BD13FCA6B265E3BEDBA671694A1EA95C9E61C774AEBADF877EA900D899D41B9435EBF2FC31DDCCBCF634612E39808FA3C5BB37A3CD7DC59A962BBCD14CF395E78BB7632C2EA6508C25AC255412B3C445F30F549218FCE2EB4379DB00F4226E7A207C37326FF072F76BA0F788C05E130DFEB40CC0CB19611E5F827D78E5C85E9D9955ED6EDB6758CC92AE46CEC5DB78578A74E35B926D8377232C119087D7A2571BBDDA27F71332627FCEC7AB9DEA640CA40BFA061DA0237994E6C0BCEADBA24EB2F0CB4B43A65B63A62015D2EF543CB803F27E0FB8EA41EE9CE2E5E2D12F3834BF806C346F51B94EF3C42DD0452370F2067804541FA1BD0086962857EA54EAC0601505C49DB04A441243E1D1384C651CAE937439737EA56468ED6216D8D6016D428092890B542DCA74A33DF5F2C161AD9F63C7AB9A6FD76BE417268A86211A062FC370B5AD7D2C43D7DCD53450CDA36D88B621DA8603B20DBB26C0826A37D3D0B776B30C74EBB011C59BE2BB77381EF3CB5A31473C81DFDA3D4B32BAA4173E7F027444B0A9BE54DB6BFBEB29A02EB9842946F62F733D4BB34CB074DA0E191E6A7F2C78DE6B02761FEC07EC2CC99F3C2BE51ED19FFA7BAFCCD664AC9549969D2E9F7D16D31689EE85067B5175CE8845C8D42C059D13C7491409F1BD08B13D52B43CDB794E23FF44C21FDEC67F7C818B0F16EFAA1ED37B88EC9F5F86740589F35203145CFF0131BB61427440E74B66D56F9BAC4896B7C5A7CF308949B252A4F9CA07D92D81F513CF6DBA7812F9732EA15FEF393B7F4C1F6A6F2C787F95EC3EE67EE75D1A4B68EB0ED87AF144C33DDC78D2DCC38FEF9B07DCE15394026CF629EC96ABA1E1E615E4B073DCEEC7EDBE8FA1700F03EE77BF0E0642BC710E641FFCCBD60D3C6D871B1E67D5FC7BBAF19AB9DE450DB492863825FDB0CD97A4895F4413E29672E2109D171BAFD8EA75999200958136D84B0B4BFD52F36288BD8AED1BC725262E3112E316788969CE9E9F61C13E2D8BEF4EEF9B72289C969C318AC001E6245FA1CBB25807B3AE0D85E18E1B70FC71C6BED719DB9EA7223BAA0B442EEE49F285D391722122A7D92B4314706F795988B77D4EE5602DD75739FEFFA4AC894FEAB396F6D8CE714F57855FB6B8C735DFDE07427712DD86688486B96E6A84B6A4C715F2731C78244EC64784243A0F71DEC6792B98B7FB331DAE71250681CB7C1D2108E8247C2E8AA7ED860EC20065DD5AC4B8AB7EC9208284397364F2EE07D0834B0E5863A0215A1E0FCBB329CABA9BDC85D309590E859BF519A108EB2B7CC3CBF5BDDF03414D9E176CAF1327E0BB9D80559D6CF1D25BB793E0BCC89769532AED341525C8DC26A50259D8E9095380D81573C020EBA22940AF560C210D806BF7DA8801C04D3EF721709D1C400168E550C3623E83F767101C2F91641038CD541EC1D4B3F3D50616AAC6F8B9D82E1EC9E31A195A954515EED6DF9CA2E4CFF332AD1641CBE073011177766FD012A170E1997C44C291D5AC2D4F0CCDAE908C9F02E7289C2E74241678CA05A7D1947905A3D24C717A068253289B128E80668423E05A9519DE80A440E6A30ACFEA8884F35C4C430E3D83DE9145549601EFF4CB19F48E2C2EC8F9AB2C1C8F2C7EBF9522F81AE1C9265E16C2CD1B62AC3749401970041C65B049D265B10D683E3802CE6A5F3D065D9AF0A6FEE12138955C48C64326ED8217D21CF0341C994D96CFC4B294E468E67340018BE9F8321D56C8423220725E9453B0CD938290F6349C7394FC18AFF0729221BA202718E76352AE4B60513CDCA759E6EB39753B94E001025F77B931BF250AA85B2312AED6BD397A1CD0B233F8DDE5596E8A34A0C6EF297C2CF349887C4B027AD7237939CA7D1D38149073045C75383097404C2EF322E0C9959C23E0C7665587744F05449CF32FD5E32CFF3509E8375DA04596600D087CE7C94DEBDF2CAFF2D345D8504B9B50D45D5C6B5DFFF36D9ABD4D4BA63D8A3A0F49A84D369247ACC2F525AD92A0044ED7E82528810B749FD641297C1D8F83A3ADF8CA8BDB150F2F55573C23E1393F18BA622B399CF1B4A945FDC174EBA2901EB5A864C7B7DEE43C644E04FD1114FDFCCBFC5BE03D4D2C6E7AA7C54D4D5D42730D89FBB3723C0E970209118EB035124A62B63374CF7D7CCD4386E71AE8393398371A82BF657659221412FFF9B624857F214974372C4E4022B8B0823F1A36CD536C07FA0EDD242FA67D22252181F7D7175D79C1352A17E491E755B8EEF4A402F768BEBD6F9ECFB9085D9B719BBCB45DF9313C8993F0243E8427F15378123F87DB71A3D09A0BF2B420C4C92BB877BEE22EEBDDEFB2DC9F3914ED31DC7759533D711837454A3C7F2BEECFB3A4AA0E645714ECC1BAF04FE2ED2F2EF695E42C7F6EA609F6012B801314A06F3B7617FF7D41F563B1F41BEA29DDE9C064AEEA47549E63155AA17045BD136E0DA22BFDAE5CE93D892377D6FB19D2EC370326A681DF6A0DF1FAE99EC9037E74386E46DEEB660495CFE902CD728F8C0F8BC2692B3246117627D21184CAF8F4ECC7BD8D0C0F54C2E72CA9178F1A436A3F638F248D143E7371FA8C67D80A11424792B79826D732C506092C0313C3B1D1038A1E90B507E4118D1DAFFFCE1ED054B1D88E2090C7D261BBDAD6D10592EA31889331DF6E3619C41D2A1FD79BACD821FF15385814F750A3A5E1D7D7266A12D2930C13E9805B8D217C83AE9CC8EBE1A9E815BC6FAF002F68DE81913D0E0FBF80C17184A191E818C4D848D8D8486FED63FC25C65F62FC25C65FA2A775749E96770086F132DC3DADE30CC1BC41C728464C62C4E45022260D81299CCC189AB1ACFD019F45D11579AFAE08B977FE02D54E2E48D7D6C9F5A0DA86753960D6F7014BF76683D70C01BA13BE1522A765EE586ED3B5BFBE36D8B0C92DEBF9AEAAD11A64125C6645126E219D550DD31FE90B1F1D0703E3001D5C8C0F508C3D4A1895E9108168CD1FDE5BFBB9C3031AE29919F8AA2CFF2725ECDD11BBE5C0792D705E08023FE7C7E9C66BB980D1C97AAF4E16C6B1F7DD9D66178DC06996F10802CE36011D476B7C8DCAD4771F4E7AEE37F5C983BD048B0F8EDBC2170371528AEF5FD23C5D6FD73E56A84394BCF8238A26319A445793D84528F1147F28CA75E26A18C7689CCCA3184DE058385490B647A4BF92D05EA77ADCE42F8DBA5AE36EE28BFD33EC4DB6DC53100DC24FC3E5D43E689A33D0409B00EB59F17B5A21AC6E8BA72FC5737BB5BCC7DC1821F39921426447324FA08A4E3A3CA2E9E6F4B26E874F34C59CF0DD165ED1A9D3E53FBD1C2EA21D7E69F1DC8B7EE2F76A326CBC104C495497C33A210C5FD913E05A34734BDA44CDCE8BFC215D39194FAABD93BDE4DA87359123CBE661D60C567A5B55FB864A32D26ADFC4DE2B6F370D01F8ED309F2E9725AAAA1F83623F098AFD4318ECB778E3B7792C72B5E03F585F8FDFA1BF4C5EC220FEB82675CDB0A9D30EF5EFE81E18F1676C36F30A2D6FA1CB5BCF3016BC2CDDA2971A9B9E4790D5E4D3377FAC96C6FD126FCAB7A5DBB69146E06EDE2904815D60E56AF21A8B051E9372F7193D0FEF53BA05B5BE6CB37AD7DEE5BBA0DE4F742830420F09C6D5A3F2EB1DE62BCDB715E3CABA85C89A02F500899A5B82C2FD9C06D5DC45FDB9E60183C90D253027BAC106E641C3EC146ED3C513F29C8D31141B43B11EA6E4C5CD84BCB8998E97E026E3C5F2711653B4965B0D53B4D7E1AFD4FBF8F0801675FA8CA6A405A2FC583E3FFA9835DCFEC4B3FD07CFF63F79B6FFD9A7FD75892719135C770A67A1E50A22029BA44B2054616A8667D569A3BA312F1A176331B2D08B315A6F2EB05BBD6BF24FF3ED1A6BF9CE69791621725AB06588C26E79C7CEB5C7D3EC8B22CBC89A54847BB7769194CB09C8ACC8A9D0A06F47B68F11072551900B8B2BC004EB98047AC186230FE8E5ACD287BA7B083B6C4FD21AAD97A15F2F21EF8E33145CDF30477558690497C41F20AB445CBFDFF1FA3DCB9FBB186B773DC5C7974D8A174D8F709D16ABEBCAAEC73A49E6D28CB8EDC4797BC78347B77F43DD022EBD54FC956B6DCE12A6AC2DE035313FD9C76E88BA626DD59825B35C1FC0ED16218FE842BFBC17FC65C5A32C6F1110812A7E8B5189E8D5787935FD42482A403F17BB24AB77A77992EDAAB472756914285DFD190DCAA963166FB37410CF86E579522E7DFD338C6256555B4F34849BEB02B7AC3C117D2D72A09E759840B86AA4949FDEA35D7348C2D32D6B380243D706CB0104D6220291D72C4FA0B8EA5181F0D5ABD6B5F73187B80CBFEB65B859D41A95745F77071CEE0B2D8B23ECCA7ACE4E41F8D7ED206F91027B8A314EF438D1FBF371BE73BD43E33BDD29348103837DBFE3948F53FE7D4DF9864AD2E49149BA1DB9170048117A9A0131C2C02E4037C5C0B6C53D42B06D319811F818D8DBB9098C9F39D83DC52D98DF30A6DAEB8A47B2331B2708DCD480A082D2A9AFE9C2892D2BBBD35D7BEA780D208BC1D5B2B018C29A929BE2BB77B205F34BDA7BCFF5E037BC67749C073E3F01B2B6DEA0054A37B572F97728D906CADD025DE8E77FF11BB97A92553AD703F2FE58F0FCD724543FD80FD859923FCDBCC3CA4D011B4456765661C54CB2EC74F9EC93366B9168A4E5A0DE17A85A94E94689F6C421ABDD641E442B98EF5987DF36642496673BCF11F6BFD1D9FFBEC9BDB3E775A3738F856080C0A33DF872627D741A72474AF650B5F51E4A307C10B3FB1695EB344FF8138CD66B4CBB23B21A403BEFAC71D6CFF096FB69597CCF9D5D34168DB39F3646133810A423686B8D495930B9D32FDCF68A50184EED87C10FBA633DA77D50F7BC62B3170BD6ED181A7BC7A1B1EBA2C2925DA635D95D3B179CB058DC4D208F25F07635CCEE08A385897DB7FB23357BD66E07D90A687A6C3F37F178D10B35D40D30C2D891622F648234F4736AC56AD51A163F0776C0033D58CD1B022097CB7FCC97207860C2093015DB50CEABBCD4CC73FEAA8ACE3CD7AE3F6CA228B6AB0C402C9446E2B1C6C488688C88C688688C883E798698623834864363383486430F371C1A6E7B72EEE694D83A8DCD9DD3EEEE2269EEE128F6CD03C761E5B79E2BA694E1221762A6EE0FB512DCEA4B7C3D91ABEFF0F544AEBEC2D71EF9B5D335CF315025C33AC931D0902765BFA2FAEDC499EC872F86990E28CC647F4976B830933652AC0BEADA7A115455AD5FF88945E4E1598C114DE263847CA1C5D757C1C20EE8025DE2569E7D37D9063BACED26576838A09DA3324D74C10007BC705773908B24822D8FA7CFABA0F88FD72B091C0586BDCF84C1A65D8A5C9E3AC99FF19F97D81417653099CC2E663FFA2CF3B38B74782C250077DDD56F2149CC7E848A6D635C27BEC23C092FCC9024662780C2FCE02BCC0FE1851992C4EC03A0307F0A2A8BB0D81B49872431FB0950D23FFBAAEDCFE1851992C4EC672861DED0BE1C38A3D51C4BC327AB35BFF0CB64CE2F3C739817B37007FAE617A1AF5DBDC014A034257040EB70A2338795FD0E12FB6D2E1D5F27FE65DF3D22E0F021D899DF1E91863F87E24498491528787E70D157A864C3595221B22D3C802219A6B8CBEDEEC8B66603A0EAE3CAA23CC32C55065091729BBC040E37CCAADBE14D4B4716AFC33FDD33F37FF2AE2D6A7913352DD0A51EF64724C255C834BC00081922C23AC16DC05069C85B984434D5D500F52865B12E9AAB597CAA526824CE19241E49D8EC11D89331F413F20142F29D5082EFA9F09F0F29147A3B15ECEE7EF13FB4CA2372564511A2C0C94C3D49EB10483CBA3A2EF18C4757E3D1D5433EBADA5FE14FAE24BF4105798AB17938BB2B5270358D1AB4AE86D200ED243520218A2CAE43963E366F6C86F4613B12CCA3EBF0915E7AFF77B06E78B06AC0F037F81F6EBD5B3FF3031C06ED511B944640D6D4C114D4C154D3C552BA584A174BE962299D047B48C76182F85AACD68BD57AB15A2F56EBC56ABD58AD17ABF5820A3356EBC56ABD58AD17ABF562B55EACD6D3E189D57AB15A2F56EBC56A3DB9BAC66A3D11AE58ADA7D2BA7D05D36993D559FA28E01E17C003F77B5C2112F94CFA66A0E4925312A3724A2CC951C5EC52CC2EC5EC52CC2EC5EC52CC2EC5EC52CC2E190833669762762966976276296697627649853C6697627629669762762966976276296697627649AEAE31BB24C215B34B2AAD8BD925FFA4927F2E29A690504C21C514524C21C514524C21C51492B300620A29A690620A29A690620A29A690620A29A690620A29A690620A29A690620A29A690620A29A6905C17FC98425268DD1B4A21A93C46E2AFA5F9CA6BDC08AC9F2A369752C2BC137C9B2E9E44A927178EBCA72B192EDCCE4F7B66355AE3094F7C738D2B6BBD545D278B27AFC936C33BA47C81B2FFBABAF5DAA9D6E87B522E3D370D2D126DACDBE1564B543EA70B748E31055CE9182A8117FFF963FA5003A8F745B2C35EAEFFE26CEB51BA64C56FD2D5635D7926C65B249EB9F10149D8F438D0FBED03E396D7BADAA2B79CBAB6E8FD230AB3EA74B1409557540EAF09C9B6427E28E6C9B32786E606F49D1F8E6F29FAEE87E10265A8F6EA49BC161F90CD63BA169F2C192EC6BC8F80D8DA6F367212C45EFBC755E28C8A33CA7D46E1EE3783EF34ADFAC64E738B6E1CD627DA930AE16CC4E917A79FFFF4BB2ED3E734432BE4B45911A0F19A922C9AB093D3608FE43ADDBD31C58D841843DC4844BB7BF476F74B5261D3E56A6EDBD6AE5676681DD6B88268364CAD09E9B6D6FFB24FDD13B4DD71063A4302172DAFAAEF45B90CC035CC124556953AF535E8849FF324AFCF1FC9438B7CA7DD717ED956A038FD4DFEC7F5262B76080578AD2AAE26EF7835F177E0FD7DF729DD76D52AF6EA3B80CBA25C47E75F88E26D38FF9F935DB11DA5C69D1E048E563B5A6D6C317B2717C07CEF51F9DB7106D5D1187438EF1666EB81AD1EF61B17B58FC58966E29D9A896FE8315D64C8C52C744D5DCC00D534ECB4BF41ABB4AACBF67160F023F65D3742E45D3EE65820C88A65A319F48837AAA802C7DB4982E004C67CB9459916ADC375135F92276856F1BC1FDE2007C2D9EAC179B24916E9701180974B38C74634CD57A0387F47646BE3B36ADCA075523E29A5E770302786D1E3DA68BA369E5655B1489BA5A2C38F37B5F87FA46CF5062D8A7C9166EDE75F51B244E59DECF305AA9334E35DED8FF9F22F3745A645DB77043B750FFFA603FDB2CDEA7493A56422E309F2577ED5BECA5BFDFFCB69B3D36F4E982D92E558B258264B5B7EDB7E1AF1DB83B2FCFEAF111BD8BB402559EB93EC1CEF0BF0CA8DC773EC8AA418F326C9CCE4C93517FA326A14631787486CCF06FFE5026D504E3C1633F985E26FCF0637D23A19FFF2033513B413E42CC99F30A5A24AEB615A503F1A4C86110A5EA504005329FEA8270ADE422BF9580C86AA431A2EDB868F400A3DEE362C2F13296F9A657831287794EAF63F99282EDB7CA41AFCE7C99496ED8394AFE00ACB09C05445D86600CACA7518928F6914F5FC11FDB945EDC9A44157E95F0DD4758C84D70C11C4544A3BEE8C8ABBD0AA2B9084A1D68C5BFA2BB0A0E7C0DC4CA9C637A8DE9639AFC6EDAFC66A4C23112B0A0B31AD1AD39D5171378D1A3392B0521CBA25941A333D07E66622352ED1929C6BA811A5C4FBDF4C549843305291D1F7C9D497EB869CB3E0AACBCBC05455B876006ACBF71994936954F602DDF31ABBFFC94061B9E6BC568C3E4FA5AE5C1FA47C8556565E00861AC235F35755BEC3907C4CA3A89F32AA32655056E667038515A0E19543083295E20AFAA3E42FB4028B8461A83C82A6FE8A2CEA3C343FD328F4DF0AECB3247C9881FED5409DC748786D11414CA5CCE3CEA8B80BADCA0249186ACEB8A5BF220B7A0ECCCD346A7C8589E469BEEA6E251F3499FB60A0CC4254BCC64880A6526961AF343C86566CB1480CB549D8D85FBDC52280E7691A25BF4675BD23973092D0DFA0E2CCCF060A2E40C3AB8E10642AE516F447C95F68C51609C35085044DFD955AD479687E2656E8D9D56F027DC6BFDAA8F31E89545B2888C99579DF19157793A9F220095BCDD9B70454E4A1E7C0DC4CACC6D7C98E5CFF2450E5EE8B8D3A33C8A44AC3414DAED64CC7745C4EA6DEAC546C958A690DA8E6AC140270F53AEA8ED926A76BE45ADF0138283F835AA75D1CF06B4D05A6B7863C4F3D315851396A2283047E9AB0A209C7E3C493E65BB15D3CA252305BBA2F36D3844126D5350E6AF289C1744CC7E5645381958AAD7E31AD01959F954200AEA65177FAFC265A6FB2844EED083E1A28BD1425AF510AC0A9545FDA43035E434F00B9780CB54D8AC07F1AC8C51186B70926437F5BFBDD698912B97E938F8C6E343FF0FACAEBC080807F3BA44132FC184699463D920D0C06F4548E7D57FCE84D39E0FD3F4457FC8D07AE85128D5EF7E5B07541D159C920312DA6D40E03C253AA49E7A97E41F563B194AA090B450F2CF7E5B0D544D159C968312DA6541303C213A8C92D2ACBB42ECA5DE0F5634F87C142FD7AF42BC8D097E35942243CBB8FDBA1D903BB41D9434F69073444A75087A2AACF31AA12DDB5C73CD3D14547D428EE81D971A47E9E6417D41D48E598E87E0BE3820C5D347203F6E0BEDAD4F50A82E804DAC41E1836D028B60133A0FCA737AA595C374D067A7C2C7B220D33213C8196F597C7DC0979771BCD40FAD4B3CAB030FC18C856D9D80C081DDA77C89BE404DAF36BB5B9298AF51DF9CF6542CE13D7720DEA80F770F4308EBEB1A3F9EFFFF66F2A8FA86B2DC218482F787E4D068B6BE3A9277DFF4C28D364EF8CD898407766F933A6929435D9BDDDE1BFCE931AAD8A52B5C4316D98E1E6BE4C6290069E773C2FC3EF41D48FEDAD890A302D3C558FEE1F10ED69F46DBEBDEF19BF9376C26F80C3A91AC53CCF0CF32994C2D90E790FEFAF6C74F740884FAE6D2777AA6E408CF3247A77A260E8249CE6398C3FD50454FF4EC0189846073FA50F75976C6EEFADBC637F3C2B8AA7E6966F850288C0393D10824CA5A0A33E2AB8EB0142A9AA56B4728D1134F557DD71D7A1B9390C3D56E7EE44B0721D91E4F1DE99FA9A270805ED0E43715F3771289E44D3EBAD7CDB0C66DBDFB8027A58F24352C1EB2DB97AB1EA0BBCC41F75055E2A940ACDE1015FC1B8B23D34E035688197523CF67AC62200D57E4E1C61789B7C32F4177E529759C801EC26C518B542D944C0AF3039C6BD35E479C249221095BD328E91804E168168C2F138C1A4996F377850DBC981D95E6E1775EB8EC92743DF8451A0E1C7A9949BE1965766EE6310E5DD77D944017A607F6564BBE64F7B8A1CE4AA62B8BEC33F88A54767032918262148FF3E4D5E92639F67670A65934A4C32E614BC6FBE92EF2008F909B48E3C2A7FF5F00525D5B64416F68D69C78C35F7E5DD583AB6DF26E3CFB4780D9B67C0C06B183E85240F56030FC1FCBDAE063A99C083D1C0BD8B47FDBB671776F59547A244A4256887EF062522C7B796AA47C095838935A9FF873ABAC94289760BD6114D07B504F6F6CDA3964C0B38C581A23DE5E6F2D5F4C56AAFFA2634E52DA8897675B20C41E8F543B8284DB722BD4628C169217AF555A8DD0CAC0BF2D39028DEFFD405724FB3ACF82E7BCC94DF5BD1C804BB2BF6F3847B3E558F646C4AA043056F79F1188642B96620FB43E3F1F7646B621DA73B44C6BCBAD389FD88F5BBE9A0916E7790EF52AFDBBE1FBF4E9F6D777FA7AB75DFA056D35DD4E9350BFBDE349BE9FDDBD06DF6F0C31BD56EF9690D1DF47BD470FB331D07AEE35D58F40D2B78D74313EDDE83BE47D5EE3BFF36F49A3B48F446755B7112450BFE1E75DCE19CCAF1E8F9C9FB50F4D111273DFC3B5775E3235107ACEB7D5F2ED2B71A40A17AA8D37006F4BD2937DDF9E3D7EB6143F176359BE9A34EB739E0F7A6DD6CF78F5FBF3FA1FA1FDD3FDFA876533DD4E93603FADE349BEEFCF1EB75B75B7EBB467BE8A04EAB69C8F7A6D454DF8F5FA7E92DC3DB556CAE973AED1E81BF3715E705F0A6F4FC5DA8B99D96BF77257F333A7E5BD449F676B5BBE99E815E7770EF50A3DB9E1FA12E77C7D1AFCAE5FE7927FE678303DF0234237511814CA6D3E3FE28F90B7D905B240C53E5193705D06841E7A1F999E6D805554882FF32B8459369C39F9398FC16CD81E7D1999FC0E944B6B72683CFB4F03FB361952D34A03DD5319F21F92DED84DF00875335594E9BFF144AE16C871CE81643AE7B20C427D7B6933B553720C67912BD3B5130142A9DEC36FE70B768F2BD8462601A1DFC425AA33CC917E86FC53D06495779E7394ABE7E5C6FB26287B437072991F37AA2829C4A8FF59D35E19A6F114AE7151233D4403906FF19612099405CBEDEB4E943DA4DF764B34734446F6DD2308230619A6B10A78C5830473E636A546254E4204F7B3A8D5E66F86F468B8B18E158E16470D3CD1171F7F49C869F1112D918AB9AB83DC46C90C8220867D34E01826ABBDE0C9DBA137F34592B648D24AA25009C7A168C7A6FC0EB54F340237CBDBA8D10C0CD84B138C2F036ED5CB8417F6E51558FD782EE83C542C0A09229150734B5F233BDD2F03895D2B322B1542AA6319CB2B32280E769D21BD03EBED484D8B267FA5B926DD19DFA6A2DA85BC834CF8B6998949092C08652548598E4CAC03402BB054DDC73179646E3FFAA8A2A481CF23F1B58625DE2500632D9657E9AC4A10C2498623B260EC54D0194DC317168C3CF240F7FEE92ACDE9D27E5F213CA51C9EC3645DFB4AA2D47C8BDD8A9809BE8215169F7F49C865577856C8C744CDEDEFB5952B92C827036DD14986FF13092A46A42129A1D9FDDCBE35A75A71B8B9487FD6EE776B0AC085533ECABEFA23E580C36DD0E48FD6C1E84570CAF9EB3292EA0AEBA9BF5B0149ED30CAD5075B7FF4D7EF96F25BA0191FA7512132AE05DCC0FFD3DCCD5BF62894974620FEDA98FA2FE01D09F48EB3885231F94FA26D852D13F4FA6710A659B44CF6CAE77DE8303689A8392BDF27689E57A7FD5DEB1AA9BF8664529CC1B5640BB5B1327D7C48FB80D76130ABCB2A7D8CBECD8208FB75DA665555F2475728F376023F523ADE6A8EEE04F170BFCBF629BD7376851E4E4A174C6F76FE1294DD035982F1ED13AF9CFBF2EEF0BAC41C97D664064E4179AF1D8EFA48C79EC1BD8F0D8B7D1F37896E44F78948B2AAD55D2138049F811405A71A1928F004CCF85852CD22CC33F973BA524782019073C9C057DA50C78201D7D8BFE6F972BA456030642469901D293257BCEF362BD4EAB0AABAE98300F2321CD8319107F2471F673526790A9C42E8293312100B563443504223803462C86A369A567C188B82DD9AF45A3B32ABA7B1025E13D9429E51B546F4BA57516C129796041ED18D1CB9F853360C4622C4AB44C6BFAF940211B2328191323401B1694433282D2B2603E1C17E85E2F8411908481119C057D950446403AFAE6FDFF94350F1D260B9D6B250494F02184B5E445250F21A0092F5E72B945EB8DB16C5A6073F9B4F07ABEFE56E0499EE83D18119C841B11A81D23AAB112C11930623E529F11F644CACE4316F3C08148C87350A694E74D26FFEB767D2F1381084EC9030B6AC04891E45A8D1801C958E0E12CE8AB146104A4A36FAE025778039BA7F9EA2CC9881FA492820454C28B04DA9A23955C24A0661C99CBE83AD935574E2964C3814838E0A08C29AB64C081A8295BF419D524DB553D927D92B2E72240191722584B5E94B210019AF0E22097D97A5352F55B4A7638581D471CB80D5357BF993134C069991940ED18311A280ACE80118761EA83AE4A2E7A201D0B3D9C057D13DB2181D571636F4DB896462364685F24E0F64C5D97C50255958DC0B826862C72AD9C39B59122D7C48E530799DEA0747DBF2D2BD49E8757B2C8C1EA78E3C02D98EA5E89371A610E56C714076ECF94D16072B0864C990FDF3CC95045688BF9A03E4B4853107A6ACC7EEA21CDD35A1A6594804AB890405B7144F67659A20E3128C0F59CF12D9CB853698D02DC9C3B73DDA11B633E4CE546811A704541EB382A5122A2DEFC2CA4D47CD1601DCA864698874F22ECC357430A5D4D8A944CF75D45AB03D110EC4CFD17543F164B0141EEBB882007A221788BCA32AD0B612C99FA2622447DD60DFFB62EBA723934CB1F0A912A8C40846A3182D2502609AEB35464C7F65F4474F61F4DD0E319B1789451E83E4A8974DF0DE84828C8711B61BD2E2A09E2E68B0C77F351871EEFA8F03EBB4FB5B78753D1F2BCA8EA73ACA0A5685D3368236449DFCC8E593D6B468CE8C996C593D080F51F8444BA6F1ADC54ADEA7032F273B1125093838AE8CBA175E694299BED8584BFD7586622F3AA86179A5B75132B064D19B360C88611E99E95FE282369B847258E698ACACB6DBE90A8FD08424C910332232B5D5699CF0A82668B6A077C8D4A79F25C00A3A04B83E9883F26F90A2D9BF6B31AADB1C724222F8212322002B46061881668B8A001758CD0B03A5EF665072D521117231021FD11949EF226C9457ECEFE8B844EFB518B5EB1ACE9D62F8B85AA51F9AB07796F7800113D1E46BB92485745F57268BC0E9E938C91D8D8F55FC472EB3EEAD037796D621789F32237AC4230216121A4968BF50DDA14657D5EE44BD9FE5A0424E6600CA7DDCD9425CA17C229B0FF24DEC3F45F0D29FC9A56923DC50842456F0F64B84DBB44088FC742E42A8F41549BB5014A43F922D9CDEBA41419D3E19388D2F05547A1586C897195A647790021350E4647B34C9FC5B4BA0F421ADD370DEEFE6628225EE1E2CF038868F13086342F10D917247DF042417C04A9E262046CC88E82BE9AA096C2654AAE044A936C9657F8CB56626BC46022CA6248532EB0BB940AC319230825ED1E4843F657946D84DADB7F1011E9BFE97017DB32DB3581551101FAAB900A0DA023556D888F9523B2A124CEC1702C5B4059012C644401AFE70B9B136C97C56CF4DF2454FBCF7A22D7784289D315F4470999FD773D9D9BA2585F26A426BC162D582308094516C88EAC725C8580064C588C27692627AEA466827EBE4164FACAC44B7D9610A22034D466F9F3E90A9DE649B6ABD26A9E25F7AD93D4E01290D7C08BF8D134B166D0882B53564CE89F25E5A2584AA4B1FF28A1B7FF6E42A77A42F59E3B94A1458D96FB9337926240D38652FE0CDADAF2DEDCFC7143F6BB260CD3D0465CD20DDC59339527DFC2924553090E77138B581ABE4AC80F007A52F45DEF2262F47709391A444F90B97A5944910190906460AC689E68899E98503D311A46BA285D32962C886C4059281BCABF2291EF3806D1526EA00CF429592758D1C53B04EEBB4C9F28103DC1DEAFA792AB62CA4240090B42583D2F9FD287BA2B55382B8AA773E94A210494F02284B5E245162A1642E9B9300B1CB36DA4612331989E09C3B011DBA8BF7C479AD25783EBB9E25B3871272D8550839B7367580A216ECC5CF864C822D3C69C4FA6993BB396F264DA5832EB24D9C6C83CA052790E48DF44CFAAA89533A786521535B1E3D45CA6FF95D6B8718EDD6C315BF477090F34889E6097CCD52E3D2238090322503D2345BA40BFA7156AABD6A4CEAC004CC2860052CF4597CA22917DB90330029270308233A05F54E745FE90AEB6A52CE52284927130023462E196E437B1EB2F0F4C48E0E46C8C400D1829F1087E46CF28FB9C5612E793879131C081D910D71136206A46B0B920F2B4AAD05A1AAC180149497370C6F4F95B2F957C8C81D5FC8CE19DF9EAEE21B560AE6B61C761D7C89A4D73F6ACD8B265E7732A2C1CE301D4C45B18639AAD5BCB55421143AC6444D14ACD9DA2A125CB06FC9931A3A53CDF6E36592AA4387C12511ABE1A5290ED9BB8EF2A5A667BA5E6992369AF98AFC24A011A404F4A376E63100951BB71FB2D4FEBAB872F28A9B6C23A0FEEBB882607622E558541164269A46C6C820DE89B11B7A63C4CAB66256D2B8E5AFFA18DAF2827ACB48D7A064B9BB9336BC7A635836EACB55B123B39B26D8CD9649BB9336BC7A63583B6AC69D7560ACA8015CB55D6C83F33F5CB1CA66477C2BE3050711E54CD0B0F6DCD91112FA65CD8D0AF8B85BCB64C02A7E182063567A433B45A05650135AC30B0C6BC2836D134809AB6F1E6B905274B2CDEF53EA35252EC2B0755F3C1431B71C43C384EEAE5BF53572C4A5853B691F3A86C66C1AC468959201D3B56EA3BEE01A16E23A80EDE46485D137B06CFB6BBBFAB1381EA16864CB28DDCD8D4E548756D2C58B5CBA58A3074D3CD9CD37D030B36F76DDC78D4E680B58D2C78B5CC156B5048F2C7FA566E1C1BE599791C7DE38BD470F2330D0C1965DAD8F33828BA31975C13433EB956F69C7E42F53FD4B15C5503432E9936F63C76F3D1589434BC218774137B06699536E672D4C890D5513B2F7E5DD875E4D69DD9DBA24EE41B0909B439835D030BD694BE2B0DA263C2D87FEDF2B012A2FBAF327A7B007352CAED9B59ED807DC1804995806169807D3D807111804DE6DF31DD6F9CE3B749EC3B66F3FF7B8B2788F20E4B11908487119C057D951C46403AFAE6FD6FAB78CFD29CA46BC5D43910096D0ECA8432B977566E6DE8EF529A0388412DA1E4FCC2F049563D687472A10754291203A0A266AE400DB84A791800154D73A569C0BB34BF82E81E4245750F644A1695952CBCC100288976302634D79B0CCD94E68187915266C1CC89AB879785D110B71964D2E26A2BBFBE4D04A4244FC159D0D7F79E02D2D1B7E8FF829C1492D1ED3FCAE8F5DF8DE990D72D94B45A0035BD16C68066FA2F89D56DBFC8A8341F0DD09300EEE9F29FDBAA56DEFF270795312086B6E648A9526250338E2CD48BDAEA18570D681B19D4BF3BD60C50285CD875E4D6915952F7F6A92C2AB2F77D48256BD40848C2CE08CE80FE7A43E73294410819AC8C1B09B81153AD93A69A8F2320391B2C9C017DC36A598B1259B7BA58D362588B0A58B7B2D7BE95DC09662134C48D1CE1BF15F7E75952899471F82422347CD5556F48CA0715658366E5829F579522F8CC7C95948118879331AC3277C07D9790B3C80934352AAAD83A0F202D74318F99B3E0A2F8F808424F551FF76EDEB14FF31A9103EE08AB557B71D970AF80C43418B693B068D2D48D71A909D1C05B306A685224ADFB00B0A560B96616EC722D6DB9BE417F6ED32A5546454C1A19712C6867C26FDD544A0C17C1A9852B839672286BE0C29A5A86326863D6ECA5465E05DCAE37A6BC09C035CC095A38716732A8027073EEEC8795A8ABEAE67D39A8862B0EDA9A239391E440CD38321FC1CEEC9C25F5E2F16BF1F16593268AA74D740DD4A5B3E236C63C9AD6F56B5BA8B974ABEB1FDA4B6AA97800351346B55303B8B6C44E0EAAE6C3B2C46EDCD08817532E6CE82B4BEC24701A2E2C4AECA856EA123B19A086159B12BBA199B6DC4D0EAAE6C7B2DC8D3494273099AF32BAA6094C0A5639390C1298023073E22A536F92C01480991357273065801A366C12987C33136968139832583D2FFA04A60848C2836D02936EA2928351025304A7A7AF4C2372DF25542DD28864AFABCB08096064DB66BB8C10D542256C938C9000CC94B82A232402529237CF08D14DF4BDD76484447006F40DD31A7250192F4E698D7143A55CCCD31A72683D47C2F0B4982309A8842309B40147266167099C8C17FBB033D74A3552A6616709A8392372A3A90F3B8F8074648B24C72BDCA610BB49F45721391AC08094AC6BFB4F3222869DB178DCC1F655078FE71C3E63D0D37C798372F45DC809FD594C9B86D052133C8820242B8413D317829A3332BC39209FEA2A680D53E3062EACC927BF0ADA9835534330B49D5595E2517719A0862106D692171309318026BC58CA45FECCD2084245DDF4D1A50E1EEF86B3942CB989380B248252906701352C903762D37CA55EB845402206447016F4A51A2002D2D1371CF966E7D5DFD82222CD7E175265413404AF93743993AD55F4471129FABB011DECE92A08EDBFCA28ED01B4A4142F6DE85ED7B07851A30325A296136ABF2A28B5007A5252C9ED5452DB9949AC48F3BA3A2B51F2B42CBE8B16D01184901C0FA423DB3AD3E452C20B84E7CA3211BF91208113B22006D531D2C53D941218C3081918836988DF20ECC0A27C21BBF792FB2E22CA81680992A2996EB116DE263E821013E580B464AB3AD962366BFD5B1C0A58312B52701D534D2DEE7CBB5E8B173BEEBB90380BA2BBD48300AB03886310E1A51E232863CAD2856D0CA2A66CB8A8CD51F99C2E54F1AA1184902E0F644A56DE5F1E4249D6AEB7AA18D5184441D83C3E3534D0F558139B1A43E9283FA60F920577F824A4B4FF6A4241865E815B8FB8B947BEB39F2202EC772121164447B0BF8D07950F45B94E2464455042E2224043169A4B1A9B345CF12C7BA25A01AB624700AE636A57D568DD5E9A28E283F92C24CD401851BB44492DBE508AFB2EA7B707D1106C1A492D02F355448C01D0927A11927891A17ED1A344EBCD05A6BDD3AC971238215931A80123B3FDBD20867516268D642CEADA19F04B978E779BE2D3EE7A7F09B3CA16324E958D8CD86CDA345EBC942F1A44CE080D6541599EC41642E9E89B26B5A936D4D5B944239154C915F01AB6444D0C1854EE6A7900190B16BBDB065CBB2F144249A95BEE0FDB36D5F0E49F6CBAF0407206583833FA7AC9B3300AEAD6F2AF887194936DBF2A08B60066A428C554F695875390E7414D18E9CFEEAB7ACEC2481960C14C881B040224705226AC0302A415ED46DDA0826CB69A030AF20B7A8C5AC998D4363460D9487D4C75C7567118F0FDB88B9890410A3991015BB1A3E5C284B80DCD9B74F5580B6DE5184643B907D31027056B027AEDCF2212ED171DD64A7E8D2EF54D88BF32BD3E770F795DA6CF698656C203FA422825611AD08005696D25FD5146D0F412DD8ADC01ABE9A549072DFB3680AB2EE09342EAB930BF6CEF1B7A4C17C27565FF45446EFF91437F5A55C522ED1F98EF689C2E16F87FE481E41BB42872F228209514BD937DDE1FA3A49076BC796264786E84B2FCCB4D916959EDA584BBA607FDC19E0ABB5F535291ECB67E6007C06C70C8C3D117685354693D0890FA513D10A6AD95E21821E1852000500B78C4810223A830D32CC384CA1D258CFE278D200D5AAABBCC22187598FFAC11204B5B8A0D5278E78FE47CC93989D9658314E85FD522346FAFECFA180DDF7B11845A9C63265438E185DA16D4F242697F3511AA497B0301D068C40260214C844A33A1C2092A54EA29BFBD48E887055502356AABEE388762D4EDD1778D2039F2727C9042BC40F7BC1CF63FA94568D252D9610E01DFDFD167B5F838DA526C90C2FB9451DB92410CCCCF6A21DA6050765F8088178110442D54011F4AAC90C2FD5B81ED45C22FC7F4AF6AD19AB7578A608C86978008422DD631132A9C904225E55FA4FEEB2CC9C82237C885FBA016AD2D16A53084C878794880D4621672A3C10C29EC6B54933ACBEA91386A8390989FD582B6C1A0148500112F0821885AC0023E945883087776F59B4032F85743D16ADB9B89608F462A010AC250AC7B2654388308B54B0A080433A40B4C846B8CC74C200C3AA95038284361330CE9708714FA75592C5055C965D601D80D812D562BA131C875B2E380ED8687E1D2905290C1EA1E7615C8B3FB62383CC678CCC4C4A093CA8783321C0286211D6E48A1531E2649C46409BDE9107C548BDE159B524852A4BC9C1480EA6190726640016C30FA731B77A7254A44F26501141D6ADAD38C373F2844C09F3C695A49CF917874ADFF4797AB51F49185D4B3CE248E18FE8579A1D7E97E673BBFA0FAB1582ABBCF42CA59E73052FC735F5EB1FBB7A82CD3BA287752CDE62020557B8F9A6946FD0A37BA1452C5C80E50604C4FABCCFBC3A177E7C57A93E42912AE06423805DBA303AD2DE3D2A3A85C6B4261C735ED7EF3EE726341AE1E3A84EA6E4B61E5CCB34D983EF09F5E4D047DCAF56E8F72DCF5110C08B34CBBCFDC99DFA6E167D9A95DFB6EFE5A6D6E8A627D47FE73999074642DECAA104ECE76073E60A4B81F7D5374BF8315B507E8FC2C7F1EAE0FBDC37F75176C4A345D052EEF02D38AE908F745218681D68EC720BD89D4491CD425A3770C72A13464D0A01DE1DB0BAE70ED51A82E66F515C7C91D4F402792518B00DD52603951A0195F20EB249E4FE943DDEDD0DA0A9D3BF6C7B3A27822271525B2326EAEECB2901EDB7321885A9023DE143825D54941442ADD4718B735EDF6787F21FC7EF062EC47DC4D90CAD6AF254A0F3DF716277BABDC9DF8A32266E281CD543CE23BF4044252DF9067404110335103020FC6F86EA23B3980F1A0386135159DFC862681F8F4772F1952D20E94C17553F683D5579DDF0D67AC5A23271C0405B4BCCB7D23A66BC38F6A61315478E1701FFD3754FBDB3FBBC5A9B9D3BE6754B0B952C12B364C34567ACF44FFAEDA7071647924D0622185E2570F5F50526D4B64A628BA26F2CE312D999E715F0E596F38560D34876D11563C53EB0FA5D7F40CE96FA396C847D924E8E41A3328C6337C071551FF0FA9FB2707D61BE1B19FC77D31138DA9687D5624AD1C5E450856AB1944F755D3440E1C623956CE8B00936246BD223CEC16F9D78DC90D81DFA9D32742D7D11E8F6E75A1D109D617F6B376AD52F648825C020D2A769A0639A853DD89BAA716B9118ED71677C39891A83BC810623EDBEEFE4E472BDD04ADC3F28AA2A659D3099B850D256E365AEE2E70359E5716B93CB8AF830E25F6CEC5F493B902C92B0B9C3B22AE92B6EC783798A8B90C88BBB835885E59E48AE484167C02D19F80C95E88E970843FCAE9E8E14388BF477F917AB82C1A24AF28748A339DBC19D010A21ED60B2F616BD1BCA2B819DE7402E7804388FC13AAFFD1FDD35DE01A24AF286E8A339DB019D010A2EED6672FD556E37845410F8CE9E44C43861033BD2278C9DA00D12B0A9CE34E27F5117860D14349FEA0056F27F79062BF2DEA24F312B814C3EB8ABA61CB40C81D1C8878C7EFA6DDF13FABD3CB3618D40291BF0BB79785FE9537255671B2D8E41D3BA7DC0415DDF8BC7F3E5D5282A80257E61624518ACFAA07D4791CC22DE067C58BEF8EA99A6127CC2097E46AC4D0A01D19276AC4DB61FE13B0384EEE78023A918C5A04E89602CB89020DC4D6F4B3EA25F73BC957F6417AD92CF3C7AB1492FE8DFB5E64E64FD59BD0609934A1C5B7083568BD0FDC9091C9B8EFB8F190D9603DC801633A60428A6B00335CE2F7E8EF84DF74F3CA0597466C62946369C9E074C322664B8F3FC4208C5EB6BF137FD44C152764466212F020969300D06C20465C1B5008311437E42AAAAA1E2B70F7C16C26986231120D834C26160EC84CE80C371ACC90C2EEECD9C7176CE89668D957407C4BB22DBA1BD753A9AAC10C7104AAED9260123225412C810511B3607FC6FFACD6671B0C6AC168767832108DB8353B3C1908C04142E9FB91778A672FC56276C5A5108DFEF5CC563EE6CF60EAF18BE46FF102A8F320D04F35DE71AF47AA04AE6EA7EDBCE8C149BAD3AA172485C2149D78D63D86E9509A3CBEEAF98EBA775A5098AC6CA0A8BBE5EFC16E6B6E65575C8BDB8E2F7E66B128EE7476130DD749F241261411A8BA4B8205467E11F6A8B5421601C5B0AF93B39087A0CD34821197009A5EBB2D17D52F3FB4E8B0EF896D173664FB6FBFFCD0DEBCDDFD80FFAC8B3259A12FC5126555F3EB2F3FDC6C71EB356AFFBA40CDF3D43D8A5F30CE1C3577B10C487B9859FE50F47E01C7510FD27FEE06EF0B36AECBA44E4ECB3A7D4816FD054769BEFAEB5F1ACFE23FFFFA717D8F96B3FC6A5B6FB635EE325ADF678C85FAE50735FD5F7E18F1FCCB55E39057105DC06CA6B80BE82A3FDBA6D972CFF76592F1CFE2C850904372C38233AF4B129FDAED317D2D724344D7FDFD50E4554E44DE3D6DAFCBA9AEF279F28CE4BCE965C84AEC978B345995C9BAEA700CEDF19F58FD96EB97FFF7FF0129075F1863762400 , N'6.0.1-21010')

    ");
            // 2016-01-20 sanjeewa
            #endregion

            #region Mig - 21-01-2016
            ExecuteSqlQuery(@"
            INSERT[dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
");
            // 2015-01-21 sanjeewa
            #endregion

            #region Mig - 8-02-2016

            ExecuteSqlQuery(@"

INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])

");
            // 2016-02-08 Peshala
            #endregion

            #region Mig - 02-03-2016
            ExecuteSqlQuery(@"
            INSERT[dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])

");
            // sanjeewa

            #endregion

            #region Mig - 02-03-2016
            ExecuteSqlQuery(@"
            INSERT[dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])

");
            // sanjeewa

            #endregion

            #region Mig - 30-03-2016
            ExecuteSqlQuery(@"
            INSERT  [dbo].[__MigrationHistory] ( [MigrationId], [ContextKey], [Model],
                                     [ProductVersion] )
VALUES  ( N'201603291302392_AutomaticMigration', N'ERP.Data.ERPDbContext',
          N'6.0.1-21010' )
");
            // Nuwan

            #endregion

            #region Mig - 26-04-2016
            ExecuteSqlQuery(@"
            INSERT  [dbo].[__MigrationHistory] ( [MigrationId], [ContextKey], [Model],
                                     [ProductVersion] )
VALUES  ( N'201604270931118_AutomaticMigration', N'ERP.Data.ERPDbContext',
          N'6.0.1-21010' )
");
            // Sanjeewa

            #endregion

            #region Mig - 03-05-2016
            ExecuteSqlQuery(@"
          INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])

");
            // Sanjeewa

            #endregion

            #region Mig - 17-05-2016
            ExecuteSqlQuery(@"
            INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])

");
            // Sanjeewa

            #endregion

            #region Mig - 20-05-2016
            ExecuteSqlQuery(@"
            INSERT[dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
            ");
            // Sanjeewa

            #endregion

            #region Mig - 25-05-2016
            ExecuteSqlQuery(@"
            INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
            ");
            // Sanjeewa

            #endregion

            #region Mig - 25-05-2016
            ExecuteSqlQuery(@"
            INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])

            ");
            // Dileepa

            #endregion

            #endregion //End Add_MigrationHistory

            // - end
            MessageBox.Show("DB Structure Update Complete ");

        }

        private void FrmERPConfiguration_Load(object sender, EventArgs e)
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            var fileInfo = new FileInfo(entryAssembly.Location);
            var buildDate = fileInfo.LastWriteTime;
            this.label2.Text = "Last Build Date " + buildDate.ToShortDateString(); //Common.LastBuildDate;
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            GetServerDbNames();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}