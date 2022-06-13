using CartingService.Api.BLL.Models;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Service
{
    public interface ICartService
    {
        int Delete(int id);
        int DeleteItem(int clientId, int itemId);
        IEnumerable<CartBS> FindAll();
        IEnumerable<CartBS> FindCart(int id);
        int Insert(CartBS cart);
        bool Update(CartBS cart);
    }
}
