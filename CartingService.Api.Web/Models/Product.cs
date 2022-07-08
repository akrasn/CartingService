using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartingService.Api.Web.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public string DeleteItemUrl { get; set; }

    }
}
