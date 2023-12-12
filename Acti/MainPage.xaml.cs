namespace Acti
{
    public partial class MainPage : ContentPage
    {

        private bool IsUserLoggedIn { get; set; }
        public MainPage()
        {
            InitializeComponent();
            IsUserLoggedIn = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn)
            {
                // Si el usuario no ha iniciado sesión, muestra una alerta
                await DisplayAlert("Alerta", "Primero debes iniciar sesión", "OK");
                return;
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}