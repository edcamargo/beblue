using System.Collections.Generic;
using System.Linq;

namespace Beblue.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Método Add
        /// </summary>
        /// <param name="entity"></param>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Método GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// Método GetAll
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Método Update
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Método Remove
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
        

    }
}
