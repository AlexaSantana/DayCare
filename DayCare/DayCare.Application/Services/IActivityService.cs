using DayCare.Application.DTOs;

namespace DayCare.Application.Services
{
    public interface IActivityService
    {
        Task<List<ActivityDto>> GetAllAsync();
        Task<ActivityDto?> GetByIdAsync(int id);
        Task<ActivityDto> CreateAsync(CreateActivityDto dto);
        Task<bool> UpdateAsync(int id, UpdateActivityDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
