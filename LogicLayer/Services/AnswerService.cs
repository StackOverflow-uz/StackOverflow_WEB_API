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
            throw new CustomException("Invalid Category");
        }

        var answers = await _unitOfWork.AnswerInterface.GetAllAsync();
        if (answer.IsExist(answers))
        {
            throw new CustomException($"{answer.Body} uje bor!");
        }

		await _unitOfWork.AnswerInterface.AddAsync(answer);
		await _unitOfWork.SaveAsync();
    }

	public Task Delete(int id)
	{
		throw new NotImplementedException();
	}

	public Task<List<AnswerDto>> GetAll()
	{
		throw new NotImplementedException();
	}

	public Task<PagedList<AnswerDto>> GetAllPaged(int pageSize, int pageNumber)
	{
		throw new NotImplementedException();
	}

	public Task<AnswerDto> GetById(int id)
	{
		throw new NotImplementedException();
	}

	public Task Update(UpdateAnswerDto updateAnswerDto)
	{
		throw new NotImplementedException();
	}
}
