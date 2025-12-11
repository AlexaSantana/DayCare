using DayCare.Application.DTOs;
using DayCare.Domain.Entities;
using DayCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DayCare.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly DayCareDbContext _context;

        public ActivityService(DayCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActivityDto>> GetAllAsync()
        {
            return await _context.Activities
                .Select(a => new ActivityDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    RecommendedGroup = a.RecommendedGroup
                })
                .ToListAsync();
        }

        public async Task<ActivityDto?> GetByIdAsync(int id)
        {
            var a = await _context.Activities.FindAsync(id);
            if (a == null)
                return null;

            return new ActivityDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                RecommendedGroup = a.RecommendedGroup
            };
        }

        public async Task<ActivityDto> CreateAsync(CreateActivityDto dto)
        {
            var a = new Activity
            {
                Name = dto.Name,
                Description = dto.Description,
                RecommendedGroup = dto.RecommendedGroup
            };

            _context.Activities.Add(a);
            await _context.SaveChangesAsync();

            return new ActivityDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                RecommendedGroup = a.RecommendedGroup
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateActivityDto dto)
        {
            var a = await _context.Activities.FindAsync(id);
            if (a == null)
                return false;

            a.Name = dto.Name;
            a.Description = dto.Description;
            a.RecommendedGroup = dto.RecommendedGroup;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var a = await _context.Activities.FindAsync(id);
            if (a == null)
                return false;

            _context.Activities.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
