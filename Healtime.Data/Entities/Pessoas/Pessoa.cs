﻿using Healtime.Domain.Entities.Medicacoes;
using Healtime.Domain.Entities.Pacientes;
using Healtime.Domain.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healtime.Domain.Entities.Pessoas;

public class Pessoa
{
    public int PessoaId { get; set; }
    public EnumTipoPessoa TipoPessoa { get; set; }
    public string CpfPessoa { get; set; }
    public string NomePessoa { get; set; }
    public string SobreNomePessoa { get; set; }
    [NotMapped]
    public string PasswordString { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DtNascPessoa { get; set; }
    [NotMapped]
    public string TokenJwt { get; set; }
    public byte[] FotoUsuario { get; set; }
    public List<PrescricaoPaciente> PrescricaoPacientes { get; set; }
    public EnderecoPessoa EnderecoPessoa { get; set; } 
    public ContatoPessoa ContatoPessoa { get; set; }
    public List<ObservacaoPaciente> ObservacoesPacientes { get; set; }
    public List<CuidadorPaciente> CuidadorPaciente_Pacientes { get; set; }
    public List<CuidadorPaciente> CuidadorPaciente_Cuidador { get; set; }
    public List<ResponsavelPaciente> ResponsavelPacientes_Responsavel { get; set; }
    public List<ResponsavelPaciente> ResponsavelPacientes_Pacientes { get; set; }
}
