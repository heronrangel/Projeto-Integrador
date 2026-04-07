using SQLite;

public class PedidoModel
{
    [PrimaryKey,  AutoIncrement]
    public int ID { get; set; }
    public int Status { get; set; } // 0 = Em Aberto, 1 = Concluido
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public string Itens { get; set; }
}
