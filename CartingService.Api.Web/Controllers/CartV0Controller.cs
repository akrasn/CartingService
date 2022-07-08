using AutoMapper;
using BLL.Service;
using CartingService.Api.BLL.Models;
using CartingService.Api.Web.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CartingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartV0Controller : ControllerBase
    {
        private readonly ILogger<CartV0Controller> logger;
        private readonly IMapper mapper;
        private readonly ICartService cartService;

        public CartV0Controller(IMapper mapper, ILogger<CartV0Controller> logger, ICartService cartService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.cartService = cartService;
        }

        [HttpGet]
        public IEnumerable<Api.Web.Models.Cart> Get()
        {
            var cartsBS = cartService.FindAll();
            var cartsUI = mapper.Map<IList<Api.Web.Models.Cart>>(cartsBS);

            return cartsUI;
        }
    }
}
