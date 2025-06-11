using Order.BusinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Order.BusinessLogic.HttpClients
{
    public class UserMicroServiceClient
    {
        private readonly HttpClient _httpClient;
        public UserMicroServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserDTO?> GetUserByIserId(Guid userId)
        {
            var response = await _httpClient.GetAsync($"api/user/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new HttpRequestException("Bad request", null, System.Net.HttpStatusCode.BadRequest);
                }
                else
                {
                    throw new HttpRequestException("An error occurred while fetching user data", null, response.StatusCode);
                }
            }
            var user = await response.Content.ReadFromJsonAsync<UserDTO>();
            if (user is null)
            {
                throw new ArgumentException("Invalid UserId");
            }
            return user;
        }
    }
}
