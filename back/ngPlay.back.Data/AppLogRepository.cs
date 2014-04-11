using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;

namespace ngPlay.back.Data
{
    public class AppLogRepository : IAppLogRepository
    {
        private readonly NgPlayDataContext _dataContext;

        public AppLogRepository(NgPlayDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Insert(AppLog logEntry)
        {
            return (int)_dataContext.Insert(logEntry);
        }
    }
}
