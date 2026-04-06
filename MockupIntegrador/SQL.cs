using SQLite;
using PCLExt.FileStorage.Folders;

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