using App_Hotel_MAUI.Model;

namespace App_Hotel_MAUI.View;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void OpenPage(ContentPage page)
    {
        await Navigation.PushAsync(page);
    }

    private async void btn_login_Clicked(object sender, EventArgs e)
    {
        try
        {
            User auth_user = new User()
            {
                Email = txt_email.Text,
                Password = txt_senha.Text
            };

            bool verification_result = App.auth_users.Any((User current_user) =>
            {
                return current_user.Email.Equals(auth_user.Email) && current_user.ComparePasswordValues(auth_user);
            });

            if (!verification_result)
            {
                throw new Exception("Usuário não encontrado! Revise seus dados e tente novamente.");
            }

            await SecureStorage.Default.SetAsync("auth_user", auth_user.Email);

            OpenPage(new DailyAllowanceCalculation());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro!", ex.Message, "OK");
        }
    }

    private async void btn_action_Clicked(object sender, EventArgs e)
    {
        OpenPage(new Register());
    }
}