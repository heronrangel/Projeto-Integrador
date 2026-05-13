using SQLite;

public class PedidoModel
{
    [PrimaryKey,  AutoIncrement]
    public int ID { get; set; }
    public int Status { get; set; } // 0 = Em Aberto, 1 = Concluido
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
}

public class PedPro
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int IDPro { get; set; }
    public int IDPedido { get; set; }
    public string Servico { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public int Tipo { get; set; }
}