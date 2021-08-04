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
    internal class ERPDbContextInitializer2 : DropCreateDatabaseIfModelChanges<ERPDbContext2>
    {
        #region Methods
        protected override void Seed(ERPDbContext2 context)
        {

        }
 
        #endregion
    }
}
