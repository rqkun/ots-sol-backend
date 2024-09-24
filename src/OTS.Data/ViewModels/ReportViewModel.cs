namespace OTS.Data.ViewModels
{
    #region View model
    public class ReportViewModel
    {
        public Guid ReportId { get; set; }
        public Guid TestId { get; set; }
        public DateTime ReportDate { get; set; }
        public string? Reason { get; set; }
        public bool IsDeleted { get; set; }
    }
    #endregion

    #region List view model
    public class AllReportViewModel
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public virtual ICollection<ReportViewModel> ReportViewModels { get; set; } = new List<ReportViewModel>();
    }
    #endregion
}
