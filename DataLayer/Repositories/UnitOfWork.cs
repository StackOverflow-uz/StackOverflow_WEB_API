using DataAccessLayer.DB;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories;

public class UnitOfWork(AppDbContext dbContext,
                        IAnswerInterface answerInterface,
                        ICommentInterface commentInterface,
                        IQuestionTaginterface questionTaginterface,
                        IQuestionInterface questionInterface,
                        ISavedInterface savedInterface,
                        IUserInterface userInterface)
{
    private readonly AppDbContext _dbContext = dbContext;
    public IAnswerInterface AnswerInterface { get; } = answerInterface;

    public ICommentInterface CommentInterface { get; } = commentInterface;

    public IQuestionTaginterface QuestionTagInterface { get; } = questionTaginterface;

    public IQuestionInterface QuestionInterface { get; } = questionInterface;

    public ISavedInterface SavedInterface { get; } = savedInterface;

    public IUserInterface UserInterface { get; } = userInterface;

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
