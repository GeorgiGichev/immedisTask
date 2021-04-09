namespace EmplyeeSystem.Data.Configurations
{
    using System;

    using EmplyeeSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasOne(c => c.Employee)
                .WithMany(e => e.Comments)
                .HasForeignKey(c => c.EmployeeId);

            builder
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId)
                .IsRequired();
        }
    }
}
