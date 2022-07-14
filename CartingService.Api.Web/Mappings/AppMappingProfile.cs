using AutoMapper;
using CartingService.Api.BLL.Models;
using CartingService.Api.Web.Models;
using CartingService.Api.Web.Service;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartingService.Api.Web.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DAL.Models.Cart, BLL.Models.Cart >().ReverseMap();
            CreateMap<BLL.Models.Cart, Web.Models.Cart>().ReverseMap();
            //CreateMap<BLL.Models.Cart, Web.Models.CartProducts >().ReverseMap();
            CreateMap<DAL.Models.Product, BLL.Models.Product >().ReverseMap();
            CreateMap<BLL.Models.Product, Api.Web.Models.Product>().ReverseMap();
            CreateMap<UpdateProduct, ProductMessage>().ReverseMap();
        }
    }
}
