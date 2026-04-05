using App_Hotel_MAUI.Model;

namespace App_Hotel_MAUI
{
    public partial class App : Application
    {
        internal static List<User> auth_users = new List<User>();

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new AppShell());

            window.Height = 600;
            window.Width = 350;

            return window;
        }
    }
}