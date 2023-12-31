using DTOs.TagD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface ITagService
{
    Task<List<TagDto>> GetAll();
    Task<PagedList<TagDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<TagDto> GetById(int id);
    Task Add(AddTagDto addTagDto);
    Task Delete(int id);
    Task Update(UpdateTag updateTagDto);
}
