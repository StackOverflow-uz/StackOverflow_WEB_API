using DTOs.CommentD;
using LogicLayer.Extended;

namespace LogicLayer.Interfaces;

public interface ICommentService
{
    Task<List<CommentDto>> GetAll();
    Task<PagedList<CommentDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<CommentDto> GetById(int id);
    Task Add(AddCommentDto addCommentDto);
    Task Delete(int id);
    Task Update(UpdateCommentDto updateCommentDto);
}
