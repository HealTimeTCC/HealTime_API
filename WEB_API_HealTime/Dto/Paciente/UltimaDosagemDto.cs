﻿namespace WEB_API_HealTime.Dto.Paciente;

public class UltimaDosagemDto
{
    public string NomePaciente { get; set; }
    public int PacienteId { get; set; }
    public int CodAplicador { get; set; }
    public DateTime? UltimaDosage { get; set; }
}
