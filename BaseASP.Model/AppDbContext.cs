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
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //  Seed(modelBuilder);

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

        private static void Seed(ModelBuilder model)
        {
            model.Entity<Role>().HasData(
                new Role() { Name = "Admin" },
                new Role() { Name = "User" }
                );
            model.Entity<User>().HasData(
                new User { Id = 1, Email = "john.doe@example.com", Name = "John Doe", Password = "password123", RoleId = 2 },
                new User { Id = 2, Email = "jane.smith@example.com", Name = "Jane Smith", Password = "password123", RoleId = 2 },
                new User { Id = 3, Email = "michael.jones@example.com", Name = "Michael Jones", Password = "password123", RoleId = 2 },
                new User { Id = 4, Email = "emily.brown@example.com", Name = "Emily Brown", Password = "password123", RoleId = 2 },
                new User { Id = 5, Email = "david.wilson@example.com", Name = "David Wilson", Password = "password123", RoleId = 2 },
                new User { Id = 6, Email = "sarah.davis@example.com", Name = "Sarah Davis", Password = "password123", RoleId = 2 },
                new User { Id = 7, Email = "james.miller@example.com", Name = "James Miller", Password = "password123", RoleId = 2 },
                new User { Id = 8, Email = "olivia.moore@example.com", Name = "Olivia Moore", Password = "password123", RoleId = 2 },
                new User { Id = 9, Email = "william.taylor@example.com", Name = "William Taylor", Password = "password123", RoleId = 2 },
                new User { Id = 10, Email = "ava.anderson@example.com", Name = "Ava Anderson", Password = "password123", RoleId = 2 }
            );
        }

    }
}
