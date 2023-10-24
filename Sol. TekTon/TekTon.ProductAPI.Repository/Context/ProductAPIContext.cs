using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Entities;

namespace TekTon.ProductAPI.Repository.Context
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext(DbContextOptions<ProductAPIContext> options) : base(options)
        {
        }

        #region DBSET

        public DbSet<Producto> PRODUCTO { get; set; }

        public DbSet<Categoria> CATEGORIA { get; set; }

        public DbSet<Estado> ESTADO { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Producto>()
            //    .HasKey(o => new { o.ID, o.ID_CATEGORIA, o.ID_ESTADO});

            //builder.Entity<Categoria>()
            //    .HasKey(o => new { o.ID, });

            //builder.Entity<Estado>()
            //    .HasKey(o => new { o.ID});

            //DbSeed(builder);

            base.OnModelCreating(builder);
        }

        protected virtual void DbSeed(ModelBuilder builder) { }
    }
}
