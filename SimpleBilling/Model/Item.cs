using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBilling.Model
{
    class Item
    {
        [Key]
        public int Id { get; set; }
        public string  Code { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
        public Category Categories { get; set; }


    }
}
