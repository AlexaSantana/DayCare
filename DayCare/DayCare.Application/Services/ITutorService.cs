using DayCare.Application.DTOs;

namespace DayCare.Application.Services
{
    public interface ITutorService
    {
        Task<List<TutorDto>> GetAllAsync();
        Task<TutorDto?> GetByIdAsync(int id);
        Task<TutorDto> CreateAsync(CreateTutorDto dto);
        Task<bool> UpdateAsync(int id, UpdateTutorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
