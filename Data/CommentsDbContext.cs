#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rapid_news_media_comments_api.Models;

public class CommentsDbContext : DbContext
{
    public CommentsDbContext(DbContextOptions<CommentsDbContext> options)
        : base(options)
    {
    }

    public DbSet<rapid_news_media_comments_api.Models.Comment> Comments { get; set; }

    //Data seeding

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>().HasData(
            new Comment {Id=1, NewsReportId = 1, Description="Interesting article", CreatedBy="Erika Mullen", CreatedByUsername="erika", DateCreated = DateTime.Now, Status = "active"},
            new Comment {Id=2, NewsReportId = 1, Description="I agree with their point of view.", CreatedBy="Jessica Luarez", CreatedByUsername="jessica", DateCreated = DateTime.Now, Status = "active"},
            new Comment {Id=3, NewsReportId = 2, Description="Great article and valid observations.", CreatedBy="John Smith", CreatedByUsername="john", DateCreated = DateTime.Now, Status = "active"}
        );
    }
}
