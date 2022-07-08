using AutoMapper;
using BLL.Service;
using CartingService.Api.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartingService.Api.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
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

        //Get cart info.
        //Input params: cart unique Key(string).
        //Returns a cart model(cart key + list of cart items).
        
        [HttpGet("v1/{key}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartProducts))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int key)
        {
            var cartProducts = cartService.FindCart(key);
            if (cartProducts.Any())
            {
                var cartProduct = cartProducts.FirstOrDefault();
                var cart = new CartProducts()
                {
                    Id = cartProduct.Id,
                    ClientId = cartProduct.ClientId,
                    Quantity = cartProduct.Quantity
                 };
                var products = new List<CartingService.Api.Web.Models.Product>();
                foreach (var item in cartProducts)
                {
                    var product = mapper.Map<Api.Web.Models.Product>(item.Product);
                    string authority = Request.Path.ToString();

                    var request = Request;
                    var uriBuilder = new UriBuilder
                    {
                        Host = request.Host.Host,
                        Scheme = request.Scheme,
                        Path = $"v1/DeleteItem/{cartProduct.ClientId}/item/{product.Id}"
                    };

                    if (request.Host.Port.HasValue)
                        uriBuilder.Port = request.Host.Port.Value;

                    product.DeleteItemUrl = uriBuilder.Uri.ToString();

                    products.Add(product);
                }

                cart.Products = products;
                return Ok(cart);
            }
            return NotFound();
        }

        //Add item to cart.
        //Input params: cart unique Key (string) + cart item model.
        //Returns 200 if item was added to the cart. If there was no cart for specified key – creates it. Otherwise returns a corresponding HTTP code.
        [HttpPost]
        [Route("v1/AddItem")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartProducts))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public IActionResult Insert(Cart dto)
        {
            if (dto == null)
            {
                return ValidationProblem(detail: "invalid dto");
            }
            var cartBS = mapper.Map<Api.BLL.Models.Cart>(dto);
            var id = cartService.Insert(cartBS);
            if (id != default)
                return Ok();
            else
                return BadRequest();
        }

        //Delete item from cart.
        //Input params: cart unique key (string) and item id (int).
        //Returns 200 if item was deleted, otherwise returns corresponding HTTP code.
        [HttpDelete("v1/DeleteItem/{clientId:int}/item/{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public ActionResult DeleteItem(int clientId, int itemId)
        {
            if (clientId < 0 || itemId < 0 )
            {
                return ValidationProblem(detail: "invalid clientId or itemId");
            }

            var result = cartService.DeleteItem(clientId, itemId);
            
            if (result > 0)
                return Ok();
            else
                return NotFound();
        }

        //Version 2 – the same as Version 1 but with the following changes:
        //a.Get cart info.
        //Returns a list of cart items instead of cart model.
        [HttpGet("v2/{key}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CartingService.Api.Web.Models.Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public IActionResult V2Get(int key)
        {
            var cartProducts = cartService.FindCart(key);
            if (cartProducts.Any())
            {
                var products = new List<CartingService.Api.Web.Models.Product>();
                foreach (var item in cartProducts)
                {
                    var product = mapper.Map<Api.Web.Models.Product>(item.Product);
                    products.Add(product);
                }

                return Ok(products);
            }

            return NotFound();
        }
    }
}
