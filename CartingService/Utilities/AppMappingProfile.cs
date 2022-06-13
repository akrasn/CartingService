using AutoMapper;
using CartingService.Api.BLL.Models;
using CartingService.Api.Web.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartingService.Api.Web.Utilities
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Cart, CartBS>().ReverseMap();
            CreateMap<Product, ProductBS>().ReverseMap();
            CreateMap<CartBS, CartUI>().ReverseMap();
            CreateMap<ProductBS, ProductUI>().ReverseMap();
        }
    }
}
