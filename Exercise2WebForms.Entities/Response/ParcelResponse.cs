using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2WebForms.Entities.Response
{
    public class ParcelResponse 
    {
        public int ParcelID { get; set; }
        public string Title { get; set; }
        public decimal TotalWeight { get; set; }
        public ParcelCalculatorResponse Info { get; set; }
        public string CreatedDate { get; set; }
    }
}
