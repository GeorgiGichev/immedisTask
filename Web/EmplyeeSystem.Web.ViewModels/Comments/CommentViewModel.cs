namespace EmplyeeSystem.Web.ViewModels.Comments
{
    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUserName { get; set; }

        public string Content { get; set; }
    }
}
