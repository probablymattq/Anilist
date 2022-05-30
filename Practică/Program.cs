namespace Practică
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize applsicatsion configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfisguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}