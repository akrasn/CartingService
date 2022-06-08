using DAL.Models;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Service
{
    public class CartService : ICartService
    {
        private IGenericLiteRepository<Cart> cartGenericRepository;
        private ICartingRepository cartRepository;

        public CartService(IGenericLiteRepository<Cart> cartGenericRepository, ICartingRepository cartRepository)
        {
            this.cartGenericRepository = cartGenericRepository;
            this.cartRepository = cartRepository;
        }

        public int Delete(int id)
        {
            return cartGenericRepository.Delete(id);
        }

        public int DeleteItem(int clientId, int itemId)
        {
            return cartRepository.DeleteItem(clientId, itemId);
        }
        public IEnumerable<Cart> FindAll()
        {
            var result = cartGenericRepository.FindAll();
            return result;
        }

        public Cart FindOne(int id)
        {
            return cartRepository.FindCartOne(id);
        }

        public IEnumerable<Cart> FindCart(int id)
        {
            return cartRepository.FindCart(id);
        }

        public int Insert(Cart cart)
        {
            var cartId = cart.Id;
            var cartItems = cartRepository.FindCart(cart.ClientId);
            var product = cartItems.FirstOrDefault(_ =>_.product.Id == cart.product.Id);

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

        public bool Update(Cart cart)
        {
            return cartGenericRepository.Update(cart);
        }

    }
}
