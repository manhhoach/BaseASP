using BaseASP.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseASP.Model
{
    public class DataSeeder
    {
        public static void SeedDatabase(DbContext context)
        {
            if (!context.Set<Role>().Any())
            {
                SeedRoles(context);
                context.SaveChanges();
            }
            if (!context.Set<User>().Any())
            {
                SeedUsers(context);
                context.SaveChanges();
            }
            if (!context.Set<Order>().Any())
            {
                SeedOrders(context);
                context.SaveChanges();
            }
            if (!context.Set<OrderDetail>().Any())
            {
                SeedOrderDetails(context);
                context.SaveChanges();
            }

        }

        private static void SeedRoles(DbContext context)
        {
            context.Set<Role>().AddRange(
                new Role { Name = "Admin" },
                new Role { Name = "User" }
            );
        }

        private static void SeedUsers(DbContext context)
        {
            context.Set<User>().AddRange(
            new User { Email = "john.doe@example.com", Name = "John Doe", Password = "password123", RoleId = 1 },
            new User { Email = "jane.smith@example.com", Name = "Jane Smith", Password = "password123", RoleId = 2 },
            new User { Email = "michael.jones@example.com", Name = "Michael Jones", Password = "password123", RoleId = 1 },
            new User { Email = "emily.brown@example.com", Name = "Emily Brown", Password = "password123", RoleId = 2 },
            new User { Email = "david.wilson@example.com", Name = "David Wilson", Password = "password123", RoleId = 1 },
            new User { Email = "sarah.davis@example.com", Name = "Sarah Davis", Password = "password123", RoleId = 2 },
            new User { Email = "james.miller@example.com", Name = "James Miller", Password = "password123", RoleId = 1 },
            new User { Email = "olivia.moore@example.com", Name = "Olivia Moore", Password = "password123", RoleId = 2 },
            new User { Email = "william.taylor@example.com", Name = "William Taylor", Password = "password123", RoleId = 1 },
            new User { Email = "ava.anderson@example.com", Name = "Ava Anderson", Password = "password123", RoleId = 2 }
        );
        }
        private static void SeedOrders(DbContext context)
        {
            context.Set<Order>().AddRange(
            new Order { UserId = 1 },
            new Order { UserId = 2 },
            new Order { UserId = 3 },
            new Order { UserId = 4 },
            new Order { UserId = 5 },
            new Order { UserId = 6 },
            new Order { UserId = 7 },
            new Order { UserId = 8 },
            new Order { UserId = 9 },
            new Order { UserId = 10 }
        );
        }

        private static void SeedOrderDetails(DbContext context)
        {
            context.Set<OrderDetail>().AddRange(
            new OrderDetail { OrderId = 1, ProductId = 101 },
            new OrderDetail { OrderId = 1, ProductId = 102 },
            new OrderDetail { OrderId = 2, ProductId = 103 },
            new OrderDetail { OrderId = 2, ProductId = 104 },
            new OrderDetail { OrderId = 3, ProductId = 105 },
            new OrderDetail { OrderId = 3, ProductId = 106 },
            new OrderDetail { OrderId = 4, ProductId = 107 },
            new OrderDetail { OrderId = 4, ProductId = 108 },
            new OrderDetail { OrderId = 5, ProductId = 109 },
            new OrderDetail { OrderId = 5, ProductId = 110 },
            new OrderDetail { OrderId = 6, ProductId = 111 },
            new OrderDetail { OrderId = 6, ProductId = 112 },
            new OrderDetail { OrderId = 7, ProductId = 113 },
            new OrderDetail { OrderId = 7, ProductId = 114 },
            new OrderDetail { OrderId = 8, ProductId = 115 },
            new OrderDetail { OrderId = 8, ProductId = 116 },
            new OrderDetail { OrderId = 9, ProductId = 117 },
            new OrderDetail { OrderId = 9, ProductId = 118 },
            new OrderDetail { OrderId = 10, ProductId = 119 },
            new OrderDetail { OrderId = 10, ProductId = 120 },
            new OrderDetail { OrderId = 1, ProductId = 121 },
            new OrderDetail { OrderId = 2, ProductId = 122 },
            new OrderDetail { OrderId = 3, ProductId = 123 },
            new OrderDetail { OrderId = 4, ProductId = 124 },
            new OrderDetail { OrderId = 5, ProductId = 125 },
            new OrderDetail { OrderId = 6, ProductId = 126 },
            new OrderDetail { OrderId = 7, ProductId = 127 },
            new OrderDetail { OrderId = 8, ProductId = 128 },
            new OrderDetail { OrderId = 9, ProductId = 129 },
            new OrderDetail { OrderId = 10, ProductId = 130 }
        );
        }
    }
}
