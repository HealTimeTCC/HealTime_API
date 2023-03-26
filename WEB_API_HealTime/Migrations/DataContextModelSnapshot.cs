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

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", b =>
                {
                    b.Property<int>("ConsultasAgendadasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsultasAgendadasId"));

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DataSolicitacaoConsulta")
                        .HasColumnType("DATE");

                    b.Property<string>("Encaminhamento")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("int");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("MotivoConsulta")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int>("StatusConsultasId")
                        .HasColumnType("int");

                    b.HasKey("ConsultasAgendadasId")
                        .HasName("PK_ConsultaAgendadaId");

                    b.HasIndex("EspecialidadeId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("StatusConsultasId");

                    b.ToTable("ConsultasAgendadas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaCancelada", b =>
                {
                    b.Property<int>("ConsultaCanceladaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsultaCanceladaId"));

                    b.Property<int>("ConsultaAgendadaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCancelamento")
                        .HasColumnType("DATE");

                    b.Property<string>("MotivoCancelamento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.HasKey("ConsultaCanceladaId", "ConsultaAgendadaId")
                        .HasName("PK_ConsultaCancelada_ConsultaAgendada");

                    b.HasIndex("ConsultaAgendadaId")
                        .IsUnique();

                    b.ToTable("ConsultaCanceladas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Especialidade", b =>
                {
                    b.Property<int>("EspecialidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecialidadeId"));

                    b.Property<string>("DescEspecialidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.HasKey("EspecialidadeId")
                        .HasName("PK_EspecialidadeId");

                    b.ToTable("Especialidades");

                    b.HasData(
                        new
                        {
                            EspecialidadeId = 1,
                            DescEspecialidade = "Cardiologia"
                        },
                        new
                        {
                            EspecialidadeId = 2,
                            DescEspecialidade = "Dermatologia"
                        },
                        new
                        {
                            EspecialidadeId = 3,
                            DescEspecialidade = "Ginecologia/Obstetrícia"
                        },
                        new
                        {
                            EspecialidadeId = 4,
                            DescEspecialidade = "Ortopedia"
                        },
                        new
                        {
                            EspecialidadeId = 5,
                            DescEspecialidade = "Anestesiologia"
                        },
                        new
                        {
                            EspecialidadeId = 6,
                            DescEspecialidade = "Pediatria"
                        },
                        new
                        {
                            EspecialidadeId = 7,
                            DescEspecialidade = "Oftalmologia"
                        },
                        new
                        {
                            EspecialidadeId = 8,
                            DescEspecialidade = "Psiquiatria"
                        },
                        new
                        {
                            EspecialidadeId = 9,
                            DescEspecialidade = "Urologia"
                        },
                        new
                        {
                            EspecialidadeId = 10,
                            DescEspecialidade = "Oncologia"
                        },
                        new
                        {
                            EspecialidadeId = 11,
                            DescEspecialidade = "Endocrinologia"
                        },
                        new
                        {
                            EspecialidadeId = 12,
                            DescEspecialidade = "Neurologia"
                        },
                        new
                        {
                            EspecialidadeId = 13,
                            DescEspecialidade = "Hematologia"
                        },
                        new
                        {
                            EspecialidadeId = 14,
                            DescEspecialidade = "Cirurgia Plástica"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicoId"));

                    b.Property<string>("CrmMedico")
                        .HasColumnType("CHAR(6)");

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
                            CrmMedico = "054321",
                            NmMedico = "Dr Val",
                            UfCrmMedico = "SP"
                        },
                        new
                        {
                            MedicoId = 2,
                            CrmMedico = "012345",
                            NmMedico = "Dr Teste",
                            UfCrmMedico = "RJ"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.StatusConsulta", b =>
                {
                    b.Property<int>("StatusConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusConsultaId"));

                    b.Property<string>("DescStatusConsulta")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.HasKey("StatusConsultaId")
                        .HasName("PK_StatusConsultaId");

                    b.ToTable("StatusConsultas");

                    b.HasData(
                        new
                        {
                            StatusConsultaId = 1,
                            DescStatusConsulta = "Encerrada"
                        },
                        new
                        {
                            StatusConsultaId = 2,
                            DescStatusConsulta = "Agendada"
                        },
                        new
                        {
                            StatusConsultaId = 3,
                            DescStatusConsulta = "Cancelada"
                        },
                        new
                        {
                            StatusConsultaId = 4,
                            DescStatusConsulta = "Remarcada"
                        },
                        new
                        {
                            StatusConsultaId = 5,
                            DescStatusConsulta = "Fila de espera"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.Property<int>("MedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicacaoId"));

                    b.Property<string>("CompostoAtivoMedicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Generico")
                        .IsRequired()
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("LaboratorioMedicaocao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<string>("NomeMedicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<int>("StatusMedicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("TipoMedicacaoId")
                        .HasColumnType("int");

                    b.HasKey("MedicacaoId")
                        .HasName("PK_MedicacaoId");

                    b.HasIndex("TipoMedicacaoId");

                    b.ToTable("Medicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("CpfPessoa")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime?>("DtNascPessoa")
                        .IsRequired()
                        .HasColumnType("DATE");

                    b.Property<string>("NomePessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SobreNomePessoa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<int?>("TipoPessoaId")
                        .IsRequired()
                        .HasColumnType("INT");

                    b.HasKey("PessoaId")
                        .HasName("PK_PessoaId");

                    b.ToTable("Pessoas");

                    b.HasData(
                        new
                        {
                            PessoaId = 1,
                            CpfPessoa = "12345678909",
                            DtNascPessoa = new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NomePessoa = "Dan",
                            PasswordHash = new byte[] { 53, 128, 235, 171, 166, 185, 233, 109, 229, 173, 73, 111, 236, 178, 201, 202, 243, 100, 246, 198, 102, 179, 251, 202, 65, 251, 172, 205, 227, 200, 187, 22, 65, 2, 99, 80, 158, 60, 185, 55, 64, 207, 24, 91, 127, 38, 180, 156, 61, 188, 179, 47, 159, 181, 224, 163, 111, 39, 205, 252, 56, 143, 19, 195 },
                            PasswordSalt = new byte[] { 103, 52, 87, 58, 7, 160, 117, 226, 132, 57, 134, 222, 246, 86, 125, 64, 47, 185, 251, 169, 145, 3, 131, 150, 139, 122, 252, 206, 173, 178, 137, 232, 19, 250, 234, 210, 244, 216, 10, 85, 162, 227, 130, 124, 141, 116, 207, 24, 179, 82, 202, 82, 75, 229, 50, 167, 147, 156, 94, 33, 178, 244, 222, 242, 67, 3, 159, 88, 94, 237, 70, 176, 121, 30, 138, 161, 88, 179, 32, 119, 222, 134, 241, 31, 253, 93, 75, 224, 123, 25, 20, 210, 62, 104, 205, 42, 112, 231, 242, 202, 121, 131, 196, 154, 102, 65, 96, 226, 253, 40, 189, 233, 208, 114, 79, 230, 79, 40, 137, 191, 149, 25, 5, 239, 200, 36, 185, 209 },
                            SobreNomePessoa = "Marzo",
                            TipoPessoaId = 1
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoMedicacao", b =>
                {
                    b.Property<int>("PrescricaoPacienteId")
                        .HasColumnType("int");

                    b.Property<int>("MedicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<int>("Intervalo")
                        .HasColumnType("int");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<string>("StatusMedicacaoFlag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(1)")
                        .HasDefaultValue("S");

                    b.HasKey("PrescricaoPacienteId", "MedicacaoId")
                        .HasName("PK_CONCAT_PrescricaPacienteId_MedicacaoId");

                    b.HasIndex("MedicacaoId")
                        .IsUnique();

                    b.HasIndex("PrescricaoPacienteId");

                    b.ToTable("PrescricoesMedicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
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

                    b.Property<string>("FlagStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(1)")
                        .HasDefaultValue("S");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("DATETIME");

                    b.HasKey("PrescricaoPacienteId")
                        .HasName("PK_PrescricaoPacienteId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PrescricaoPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", b =>
                {
                    b.Property<int>("TipoMedicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoMedicacaoId"));

                    b.Property<int>("ClasseAplicacao")
                        .HasColumnType("int");

                    b.Property<string>("DescMedicacao")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("TituloTipoMedicacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("TipoMedicacaoId")
                        .HasName("PK_TipoMedicacaoId");

                    b.ToTable("TiposMedicacoes");

                    b.HasData(
                        new
                        {
                            TipoMedicacaoId = 1,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Aplicado pela boca",
                            TituloTipoMedicacao = "Via oral"
                        },
                        new
                        {
                            TipoMedicacaoId = 2,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Aplicado  por dembaixo da língua",
                            TituloTipoMedicacao = "Sublingual"
                        },
                        new
                        {
                            TipoMedicacaoId = 3,
                            ClasseAplicacao = 1,
                            DescMedicacao = "Aplicado pelo canal retal",
                            TituloTipoMedicacao = "Supositorios"
                        },
                        new
                        {
                            TipoMedicacaoId = 4,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicada diretamente no sangue",
                            TituloTipoMedicacao = "Intravenosa"
                        },
                        new
                        {
                            TipoMedicacaoId = 5,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicada diretamente no músculo",
                            TituloTipoMedicacao = "Intramuscular"
                        },
                        new
                        {
                            TipoMedicacaoId = 6,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicada debaixo da pele",
                            TituloTipoMedicacao = "Subcutânea"
                        },
                        new
                        {
                            TipoMedicacaoId = 7,
                            ClasseAplicacao = 2,
                            DescMedicacao = "",
                            TituloTipoMedicacao = "Respiratória"
                        },
                        new
                        {
                            TipoMedicacaoId = 8,
                            ClasseAplicacao = 2,
                            DescMedicacao = "Aplicada por pomadas",
                            TituloTipoMedicacao = "Via tópica"
                        },
                        new
                        {
                            TipoMedicacaoId = 9,
                            ClasseAplicacao = 2,
                            DescMedicacao = "",
                            TituloTipoMedicacao = "Via Ocular"
                        },
                        new
                        {
                            TipoMedicacaoId = 10,
                            ClasseAplicacao = 2,
                            DescMedicacao = "",
                            TituloTipoMedicacao = "Via Nasal"
                        },
                        new
                        {
                            TipoMedicacaoId = 11,
                            ClasseAplicacao = 2,
                            DescMedicacao = "",
                            TituloTipoMedicacao = "Via Auricular"
                        });
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.Especialidade", "Especialidade")
                        .WithMany("ConsultaAgendadas")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_EspecialidadeId");

                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.Medico", "Medico")
                        .WithMany("ConsultaAgendadas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MedicoId_ConsultaAgendadaId");

                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.StatusConsulta", "StatusConsulta")
                        .WithMany("ConsultasAgendadas")
                        .HasForeignKey("StatusConsultasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ConsultaAgendadas_StatusConsulta");

                    b.Navigation("Especialidade");

                    b.Navigation("Medico");

                    b.Navigation("StatusConsulta");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaCancelada", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", "ConsultaAgendada")
                        .WithOne("ConsultaCancelada")
                        .HasForeignKey("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaCancelada", "ConsultaAgendadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ConsultaAgendadaId");

                    b.Navigation("ConsultaAgendada");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", "TipoMedicacao")
                        .WithMany("Medicacoes")
                        .HasForeignKey("TipoMedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Medicacao_TipoMedicacao");

                    b.Navigation("TipoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoMedicacao", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.Medicacao", "Medicacao")
                        .WithOne("PrescricaoMedicacao")
                        .HasForeignKey("WEB_API_HealTime.Models.Medicacoes.PrescricaoMedicacao", "MedicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_MedicacaoId_PrescricaoMedicao");

                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", "PrescricaoPaciente")
                        .WithMany("PrescricoesMedicacoes")
                        .HasForeignKey("PrescricaoPacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PK_PrescricaoPacienteId_PrescricaoMedicao");

                    b.Navigation("Medicacao");

                    b.Navigation("PrescricaoPaciente");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
                {
                    b.HasOne("WEB_API_HealTime.Models.ConsultasMedicas.Medico", "Medico")
                        .WithMany("PrescricoesPacientes")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PrescricaoPaciente_Medico");

                    b.HasOne("WEB_API_HealTime.Models.Medicacoes.Pessoa", "Pessoa")
                        .WithMany("PrescricaoPacientes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PacienteId_PrescricoesPacientes");

                    b.Navigation("Medico");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.ConsultaAgendada", b =>
                {
                    b.Navigation("ConsultaCancelada");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Especialidade", b =>
                {
                    b.Navigation("ConsultaAgendadas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.Medico", b =>
                {
                    b.Navigation("ConsultaAgendadas");

                    b.Navigation("PrescricoesPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.ConsultasMedicas.StatusConsulta", b =>
                {
                    b.Navigation("ConsultasAgendadas");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Medicacao", b =>
                {
                    b.Navigation("PrescricaoMedicacao");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.Pessoa", b =>
                {
                    b.Navigation("PrescricaoPacientes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.PrescricaoPaciente", b =>
                {
                    b.Navigation("PrescricoesMedicacoes");
                });

            modelBuilder.Entity("WEB_API_HealTime.Models.Medicacoes.TipoMedicacao", b =>
                {
                    b.Navigation("Medicacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
