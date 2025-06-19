using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using SmartHotel.Domain;
using SmartHotel.Domain.Entities;


namespace SmartHotel.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        #region Tables

        public DbSet<Variable> Variables => Set<Variable>();
        public DbSet<Agreement> Agreements => Set<Agreement>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Smoke> Smokes => Set<Smoke>();
        public DbSet<Temperature> Temperatures => Set<Temperature>();

        public DbSet<Light> Lights => Set<Light>();

        #endregion

        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public AppDbContext()
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Cadena de conexión.
        /// </param>
        /*public AppDbContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }*/

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">
        /// Opciones del contexto.
        /// </param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql();
            //Mayby delete
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=.;Database=SmartHotel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql("Host=localhost;Port=5047;Database=SmartHotelDB;Username=Servers;Password=AAM821988");

                return new AppDbContext(optionsBuilder.Options);
            }
        }





    }
}
