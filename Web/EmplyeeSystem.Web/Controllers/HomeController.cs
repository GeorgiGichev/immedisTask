namespace EmplyeeSystem.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using EmployeeSystem.Web.ViewModels.Employees;
    using EmplyeeSystem.Services.Data.Employees;
    using EmplyeeSystem.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IEmployeeService employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new EmployeesListModel
            {
                Employees = (await this.employeeService.GetBySearchCriteriaAsync<EmployeesViewModel>(new EmployeesViewModel())).ToHashSet(),
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string name, string jobTitle, string department, DateTime? joinedOn)
        {
            var searchedCriteria = new EmployeesViewModel
            {
                Name = name,
                JobTitle = jobTitle,
                Department = department,
                JoinedOn = joinedOn,
            };
            var model = new EmployeesListModel
            {
                Employees = (await this.employeeService.GetBySearchCriteriaAsync<EmployeesViewModel>(searchedCriteria)).ToHashSet(),
            };
            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
