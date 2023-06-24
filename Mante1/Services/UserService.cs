using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace Mante1.Services
{
    public class UserService : IUserService
    {
        HttpClient httpClient;

        public UserService() { 
            httpClient = new HttpClient();
        }


        public Task<bool> AddUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(string codUser)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            Uri uri = new Uri(string.Format("https://webappjpm.azurewebsites.net/api/user/", string.Empty));
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    //Items = JsonSerializer.Deserialize<List<TodoItem>>(content, _serializerOptions);

                    var users = await response.Content.ReadFromJsonAsync<List<UserModel>>();
                    //    //El content se va a convertir en una cadena y se va a desserializar en una lista.
                        return users;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            //try
            //{
            //    //var response = await httpClient.GetAsync("http://192.168.2.207:52345/api/user/?CodUser='porrasmj'");
            //    var response = await httpClient.GetAsync("http://192.168.0.207:52345/api/user");
            //    //var response = await httpClient.GetAsync("http://jsonkeeper.com/b/LPRG");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var users = await response.Content.ReadFromJsonAsync<List<UserModel>>();
            //        //El content se va a convertir en una cadena y se va a desserializar en una lista.
            //        return users;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(@"\tERROR {0}", ex.Message);
            //}
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

        public async Task<bool> UpdateUser(UserModel user)
        {
            
            var response = await httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                //var user = await response.Content.ReadFromJsonAsync<UserModel>();
                //El content se va a convertir en una cadena y se va a desserializar en una lista.
                return true;
            }
            return default;
        }
    }
}
