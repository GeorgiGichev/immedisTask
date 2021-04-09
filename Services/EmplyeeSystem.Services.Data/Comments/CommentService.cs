namespace EmplyeeSystem.Services.Data.Comments
{
    using System.Linq;
    using System.Threading.Tasks;

    using EmplyeeSystem.Data.Common.Repositories;
    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CommentService : ICommentService
    {
        private IDeletableEntityRepository<Comment> commentRepo;

        public CommentService(IDeletableEntityRepository<Comment> commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        /// <summary>
        /// This method create new comment in the database.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to comment.</typeparam>
        /// <param name="model">This is the model comming from the controller.</param>
        /// <returns>Return the id of the created comment.</returns>
        public async Task<int> CreateAsync<T>(T model)
        {
            var comment = model.To<Comment>();
            await this.commentRepo.AddAsync(comment);
            await this.commentRepo.SaveChangesAsync();
            return comment.Id;
        }

        /// <summary>
        /// This method delete comment from the database.
        /// </summary>
        /// <param name="id">The id of comment.</param>
        /// <returns>Return the id of employee to whom the comment relates.</returns>
        public async Task<int> DeleteAsync(int id)
        {
            var comment = await this.commentRepo.All()
                           .FirstOrDefaultAsync(x => x.Id == id);
            this.commentRepo.Delete(comment);
            await this.commentRepo.SaveChangesAsync();

            return comment.EmployeeId;
        }

        /// <summary>
        /// This method edit comment`s data in the database.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to comment.</typeparam>
        /// <param name="model">This is the model comming from the controller.</param>
        /// <returns>Return the id of employee to whom the comment relates.</returns>
        public async Task<int> EditAsync<T>(T model)
        {
            var inputComment = model.To<Comment>();
            var comment = await this.commentRepo.All().Where(c => c.Id == inputComment.Id).FirstOrDefaultAsync();
            await this.commentRepo.UpdateModel<T>(comment, model);
            await this.commentRepo.SaveChangesAsync();
            return comment.EmployeeId;
        }

        /// <summary>
        /// This method return comment by id to the controller.
        /// </summary>
        /// <typeparam name="T">This is generic wich will be mapped to comment.</typeparam>
        /// <param name="id">The id of comment.</param>
        /// <returns>Return comment mapped to the generic model.</returns>
        public async Task<T> GetByIdAsync<T>(int id)
           => await this.commentRepo.All().Where(c => c.Id == id).To<T>().FirstOrDefaultAsync();
    }
}
