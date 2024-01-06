using DataAccessLayer.DB;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories;

public class UnitOfWork(AppDbContext dbContext,
                        IAnswerInterface answerInterface,
                        ICommentInterface commentInterface,
                        IQuestionTagInterface questionTagInterface,
                        IQuestionInterface questionInterface,
                        ISavedInterface savedInterface,
                        ITagInterface tagInterface) : IUnitOfWorkInterface
{
    private readonly AppDbContext _dbContext = dbContext;
    public IAnswerInterface AnswerInterface { get; } = answerInterface;

    public ICommentInterface CommentInterface { get; } = commentInterface;

    public IQuestionTagInterface QuestionTagInterface { get; } = questionTagInterface;

    public IQuestionInterface QuestionInterface { get; } = questionInterface;

    public ISavedInterface SavedInterface { get; } = savedInterface;

    public ITagInterface TagInterface { get; } = tagInterface;

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
