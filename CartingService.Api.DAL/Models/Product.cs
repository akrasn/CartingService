using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Product: IBaseLiteEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

    }
}
