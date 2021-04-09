namespace EmplyeeSystem.Web.ViewModels.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;

    public class EmployeeInputModel : IMapTo<Employee>, IMapFrom<Employee>
    {
        public int Id { get; set; }

        public DateTime JoinedOn { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public decimal Salary { get; set; }

        [Required]
        public string Department { get; set; }

        public int? ManagerId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string AuthorId { get; set; }
    }
}
