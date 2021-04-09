namespace EmplyeeSystem.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EmplyeeSystem.Data.Common.Repositories;
    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Data.Models;
    using EmplyeeSystem.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeService : IEmployeeService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepo;

        public EmployeeService(IDeletableEntityRepository<Employee> employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        /// <summary>
        /// This method create new employee in the database.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to employee.</typeparam>
        /// <param name="input">This is the model comming from the controller.</param>
        /// <returns>No return type.</returns>
        public async Task CreateAsync<T>(T input)
        {
            var employee = input.To<Employee>();
            await this.employeeRepo.AddAsync(employee);
            await this.employeeRepo.SaveChangesAsync();
        }

        /// <summary>
        /// This method delete employee from the database.
        /// </summary>
        /// <param name="employeeId">The id of employee.</param>
        /// <returns>Return the id of deleted employee.</returns>
        public async Task<int> DeleteAsync(int employeeId)
        {
            var employee = await this.employeeRepo.All()
                           .FirstOrDefaultAsync(x => x.Id == employeeId);
            this.employeeRepo.Delete(employee);
            await this.employeeRepo.SaveChangesAsync();

            return employee.Id;
        }

        /// <summary>
        /// This method edit employee`s data in the database.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to employee.</typeparam>
        /// <param name="input">This is the model comming from the controller.</param>
        /// <returns>No return type.</returns>
        public async Task EditAsync<T>(T input)
        {
            var employeeToEdit = input.To<Employee>();
            var employee = await this.employeeRepo.All().Where(e => e.Id == employeeToEdit.Id).FirstOrDefaultAsync();
            await this.employeeRepo.UpdateModel(employee, input);
        }

        /// <summary>
        /// This method return employee by id to the controller.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to employee.</typeparam>
        /// <param name="id">This is the id of employee.</param>
        /// <returns>Return employee mapped to the generic model.</returns>
        public async Task<T> GetByIdAsync<T>(int id)
            => await this.employeeRepo.All().Where(e => e.Id == id).To<T>().FirstOrDefaultAsync();

        /// <summary>
        /// This method return list of employees by search criteria.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to employee and back to the submitted model.</typeparam>
        /// <param name="query">The model with search criteria.</param>
        /// <returns>Return list from employees mapped to the generic model.</returns>
        public async Task<IEnumerable<T>> GetBySearchCriteriaAsync<T>(T query)
        {
            IQueryable<Employee> employees = null;

            var employee = query.To<InputEmployeeSearchModel>();

            employees = this.employeeRepo.All();

            if (employee.Name != null)
            {
                employees = employees.Where(e => e.Name.ToLower().Contains(employee.Name.ToLower()));
            }

            if (employee.JobTitle != null)
            {
                employees = employees.Where(e => e.JobTitle.ToLower().Contains(employee.JobTitle.ToLower()));
            }

            if (employee.Department != null)
            {
                employees = employees.Where(e => e.Department.ToLower().Contains(employee.Department.ToLower()));
            }

            if (employee.JoinedOn.HasValue)
            {
                var date = employee.JoinedOn.Value.Date;
                employees = employees.Where(e => e.JoinedOn.Date == date);
            }

            var result = await employees.To<T>()
                .ToListAsync();

            return result;
        }
    }
}
