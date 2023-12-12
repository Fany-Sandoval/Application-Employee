using Acti.Models;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Acti.Conexion
{
    public class ApiService
    {

        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:44349/api/Personas";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> RegistrarPersonaAsync(Personas persona)
        {
            try
            {
                var json = JsonSerializer.Serialize(persona);
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
                Console.WriteLine($"Error al registrar persona: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Personas>> ObtenerListaPersonasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var listaPersonas = JsonSerializer.Deserialize<List<Personas>>(json);
                    return listaPersonas;
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
                Console.WriteLine($"Error al obtener la lista de personas: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> EliminarPersonaAsync(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");

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
                Console.WriteLine($"Error al eliminar persona: {ex.Message}");
                return false;
            }
        }

       
    }
}