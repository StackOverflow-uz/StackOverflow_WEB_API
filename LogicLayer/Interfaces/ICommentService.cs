using DTOs.AnswerD;
using DTOs.CommentD;
using LogicLayer.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces;

public interface ICommentService
{
    Task<List<CommentDto>> GetAll();
    Task<PagedList<CommentDto>> GetAllPaged(int pageSize, int pageNumber);
    Task<CommentDto> GetById(int id);
    Task Add(AddCommentDto addCategoryDto);
    Task Delete(int id);
    Task Update(UpdateCommentDto updateCategoryDto);
}
