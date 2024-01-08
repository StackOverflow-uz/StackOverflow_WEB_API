using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.QuestionD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;
public class QuestionService(IUnitOfWorkInterface unitOfWork,
                             IMapper mapper) : IQuestionService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddQuestionDto addQuestionDto)
    {
        if (addQuestionDto == null)
        {
            throw new ArgumentNullException("Question null bo'lib qoldi!");
        }

        var question = _mapper.Map<Question>(addQuestionDto);
        if (!question.IsValid())
        {
            throw new CustomException("Invalid Question");
        }

        var questions = await _unitOfWork.QuestionInterface.GetAllAsync();
        if (question.IsExist(questions))
        {
            throw new CustomException($"{question.Body} uje bor!");
        }

        await _unitOfWork.QuestionInterface.AddAsync(question);
        await _unitOfWork.SaveAsync();
    }
    public async Task Delete(int id)
    {
        var question = await _unitOfWork.QuestionInterface.GetByIdAsync(id);
        if (question == null)
        {
            throw new ArgumentNullException("Bunday Question mavjud emas");
        }
        await _unitOfWork.QuestionInterface.DeleteAsync(question);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<QuestionDto>> GetAll()
    {
        var questions = await _unitOfWork.QuestionInterface.GetAllAsync();

        return questions.Select(c => _mapper.Map<QuestionDto>(c)).ToList();
    }

    public async Task<PagedList<QuestionDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.QuestionInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<QuestionDto>(c))
                                    .ToList();

        PagedList<QuestionDto> pagedList = new(dtos,
                                               dtos.Count(),
                                               pageNumber,
                                               pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<QuestionDto> GetById(int id)
        => _mapper.Map<QuestionDto>(await _unitOfWork.QuestionInterface.GetByIdAsync(id));

    public async Task Update(UpdateQuestionDto updateQuestionDto)
    {
        if (updateQuestionDto == null)
        {
            throw new ArgumentNullException("QuestionDto is null here");
        }

        var questions = await _unitOfWork.QuestionInterface.GetAllAsync();
        var question = questions.FirstOrDefault(c => c.Id == updateQuestionDto.Id);

        if (question == null)
        {
            throw new ArgumentNullException("Question is null here");
        }
        var updateQuestion = _mapper.Map<Question>(updateQuestionDto);
        if (!updateQuestion.IsValid())
        {
            throw new StackException("Question is invalid ");
        }
        if (updateQuestion.IsExist(questions))
        {
            throw new StackException("Question is already exist ");
        }
        await _unitOfWork.QuestionInterface.UpdateAsync(updateQuestion);
        await _unitOfWork.SaveAsync();
    }
}
