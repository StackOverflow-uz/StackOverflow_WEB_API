using DTOs.CommentD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services;

public class CommentService : ICommentService
{
    public Task Add(AddCommentDto addCategoryDto)
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

    public Task Update(UpdateCommentDto updateCategoryDto)
    {
        throw new NotImplementedException();
    }
}
