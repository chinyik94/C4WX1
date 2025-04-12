using C4WX1.API.Features.Chat.Dtos;

namespace C4WX1.API.Features.Chat.Repository;

public interface IChatRepository
{
    Task<IEnumerable<ChatDto>> ListLatestAsync(GetChatListDto req);
    Task<IEnumerable<ChatDto>> ListPreviousAsync(GetChatListDto req);
    Task<bool> CanLoadMoreAsync(int? patientId, int? userId, int minChatId);
}
