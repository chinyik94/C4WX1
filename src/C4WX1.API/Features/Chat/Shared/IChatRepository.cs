namespace C4WX1.API.Features.Chat.Shared
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatDto>> GetLatestListAsync(GetChatListRequestDto req, CancellationToken ct = default);
        Task<IEnumerable<ChatDto>> GetPreviousListAsync(GetChatListRequestDto req, CancellationToken ct = default);
    }
}
