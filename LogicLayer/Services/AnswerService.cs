using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.AnswerD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services;

public class AnswerService : IAnswerService
{
    public Task Add(AddAnswerDto addCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AnswerDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<AnswerDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<AnswerDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateAnswerDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}
