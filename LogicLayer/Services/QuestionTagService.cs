using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.QuestionTagD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;
public class QuestionTagTagService(IUnitOfWorkInterface unitOfWork,
                                IMapper mapper) : IQuestionTagService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddQuestionTagDto addQuestionTagDto)
    {
        if (addQuestionTagDto == null)
        {
            throw new ArgumentNullException("QuestionTag null bo'lib qoldi!");
        }

        var questionTag = _mapper.Map<QuestionTag>(addQuestionTagDto);

        var questionTags = await _unitOfWork.QuestionTagInterface.GetAllAsync();
        if (questionTags.Any(c => c.TagId == questionTag.TagId && c.Id != questionTag.Id))
        {
            throw new StackException($"{questionTag.Tag} uje bor!");
        }

        await _unitOfWork.QuestionTagInterface.AddAsync(questionTag);
        await _unitOfWork.SaveAsync();
    }
    public async Task Delete(int id)
    {
        var questionTag = await _unitOfWork.QuestionTagInterface.GetByIdAsync(id);
        if (questionTag == null)
        {
            throw new ArgumentNullException("Bunday QuestionTag mavjud emas");
        }
        await _unitOfWork.QuestionTagInterface.DeleteAsync(questionTag);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<QuestionTagDto>> GetAll()
    {
        var questionTags = await _unitOfWork.QuestionTagInterface.GetAllAsync();

        return questionTags.Select(c => _mapper.Map<QuestionTagDto>(c)).ToList();
    }

    public async Task<PagedList<QuestionTagDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.QuestionTagInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<QuestionTagDto>(c))
                                    .ToList();

        PagedList<QuestionTagDto> pagedList = new(dtos,
                                               dtos.Count(),
                                               pageNumber,
                                               pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<QuestionTagDto> GetById(int id)
        => _mapper.Map<QuestionTagDto>(await _unitOfWork.QuestionTagInterface.GetByIdAsync(id));

    public async Task Update(UpdateQuestionTagDto updateQuestionTagDto)
    {
        if (updateQuestionTagDto == null)
        {
            throw new ArgumentNullException("QuestionTagDto is null here");
        }

        var questionTags = await _unitOfWork.QuestionTagInterface.GetAllAsync();
        var questionTag = questionTags.FirstOrDefault(c => c.Id == updateQuestionTagDto.Id);

        if (questionTag == null)
        {
            throw new ArgumentNullException("QuestionTag is null here");
        }
        var updateQuestionTag = _mapper.Map<QuestionTag>(updateQuestionTagDto);

        if (questionTags.Any(c => c.TagId == questionTag.TagId && c.Id != questionTag.Id))
        {
            throw new StackException($"{questionTag.Tag} uje bor!");
        }
        await _unitOfWork.QuestionTagInterface.UpdateAsync(updateQuestionTag);
        await _unitOfWork.SaveAsync();
    }
}
