﻿// <auto-generated />
using ChangeControl.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChangeControl.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200405182002_AddImpacts")]
    partial class AddImpacts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChangeControl.Models.ChangeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AffectedProductsAndProcesses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChangeLogs");
                });

            modelBuilder.Entity("ChangeControlApp.Models.Impact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangeLogId")
                        .HasColumnType("int");

                    b.Property<string>("Cleaning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerReqSpec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Environment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExistMaterialStockFinishProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinishedProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maintenance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufWorkFlowAncillaryPkgEquip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialQualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewExistEquipSoftware")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDocumentation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessValidation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdCustSpec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductValidation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QmsProceduresProcesses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegulatoryReq")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierAgreementsSpec")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestEquipMethodsCalib")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChangeLogId")
                        .IsUnique();

                    b.ToTable("Impacts");
                });

            modelBuilder.Entity("ChangeControlApp.Models.Impact", b =>
                {
                    b.HasOne("ChangeControl.Models.ChangeLog", "ChangeLog")
                        .WithOne("Impact")
                        .HasForeignKey("ChangeControlApp.Models.Impact", "ChangeLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
