using Newtonsoft.Json;
using WEB_API_HealTime.Models.Enuns;

namespace WEB_API_HealTime.Utility;

public class VerificarInfoPessoa
{
    //Verificador de cpf (inicio)
    public int Soma { get; set; }
    public int ResulMulti { get; set; }
    public int ResulMod { get; set; }

    public bool VerificadorCpfPessoa(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        if (VerificarPriDigito(cpf.ToCharArray()) && VerificarSegDigito(cpf.ToCharArray()))
            return true;
        else
            return false;
    }

    private bool VerificarPriDigito(char[] cpf)
    {
        var tools = new VerificarInfoPessoa();

        int multi = 10;
        for (int i = 0; i < 9; i++)
        {
            tools.ResulMulti = multi * (int)char.GetNumericValue(cpf[i]);
            tools.Soma += tools.ResulMulti;
            --multi;
        }

        if (DigitoVerificador(tools.Soma) == (int)char.GetNumericValue(cpf[9]))
            return (true);
        else
            return (false);
    }

    private bool VerificarSegDigito(char[] cpf)
    {
        var tools = new VerificarInfoPessoa();

        int multi = 11;
        for (int i = 0; i < 10; i++)
        {
            tools.ResulMulti = multi * (int)char.GetNumericValue(cpf[i]);
            tools.Soma += tools.ResulMulti;
            --multi;
        }

        if (DigitoVerificador(tools.Soma) == (int)char.GetNumericValue(cpf[10]))
            return (true);
        else
            return (false);
    }

    private int DigitoVerificador(int valoresSomados)
    {
        int resulId = 11 - (valoresSomados % 11);

        if (resulId >= 10)
            return (0);
        else
            return (resulId);

    }
    //Verificador de cpf (fim)

    public bool VerificarNomePessoa(String nomePessoa, String sobrenomePessoa)
    {
        if ((nomePessoa.Length >= 3) && (sobrenomePessoa.Length >= 2))
            return true;
        else
            return false;
    }

    public bool VerificarDtNascimentoPessoa(DateTime dtNascimentoPessoa, TipoPessoa tipoPessoa)
    {
        var idadePessoa = DateTime.Now.Year - dtNascimentoPessoa.Year;

        if (idadePessoa < 18 && tipoPessoa != TipoPessoa.Paciente_Incapaz)
            return false;
        if (dtNascimentoPessoa.Date >= DateTime.Now.AddYears(-3))
            return false;

        return true;
    }


}
