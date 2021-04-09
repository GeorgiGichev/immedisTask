namespace EmplyeeSystem.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<IEnumerable<T>> GetBySearchCriteriaAsync<T>(T employee);

        Task<T> GetByIdAsync<T>(int id);

        Task EditAsync<T>(T input);

        Task CreateAsync<T>(T input);

        Task<int> DeleteAsync(int employeeId);
    }
}
