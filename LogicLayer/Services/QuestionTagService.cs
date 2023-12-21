using DTOs.QuestionTagD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services;
public class QuestionTagService : IQuestionTagService
{
    public Task Add(AddQuestionTagDto addCategoryDto)
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

    public Task Update(UpdateQuestionTagDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}
