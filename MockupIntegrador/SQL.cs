using SQLite;
using PCLExt.FileStorage.Folders;

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

public class SQL
{
    public static SQLiteConnection conexao;

    public static object fxConexao()
    {
        try
        {
            if (conexao is null)
            {
                var pasta = new LocalRootFolder();
                var arquivo = pasta.CreateFile("db", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
                conexao = new SQLiteConnection(arquivo.Path);
            }

            return conexao;

        }
        catch (Exception error)
        {
            return null;
        }
    }

    public static string fxPathDB()
    {
        var pasta = new LocalRootFolder();
        var arquivo = pasta.CreateFile("db", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
        return arquivo.Path;
    }
}