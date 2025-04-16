namespace C4WX1.API.Features.Branch.Dtos;

public sealed class UpdateBranchDto
{
    public int BranchID { get; set; }
    public string BranchName { get; set; } = null!;
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? Address3 { get; set; }
    public string? Contact { get; set; }
    public string? Email { get; set; }
    public string Status { get; set; } = null!;
    public int? CurrencyID_FK { get; set; }
    public int UserId { get; set; }
    public ICollection<int> UserDataList { get; set; } = [];
}
