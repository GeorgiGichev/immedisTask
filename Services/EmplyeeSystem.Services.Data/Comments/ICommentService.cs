namespace EmplyeeSystem.Services.Data.Comments
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task<int> CreateAsync<T>(T model);

        Task<int> DeleteAsync(int id);

        Task<T> GetByIdAsync<T>(int id);

        Task<int> EditAsync<T>(T model);
    }
}
