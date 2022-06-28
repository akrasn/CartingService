using DAL.DataContext;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class GenericLiteRepository<TEntity> : IGenericLiteRepository<TEntity> where TEntity : BaseLiteEntity
    {
        private LiteDatabase _liteDb;

        public GenericLiteRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }
        public int Delete(int id)
        {
            return _liteDb.GetCollection<TEntity>().Delete(x => x.Id == id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            var result = _liteDb.GetCollection<TEntity>()
                .FindAll();
            return result;
        }

        public TEntity FindOneId(int id)
        {
            return _liteDb.GetCollection<TEntity>()
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(TEntity entity)
        {
            return _liteDb.GetCollection<TEntity>(entity.GetType().Name).Insert(entity);
        }

        public bool Update(TEntity entity)
        {
            return _liteDb.GetCollection<TEntity>(entity.GetType().Name)
                            .Update(entity);
        }
    }
}
