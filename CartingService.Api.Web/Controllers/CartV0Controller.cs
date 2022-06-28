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

        [HttpGet("{id}", Name = "FindOne")]
        public IEnumerable<Api.Web.Models.CartProducts> Get(int id)
        {
            var cartBS = cartService.FindCart(id);
            var cartsUI = mapper.Map<IList<Api.Web.Models.CartProducts>>(cartBS);
            return cartsUI;
        }

        [HttpPost]
        public ActionResult<Api.Web.Models.CartProducts> Insert(Api.Web.Models.CartProducts dto)
        {
            var cartBS = mapper.Map<Api.BLL.Models.Cart>(dto);
            var id = cartService.Insert(cartBS);
            if (id != default)
                return Ok(dto);
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = cartService.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id:int}/item/{itemId:int}")]
        public ActionResult DeleteItem(int id, int itemId)
        {
            var result = cartService.DeleteItem(id, itemId);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
