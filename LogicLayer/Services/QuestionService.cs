using DTOs.QuestionD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services;
public class QuestionService : IQuestionService
{
    public Task Add(AddQuestionDto addCategoryDto)
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

    public Task Update(UpdateQuestionDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}
