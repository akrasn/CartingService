using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CartingService.Api.BLL.Models;
using DAL.Repository;

namespace BLL.Service
{
    public class CartService : ICartService
    {
      // private IGenericLiteRepository<DAL.Models.Cart> cartGenericRepository;
        private ICartingRepository cartRepository;
        private readonly IMapper mapper;

        public CartService(IMapper mapper,  ICartingRepository cartRepository)
        {
            this.mapper = mapper;
           // this.cartGenericRepository = cartGenericRepository;
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
                cartId = cartRepository.Insert(cart);
            }
            else
            {
                cartRepository.Update(cart);
            }

            return cartId;
        }

        public void UpdateProduct(UpdateProduct updateProduct)
        {
            var updateProducts = cartRepository.FindProducts(updateProduct.Id);
            foreach (var item in updateProducts)
            {
                item.Product.Image = updateProduct.Image;
                item.Product.Name = updateProduct.Name;
                item.Product.Price = updateProduct.Price;
                cartRepository.Update(item);

                // cartGenericRepository.Update(item);
            }
        }

        public bool Update(CartingService.Api.BLL.Models.Cart cartBS)
        {
            var cart = mapper.Map<DAL.Models.Cart>(cartBS);
            return cartRepository.Update(cart);
            //return cartGenericRepository.Update(cart);
        }

    }
}
