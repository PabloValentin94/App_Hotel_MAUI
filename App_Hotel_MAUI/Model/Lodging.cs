namespace App_Hotel_MAUI.Model
{
    public class Lodging // Hospedagem.
    {
        // Campos.

        private Bedroom _selected_bedroom = new Bedroom();

        private int _adult_quantity = 0;

        private int _child_quantity = 0;

        // Atributos.

        public Bedroom Selected_Bedroom {
            get => this._selected_bedroom;
            set
            {
                if (value == null)
                {
                    throw new Exception("Um quarto válido deve ser especificado!");
                }

                this._selected_bedroom = value;
            }
        }

        public int Adult_Quantity
        {
            get => this._adult_quantity;
            set
            {
                if (value > 0)
                {
                    this._adult_quantity = value;
                }
            }
        }

        public int Child_Quantity
        {
            get => this._child_quantity;
            set
            {
                if (value >= 0)
                {
                    this._child_quantity = value;
                }
            }
        }

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
