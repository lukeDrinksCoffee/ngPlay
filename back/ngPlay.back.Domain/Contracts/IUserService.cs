
namespace ngPlay.back.Domain.Contracts
{
    public interface IUserService
    {
        bool IsUserNameUnique(string name);
        bool IsEmailUnique(string email);
    }
}
