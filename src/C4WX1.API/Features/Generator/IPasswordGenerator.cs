namespace C4WX1.API.Features.Generator
{
    public interface IPasswordGenerator
    {
        Task<string> GenerateAsync();
    }
}
