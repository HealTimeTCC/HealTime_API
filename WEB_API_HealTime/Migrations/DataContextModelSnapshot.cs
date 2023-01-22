﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_API_HealTime.Data;

#nullable disable

namespace WEBAPIHealTime.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("varchar(40)");

                    b.Property<string>("TelefoneCelular")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("TipoCtt")
                        .HasColumnType("int");

                    b.HasKey("ContatoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("ContatoPessoas");
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

            modelBuilder.Entity("WEB_API_HealTime.Models.ContatoPessoa", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", null)
                        .WithMany("ContatosPessoa")
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Navigation("ContatosPessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
