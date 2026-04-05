namespace App_Hotel_MAUI.Model
{
    public class Lodging // Hospedagem.
    {
        // Campos.

        private Bedroom selected_bedroom = new Bedroom();

        // Atributos.

        public Bedroom Selected_Bedroom {
            get => this.selected_bedroom;
            set
            {
                if (value == null)
                {
                    throw new Exception("Um quarto válido deve ser especificado!");
                }

                this.selected_bedroom = value;
            }
        }

        public int Adult_Quantity { get; set; } = 0;

        public int Child_Quantity { get; set; } = 0;

        public DateTime CheckIn_Date { get; set; }

        public DateTime CheckOut_Date { get; set; }

        public int Stay
        {
            get => this.CheckOut_Date.Subtract(this.CheckIn_Date).Days;
        }

        public double Lodging_Cost
        {
            get
            {
                double adult_cost = this.Adult_Quantity * this.Selected_Bedroom.Adult_Daily_Allowance_Price;

                double child_cost = this.Child_Quantity * this.Selected_Bedroom.Child_Daily_Allowance_Price;

                double total_cost = (adult_cost + child_cost) * this.Stay;

                return total_cost;
            }
        }
    }
}
