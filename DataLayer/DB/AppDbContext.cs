using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {    }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<QuestionTag> QuestionTags { get; set; }
    public DbSet<Saved> Saves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>()
        .HasMany(e => e.QuestionTags)
        .WithOne(e => e.Tag)
        .HasForeignKey(e => e.TagId)
        .IsRequired(false);
        //Users

        modelBuilder.Entity<User>()
        .HasMany(e => e.Answers)
        .WithOne(e => e.User)
        .HasForeignKey(e => e.UserId)
        .IsRequired(false);

        modelBuilder.Entity<User>()
        .HasMany(e => e.Saves)
        .WithOne(e => e.User)
        .HasForeignKey(e => e.UserId)//
        .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
        .HasMany(e => e.Comments)
        .WithOne(e => e.UserComment)
        .HasForeignKey(e => e.UserId)
        .IsRequired(false);

        modelBuilder.Entity<User>()
        .HasMany(e => e.Questions)
        .WithOne(e => e.User)
        .HasForeignKey(e => e.UserId)
        .IsRequired(false);

        //Answer
        modelBuilder.Entity<Answer>()
        .HasMany(e => e.Saveds)//
        .WithOne(e => e.Answer)
        .HasForeignKey(e => e.AnswerId)
        .IsRequired(false);

        modelBuilder.Entity<Answer>()
        .HasMany(e => e.Comments)
        .WithOne(e => e.Answer)
        .HasForeignKey(e => e.AnswerId)
        .IsRequired(false);

        //Questionstags
        modelBuilder.Entity<Question>()
        .HasMany(e => e.QuestionTags)//
        .WithOne(e => e.Question)
        .HasForeignKey(e => e.QuestionId)
        .IsRequired(false);

        //Question
        modelBuilder.Entity<Question>()
        .HasMany(e => e.Saves)
        .WithOne(e => e.Question)//
        .HasForeignKey(e => e.QuestionId)
        .IsRequired(false);

        modelBuilder.Entity<Question>()
        .HasMany(e => e.Comments)
        .WithOne(e => e.Question)
        .HasForeignKey(e => e.QuestionId)
        .IsRequired(false);

        modelBuilder.Entity<Comment>()
        .HasMany(e => e.RepliComments)
        .WithOne(e => e)
        .HasForeignKey(e => e.RepliedCommentId)
        .IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}




