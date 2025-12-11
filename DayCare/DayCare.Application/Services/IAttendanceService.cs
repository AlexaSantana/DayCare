using DayCare.Application.DTOs;

namespace DayCare.Application.Services
{
    public interface IAttendanceService
    {
        Task<List<AttendanceDto>> GetAllAsync();
        Task<AttendanceDto?> GetByIdAsync(int id);
        Task<AttendanceDto?> CreateAsync(CreateAttendanceDto dto);
        Task<bool> UpdateAsync(int id, UpdateAttendanceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
