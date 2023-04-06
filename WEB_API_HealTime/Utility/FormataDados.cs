using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using WEB_API_HealTime.Dto.Pessoa;
using WEB_API_HealTime.Utility.Enums;
using WEB_API_HealTime.Utility.EnumsGlobal;

namespace WEB_API_HealTime.Utility;

public static class FormataDados
{
    public static bool StringLenght(string compararString, TipoVerificadorCaracteresMinimos tipoVerificadorCaracteresMinimos)
    {
        switch (tipoVerificadorCaracteresMinimos)
        {
            case TipoVerificadorCaracteresMinimos.Nome:
                return compararString.Length > 3 ? true : false;
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

    public static bool VerificarUF(int uf)
    {
        foreach (var item in Enum.GetValues(typeof(CodigoIBGEEnum)))
        {
            if (uf == (int)item)
                return true;
        }
        return false;
    }
}
