using DTOs.AnswerD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface IAnswerService
{
    Task<List<AnswerDto>> GetAll();
    Task<PagedList<AnswerDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<AnswerDto> GetById(int id);
    Task Add(AddAnswerDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateAnswerDto updateCategoryDto);
}
