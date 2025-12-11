using DayCare.Application.DTOs;
using DayCare.Domain.Entities;
using DayCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DayCare.Application.Services
{
    public class TutorService : ITutorService
    {
        private readonly DayCareDbContext _context;

        public TutorService(DayCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<TutorDto>> GetAllAsync()
        {
            return await _context.Tutors
                .Select(t => new TutorDto
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Relationship = t.Relationship,
                    PhoneNumber = t.PhoneNumber,
                    Email = t.Email
                })
                .ToListAsync();
        }

        public async Task<TutorDto?> GetByIdAsync(int id)
        {
            var tutor = await _context.Tutors.FindAsync(id);

            if (tutor == null)
                return null;

            return new TutorDto
            {
                Id = tutor.Id,
                FullName = tutor.FullName,
                Relationship = tutor.Relationship,
                PhoneNumber = tutor.PhoneNumber,
                Email = tutor.Email
            };
        }

        public async Task<TutorDto> CreateAsync(CreateTutorDto dto)
        {
            var tutor = new Tutor
            {
                FullName = dto.FullName,
                Relationship = dto.Relationship,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            _context.Tutors.Add(tutor);
            await _context.SaveChangesAsync();

            return new TutorDto
            {
                Id = tutor.Id,
                FullName = tutor.FullName,
                Relationship = tutor.Relationship,
                PhoneNumber = tutor.PhoneNumber,
                Email = tutor.Email
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateTutorDto dto)
        {
            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor == null)
                return false;

            tutor.FullName = dto.FullName;
            tutor.Relationship = dto.Relationship;
            tutor.PhoneNumber = dto.PhoneNumber;
            tutor.Email = dto.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tutor = await _context.Tutors.FindAsync(id);
            if (tutor == null)
                return false;

            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
