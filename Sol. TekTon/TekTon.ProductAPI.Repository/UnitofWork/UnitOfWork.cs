using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork;
using TekTon.ProductAPI.Repository.Context;

namespace TekTon.ProductAPI.Repository.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductAPIContext _context;

        public UnitOfWork(ProductAPIContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        #region Save Changes
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
