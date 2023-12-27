using DTOs.AnswerD;
using DTOs.SavedD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface ISavedService
{
    Task<List<SavedDto>> GetAll();
    Task<PagedList<SavedDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<SavedDto> GetById(int id);
    Task Add(AddSavedDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateSavedDto updateCategoryDto);
}
