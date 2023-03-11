﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_HealTime.Data;

#nullable disable

namespace WEB_API_HealTime.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API_HealTime.Models.Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"));

                    b.Property<int>("CrmMedico")
                        .HasColumnType("INT");

                    b.Property<string>("NmMedico")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("UfCrmMedico")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.HasKey("MedicoId")
                        .HasName("PK_MedicoId");

                    b.ToTable("Medicos");

                    b.HasData(
                        new
                        {
                            MedicoId = 1,
                            CrmMedico = 12345,
                            NmMedico = "Dr Val",
                            UfCrmMedico = "SP"
                        },
                        new
                        {
                            MedicoId = 2,
                            CrmMedico = 12345,
                            NmMedico = "Dr Teste",
                            UfCrmMedico = "RJ"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("CpfPessoa")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime>("DtNascPessoa")
                        .HasColumnType("DATE");

                    b.Property<string>("NomePessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<string>("SobreNomePessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int>("TipoPessoaId")
                        .HasColumnType("INT");

                    b.HasKey("PessoaId")
                        .HasName("PK_PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoPaciente", b =>
                {
                    b.Property<int>("PrescricaoPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescricaoPacienteId"));

                    b.Property<DateTime?>("CriadoEm")
                        .IsRequired()
                        .HasColumnType("DATETIME");

                    b.Property<string>("DescFichaPessoa")
                        .HasColumnType("VARCHAR(350)");

                    b.Property<DateTime>("Emissao")
                        .HasColumnType("DATETIME");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("DATETIME");

                    b.HasKey("PrescricaoPacienteId")
                        .HasName("PK_PrescricaoPacienteId");

                    b.HasIndex("MedicoId")
                        .IsUnique();

                    b.ToTable("PrescricaoPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.PrescricaoPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medico", "Medico")
                        .WithOne("PrescricaoPaciente")
                        .HasForeignKey("WEB_API_HealTime.Models.PrescricaoPaciente", "MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PrescricaoPaciente_Medico");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medico", b =>
                {
                    b.Navigation("PrescricaoPaciente");
                });
#pragma warning restore 612, 618
        }
    }
}
