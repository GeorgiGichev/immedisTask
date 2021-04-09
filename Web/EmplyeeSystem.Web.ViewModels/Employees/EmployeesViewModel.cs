namespace EmployeeSystem.Web.ViewModels.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Data.Models;
    using EmplyeeSystem.Services.Mapping;

    public class EmployeesViewModel : IMapTo<InputEmployeeSearchModel>, IMapFrom<Employee>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public DateTime? JoinedOn { get; set; }
    }
}
