using DTOs.AnswerD;
using DTOs.QuestionTagD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface IQuestionTagService
{
    Task<List<QuestionTagDto>> GetAll();
    Task<PagedList<QuestionTagDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<QuestionTagDto> GetById(int id);
    Task Add(AddQuestionTagDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateQuestionTagDto updateCategoryDto);
}
