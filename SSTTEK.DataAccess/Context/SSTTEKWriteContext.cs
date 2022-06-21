using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SSTTEK.DataAccess.Configurations;
using SSTTEK.DataAccess.Migrations;
using SSTTEK.DataAccess.Migrations.Assembly;
using SSTTEK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTTEK.DataAccess.Context
{
    public class SSTTEKWriteContext : DbContext, IAPCContext
    {
        public string Schema
        {
            get
            {
                return "sssttek";
            }
        }
        public SSTTEKWriteContext()
        {

        }
        public SSTTEKWriteContext(DbContextOptions<SSTTEKWriteContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging(true);
#endif

            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLazyLoadingProxies(false)
                .UseSqlServer(
                    Configuration.ConnectionString("DefaultConnection"),
                    x =>
                    {
                        x.MigrationsHistoryTable(HistoryRepository.DefaultTableName.ToLowerInvariant(), Schema);
                    })
                .ReplaceService<IModelCacheKeyFactory, DbSchemaAwareModelCacheKeyFactory>()
                .ReplaceService<IMigrationsAssembly, DbSchemaAwareMigrationAssembly>();
        }
        public DbSet<Contact> Contacts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            //TODO : Configuration classları eklenecek.
            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
