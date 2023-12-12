using Acti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Acti.Conexion
{
    public class EmpleosService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:44349/api/Empleos";

        public EmpleosService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> RegistrarEmpleoAsync(Empleos empleos)
        {
            try
            {
                var json = JsonSerializer.Serialize(empleos);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Captura más detalles sobre el error
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en la respuesta: {errorContent}");

                    // Puedes lanzar una excepción aquí o manejar el error según tus necesidades
                    // throw new Exception($"Error en la respuesta: {errorContent}");

                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejar errores aquí
                Console.WriteLine($"Error al registrar Empleo: {ex.Message}");
                return false;
            }
        }


         public async Task<List<Empleos>> ObtenerListaEmpleosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var listaEmpleos = JsonSerializer.Deserialize<List<Empleos>>(json);
                    return listaEmpleos;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en la respuesta: {errorContent}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de Empleos: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> EliminarEmpleoAsync(string id_empleo)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id_empleo}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en la respuesta: {errorContent}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empleo: {ex.Message}");
                return false;
            }
        }
    }
}
