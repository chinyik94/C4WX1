namespace C4WX1.API.Features.Activity.Shared
{
    public sealed class ActivityDto
    {
        public int ActivityID { get; set; }
        public int ProblemListID_FK { get; set; }
        public int DiseaseID_FK { get; set; }
        public string ActivityDetail { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy_FK { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy_FK { get; set; }
        public int? DiseaseSubInfoID_FK { get; set; }
        public bool CanDelete { get; set; }
    }
}
