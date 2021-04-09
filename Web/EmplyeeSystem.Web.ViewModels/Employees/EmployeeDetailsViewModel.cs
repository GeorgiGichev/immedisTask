namespace EmplyeeSystem.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;

    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;
    using EmplyeeSystem.Web.ViewModels.Comments;

    public class EmployeeDetailsViewModel : IMapFrom<Employee>
    {
        public int Id { get; set; }

        public DateTime JoinedOn { get; set; }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }

        public int? ManagerId { get; set; }

        public string ManagerName { get; set; }

        public string Address { get; set; }

        public string AuthorId { get; set; }

        public CommentEditModel CommentToEdit { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
