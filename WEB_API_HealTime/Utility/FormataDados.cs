using Microsoft.IdentityModel.Tokens;
using WEB_API_HealTime.Utility.Enums;

namespace WEB_API_HealTime.Utility;

public static class FormataDados
{
    public static bool VerificadorCaracteresMinimos(string compararString, TipoVerificadorCaracteresMinimos tipoVerificadorCaracteresMinimos)
    {
        switch (tipoVerificadorCaracteresMinimos)
        {
            case TipoVerificadorCaracteresMinimos.Nome:
                return compararString.Length < 3 ? true : false;
            case TipoVerificadorCaracteresMinimos.Endereco:
                return compararString.Length < 3 ? true : false;
            case TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta:
                return compararString.Length < 10 ? true : false;
            case TipoVerificadorCaracteresMinimos.UF:
                return compararString.Length == 2 ? true : false;
            case TipoVerificadorCaracteresMinimos.CRM:
                return compararString.Length == 6 ? true : false;
            case TipoVerificadorCaracteresMinimos.Telefone:
                return compararString.Length == 10  ? true : false;
            case TipoVerificadorCaracteresMinimos.Celular:
                return compararString.Length == 11 || compararString.Length == 9 ? true : false;
            
            default: return false;//Não ira 
        }
    }

}
