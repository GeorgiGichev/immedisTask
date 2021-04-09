namespace EmplyeeSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using EmplyeeSystem.Data.Common.Models;

    public class Employee : BaseDeletableModel<int>
    {
        public Employee()
        {
            this.Comments = new HashSet<Comment>();
        }

        public DateTime JoinedOn { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public decimal Salary { get; set; }

        [Required]
        public string Department { get; set; }

        [ForeignKey(nameof(Employee))]
        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }

        [Required]
        public string Address { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
