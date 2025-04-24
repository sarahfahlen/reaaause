using shared;

namespace backend.Repository;

public interface ILoginRepository
{
    User[] GetAllUsers();
}