using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Data;
using WEB_API_HealTime.Dto.PrescricaoDTO;
using WEB_API_HealTime.Models.ConsultasMedicas;
using WEB_API_HealTime.Models.Medicacoes;
using WEB_API_HealTime.Repository.Interfaces;

namespace WEB_API_HealTime.Repository;

public class MedicacaoRepository : IMedicacaoRepository
{
	private readonly DataContext _context;
    public MedicacaoRepository(DataContext context){ _context = context; }

    public async Task<bool> IncluiPrescricaoMedicacao(List<PrescricaoMedicacao> listPrescricaoMedicacaos)
    {
		try
		{
            await _context.PrescricoesMedicacoes
                .AddRangeAsync(listPrescricaoMedicacaos);
			await _context.SaveChangesAsync();
			return true;
		}
		catch (Exception)
		{

			throw;
		}
    }

    public async Task<int> IncluiPrescricaoPaciente(PrescricaoPaciente prescricaoPaciente)
    {
        try
        {
			await _context.PrescricaoPacientes.AddRangeAsync(prescricaoPaciente);
            await _context.SaveChangesAsync();
			return prescricaoPaciente.PrescricaoPacienteId;
        }
		catch (Exception)
		{
			throw;
		}
	}

    public async Task<List<Medico>> ListarMedicos()
    {
		try
		{
			return await _context.Medicos.ToListAsync();//Como não havera muitos medicos esse endpoint pode ir assim mesmo
		}
		catch (Exception)
		{
			throw;
		}
    }

    public async Task<bool> MedicacaoExiste(int idMedicacao)
    {
		try
		{
            int id = await _context.Medicacoes
					.Where(x => x.MedicacaoId == idMedicacao)
					.Select(x => x.MedicacaoId)
                    .FirstOrDefaultAsync();
			return id != 0;
        }
		catch (Exception)
		{ 		
			throw;
		}
    }

    public async Task<bool> MedicoExiste(int id)
    {
		try
		{
			string crm = string.Empty;
			crm = await _context.Medicos
					.Where(x => x.MedicoId == id)
					.Select(c => c.CrmMedico)
					.FirstOrDefaultAsync();
			return crm != string.Empty;
		}
		catch (Exception)
		{
			throw;
		}
    }
}
