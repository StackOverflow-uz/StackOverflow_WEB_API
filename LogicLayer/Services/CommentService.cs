using DTOs.CommentD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class CommentService : ICommentService
{
    public Task Add(AddCommentDto addCommentDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedList<CommentDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task<CommentDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateCommentDto updateCommentDto)
    {
        throw new NotImplementedException();
    }
}
