using BLL.Service;
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
        private readonly ICartService cartService;

        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            this.logger = logger;
            this.cartService = cartService;
        }

        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return cartService.FindAll();
        }


        [HttpGet("{id}", Name = "FindOne")]
        public ActionResult<Cart> Get(int id)
        {
            var result = cartService.FindCart(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }


        [HttpPost]
        public ActionResult<Cart> Insert(Cart dto)
        {
            var id = cartService.Insert(dto);
            if (id != default)
                return CreatedAtRoute("FindOne", new { id = id }, dto);
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<Cart> Delete(int id)
        {
            var result = cartService.Delete(id);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id:int}/item/{itemId:int}")]
        public ActionResult<Cart> DeleteItem(int id, int itemId)
        {
            var result = cartService.DeleteItem(id, itemId);
            if (result > 0)
                return NoContent();
            else
                return NotFound();
        }
    }
}
