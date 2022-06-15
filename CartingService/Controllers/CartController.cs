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
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> logger;
        private readonly IMapper mapper;
        private readonly ICartService cartService;

        public CartController(IMapper mapper, ILogger<CartController> logger, ICartService cartService)
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
        public ActionResult<Api.Web.Models.Cart> Get(int id)
        {
            var cartBS = cartService.FindCart(id);
            var cartUI = mapper.Map<Api.Web.Models.Cart>(cartBS);
            if (cartUI != default)
                return Ok(cartUI);
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Api.Web.Models.Cart> Insert(Api.Web.Models.Cart dto)
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
