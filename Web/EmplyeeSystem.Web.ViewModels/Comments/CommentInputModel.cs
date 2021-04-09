namespace EmplyeeSystem.Web.ViewModels.Comments
{
    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;

    public class CommentInputModel : IMapTo<Comment>
    {
        public int EmployeeId { get; set; }

        public string AuthorId { get; set; }

        public string Content { get; set; }
    }
}
