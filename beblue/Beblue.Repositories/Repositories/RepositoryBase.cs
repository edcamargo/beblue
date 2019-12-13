using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.Repositories.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly BeblueContext _BeblueContext;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="proteusContext"></param>
        public RepositoryBase(BeblueContext beblueContext)
        {
            this._BeblueContext = beblueContext;
        }

        /// <summary>
        /// Método Add
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Add(TEntity entity)
        {
            _BeblueContext.Set<TEntity>().Add(entity);
            _BeblueContext.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Método Update
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            _BeblueContext.Entry(entity).State = EntityState.Modified;
            _BeblueContext.SaveChanges();
        }

        /// <summary>
        /// Método Remove
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            _BeblueContext.Set<TEntity>().Remove(entity);
            _BeblueContext.SaveChanges();
        }

        /// <summary>
        /// Método GetAll
        /// </summary>
        /// <returns></returns>
        //public List<TEntity> GetAll()
        //{
        //    return _BeblueContext.Set<TEntity>().AsNoTracking().ToList();
        //}

        public IQueryable<TEntity> GetAll()
        {
            return _BeblueContext.Set<TEntity>();
        }

        /// <summary>
        /// Método GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(object id)
        {
            return _BeblueContext.Set<TEntity>().Find(id);
        }

        public void Dispose()
        {
            _BeblueContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
