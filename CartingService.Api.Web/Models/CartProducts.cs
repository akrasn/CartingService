using CartingService.Api.BLL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;

namespace CartingService.Api.Web.Models
{
    public class CartProducts
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public IEnumerable<Product>  Products { get; set; }

    }
}
