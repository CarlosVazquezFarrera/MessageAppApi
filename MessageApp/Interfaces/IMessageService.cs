using MessageApp.DTOs;

namespace MessageApp.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<MessageDTO> GetAll();
        Task<MessageDTO> SaveMessage(MessageDTO message);
        Task DeleteMessage(Guid Id);
    }
}
