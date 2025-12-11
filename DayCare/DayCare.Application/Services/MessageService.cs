using DayCare.Application.DTOs;
using DayCare.Domain.Entities;
using DayCare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DayCare.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly DayCareDbContext _context;

        public MessageService(DayCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<MessageDto>> GetAllAsync()
        {
            return await _context.Messages
                .Include(m => m.Child)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    SentDate = m.SentDate,
                    Title = m.Title,
                    Content = m.Content,
                    MessageType = m.MessageType,
                    ChildId = m.ChildId,
                    ChildName = m.Child != null ? m.Child.FullName : null
                })
                .ToListAsync();
        }

        public async Task<MessageDto?> GetByIdAsync(int id)
        {
            var msg = await _context.Messages
                .Include(m => m.Child)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (msg == null)
                return null;

            return new MessageDto
            {
                Id = msg.Id,
                SentDate = msg.SentDate,
                Title = msg.Title,
                Content = msg.Content,
                MessageType = msg.MessageType,
                ChildId = msg.ChildId,
                ChildName = msg.Child?.FullName
            };
        }

        public async Task<MessageDto> CreateAsync(CreateMessageDto dto)
        {
            Child? child = null;

            if (dto.ChildId.HasValue)
            {
                child = await _context.Children.FindAsync(dto.ChildId.Value);
                if (child == null)
                    throw new Exception("El niño especificado no existe.");
            }

            var msg = new Message
            {
                SentDate = DateTime.Now,
                Title = dto.Title,
                Content = dto.Content,
                MessageType = dto.MessageType,
                ChildId = dto.ChildId
            };

            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();

            return new MessageDto
            {
                Id = msg.Id,
                SentDate = msg.SentDate,
                Title = msg.Title,
                Content = msg.Content,
                MessageType = msg.MessageType,
                ChildId = msg.ChildId,
                ChildName = child?.FullName
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateMessageDto dto)
        {
            var msg = await _context.Messages.FindAsync(id);
            if (msg == null)
                return false;

            msg.Title = dto.Title;
            msg.Content = dto.Content;
            msg.MessageType = dto.MessageType;
            msg.ChildId = dto.ChildId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var msg = await _context.Messages.FindAsync(id);
            if (msg == null)
                return false;

            _context.Messages.Remove(msg);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
