using System;
using System.Collections.Generic;
using BrentUniversity_Azure.Repository.Base;
using BrentUniversity_Azure.Service.Base;

namespace BrentUniversity_Azure.Service
{
    /// <summary>
    /// Inheriting from EntityService provides CRUD operations encapsulating Unit Of Work.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityService<T> : IEntityService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual void Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
