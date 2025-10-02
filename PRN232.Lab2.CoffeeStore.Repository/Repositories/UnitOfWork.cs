using Common.Repository;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using PRN232.Lab2.CoffeeStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.Repositories
{
    public class UnitOfWork(
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderDetail> orderDetailRepository,
            IGenericRepository<Payment> paymentRepository
        ) : IUnitOfWork
    {
        private bool disposedValue;

        IGenericRepository<Category> IUnitOfWork.Categories => categoryRepository;

        IGenericRepository<Product> IUnitOfWork.Products => productRepository;

        IGenericRepository<Order> IUnitOfWork.Orders => orderRepository;

        IGenericRepository<OrderDetail> IUnitOfWork.OrderDetails => orderDetailRepository;

        IGenericRepository<Payment> IUnitOfWork.Payments => paymentRepository;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
