using ngPlay.back.Data.Contracts;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.Domain.Entities;

using dbEntity = ngPlay.back.Data.Entities;

namespace ngPlay.back.Domain.Services
{
    public class AppLogService : IAppLogService
    {
        private IAppLogRepository _repository;

        public AppLogService(IAppLogRepository repository)
        {
            _repository = repository;
        }

        public int Add(AppLogEntry logEntry)
        {
            // Map from domain to data entity
            var dbAppLogEntry = new dbEntity.AppLog
            {
                TimeStamp = logEntry.TimeStamp,
                Detail = logEntry.Detail
            };

            return _repository.Insert(dbAppLogEntry);
        }
    }
}
