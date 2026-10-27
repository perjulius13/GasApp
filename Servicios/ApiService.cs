using GasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace GasApp.Servicios
{
    internal class ApiService
    {
        private readonly HttpClient _cliente = new HttpClient();


        public async Task<List<ComercioClass>> ListarComercios()
        {
            var response = await _cliente.GetAsync("https://www.urbanitycore.com/api/Comercios/ListarComercios");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ComercioClass>>(json);
            }

            return new List<ComercioClass>();
        }


        public async Task<UsuarioClass> Login(UsuarioClass user)
        {            
            string url = "https://www.urbanitycore.com/api/Usuario/Login";

            try
            {                
                HttpResponseMessage response = await _cliente.PostAsJsonAsync<UsuarioClass>(url, user);
                
                if (response.IsSuccessStatusCode)
                {
                    //return true;
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UsuarioClass>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la petición: {ex.Message}");
            }

            return new UsuarioClass();
        }



    }
}
