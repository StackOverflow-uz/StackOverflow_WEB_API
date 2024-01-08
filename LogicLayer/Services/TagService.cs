using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.TagD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class TagService(IUnitOfWorkInterface unitOfWork,
                        IMapper mapper) : ITagService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddTagDto addTagDto)
    {
        if (addTagDto == null)
        {
            throw new ArgumentNullException("Tag null bo'lib qoldi!");
        }
        var tag = _mapper.Map<Tag>(addTagDto);
        var tas = await _unitOfWork.TagInterface.GetAllAsync();
        if (!tag.IsValid())
        {
            throw new StackException("Tag null bo'lib qoldi!");
        }
        var tags = await _unitOfWork.TagInterface.GetAllAsync();
        if (tag.IsExist(tags))
        {
            throw new StackException("Invalid Tag!");
        }
        await _unitOfWork.TagInterface.AddAsync(tag);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var tag = await _unitOfWork.TagInterface.GetByIdAsync(id);
        if (tag == null)
        {
            throw new ArgumentNullException("Bunday Tag yo'q!");
        }
        await _unitOfWork.TagInterface.DeleteAsync(tag);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<TagDto>> GetAll()
    {
        var list = await _unitOfWork.TagInterface.GetAllAsync();
        return list.Select(c => _mapper.Map<TagDto>(c)).ToList();
    }

    public async Task<PagedList<TagDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.TagInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<TagDto>(c))
                            .ToList();

        PagedList<TagDto> pagedList = new PagedList<TagDto>(dtos, 
                                                            dtos.Count(), 
                                                            pageSize, 
                                                            pageNumber);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<TagDto> GetById(int id)
    {
        var tag = await _unitOfWork.TagInterface.GetByIdAsync(id);
        return _mapper.Map<TagDto>(tag);
    }

    public async Task Update(UpdateTagDto updateTagDto)
    {
        if (updateTagDto == null)
        {
            throw new ArgumentNullException("TagDto is null here!");
        }

        var tag = await _unitOfWork.TagInterface.GetByIdAsync(updateTagDto.Id);
        var tags = await _unitOfWork.TagInterface.GetAllAsync();
        if (tag == null)
        {
            throw new ArgumentNullException("Tag is null here!");
        }

        var updateTag = _mapper.Map<Tag>(updateTagDto);
        if (updateTag.IsValid())
        {
            throw new StackException("Tag is invalid!");
        }
        if (updateTag.IsExist(tags))
        {
            throw new StackException("Tag is already exist!");
        }
        await _unitOfWork.TagInterface.UpdateAsync(updateTag);
        await _unitOfWork.SaveAsync();
    }
}
