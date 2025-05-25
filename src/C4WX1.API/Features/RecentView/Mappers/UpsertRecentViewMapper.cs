using C4WX1.API.Features.RecentView.Dtos;

namespace C4WX1.API.Features.RecentView.Mappers;

public class UpsertRecentViewMapper 
    : RequestMapper<UpsertRecentViewDto, Database.Models.RecentView>
{
    public override Database.Models.RecentView ToEntity(UpsertRecentViewDto r)
        => new()
        {
            UserID_FK = r.UserID,
            PatientID_FK = r.PatientID,
            DateView = DateTime.Now
        };
}