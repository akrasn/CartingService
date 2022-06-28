using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface ICartingRepository
    {
        int Delete(int id);
        int DeleteItem(int clientId, int itemId);
        IEnumerable<Cart> FindAll();
        Cart FindCartOne(int id);
        IEnumerable<Cart> FindCart(int id);
        int Insert(Cart entity);
        bool Update(Cart entity);
    }
}
