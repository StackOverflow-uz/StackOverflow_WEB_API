using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.AnswerD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class AnswerService(IUnitOfWorkInterface unitOfWork,
						   IMapper mapper) : IAnswerService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddAnswerDto addAnswerDto)
	{
        if (addAnswerDto == null)
        {
            throw new ArgumentNullException("Answer null bo'lib qoldi!");
        }

        var answer = _mapper.Map<Answer>(addAnswerDto);
        if (!answer.IsValid())
        {
            throw new CustomException("Invalid Answer");
        }

        var answers = await _unitOfWork.AnswerInterface.GetAllAsync();
        if (answer.IsExist(answers))
        {
            throw new CustomException($"{answer.Body} uje bor!");
        }

		await _unitOfWork.AnswerInterface.AddAsync(answer);
		await _unitOfWork.SaveAsync();
    }
    public async Task Delete(int id)
    {
        var answer = await _unitOfWork.AnswerInterface.GetByIdAsync(id);
        if (answer == null)
        {
            throw new ArgumentNullException("Bunday Answer mavjud emas");
        }
        await _unitOfWork.AnswerInterface.DeleteAsync(answer);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<AnswerDto>> GetAll()
    {
        var answers = await _unitOfWork.AnswerInterface.GetAllAsync();

        return answers.Select(c => _mapper.Map<AnswerDto>(c)).ToList();
    }

    public async Task<PagedList<AnswerDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.AnswerInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<AnswerDto>(c))
                                    .ToList();

        PagedList<AnswerDto> pagedList = new(dtos,
                                               dtos.Count(),
                                               pageNumber,
                                               pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<AnswerDto> GetById(int id)
        => _mapper.Map<AnswerDto>(await _unitOfWork.AnswerInterface.GetByIdAsync(id));

    public async Task Update(UpdateAnswerDto updateAnswerDto)
    {
        if (updateAnswerDto == null)
        {
            throw new ArgumentNullException("AnswerDto is null here");
        }

        var answers = await _unitOfWork.AnswerInterface.GetAllAsync();
        var answer = answers.FirstOrDefault(c => c.Id == updateAnswerDto.Id);

        if (answer == null)
        {
            throw new ArgumentNullException("Answer is null here");
        }
        var updateAnswer = _mapper.Map<Answer>(updateAnswerDto);
        if (!updateAnswer.IsValid())
        {
            throw new StackException("Answer is invalid ");
        }
        if (updateAnswer.IsExist(answers))
        {
            throw new StackException("Answer is already exist ");
        }
        await _unitOfWork.AnswerInterface.UpdateAsync(updateAnswer);
        await _unitOfWork.SaveAsync();
    }
}
