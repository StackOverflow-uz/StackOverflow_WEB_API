using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.SavedD;
using LogicLayer.Extended;
using LogicLayer.Interfaces;

namespace LogicLayer.Services;

public class SavedService(IUnitOfWorkInterface unitOfWork,
                          IMapper mapper) : ISavedService
{
    private readonly IUnitOfWorkInterface _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task Add(AddSavedDto addSavedDto)
    {
        if (addSavedDto == null)
        {
            throw new ArgumentNullException("Saved null bo'lib qoldi");
        }
        var saved = _mapper.Map<Saved>(addSavedDto);
        await _unitOfWork.SavedInterface.AddAsync(saved);
        await _unitOfWork.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var questionTag = await _unitOfWork.SavedInterface.GetByIdAsync(id);
        if (questionTag == null)
        {
            throw new ArgumentNullException("Bunday Saved mavjud emas");
        }
        await _unitOfWork.SavedInterface.DeleteAsync(questionTag);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<SavedDto>> GetAll()
    {
        var saveds = await _unitOfWork.SavedInterface.GetAllAsync();
        return saveds.Select(c => _mapper.Map<SavedDto>(c)).ToList();
    }

    public async Task<PagedList<SavedDto>> GetAllPaged(int pageSize, int pageNumber)
    {
        var list = await _unitOfWork.SavedInterface.GetAllAsync();
        var dtos = list.Select(c => _mapper.Map<SavedDto>(c))
                                .ToList();

        PagedList<SavedDto> pagedList = new(dtos,
                                             dtos.Count(),
                                             pageNumber,
                                             pageSize);
        return pagedList.ToPagedList(dtos, pageSize, pageNumber);
    }

    public async Task<SavedDto> GetById(int id)
    {
        var saved = await _unitOfWork.SavedInterface.GetByIdAsync(id);
        return _mapper.Map<SavedDto>(saved);
    }

    public async Task Update(UpdateSavedDto updateSavedDto)
    {
        if (updateSavedDto == null)
        {
            throw new ArgumentNullException("SavedDto is not null here");
        }
        var saveds = await _unitOfWork.SavedInterface.GetAllAsync();
        var saved = saveds.FirstOrDefault(c => c.Id == updateSavedDto.Id);

        if (saved == null)
        {
            throw new ArgumentNullException("Saved is null here");
        }
        var updateSaved = _mapper.Map<Saved>(updateSavedDto);
        await _unitOfWork.SavedInterface.UpdateAsync(updateSaved);
        await _unitOfWork.SaveAsync();
    }
}
