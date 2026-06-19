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

public class Inicializar
{
    // Esta funcao criamos para inicializar o banco de dados SQLite e criar as tabelas.
    public static void Inicializa()
    {
        SQL.fxConexao();
        //SQL.conexao.DropTable<ServicoItem>();

        SQL.conexao.CreateTable<Produtos>();
        SQL.conexao.CreateTable<Servicos>();
        SQL.conexao.CreateTable<ServicoItem>();
        SQL.conexao.CreateTable<PedidoModel>();
        SQL.conexao.CreateTable<PedPro>();
    }
}