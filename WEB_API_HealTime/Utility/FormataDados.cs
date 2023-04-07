using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using WEB_API_HealTime.Dto.Pessoa;
using WEB_API_HealTime.Utility.Enums;
using WEB_API_HealTime.Utility.EnumsGlobal;

namespace WEB_API_HealTime.Utility;

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
}
