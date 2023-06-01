﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCompany.Crm.Sales.Database.Sql.EF;
using MyCompany.ECommerce.Sales.Database.Sql.EF;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyCompany.Crm.Sales.Database.Sql.EF.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    [Migration("20221229083720_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyCompany.Crm.Sales.Database.Sql.EF.DbOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPlaced")
                        .HasColumnType("boolean");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("OrderHeaderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("OrderNotes");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Database.Sql.EF.DbOrder", b =>
                {
                    b.OwnsMany("MyCompany.Crm.Sales.Orders.Order+Item", "Items", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id1")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id1"));

                            b1.HasKey("OrderId", "Id1");

                            b1.ToTable("OrderItems", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.OwnsOne("MyCompany.Crm.Sales.Orders.Order+PriceAgreement", "PriceAgreement", b2 =>
                                {
                                    b2.Property<Guid>("ItemOrderId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("ItemId1")
                                        .HasColumnType("integer");

                                    b2.Property<DateTime?>("ExpiresOn")
                                        .HasColumnType("timestamp with time zone");

                                    b2.Property<byte>("Type")
                                        .HasColumnType("smallint");

                                    b2.HasKey("ItemOrderId", "ItemId1");

                                    b2.ToTable("OrderItems");

                                    b2.WithOwner()
                                        .HasForeignKey("ItemOrderId", "ItemId1");

                                    b2.OwnsOne("MyCompany.Crm.Sales.Commons.Money", "Price", b3 =>
                                        {
                                            b3.Property<Guid>("PriceAgreementItemOrderId")
                                                .HasColumnType("uuid");

                                            b3.Property<int>("PriceAgreementItemId1")
                                                .HasColumnType("integer");

                                            b3.Property<int>("Currency")
                                                .HasColumnType("integer");

                                            b3.Property<decimal>("Value")
                                                .HasColumnType("numeric");

                                            b3.HasKey("PriceAgreementItemOrderId", "PriceAgreementItemId1");

                                            b3.ToTable("OrderItems");

                                            b3.WithOwner()
                                                .HasForeignKey("PriceAgreementItemOrderId", "PriceAgreementItemId1");
                                        });

                                    b2.Navigation("Price");
                                });

                            b1.OwnsOne("MyCompany.Crm.Sales.Products.ProductAmount", "ProductAmount", b2 =>
                                {
                                    b2.Property<Guid>("ItemOrderId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("ItemId1")
                                        .HasColumnType("integer");

                                    b2.Property<Guid>("ProductId")
                                        .HasColumnType("uuid");

                                    b2.HasKey("ItemOrderId", "ItemId1");

                                    b2.ToTable("OrderItems");

                                    b2.WithOwner()
                                        .HasForeignKey("ItemOrderId", "ItemId1");

                                    b2.OwnsOne("MyCompany.Crm.Sales.Products.Amount", "Amount", b3 =>
                                        {
                                            b3.Property<Guid>("ProductAmountItemOrderId")
                                                .HasColumnType("uuid");

                                            b3.Property<int>("ProductAmountItemId1")
                                                .HasColumnType("integer");

                                            b3.Property<int>("Unit")
                                                .HasColumnType("integer");

                                            b3.Property<int>("Value")
                                                .HasColumnType("integer");

                                            b3.HasKey("ProductAmountItemOrderId", "ProductAmountItemId1");

                                            b3.ToTable("OrderItems");

                                            b3.WithOwner()
                                                .HasForeignKey("ProductAmountItemOrderId", "ProductAmountItemId1");
                                        });

                                    b2.Navigation("Amount")
                                        .IsRequired();
                                });

                            b1.Navigation("PriceAgreement")
                                .IsRequired();

                            b1.Navigation("ProductAmount")
                                .IsRequired();
                        });

                    b.Navigation("Items");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderHeader", b =>
                {
                    b.OwnsOne("MyCompany.Crm.Sales.Orders.InvoicingDetails", "InvoicingDetails", b1 =>
                        {
                            b1.Property<Guid>("OrderHeaderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("TaxId")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("OrderHeaderId");

                            b1.ToTable("OrderHeaders");

                            b1.WithOwner()
                                .HasForeignKey("OrderHeaderId");
                        });

                    b.Navigation("InvoicingDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderNote", b =>
                {
                    b.HasOne("MyCompany.Crm.Sales.Orders.OrderHeader", null)
                        .WithMany("Notes")
                        .HasForeignKey("OrderHeaderId");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderHeader", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
