using DTOs.QuestionD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface IQuestionService
{
    Task<List<QuestionDto>> GetAll();
    Task<PagedList<QuestionDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<QuestionDto> GetById(int id);
    Task Add(AddQuestionDto addQuestionDto);
    Task Delete(int id);
    Task Update(UpdateQuestionDto updateQuestionDto);
}
