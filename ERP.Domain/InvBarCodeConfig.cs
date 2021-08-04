using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ERP.Domain
{
    public class InvBarCodeConfig
    {
        public long InvBarCodeConfigID { get; set; }

        [MaxLength(15)]
        public string CostCode { get; set; }
        [MaxLength(15)]
        public string TextFileOrder { get; set; }

        [DefaultValue(0)]
        public bool IsPrintLGD { get; set; } // print last GRN date

    }
}
