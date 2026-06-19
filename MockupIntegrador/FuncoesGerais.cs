using System.Globalization;
using System.Text.RegularExpressions;

/*
    * Projeto: Projeto Integrador II (La Salle)
    * Software desenvolvido em conjunto por:
    * - Heron Rangel Agostinho
    * - Eduardo Henrique Copatti
    *
    * Data: Semestre 1/2026
    * Descrição: Sistema para gerir uma lavanderia com a possibilidade de cadastrar insumos (produtos), serviços,
    * pedidos e estoque. Foi desenvolvido ao logo do primeiro semestre de 2026.
    */

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


    // Esta funcao criamos para atualizar o estoque, consumir ou devoler itens.
    public static void FxEstoque(int IDPed, bool consome = true)
    {
        var produtos = SQL.conexao.Query<PedPro>($"SELECT * FROM PedPro WHERE IDPedido = {IDPed};");
        foreach (var produto in produtos)
        {
            var servicoItem = SQL.conexao.Query<ServicoItem>($"SELECT * FROM ServicoItem WHERE IDServico = {produto.IDServico}");
            foreach (var s in servicoItem)
            {
                var pro = SQL.conexao.Query<Produtos>($"SELECT * FROM Produtos WHERE ID = {s.IDProduto}").FirstOrDefault();
                if (pro != null)
                {
                    double quantUsada = s.Quantidade * produto.Quantidade;
                    double est = consome ? pro.Estoque - quantUsada : pro.Estoque + quantUsada;
                    pro.Estoque = est < 0 ? 0 : est;
                    SQL.conexao.Update(pro);
                }
            }
        }
    }
}