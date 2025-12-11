using DayCare.Application.DTOs;

namespace DayCare.Application.Services
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetAllAsync();
        Task<MessageDto?> GetByIdAsync(int id);
        Task<MessageDto> CreateAsync(CreateMessageDto dto);
        Task<bool> UpdateAsync(int id, UpdateMessageDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
