using BaseASP.Model.Common;
using BaseASP.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseASP.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProperty = entityType.ClrType.GetProperty("IsDeleted");
                if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.Property(parameter, "IsDeleted"),
                        Expression.Constant(false)
                    );
                    var lambda = Expression.Lambda(body, parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }


            modelBuilder.Entity<User>(user =>
            {
                user.HasIndex(u => u.Email).IsUnique();
            });
            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modelEntries = ChangeTracker.Entries().Where(
                model => model.Entity is IEntityBase &&
                (model.State == EntityState.Added || model.State == EntityState.Modified)
            );
            foreach (var entry in modelEntries)
            {
                if (entry.Entity is IEntityBase entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedDate = DateTime.Now;
                    }
                    else
                    {
                        // nếu không phải là tạo mới thì ngăn chặn việc thay đổi CreatedDate và CreatedBy
                        base.Entry(entry).Property("CreatedDate").IsModified = false;
                        base.Entry(entry).Property("CreatedBy").IsModified = false;

                        entity.UpdatedDate = DateTime.Now;
                    }

                    if (entry.Entity is User user)
                    {
                        if (entry.State == EntityState.Added || (entry.State == EntityState.Modified && entry.Property("Password").IsModified))
                        {
                            string salt = BCrypt.Net.BCrypt.GenerateSalt();
                            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
                        }
                    }
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void Seed(ModelBuilder model)
        {
            model.Entity<Role>().HasData(
                new Role() { Name = "Admin" },
                new Role() { Name = "User" }
                );

        }

    }
}
