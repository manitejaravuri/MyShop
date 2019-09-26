using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
   public class productCategory
    {
        public string Id { get; set; }

        public string Category { get; set; }

        public productCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
