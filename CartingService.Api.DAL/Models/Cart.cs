using DAL.Repository;
using System;

namespace DAL.Models
{
    public class Cart : IBaseLiteEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Quantity { get; set; }
        public Product Product { get; set; }
    }
}
