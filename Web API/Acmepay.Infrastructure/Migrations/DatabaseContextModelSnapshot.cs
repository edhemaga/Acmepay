﻿// <auto-generated />
using System;
using Acmepay.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acmepay.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acmepay.Domain.Entities.CardHolder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("Cardholder_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpirationMonth")
                        .HasColumnType("int");

                    b.Property<int>("ExpirationYear")
                        .HasColumnType("int");

                    b.Property<string>("HolderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardHolders");
                });

            modelBuilder.Entity("Acmepay.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid>("CardHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderReference")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardHolderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Acmepay.Domain.Entities.Payment", b =>
                {
                    b.HasOne("Acmepay.Domain.Entities.CardHolder", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CardHolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Acmepay.Domain.Entities.CardHolder", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
