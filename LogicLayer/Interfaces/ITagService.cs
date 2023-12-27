using DTOs.AnswerD;
using DTOs.TagD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface ITagService
{
    Task<List<TagDto>> GetAll();
    Task<PagedList<TagDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<TagDto> GetById(int id);
    Task Add(AddTagDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateTagDto updateCategoryDto);
}
