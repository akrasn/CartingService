using LiteDB;
using System.Linq;
using System.Collections.Generic;
using DAL.DataContext;
using DAL.Models;

namespace DAL.Repository
{
    public class CartingRepository : ICartingRepository
    {
        private LiteDatabase _liteDb;

        public CartingRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public IEnumerable<Cart> FindAll()
        {
            var result = _liteDb.GetCollection<Cart>("Cart").Include(_=>_.Product)
                .FindAll();
            return result;
        }

        public Cart FindCartOne(int id)
        {
            return _liteDb.GetCollection<Cart>("Cart").Include(_ => _.Product)
                .Find(x => x.ClientId == id).FirstOrDefault();
        }

        public IEnumerable<Cart> FindCart(int id)
        {
            return _liteDb.GetCollection<Cart>("Cart")
                .Find(x => x.ClientId == id);
        }

        public IEnumerable<Cart> FindProducts(int id)
        {
            return _liteDb.GetCollection<Cart>("Cart")
                .Find(x => x.Product.Id == id);
        }

        public int Insert(Cart forecast)
        {
            return _liteDb.GetCollection<Cart>("Cart")
                .Insert(forecast);
        }

        public bool Update(Cart forecast)
        {
            return _liteDb.GetCollection<Cart>("Cart")
                .Update(forecast);
        }

        public int DeleteItem(int clientId, int itemId)
        {
            return _liteDb.GetCollection<Cart>("Cart")
                .Delete(x => x.ClientId == clientId & x.Product.Id == itemId);
        }

        public int Delete(int id)
        {
            return _liteDb.GetCollection<Cart>("Cart")
                .Delete(x => x.ClientId == id);
        }
    }
}
