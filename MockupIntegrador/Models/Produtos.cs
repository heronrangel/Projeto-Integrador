using SQLite;

public class Produtos
{
    [AutoIncrement, PrimaryKey]
    public int ID { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public string Medida { get; set; }
    public double Estoque { get; set; }
    public string DisplayText
    {
        get { return $"{ID} - {Nome} - {FuncoesGerais.DoubleToStr(Valor)} ({Medida})"; }
    }
}

public class Servicos
{
    [AutoIncrement, PrimaryKey]
    public int ID { get; set; }
    public string Nome { get; set; }
}

public class ServicoItem : Produtos
{
    public int IDServico { get; set; }
    public double Quantidade { get; set; }
    public double Total { get; set; }
}
