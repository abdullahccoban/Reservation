using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Comment;
using Reservation.Application.DTOs.Responses.Comment;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly ICommentRepository _repo;

    public CommentService(IUnitOfWork uow, IMapper mapper, ICommentRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateCommentAsync(CreateCommentRequestDto request)
    {
        var room = new CommentDomain(request.HotelId, request.Point, request.Comment, request.CreatedAt);
        await _uow.GetRepository<Comment>().AddAsync(_mapper.Map<Comment>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateCommentAsync(UpdateCommentRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingComment = await _uow.GetRepository<Comment>().GetByIdAsync(request.Id);
        if (existingComment == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<CommentDomain>(existingComment);
        domain.Update(request.Point, request.Comment, request.CreatedAt);

        _mapper.Map(domain, existingComment);
        _uow.GetRepository<Comment>().Update(existingComment);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveCommentAsync(int id)
    {
        var existingComment = await _uow.GetRepository<Comment>().GetByIdAsync(id);
        if (existingComment == null) throw new KeyNotFoundException();
        _uow.GetRepository<Comment>().Delete(existingComment);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<CommentDto>> GetAllCommentsAsync()
    {
        var rooms = await _uow.GetRepository<Comment>().GetAllAsync();
        return _mapper.Map<List<CommentDto>>(rooms);
    }

    public async Task<CommentDto> GetCommentById(int id)
    {
        var existingComment = await _uow.GetRepository<Comment>().GetByIdAsync(id);
        if (existingComment == null) throw new KeyNotFoundException();
        
        return _mapper.Map<CommentDto>(existingComment);
    }

    public async Task<List<CommentDto>> GetHotelCommentsAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelComments(hotelId);
        return _mapper.Map<List<CommentDto>>(rooms);
    }
}