namespace OTS.Data.ViewModels
{
    public class SubmitViewModel
    {
        public Guid SubmitId { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string? Answers { get; set; }
        public double Score { get; set; }
        // public virtual ICollection<SubmittedAnswerViewModel> SubmittedAnswerViewModels { get; set; } = new List<SubmittedAnswerViewModel>();
    }
    //public class SubmittedAnswerViewModel
    //{
    //    public Guid SubmittedAnswerId { get; set; }
    //    public virtual AnswerViewModel? Answers { get; set; }
    //}
}
