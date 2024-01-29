using Microsoft.EntityFrameworkCore;
using Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Data.Data
{
    public partial class Entrega5Context : DbContext
    {
        public Entrega5Context()
        {
        }

        public Entrega5Context(DbContextOptions<Entrega5Context> options) : base(options)
        {
        }

        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<TipoMedioPago> TipoMedioPago { get; set; }
        public virtual DbSet<Cobranza> Cobranza { get; set; }
        public virtual DbSet<Afiliado> Afiliado { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual DbSet<Transferencia> Transferencia { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<TipoTarjeta> TipoTarjeta { get; set; }
        public virtual DbSet<TipoResponsableIVA> TipoResponsableIVA { get; set; }
        public virtual DbSet<Insumo> Insumo { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Precio> Precio { get; set; }
        public virtual DbSet<ListaPrecio> ListaPrecio { get; set; }
        public virtual DbSet<TipoCondicionDeVenta> TipoCondicionDeVenta { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Entrega5;Persist Security Info=True;Password=WebAPIDesarrollo;Username=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
