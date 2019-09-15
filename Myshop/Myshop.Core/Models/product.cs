using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
   public class product
    {
        public string id { get; set; }
        [StringLength(20)]
        [DisplayName("product name")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Range(0,10000)]
        public decimal price { get; set; }

        public string categeory { get; set; }

        public string image { get; set; }


        public product()
        {
            this.id = Guid.NewGuid().ToString();
        }
    }
}
