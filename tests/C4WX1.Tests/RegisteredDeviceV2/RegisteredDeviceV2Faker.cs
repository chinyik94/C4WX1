using C4WX1.API.Features.RegisteredDeviceV2.Dtos;

namespace C4WX1.Tests.RegisteredDeviceV2;

public class RegisteredDeviceV2Faker
{
    public static CreateRegisteredDeviceV2Dto CreateDto => new()
    {
        DeviceId = "control-DeviceId",
        DeviceName = "control-DeviceName",
        DeviceType = "control-DeviceType",
        DeviceToken = "control-DeviceToken",
        AppName = "control-AppName",
        Version = "control-Version",
        FirstRegisterIpAddress = "control-FirstRegisterIpAddress",
        Remarks = "control-Remarks",
        UserId = 1
    };

    public static CreateRegisteredDeviceV2Dto CreateDummy => new Faker<CreateRegisteredDeviceV2Dto>()
        .RuleFor(x => x.DeviceId, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.DeviceName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.DeviceType, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.DeviceToken, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.AppName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.Version, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.FirstRegisterIpAddress, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.Remarks, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.UserId, f => C4WX1Faker.Id)
        .Generate();

    public static UpdateRegisteredDeviceV2Dto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        DeviceId = "updated-control-DeviceId",
        DeviceName = "updated-control-DeviceName",
        DeviceType = "updated-control-DeviceType",
        DeviceToken = "updated-control-DeviceToken",
        AppName = "updated-control-AppName",
        Version = "updated-control-Version",
        FirstRegisterIpAddress = "updated-control-FirstRegisterIpAddress",
        Remarks = "updated-control-Remarks",
        UserId = 1
    };
}
