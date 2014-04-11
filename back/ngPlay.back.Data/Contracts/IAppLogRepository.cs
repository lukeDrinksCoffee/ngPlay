
using ngPlay.back.Data.Entities;

namespace ngPlay.back.Data.Contracts
{
    public interface IAppLogRepository
    {
        int Insert(AppLog logEntry);
    }
}
