USE [RIT_ERP]
GO
/****** Object:  StoredProcedure [dbo].[spReportGen]    Script Date: 12/23/2015 01:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- spReportGen '0','z',0,0,0,'SL','SUP',{},{},{},{},{},{},1,1,'DTL','04/09/2014','04/09/2014'

ALTER PROCEDURE [dbo].[spReportGen]

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
                          FROM      @Dep
                        )
        SET @RecCCat = ( SELECT ISNULL(COUNT(InvCategoryID), 0)
                         FROM   @Cat
                       )
        SET @RecCSub = ( SELECT ISNULL(COUNT(InvSubCategoryID), 0)
                         FROM   @SubCat
                       )
        SET @RecCSub2 = ( SELECT    ISNULL(COUNT(InvSubCategory2ID), 0)
                          FROM      @SubCat2
                        )
        SET @RecCExt = ( SELECT ISNULL(COUNT(InvProductExtendedPropertyID), 0)
                         FROM   @ExtendedProperties
                       )
                        
        SET @RecCSup = ( SELECT ISNULL(COUNT(SupplierID), 0)
                         FROM   @Sup
                       )                
                        
                  
        SET @RecCLoca = ( SELECT    ISNULL(COUNT(LocationID), 0)
                          FROM      @Locations
                        )        
  ---- **********
  
  
        IF ( @RecCSup > 0 ) 
            BEGIN
        
			--DELETE FROM InvTmpReportDetail WHERE SupplierID NOT IN (SELECT SupplierID FROM @Sup)
			
			
			
                IF ( @RecCDept <> 0
                     AND @RecCSup <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.SupplierID IN ( SELECT
                                                              SupplierID
                                                              FROM
                                                              @Sup )
                                )
                    END

                IF ( @RecCCat <> 0
                     AND @RecCSup <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                            AND p.SupplierID IN ( SELECT
                                                              SupplierID
                                                              FROM
                                                              @Sup )
                                )
                    END

                IF ( @RecCSub <> 0
                     AND @RecCSup <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.SubCategoryID IN ( SELECT
                                                              SubCategoryID
                                                              FROM
                                                              @SubCat )
                                            AND p.SupplierID IN ( SELECT
                                                              SupplierID
                                                              FROM
                                                              @Sup )
                                )
                    END 

                IF ( @RecCSub2 <> 0
                     AND @RecCSup <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.SubCategory2ID IN ( SELECT
                                                              SubCategory2ID
                                                              FROM
                                                              @SubCat2 )
                                            AND p.SupplierID IN ( SELECT
                                                              SupplierID
                                                              FROM
                                                              @Sup )
                                )
                    END
			
				

                IF ( @RecCSup <> 0
                     AND @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCCat = 0
                     AND @RecCSub2 = 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.SupplierID IN ( SELECT
                                                              SupplierID
                                                              FROM
                                                              @Sup )
                                )
                    END
			

        
            END
        ELSE 
            BEGIN
 
                IF ( @RecCDept <> 0
                     AND @RecCCat <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                )
                    END

                IF ( @RecCDept <> 0
                     AND @RecCSub <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.SubCategoryID IN ( SELECT
                                                              InvSubCategoryID
                                                              FROM
                                                              @SubCat )
                                )
                    END

                IF ( @RecCDept <> 0
                     AND @RecCSub2 <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                            AND p.SubCategory2ID IN (
                                            SELECT  InvSubCategory2ID
                                            FROM    @SubCat2 )
                                )
                    END 


			-- **********
                IF ( @RecCCat <> 0
                     AND @RecCSub <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                            AND p.SubCategoryID IN ( SELECT
                                                              InvSubCategoryID
                                                              FROM
                                                              @SubCat )
                                )
                    END

                IF ( @RecCCat <> 0
                     AND @RecCSub2 <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                            AND p.SubCategory2ID IN (
                                            SELECT  InvSubCategory2ID
                                            FROM    @SubCat2 )
                                )
                    END

			---- **********
 
	
		
                IF ( @RecCDept <> 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   ) 
                    BEGIN
	            
	            
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.DepartmentID IN ( SELECT
                                                              InvDepartmentID
                                                              FROM
                                                              @Dep )
                                )
	 
                    END
		 		
                IF ( @RecCDept = 0
                     AND @RecCCat <> 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   ) 
                    BEGIN
			
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.CategoryID IN ( SELECT
                                                              InvCategoryID
                                                              FROM
                                                              @Cat )
                                )
                    END

                IF ( @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub <> 0
                     AND @RecCSub2 = 0
                   ) 
                    BEGIN
			
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.SubCategoryID IN ( SELECT
                                                              InvSubCategoryID
                                                              FROM
                                                              @SubCat )
                                )
                    END
			
                IF ( @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 <> 0
                   ) 
                    BEGIN
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                            AND p.SubCategory2ID IN (
                                            SELECT  InvSubCategory2ID
                                            FROM    @SubCat2 )
                                )
                    END

                IF ( @RecCDept = 0
                     AND @RecCCat = 0
                     AND @RecCSub = 0
                     AND @RecCSub2 = 0
                   ) 
                    BEGIN
	            
                        INSERT  INTO dbo.InvTmpReportDetail
                                ( CompanyID ,
                                  LocationID ,
                                  UserID ,
                                  DocumentDate ,
                                  DocumentNo ,
                                  UnitNo ,
                                  ZNo ,
                                  CustomerID ,
                                  CustomerCode ,
                                  CustomerName ,
                                  SupplierID ,
                                  SupplierCode ,
                                  SupplierName ,
                                  ProductID ,
                                  ProductCode ,
                                  ProductName ,
                                  DepartmentID ,
                                  DepartmentCode ,
                                  DepartmentName ,
                                  CategoryID ,
                                  CategoryCode ,
                                  CategoryName ,
                                  SubCategoryID ,
                                  SubCategoryCode ,
                                  SubCategoryName ,
                                  SubCategory2ID ,
                                  SubCategory2Code ,
                                  SubCategory2Name ,
                                  BatchNo ,
                                  CostPrice ,
                                  SellingPrice ,
                                  AverageCost ,
                                  GrossProfit ,
                                  Qty01 ,
                                  Value01 ,
                                  Qty02 ,
                                  Value02 ,
                                  Qty03 ,
                                  Value03 ,
                                  Qty04 ,
                                  Value04 ,
                                  Qty05 ,
                                  Value05 ,
                                  Qty06 ,
                                  Value06 ,
                                  Qty07 ,
                                  Value07 ,
                                  Qty08 ,
                                  Value08 ,
                                  Qty09 ,
                                  Value09 ,
                                  Qty10 ,
                                  Value10 ,
                                  Qty11 ,
                                  Value11 ,
                                  Qty12 ,
                                  Value12 ,
                                  Qty13 ,
                                  Value13 ,
                                  Qty14 ,
                                  Value14 ,
                                  Qty15 ,
                                  Value15 ,
                                  Qty16 ,
                                  Value16 ,
                                  Qty17 ,
                                  Value17 ,
                                  Qty18 ,
                                  Value18 ,
                                  Qty19 ,
                                  Value19 ,
                                  Qty20 ,
                                  Value20 ,
                                  Qty21 ,
                                  Value21 ,
                                  Qty22 ,
                                  Value22 ,
                                  Qty23 ,
                                  Value23 ,
                                  Qty24 ,
                                  Value24 ,
                                  Qty25 ,
                                  Value25 ,
                                  Qty26 ,
                                  Value26 ,
                                  Qty27 ,
                                  Value27 ,
                                  Qty28 ,
                                  Value28 ,
                                  Qty29 ,
                                  Value29 ,
                                  Qty30 ,
                                  Value30 ,
                                  GroupOfCompanyID ,
                                  CreatedUser ,
                                  CreatedDate ,
                                  ModifiedUser ,
                                  ModifiedDate ,
                                  DataTransfer 
                                )
                                ( SELECT    @CompanyId ,
                                            @LocationID ,
                                            @UserId ,
                                            GETDATE() ,
                                            '' ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '' ,
                                            '' ,
                                            SupplierID ,
                                            '' ,
                                            '' ,
                                            InvProductMasterID ,
                                            ProductCode ,
                                            ProductName ,
                                            DepartmentID ,
                                            '' ,
                                            '' ,
                                            CategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategoryID ,
                                            '' ,
                                            '' ,
                                            SubCategory2ID ,
                                            '' ,
                                            '' ,
                                            '' ,
                                            p.CostPrice ,
                                            p.SellingPrice ,
                                            p.AverageCost ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            0 ,
                                            '''' ,
                                            GETDATE() ,
                                            '''' ,
                                            GETDATE() ,
                                            0
                                  FROM      dbo.InvProductMaster p
                                  WHERE     p.IsDelete = 0
                                )
	 
                    END
        
            END
            
                -- UPDATE DEPARTMENT                            
        UPDATE  b
        SET     b.DepartmentCode = T.DepartmentCode ,
                b.DepartmentName = T.DepartmentName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvDepartment t ( NOLOCK ) ON b.DepartmentID = t.InvDepartmentID 
                        
                         -- UPDATE CATEGORY
        UPDATE  b
        SET     b.CategoryCode = T.CategoryCode ,
                b.CategoryName = T.CategoryName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvCategory t ( NOLOCK ) ON b.CategoryID = t.InvCategoryID
                        
                         -- UPDATE SUBCATEGORY
            
        UPDATE  b
        SET     b.SubCategoryCode = T.SubCategoryCode ,
                b.SubCategoryName = T.SubCategoryName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvSubCategory t ( NOLOCK ) ON b.SubCategoryID = t.InvSubCategoryID
                        
                        -- UPDATE SUBCATEGORY2
        UPDATE  b
        SET     b.SubCategory2Code = T.SubCategory2Code ,
                b.SubCategory2Name = T.SubCategory2Name
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN InvSubCategory2 t ( NOLOCK ) ON b.SubCategory2ID = t.InvSubCategory2ID                               

				-- UPDATE Supplier
        UPDATE  b
        SET     b.SupplierCode = T.SupplierCode ,
                b.SupplierName = T.SupplierName
        FROM    InvTmpReportDetail b ( NOLOCK )
                INNER JOIN dbo.Supplier t ( NOLOCK ) ON b.SupplierID = t.SupplierID
		
        
        
 
	
       

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
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 1
                     )
        SET @Loca2 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 2
                     )
        SET @Loca3 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 3
                     )
        SET @Loca4 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 4
                     )
        SET @Loca5 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 5
                     )
        SET @Loca6 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 6
                     )
        SET @Loca7 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 7
                     )
        SET @Loca8 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 8
                     )
        SET @Loca9 = ( SELECT   ISNULL(LocationID, 0)
                       FROM     ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                       WHERE    row = 9
                     )
        SET @Loca10 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 10
                      )
        SET @Loca11 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 11
                      )
        SET @Loca12 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 12
                      )
        SET @Loca13 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 13
                      )
        SET @Loca14 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 14
                      )
        SET @Loca15 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 15
                      )
        SET @Loca16 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 16
                      )
        SET @Loca17 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 17
                      )
        SET @Loca18 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 18
                      )
        SET @Loca19 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 19
                      )
        SET @Loca20 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 20
                      )
        SET @Loca21 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 21
                      )
        SET @Loca22 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 22
                      )
        SET @Loca23 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 23
                      )
        SET @Loca24 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 24
                      )
        SET @Loca25 = ( SELECT  ISNULL(LocationID, 0)
                        FROM    ( SELECT    LocationID ,
                                            ROW_NUMBER() OVER ( ORDER BY LocationID ) AS 'row'
                                  FROM      @Locations
                                ) AS temp
                        WHERE   row = 25
                      )
 


 
-- LAST PURCHASE DATE

	;
        WITH    cte
                  AS ( SELECT   MAX(d.DocumentDate) AS TopDocDate ,
                                ProductID ,
                                SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1502
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                AND d.LocationID IN ( SELECT  LocationId
                                                      FROM    @Locations )
                       GROUP BY ProductID ,
                                SupplierID
                     )
            UPDATE  t
            SET     DocumentDate = cte.TopDocDate
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID


----------------Qty01 - LAST PURCHASE  QTY

;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY ,
                                d.ProductID ,
                                SupplierID ,
                                MAX(d.DocumentDate) DocumentDate
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                                                              AND d.LocationID IN (
                                                              SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                                INNER JOIN ( SELECT MAX(CAST(DocumentDate AS DATE)) AS TopDocDate ,
                                                    ProductID
                                             FROM   InvPurchaseDetail
                                             WHERE  DocumentID = 1502
                                                    AND CAST(DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                                    AND LocationID IN ( SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                                             GROUP BY ProductID
                                           ) b ON d.ProductID = b.ProductID
                                                  AND CAST(d.DocumentDate AS DATE) = CAST(b.TopDocDate AS DATE)
                       WHERE    d.DocumentID = 1502
                       GROUP BY d.ProductID ,
                                h.SupplierID
                     )
            UPDATE  t
            SET     Qty01 = cte.QTY
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID


----------------Qty02 - TOTAL PURCHASE  QTY

;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY ,
                                ProductID ,
                                SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1502
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                AND d.LocationID IN ( SELECT  LocationId
                                                      FROM    @Locations )
                       GROUP BY d.ProductID ,
                                h.SupplierID
                     )
            UPDATE  t
            SET     Qty02 = cte.QTY
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID
                    
-- delete zoro purchase qty

--DELETE FROM InvTmpReportDetail WHERE Qty02=0
-- ************                  
                    
----------------Qty03 - TOTAL PURCHASE RETRUN QTY	
;
        WITH    cte
                  AS ( SELECT   ISNULL(SUM(Qty), 0) QTY ,
                                ProductID ,
                                SupplierID
                       FROM     InvPurchaseDetail D
                                INNER JOIN dbo.InvPurchaseHeader h ON d.InvPurchaseHeaderID = h.InvPurchaseHeaderID
                       WHERE    d.DocumentID = 1503
                                AND CAST(D.DocumentDate AS DATE) BETWEEN @DateFrom
                                                              AND
                                                              @DateTo
                                AND d.LocationID IN ( SELECT  LocationId
                                                      FROM    @Locations )
                       GROUP BY ProductID ,
                                SupplierID
                     )
            UPDATE  t
            SET     Qty03 = cte.QTY
            FROM    InvTmpReportDetail t
                    INNER JOIN cte ON t.ProductID = cte.ProductID
                                      AND t.SupplierID = cte.SupplierID

 
	
	
        DECLARE @GROUPofCompany VARCHAR(30)
 
        SET @GROUPofCompany = ( SELECT TOP 1 GroupOfCompanyName
                                FROM    dbo.GroupOfCompany
                                WHERE   GroupOfCompanyName LIKE '% MANJARI %'
                              )
 

        IF ( @GROUPofCompany = 'MANJARI' ) 
            BEGIN
-- ********** Qty05 UPDATE SALES AND RETURN
			
			-- galle sales

;
                WITH    temp
                          AS ( SELECT   td.ProductID ,
                                        ISNULL(SUM(CASE WHEN DocumentID = 1
                                                        THEN td.Qty
                                                        WHEN DocumentID = 3
                                                        THEN td.Qty
                                                   END), 0) SALES ,
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
                               GROUP BY td.ProductID
                             )
                    UPDATE  b
                    SET     b.Qty04 = ISNULL(t.SALES, 0) ,
                            b.Qty05 = ISNULL(t.SALESRETURN, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID
                            
                            
			-- nugegoda sales
;
                WITH    temp
                          AS ( SELECT   td.ProductID ,
                                        ISNULL(SUM(CASE WHEN DocumentID = 1
                                                        THEN td.Qty
                                                        WHEN DocumentID = 3
                                                        THEN td.Qty
                                                   END), 0) SALES ,
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
                               GROUP BY td.ProductID
                             )
                    UPDATE  b
                    SET     b.Qty08 = ISNULL(t.SALES, 0) ,
                            b.Qty09 = ISNULL(t.SALESRETURN, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID

  
--****************** Qty06 UPDATE Stock QTY 
 
				-- manjari  HeadOffice
				
				;WITH    temp
                          AS ( SELECT   td.ProductID ,
                                        ISNULL(SUM(td.Stock), 0) AS stock
                               FROM     dbo.InvProductStockMaster td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    td.IsDelete = 0
                                        AND td.LocationID IN (1)
                               GROUP BY td.ProductID
                             )
                    UPDATE  b
                    SET     b.Qty06 = ISNULL(T.Stock, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID
 
 
				-- manjari  galle stock
				
				;WITH    temp
                          AS ( SELECT   td.ProductID ,
                                        ISNULL(SUM(td.Stock), 0) AS stock
                               FROM     dbo.InvProductStockMaster td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    td.IsDelete = 0
                                        AND td.LocationID IN (5 )
                               GROUP BY td.ProductID
                             )
                    UPDATE  b
                    SET     b.Qty10 = ISNULL(T.Stock, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID
                            
                -- manjari  Nugegoda stock
                     
                ;WITH    temp
                          AS ( SELECT   td.ProductID ,
                                        ISNULL(SUM(td.Stock), 0) AS stock
                               FROM     dbo.InvProductStockMaster td
                                        INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                               WHERE    td.IsDelete = 0
                                        AND td.LocationID IN ( 6 )
                               GROUP BY td.ProductID
                             )
                    UPDATE  b
                    SET     b.Qty11 = ISNULL(T.Stock, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID       
                                                              
 	
 
				
                                 
            END
        ELSE 
            BEGIN 

;
                WITH    temp
                          AS ( SELECT   td.ProductID ,
                                        ISNULL(SUM(CASE WHEN DocumentID = 1
                                                        THEN td.Qty
                                                        WHEN DocumentID = 3
                                                        THEN td.Qty
                                                   END), 0) SALES ,
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
                               GROUP BY td.ProductID
                             )
                    UPDATE  b
                    SET     b.Qty04 = ISNULL(t.SALES, 0) ,
                            b.Qty05 = ISNULL(t.SALESRETURN, 0)
                    FROM    InvTmpReportDetail b
                            INNER JOIN temp t ON b.ProductID = t.ProductID
 
  
--****************** Qty06 UPDATE Stock QTY 
			
                IF ( @RecCLoca > 0 ) 
                    BEGIN
			
				;
                        WITH    temp
                                  AS ( SELECT   td.ProductID ,
                                                ISNULL(SUM(td.Stock), 0) AS stock
                                       FROM     dbo.InvProductStockMaster td
                                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                                       WHERE    td.IsDelete = 0
                                                AND td.LocationID IN ( SELECT
                                                              LocationId
                                                              FROM
                                                              @Locations )
                                       GROUP BY td.ProductID
                                     )
                            UPDATE  b
                            SET     b.Qty06 = ISNULL(T.Stock, 0)
                            FROM    InvTmpReportDetail b
                                    INNER JOIN temp t ON b.ProductID = t.ProductID
                                                              
				
                    END	
                ELSE 
                    BEGIN
						
						  ;
                        WITH    temp
                                  AS ( SELECT   td.ProductID ,
                                                ISNULL(SUM(td.Stock), 0) AS stock
                                       FROM     dbo.InvProductStockMaster td
                                                INNER JOIN InvTmpReportDetail ON td.ProductID = InvTmpReportDetail.ProductID
                                       WHERE    td.IsDelete = 0
                                       GROUP BY td.ProductID
                                     )
                            UPDATE  b
                            SET     b.Qty06 = ISNULL(T.Stock, 0)
                            FROM    InvTmpReportDetail b
                                    INNER JOIN temp t ON b.ProductID = t.ProductID
			
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
