using DayCare.Application.DTOs;
using DayCare.Domain.Entities;
using DayCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DayCare.Application.Services
{
    public class ChildService : IChildService
    {
        private readonly DayCareDbContext _context;

        public ChildService(DayCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<ChildDto>> GetAllAsync()
        {
            return await _context.Children
                .Include(c => c.Tutor)
                .Select(c => new ChildDto
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    BirthDate = c.BirthDate,
                    GroupName = c.GroupName,
                    TutorId = c.TutorId,
                    TutorName = c.Tutor.FullName
                })
                .ToListAsync();
        }

        public async Task<ChildDto?> GetByIdAsync(int id)
        {
            var child = await _context.Children
                .Include(c => c.Tutor)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (child == null)
                return null;

            return new ChildDto
            {
                Id = child.Id,
                FullName = child.FullName,
                BirthDate = child.BirthDate,
                GroupName = child.GroupName,
                TutorId = child.TutorId,
                TutorName = child.Tutor.FullName
            };
        }

        public async Task<ChildDto?> CreateAsync(CreateChildDto dto)
        {
            var tutor = await _context.Tutors.FindAsync(dto.TutorId);
            if (tutor == null)
                return null;

            var child = new Child
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                GroupName = dto.GroupName,
                TutorId = dto.TutorId
            };

            _context.Children.Add(child);
            await _context.SaveChangesAsync();

            return new ChildDto
            {
                Id = child.Id,
                FullName = child.FullName,
                BirthDate = child.BirthDate,
                GroupName = child.GroupName,
                TutorId = child.TutorId,
                TutorName = tutor.FullName
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateChildDto dto)
        {
            var child = await _context.Children.FindAsync(id);
            if (child == null)
                return false;

            var tutor = await _context.Tutors.FindAsync(dto.TutorId);
            if (tutor == null)
                return false;

            child.FullName = dto.FullName;
            child.BirthDate = dto.BirthDate;
            child.GroupName = dto.GroupName;
            child.TutorId = dto.TutorId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var child = await _context.Children.FindAsync(id);
            if (child == null)
                return false;

            _context.Children.Remove(child);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
