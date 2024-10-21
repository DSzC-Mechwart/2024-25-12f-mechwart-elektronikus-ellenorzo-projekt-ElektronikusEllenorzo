﻿// <auto-generated />
using System;
using DH_EE_IKT_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DH_EE_IKT_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240930174516_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DH_EE_IKT_API.Models.Jegy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Jegy_Ertek")
                        .HasColumnType("int");

                    b.Property<int>("Tanar_ID")
                        .HasColumnType("int");

                    b.Property<int>("Tantargy_ID")
                        .HasColumnType("int");

                    b.Property<int>("Tanulo_ID")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("Tanar_ID");

                    b.HasIndex("Tantargy_ID");

                    b.HasIndex("Tanulo_ID");

                    b.ToTable("Jegyek");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Orarend", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Elso_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Harmadik_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Hatodik_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Hetedik_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Masodik_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Negyedik_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Nyolcadik_Tanora_ID")
                        .HasColumnType("int");

                    b.Property<string>("Osztaly_ID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Otodik_Tanora_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Elso_Tanora_ID");

                    b.HasIndex("Harmadik_Tanora_ID");

                    b.HasIndex("Hatodik_Tanora_ID");

                    b.HasIndex("Hetedik_Tanora_ID");

                    b.HasIndex("Masodik_Tanora_ID");

                    b.HasIndex("Negyedik_Tanora_ID");

                    b.HasIndex("Nyolcadik_Tanora_ID");

                    b.HasIndex("Otodik_Tanora_ID");

                    b.ToTable("Orarendek");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Osztaly", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Evfolyam")
                        .HasColumnType("int");

                    b.Property<int>("Ofo_ID")
                        .HasColumnType("int");

                    b.Property<int>("Szak_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Ofo_ID");

                    b.HasIndex("Szak_ID");

                    b.ToTable("Osztalyok");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Szak", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Szak_Nev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Szakok");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tanar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("P_Hash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("P_Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Tanarok");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tanora", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Tantargy_ID")
                        .HasColumnType("int");

                    b.Property<string>("Terem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("Tantargy_ID");

                    b.ToTable("Tanorak");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tantargy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Osztaly_ID")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Szakmai_e")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Tanar_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Osztaly_ID");

                    b.HasIndex("Tanar_ID");

                    b.ToTable("Tantargyak");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tanulo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Anya_Nev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Koli")
                        .HasColumnType("longtext");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Osztaly_ID")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("P_Hash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("P_Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Szul_Hely")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Szul_Ido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Torzslapszam")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Osztaly_ID");

                    b.ToTable("Tanulok");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Jegy", b =>
                {
                    b.HasOne("DH_EE_IKT_API.Models.Tanar", "Tanar")
                        .WithMany()
                        .HasForeignKey("Tanar_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DH_EE_IKT_API.Models.Tantargy", "Tantargy")
                        .WithMany()
                        .HasForeignKey("Tantargy_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DH_EE_IKT_API.Models.Tanulo", "Tanulo")
                        .WithMany()
                        .HasForeignKey("Tanulo_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tanar");

                    b.Navigation("Tantargy");

                    b.Navigation("Tanulo");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Orarend", b =>
                {
                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Elso_Ora")
                        .WithMany()
                        .HasForeignKey("Elso_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Harmadik_Ora")
                        .WithMany()
                        .HasForeignKey("Harmadik_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Hatodik_Ora")
                        .WithMany()
                        .HasForeignKey("Hatodik_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Hetedik_Ora")
                        .WithMany()
                        .HasForeignKey("Hetedik_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Masodik_Ora")
                        .WithMany()
                        .HasForeignKey("Masodik_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Negyedik_Ora")
                        .WithMany()
                        .HasForeignKey("Negyedik_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Nyolcadik_Ora")
                        .WithMany()
                        .HasForeignKey("Nyolcadik_Tanora_ID");

                    b.HasOne("DH_EE_IKT_API.Models.Tanora", "Otodik_Ora")
                        .WithMany()
                        .HasForeignKey("Otodik_Tanora_ID");

                    b.Navigation("Elso_Ora");

                    b.Navigation("Harmadik_Ora");

                    b.Navigation("Hatodik_Ora");

                    b.Navigation("Hetedik_Ora");

                    b.Navigation("Masodik_Ora");

                    b.Navigation("Negyedik_Ora");

                    b.Navigation("Nyolcadik_Ora");

                    b.Navigation("Otodik_Ora");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Osztaly", b =>
                {
                    b.HasOne("DH_EE_IKT_API.Models.Tanar", "Osztalyfonok")
                        .WithMany()
                        .HasForeignKey("Ofo_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DH_EE_IKT_API.Models.Szak", "Szak")
                        .WithMany()
                        .HasForeignKey("Szak_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osztalyfonok");

                    b.Navigation("Szak");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tanora", b =>
                {
                    b.HasOne("DH_EE_IKT_API.Models.Tantargy", "Targy")
                        .WithMany()
                        .HasForeignKey("Tantargy_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Targy");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tantargy", b =>
                {
                    b.HasOne("DH_EE_IKT_API.Models.Osztaly", "Osztaly")
                        .WithMany()
                        .HasForeignKey("Osztaly_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DH_EE_IKT_API.Models.Tanar", "Tanar")
                        .WithMany()
                        .HasForeignKey("Tanar_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osztaly");

                    b.Navigation("Tanar");
                });

            modelBuilder.Entity("DH_EE_IKT_API.Models.Tanulo", b =>
                {
                    b.HasOne("DH_EE_IKT_API.Models.Osztaly", "Osztaly")
                        .WithMany()
                        .HasForeignKey("Osztaly_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Osztaly");
                });
#pragma warning restore 612, 618
        }
    }
}