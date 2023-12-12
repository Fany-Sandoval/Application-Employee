using Acti.Conexion;
using Acti.Models;
using System.Collections.ObjectModel;

namespace Acti;

public partial class ListaEmpleos : ContentPage
{
    private EmpleosService _apiService;
    public ObservableCollection<Empleos> Lista { get; set; }
    public ListaEmpleos()
    {
        InitializeComponent();
        _apiService = new EmpleosService();
        Lista = new ObservableCollection<Empleos>();
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var lista = await _apiService.ObtenerListaEmpleosAsync();

        if (lista != null)
        {
            foreach (var empleos in lista)
            {
                Lista.Add(empleos);
            }
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Empleos empleos)
        {
            // Confirmar la eliminación
            var confirmar = await DisplayAlert("Eliminar", $"¿Seguro que quieres eliminar a {empleos.empresa}?", "Sí", "No");

            if (confirmar)
            {
                // Llamar al método para eliminar la persona
                var success = await _apiService.EliminarEmpleoAsync(empleos.id_empleo);

                if (success)
                {
                    // Eliminar la persona de la lista
                    Lista.Remove(empleos);
                }
                else
                {
                    // Manejar error en la eliminación
                    await DisplayAlert("Error", "No se pudo eliminar el empleo.", "Aceptar");
                }
            }
        }
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        // Obtén el elemento seleccionado en la colección
        var selectedItem = (Empleos)((Button)sender).BindingContext;

        // Verifica que el elemento no sea nulo
        if (selectedItem != null)
        {
            // Accede a los atributos del objeto y crea el mensaje para el DisplayAlert
            string mensaje = $"Descripción: {selectedItem.descripcion}\n" +
                             $"Lugar: {selectedItem.lugar}\n" +
                             $"Correo: {selectedItem.correo}";

            // Muestra el DisplayAlert
            await DisplayAlert("Detalles del Trabajo", mensaje, "OK");

        }
    }

    
    private void Button_Clicked_4(object sender, EventArgs e)
    {
        var nombreUsuario = Preferences.Get("NombreUsuario", string.Empty);
        // Muestra el DisplayAlert con el nombre de usuario y el mensaje de postulación
        DisplayAlert("Postulación", $"Te has postulado, {nombreUsuario}!", "OK");
    }
}