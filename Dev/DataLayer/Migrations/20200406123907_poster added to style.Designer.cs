﻿// <auto-generated />
using System;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20200406123907_poster added to style")]
    partial class posteraddedtostyle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.CartLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<Guid?>("StyleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SizeId");

                    b.HasIndex("StyleId");

                    b.ToTable("CartLines");
                });

            modelBuilder.Entity("DataLayer.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Guest")
                        .HasColumnType("bit");

                    b.Property<string>("HouseNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataLayer.Models.DiscountCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPercentage")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("DataLayer.Models.Giftcard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("GiftCardCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PuchasedWithOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PuchasedWithOrderId");

                    b.ToTable("Giftcards");
                });

            modelBuilder.Entity("DataLayer.Models.GiftcardUsageHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GiftcardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("UsedValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UsedWithOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GiftcardId");

                    b.HasIndex("UsedWithOrderId");

                    b.ToTable("GiftCardUsageHistories");
                });

            modelBuilder.Entity("DataLayer.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GiftAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HusNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("OrderSubTotalTaxEXCL")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OrderSubTotalTaxINCL")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OrderTotalTaxEXCL")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OrderTotalTaxINCL")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Shipping")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Models.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Style")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("DataLayer.Models.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartLineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderLineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartLineId");

                    b.HasIndex("OrderLineId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("DataLayer.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SizeType")
                        .HasColumnType("int");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("DataLayer.Models.Style", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfPictures")
                        .HasColumnType("int");

                    b.Property<decimal>("B2BPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasText")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoFollow")
                        .HasColumnType("bit");

                    b.Property<decimal>("OldPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("SeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("DataLayer.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyTekst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPage")
                        .HasColumnType("bit");

                    b.Property<bool>("NoFollow")
                        .HasColumnType("bit");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeoTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubpageId")
                        .HasColumnType("int");

                    b.Property<string>("SystemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubpageId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("DataLayer.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLayer.Models.CartLine", b =>
                {
                    b.HasOne("DataLayer.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataLayer.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId");

                    b.HasOne("DataLayer.Models.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId");
                });

            modelBuilder.Entity("DataLayer.Models.Giftcard", b =>
                {
                    b.HasOne("DataLayer.Models.Order", "PuchasedWithOrder")
                        .WithMany()
                        .HasForeignKey("PuchasedWithOrderId");
                });

            modelBuilder.Entity("DataLayer.Models.GiftcardUsageHistory", b =>
                {
                    b.HasOne("DataLayer.Models.Giftcard", "Giftcard")
                        .WithMany()
                        .HasForeignKey("GiftcardId");

                    b.HasOne("DataLayer.Models.Order", "UsedWithOrder")
                        .WithMany()
                        .HasForeignKey("UsedWithOrderId");
                });

            modelBuilder.Entity("DataLayer.Models.OrderLine", b =>
                {
                    b.HasOne("DataLayer.Models.Order", null)
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("DataLayer.Models.Picture", b =>
                {
                    b.HasOne("DataLayer.Models.CartLine", null)
                        .WithMany("Pictures")
                        .HasForeignKey("CartLineId");

                    b.HasOne("DataLayer.Models.OrderLine", null)
                        .WithMany("Pictures")
                        .HasForeignKey("OrderLineId");
                });

            modelBuilder.Entity("DataLayer.Models.Topic", b =>
                {
                    b.HasOne("DataLayer.Models.Topic", "Subpage")
                        .WithMany()
                        .HasForeignKey("SubpageId");
                });
#pragma warning restore 612, 618
        }
    }
}
