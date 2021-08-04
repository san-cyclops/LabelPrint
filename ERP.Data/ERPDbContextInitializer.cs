using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain;
using System.IO;

namespace ERP.Data
{
    internal class ERPDbContextInitializer : DropCreateDatabaseIfModelChanges<ERPDbContext>
    {
        #region Methods
        protected override void Seed(ERPDbContext context)
        {
            AddGroupOfCompany(context);
            AddLookupReferenceTypes(context);
            AddCostCentres(context);
            AddAutoGenerateInfo(context);
            AddPaymentMethods(context);

            //AddTax(context);
            //AddCurrencyCodes(context);


            //AddUnitOfMeasures(context);
            //AddCommissionSchemas(context);


            //AddProductCodeDependancy(context);

            // AddCurrencyCodes(context);

            ////General Ledger
            //AddLedgerAccounts(context);

            //
            //AddCompany(context);
            //AddLocation(context);
            //AddSupplierGroups(context);

            ////Inventry
            //AddDepartments(context);
            //AddCategories(context);
            //AddSubCategories(context);
            //AddSubCategories2(context);
            //AddCustomerGroups(context);

            ////Logistic
            //AddLgsDepartments(context);
            //AddLgsCategories(context);
            //AddLgsSubCategories(context);
            //AddLgsSubCategories2(context);
            //AddAreas(context);
            //AddBrokers(context);
            //AddTerritorys(context);
            ////AddSuppliers(context);
            //AddGiftVoucherGroup(context);
            //AddGiftVoucherBook(context);
        }

        private static void AddLookupReferenceTypes(ERPDbContext context)
        {
            // Add Reference Type
            var referenceTypes = new List<ReferenceType>
                {
                    //Gender Type                    
                    new ReferenceType { LookupType = ((int)LookUpReference.GenderType).ToString(), LookupKey = 1, LookupValue = "Male", Remark =  (LookUpReference.GenderType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.GenderType).ToString(), LookupKey = 2, LookupValue = "Female", Remark =  (LookUpReference.GenderType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.GenderType).ToString(), LookupKey = 3, LookupValue = "Other", Remark =  (LookUpReference.GenderType).ToString()},
                    //Title Type
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 1, LookupValue = "Mr.", Remark =  (LookUpReference.TitleType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 2, LookupValue = "Mrs.", Remark =  (LookUpReference.TitleType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 3, LookupValue = "Miss.", Remark =  (LookUpReference.TitleType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 4, LookupValue = "Dr.", Remark =  (LookUpReference.TitleType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 5, LookupValue = "Prof.", Remark =  (LookUpReference.TitleType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 6, LookupValue = "Ven.", Remark =  (LookUpReference.TitleType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.TitleType).ToString(), LookupKey = 7, LookupValue = "Company", Remark =  (LookUpReference.TitleType).ToString()},
                    //Supplier Type
                    new ReferenceType { LookupType = ((int)LookUpReference.SupplierType).ToString(), LookupKey = 1, LookupValue = "Trade", Remark =  (LookUpReference.SupplierType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.SupplierType).ToString(), LookupKey = 2, LookupValue = "Expense", Remark =  (LookUpReference.SupplierType).ToString()},
                    //Customer Type
                    new ReferenceType { LookupType = ((int)LookUpReference.CustomerType).ToString(), LookupKey = 1, LookupValue = "Trade", Remark =  (LookUpReference.CustomerType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.CustomerType).ToString(), LookupKey = 2, LookupValue = "Local", Remark =  (LookUpReference.CustomerType).ToString()},
                    //FiscalType
                    new ReferenceType { LookupType = ((int)LookUpReference.FiscalType).ToString(), LookupKey = 1, LookupValue = "January", Remark = (LookUpReference.FiscalType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.FiscalType).ToString(), LookupKey = 2, LookupValue = "April", Remark = (LookUpReference.FiscalType).ToString()},
                    //Nationality
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 1, LookupValue = "Sri Lankan", Remark =  (LookUpReference.Nationality).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 2, LookupValue = "Indian", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 3, LookupValue = "Moldovans", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 4, LookupValue = "Nepalese", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 5, LookupValue = "Kazakhstani", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 6, LookupValue = "Bangladeshi", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 7, LookupValue = "Afghani", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 8, LookupValue = "Chinese", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 9, LookupValue = "Japanese", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 10, LookupValue = "Mongolian", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 11, LookupValue = "North Korean", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 12, LookupValue = "South Korean", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 13, LookupValue = "Taiwanese", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 14, LookupValue = "Cambodian", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 15, LookupValue = "Indonesian", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 16, LookupValue = "Malaysian", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 17, LookupValue = "Singaporean", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 18, LookupValue = "	Australian", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 19, LookupValue = "American", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 20, LookupValue = "African", Remark = (LookUpReference.Nationality).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Nationality).ToString(), LookupKey = 21, LookupValue = "Other", Remark = (LookUpReference.Nationality).ToString() },
                    //Religion
                    new ReferenceType { LookupType = ((int)LookUpReference.Religion).ToString(), LookupKey = 1, LookupValue = "Buddhism", Remark = (LookUpReference.Religion).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Religion).ToString(), LookupKey = 2, LookupValue = "Hinduism", Remark = (LookUpReference.Religion).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Religion).ToString(), LookupKey = 3, LookupValue = "Christianity", Remark = (LookUpReference.Religion).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Religion).ToString(), LookupKey = 4, LookupValue = "Islam", Remark = (LookUpReference.Religion).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Religion).ToString(), LookupKey = 5, LookupValue = "Other", Remark = (LookUpReference.Religion).ToString() },
                    //District
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 1, LookupValue = "Ampara", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 2, LookupValue = "Anuradhapura", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 3, LookupValue = "Badulla", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 4, LookupValue = "Batticaloa", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 5, LookupValue = "Colombo", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 6, LookupValue = "Galle", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 7, LookupValue = "Gampaha", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 8, LookupValue = "Hambantota", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 9, LookupValue = "Jaffna", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 10, LookupValue = "Kalutara", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 11, LookupValue = "Kandy", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 12, LookupValue = "Kegalle", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 13, LookupValue = "Kilinochchi", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 14, LookupValue = "Kurunegala", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 15, LookupValue = "Mannar", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 16, LookupValue = "Matale", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 17, LookupValue = "Matara", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 18, LookupValue = "Moneragala", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 19, LookupValue = "Mullaitivu", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 20, LookupValue = "Nuwara Eliya", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 21, LookupValue = "Polonnaruwa", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 22, LookupValue = "Puttalam", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 23, LookupValue = "Ratnapura", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 24, LookupValue = "Trincomalee", Remark = (LookUpReference.District).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.District).ToString(), LookupKey = 25, LookupValue = "Vavuniya", Remark = (LookUpReference.District).ToString() },
                    //CivilStatus
                    new ReferenceType { LookupType = ((int)LookUpReference.CivilStatus).ToString(), LookupKey = 1, LookupValue = "Unmarried", Remark = (LookUpReference.CivilStatus).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.CivilStatus).ToString(), LookupKey = 2, LookupValue = "Married", Remark = (LookUpReference.CivilStatus).ToString() },
                    //TvChannel
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 1, LookupValue = "Independent Television Network (ITN)", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 2, LookupValue = "Sri Lanka Rupavahini Corporation", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 3, LookupValue = "TNL", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 4, LookupValue = "MTV SPORTS", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 5, LookupValue = "ETV", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 6, LookupValue = "Swarnavahini", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 7, LookupValue = "Sirasa TV ", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 8, LookupValue = "Shakthi TV ", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 9, LookupValue = "Channel Eye", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 10, LookupValue = "ART Television", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 11, LookupValue = "TV Derana", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 12, LookupValue = "MAX TV", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 13, LookupValue = "Nethra TV", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 14, LookupValue = "Vasantham TV", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 15, LookupValue = "NTV", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 16, LookupValue = "Carlton Sports Network (CSN)", Remark = (LookUpReference.TvChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TvChannel).ToString(), LookupKey = 17, LookupValue = "The Buddhist TV", Remark = (LookUpReference.TvChannel).ToString() },
                    //NewsPaper
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 1, LookupValue = "Divaina", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 2, LookupValue = "Lankadeepa", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 3, LookupValue = "Dinamina", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 4, LookupValue = "Divaina", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 5, LookupValue = "Rivira", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 6, LookupValue = "Lakbima", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 7, LookupValue = "Silumina", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 8, LookupValue = "Mawbima", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 9, LookupValue = "Randiwa", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 10, LookupValue = "Ravaya", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 11, LookupValue = "Sunday Times", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 12, LookupValue = "Sunday Observer", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 13, LookupValue = "Daily News", Remark = (LookUpReference.NewsPaper).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.NewsPaper).ToString(), LookupKey = 14, LookupValue = "Daily Mirror", Remark = (LookUpReference.NewsPaper).ToString() },
                    //RadioChannel
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 1, LookupValue = "Shree FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 2, LookupValue = "City FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 3, LookupValue = "Swadeshiya Sevaya", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 4, LookupValue = "Velanda Sevaya", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 5, LookupValue = "Kothmale FM ", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 6, LookupValue = "Singha FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 7, LookupValue = "Sirasa FM ", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 8, LookupValue = "Siyatha FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 9, LookupValue = "V FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 10, LookupValue = "Y FM ", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 11, LookupValue = "Rangiri Sri Lanka", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 12, LookupValue = "Isira TNL", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 13, LookupValue = "Bauddaya Guwan Viduliya(The Buddhist)", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 14, LookupValue = "Kirula FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 15, LookupValue = "Rajarata Sewaya", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 16, LookupValue = "Rajarata Sewaya", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 17, LookupValue = "VIP Radio ", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 18, LookupValue = "Kandurata Sewaya", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 19, LookupValue = "Shaa FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 20, LookupValue = "Seth FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 21, LookupValue = "Kandurata FM ", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 22, LookupValue = "Lakviru FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 23, LookupValue = "FM Derana", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 24, LookupValue = "Hiru FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 25, LookupValue = "Lak FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 26, LookupValue = "Lakhanda", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 27, LookupValue = "Neth FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.RadioChannel).ToString(), LookupKey = 28, LookupValue = "Ran FM", Remark = (LookUpReference.RadioChannel).ToString() },
                    //Magazine
                    new ReferenceType { LookupType = ((int)LookUpReference.Magazine).ToString(), LookupKey = 1, LookupValue = "ADZ", Remark = (LookUpReference.Magazine).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Magazine).ToString(), LookupKey = 2, LookupValue = "Z", Remark = (LookUpReference.Magazine).ToString() },
                    //DeliverTo
                    new ReferenceType { LookupType = ((int)LookUpReference.DeliverTo).ToString(), LookupKey = 1, LookupValue = "Home Address", Remark = (LookUpReference.DeliverTo).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.DeliverTo).ToString(), LookupKey = 2, LookupValue = "Office Address", Remark = (LookUpReference.DeliverTo).ToString() },
                    //Relationship
                    new ReferenceType { LookupType = ((int)LookUpReference.Relationship).ToString(), LookupKey = 1, LookupValue = "Wife", Remark = (LookUpReference.Relationship).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Relationship).ToString(), LookupKey = 2, LookupValue = "Sister", Remark = (LookUpReference.Relationship).ToString() },
                    //Satatus
                    new ReferenceType { LookupType = ((int)LookUpReference.Status).ToString(), LookupKey = 1, LookupValue = "True", Remark = (LookUpReference.Status).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Status).ToString(), LookupKey = 2, LookupValue = "False", Remark = (LookUpReference.Status).ToString() },
                    ////Transaction Definition
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 1, LookupValue = "Transaction", Remark = (LookUpReference.TransactionDefinition).ToString() },
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 2, LookupValue = "Discount", Remark = (LookUpReference.TransactionDefinition).ToString() },
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 3, LookupValue = "Expense", Remark = (LookUpReference.TransactionDefinition).ToString() },
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 4, LookupValue = "Advance", Remark = (LookUpReference.TransactionDefinition).ToString() },
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 5, LookupValue = "OverPayment", Remark = (LookUpReference.TransactionDefinition).ToString() },
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 6, LookupValue = "Consignment", Remark = (LookUpReference.TransactionDefinition).ToString() },
                    //new ReferenceType { LookupType = ((int)LookUpReference.TransactionDefinition).ToString(), LookupKey = 7, LookupValue = "RoundOff", Remark = (LookUpReference.TransactionDefinition).ToString() },

                    //Costing Methods
                    new ReferenceType { LookupType = ((int)LookUpReference.CostingMethod).ToString(), LookupKey = 1, LookupValue = "First In First Out (FIFO)", Remark = (LookUpReference.CostingMethod).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.CostingMethod).ToString(), LookupKey = 2, LookupValue = "Last In First Out (LIFO)", Remark = (LookUpReference.CostingMethod).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.CostingMethod).ToString(), LookupKey = 3, LookupValue = "Average Cost", Remark = (LookUpReference.CostingMethod).ToString() },
                    //Module Type
                    new ReferenceType { LookupType = ((int)LookUpReference.ModuleType).ToString(), LookupKey = 1, LookupValue = "Inventory", Remark = (LookUpReference.ModuleType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.ModuleType).ToString(), LookupKey = 2, LookupValue = "Logistic", Remark = (LookUpReference.ModuleType).ToString() },
                    //Stock Adjustment Mode
                    new ReferenceType { LookupType = ((int)LookUpReference.StockAdjustmentMode).ToString(), LookupKey = 1, LookupValue = "Add Stock", Remark = (LookUpReference.StockAdjustmentMode).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.StockAdjustmentMode).ToString(), LookupKey = 2, LookupValue = "Reduce Stock", Remark = (LookUpReference.StockAdjustmentMode).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.StockAdjustmentMode).ToString(), LookupKey = 3, LookupValue = "Overwrite Stock", Remark = (LookUpReference.StockAdjustmentMode).ToString() },
                    //EntryDrCr
                    new ReferenceType { LookupType = ((int)LookUpReference.EntryDrCr).ToString(), LookupKey = 1, LookupValue = "Dr", Remark = (LookUpReference.EntryDrCr).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.EntryDrCr).ToString(), LookupKey = 2, LookupValue = "Cr", Remark = (LookUpReference.EntryDrCr).ToString() },
                    //SupplierType - Logistic
                    new ReferenceType { LookupType = ((int)LookUpReference.LogisticSupplierType).ToString(), LookupKey = 1, LookupValue = "Expense", Remark =  (LookUpReference.LogisticSupplierType).ToString()},
                    //EditablePaymentMethods
                    new ReferenceType { LookupType = ((int)LookUpReference.EditablePaymentTerm).ToString(), LookupKey = 1, LookupValue = "Credit", Remark = (LookUpReference.EditablePaymentTerm).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.EditablePaymentTerm).ToString(), LookupKey = 2, LookupValue = "Cheque", Remark = (LookUpReference.EditablePaymentTerm).ToString() },
                    //card type
                    new ReferenceType { LookupType = ((int)LookUpReference.LCardType).ToString(), LookupKey = 1, LookupValue = "Discount", Remark = (LookUpReference.LCardType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.LCardType).ToString(), LookupKey = 2, LookupValue = "Arapaima", Remark = (LookUpReference.LCardType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.LCardType).ToString(), LookupKey = 3, LookupValue = "Arrowana", Remark = (LookUpReference.LCardType).ToString() },
                    //Data Download Mode
                    new ReferenceType { LookupType = ((int)LookUpReference.DataDownloadMode).ToString(), LookupKey = 1, LookupValue = "Add Stock", Remark = (LookUpReference.DataDownloadMode).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.DataDownloadMode).ToString(), LookupKey = 2, LookupValue = "Reduce Stock", Remark = (LookUpReference.DataDownloadMode).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.DataDownloadMode).ToString(), LookupKey = 3, LookupValue = "Overwrite Stock", Remark = (LookUpReference.DataDownloadMode).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.DataDownloadMode).ToString(), LookupKey = 4, LookupValue = "Opening Stock", Remark = (LookUpReference.DataDownloadMode).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.DataDownloadMode).ToString(), LookupKey = 5, LookupValue = "Transfer Stock", Remark = (LookUpReference.DataDownloadMode).ToString() },
                    //Tag Type
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 1, LookupValue = "2X1 Sticker", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 2, LookupValue = "3Sticker", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 3, LookupValue = "GlitzTAG A4 new", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 4, LookupValue = "A4 new", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 5, LookupValue = "Price Removable TAG", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 6, LookupValue = "Zebra 4 Cross TAG", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 7, LookupValue = "Special Offer TAG", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 8, LookupValue = "Discount TAG", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 9, LookupValue = "Watch TAG", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 10, LookupValue = "Old Price New Price TAG", Remark = (LookUpReference.TagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.TagType).ToString(), LookupKey = 11, LookupValue = "Zebra 110 2X1 Sticker", Remark = (LookUpReference.TagType).ToString() },
                    //Loylty Type
                    new ReferenceType { LookupType = ((int)LookUpReference.LoyaltyType).ToString(), LookupKey = 2, LookupValue = "Arapaima", Remark = (LookUpReference.LoyaltyType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.LoyaltyType).ToString(), LookupKey = 3, LookupValue = "Arrowana", Remark = (LookUpReference.LoyaltyType).ToString() },
                    //Race
                    new ReferenceType { LookupType = ((int)LookUpReference.Race).ToString(), LookupKey = 1, LookupValue = "Sinhalese", Remark = (LookUpReference.Race).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Race).ToString(), LookupKey = 2, LookupValue = "Tamils", Remark = (LookUpReference.Race).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Race).ToString(), LookupKey = 3, LookupValue = "Moors", Remark = (LookUpReference.Race).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Race).ToString(), LookupKey = 4, LookupValue = "Sri Lankan Malays", Remark = (LookUpReference.Race).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Race).ToString(), LookupKey = 5, LookupValue = "Burghers", Remark = (LookUpReference.Race).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.Race).ToString(), LookupKey = 6, LookupValue = "Other", Remark = (LookUpReference.Race).ToString() },
                    //Slab Period                    
                    new ReferenceType { LookupType = ((int)LookUpReference.SlabPeriod).ToString(), LookupKey = 1, LookupValue = "Days", Remark =  (LookUpReference.SlabPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.SlabPeriod).ToString(), LookupKey = 2, LookupValue = "Weeks", Remark =  (LookUpReference.SlabPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.SlabPeriod).ToString(), LookupKey = 3, LookupValue = "Months", Remark =  (LookUpReference.SlabPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.SlabPeriod).ToString(), LookupKey = 4, LookupValue = "Years", Remark =  (LookUpReference.SlabPeriod).ToString()},
                   
                    //Budget Period
                    new ReferenceType { LookupType = ((int)LookUpReference.BudgetPeriod).ToString(), LookupKey = 1, LookupValue = "Monthly", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.BudgetPeriod).ToString(), LookupKey = 2, LookupValue = "Yearly", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.BudgetPeriod).ToString(), LookupKey = 3, LookupValue = "Quarterly", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    
                     //Months
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 1, LookupValue = "January", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 2, LookupValue = "February", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 3, LookupValue = "March", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 4, LookupValue = "April", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 5, LookupValue = "May", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 6, LookupValue = "June", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 7, LookupValue = "July", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 8, LookupValue = "August", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 9, LookupValue = "September", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 10,LookupValue = "October", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 11,LookupValue = "November", Remark =  (LookUpReference.BudgetPeriod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.Months).ToString(), LookupKey = 12,LookupValue = "December", Remark =  (LookUpReference.BudgetPeriod).ToString()},

                    //Cheque Book Page Count                   
                    new ReferenceType { LookupType = ((int)LookUpReference.ChequeBookPageCount).ToString(), LookupKey = 1, LookupValue = "10", Remark =  (LookUpReference.ChequeBookPageCount).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ChequeBookPageCount).ToString(), LookupKey = 2, LookupValue = "25", Remark =  (LookUpReference.ChequeBookPageCount).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ChequeBookPageCount).ToString(), LookupKey = 3, LookupValue = "50", Remark =  (LookUpReference.ChequeBookPageCount).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ChequeBookPageCount).ToString(), LookupKey = 4, LookupValue = "100", Remark =  (LookUpReference.ChequeBookPageCount).ToString()},
                    //Reference Type ID
                    //If add record to here, apply changes into commonservice -> SetReferenceCardID method, common -> ReferenceCardTypeIDs struct
                    new ReferenceType { LookupType = ((int)LookUpReference.ReferenceCardTypeID).ToString(), LookupKey = 1, LookupValue = "Supplier", Remark =  (LookUpReference.ReferenceCardTypeID).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ReferenceCardTypeID).ToString(), LookupKey = 2, LookupValue = "Customer", Remark =  (LookUpReference.ReferenceCardTypeID).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ReferenceCardTypeID).ToString(), LookupKey = 3, LookupValue = "Loyalty Customer", Remark =  (LookUpReference.ReferenceCardTypeID).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ReferenceCardTypeID).ToString(), LookupKey = 4, LookupValue = "Logistic Supplier", Remark =  (LookUpReference.ReferenceCardTypeID).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.ReferenceCardTypeID).ToString(), LookupKey = 5, LookupValue = "Employee", Remark =  (LookUpReference.ReferenceCardTypeID).ToString()},

                    //PaymentMethods
                    new ReferenceType { LookupType = ((int)LookUpReference.PaymentMethod).ToString(), LookupKey = 1, LookupValue = "Equal Interest Payment", Remark =  (LookUpReference.PaymentMethod).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.PaymentMethod).ToString(), LookupKey = 2, LookupValue = "Principle Equal Payment", Remark =  (LookUpReference.PaymentMethod).ToString()},

                    //LoanTerms
                    new ReferenceType { LookupType = ((int)LookUpReference.LoanTerm).ToString(), LookupKey = 1, LookupValue = "Fixed", Remark =  (LookUpReference.LoanTerm).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.LoanTerm).ToString(), LookupKey = 2, LookupValue = "Floating", Remark =  (LookUpReference.LoanTerm).ToString()},
                   
                    //GiftVoucher Tag Print
                    //BS
                    new ReferenceType { LookupType = ((int)LookUpReference.GiftVoucherTagType).ToString(), LookupKey = 1, LookupValue = "2X1 Sticker", Remark = (LookUpReference.GiftVoucherTagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.GiftVoucherTagType).ToString(), LookupKey = 2, LookupValue = "3Sticker", Remark = (LookUpReference.GiftVoucherTagType).ToString() },
                    new ReferenceType { LookupType = ((int)LookUpReference.GiftVoucherTagType).ToString(), LookupKey = 3, LookupValue = "GlitzTAG A4 new", Remark = (LookUpReference.GiftVoucherTagType).ToString() },

                    //Sales Person Type
                    new ReferenceType { LookupType = ((int)LookUpReference.SalesPersonType).ToString(), LookupKey = 1, LookupValue = "Sales Person", Remark =  (LookUpReference.SalesPersonType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.SalesPersonType).ToString(), LookupKey = 2, LookupValue = "Representative", Remark =  (LookUpReference.SalesPersonType).ToString()},
                    new ReferenceType { LookupType = ((int)LookUpReference.SalesPersonType).ToString(), LookupKey = 3, LookupValue = "Collector", Remark =  (LookUpReference.SalesPersonType).ToString()},
                   
                };

            referenceTypes.ForEach(r => context.ReferenceTypes.Add(r));
            context.SaveChanges();
        }

        private static void AddTax(ERPDbContext context)
        {
            // Add Tax
            var taxes = new List<Tax>
                {
                    new Tax { TaxCode = "VAT", TaxName = "VAT", EffectivePercentage = (decimal)12.00 , TaxPercentage =(decimal)12.00 },
                    new Tax { TaxCode = "NBT", TaxName = "NBT", EffectivePercentage = (decimal)2.00, TaxPercentage =(decimal)2.00},
                    new Tax { TaxCode = "NBT1", TaxName = "NBT1", EffectivePercentage = (decimal)2.04, TaxPercentage =(decimal)2.04},
                };

            taxes.ForEach(u => context.Taxes.Add(u));
            context.SaveChanges();
        }

        //private static void AddTransactionRights(ERPDbContext context)
        //{
        //    // Add Tax
        //    var transactionRights = new List<TransactionRights>
        //        {

        //            new TransactionRights { DocumentID = , TransactionCode = "VAT", TransactionName = "", IsAccess = true, IsPause = true, IsSave = true, IsModify = true, IsDelete = false},
        //            new TransactionRights { DocumentID = , TransactionCode = "VAT", TransactionName = "", IsAccess = true, IsPause = true, IsSave = true, IsModify = true, IsDelete = false},
        //            new TransactionRights { DocumentID = , TransactionCode = "VAT", TransactionName = "", IsAccess = true, IsPause = true, IsSave = true, IsModify = true, IsDelete = false},
        //            new TransactionRights { DocumentID = , TransactionCode = "VAT", TransactionName = "", IsAccess = true, IsPause = true, IsSave = true, IsModify = true, IsDelete = false},
        //            new TransactionRights { DocumentID = , TransactionCode = "VAT", TransactionName = "", IsAccess = true, IsPause = true, IsSave = true, IsModify = true, IsDelete = false},
        //            new TransactionRights { DocumentID = , TransactionCode = "VAT", TransactionName = "", IsAccess = true, IsPause = true, IsSave = true, IsModify = true, IsDelete = false},

        //        };

        //    transactionRights.ForEach(u => context.Taxes.Add(u));
        //    context.SaveChanges();
        //}

        private static void AddUnitOfMeasures(ERPDbContext context)
        {
            // Add Unit of Measure
            var unitOfMeasures = new List<UnitOfMeasure>
                {
                    new UnitOfMeasure { UnitOfMeasureCode = "001", UnitOfMeasureName = "Nos", Remark = "No of Units"},
                };

            unitOfMeasures.ForEach(u => context.UnitOfMeasures.Add(u));
            context.SaveChanges();
        }

        // Add Payment Methods
        private static void AddPaymentMethods(ERPDbContext context)
        {
            var paymentMethods = new List<PaymentMethod>
                {
                    new PaymentMethod { PaymentMethodCode = "001", PaymentMethodName = "CASH", CommissionRate = 0, PaymentType = 0, IsPaymentType = true, IsReceiptType = true, IsDelete = false, GroupOfCompanyID = 0},
                    new PaymentMethod { PaymentMethodCode = "002", PaymentMethodName = "CHEQUE", CommissionRate = 0, PaymentType = 2, IsPaymentType = true, IsReceiptType = true, IsDelete = false, GroupOfCompanyID = 0},
                    new PaymentMethod { PaymentMethodCode = "003", PaymentMethodName = "CREDIT", CommissionRate = 0, PaymentType = 1, IsPaymentType = false, IsReceiptType = false, IsDelete = false, GroupOfCompanyID = 0},
                    new PaymentMethod { PaymentMethodCode = "004", PaymentMethodName = "SET-OFF", CommissionRate = 0, PaymentType = 5, IsPaymentType = true, IsReceiptType = true, IsDelete = false, GroupOfCompanyID = 0},
                    new PaymentMethod { PaymentMethodCode = "005", PaymentMethodName = "THIRD PARTY CHEQUE", CommissionRate = 0, PaymentType = 6, IsPaymentType = true, IsReceiptType = false, IsDelete = false, GroupOfCompanyID = 0},

                };

            paymentMethods.ForEach(u => context.PaymentMethods.Add(u));
            context.SaveChanges();
        }

   
        // Add Currency Codes
        private static void AddCurrencyCodes(ERPDbContext context)
        {
            var currencies = new List<Currency>
                {
					new Currency { CurrencyCode = "LKR", CurrencyDescription = "Sri Lanken Rupees", CurrencyFormat = "Rs" , CurrencySymbol = "LKR", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "USD", CurrencyDescription = "US Dollar", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "EUR", CurrencyDescription = "Euro", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "GBP", CurrencyDescription = "British Pound", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "INR", CurrencyDescription = "Indian Rupees", BuyingRate = 0, SellingRate = 0,  IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "AUD", CurrencyDescription = "Australian Dollar", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "CAD", CurrencyDescription = "Canadian Dollar", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "AED", CurrencyDescription = "Emirati Dirham", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "MYR", CurrencyDescription = "Malaysian Ringgit", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "CHF", CurrencyDescription = "Swiss Franc", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "CNY", CurrencyDescription = "Chinese Yuan Renminbi", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "THB", CurrencyDescription = "Thai Baht", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "SAR", CurrencyDescription = "Saudi Arabian Riyal", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                    new Currency { CurrencyCode = "JPY", CurrencyDescription = "Japanese Yen", BuyingRate = 0, SellingRate = 0, IsDelete = false, GroupOfCompanyID = 0},
                   
                };

            currencies.ForEach(u => context.Currencies.Add(u));
            context.SaveChanges();
        }
        private static void AddSupplierGroups(ERPDbContext context)
        {
            // Add Supplier Groups
            var supplierGroups = new List<SupplierGroup>
                {
                    new SupplierGroup { SupplierGroupCode = "001", SupplierGroupName = "Group 01"},
                };

            supplierGroups.ForEach(g => context.SupplierGroups.Add(g));
            context.SaveChanges();
        }

        private void AddCommissionSchemas(ERPDbContext context)
        {
            var commissionSchemas = new List<CommissionSchema>
            {
                new CommissionSchema {CommissionSchemaCode="001",CommissionSchemaName="Schema Name 001"},
            };
            commissionSchemas.ForEach(c => context.CommissionSchemas.Add(c));
            context.SaveChanges();
        }

        private void AddCostCentres(ERPDbContext context)
        {
            var costCentres = new List<CostCentre>
            {
                new CostCentre {CostCentreCode="001",CostCentreName="Cost Centre 001"},
            };
            costCentres.ForEach(c => context.CostCentres.Add(c));
            context.SaveChanges();
        }

        private static void AddAutoGenerateInfo(ERPDbContext context)
        {
            // Add Sub AutoGenerateInfo
            var autoGenerateInfo = new List<AutoGenerateInfo>
                {
                    #region Common
                    #region common references

                    new AutoGenerateInfo { ModuleType=1, DocumentID=1, FormId = 1, FormName = "FrmCompany" , FormText = "Company" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true},
                    new AutoGenerateInfo { ModuleType=1, DocumentID=2, FormId = 2, FormName = "FrmLocation" , FormText = "Location" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=3, FormId = 3, FormName = "FrmCostCentre" , FormText = "Cost Centers" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=1, DocumentID=4, FormId = 4, FormName = "FrmArea" , FormText = "Area" , Prefix = "A", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=5, FormId = 5, FormName = "FrmTerritory" , FormText = "Territory" , Prefix = "T", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=6, FormId = 6, FormName = "FrmUnitOfMeasure" , FormText = "Unit of Measure" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=7, FormId = 7, FormName = "FrmTypes" , FormText = "Return Types" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=8, FormId = 8, FormName = "FrmTypes" , FormText = "Transfer Types" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=9, FormId = 9, FormName = "FrmProductExtendedProperty" , FormText = "Product Extended Property" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=10, FormId = 10, FormName = "FrmProductExtendedValue" , FormText = "Product Extended Value" , Prefix = "", CodeLength = 5, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true }, 
                    new AutoGenerateInfo { ModuleType=1, DocumentID=11, FormId = 11, FormName = "FrmColour" , FormText = "Colour" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=12, FormId = 12, FormName = "FrmSize" , FormText = "Size" , Prefix = "S", CodeLength = 3, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true }, 
                    new AutoGenerateInfo { ModuleType=1, DocumentID=13, FormId = 13, FormName = "FrmCustomerGroup" , FormText = "Customer Group" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=14, FormId = 14, FormName = "FrmSupplierGroup" , FormText = "Supplier Group" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=15, FormId = 15, FormName = "FrmPaymentMethod" , FormText = "Payment Method" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=16, FormId = 16, FormName = "FrmVehicle" , FormText = "Vehicle" , Prefix = "V", CodeLength = 3, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=17, FormId = 17, FormName = "FrmDriver" , FormText = "Driver" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=18, FormId = 18, FormName = "FrmHelper" , FormText = "Helper" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=19, FormId = 19, FormName = "FrmUserPrivileges" , FormText = "User Privileges" , Prefix = "UP", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=20, FormId = 20, FormName = "FrmLoginUser" , FormText = "Login User" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=21, FormId = 21, FormName = "FrmEmployee" , FormText = "Employee" , Prefix = "E", CodeLength = 6, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = true, CardId = 5, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=22, FormId = 22, FormName = "FrmGroupPrivileges" , FormText = "Group Privileges" , Prefix = "GP", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=23, FormId = 23, FormName = "FrmDesignationType" , FormText = "Employee Designation Type" , Prefix = "D", CodeLength = 3, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=24, FormId = 24, FormName = "FrmManualPasswordChange" , FormText = "Change Password" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=25, FormId = 25, FormName = "FrmBank" , FormText = "Bank" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=26, FormId = 26, FormName = "FrmBankBranch" , FormText = "Bank Branch" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=27, FormId = 27, FormName = "FrmLoanType" , FormText = "Loan Type" , Prefix = "", CodeLength = 2, Suffix =  2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=28, FormId = 28, FormName = "FrmLoanPurpose" , FormText = "Loan Purpose" , Prefix = "", CodeLength = 2, Suffix =  2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=29, FormId = 29, FormName = "FrmChequeBookEntry" , FormText = "Cheque Book Entry" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=30, FormId = 30, FormName = "FrmSlab" , FormText = "Slab" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=31, FormId = 31, FormName = "FrmCurrency" , FormText = "Currency" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=32, FormId = 32, FormName = "FrmTax" , FormText = "Tax" , Prefix = "", CodeLength = 0, Suffix =  0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=33, FormId = 33, FormName = "FrmChequeBookCancel" , FormText = "Cheque Book Cancel" , Prefix = "CBC", CodeLength = 15, Suffix =  12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=34, FormId = 34, FormName = "FrmPaymentTerm" , FormText = "Payment Term" , Prefix = "", CodeLength = 3, Suffix =  3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=35, FormId = 35, FormName = "FrmJobClass" , FormText = "Job / Class" , Prefix = "", CodeLength = 3, Suffix =  3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=1, DocumentID=36, FormId = 36, FormName = "FrmManualPasswordChange" , FormText = "Manual Password Change" , Prefix = "", CodeLength = 3, Suffix =  3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=37, FormId = 37, FormName = "FrmSystemPreference" , FormText = "System Preference" , Prefix = "", CodeLength = 3, Suffix =  3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=1, DocumentID=38, FormId = 38, FormName = "FrmDayEnd" , FormText = "Day End" , Prefix = "", CodeLength = 3, Suffix =  3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                      new AutoGenerateInfo { ModuleType=1, DocumentID=39, FormId = 39, FormName = "FrmCreditCardMaster" , FormText = "Credit Card Master" , Prefix = "", CodeLength = 3, Suffix =  3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },


                    #region common transactions
                    //new AutoGenerateInfo { ModuleType=1, DocumentID=30, FormId = 30, FormName = "" , FormText = "Supplier Payment" , Prefix = "SAO", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    //new AutoGenerateInfo { ModuleType=1, DocumentID=31, FormId = 31, FormName = "" , FormText = "Customer Receipt" , Prefix = "SAI", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    // u can use 501, 502
                    new AutoGenerateInfo { ModuleType=1, DocumentID=503, FormId = 503, FormName = "FrmOpeningStock" , FormText = "Opening Stock" , Prefix = "OS", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=504, FormId = 504, FormName = "FrmDataDownload" , FormText = "Data Download" , Prefix = "DD", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },

                    new AutoGenerateInfo { ModuleType=1, DocumentID=18001, FormId = 18001, FormName = "ShowCostPrice" , FormText = "Show Cost Price" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    new AutoGenerateInfo { ModuleType=1, DocumentID=18002, FormId = 18002, FormName = "ShowSellingPrice" , FormText = "Show Selling Price" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    #endregion
                    #endregion

                    #region Common reports
                    //new AutoGenerateInfo { ModuleType=1, DocumentID=7001, FormId = 7001, FormName = "RptOpeningBalanceRegister" , FormText = "Opening Balance Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    #endregion 

                    #endregion

                    #region Inventory
                    #region inventory & sales referencs
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1001, FormId = 1001, FormName = "FrmSupplier" , FormText = "Supplier" , Prefix = "S", CodeLength = 6, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = true, CardId = 1, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1002, FormId = 1002, FormName = "FrmCustomer" , FormText = "Customer" , Prefix = "C", CodeLength = 6, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = true, CardId = 2, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1003, FormId = 1003, FormName = "FrmDepartment" , FormText = "Department" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1004, FormId = 1004, FormName = "FrmCategory" , FormText = "Category" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1005, FormId = 1005, FormName = "FrmSubCategory" , FormText = "Sub Category" , Prefix = "", CodeLength = 4, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1006, FormId = 1006, FormName = "FrmSubCategory2" , FormText = "Sub Category 2" , Prefix = "", CodeLength = 5, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1007, FormId = 1007, FormName = "FrmProduct" , FormText = "Product" , Prefix = "", CodeLength = 12, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1008, FormId = 1008, FormName = "FrmSalesPerson" , FormText = "Sales Person" , Prefix = "SP", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1009, FormId = 1009, FormName = "FrmPromotionMaster" , FormText = "Promotion Master" , Prefix = "PM", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1010, FormId = 1010, FormName = "FrmInvProductType" , FormText = "Product Type" , Prefix = "T", CodeLength = 6, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    #endregion

                    #region inventory & sales transactions
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1501, FormId = 1501, FormName = "FrmPurchaseOrder" , FormText = "Purchase Order" , Prefix = "PO", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = true, IsRoundOff = true, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1502, FormId = 1502, FormName = "FrmGoodsReceivedNote" , FormText = "Goods Received Note" , Prefix = "GRN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = true, IsRoundOff = true, IsAutoComplete  = true, IsActive = true},
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1503, FormId = 1503, FormName = "FrmPurchaseReturnNote" , FormText = "Purchase Return Note" , Prefix = "PRN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1504, FormId = 1504, FormName = "FrmTransferOfGoodsNote" , FormText = "Transfer of Goods Note" , Prefix = "TOG", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true},
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1505, FormId = 1505, FormName = "FrmStockAdjustment" , FormText = "Stock Adjustment" , Prefix = "SA", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1506, FormId = 1506, FormName = "FrmQuotation" , FormText = "Quotation" , Prefix = "QT", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1507, FormId = 1507, FormName = "FrmSalesOrder" , FormText = "Sales Order" , Prefix = "SO", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1508, FormId = 1508, FormName = "FrmInvoice" , FormText = "Invoice" , Prefix = "I", CodeLength = 15, Suffix = 14, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1509, FormId = 1509, FormName = "FrmSalesReturnNote" , FormText = "Sales Return Note" , Prefix = "SRN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=true, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1510, FormId = 1510, FormName = "FrmDispatchNote" , FormText = "Dispatch Note" , Prefix = "DPN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1511, FormId = 1511, FormName = "FrmBarcode" , FormText = "Barcode" , Prefix = "B", CodeLength = 15, Suffix = 14, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1512, FormId = 1512, FormName = "FrmProductPriceChange" , FormText = "Product Price Change" , Prefix = "PPC", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1513, FormId = 1513, FormName = "FrmProductPriceChangeDamage" , FormText = "Product Price Change Damage" , Prefix = "PPD", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=2, DocumentID=1514, FormId = 1514, FormName = "FrmSampleOut" , FormText = "Sample Out" , Prefix = "SAO", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true  },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=1515, FormId = 1515, FormName = "FrmSampleIn" , FormText = "Sample In" , Prefix = "SAI", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true  },
                    #endregion

                    #region giftvoucher references
                    new AutoGenerateInfo { ModuleType=6, DocumentID=5001, FormId = 5001, FormName = "FrmGiftVoucherGroup" , FormText = "Gift Voucher Group" , Prefix = "G", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=6, DocumentID=5002, FormId = 5002, FormName = "FrmGiftVoucherBookCodeGeneration" , FormText = "Gift Voucher Book Code Generation" , Prefix = "B", CodeLength = 8, Suffix = 7, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=6, DocumentID=5003, FormId = 5003, FormName = "FrmGiftVoucherMaster" , FormText = "Gift Voucher Master" , Prefix = "GVM", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion

                    #region giftvoucher transactions
                    new AutoGenerateInfo { ModuleType=6, DocumentID=5501, FormId = 5501, FormName = "FrmGiftVoucherPurchaseOrder" , FormText = "Gift Voucher Purchase Order" , Prefix = "GPO", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=6, DocumentID=5502, FormId = 5502, FormName = "FrmGiftVoucherGoodsReceivedNote" , FormText = "Gift Voucher Goods Received Note" , Prefix = "GVR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=6, DocumentID=5503, FormId = 5503, FormName = "FrmGiftVoucherTransfer" , FormText = "Gift Voucher Transfer" , Prefix = "GVT", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=6, DocumentID=5504, FormId = 5504, FormName = "FrmGiftVoucherBarcode" , FormText = "Gift Voucher Barcode" , Prefix = "GVB", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    #endregion


                    #region Gift Voucher Reports
                    new AutoGenerateInfo { ModuleType=6, DocumentID=16001, FormId = 16001, FormName = "RptGiftVoucherRegister" , FormText = "Gift Voucher Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    #endregion 

                    #region inventory and sales (sales rep)
                    //new AutoGenerateInfo { ModuleType=2, DocumentID=8001, FormId = 8001, FormName = "RptProductWiseSales" , FormText = "Product Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=8002, FormId = 8002, FormName = "RptSupplierWiseSales" , FormText = "Supplier Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=8003, FormId = 8003, FormName = "RptSalesRegister" , FormText = "Sales Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=8004, FormId = 8004, FormName = "RptSummarySalesBook" , FormText = "Summary Sales Book" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=8005, FormId = 8005, FormName = "RptLocationSales" , FormText = "Location Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=8006, FormId = 8006, FormName = "RptExtendedPropertySalesRegister" , FormText = "Sales Register (Extended Properties)" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=8006, FormId = 8006, FormName = "RptSalesRegisterExt" , FormText = "Sales Register Extended" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },


                    //Check below document id range : 
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17001, FormId = 17001, FormName = "RptUserWiseDiscount" , FormText = "User Wise Discount" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17002, FormId = 17002, FormName = "RptUserMediaTerminal" , FormText = "User Media Terminal" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17003, FormId = 17003, FormName = "RptUserWiseSales" , FormText = "User Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17004, FormId = 17004, FormName = "RptDetailMediaSales" , FormText = "Detail Media Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17005, FormId = 17005, FormName = "RptMediaSalesSummary" , FormText = "Media Sales Summary" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17006, FormId = 17006, FormName = "RptSalesDiscount" , FormText = "Sales Discount" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17007, FormId = 17007, FormName = "RptCreditCardCollection" , FormText = "Credit Card Collection" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },   
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17008, FormId = 17008, FormName = "FrmPosSalesSummary" , FormText = "POS Sales Summary" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17009, FormId = 17009, FormName = "FrmCurrentSales" , FormText = "Current Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17010, FormId = 17010, FormName = "RptStaffCreditSales" , FormText = "Staff Credit Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17015, FormId = 17015, FormName = "FrmBasketAnalysisReport" , FormText = "Basket Analysis Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17016, FormId = 17016, FormName = "FrmSalesReport" , FormText = "Hourly Sales Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    #endregion 

                    #region inventory and sales (purchasing rep)
                    new AutoGenerateInfo { ModuleType=2, DocumentID=9001, FormId = 9001, FormName = "RptPurchaseRegister" , FormText = "Purchase Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=9002, FormId = 9002, FormName = "RptPendingPurchaseOrders" , FormText = "Pending Purchase Orders" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=9003, FormId = 9003, FormName = "RptSupplierWisePerformanceAnalysis" , FormText = "Supplier Wise Performance Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=9004, FormId = 9004, FormName = "RptPurchaseRegisterExt" , FormText = "Purchase Register Extended" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },

                    #endregion 

                    #region inventory and sales (stock rep)
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10001, FormId = 10001, FormName = "RptExcessStockAdjustment" , FormText = "Add Stock Adjustment" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10002, FormId = 10002, FormName = "RptShortageStockAdjustment" , FormText = "Reduce Stock Adjustment" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10003, FormId = 10003, FormName = "RptStockAdjustmentPercentage" , FormText = "Stock Adjustment" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10004, FormId = 10004, FormName = "RptBatchWiseStockAnalysis" , FormText = "Batch Wise Stock Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10005, FormId = 10005, FormName = "RptBatchWiseStockDetails" , FormText = "Batch Wise Stock Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10006, FormId = 10006, FormName = "RptBatchWiseStockBalance" , FormText = "Batch Wise Stock Balance" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10007, FormId = 10007, FormName = "RptProductWiseBatchWiseStockBalance" , FormText = "Product Wise Batch Wise Stock Balance" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10008, FormId = 10008, FormName = "RptAgingOfStockBatchWise" , FormText = "Aging Of Stock Batch Wise" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    //new AutoGenerateInfo { ModuleType=2, DocumentID=10009, FormId = 10009, FormName = "RptShortagePercentageStockAdjustment" , FormText = "Shortage Percentage Stock Adjustment" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10010, FormId = 10010, FormName = "InvRptOpeningBalanceRegister" , FormText = "Inventory Opening Balance Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10011, FormId = 10011, FormName = "InvRptStockBalance" , FormText = "Inventory Stock Balance" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10012, FormId = 10012, FormName = "InvRptBatchStockBalance" , FormText = "Inventory Batch Stock Balance" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10013, FormId = 10013, FormName = "`" , FormText = "Stock Balances (Extended Properties)" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10014, FormId = 10014, FormName = "InvRptTransferRegister" , FormText = "Product Transfer Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10015, FormId = 10015, FormName = "FrmGivenDateStock" , FormText = "Given Date Stock" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10016, FormId = 10016, FormName = "FrmGivenDateStock" , FormText = "Stock Movement Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10501, FormId = 10501, FormName = "RptBatchMaster", FormText = "Batch Master" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17014, FormId = 17014, FormName = "FrmBinCard", FormText = "Stock Movement Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17015, FormId = 17015, FormName = "FrmBasketAnalysisReport", FormText = "Basket Analysis Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=17018, FormId = 17018, FormName = "InvRptSupplierWiseStockMovement", FormText = "Supplier Wise Stock Movement" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },

                    #endregion 

                    // you can use 10009

                    #region inventory and sales (other rep)
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10502, FormId = 10502, FormName = "RptPriceChange", FormText = "Price Change Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10503, FormId = 10503, FormName = "RptProductPriceChangeDetail", FormText = "Price Change Detail Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=10504, FormId = 10504, FormName = "RptProductPriceChangeDamageDetail", FormText = "Price Change Damage Detail Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    #endregion 
                    #endregion
                    
                    #region NonTrading
                    #region non trading references
                    //pls keep different prefix with inventory supplier
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2001, FormId = 2001, FormName = "FrmLogisticSupplier" , FormText = "Logistic Supplier" , Prefix = "", CodeLength = 5, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = true, CardId = 4, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2002, FormId = 2002, FormName = "FrmLogisticDepartment" , FormText = "Logistic Department" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2003, FormId = 2003, FormName = "FrmLogisticCategory" , FormText = "Logistic Category" , Prefix = "", CodeLength = 4, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2004, FormId = 2004, FormName = "FrmLogisticSubCategory" , FormText = "Logistic Sub Category" , Prefix = "", CodeLength = 4, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2005, FormId = 2005, FormName = "FrmLogisticSubCategory2" , FormText = "Logistic Sub Category 2" , Prefix = "", CodeLength = 4, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2006, FormId = 2006, FormName = "FrmLogisticProduct" , FormText = "Logistic Product" , Prefix = "", CodeLength = 14, Suffix = 14, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion

                    #region non trading transactions
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2501, FormId = 2501, FormName = "FrmLogisticQuotation" , FormText = "Logistic Quotation" , Prefix = "LQT", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2502, FormId = 2502, FormName = "FrmLogisticPurchaseOrder" , FormText = "Logistic Purchase Order" , Prefix = "LPO", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=true, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2503, FormId = 2503, FormName = "FrmLogisticGoodsReceivedNote" , FormText = "Logistic Goods Received Note" , Prefix = "LGR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2504, FormId = 2504, FormName = "FrmLogisticPurchaseReturnNote" , FormText = "Logistic Purchase Return Note" , Prefix = "LPR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2505, FormId = 2505, FormName = "FrmLogisticTransferOfGoodsNote" , FormText = "Logistic Transfer of Goods Note" , Prefix = "LTR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2506, FormId = 2506, FormName = "FrmLogisticStockAdjustment" , FormText = "Logistic Stock Adjustment" , Prefix = "LSA", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2507, FormId = 2507, FormName = "FrmMaterialRequestNote" , FormText = "Material Request Note" , Prefix = "MRN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2508, FormId = 2508, FormName = "FrmMaterialAllocationNote" , FormText = "Material Allocation Note" , Prefix = "MAN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2509, FormId = 2509, FormName = "FrmMaterialConsumptionNote" , FormText = "Material Consumption Note" , Prefix = "MCN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2510, FormId = 2510, FormName = "FrmMaintenanceJobRequisitionNote" , FormText = "Maintenance Job Requisition Note" , Prefix = "MJR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2511, FormId = 2511, FormName = "FrmMaintenanceJobAssignNote" , FormText = "Maintenance Job Assign Note" , Prefix = "MJA", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2512, FormId = 2512, FormName = "FrmServiceOut" , FormText = "Service Out" , Prefix = "SA", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2513, FormId = 2513, FormName = "FrmServiceIn" , FormText = "Service In" , Prefix = "SI", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2514, FormId = 2514, FormName = "FrmLogisticTransactionSearch" , FormText = "Logistic Transaction Panel" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },


                    new AutoGenerateInfo { ModuleType=3, DocumentID=2515, FormId = 2515, FormName = "FrmLogisticSampleOut" , FormText = "Logistic Sample Out" , Prefix = "LSO", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true  },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=2516, FormId = 2516, FormName = "FrmLogisticSampleIn" , FormText = "Logistic Sample In" , Prefix = "LSI", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true  },
                    #endregion

                    #region Non Trading (purchasing rep) Purchase 11001:12000
                    //new AutoGenerateInfo { ModuleType=3, DocumentID=11001, FormId = 11001, FormName = "RptPurchaseRegister" , FormText = "Purchase Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    //new AutoGenerateInfo { ModuleType=2, DocumentID=11002, FormId = 11002, FormName = "RptPurchaseReturnRegister" , FormText = "Purchase Return Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=11002, FormId = 11002, FormName = "RptLgsPendingPurchaseOrders" , FormText = "Logistic - Pending Purchase Orders" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },

                    //Statement
                    new AutoGenerateInfo { ModuleType=3, DocumentID=11003, FormId = 11003, FormName = "RptLgsSupplierStatement" , FormText = "Logistic - Supplier Statement" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },

                    #endregion 

                    #region Non trading (stock rep) Stock 12001:12500
                    new AutoGenerateInfo { ModuleType=3, DocumentID=12010, FormId = 12010, FormName = "LgsRptOpeningBalanceRegister" , FormText = "Logistic Opening Balance Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=12011, FormId = 12011, FormName = "LgsRptStockBalance" , FormText = "Logistic Stock Balance" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=12012, FormId = 12012, FormName = "LgsRptTransferRegister" , FormText = "Logistic Product Transfer Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=3, DocumentID=12013, FormId = 12013, FormName = "FrmLogistciBinCard", FormText = "Logistic Stock Movement Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    
                    
                    #endregion
                    #endregion

                    #region Account
                    #region accounts reference
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4001, FormId = 4001, FormName = "FrmPettyCashMasterCreation" , FormText = "Petty Cash Master Creation" , Prefix = "P", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    //will change as 01
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4002, FormId = 4002, FormName = "FrmLinkedAccount" , FormText = "Linked Account" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4003, FormId = 4003, FormName = "FrmChartOfAccounts" , FormText = "Chart Of Accounts" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    //4004 --> @ Tools Menu
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4005, FormId = 4005, FormName = "FrmBudget" , FormText = "Budget" , Prefix = "BG", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    #endregion

                    #region accounts transactions
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4501, FormId = 4501, FormName = "FrmPettyCashReimbursement" , FormText = "Petty Cash Reimbursement" , Prefix = "PCR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4502, FormId = 4502, FormName = "FrmPettyCashIOU" , FormText = "Petty Cash IOU" , Prefix = "IOU", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4503, FormId = 4503, FormName = "FrmPettyCashBillEntry" , FormText = "Petty Cash Bill Entry" , Prefix = "PBE", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4504, FormId = 4504, FormName = "FrmPettyCashPayment" , FormText = "Petty Cash Payment" , Prefix = "PCP", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    // u can use 4505
                    //new AutoGenerateInfo { ModuleType=5, DocumentID=4505, FormId = 4505, FormName = "FrmPettyCashPaymentUpdate" , FormText = "Petty Cash Payment Process" , Prefix = "PPU", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4506, FormId = 4506, FormName = "FrmPayment" , FormText = "Payment Voucher" , Prefix = "PY", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = true, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4507, FormId = 4507, FormName = "FrmLedgerOpeningBalances" , FormText = "Ledger Opening Balances" , Prefix = "LOP", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4508, FormId = 4508, FormName = "FrmJournalEntry" , FormText = "Journal Entry" , Prefix = "JE", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4509, FormId = 4509, FormName = "FrmCreditNote" , FormText = "Credit Note" , Prefix = "CRN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4510, FormId = 4510, FormName = "FrmDebitNote" , FormText = "Debit Note" , Prefix = "DRN", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    //4511--> @ Tools Menu
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4513, FormId = 4512, FormName = "FrmBillEntry" , FormText = "Bill Entry" , Prefix = "BE", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4514, FormId = 4513, FormName = "FrmLoanEntry" , FormText = "Loan Entry" , Prefix = "LE", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4515, FormId = 4515, FormName = "FrmAccountsReconciliation" , FormText = "Bank Reconciliation" , Prefix = "ARC", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4516, FormId = 4516, FormName = "FrmBankDeposit" , FormText = "Bank Deposit" , Prefix = "BD", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4517, FormId = 4517, FormName = "FrmChequeReturn" , FormText = "Cheque Return" , Prefix = "CQR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4518, FormId = 4518, FormName = "FrmReceipt" , FormText = "Receipt" , Prefix = "RE", CodeLength = 15, Suffix = 13, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4519, FormId = 4519, FormName = "FrmChequePrint" , FormText = "Cheque Print" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4520, FormId = 4520, FormName = "FrmChequeCancel" , FormText = "Cheque Cancel" , Prefix = "CQC", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = true, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion

                    #region Tools
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4004, FormId = 4004, FormName = "FrmSalesDownloadSettings" , FormText = "Sales Download Settings" , Prefix = "DS", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=5, DocumentID=4511, FormId = 4511, FormName = "FrmSalesDownload" , FormText = "Sales Download" , Prefix = "SD", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },                    
					new AutoGenerateInfo { ModuleType=5, DocumentID=4521, FormId = 4521, FormName = "FrmThirdPartyDataDownload" , FormText = "Third Party Download" , Prefix = "PD", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },                    
                    new AutoGenerateInfo { ModuleType=5, DocumentID=4522, FormId = 4522, FormName = "FrmAccountDataDownload" , FormText = "Data Download" , Prefix = "TD", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },                    
                    #endregion

                    #region Accounts Reports
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14001, FormId = 14001, FormName = "RptReceiptsRegister" , FormText = "Receipts Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14002, FormId = 14002, FormName = "RptLedgerDetail" , FormText = "Ledger List" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14003, FormId = 14003, FormName = "RptTrialBalance" , FormText = "Trial Balance" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=5, DocumentID=14004, FormId = 14004, FormName = "RptSupplierStatement" , FormText = "Supplier Statement" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14005, FormId = 14005, FormName = "RptCustomerStatement" , FormText = "Customer Statement" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=5, DocumentID=14006, FormId = 14006, FormName = "RptSupplierAgeAnalysis" , FormText = "Supplier Age Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = true, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14007, FormId = 14007, FormName = "RptCustomerAgeAnalysis" , FormText = "Customer Age Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = true, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14008, FormId = 14008, FormName = "RptPettyCashRegister" , FormText = "Petty Cash Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=5, DocumentID=14009, FormId = 14009, FormName = "RptPayableChequeDetails" , FormText = "Issued Cheque Details" , Prefix ="RPT" , CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete = true, IsActive = true},
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14010, FormId = 14010, FormName = "RptReceivableChequeDetails", FormText = "Received Cheque Details", Prefix="RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard= false, CardId =0, IsEntry=false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete = true, IsActive = true},
                    new AutoGenerateInfo { ModuleType=5, DocumentID=14011, FormId = 14011, FormName = "RptLedgerView", FormText = "Ledger View", Prefix="RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard= false, CardId =0, IsEntry=false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete = true, IsActive = true},
                    #endregion

                    #endregion  

                    #region CRM
                    #region crm references
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3001, FormId = 3001, FormName = "FrmLoyaltyCustomer" , FormText = "Loyalty Customer" , Prefix = "LC", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = true, CardId = 3, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3002, FormId = 3002, FormName = "FrmCardMaster" , FormText = "Card Types" , Prefix = "CM", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3003, FormId = 3003, FormName = "FrmCardNoGeneration" , FormText = "Card No Generation" , Prefix = "CN", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3004, FormId = 3004, FormName = "FrmManualPointsAdd" , FormText = "Manual Points Add" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3005, FormId = 3005, FormName = "FrmLoyaltyGiftCard" , FormText = "Gift Card" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion 

                    #region crm transactions
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3501, FormId = 3501, FormName = "FrmCardIssue" , FormText = "Card Issue" , Prefix = "CIS", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3502, FormId = 3502, FormName = "FrmLostAndRenew" , FormText = "Lost and Renew" , Prefix = "LAR", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=3503, FormId = 3503, FormName = "FrmCustomerFeedBack" , FormText = "Customer FeedBack" , Prefix = "CFB", CodeLength = 15, Suffix = 12, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion 
                    
                    #region crm ref reports
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13001, FormId = 13001, FormName = "RptCustomerAddress" , FormText = "RptCustomerAddress" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13002, FormId = 13002, FormName = "RptBranchWiseCustomerDetails" , FormText = "Branch Wise Customer Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13003, FormId = 13003, FormName = "RptInActiveCustomerDetails" , FormText = "InActive Customer Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion 
                    
                    #region crm trans reports
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13004, FormId = 13004, FormName = "RptCustomerHistory" , FormText = "Customer History" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13005, FormId = 13005, FormName = "RptCustomerBehavior" , FormText = "Customer Behavior" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13006, FormId = 13006, FormName = "RptCustomervisitdetails" , FormText = "Customer visit details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13007, FormId = 13007, FormName = "RptNumberOfVisitsCustomerWise" , FormText = "Number Of Visits Customer Wise" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13008, FormId = 13008, FormName = "RptCashierWiseLoyaltySummary" , FormText = "Cashier Wise Loyalty Summary" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    new AutoGenerateInfo { ModuleType=4, DocumentID=13009, FormId = 13009, FormName = "RptLocationWiseSummary" , FormText = "Location Wise Summary" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },                  
                    
                    //You can Use 13010 for another one
                    //new AutoGenerateInfo { ModuleType=4, DocumentID=13010, FormId = 13010, FormName = "RptCustomerStatement" , FormText = "CustomerStatement" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13011, FormId = 13011, FormName = "RptBestcustomerdetails" , FormText = "Best customer details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13012, FormId = 13012, FormName = "RptLocationWiseLoyaltyAnalysis" , FormText = "Location Wise Loyalty Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13013, FormId = 13013, FormName = "RptMembershipUpgradesAnalysis" , FormText = "Membership Upgrades Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13014, FormId = 13014, FormName = "RptLostAndRenewalCardAnalysis" , FormText = "Lost And Renewal Card Analysis" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13015, FormId = 13015, FormName = "RptFreeCardIssueDetails" , FormText = "Free Card Issue Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13016, FormId = 13016, FormName = "RptLocationWiseLoyaltySummary" , FormText = "Location Wise Loyalty Summary" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13017, FormId = 13017, FormName = "RptMonthVisitCustomerWise" , FormText = "Month Visit Customer Wise" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13018, FormId = 13018, FormName = "RptMemberShipUpgradeProposalReport" , FormText = "Member Ship Upgrade Proposal Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13019, FormId = 13019, FormName = "RptCardInventory" , FormText = "Card Inventory" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=4, DocumentID=13020, FormId = 13020, FormName = "RptCRMRegister" , FormText = "CRM Register" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion 
                    #endregion

                    #region POS
                    #region Pos Module [1- 6001:6500, 2 - 6501:7000]
                    #region Reference
                    new AutoGenerateInfo { ModuleType=7, DocumentID=6001, FormId = 6001, FormName = "FrmCashier" , FormText = "Cashier" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=7, DocumentID=6002, FormId = 6002, FormName = "FrmCashierGroup" , FormText = "Cashier Group" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion

                    #region reports [17001:18000]
                    new AutoGenerateInfo { ModuleType=7, DocumentID=6003, FormId = 6003, FormName = "RptPOSReceiptSummery" , FormText = "POS Receipt Summary" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=7, DocumentID=17017, FormId = 17017, FormName = "RptPOSReceiptsRegister" , FormText = "POS Receipt Register" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=7, DocumentID=6005, FormId = 6005, FormName = "FrmJournalReader" , FormText = "Journal Reader" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=2, PoIsMandatory=true, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion
                    
                    #endregion 
                    #endregion
                   
                    //new AutoGenerateInfo { ModuleType=1, DocumentID=1, FormId = 1, FormName = "FrmDocumentViewer" , FormText = "Document Viewer" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false },
                    //new AutoGenerateInfo { ModuleType=1, DocumentID=1, FormId = 1, FormName = "FrmPaymentMethodLimit" , FormText = "Payment Method Limit" , Prefix = "", CodeLength = 5, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false },
                    
                    #region Special User Rights
                    #region Inventory
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19001, FormId = 19001, FormName = "ChangeSellingPrice" , FormText = "Change Selling Price" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19002, FormId = 19002, FormName = "ShowCostPrice" , FormText = "Show Cost Price" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19003, FormId = 19003, FormName = "ShowSellingPrice" , FormText = "Show Selling Price" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    //19004 CRM
                    new AutoGenerateInfo { ModuleType=4, DocumentID=19005, FormId = 19005, FormName = "CanChangeCardType" , FormText = "Can Change CRM Card Type" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19006, FormId = 19006, FormName = "ConsignmentBasis" , FormText = "Inventory Consignment Basis" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19007, FormId = 19007, FormName = "ChangePaymentTerm" , FormText = "Inventory Change Payment Term" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    //19008 LGS
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19009, FormId = 19009, FormName = "RptGrossProfitDetails" , FormText = "Gross Profit Details" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19010, FormId = 19010, FormName = "Scan Qty" , FormText = "Scan Qty" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19011, FormId = 19011, FormName = "Activate PO" , FormText = "Activate Purchase Order" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19012, FormId = 19012, FormName = "Sales Summary Percentage" , FormText = "Sales Summary Percentage" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    #endregion

                    #region CRM 
                    new AutoGenerateInfo { ModuleType=2, DocumentID=19004, FormId = 19004, FormName = "ShowQty" , FormText = "Show Qty" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion

                    #region Non Trading - 3
                    new AutoGenerateInfo { ModuleType=3, DocumentID=19008, FormId = 19008, FormName = "ChangePaymentTerm" , FormText = "Logistic Change Payment Term" , Prefix = "USR", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion
                    #endregion

                    #region DashBoard
                    new AutoGenerateInfo { ModuleType=9, DocumentID=50000, FormId = 50000, FormName = "FrmCrmDashBoard" , FormText = "Customer Relation" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=9, DocumentID=50001, FormId = 50001, FormName = "FrmPromotionDashBoard" , FormText = "Promotion" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=9, DocumentID=50002, FormId = 50001, FormName = "FrmSupplierPerformanceDashBoard" , FormText = "Supplier Performance" , Prefix = "", CodeLength = 0, Suffix = 0, AutoGenerete = false, AutoClear = false, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    #endregion

                    #region Hospital Management

                    new AutoGenerateInfo { ModuleType=10, DocumentID=20000, FormId = 20000, FormName = "FrmDoctorRegistration" , FormText = "Doctor" , Prefix = "DR", CodeLength = 5, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=0, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    #endregion

                    #region ARM
                    new AutoGenerateInfo { ModuleType=11, DocumentID=30001, FormId = 30001, FormName = "FrmCustomerCategory" , FormText = "Customer Category" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=11, DocumentID=30002, FormId = 30002, FormName = "FrmCustomerSubCategory" , FormText = "Customer Sub Category" , Prefix = "", CodeLength = 4, Suffix = 4, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=11, DocumentID=30003, FormId = 30003, FormName = "FrmApmCustomer" , FormText = "Customer" , Prefix = "C", CodeLength = 6, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },

                    #endregion

                    # region Restaurent Management

                    // Mater Files
                    new AutoGenerateInfo { ModuleType=15, DocumentID=31001, FormId = 31001, FormName = "FrmBillinglocation" , FormText = "Billinglocation" , Prefix = "", CodeLength = 2, Suffix = 2, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=31002, FormId = 31002, FormName = "FrmResProduct" , FormText = "Product Master" , Prefix = "", CodeLength = 5, Suffix = 5, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=31003, FormId = 31003, FormName = "FrmResSubCategory" , FormText = "Main Layer" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=31004, FormId = 31004, FormName = "FrmResSubCategory2" , FormText = "Sub Layer" , Prefix = "", CodeLength = 3, Suffix = 3, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=false, ReportPrefix="", ReportType=1, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsConsignment = false, IsRoundOff = false, IsAutoComplete  = true, IsActive = true },
                    
                    // Reports
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50751, FormId = 50751, FormName = "RptResSalesRegister" , FormText = "Item Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50752, FormId = 50752, FormName = "RptResItemWiseSales" , FormText = "Item Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50753, FormId = 50753, FormName = "RptResDepartmentWiseSales" , FormText = "Department Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50754, FormId = 50754, FormName = "RptResPaidIn" , FormText = "Paid In" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50755, FormId = 50755, FormName = "RptResPaidOut" , FormText = "Paid Out" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50756, FormId = 50756, FormName = "RptResCategoryWiseSales" , FormText = "Category Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50757, FormId = 50757, FormName = "RptResSubCategoryWiseSales" , FormText = "Sub Category Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50758, FormId = 50758, FormName = "RptResSubCategory2WiseSales" , FormText = "Sub Category2 Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50759, FormId = 50759, FormName = "ResRptInvoiceWiseSales" , FormText = "Invoice Wise Sales" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50760, FormId = 50760, FormName = "RptResKotAndBot" , FormText = "Kot And Bot Report" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50761, FormId = 50761, FormName = "FrmVoidDetails" , FormText = "Void Details" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50762, FormId = 50762, FormName = "ResRptDaySalesSummary" , FormText = "Day Sales Summary" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50763, FormId = 50763, FormName = "RptInvoiceView" , FormText = "Invoice View" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50764, FormId = 50764, FormName = "ResRptDayilySalesTurnover" , FormText = "Dayily Sales Turnover" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    new AutoGenerateInfo { ModuleType=15, DocumentID=50765, FormId = 50765, FormName = "ResRptSalesGroupedReport" , FormText = "Sale (Group)" , Prefix = "RPT", CodeLength = 0, Suffix = 0, AutoGenerete = true, AutoClear = true, IsDepend = false, IsDependCode = false, IsSupplierProduct=false, IsOverWriteQty=false, IsLocationCode=true, ReportPrefix="", ReportType=2, PoIsMandatory=false, IsDispatchRecall=false, IsBackDated = false, IsCard = false, CardId = 0, IsEntry = false, IsSlabReport = false, IsActive = true },
                    #endregion
      
                };

            autoGenerateInfo.ForEach(g => context.AutoGenerateInfos.Add(g));
            context.SaveChanges();
        }

        private static void AddDepartments(ERPDbContext context)
        {
            // Add Departments
            var departments = new List<InvDepartment>
                {
                    new InvDepartment { DepartmentCode = "D01", DepartmentName = "DEPARTMENT NAME D01", Remark = "D01 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvDepartment { DepartmentCode = "D02", DepartmentName = "DEPARTMENT NAME D02", Remark = "D02 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvDepartment { DepartmentCode = "D03", DepartmentName = "DEPARTMENT NAME D03", Remark = "D03 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                };

            departments.ForEach(g => context.InvDepartments.Add(g));
            context.SaveChanges();
        }

        private static void AddLgsDepartments(ERPDbContext context)
        {
            // Add Logistic Departments
            var departments = new List<LgsDepartment>
                {
                    new LgsDepartment { DepartmentCode = "D01", DepartmentName = "DEPARTMENT NAME D01", Remark = "D01 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsDepartment { DepartmentCode = "D02", DepartmentName = "DEPARTMENT NAME D02", Remark = "D02 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsDepartment { DepartmentCode = "D03", DepartmentName = "DEPARTMENT NAME D03", Remark = "D03 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                };

            departments.ForEach(g => context.LgsDepartments.Add(g));
            context.SaveChanges();
        }

        private static void AddCategories(ERPDbContext context)
        {
            // Add Categories
            var categories = new List<InvCategory>
                {
                    new InvCategory { InvDepartmentID = 1, CategoryCode = "D01C01", CategoryName = "CATEGORY NAME D01C01", Remark = "D01C01 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvCategory { InvDepartmentID = 1, CategoryCode = "D01C02", CategoryName = "CATEGORY NAME D01C02", Remark = "D01C02 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvCategory { InvDepartmentID = 3, CategoryCode = "D03C01", CategoryName = "CATEGORY NAME D03C01", Remark = "D03C01 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                };

            categories.ForEach(g => context.InvCategories.Add(g));
            context.SaveChanges();
        }

        private static void AddLgsCategories(ERPDbContext context)
        {
            // Add Logistic Categories
            var categories = new List<LgsCategory>
                {
                    new LgsCategory { LgsDepartmentID = 1, CategoryCode = "D01C01", CategoryName = "CATEGORY NAME D01C01", Remark = "D01C01 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsCategory { LgsDepartmentID = 1, CategoryCode = "D01C02", CategoryName = "CATEGORY NAME D01C02", Remark = "D01C02 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsCategory { LgsDepartmentID = 3, CategoryCode = "D03C01", CategoryName = "CATEGORY NAME D03C01", Remark = "D03C01 Remark", IsDelete = false, GroupOfCompanyID = 0 },
                };

            categories.ForEach(g => context.LgsCategories.Add(g));
            context.SaveChanges();
        }

        private static void AddSubCategories(ERPDbContext context)
        {
            // Add Sub Categories
            var subCategories = new List<InvSubCategory>
                {
                    new InvSubCategory { InvCategoryID = 1, SubCategoryCode = "SC01", SubCategoryName = "SC01N", Remark = "SC01R", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvSubCategory { InvCategoryID = 2, SubCategoryCode = "SC02", SubCategoryName = "SC02N", Remark = "SC02R", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvSubCategory { InvCategoryID = 1, SubCategoryCode = "SC03", SubCategoryName = "SC03N", Remark = "SC03R", IsDelete = false, GroupOfCompanyID = 0 },
                };

            subCategories.ForEach(g => context.InvSubCategories.Add(g));
            context.SaveChanges();
        }

        private static void AddLgsSubCategories(ERPDbContext context)
        {
            // Add Logistic Sub Categories
            var subCategories = new List<LgsSubCategory>
                {
                    new LgsSubCategory { LgsCategoryID = 1, SubCategoryCode = "SC01", SubCategoryName = "SC01N", Remark = "SC01R", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsSubCategory { LgsCategoryID = 2, SubCategoryCode = "SC02", SubCategoryName = "SC02N", Remark = "SC02R", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsSubCategory { LgsCategoryID = 1, SubCategoryCode = "SC03", SubCategoryName = "SC03N", Remark = "SC03R", IsDelete = false, GroupOfCompanyID = 0 },
                };

            subCategories.ForEach(g => context.LgsSubCategories.Add(g));
            context.SaveChanges();
        }

        private static void AddSubCategories2(ERPDbContext context)
        {
            // Add Sub Categories2
            var subCategories2 = new List<InvSubCategory2>
                {
                    new InvSubCategory2 { InvSubCategoryID = 1, SubCategory2Code = "SC201", SubCategory2Name = "SC201N", Remark = "SC201R", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvSubCategory2 { InvSubCategoryID = 3, SubCategory2Code = "SC202", SubCategory2Name = "SC202N", Remark = "SC202R", IsDelete = false, GroupOfCompanyID = 0 },
                    new InvSubCategory2 { InvSubCategoryID = 2, SubCategory2Code = "SC203", SubCategory2Name = "SC203N", Remark = "SC203R", IsDelete = false, GroupOfCompanyID = 0 },
                };

            subCategories2.ForEach(g => context.InvSubCategories2.Add(g));
            context.SaveChanges();
        }

        private static void AddLgsSubCategories2(ERPDbContext context)
        {
            // Add Logistic Sub Categories2
            var subCategories2 = new List<LgsSubCategory2>
                {
                    new LgsSubCategory2 { LgsSubCategoryID = 1, SubCategory2Code = "SC201", SubCategory2Name = "SC201N", Remark = "SC201R", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsSubCategory2 { LgsSubCategoryID = 3, SubCategory2Code = "SC202", SubCategory2Name = "SC202N", Remark = "SC202R", IsDelete = false, GroupOfCompanyID = 0 },
                    new LgsSubCategory2 { LgsSubCategoryID = 2, SubCategory2Code = "SC203", SubCategory2Name = "SC203N", Remark = "SC203R", IsDelete = false, GroupOfCompanyID = 0 },
                };

            subCategories2.ForEach(g => context.LgsSubCategories2.Add(g));
            context.SaveChanges();
        }

        private static void AddSuppliers(ERPDbContext context)
        {
            // Add Suppliers
            var suppliers = new List<Supplier>
                {
                    new Supplier { SupplierGroupID = 1, SupplierCode = "S01", SupplierTitle = 1, SupplierName = "S1Name", SupplierType = 1, BillingTelephone = "0451287419", LedgerID = 1, OtherLedgerID = 1},
                    new Supplier { SupplierGroupID = 1, SupplierCode = "S02", SupplierTitle = 2, SupplierName = "S2Name", SupplierType = 1, BillingTelephone = "0451274419", LedgerID = 1, OtherLedgerID = 1},                                        
                };

            suppliers.ForEach(g => context.Suppliers.Add(g));
            context.SaveChanges();
        }

        private static void AddCustomerGroups(ERPDbContext context)
        {
            // Add Customer Groups
            var customerGroups = new List<CustomerGroup>
                {
                    new CustomerGroup { CustomerGroupCode = "001", CustomerGroupName = "Group 01"},
                    new CustomerGroup { CustomerGroupCode = "002", CustomerGroupName = "Group 02"},
                    new CustomerGroup { CustomerGroupCode = "003", CustomerGroupName = "Group 03"},
                };

            customerGroups.ForEach(g => context.CustomerGroups.Add(g));
            context.SaveChanges();
        }

        private static void AddAreas(ERPDbContext context)
        {
            var areas = new List<Area>
                {
                    new Area { AreaCode = "001", AreaName = "Area 01" ,Remark = "D03R", IsDelete = false, GroupOfCompanyID = 0 },
                    new Area { AreaCode = "002", AreaName = "Area 02" ,Remark = "D03R", IsDelete = false, GroupOfCompanyID = 0 },
                    new Area { AreaCode = "003", AreaName = "Area 03" ,Remark = "D03R", IsDelete = false, GroupOfCompanyID = 0 },
                };

            areas.ForEach(a => context.Areas.Add(a));
            context.SaveChanges();
        }

        private static void AddTerritorys(ERPDbContext context)
        {
            var territorys = new List<Territory>
                {
                    new Territory { TerritoryCode = "001", TerritoryName = "Territory 01",  IsDelete = false, GroupOfCompanyID = 0 ,AreaID = 1},
                    new Territory { TerritoryCode = "002", TerritoryName = "Territory 02",  IsDelete = false, GroupOfCompanyID = 0 ,AreaID = 1},
                    new Territory { TerritoryCode = "003", TerritoryName = "Territory 03",  IsDelete = false, GroupOfCompanyID = 0 ,AreaID = 1},
                };
            territorys.ForEach(t => context.Territories.Add(t));
            context.SaveChanges();
        }

        private static void AddBrokers(ERPDbContext context)
        {
            var brokers = new List<Broker>
                {
                    new Broker { BrokerCode = "001", BrokerName = "Broker 01", IsDelete = false, GroupOfCompanyID = 0 },
                    new Broker { BrokerCode = "002", BrokerName = "Broker 02",  IsDelete = false, GroupOfCompanyID = 0 },
                    new Broker { BrokerCode = "003", BrokerName = "Broker 03",  IsDelete = false, GroupOfCompanyID = 0 },
                };

            brokers.ForEach(a => context.Brokers.Add(a));
            context.SaveChanges();
        }

        private static void AddProductCodeDependancy(ERPDbContext context)
        {
            var productCodeDependanciey = new List<ProductCodeDependancy> 
                {
                    new ProductCodeDependancy { FormName = "FrmProduct", DependOnDepartment = true, DependOnCategory = true, DependOnSubCategory = true, DependOnSubCategory2 = false  },
                    new ProductCodeDependancy { FormName = "FrmLogisticProduct", DependOnDepartment = true, DependOnCategory = true, DependOnSubCategory = true, DependOnSubCategory2 = false  },
                };

            productCodeDependanciey.ForEach(a => context.ProductCodeDependancies.Add(a));
            context.SaveChanges();
        }

        private static void AddGroupOfCompany(ERPDbContext context)
        {
            //remove inactive groupofcompany names
            var groupOfCompanies = new List<GroupOfCompany>
            {
                new GroupOfCompany {GroupOfCompanyCode="1", GroupOfCompanyName="Manjari", IsInventory = true, IsCrm = false, IsGeneralLedger = true, IsManufacture =  false, IsLogistic = true, IsHirePurchase = false, IsHrManagement = false, IsApparelManufacture = false, IsActive = false, IsDelete = false, CreatedUser = "ADMIN", ModifiedUser = "ADMIN", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now},
            };
            groupOfCompanies.ForEach(g => context.GroupOfCompanies.Add(g));
            context.SaveChanges();
        }

        private static void AddCompany(ERPDbContext context)
        {
            var companies = new List<Company>
            {
                //new Company {GroupOfCompanyID= 1,CostCentreID=1, CompanyCode= "C0001", CompanyName ="SARSA SOFT SOLUTIONS",OtherBusinessName1="Name 01",OtherBusinessName2 = "Name 02", OtherBusinessName3 = "Name 03",},
            };
            companies.ForEach(g => context.Companies.Add(g));
            context.SaveChanges();
        }

        private static void AddLocation(ERPDbContext context)
        {
            var locations = new List<Location>
            {
                // new Location {GroupOfCompanyCode="GC01",GroupOfCompanyName="RIT TRADING PVT(LTD)"},
            };
            locations.ForEach(g => context.Locations.Add(g));

            context.SaveChanges();
        }

        private static void AddGiftVoucherGroup(ERPDbContext context)
        {
            // Add Gift Voucher Group
            var invGiftVoucherMasterGroups = new List<InvGiftVoucherGroup>
                {
                    new InvGiftVoucherGroup { GiftVoucherGroupCode = "001", GiftVoucherGroupName = "GROUP 01", Remark = "GROUP 01"},
                    new InvGiftVoucherGroup { GiftVoucherGroupCode = "002", GiftVoucherGroupName = "GROUP 02", Remark = "GROUP 02"},
                    new InvGiftVoucherGroup { GiftVoucherGroupCode = "003", GiftVoucherGroupName = "GROUP 03", Remark = "GROUP 03"},
                };

            invGiftVoucherMasterGroups.ForEach(u => context.InvGiftVoucherGroups.Add(u));
            context.SaveChanges();
        }

        private static void AddGiftVoucherBook(ERPDbContext context)
        {
            // Add Gift Voucher Book
            var invGiftVoucherMasterBooks = new List<InvGiftVoucherBookCode>
                {
                    new InvGiftVoucherBookCode { BookCode = "001", BookName = "VOUCHER 500", InvGiftVoucherGroupID = 1, GiftVoucherValue = 500, PageCount = 10, StartingNo = 1, CurrentSerialNo = 1, SerialLength = 8, BookPrefix = "1V"},
                    new InvGiftVoucherBookCode { BookCode = "002", BookName = "VOUCHER 500", InvGiftVoucherGroupID = 3, GiftVoucherValue = 500, PageCount = 15, StartingNo = 6, CurrentSerialNo = 1, SerialLength = 8, BookPrefix = "1B"},
                    new InvGiftVoucherBookCode { BookCode = "003", BookName = "VOUCHER 1000", InvGiftVoucherGroupID = 1, GiftVoucherValue = 1000, PageCount = 25, StartingNo = 1, CurrentSerialNo = 1, SerialLength = 8, BookPrefix = "1C"},
                };

            invGiftVoucherMasterBooks.ForEach(u => context.InvGiftVoucherBookCodes.Add(u));
            context.SaveChanges();
        }


        //        SELECT * FROM
        //    (SELECT ROW_NUMBER() 
        //        OVER (ORDER BY Salary) AS Row, 
        //        EmployeeId, EmployeeName, Salary 
        //    FROM Employees) AS EMP
        //WHERE Row = 4

        #endregion
    }
}
