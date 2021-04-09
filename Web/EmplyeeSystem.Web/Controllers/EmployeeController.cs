namespace EmplyeeSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using EmplyeeSystem.Services.Data.Comments;
    using EmplyeeSystem.Services.Data.Employees;
    using EmplyeeSystem.Web.ViewModels.Comments;
    using EmplyeeSystem.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeeController : BaseController
    {
        private IEmployeeService employeeService;
        private ICommentService commentService;

        public EmployeeController(IEmployeeService employeeService, ICommentService commentService)
        {
            this.employeeService = employeeService;
            this.commentService = commentService;
        }

        /// <summary>
        /// This action returns view with Details of the employee and his comments.
        /// </summary>
        /// <param name="id">The Id of a employee.</param>
        /// <param name="commentId">The Id of a comment(if no comment to edit it will be 0).</param>
        /// <returns>Returns the details view.</returns>
        public async Task<IActionResult> Details(int id, int commentId)
        {
            var employee = await this.employeeService.GetByIdAsync<EmployeeDetailsViewModel>(id);

            if (commentId == 0)
            {
                employee.CommentToEdit = new CommentEditModel();
            }
            else
            {
                employee.CommentToEdit = await this.commentService.GetByIdAsync<CommentEditModel>(commentId);
            }

            return this.View(employee);
        }

        /// <summary>
        /// This action returns empty form for creating new employee.
        /// </summary>
        /// <returns>Returns view with empty form.</returns>
        public IActionResult Create()
        {
            var model = new EmployeeInputModel();
            return this.View(model);
        }

        /// <summary>
        /// This action create new employee.
        /// </summary>
        /// <param name="model">The filled model from the create form.</param>
        /// <returns>Redirect to home page.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.employeeService.CreateAsync(model);
            return this.Redirect("/Home/Index");
        }

        /// <summary>
        /// This action returns filed form with the data of the employee who will edit.
        /// </summary>
        /// <param name="id">The Id of a employee.</param>
        /// <returns>Return view with filled form.</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.employeeService.GetByIdAsync<EmployeeInputModel>(id);
            return this.View(model);
        }

        /// <summary>
        /// This action edit the data of employee.
        /// </summary>
        /// <param name="model">this is the new data from edit form.</param>
        /// <returns>Redirect to home page.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.employeeService.EditAsync<EmployeeInputModel>(model);
            return this.Redirect("/Home/Index");
        }

        /// <summary>
        /// This action delete employee.
        /// </summary>
        /// <param name="id">The Id of employee.</param>
        /// <returns>Redirect to home page.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            await this.employeeService.DeleteAsync(id);
            return this.Redirect($"/Home/Index");
        }
    }
}
