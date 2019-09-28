using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.ViewModels
{
  public  class ProductManagerViewModel
    {
        public productCategory product { get; set; }

        public IEnumerable<productCategory> productCategories { get; set; }

    }
}
