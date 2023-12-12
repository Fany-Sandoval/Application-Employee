

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
            StatusLabel.Text = "Por favor, ingrese un email y contraseña válidos.";
            return;
        }

        // Aquí deberías tener una instancia de tu servicio de autenticación (LoginService)
        var loginService = new LoginService();

        // Llama al método de autenticación
        bool loginResult = await loginService.LoginAsync(email, password);

        if (loginResult)
        {
            // Inicio de sesión exitoso
            StatusLabel.Text = string.Empty;
            await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
            await Navigation.PushAsync(new Menu());
        }
        else
        {
            StatusLabel.Text = string.Empty;
            await DisplayAlert("Error", "Credenciales Invalidas", "OK");
        }

    }
}