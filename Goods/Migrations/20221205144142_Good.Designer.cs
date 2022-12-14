// <auto-generated />
using System;
using Goods.Goods_DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Goods.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221205144142_Good")]
    partial class Good
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Carts_Entities", b =>
                {
                    b.Property<int>("CartsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartsId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("ProductAllPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("carts_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Items_Entities", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("NumberReview")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProductRemain")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("items_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.OrderDetails_Entities", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductAllPrice")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrdersId");

                    b.HasIndex("ProductId");

                    b.ToTable("orderDetails_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Orders_Entities", b =>
                {
                    b.Property<int>("OrdersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdersId"));

                    b.Property<DateTime>("OrdersDate")
                        .HasColumnType("date");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShipPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SumOfPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId");

                    b.HasIndex("UserId");

                    b.ToTable("orders_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Reviews_Entities", b =>
                {
                    b.Property<int>("ReviewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewsId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewsId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("reviews_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.User_Entities", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("TokenCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("user_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Carts_Entities", b =>
                {
                    b.HasOne("Goods.Goods_DAL.Goods_Entities.Items_Entities", "items_Entities")
                        .WithMany("ListCarts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Goods.Goods_DAL.Goods_Entities.User_Entities", "user_Entities")
                        .WithMany("ListCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("items_Entities");

                    b.Navigation("user_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.OrderDetails_Entities", b =>
                {
                    b.HasOne("Goods.Goods_DAL.Goods_Entities.Orders_Entities", "orders_Entities")
                        .WithMany("ListOrderDetails")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Goods.Goods_DAL.Goods_Entities.Items_Entities", "items_Entities")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("items_Entities");

                    b.Navigation("orders_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Orders_Entities", b =>
                {
                    b.HasOne("Goods.Goods_DAL.Goods_Entities.User_Entities", "user_Entities")
                        .WithMany("ListOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Reviews_Entities", b =>
                {
                    b.HasOne("Goods.Goods_DAL.Goods_Entities.Items_Entities", "items_Entities")
                        .WithMany("ListReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Goods.Goods_DAL.Goods_Entities.User_Entities", "user_Entities")
                        .WithMany("ListReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("items_Entities");

                    b.Navigation("user_Entities");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Items_Entities", b =>
                {
                    b.Navigation("ListCarts");

                    b.Navigation("ListReviews");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.Orders_Entities", b =>
                {
                    b.Navigation("ListOrderDetails");
                });

            modelBuilder.Entity("Goods.Goods_DAL.Goods_Entities.User_Entities", b =>
                {
                    b.Navigation("ListCarts");

                    b.Navigation("ListOrders");

                    b.Navigation("ListReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
