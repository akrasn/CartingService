using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartingService.Api.Web.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public Product Product { get; set; }
    }
}
