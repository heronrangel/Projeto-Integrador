public class Inicializar
{
    public static void Inicializa()
    {
        SQL.fxConexao();
        //SQL.conexao.DropTable<Produtos>();
        SQL.conexao.CreateTable<Produtos>();
        SQL.conexao.CreateTable<Servicos>();
        SQL.conexao.CreateTable<ServicoItem>();
        SQL.conexao.CreateTable<PedidoModel>();
        SQL.conexao.DropTable<PedPro>();
        SQL.conexao.CreateTable<PedPro>();
    }
}