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
    [Migration("20230208011145_CuidadorPaciente")]
    partial class CuidadorPaciente
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

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("TelefoneCelularObri")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneCelularOpcional")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("TelefoneFixo")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<int>("TipoCtt")
                        .HasColumnType("int");

                    b.HasKey("ContatoId")
                        .HasName("PK_ContatoPessoas");

                    b.HasIndex("PessoaId");

                    b.ToTable("ContatoPessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.CuidadorPaciente", b =>
                {
                    b.Property<int>("CuidadorPacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CuidadorPacienteId"));

                    b.Property<DateTime?>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CuidadorId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteIncapazId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("CuidadorPacienteId")
                        .HasName("PK_CuidadorPacienteId");

                    b.HasIndex("CuidadorId");

                    b.HasIndex("PacienteIncapazId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("CuidadorPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.GrauParentesco", b =>
                {
                    b.Property<int>("GrauParentescoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrauParentescoId"));

                    b.Property<string>("DescGrauParentesco")
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("GrauParentescoId")
                        .HasName("PK_GrauParentescoId");

                    b.ToTable("GrausParentesco");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("BairroEnderecoPessoa")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("CepEndereco")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("CidadeEnderecoPessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("ComplementoPessoa")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<string>("CpfPessoa")
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime?>("DtNascimentoPessoa")
                        .IsRequired()
                        .HasColumnType("SMALLDATETIME");

                    b.Property<DateTime?>("DtUltimoAcesso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("EnderecoPessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.Property<int>("GeneroPessoa")
                        .HasColumnType("int");

                    b.Property<string>("NomePessoa")
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("ObsPacienteIncapaz")
                        .HasColumnType("VARCHAR(350)");

                    b.Property<string>("SobrenomePessoa")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("TipoPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("UfEndereco")
                        .HasColumnType("int");

                    b.HasKey("PessoaId")
                        .HasName("PK_Pessoas");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ResponsavelPaciente", b =>
                {
                    b.Property<string>("ResponsavelPacienteId")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("GrauParentescoId")
                        .HasColumnType("int");

                    b.Property<int?>("PacienteInId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.HasKey("ResponsavelPacienteId")
                        .HasName("PK_ResponsavelPacienteId");

                    b.HasIndex("GrauParentescoId")
                        .IsUnique()
                        .HasFilter("[GrauParentescoId] IS NOT NULL");

                    b.HasIndex("PacienteInId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("ResponsaveisPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ContatoPessoa", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "Pessoa")
                        .WithMany("ContatosPessoas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pessoas_ContatosPessoas");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.CuidadorPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "CuidadorRelacaoNoPessoas")
                        .WithMany("CuidadorIdCpRE")
                        .HasForeignKey("CuidadorId")
                        .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_CuidadorId");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "PacienteIncapazRelacaoNoPessoas")
                        .WithMany("PacienteInIdCpRE")
                        .HasForeignKey("PacienteIncapazId")
                        .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_PacienteIncapazId");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "ResponsavelRelacaoNoPessoas")
                        .WithMany("ResponsavelIdCpRE")
                        .HasForeignKey("ResponsavelId")
                        .HasConstraintName("FK_PESSOAS_CUIDADORPACIENTE_RESPONSAVELID");

                    b.Navigation("CuidadorRelacaoNoPessoas");

                    b.Navigation("PacienteIncapazRelacaoNoPessoas");

                    b.Navigation("ResponsavelRelacaoNoPessoas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ResponsavelPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.GrauParentesco", "GrauParentesco")
                        .WithOne("ResponsavelPacientes")
                        .HasForeignKey("WEB_API_HealTime.Models.ResponsavelPaciente", "GrauParentescoId")
                        .HasConstraintName("FK_ResponsavelPaciente_GRAUPARENTESCO");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "PacienteId")
                        .WithMany("PacienteIdInRe")
                        .HasForeignKey("PacienteInId")
                        .HasConstraintName("FK_PESSOAS_RESPONSAVELPACIENTE_PACIENTEINID");

                    b.HasOne("WEB_API_HealTime.Models.Pessoa", "IdResponsavel")
                        .WithMany("ResponsavelIdRe")
                        .HasForeignKey("ResponsavelId")
                        .HasConstraintName("FK_PESSOAS_RESPONSAVELPACIENTE_RESPONSAVELID");

                    b.Navigation("GrauParentesco");

                    b.Navigation("IdResponsavel");

                    b.Navigation("PacienteId");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.GrauParentesco", b =>
                {
                    b.Navigation("ResponsavelPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Pessoa", b =>
                {
                    b.Navigation("ContatosPessoas");

                    b.Navigation("CuidadorIdCpRE");

                    b.Navigation("PacienteIdInRe");

                    b.Navigation("PacienteInIdCpRE");

                    b.Navigation("ResponsavelIdCpRE");

                    b.Navigation("ResponsavelIdRe");
                });
#pragma warning restore 612, 618
        }
    }
}
