using CartingService.Api.BLL.Models;
using DAL.Repository;
using System;

namespace CartingService.Api.Web.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public Product product { get; set; }

    }
}
