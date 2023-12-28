using DTOs.AnswerD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface IAnswerService
{
    Task<List<AnswerDto>> GetAll();
    Task<PagedList<AnswerDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<AnswerDto> GetById(int id);
    Task Add(AddAnswerDto addAnswerDto);
    Task Delete(int id);
    Task Update(UpdateAnswerDto updateAnswerDto);
}
