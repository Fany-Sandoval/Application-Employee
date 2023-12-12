using Acti.Conexion;
using Acti.Models;

namespace Acti;

public partial class PublicarEmpleo : ContentPage
{
    private readonly EmpleosService _apiService;
    public PublicarEmpleo()
	{
		InitializeComponent();
        _apiService = new EmpleosService();
    }

    private async void RegistrarEmpleoButton_Clicked(object sender, EventArgs e)
    {
        // Tu lógica para el botón Registrarse aquí
        await RegistrarEmpleoAsync();
    }
    private async Task RegistrarEmpleoAsync()
    {
        // Crea una instancia de la clase Personas con los datos ingresados en la vista
        var empleo = new Empleos
        {
            id_empleo = Id_EmpleoEntry.Text,
            puesto = PuestoEntry.Text,
            empresa = EmpresaEntry.Text,
            salario = SalarioEntry.Text,
            descripcion = DescripcionEntry.Text,
            lugar = LugarEntry.Text,
            correo = correoEntry.Text
        };

        // Llama al método del servicio de API para registrar la persona
        var registroExitoso = await _apiService.RegistrarEmpleoAsync(empleo);

        if (registroExitoso)
        {
            // Manejar el éxito, por ejemplo, mostrar un mensaje o navegar a otra página
            await DisplayAlert("Éxito", "Registro exitoso", "Aceptar");
        }
        else
        {
            // Manejar el error, por ejemplo, mostrar un mensaje de error
            await DisplayAlert("Error", "Fallo el registro", "Aceptar");
        }
    }
}