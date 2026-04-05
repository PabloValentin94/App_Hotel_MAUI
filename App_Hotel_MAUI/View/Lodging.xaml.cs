namespace App_Hotel_MAUI.View;

public partial class Lodging : ContentPage
{
	public Lodging()
	{
		InitializeComponent();
	}

    private async void btn_voltar_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}