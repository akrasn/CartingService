using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CartingService.Api.BLL.Models;

namespace BLL.Service
{
    public class CartService : ICartService
    {
        private IGenericLiteRepository<Cart> cartGenericRepository;
        private ICartingRepository cartRepository;
        private readonly IMapper mapper;

        public CartService(IMapper mapper, IGenericLiteRepository<Cart> cartGenericRepository, ICartingRepository cartRepository)
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
        public IEnumerable<CartBS> FindAll()
        {
            var carts = cartGenericRepository.FindAll();
            var cartsBS = mapper.Map<IList<CartBS>>(carts);
           
            return cartsBS;
        }

        public CartBS FindOne(int id)
        {
            var cart = cartRepository.FindCartOne(id);
            var cartBS = mapper.Map<CartBS>(cart);
            return cartBS;
        }

        public IEnumerable<CartBS> FindCart(int id)
        {
            var carts = cartRepository.FindCart(id);
            var CartsBS = mapper.Map<IList<CartBS>>(carts);
            return CartsBS;
        }

        public int Insert(CartBS cartBS)
        {
            var cartId = cartBS.Id;
            var cartItems = cartRepository.FindCart(cartBS.ClientId);
            var product = cartItems.FirstOrDefault(_ =>_.product.Id == cartBS.product.Id);
            var cart = mapper.Map<Cart>(cartBS);
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

        public bool Update(CartBS cartBS)
        {
            var cart = mapper.Map<Cart>(cartBS);
            return cartGenericRepository.Update(cart);
        }

    }
}
