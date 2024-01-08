using DataAccessLayer.DB;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class CommentRepository : Repository<Comment>, ICommentInterface
{
    public CommentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    public Task AddCommentReply(int commentId, string replyText)
    {
        using (var context = new AppDbContext())
        {
            Comment comment = new();
            if (comment.IsReply == true)
            {
                var coment = context.Comments.Find(commentId);
                var reply = new Comment { Text = replyText };
                coment.RepliComments.Add(reply);
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
        

    public List<string> GetCommentReplies(int commentId, string r)
    {
        using(var context = new AppDbContext())
        {
            var comment = context.Comments.Include(c => c.RepliComments).FirstOrDefault(c => c.Id == commentId);
            return comment.RepliComments.Select(r => r.Text)
                .ToList();
        }
    }
}
