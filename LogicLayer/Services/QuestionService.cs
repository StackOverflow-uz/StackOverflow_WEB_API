using DTOs.QuestionD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;
public class QuestionService : IQuestionService
{
    public Task Add(AddQuestionDto addQuestionDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<QuestionDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<QuestionDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<QuestionDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateQuestionDto updateQuestionDto)
    {
        throw new NotImplementedException();
    }
}
