using App_Hotel_MAUI.Model;

namespace App_Hotel_MAUI.View;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    private async void ClosePage()
    {
        await Navigation.PopAsync();
    }

    private async void btn_register_Clicked(object sender, EventArgs e)
    {
        try
        {
            User user = new User()
            {
                Name = txt_nome_completo.Text,
                Email = txt_email.Text,
                Password = txt_senha.Text
            };

            App.auth_users.Add(user);

            ClosePage();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro!", ex.Message, "OK");
        }
    }

    private async void btn_action_Clicked(object sender, EventArgs e)
    {
        ClosePage();
    }
}