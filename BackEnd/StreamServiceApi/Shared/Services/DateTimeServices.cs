using Application.Interfaces;

namespace Shared.Services
{
    public class DateTimeServices : IDateTimeService
    {
        public DateTime NowUTC => DateTime.UtcNow;
    }
}
