﻿namespace C4WX1.API.Features.C4WDeviceToken.Dtos;

public sealed class C4WDeviceTokenDto
{
    public int C4WDeviceTokenId { get; set; }
    public string? OldDeviceToken { get; set; }
    public string? NewDeviceToken { get; set; }
    public string? ClientEnvironment { get; set; }
    public string? Device { get; set; }
}
