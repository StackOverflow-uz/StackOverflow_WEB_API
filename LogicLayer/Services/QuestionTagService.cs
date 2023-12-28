using DTOs.QuestionTagD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;
public class QuestionTagService : IQuestionTagService
{
    public Task Add(AddQuestionTagDto addQuestionDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<QuestionTagDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<QuestionTagDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<QuestionTagDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateQuestionTagDto updateQuestionDto)
    {
        throw new NotImplementedException();
    }
}
