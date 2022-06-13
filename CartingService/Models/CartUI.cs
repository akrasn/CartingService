using CartingService.Api.BLL.Models;
using DAL.Repository;
using System;

namespace CartingService.Api.Web.Models
{
    public class CartUI
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public ProductUI product { get; set; }

    }
}
