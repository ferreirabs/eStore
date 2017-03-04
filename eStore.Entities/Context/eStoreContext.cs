using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using eStore.Entities;


namespace eStore.Entities.Context
{
    public class eStoreContext : DbContext 
    {
        public eStoreContext()
            : base("DBeStore")
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Lojista> Lojista { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<Comprador> Comprador { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        //public System.Data.Entity.DbSet<eStore.ModelView.ModelCategoria> ModelCategorias { get; set; }
    }
}