using Blazored.LocalStorage;
using System.Net.Http.Json;
using shared;

namespace reaause.Services.Login
{
    public class LoginServiceServer : ILoginService
    {
        private HttpClient client;
        private ILocalStorageService localStorage;
        private string serverUrl = "http://localhost:5129";

        public LoginServiceServer(HttpClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        public async Task<bool> Login(string email, string password)
        {
            var body = new { Email = email, Password = password };

            var response = await client.PostAsJsonAsync($"{serverUrl}/api/users/login", body);

            if (!response.IsSuccessStatusCode)
                return false;

            var user = await response.Content.ReadFromJsonAsync<User>();

            if (user != null)
            {
                await localStorage.SetItemAsync("user", user);
                return true;
            }

            return false;
        }

        public async Task<User?> GetUserLoggedIn()
        {
            return await localStorage.GetItemAsync<User>("user");
        }

        public async Task<User[]> GetAll()
        {
            return await client.GetFromJsonAsync<User[]>($"{serverUrl}/api/users");
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("user");
        }
    }
}