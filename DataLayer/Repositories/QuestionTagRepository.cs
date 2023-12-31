using DataAccessLayer.DB;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class QuestionTagRepository(AppDbContext dbContext) : IQuestionTagInterface
{
    protected readonly AppDbContext _dbContext = dbContext;
    public async Task AddAsync(QuestionTag questiontag)
    {
        if (questiontag == null) throw new ArgumentNullException(nameof(questiontag));

        await _dbContext.QuestionTags.AddAsync(questiontag);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(QuestionTag questiontag)
    {
        if (questiontag == null) throw new ArgumentNullException(nameof(questiontag));

        _dbContext.QuestionTags.Remove(questiontag);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<QuestionTag>> GetAllAsync()
    {
        return await _dbContext.QuestionTags.ToListAsync();
    }

    public async Task<QuestionTag?> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be greater than zero.", nameof(id));
        }

        return await _dbContext.QuestionTags.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(QuestionTag questiontag)
    {
        if (questiontag == null) throw new ArgumentNullException(nameof(questiontag));

        var existingEntity = await GetByIdAsync(questiontag.Id);

        if (existingEntity == null)
        {
            throw new ArgumentException($"Entity with Id {questiontag.Id} not found.", nameof(questiontag));
        }

        _dbContext.Entry(existingEntity).CurrentValues.SetValues(questiontag);
        await _dbContext.SaveChangesAsync();
    }
}
