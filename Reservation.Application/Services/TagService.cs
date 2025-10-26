using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Tag;
using Reservation.Application.DTOs.Responses.Tag;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class TagService : ITagService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ITagRepository _repo;

    public TagService(IUnitOfWork uow, IMapper mapper, ITagRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateTagAsync(CreateTagRequestDto request)
    {
        var room = new TagDomain(request.HotelId, request.Tag);
        await _uow.GetRepository<Tag>().AddAsync(_mapper.Map<Tag>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateTagAsync(UpdateTagRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingTag = await _uow.GetRepository<Tag>().GetByIdAsync(request.Id);
        if (existingTag == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<TagDomain>(existingTag);
        domain.Update(request.Tag);

        _mapper.Map(domain, existingTag);
        _uow.GetRepository<Tag>().Update(existingTag);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveTagAsync(int id)
    {
        var existingTag = await _uow.GetRepository<Tag>().GetByIdAsync(id);
        if (existingTag == null) throw new KeyNotFoundException();
        _uow.GetRepository<Tag>().Delete(existingTag);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<TagDto>> GetAllTagsAsync()
    {
        var rooms = await _uow.GetRepository<Tag>().GetAllAsync();
        return _mapper.Map<List<TagDto>>(rooms);
    }

    public async Task<TagDto> GetTagById(int id)
    {
        var existingTag = await _uow.GetRepository<Tag>().GetByIdAsync(id);
        if (existingTag == null) throw new KeyNotFoundException();
        
        return _mapper.Map<TagDto>(existingTag);
    }

    public async Task<List<TagDto>> GetHotelTagsAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelTags(hotelId);
        return _mapper.Map<List<TagDto>>(rooms);
    }
}