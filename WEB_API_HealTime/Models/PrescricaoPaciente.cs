
using Newtonsoft.Json;

namespace WEB_API_HealTime.Models;

public class PrescricaoPaciente
{
    //Modelo para informações da prescrição, adicão de medicamento é feita por outra controller
    public int PrescricaoPacienteId { get; set; }
    public int? PacienteId { get; set; }
    [JsonIgnore]
    public Pessoa PacienteRePresc { get; set; }
    public string DescFichaPessoa { get; set; }
    public DateTime? DataCadastroSistemaPrescricao { get; set; }
    public DateTime? EmissaoPrescricao { get; set; }
    [JsonIgnore]
    public ICollection<PrescricaoMedicamento> PrescricaoMedicamentos { get; set; }
}
