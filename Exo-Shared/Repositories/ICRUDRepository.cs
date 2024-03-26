using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_Shared.Repositories
{
    public interface ICRUDRepository<TEntity, TKey> where TEntity : class
    {

        //CREATE
        public TEntity Insert(TEntity entity);

        //RETRIEVE
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(TKey id);
        public IEnumerable<TEntity> GetMany(Func<TEntity,bool> predicate);
        public TEntity GetOne(Func<TEntity,bool> predicate);

        //UPDATE
        public TEntity Update(TKey id, TEntity entity);

        //DELETE
        public void Delete(TKey id);
    }
}
