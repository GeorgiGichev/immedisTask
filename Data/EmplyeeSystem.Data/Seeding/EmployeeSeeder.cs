namespace EmplyeeSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EmplyeeSystem.Data.Models;

    public class EmployeeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Employees.Any())
            {
                return;
            }

            var employees = new HashSet<Employee>()
            {
                new Employee
                {
                    Name = "Ivan Ivanov",
                    JobTitle = "Developer",
                    Department = "Development",
                    Salary = 2600,
                    JoinedOn = DateTime.Now,
                    Address = "Varna, str.Batak 6",
                },
                new Employee
                {
                    Name = "Georgi Georgiev",
                    JobTitle = "Senior Developer",
                    Department = "Development",
                    Salary = 5000,
                    JoinedOn = DateTime.Now,
                    Address = "Varna, str.Shipka 10",
                },
                new Employee
                {
                    Name = "Petyr Petrov",
                    JobTitle = "Junior Developer",
                    Department = "Development",
                    Salary = 1800,
                    JoinedOn = DateTime.Now,
                    Address = "Varna, str.Vitosha 18",
                },
            };

            await dbContext.Employees.AddRangeAsync(employees);
            await dbContext.SaveChangesAsync();
        }
    }
}
