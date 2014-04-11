using ngPlay.back.Domain.Entities;

namespace ngPlay.back.Domain.Contracts
{
    public interface IAppLogService
    {
        int Add(AppLogEntry logEntry);
    }
}
