using Bulky.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Categories { get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
