namespace App_Hotel_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            InitializeShellContentComponents();
        }

        private async void InitializeShellContentComponents()
        {
            string? auth_key_value = await SecureStorage.Default.GetAsync("auth_user");

            if (String.IsNullOrWhiteSpace(auth_key_value))
            {
                shc_home.Content = new View.Login();
            }
            else
            {
                shc_home.Content = new View.DailyAllowanceCalculation();
            }
        }
    }
}
