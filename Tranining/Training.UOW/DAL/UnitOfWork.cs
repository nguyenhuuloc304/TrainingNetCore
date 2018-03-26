using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data.Models;

namespace Training.UOW.DAL
{
    public class UnitOfWork : IDisposable
    {
        private CleanArchitectureContext context = new CleanArchitectureContext();
        private GenericRepository<Customers> customersRepository;
        private GenericRepository<Products> productsRepository;

        public GenericRepository<Customers> CustomersRepository
        {
            get
            {

                if (this.customersRepository == null)
                {
                    this.customersRepository = new GenericRepository<Customers>(context);
                }
                return customersRepository;
            }
        }

        public GenericRepository<Products> CourseRepository
        {
            get
            {

                if (this.productsRepository == null)
                {
                    this.productsRepository = new GenericRepository<Products>(context);
                }
                return productsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
