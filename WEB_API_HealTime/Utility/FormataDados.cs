using WEB_API_HealTime.Utility.Enums;

namespace WEB_API_HealTime.Utility;

public static class FormataDados
{
    public static bool VerificadorCaracteresMinimos(string compararString, TipoVerificadorCaracteresMinimos tipoVerificadorCaracteresMinimos)
    {
        switch (tipoVerificadorCaracteresMinimos)
        {
            case TipoVerificadorCaracteresMinimos.Nome:
                if (compararString.Length < 3)
                    return true;
                return false;
            case TipoVerificadorCaracteresMinimos.Endereco:
                if (compararString.Length < 3)
                    return true; ;
                return false;
            case TipoVerificadorCaracteresMinimos.MotivoCancelamentoConsulta:
                if(compararString.Length < 10)
                    return true;
                return false;
            default: return false;//Não ira 
        }
    }
}
