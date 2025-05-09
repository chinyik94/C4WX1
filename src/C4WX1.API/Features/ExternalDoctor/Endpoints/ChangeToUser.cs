using C4WX1.API.Features.ExternalDoctor.Dtos;
using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.API.Features.ExternalDoctor.Endpoints;

public class ChangeExternalDoctorToUserSummary : EndpointSummary
{
    public ChangeExternalDoctorToUserSummary()
    {
        Description = "Change External Doctor to User";
        Summary = "Change External Doctor to User";
        Responses[204] = "External Doctor changed to User successfully";
        Responses[404] = "External Doctor not found";
    }
}

public class ChangeToUser(THCC_C4WDEVContext dbContext)
    : Endpoint<ChangeExternalDoctorToUserDto>
{
    private readonly ICollection<int> _userTypes = [
        UserCategoryKey.Clinician,
        UserCategoryKey.Therapist
        ];

    public override void Configure()
    {
        Post("/external-doctor/change-to-user");
        Summary(new ChangeExternalDoctorToUserSummary());
    }

    public override async Task HandleAsync(ChangeExternalDoctorToUserDto req, CancellationToken ct)
    {
        var entity = await dbContext.ExternalDoctor
            .Where(x => x.Name == req.ExternalName && !x.IsDeleted)
            .FirstOrDefaultAsync(ct);
        if (entity == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var user = await dbContext.Users
            .Include(x => x.UserUserType)
            .Where(x => !x.IsDeleted
                && x.UserUserType.Any(y => _userTypes.Contains(y.UserTypeID_FK))
                && x.Firstname + " " + x.Lastname == req.UserName)
            .FirstOrDefaultAsync(ct);
        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var externalDoctors = dbContext.PatientClinician
            .Where(x => x.ExternalDoctorID_FK == entity.ExternalDoctorID)
            .AsAsyncEnumerable();
        await foreach (var externalDoctor in externalDoctors)
        {
            externalDoctor.UserID_FK = user.UserId;
            externalDoctor.ExternalDoctorID_FK = null;
            externalDoctor.ModifiedBy_FK = req.UserId;
            externalDoctor.ModifiedDate = DateTime.Now;
        }

        entity.IsDeleted = true;
        entity.ModifiedBy_FK = req.UserId;
        entity.ModifiedDate = DateTime.Now;
        await dbContext.SaveChangesAsync(ct);
        await SendNoContentAsync(ct);
    }
}
