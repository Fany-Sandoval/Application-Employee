using Acti.Conexion;
using Acti.Models;
using System.Collections.ObjectModel;

namespace Acti;

public partial class ListaUser : ContentPage
{
    private ApiService _apiService;
    public ObservableCollection<Personas> ListaPersonas { get; set; }
    public ListaUser()
    {
        InitializeComponent();
        _apiService = new ApiService();
        ListaPersonas = new ObservableCollection<Personas>();
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var listaPersonas = await _apiService.ObtenerListaPersonasAsync();

        if (listaPersonas != null)
        {
            foreach (var persona in listaPersonas)
            {
                ListaPersonas.Add(persona);
            }
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Personas persona)
        {
            // Confirmar la eliminación
            var confirmar = await DisplayAlert("Eliminar", $"¿Seguro que quieres eliminar a {persona.nombre}?", "Sí", "No");

            if (confirmar)
            {
                // Llamar al método para eliminar la persona
                var success = await _apiService.EliminarPersonaAsync(persona.id);

                if (success)
                {
                    // Eliminar la persona de la lista
                    ListaPersonas.Remove(persona);
                }
                else
                {
                    // Manejar error en la eliminación
                    await DisplayAlert("Error", "No se pudo eliminar la persona.", "Aceptar");
                }
            }
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Menu());
    }
}