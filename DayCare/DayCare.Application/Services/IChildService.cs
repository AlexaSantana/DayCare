using DayCare.Application.DTOs;

namespace DayCare.Application.Services
{
    public interface IChildService
    {
        Task<List<ChildDto>> GetAllAsync();
        Task<ChildDto?> GetByIdAsync(int id);
        Task<ChildDto?> CreateAsync(CreateChildDto dto);
        Task<bool> UpdateAsync(int id, UpdateChildDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
