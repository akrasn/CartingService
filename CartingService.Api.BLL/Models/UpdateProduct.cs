using System;
using System.Collections.Generic;
using System.Text;

namespace CartingService.Api.BLL.Models
{
   public class UpdateProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
