namespace WinFormsAppPingPong
{
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
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "sound.wav";
            player.Play();
            ApplicationConfiguration.Initialize();
            Application.Run(new Game());
            
        }
    }
}