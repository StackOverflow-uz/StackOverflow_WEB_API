using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces;
public interface ICommentInterface : IRepository<Comment>
{
    public Task AddCommentReply(int commentId, string replyText);
    public List<string> GetCommentReplies(int commentId, string r);
}