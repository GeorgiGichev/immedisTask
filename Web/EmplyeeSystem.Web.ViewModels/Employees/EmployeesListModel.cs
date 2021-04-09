namespace EmployeeSystem.Web.ViewModels.Employees
{
    using System.Collections.Generic;

    public class EmployeesListModel
    {
        public EmployeesListModel()
        {
            this.Employees = new HashSet<EmployeesViewModel>();
        }

        public ICollection<EmployeesViewModel> Employees { get; set; }
    }
}