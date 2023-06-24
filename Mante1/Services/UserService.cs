using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mante1.Services
{
    public class UserService : IUserService
    {
        HttpClient httpClient;

        public UserService() { 
            httpClient = new HttpClient();
        }


        public async Task AddUser(UserModel user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://webappjpm.azurewebsites.net/api/user/", content);
                if (response.IsSuccessStatusCode)
                {
                      //Se podría hcacer algo si se agregó bien.
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public Task<bool> DeleteUser(string codUser)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                var response = await httpClient.GetAsync("https://webappjpm.azurewebsites.net/api/user/");
                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<List<UserModel>>();
                    //El content se va a convertir en una cadena y se va a desserializar en una lista.
                    return users;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return default;
        }

        public async Task<UserModel> GetByCod(string codUser)
        {
            var response = await httpClient.GetAsync("http://localhost:52345/Get?" + codUser);
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserModel>();
                //El content se va a convertir en una cadena y se va a desserializar en una lista.
                return user;
            }
            return default;
        }

        public async Task UpdateUser(UserModel user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync("https://webappjpm.azurewebsites.net/api/user/", content);
                if (response.IsSuccessStatusCode)
                {
                    //Se podría hcacer algo si se agregó bien.
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
