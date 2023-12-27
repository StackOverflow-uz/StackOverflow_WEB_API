using DTOs.AnswerD;
using DTOs.QuestionD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface IQuestionService
{
    Task<List<QuestionDto>> GetAll();
    Task<PagedList<QuestionDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<QuestionDto> GetById(int id);
    Task Add(AddQuestionDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateQuestionDto updateCategoryDto);
}
