using C4WX1.API.Features.MobileAppVersioning.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.MobileAppVersioning;

public class MobileAppVersioningFaker
{
    public static CreateMobileAppVersioningDto CreateDto => new()
    {
        AppName = "control-AppName",
        DeviceType = "control-DeviceType",
        Version = "control-Version",
        UserId = 1
    };

    public static CreateMobileAppVersioningDto CreateDummy =>
        new Faker<CreateMobileAppVersioningDto>()
        .RuleFor(x => x.AppName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.DeviceType, f => C4WX1Faker.AlphaNumeric)
        .RuleFor(x => x.Version, f => C4WX1Faker.AlphaNumeric)
        .RuleFor(x => x.UserId, f => 1)
        .Generate();

    public static UpdateMobileAppVersioningDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        AppName = "updated-control-AppName",
        DeviceType = "updated-control-DeviceType",
        Version = "updated-control-Version",
        UserId = 1
    };

    public static UpdateMobileAppVersioningStatusDto UpdateStatusDto(
        int? id = null,
        string? status = null)
        => new()
        {
            Id = id ?? C4WX1Faker.Id,
            Status = status ?? C4WX1Faker.ShortString,
            UserId = 1
        };
}
