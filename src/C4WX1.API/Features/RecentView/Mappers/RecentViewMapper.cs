using C4WX1.API.Features.RecentView.Dtos;

namespace C4WX1.API.Features.RecentView.Mappers;

public class RecentViewMapper
    : ResponseMapper<RecentViewDto, Database.Models.RecentView>
{
    public override RecentViewDto FromEntity(Database.Models.RecentView e)
        => new()
        {
            PatientID = e.PatientID_FK,
            Firstname = e.PatientID_FKNavigation.Firstname,
            Lastname = e.PatientID_FKNavigation.Lastname,
            DateOfBirth = e.PatientID_FKNavigation.DateOfBirth,
            IdentificationNumber = e.PatientID_FKNavigation.IdentificationNumber,
            Status = e.PatientID_FKNavigation.Status,
            Photo = e.PatientID_FKNavigation.Photo,
            Profile = e.PatientID_FKNavigation.PatientProfileID_FKNavigation == null
                ? null
                : new RecentViewPatientProfileDto
                {
                    MobilePhone = e.PatientID_FKNavigation.PatientProfileID_FKNavigation.MobilePhone,
                    HomePhone = e.PatientID_FKNavigation.PatientProfileID_FKNavigation.HomePhone,
                    Email = e.PatientID_FKNavigation.PatientProfileID_FKNavigation.Email
                },
            ClinicianList = [.. e.PatientID_FKNavigation.PatientClinician
                .Where(x => !x.IsDeleted)
                .Select(x => new RecentViewClinicianDto
                {
                    PatientClinicianID = x.PatientClinicianID,
                    UserID_FK = x.UserID_FK,
                    ExternalDoctorID_FK = x.ExternalDoctorID_FK,
                    UserData = x.UserID_FKNavigation == null
                        ? null
                        : new RecentViewClinicianUserDto
                        {
                            UserId = x.UserID_FK,
                            Firstname = x.UserID_FKNavigation.Firstname,
                            Lastname = x.UserID_FKNavigation.Lastname,
                            Email = x.UserID_FKNavigation.Email,
                            Contact = x.UserID_FKNavigation.Contact,
                            Photo = x.UserID_FKNavigation.Photo
                        },
                    ExternalDoctorData = x.ExternalDoctorID_FKNavigation == null
                        ? null
                        : new RecentViewExternalDoctorDto
                        {
                            ExternalDoctorID = x.ExternalDoctorID_FK,
                            Name = x.ExternalDoctorID_FKNavigation.Name,
                            Contact = x.ExternalDoctorID_FKNavigation.Contact,
                            Email = x.ExternalDoctorID_FKNavigation.Email,
                            ClinicianTypeID_FK = x.ExternalDoctorID_FKNavigation.ClinicianTypeID_FK,
                            ClinicianTypeName = x.ExternalDoctorID_FKNavigation.ClinicianTypeID_FKNavigation?.UserType1
                        }
                })]
        };
}
