using Common.Repository;
using PRN232.Lab2.CoffeeStore.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repository.Interfaces
{
    /// <summary>
    /// Unit of Work interface for transaction management
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // Repository properties
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Order> Orders { get; }
        public IGenericRepository<OrderDetail> OrderDetails { get; }
        public IGenericRepository<Payment> Payments { get; }

        // Transaction methods
        //public Task<int> SaveChangesAsync();
        //Task BeginTransactionAsync();
        //Task CommitTransactionAsync();
        //Task RollbackTransactionAsync();
    }
}