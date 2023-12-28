using DTOs.SavedD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class SavedService : ISavedService
{
    public Task Add(AddSavedDto addSavedDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SavedDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<SavedDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<SavedDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateSavedDto updateSavedDto)
    {
        throw new NotImplementedException();
    }
}
