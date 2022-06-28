using DAL.Repository;
using System;

namespace DAL.Models
{
    public class Cart : BaseLiteEntity
    {
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public Product Product { get; set; }

    }
}
