using DataAccessLayer.DB;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories;

public class QuestionRepository : Repository<Question>, IQuestionInterface
{
    public QuestionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}