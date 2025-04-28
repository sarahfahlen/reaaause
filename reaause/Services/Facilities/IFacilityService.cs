using shared;

namespace reaause.Services.Facilities
{
    public interface IFacilityService
    {
        Task<List<shared.Facility>> GetAllFacilities();
        Task AddFacility(shared.Facility facility);
        Task<List<User>> GetAllStaffUsers();
    }
}