﻿// <auto-generated />
using System;
using CondominiumApi.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CondominiumApi.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230220235927_addindexess")]
    partial class addindexess
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Chave Primária");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Create_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Create_Date")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Data de Criação do Cadastro do apartamento");

                    b.Property<DateTime>("Last_Update_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Last_Update_Date")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Ultima atualização dos dados do apartamento");

                    b.Property<int>("Number")
                        .HasColumnType("INT")
                        .HasColumnName("Number")
                        .HasComment("Numero do Apartamento");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Chave da tabela de Pessoa");

                    b.Property<Guid?>("ResidentId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Chave da tabela de Pessoa");

                    b.HasKey("Id")
                        .HasName("PK_Apartment");

                    b.HasIndex("BlockId");

                    b.HasIndex(new[] { "Number", "BlockId" }, "IX_Apartment_Block")
                        .IsUnique();

                    b.HasIndex(new[] { "OwnerId" }, "IX_Apartment_OwnerId")
                        .IsUnique()
                        .HasFilter("[OwnerId] IS NOT NULL");

                    b.HasIndex(new[] { "ResidentId" }, "IX_Apartment_ResidentId")
                        .IsUnique()
                        .HasFilter("[ResidentId] IS NOT NULL");

                    b.ToTable("Apartment", "Condominium");

                    b.HasComment("Tabela de Apartamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BlockId = 1,
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Last_Update_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 1,
                            OwnerId = new Guid("5a7a5658-ccbc-4451-b4bc-5a0264bd0a81")
                        },
                        new
                        {
                            Id = 2,
                            BlockId = 2,
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Last_Update_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 1,
                            OwnerId = new Guid("495dadfc-add1-4826-bde8-828c9b0c0134"),
                            ResidentId = new Guid("495dadfc-add1-4826-bde8-828c9b0c0134")
                        },
                        new
                        {
                            Id = 3,
                            BlockId = 1,
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Last_Update_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 2,
                            OwnerId = new Guid("59de6d3b-2002-42fa-80e3-057f2cfc5cae"),
                            ResidentId = new Guid("e69cb7b8-164c-41ed-a670-7b40480c3887")
                        });
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.ApartmentVehicle", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(6,0)")
                        .HasComment("Chave da tabela Vehicle");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasColumnName("Active")
                        .HasDefaultValueSql("0")
                        .HasComment("Indica se o veiculo está ativo");

                    b.Property<DateTime?>("Active_Date")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Active_Date")
                        .HasComment("Data de Ativação");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Inactive_Date")
                        .HasColumnType("DATETIME")
                        .HasColumnName("Inactive_Date")
                        .HasComment("Data de Desativação");

                    b.Property<decimal>("VehicleId")
                        .HasColumnType("DECIMAL(6,0)");

                    b.HasKey("Id")
                        .HasName("PK_ApartmentsVehicles");

                    b.HasIndex("ApartmentId");

                    b.HasIndex(new[] { "VehicleId", "ApartmentId" }, "IX_Teste")
                        .IsUnique()
                        .HasFilter("[Active] = 1");

                    b.ToTable("ApartmentsVehicles", "Condominium");

                    b.HasComment("Tabela Associtativa de Apartamento e Veiculos");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.BlockOfApartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Chave Primária");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("NVARCHAR(2)")
                        .HasColumnName("Block")
                        .HasComment("Bloco por Apartamento");

                    b.HasKey("Id")
                        .HasName("PK_Block");

                    b.HasIndex(new[] { "Block" }, "IX_Block")
                        .IsUnique();

                    b.ToTable("Block", "Condominium");

                    b.HasComment("Tabela de Bloco de apartamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Block = "A"
                        },
                        new
                        {
                            Id = 2,
                            Block = "B"
                        },
                        new
                        {
                            Id = 3,
                            Block = "C"
                        });
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasComment("Chave Primária");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)")
                        .HasColumnName("Brand_Name")
                        .HasComment("Marca do veiculo");

                    b.HasKey("Id")
                        .HasName("PK_Brand");

                    b.HasIndex(new[] { "Brand_Name" }, "IX_Brand_Name")
                        .IsUnique();

                    b.ToTable("Brand", "Condominium");

                    b.HasComment("Tabela de marcas de veiculos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand_Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 2,
                            Brand_Name = "Hyundai"
                        },
                        new
                        {
                            Id = 3,
                            Brand_Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 4,
                            Brand_Name = "Honda"
                        });
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Chave Primária");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("Cpf")
                        .HasComment("CPF");

                    b.Property<DateTime>("Create_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Create_Date")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Data de Criação do Cadastro");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("Email")
                        .HasComment("Email");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)")
                        .HasColumnName("First_Name")
                        .HasComment("Nome");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)")
                        .HasColumnName("Last_Name")
                        .HasComment("Sobrenome");

                    b.Property<DateTime?>("Last_Update_Date")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Last_Update_Date")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Ultima atualização do cadastro");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("Phone")
                        .HasComment("Telefone para contato");

                    b.HasKey("Id")
                        .HasName("PK_Person");

                    b.HasIndex(new[] { "Cpf" }, "IX_Person_Cpf")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "IX_Person_Email")
                        .IsUnique();

                    b.ToTable("Person", "Condominium");

                    b.HasComment("Tabela de Pessoas Cadastradas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fd401e3-fb52-4eed-b7df-28c99753ae55"),
                            Cpf = "0124567890",
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            First_Name = "Admin",
                            Last_Name = "System",
                            Phone = "11987654321"
                        },
                        new
                        {
                            Id = new Guid("5a7a5658-ccbc-4451-b4bc-5a0264bd0a81"),
                            Cpf = "11122233344",
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "garen@stemmaguarda.com",
                            First_Name = "Garen",
                            Last_Name = "Stemmaguarda",
                            Phone = "11987654322"
                        },
                        new
                        {
                            Id = new Guid("495dadfc-add1-4826-bde8-828c9b0c0134"),
                            Cpf = "22233344455",
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lux@stemmaguarda.com",
                            First_Name = "Lux",
                            Last_Name = "Stemmaguarda",
                            Phone = "11987654322"
                        },
                        new
                        {
                            Id = new Guid("59de6d3b-2002-42fa-80e3-057f2cfc5cae"),
                            Cpf = "22233344456",
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "annie@hastur.com",
                            First_Name = "Annie",
                            Last_Name = "Hastur",
                            Phone = "11987654322"
                        },
                        new
                        {
                            Id = new Guid("e69cb7b8-164c-41ed-a670-7b40480c3887"),
                            Cpf = "33344455566",
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ashe@avarosa.com",
                            First_Name = "Ashe",
                            Last_Name = "Avarosa",
                            Phone = "11987654323"
                        });
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Vehicle", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DECIMAL(6,0)")
                        .HasComment("Chave Primária");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("Create_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Create_Date")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Data de cadastramento do veículo");

                    b.Property<bool>("Handicap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasColumnName("Handicap")
                        .HasDefaultValueSql("0")
                        .HasComment("Indica se o veículo é adpatado para PcD");

                    b.Property<DateTime>("Last_Update_Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("Last_Update_Date")
                        .HasDefaultValueSql("GETDATE()")
                        .HasComment("Ultima atualização do cadastro do veículo");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("NVARCHAR(7)")
                        .HasColumnName("Plate")
                        .HasComment("Placa do veículo");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("INT")
                        .HasComment("Chave da tabela de Model");

                    b.Property<int>("Vehicle_Type")
                        .HasColumnType("INT")
                        .HasColumnName("Vehicle_Type")
                        .HasComment("Indica tipo de veiculo. 1 == Automóvel, 2 == Motoclicleta, 3 == Caminhão");

                    b.HasKey("Id")
                        .HasName("PK_Vehicle");

                    b.HasIndex("VehicleModelId");

                    b.HasIndex(new[] { "Plate" }, "IX_Vehicle_Plate")
                        .IsUnique();

                    b.ToTable("Vehicle", "Condominium");

                    b.HasComment("Tabela de veiculos do condomínio");

                    b.HasData(
                        new
                        {
                            Id = 1m,
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Handicap = false,
                            Last_Update_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Plate = "QNH3936",
                            VehicleModelId = 1,
                            Vehicle_Type = 1
                        },
                        new
                        {
                            Id = 2m,
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Handicap = false,
                            Last_Update_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Plate = "ABC5566",
                            VehicleModelId = 3,
                            Vehicle_Type = 1
                        },
                        new
                        {
                            Id = 3m,
                            Create_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Handicap = false,
                            Last_Update_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Plate = "EGC4355",
                            VehicleModelId = 5,
                            Vehicle_Type = 1
                        });
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasComment("Chave Primária");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("INT")
                        .HasColumnName("BrandId")
                        .HasComment("PK da tabela de marca");

                    b.Property<string>("Model_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)")
                        .HasColumnName("Model_Name")
                        .HasComment("Modelo");

                    b.HasKey("Id")
                        .HasName("PK_Vehicle_Model");

                    b.HasIndex(new[] { "BrandId" }, "IX_Brand_Id");

                    b.HasIndex(new[] { "Model_Name" }, "IX_Model_Name")
                        .IsUnique();

                    b.ToTable("VehicleModel", "Condominium");

                    b.HasComment("Tabela de modelos de veículo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Model_Name = "Onix"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Model_Name = "Cruze"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Model_Name = "Celta"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Model_Name = "HB20"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 3,
                            Model_Name = "Fox"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 3,
                            Model_Name = "Gol"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 4,
                            Model_Name = "Civic"
                        });
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Apartment", b =>
                {
                    b.HasOne("CondominiumApi.Domain.Entities.BlockOfApartment", "BlockOfApartment")
                        .WithMany("Apartments")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CondominiumApi.Domain.Entities.Person", "Owner")
                        .WithOne("ApartmentOwner")
                        .HasForeignKey("CondominiumApi.Domain.Entities.Apartment", "OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Apartment_Owner_PersonId");

                    b.HasOne("CondominiumApi.Domain.Entities.Person", "Resident")
                        .WithOne("ApartmentResident")
                        .HasForeignKey("CondominiumApi.Domain.Entities.Apartment", "ResidentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK_Apartment_Resident_PersonId");

                    b.Navigation("BlockOfApartment");

                    b.Navigation("Owner");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.ApartmentVehicle", b =>
                {
                    b.HasOne("CondominiumApi.Domain.Entities.Apartment", "Apartment")
                        .WithMany("ApartmentsVehicles")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CondominiumApi.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("ApartmentsVehicles")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("CondominiumApi.Domain.Entities.VehicleModel", "VehicleModel")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.VehicleModel", b =>
                {
                    b.HasOne("CondominiumApi.Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Apartment", b =>
                {
                    b.Navigation("ApartmentsVehicles");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.BlockOfApartment", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Person", b =>
                {
                    b.Navigation("ApartmentOwner")
                        .IsRequired();

                    b.Navigation("ApartmentResident")
                        .IsRequired();
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("ApartmentsVehicles");
                });

            modelBuilder.Entity("CondominiumApi.Domain.Entities.VehicleModel", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
