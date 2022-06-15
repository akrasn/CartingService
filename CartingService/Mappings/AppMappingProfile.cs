using AutoMapper;
using CartingService.Api.BLL.Models;
using CartingService.Api.Web.Models;
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
            CreateMap<DAL.Models.Product, BLL.Models.Product >().ReverseMap();
            CreateMap<Api.Web.Models.Cart, BLL.Models.Cart>().ReverseMap();
            CreateMap<Api.Web.Models.Product, BLL.Models.Product>().ReverseMap();
        }
    }
}
