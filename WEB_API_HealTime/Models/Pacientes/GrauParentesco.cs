﻿namespace WEB_API_HealTime.Models.Pacientes;

public class GrauParentesco
{
    public int GrauParentescoId { get; set; }
    public string DescGrauParentesco { get; set; }
    public List<ResponsavelPaciente> ResponsavelPacientes { get; set; }
}
