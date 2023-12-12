using Acti.Conexion;
using Acti.Models;

namespace Acti;

public partial class Registrer : ContentPage
{
    private readonly ApiService _apiService;
    public Registrer()
    {
        InitializeComponent();
        _apiService = new ApiService();
        
    }
    private async void RegistrarseButton_Clicked(object sender, EventArgs e)
    {
        // Tu lógica para el botón Registrarse aquí
        await RegistrarPersonaAsync();
    }

    private async Task RegistrarPersonaAsync()
    {
        // Crea una instancia de la clase Personas con los datos ingresados en la vista
        var persona = new Personas
        {
            id = IdEntry.Text,
            nombre = NombreEntry.Text,
            apellidoPaterno = ApellidoPaternoEntry.Text,
            apellidoMaterno = ApellidoMaternoEntry.Text,
            telefono = TelefonoEntry.Text,
            email = emailEntry.Text,
            password = passwordEntry.Text
        };

        // Llama al método del servicio de API para registrar la persona
        var registroExitoso = await _apiService.RegistrarPersonaAsync(persona);

        if (registroExitoso)
        {
            // Manejar el éxito, por ejemplo, mostrar un mensaje o navegar a otra página
            await DisplayAlert("Éxito", "Registro exitoso", "Aceptar");
        }
        else
        {
            // Manejar el error, por ejemplo, mostrar un mensaje de error
            await DisplayAlert("Error", "No se pudo completar el registro", "Aceptar");
        }
    }
}