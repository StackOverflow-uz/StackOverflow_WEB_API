using DTOs.QuestionTagD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface IQuestionTagService
{
    Task<List<QuestionTagDto>> GetAll();
    Task<PagedList<QuestionTagDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<QuestionTagDto> GetById(int id);
    Task Add(AddQuestionTagDto addQuestionDto);
    Task Delete(int id);
    Task Update(UpdateQuestionTagDto updateQuestionDto);
}
