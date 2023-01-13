using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
    
    public bool VerificarTelefoneCelular(string telefone)
    {
        if(telefone.Length == 11)
        {
            string dddNove = telefone.Substring(0,2);
            bool dddVerdadeiro = VerificaDDD(dddNove);
            if(!dddVerdadeiro)
                return false;
            dddNove = telefone.Substring(2,1);
            bool nove = VerificaIniCelular(dddNove);
            if (!dddVerdadeiro)
                return false;
            return true;
        }
        else if (telefone.Length == 9)
        {
            string dddNove = telefone.Substring(0, 1);
            bool nove = VerificaIniCelular(dddNove);
            if (!nove)
                return false;
            return true;
        }
        return false;
    }
    public bool VerificaIniCelular(string dddNove)
    {
        if (int.Parse(dddNove) != 9)
            return false;
        else
            return true;
    }
    public bool VerificaDDD(string dddVerifica)
    {
        switch (int.Parse(dddVerifica))
        {
            case 23: return false;case 25: return false;case 26: return false;case 29: return false;
            case 20: return false;case 30: return false;case 36: return false;case 39: return false;
            case 40: return false;case 50: return false;case 52: return false;case 55: return false;
            case 56: return false;case 57: return false;case 58: return false;case 59: return false;
            case 60: return false;case 70: return false;case 72: return false;case 76: return false;
            case 78: return false;case 80: return false;case 90: return false;
            default: return true;
        }
    }
}

