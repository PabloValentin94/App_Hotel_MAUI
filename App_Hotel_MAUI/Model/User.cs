namespace App_Hotel_MAUI.Model
{
    public class User // Usuário.
    {
        // Campos.

        private string _name = String.Empty;

        private string _email = String.Empty;

        private string _password = String.Empty;

        // Atributos.

        public string Name
        {
            get => this._name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Insira um nome válido para o usuário!");
                }

                this._name = value;
            }
        }

        public string Email
        {
            get => this._email;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Insira um e-mail válido para o usuário!");
                }

                this._email = value;
            }
        }

        public string Password
        {
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Insira uma senha válida para o usuário!");
                }

                this._password = value;
            }
        }

        // Métodos.

        public bool ComparePasswordValues(User user)
        {
            return this._password.Equals(user._password);
        }
    }
}
