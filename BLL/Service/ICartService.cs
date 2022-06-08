using DAL.Models;
using System.Collections.Generic;

namespace BLL.Service
{
    public interface ICartService
    {
        int Delete(int id);
        int DeleteItem(int clientId, int itemId);
        IEnumerable<Cart> FindAll();
        IEnumerable<Cart> FindCart(int id);
        int Insert(Cart cart);
        bool Update(Cart cart);
    }
}
