using System.Net.Http.Json;
using reaause.Services.Facilities;
using shared;

namespace reaause.Services.Facility
{
    public class FacilityServiceServer : IFacilityService
    {
        private readonly HttpClient httpClient;

        public FacilityServiceServer(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<shared.Facility>> GetAllFacilities()
        {
            return await httpClient.GetFromJsonAsync<List<shared.Facility>>("api/facilities");
        }

        public async Task AddFacility(shared.Facility facility)
        {
            await httpClient.PostAsJsonAsync("api/facilities", facility);
        }
        public async Task<List<User>> GetAllStaffUsers()
        {
            return await httpClient.GetFromJsonAsync<List<User>>("api/users/staff");
        }
    }
}