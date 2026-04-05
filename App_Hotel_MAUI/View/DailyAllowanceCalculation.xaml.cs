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

        pck_bedroom.ItemsSource = this.bedrooms_options;

        pck_bedroom.SelectedIndex = 0;
    }

    private void dtpck_checkin_date_DateSelected(object sender, DateChangedEventArgs e)
    {
        //
    }

    private void dtpck_checkout_date_DateSelected(object sender, DateChangedEventArgs e)
    {
        //
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
}