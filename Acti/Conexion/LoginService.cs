using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Acti.Conexion
{
    public class LoginService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:44349/api/Personas/login"; // Reemplaza con la URL de tu endpoint de inicio de sesión

        public LoginService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                var loginData = new { Email = email, Password = password };
                var json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Preferences.Set("NombreUsuario", email); // o el campo correspondiente
                                                             // Aquí puedes realizar alguna lógica adicional si lo necesitas
                                                             // Aquí puedes realizar alguna lógica adicional si lo necesitas
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
                Console.WriteLine($"Error al iniciar sesión: {ex.Message}");
                return false;
            }
        }
    }
}
