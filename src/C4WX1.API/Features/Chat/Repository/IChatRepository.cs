using C4WX1.API.Features.Chat.Dtos;

namespace C4WX1.API.Features.Chat.Repository
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatDto>> GetLatestListAsync(GetChatListDto req, CancellationToken ct = default);
        Task<IEnumerable<ChatDto>> GetPreviousListAsync(GetChatListDto req, CancellationToken ct = default);
    }
}
