using C4WX1.API.Features.Chat.Constants;
using C4WX1.API.Features.Chat.Dtos;
using Dapper;
using Npgsql;

namespace C4WX1.API.Features.Chat.Repository;

public class ChatRepository(
    IConfiguration configuration) : IChatRepository
{
    private readonly string? connectionString = configuration.GetConnectionString("Default");

    public async Task<bool> CanLoadMoreAsync(int? patientId, int? userId, int minChatId)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var canLoadMore = await connection.QuerySingleAsync<bool>(
            ChatSqls.CanLoadMore,
            new
            {
                PatientId = patientId,
                UserId = userId,
                MinChatId = minChatId
            });

        return canLoadMore;
    }

    public async Task<IEnumerable<ChatDto>> ListLatestAsync(GetChatListDto req)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var latestDtoDict = new Dictionary<int, ChatDto>();
        await connection
            .QueryAsync<ChatDto, ChatUserDto, ChatPatientDto, ChatDto, ChatDto>(
                ChatSqls.ListLatest,
                (chat, chatUser, chatPatient, comment) =>
                {
                    if (!latestDtoDict.TryGetValue(chat.ChatID, out var chatEntry))
                    {
                        chatEntry = chat;
                        chatEntry.UserData = chatUser;
                        chatEntry.PatientData = chatPatient;
                        chatEntry.CommentList.Add(comment);
                        latestDtoDict.Add(chat.ChatID, chatEntry);
                    }
                    return chatEntry;
                },
                new
                {
                    ChatId = req.ChatID,
                    PatientId = req.PatientID,
                    UserId = req.UserID,
                    req.Family,
                    req.Count
                },
                splitOn: "UserData_UserId, PatientData_PatientID, CommentList_ChatID"
            );
        var latestDtos = latestDtoDict.Values.ToList();
        var parentIds = latestDtos.Select(x => x.ParentID_FK);
        var childDict = new Dictionary<int, ChatDto>();
        await connection
            .QueryAsync<ChatDto, ChatUserDto, ChatPatientDto, ChatDto, ChatDto>(
                ChatSqls.ListLatestChild,
                (chat, chatUser, chatPatient, comment) =>
                {
                    if (!latestDtoDict.TryGetValue(chat.ChatID, out var chatEntry))
                    {
                        chatEntry = chat;
                        chatEntry.UserData = chatUser;
                        chatEntry.PatientData = chatPatient;
                        chatEntry.CommentList.Add(comment);
                        childDict.Add(chat.ChatID, chatEntry);
                    }
                    return chatEntry;
                },
                new
                {
                    ChatId = req.ChatID,
                    PatientId = req.PatientID,
                    UserId = req.UserID,
                    req.Family,
                    req.Count,
                    ParentIds = parentIds?.ToArray() ?? []
                },
                splitOn: "UserData_UserId, PatientData_PatientID, CommentList_ChatID"
            );
        var childDtos = childDict.Values.ToList();
        latestDtos.AddRange(childDtos);
        return latestDtos;
    }

    public async Task<IEnumerable<ChatDto>> ListPreviousAsync(GetChatListDto req)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Invalid connection string");
        }

        using var connection = new NpgsqlConnection(connectionString);
        var previousDtoDict = new Dictionary<int, ChatDto>();
        await connection
            .QueryAsync<ChatDto, ChatUserDto, ChatPatientDto, ChatDto, ChatDto>(
                ChatSqls.ListPrevious,
                (chat, chatUser, chatPatient, comment) =>
                {
                    if (!previousDtoDict.TryGetValue(chat.ChatID, out var chatEntry))
                    {
                        chatEntry = chat;
                        chatEntry.UserData = chatUser;
                        chatEntry.PatientData = chatPatient;
                        chatEntry.CommentList.Add(comment);
                        previousDtoDict.Add(chat.ChatID, chatEntry);
                    }
                    return chatEntry;
                },
                new
                {
                    ChatId = req.ChatID,
                    PatientId = req.PatientID,
                    UserId = req.UserID,
                    req.Family,
                    req.Count
                },
                splitOn: "UserData_UserId, PatientData_PatientID, CommentList_ChatID"
            );
        var previousDtos = previousDtoDict.Values.ToList();
        return previousDtos;
    }
}
