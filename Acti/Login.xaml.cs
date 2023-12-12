

using Acti.Conexion;

namespace Acti;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();

        
       
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registrer());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            StatusLabel.Text = "Por favor, ingrese un email y contrase�a v�lidos.";
            return;
        }

        // Aqu� deber�as tener una instancia de tu servicio de autenticaci�n (LoginService)
        var loginService = new LoginService();

        // Llama al m�todo de autenticaci�n
        bool loginResult = await loginService.LoginAsync(email, password);

        if (loginResult)
        {
            // Inicio de sesi�n exitoso
            StatusLabel.Text = string.Empty;
            await DisplayAlert("�xito", "Inicio de sesi�n correcto", "OK");
            await Navigation.PushAsync(new Menu());
        }
        else
        {
            StatusLabel.Text = string.Empty;
            await DisplayAlert("Error", "Credenciales Invalidas", "OK");
        }

    }
}