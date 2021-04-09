namespace EmplyeeSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using EmplyeeSystem.Services.Data.Comments;
    using EmplyeeSystem.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Mvc;

    public class CommentController : BaseController
    {
        private ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        /// <summary>
        /// This action create commnet to employee.
        /// </summary>
        /// <param name="model">Commnet data from input form.</param>
        /// <returns>Redirect to details page of employee to which it relates the comment.</returns>
        public async Task<IActionResult> Create(CommentInputModel model)
        {
            await this.commentService.CreateAsync<CommentInputModel>(model);
            return this.Redirect($"/Employee/Details/{model.EmployeeId}");
        }

        /// <summary>
        /// This action delete comment from comments of the Employee.
        /// </summary>
        /// <param name="commentId">the id of a comment.</param>
        /// <returns>Redirect to details page of employee to which it relates the comment.</returns>
        public async Task<IActionResult> Delete(int commentId)
        {
            var id = await this.commentService.DeleteAsync(commentId);
            return this.Redirect($"/Employee/Details/{id}");
        }

        /// <summary>
        /// This action edit the content of the comment.
        /// </summary>
        /// <param name="commentId">The id of a comment.</param>
        /// <param name="content">The new content of a comment.</param>
        /// <returns>Redirect to details page of employee to which it relates the comment.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int commentId, string content)
        {
            var comment = await this.commentService.GetByIdAsync<CommentEditModel>(commentId);
            comment.Content = content;
            var id = await this.commentService.EditAsync(comment);
            return this.Redirect($"/Employee/Details/{id}");
        }
    }
}
