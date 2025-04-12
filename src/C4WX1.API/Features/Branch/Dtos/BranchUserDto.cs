namespace C4WX1.API.Features.Branch.Dtos;

public sealed class BranchUserDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
