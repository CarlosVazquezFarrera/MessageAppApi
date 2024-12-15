using AutoMapper;
using MessageApp.Data;
using MessageApp.DTOs;
using MessageApp.Enetities;
using MessageApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Services
{
    public class MessageService : IMessageService
    {
        public MessageService(MessagesAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly MessagesAppContext _context;
        private readonly IMapper _mapper;
        public IEnumerable<MessageDTO> GetAll()
        {
            var messages = _context.Messages.OrderByDescending(m => m.Createdat).Include(m => m.Student);
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public async Task<MessageDTO> SaveMessage(MessageDTO message)
        {
            Message newMessage = _mapper.Map<Message>(message);
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            await _context.Entry(newMessage).Reference(m => m.Student).LoadAsync();

            return _mapper.Map<MessageDTO>(newMessage);
        }
    }
}
