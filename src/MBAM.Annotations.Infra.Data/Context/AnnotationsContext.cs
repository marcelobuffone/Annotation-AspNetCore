using MBAM.Annotations.Domain.Annotations;
using MBAM.Annotations.Infra.Data.Extensions;
using MBAM.Annotations.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MBAM.Annotations.Infra.Data.Context
{
    public class AnnotationsContext : DbContext
    {
        public virtual DbSet<Annotation> Annotations { get; set; }
        public virtual DbSet<AnnotationHistory> AnnotationHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new AnnotationMapping());
            modelBuilder.AddConfiguration(new AnnotationHistoryMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
