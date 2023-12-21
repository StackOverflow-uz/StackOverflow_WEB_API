namespace DataAccessLayer.Interfaces;

public interface IUnitOfWorkInterface : IDisposable
{
    IUserInterface UserInterface { get; }
    IAnswerInterface AnswerInterface { get; }
    ICommentInterface CommentInterface { get; }
    IQuestionInterface QuestionInterface { get; }
    IQuestionTaginterface QuestionTaginterface { get; }
    ITagInterface TagInterface { get; }
    ISavedInterface SavedInterface { get; }
    Task SaveAsync();
}
