using System;
using Service.Entities;
using Service.Repositories.Concrete;
using Service.UnitOfWork.Abstract;

namespace Service.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;
        private IExampleRepository exampleRepository;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IExampleRepository ExampleRepo
        {
            get
            {
                if(exampleRepository == null)
                {
                    exampleRepository = new EFExampleRepository(_dbContext);
                }

                return exampleRepository;
            }
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
	}
}