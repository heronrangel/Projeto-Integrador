using System.Globalization;

public class FuncoesGerais
{
    public static int so_numero(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }

        string apenasNumeros = new string(input.Where(char.IsDigit).ToArray());
        return int.TryParse(apenasNumeros, out int resultado) ? resultado : 0;
    }

    public static double so_numero_double(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }

        string apenasNumeros = new string(input.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
        return double.TryParse(apenasNumeros, out double resultado) ? resultado : 0;
    }

    public static double StrToDouble(string valorDinheiro)
    {
        if (string.IsNullOrEmpty(valorDinheiro))
        {
            return 0.0;
        }
        char ponto = '.';
        char virgula = ',';

        valorDinheiro = valorDinheiro.Replace("R", "").Replace("$", "").Replace(" ", "");

        int freqPonto = valorDinheiro.Split(ponto).Length - 1;
        int freqVirgula = valorDinheiro.Split(virgula).Length - 1;

        if (freqPonto > 0 && freqVirgula > 0)
        {
            valorDinheiro = valorDinheiro.Replace(".", "");
        }
        else
        {
            valorDinheiro = valorDinheiro.Replace(".", ",");
        }

        string valorLimpo = valorDinheiro.Replace("R$", "").Replace(" ", "").Trim();
        if (double.TryParse(valorLimpo, NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out double resultado))
        {
            return resultado;
        }
        else
        {
            return 0.0;
        }
    }
    public static string DoubleToStr(double valor)
    {
        return string.Format(new CultureInfo("pt-BR"), "R$ {0:N2}", valor);
    }
}