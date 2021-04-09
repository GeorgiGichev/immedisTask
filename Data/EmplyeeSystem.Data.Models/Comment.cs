namespace EmplyeeSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using EmplyeeSystem.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
