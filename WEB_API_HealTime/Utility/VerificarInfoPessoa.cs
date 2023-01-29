using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using WEB_API_HealTime.Models;
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

    public bool VerificarTelefoneFixo(string telefone)
    {
        if (telefone.Length == 10)
        {
            string dddIniTelFixo = telefone.Substring(0, 2);
            bool inicioTelFixo = VerificaDDD(dddIniTelFixo);
            if (!inicioTelFixo)
                return false;
            dddIniTelFixo = telefone.Substring(2, 1);
            bool nove = VerificaIniFixo(dddIniTelFixo);
            if (!inicioTelFixo)
                return false;
            return true;
        }
        else if (telefone.Length == 8)
        {
            string dddNove = telefone.Substring(0, 1);
            bool nove = VerificaIniFixo(dddNove);
            if (!nove)
                return false;
            return true;
        }
        return false;
    }

    private bool VerificaIniFixo(string iniTelFixo)
    {
        if (int.Parse(iniTelFixo) >= 2 && int.Parse(iniTelFixo) <= 5)
            return true;
        else
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
        int[] ddd = new int[23] { 23, 25, 26, 29,20, 30, 36, 39, 40, 50, 52, 55, 56, 57, 58, 59, 60, 70, 72, 76, 78, 80, 90};//atende False se encontrar um desses pois são ddd que nao sao utilizados
        foreach (var item in ddd)
        {
            if(item == int.Parse(dddVerifica)) return false;
        }
        return true;
    }

    // Referente => Controller: AssociaPessoas
    //public bool AntiDuplicidade(Registro registro)
}

