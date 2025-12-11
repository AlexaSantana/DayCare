using DayCare.Application.DTOs;
using DayCare.Domain.Entities;
using DayCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DayCare.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly DayCareDbContext _context;

        public AttendanceService(DayCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<AttendanceDto>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Child)
                .Select(a => new AttendanceDto
                {
                    Id = a.Id,
                    ChildId = a.ChildId,
                    ChildName = a.Child.FullName,
                    Date = a.Date,
                    Status = a.Status,
                    CheckInTime = a.CheckInTime,
                    CheckOutTime = a.CheckOutTime
                }).ToListAsync();
        }

        public async Task<AttendanceDto?> GetByIdAsync(int id)
        {
            var a = await _context.Attendances
                .Include(x => x.Child)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (a == null) return null;

            return new AttendanceDto
            {
                Id = a.Id,
                ChildId = a.ChildId,
                ChildName = a.Child.FullName,
                Date = a.Date,
                Status = a.Status,
                CheckInTime = a.CheckInTime,
                CheckOutTime = a.CheckOutTime
            };
        }

        public async Task<AttendanceDto?> CreateAsync(CreateAttendanceDto dto)
        {
            var child = await _context.Children.FindAsync(dto.ChildId);
            if (child == null)
                return null;

            var a = new Attendance
            {
                ChildId = dto.ChildId,
                Date = dto.Date,
                Status = dto.Status,
                CheckInTime = dto.CheckInTime,
                CheckOutTime = dto.CheckOutTime
            };

            _context.Attendances.Add(a);
            await _context.SaveChangesAsync();

            return new AttendanceDto
            {
                Id = a.Id,
                ChildId = a.ChildId,
                ChildName = child.FullName,
                Date = a.Date,
                Status = a.Status,
                CheckInTime = a.CheckInTime,
                CheckOutTime = a.CheckOutTime
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateAttendanceDto dto)
        {
            var a = await _context.Attendances.FindAsync(id);
            if (a == null)
                return false;

            a.Status = dto.Status;
            a.CheckInTime = dto.CheckInTime;
            a.CheckOutTime = dto.CheckOutTime;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var a = await _context.Attendances.FindAsync(id);
            if (a == null)
                return false;

            _context.Attendances.Remove(a);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
