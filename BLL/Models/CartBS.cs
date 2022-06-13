using DAL.Repository;
using System;

namespace CartingService.Api.BLL.Models
{
    public class CartBS
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public ProductBS product { get; set; }

    }
}
