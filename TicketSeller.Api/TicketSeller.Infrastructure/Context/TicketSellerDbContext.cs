using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketSeller.Core.Entities;

namespace TicketSeller.Infrastructure.Context
{
    public class TicketSellerDbContext : DbContext
    {
        public TicketSellerDbContext(DbContextOptions<TicketSellerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Carrito> Carritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Categoria
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(c => c.Descripcion);

            //Evento
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Event>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Event>().Property(e => e.Nombre);
            //modelBuilder.Entity<Event>().Property(e => e.Categoria);
            modelBuilder.Entity<Event>().Property(e => e.CantidadDisponible);
            modelBuilder.Entity<Event>().Property(e => e.Precio);
            
            //Carrito
            modelBuilder.Entity<Carrito>().HasKey(r => r.Id);
            modelBuilder.Entity<Carrito>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Carrito>().Property(r => r.IdEvento);
            modelBuilder.Entity<Carrito>().Property(r => r.CantidadBoletos);



            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = -2,
                Descripcion = "Concierto"

            },
            new Category
            { 
                        
                Id = -1,
                Descripcion = "Obra de Arte"

            }
            ) ;

        }
    }
}
