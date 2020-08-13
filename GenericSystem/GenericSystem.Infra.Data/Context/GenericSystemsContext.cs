using GenericSystem.Infra.CrossCutting.Util.Interface;
using GenericSystem.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GenericSystem.Infra.Data.Context
{
    internal class GenericSystemsContext : DbContext
    {
        private readonly ISystemConfiguration _configuration;

        public GenericSystemsContext(ISystemConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_configuration.ConnectionString)
                .EnableSensitiveDataLogging();
        }
    }
}
