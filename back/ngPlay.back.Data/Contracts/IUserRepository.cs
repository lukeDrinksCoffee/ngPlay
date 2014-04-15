using ngPlay.back.Data.Entities;

namespace ngPlay.back.Data.Contracts
{
    public interface IUserRepository
    {
        int Insert(User user);
        User Get(int id);
        User GetByName(string name);
        User GetByEmail(string email);
        int Update(User user);
        int UpdatePasswordHash(User user);
        int Delete(User user);
    }
}
