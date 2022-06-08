using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IGenericLiteRepository<TEntity> where TEntity : BaseLiteEntity
    {
        int Delete(int id);
        IEnumerable<TEntity> FindAll();
        TEntity FindOneId(int id);
        int Insert(TEntity entity);
        bool Update(TEntity entity);
    }
}
