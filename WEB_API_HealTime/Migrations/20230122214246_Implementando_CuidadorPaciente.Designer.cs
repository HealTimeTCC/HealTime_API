﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_HealTime.Data;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230122214246_Implementando_CuidadorPaciente")]
    partial class ImplementandoCuidadorPaciente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEB_API_HealTime.Models.ContatoPessoa", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContatoId"));

                    b.Property<string>("EmailContato")
                        .HasColumnType("VARCHAR(70)");

                    b.Property<string>("PessoaId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneCelularObri")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneCelularOpcional")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("TipoCtt")
                        .HasColumnType("int");

                    b.HasKey("ContatoId");

                    b.ToTable("ContatoPessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.GrauParentesco", b =>
                {
                    b.Property<int>("GrauParentescoId")
                        .HasColumnType("int");

                    b.Property<string>("DescGrauParentesco")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("GrauParentescoId");

                    b.ToTable("GrausParentesco");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Property<string>("PessoaId")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("BairroEnderecoPessoa")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CepEndereco")
                        .HasColumnType("char(8)");

                    b.Property<string>("CidadeEnderecoPessoa")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ComplementoPessoa")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("CpfPessoa")
                        .HasColumnType("char(11)");

                    b.Property<DateTime>("DtNascimentoPesssoa")
                        .HasColumnType("date");

                    b.Property<DateTime>("DtUltimoAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnderecoPessoa")
                        .HasColumnType("varchar(45)");

                    b.Property<int>("GeneroPessoa")
                        .HasColumnType("int");

                    b.Property<string>("NomePessoa")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("ObsPacienteIncapaz")
                        .HasColumnType("varchar(350)");

                    b.Property<string>("SobrenomePessoa")
                        .HasColumnType("varchar(40)");

                    b.Property<int>("TipoPessoa")
                        .HasColumnType("int");

                    b.Property<int>("UfEndereco")
                        .HasColumnType("int");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ResponsavelPaciente", b =>
                {
                    b.Property<int>("ResponsavelPacienteId")
                        .HasColumnType("int");

                    b.Property<int>("GrauParentescoId")
                        .HasColumnType("int");

                    b.Property<string>("IdResponsavelPessoaId")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PacienteIdPessoaId")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PacienteInId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsavelId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResponsavelPacienteId");

                    b.HasIndex("GrauParentescoId");

                    b.HasIndex("IdResponsavelPessoaId");

                    b.HasIndex("PacienteIdPessoaId");

                    b.ToTable("ResponsaveisPaciente");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ResponsavelPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.GrauParentesco", "GrauParentesco")
                        .WithMany("ResponsavelPacientes")
                        .HasForeignKey("GrauParentescoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "IdResponsavel")
                        .WithMany()
                        .HasForeignKey("IdResponsavelPessoaId");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "PacienteId")
                        .WithMany()
                        .HasForeignKey("PacienteIdPessoaId");

                    b.Navigation("GrauParentesco");

                    b.Navigation("IdResponsavel");

                    b.Navigation("PacienteId");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.GrauParentesco", b =>
                {
                    b.Navigation("ResponsavelPacientes");
                });
#pragma warning restore 612, 618
        }
    }
}