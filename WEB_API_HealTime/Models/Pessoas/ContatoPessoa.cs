﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WEB_API_HealTime.Models.Pessoas.Enums;

namespace WEB_API_HealTime.Models.Pessoas;

public class ContatoPessoa
{
    public int PessoaId { get; set; }
    [JsonIgnore]
    public Pessoa Pessoa { get; set; }
    public string Email { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? AtualizadoEm { get; set; }
    public string Telefone { get; set; }
    public string TelefoneSecundario { get; set; }
    public string Celular { get; set; }
    public string CelularSecundario { get; set; }
}
