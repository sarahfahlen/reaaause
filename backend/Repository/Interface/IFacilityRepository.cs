using shared;
namespace backend.Repository
{
    public interface IFacilityRepository
    {
        Task<List<Facility>> GetAllFacilities();
        Task AddFacility(Facility facility);
    }
}