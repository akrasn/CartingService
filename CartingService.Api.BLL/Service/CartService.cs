using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CartingService.Api.BLL.Models;
using DAL.Repository;

namespace BLL.Service
{
    public class CartService : ICartService
    {
        private IGenericLiteRepository<DAL.Models.Cart> cartGenericRepository;
        private ICartingRepository cartRepository;
        private readonly IMapper mapper;

        public CartService(IMapper mapper, IGenericLiteRepository<DAL.Models.Cart> cartGenericRepository, ICartingRepository cartRepository)
        {
            this.mapper = mapper;
            this.cartGenericRepository = cartGenericRepository;
            this.cartRepository = cartRepository;
        }

        public int Delete(int id)
        {
            return cartRepository.Delete(id);
        }

        public int DeleteItem(int clientId, int itemId)
        {
            return cartRepository.DeleteItem(clientId, itemId);
        }
        public IEnumerable<CartingService.Api.BLL.Models.Cart> FindAll()
        {
            var carts = cartRepository.FindAll();
            var cartsBS = mapper.Map<IList<CartingService.Api.BLL.Models.Cart>>(carts);
           
            return cartsBS;
        }

        public CartingService.Api.BLL.Models.Cart FindOne(int id)
        {
            var cart = cartRepository.FindCartOne(id);
            var cartBS = mapper.Map<CartingService.Api.BLL.Models.Cart>(cart);
            return cartBS;
        }

        public IEnumerable<CartingService.Api.BLL.Models.Cart> FindCart(int id)
        {
            var carts = cartRepository.FindCart(id);
            var CartsBS = mapper.Map<IList<CartingService.Api.BLL.Models.Cart>>(carts);
            return CartsBS;
        }

        public int Insert(CartingService.Api.BLL.Models.Cart cartBS)
        {
            var cartId = cartBS.Id;
            var cartItems = cartRepository.FindCart(cartBS.ClientId);
            var product = cartItems.FirstOrDefault(_ =>_.Product.Id == cartBS.Product.Id);
            var cart = mapper.Map<DAL.Models.Cart>(cartBS);
            if (product == null)
            {
                cartId = cartGenericRepository.Insert(cart);
            }
            else
            {
                cartGenericRepository.Update(cart);
            }

            return cartId;
        }

        public bool Update(CartingService.Api.BLL.Models.Cart cartBS)
        {
            var cart = mapper.Map<DAL.Models.Cart>(cartBS);
            return cartGenericRepository.Update(cart);
        }

    }
}
