namespace C4WX1.API.Features.Generator;

public interface IPasswordGenerator
{
    Task<string> GenerateAsync();
    string Generate(
        bool useAlpha,
        bool useNumeric,
        int minLength,
        int maxLength);
}
