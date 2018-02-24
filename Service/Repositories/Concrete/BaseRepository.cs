using System;
using System.Collections.Generic;
using System.Linq;
using Service.Entities;
using Service.Repositories.Abstract;

namespace Service.Repositories.Concrete
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
        private readonly ExampleDbContext _context;

        public BaseRepository(ExampleDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>().AsQueryable();
            }
            catch(Exception exception)
            {
                throw exception;
            }   
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
		public void Delete(int id)
		{
            try
            {
                TEntity entity = _context.Set<TEntity>().Find(id);
                _context.Set<TEntity>().Remove(entity);
            }
            catch(Exception exception)
            {
                throw exception;
            }
		}

		public TEntity Insert(TEntity entity)
		{
            try
            {
                _context.Set<TEntity>().Add(entity);
                int result = _context.SaveChanges();
                return entity;
            }
            catch(Exception exception)
            {
                throw exception;
            }
		}

		public void Update(TEntity entity, int id)
		{
            try
            {
                TEntity _entity = _context.Set<TEntity>().Find(id);
                _entity = entity;
                _context.Set<TEntity>().Update(_entity);
                _context.SaveChanges();

            }
            catch(Exception exception)
            {
                throw exception;
            }
		}
	}
}