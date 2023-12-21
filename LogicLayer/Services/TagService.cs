using DTOs.TagD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class TagService : ITagService
{
    public Task Add(AddTagDto addCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TagDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<TagDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<TagDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateTagDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}
