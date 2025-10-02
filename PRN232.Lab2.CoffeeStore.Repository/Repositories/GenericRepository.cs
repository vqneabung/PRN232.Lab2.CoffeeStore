using Common.Repository;
using PRN232.Lab2.CoffeeStore.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories.Repositories
{
    public class GenericRepository<T> : GenericRepositoryWithContext<CoffeeStoreDB2Context, T> where T : class
    {
        public GenericRepository(CoffeeStoreDB2Context context) : base(context)
        {
        }
    }
}
