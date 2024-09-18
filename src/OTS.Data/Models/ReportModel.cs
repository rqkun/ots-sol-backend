namespace OTS.Data.Models
{
    public class ReportModel
    {
        public Guid ReportId { get; set; }
        // public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Reason { get; set; }
    }
    public class ReportCreateModel
    {
        // public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Reason { get; set; }
    }
    public class ReportUpdateModel
    {
        // public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Reason { get; set; }
        public bool IsDeleted { get; set; }
    }
}
