namespace Application.Interfaces
{
    /// <summary>
    /// interface to manage the time 
    /// </summary>
    public interface IDateTimeService
    {
        DateTime NowUTC { get; }
    }
}
