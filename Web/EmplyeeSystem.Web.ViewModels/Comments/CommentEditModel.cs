namespace EmplyeeSystem.Web.ViewModels.Comments
{
    using EmplyeeSystem.Data.Models;
    using EmplyeeSystem.Services.Mapping;

    public class CommentEditModel : IMapTo<Comment>, IMapFrom<Comment>
    {
        public int EmployeeId { get; set; }

        public int Id { get; set; }

        public string Content { get; set; }
    }
}
