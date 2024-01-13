using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.CommentD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class CommentService(IUnitOfWorkInterface unitOfWork,
                            IMapper mapper) : ICommentService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddCommentDto addCommentDto)
    {
        if (addCommentDto == null)
        {
            throw new ArgumentNullException("Comment null bo'lib qoldi!");
        }

        var comment = _mapper.Map<Comment>(addCommentDto);
        if (!comment.IsValid())
        {
            throw new StackException("Invalid Comment");
        }

        var comments = await _unitOfWork.CommentInterface.GetAllAsync();
        if (comment.IsExist(comments))
        {
            throw new StackException($"{comment.Text} uje bor!");
        }

        await _unitOfWork.CommentInterface.AddAsync(comment);
        await _unitOfWork.SaveAsync();
    }
    public async Task Delete(int id)
    {
        var comment = await _unitOfWork.CommentInterface.GetByIdAsync(id);
        if (comment == null)
        {
            throw new ArgumentNullException("Bunday Comment mavjud emas");
        }
        await _unitOfWork.CommentInterface.DeleteAsync(comment);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<CommentDto>> GetAll()
    {
        var comments = await _unitOfWork.CommentInterface.GetAllAsync();

        return comments.Select(c => _mapper.Map<CommentDto>(c)).ToList();
    }

    public async Task<PagedList<CommentDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.CommentInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<CommentDto>(c))
                                    .ToList();

        PagedList<CommentDto> pagedList = new(dtos,
                                               dtos.Count(),
                                               pageNumber,
                                               pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<CommentDto> GetById(int id)
        => _mapper.Map<CommentDto>(await _unitOfWork.CommentInterface.GetByIdAsync(id));

    public async Task Update(UpdateCommentDto updateCommentDto)
    {
        if (updateCommentDto == null)
        {
            throw new ArgumentNullException("CommentDto is null here");
        }

        var comments = await _unitOfWork.CommentInterface.GetAllAsync();
        var comment = comments.FirstOrDefault(c => c.Id == updateCommentDto.Id);

        if (comment == null)
        {
            throw new ArgumentNullException("Comment is null here");
        }
        var updateComment = _mapper.Map<Comment>(updateCommentDto);
        if (!updateComment.IsValid())
        {
            throw new StackException("Comment is invalid ");
        }
        if (updateComment.IsExist(comments))
        {
            throw new StackException("Comment is already exist ");
        }
        await _unitOfWork.CommentInterface.UpdateAsync(updateComment);
        await _unitOfWork.SaveAsync();
    }
}
