using DTOs.SavedD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface ISavedService
{
    Task<List<SavedDto>> GetAll();
    Task<PagedList<SavedDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<SavedDto> GetById(int id);
    Task Add(AddSavedDto addSavedDto);
    Task Delete(int id);
    Task Update(UpdateSavedDto updateSavedDto);
}
