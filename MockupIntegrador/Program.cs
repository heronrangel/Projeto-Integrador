namespace MockupIntegrador
{
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

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Inicializar.Inicializa();
            Application.Run(new Pedido());
        }
    }
}