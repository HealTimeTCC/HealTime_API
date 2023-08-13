
using Healtime.Domain.Enums;

namespace Healtime.Infra.Data.Utility;

public static class FormataDados
{
    #region Verificar o tamanho dos caracteres
    public static bool StringLenght(string compararString, TipoVerificadorCaracteresMinimos tipoVerificadorCaracteresMinimos)
    {
        switch (tipoVerificadorCaracteresMinimos)
        {
            case TipoVerificadorCaracteresMinimos.Nome:
                return compararString.Length >= 3 ? true : false;
            case TipoVerificadorCaracteresMinimos.Endereco:
                return compararString.Length > 3 ? true : false;
            case TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta:
                return compararString.Length > 10 ? true : false;
            case TipoVerificadorCaracteresMinimos.UF:
                return compararString.Length == 2 ? true : false;
            case TipoVerificadorCaracteresMinimos.CRM:
                return compararString.Length == 6 ? true : false;
            case TipoVerificadorCaracteresMinimos.Telefone:
                return compararString.Length == 10  ? true : false;
            case TipoVerificadorCaracteresMinimos.Celular:
                return compararString.Length == 11 || compararString.Length == 9 ? true : false;
            case TipoVerificadorCaracteresMinimos.CEP:
                return compararString.Length == 8 ? true : false;

            default: return false;//Não ira 
        }
    }
    #endregion

    #region Uf: Confirma existencia, e devolve uma Uf
    public static bool VerificarUF(int uf, out string ufString)
    {
        foreach (var item in Enum.GetValues(typeof(CodigoIBGEEnum)))
        {
            if (uf == (int)item)
            {
                ufString = item.ToString() ;
                return true;
            }
        }
        ufString = null;
        return false;
    }
    #endregion

    #region CPF: Confirma se é legitimo

    public static bool VerificadorCpfPessoa(string cpfString)
    {
        cpfString = cpfString.Replace(".", "").Replace("-", "");

        foreach (var item in cpfString)
        {
            if (!(int.TryParse(item.ToString(), out int result)))
                return false;
        }

        if (!(cpfString.Length == 11))
            return false;

        int first = int.Parse(cpfString.Substring(cpfString.Length - 2, 1));
        int second = int.Parse(cpfString.Substring(cpfString.Length - 1, 1));

        if (!(VerificarPriDigito(first, cpfString.Substring(0, 9))))
            return false;
        if (!(VerificarSegDigito(second, cpfString.Substring(0, 10))))
            return false;
        return true;
    }
    private static bool VerificarPriDigito(int first, string cpfString)
    {
        int[] multiDigitoUm = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }; //Nove digitos vamos para o FOR
        int mults = 0;
        for (int i = 0; i < multiDigitoUm.Length; i++)
        {
            mults += multiDigitoUm[i] * int.Parse(cpfString[i].ToString());
        }
        int num = mults;
        mults = mults % 11;
        if (mults < 2)
            mults = 0;
        else
            mults = 11 - mults;
        return mults == first ? true : false;
    }
    private static bool VerificarSegDigito(int second, string cpfString)
    {
        int[] multiDigitoDois = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int mults = 0;

        for (int i = 0; i < multiDigitoDois.Length; i++)
        {
            mults += multiDigitoDois[i] * int.Parse(cpfString[i].ToString());
        }
        mults = mults % 11;
        if (mults < 2)
            mults = 0;
        else
            mults = 11 - mults;
        return mults == second ? true : false;
    }

    #endregion

    #region Temporarios
    public static bool VerificarTelefoneCelular(string telefone)
    {
        if (telefone.Length == 11)
        {
            string dddNove = telefone.Substring(0, 2);
            bool dddVerdadeiro = VerificaDDD(dddNove);
            if (!dddVerdadeiro)
                return false;
            dddNove = telefone.Substring(2, 1);
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

    public static bool VerificarTelefoneFixo(string telefone)
    {
        if (telefone.Length == 10)
        {
            string dddIniTelFixo = telefone.Substring(0, 2);
            bool inicioTelFixo = VerificaDDD(dddIniTelFixo);
            if (!inicioTelFixo)
                return false;
            dddIniTelFixo = telefone.Substring(2, 1);
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

    static private bool VerificaIniFixo(string iniTelFixo)
    {
        if (int.Parse(iniTelFixo) >= 2 && int.Parse(iniTelFixo) <= 5)
            return true;
        else
            return false;
    }

    public static bool VerificaIniCelular(string dddNove)
    {
        if (int.Parse(dddNove) != 9)
            return false;
        else
            return true;
    }
    public static bool VerificaDDD(string dddVerifica)
    {
        int[] ddd = new int[23] { 23, 25, 26, 29, 20, 30, 36, 39, 40, 50, 52, 55, 56, 57, 58, 59, 60, 70, 72, 76, 78, 80, 90 };//atende False se encontrar um desses pois são ddd que nao sao utilizados
        foreach (var item in ddd)
        {
            if (item == int.Parse(dddVerifica)) return false;
        }
        return true;
    }
    public static bool VerificarDtNascimentoPessoa(DateTime dtNascimentoPessoa, EnumTipoPessoa tipoPessoa)
    {
        var idadePessoa = DateTime.Now.Year - dtNascimentoPessoa.Year;

        if (idadePessoa < 18 && tipoPessoa != EnumTipoPessoa.PacienteIncapaz)//Corrigir
            return false;
        if (dtNascimentoPessoa.Date >= DateTime.Now.AddYears(-3))
            return false;
        return true;
    }

    #endregion

    public static bool VerificaTempo(TimeSpan hora)
    {
        return hora >= TimeSpan.Parse("1") && hora <= TimeSpan.Parse("24");
    }
}
