using Goods.Goods_DAL.Goods_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace Goods.Goods_DAL.DbContexts
{
    public class MyDbContext : DbContext
    {
        // Database User
        public DbSet<User_Entities> user_Entities { get; set; } = null!;
        // Database Items
        public DbSet<Items_Entities> items_Entities { get; set; } = null!;
        // Database Carts
        public DbSet<Carts_Entities> carts_Entities { get; set; } = null!;
        // Database Reviews
        public DbSet<Reviews_Entities> reviews_Entities { get; set; } = null!;
        // Database Orders
        public DbSet<Orders_Entities> orders_Entities { get; set; } = null!;
        // Database OrderDetails
        public DbSet<OrderDetails_Entities> orderDetails_Entities { get; set; } = null!;
        // Tạo hàm kết nối với SQL Server
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }
    }
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        {
        }
    }
}
