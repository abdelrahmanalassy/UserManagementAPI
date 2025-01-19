using System.Net.Http.Json;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class RandomUserService
    {
        private readonly HttpClient _httpClient;
        public RandomUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserModel>> FetchRandomUserAsync(int count)
        {
            var response = await _httpClient.GetFromJsonAsync<RandomUserApiResponse>($"api/?results={count}");
            return response.Results.Select(r => new UserModel
            {
                FirstName = r.Name.First,
                LastName = r.Name.Last,
                Email = r.Email,
                Dob = DateTime.Parse(r.Dob.Date),
                Country = r.Location.Country
            }).ToList();
        }
    }
}