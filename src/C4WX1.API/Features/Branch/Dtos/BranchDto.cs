namespace C4WX1.API.Features.Branch.Dtos;

public sealed class BranchDto
{
    public int BranchID { get; set; }
    public string BranchName { get; set; } = null!;
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? Contact { get; set; }
    public string? Email { get; set; }
    public string Status { get; set; } = null!;
    public bool IsSystemUsed { get; set; }
    public int? CurrencyID_FK { get; set; }
    public string CurrencyName { get; set; } = null!;
    public bool CanDelete { get; set; }
    public ICollection<BranchUserDto> UserDataList { get; set; } = [];
}
