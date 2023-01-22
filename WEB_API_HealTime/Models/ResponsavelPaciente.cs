﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API_HealTime.Models;
public class ResponsavelPaciente
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ResponsavelPacienteId { get; set; }

    //Tem que testar esse relacionamento para ver se vai dar certo, tenho minhas dúvidas ksks
    [ForeignKey("Pessoas")]
    public string PacienteInId { get; set; }
    public Pessoa PacienteId { get; set; }

    //Esse vai funcionar normal, só precisa saber do de cima
    [ForeignKey("Pessoas")]
    public string ResponsavelId { get; set; }
    public Pessoa IdResponsavel { get; set; }

    public int GrauParentescoId { get; set; }
    public GrauParentesco GrauParentesco { get; set; }
}
