using CartingService.Api.BLL.Models;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Service
{
    public interface ICartService
    {
        int Delete(int id);
        int DeleteItem(int clientId, int itemId);
        IEnumerable<CartingService.Api.BLL.Models.Cart> FindAll();
        IEnumerable<CartingService.Api.BLL.Models.Cart> FindCart(int id);
        int Insert(CartingService.Api.BLL.Models.Cart cart);
        bool Update(CartingService.Api.BLL.Models.Cart cart);
    }
}
