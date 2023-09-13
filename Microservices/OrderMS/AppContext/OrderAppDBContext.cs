﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using OrderMS.Models;
using System.Reflection;

namespace OrderMS.AppContext
{
    public class OrderAppDBContext : DbContext
{
    public OrderAppDBContext(DbContextOptions<OrderAppDBContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Modified)
                {
                    var baseEntity = entity.Entity as BaseEntity;
                    if (baseEntity != null)
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Modified)
                {
                    var baseEntity = entity.Entity as BaseEntity;
                    if (baseEntity != null)
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
