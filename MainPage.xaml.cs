namespace PM2E1130145_V2
{
    public partial class MainPage : ContentPage
    {
        private const string color1 = "#DCFCE7";
        private const string color2 = "#EOF2FE";
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnCalcular_Clicked(object? sender, EventArgs e)
        {
            // Validar peso
            if (!double.TryParse(txtPeso.Text, out double peso) || peso <= 0)
            {
                await DisplayAlert("Error", "Por favor ingrese un peso válido mayor que 0.", "OK");
                return;
            }

            // Validar descripción
            string descripcion = txtDescripcion.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                await DisplayAlert("Error", "Por favor ingrese una descripción.", "OK");
                return;
            }

            // Calcular costo según zona
            double calcularCosto = pckZona.SelectedItem?.ToString() switch
            {
                "Zona Local" => peso * 50.00,
                "Zona Nacional" => peso * 85.00,
                "Zona Internacional" => peso * 150.00,
                _ => 0.0
            };

            // Costo express opcional
            if (chkExpress.IsChecked)
            {
                calcularCosto += 100.00;
            }

            if(calcularCosto<= 300)
            {
                contenedor.IsVisible = true;
                contenedor.BackgroundColor = color1;
            }
            else
            {
                contenedor.IsVisible = true;
                contenedor.BackgroundColor = color2;
            }

            lblResultado.Text = $"Costo de envío: L. {calcularCosto:N2}";

        }
    }
}
