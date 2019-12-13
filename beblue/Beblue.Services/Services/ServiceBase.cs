using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System.Collections.Generic;

namespace Beblue.Services.Services
{
    /// <summary>
    /// Classe que implementa os serviços genéricos.
    /// </summary>
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected IRepositoryBase<TEntity> _RepositoryBase;

        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="repositoryBase"></param>
        /// <param name="context"></param>
        public ServiceBase(IRepositoryBase<TEntity> _repositoryBase)
        {
            _RepositoryBase = _repositoryBase;
        }

        public TEntity Add(TEntity obj)
        {
            return _RepositoryBase.Add(obj);
        }

        public TEntity GetById(object id)
        {
            return _RepositoryBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _RepositoryBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _RepositoryBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _RepositoryBase.Remove(obj);
        }
    }
}
