using App_Hotel_MAUI.Model;

namespace App_Hotel_MAUI.View;

public partial class DailyAllowanceCalculation : ContentPage
{
    List<Bedroom> bedrooms_options = new List<Bedroom>()
    {
        new Bedroom()
        {
            Name = "Suíte Super Luxo",
            Adult_Daily_Allowance_Price = 500.00,
            Child_Daily_Allowance_Price = 250.00
        },
        new Bedroom()
        {
            Name = "Suíte de Luxo",
            Adult_Daily_Allowance_Price = 200.00,
            Child_Daily_Allowance_Price = 100.00
        },
        new Bedroom()
        {
            Name = "Suíte Comum",
            Adult_Daily_Allowance_Price = 100.00,
            Child_Daily_Allowance_Price = 50.00
        }
    };

	public DailyAllowanceCalculation()
	{
		InitializeComponent();

        PrepareDateComponentsValidations();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        ApplyAuthConfigurations();
    }

    private async void ApplyAuthConfigurations()
    {
        string? auth_user = await SecureStorage.Default.GetAsync("auth_user");

        if (!String.IsNullOrWhiteSpace(auth_user))
        {
            lbl_auth_user.IsVisible = true;

            lbl_auth_user.Text = auth_user;

            btn_logout.IsVisible = true;
        }
        else
        {
            lbl_auth_user.IsVisible = false;

            btn_logout.IsVisible = false;
        }
    }

    private void PrepareDateComponentsValidations()
    {
        // Preenchendo o seletor de suítes.

        pck_bedroom.ItemsSource = this.bedrooms_options;

        pck_bedroom.SelectedIndex = 0;

        // Configurando o seletor de data de check-in.

        DateTime current_date = DateTime.Now;

        dtpck_checkin_date.MinimumDate = current_date;

        dtpck_checkin_date.MaximumDate = current_date.AddMonths(1);

        // Configurando o seletor de data de check-out.

        dtpck_checkout_date.MinimumDate = dtpck_checkin_date.MinimumDate.Value.AddDays(1);

        dtpck_checkout_date.MaximumDate = dtpck_checkin_date.MaximumDate.Value.AddMonths(2);
    }

    private void dtpck_checkin_date_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (e.OldDate != null && e.NewDate != null && e.OldDate.Value != e.NewDate.Value)
        {
            dtpck_checkout_date.MinimumDate = e.NewDate.Value.AddDays(1);

            dtpck_checkout_date.MaximumDate = e.NewDate.Value.AddMonths(2);
        }
    }

    private async void btn_calculate_daily_allowance_Clicked(object sender, EventArgs e)
    {
        try
        {
            Model.Lodging lodging = new Model.Lodging()
            {
                Selected_Bedroom = (Bedroom) pck_bedroom.SelectedItem,
                Adult_Quantity = Convert.ToInt32(stp_adult_quantity.Value),
                Child_Quantity = Convert.ToInt32(stp_child_quantity.Value),
                CheckIn_Date = dtpck_checkin_date.Date.Value,
                CheckOut_Date = dtpck_checkout_date.Date.Value
            };

            ContentPage lodging_page = new View.Lodging()
            {
                BindingContext = lodging
            };

            await Navigation.PushAsync(lodging_page);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro!", ex.Message, "OK");
        }
    }

    private void stepper_quantity_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        /*
            Essa lógica deveria impedir incosistências, mas o contador de cliques
            do componente (Stepper) do MAUI possui bugs internos.
        */

        Stepper stepper = (Stepper) sender;

        if (e.NewValue < stepper.Minimum)
        {
            stepper.Value = stepper.Minimum;

        }
        
        if (e.NewValue > stepper.Maximum)
        {
            stepper.Value = stepper.Maximum;
        }
    }

    private async void btn_logout_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlertAsync("Atenção!", "Realmente deseja encerrar a sessão no aplicativo?", "Sim", "Não"))
        {
            SecureStorage.Default.RemoveAll();

            ApplyAuthConfigurations();
        }
    }
}