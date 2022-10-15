namespace ChatApplication.Services.Abstractions
{
    public interface IChatChannelApi
    {
        Task<IList<T>> GetAllAsync<T>(string route);
        Task<T> CreateAsync<T>(T request, string route);
    }
}
