namespace DataAccessLayer.Interfaces;

public interface IUnitOfWorkInterface : IDisposable
{
    IAnswerInterface AnswerInterface { get; }
    ICommentInterface CommentInterface { get; }
    IQuestionInterface QuestionInterface { get; }
    IQuestionTagInterface QuestionTagInterface { get; }
    ITagInterface TagInterface { get; }
    ISavedInterface SavedInterface { get; }
    Task SaveAsync();
}
