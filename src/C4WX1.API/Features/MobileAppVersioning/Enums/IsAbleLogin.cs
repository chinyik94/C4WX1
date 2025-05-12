namespace C4WX1.API.Features.MobileAppVersioning.Enums;

public enum IsAbleLogin
{
    YesButSysConfigDisabled = 1,
    YesVersionActive = 2,
    NoVersionPending = 3,
    NoVersionForcedUpdate = 4,
    NoVersionNotFound = 5
}
