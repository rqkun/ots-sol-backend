namespace OTS.Data.ViewModels
{
    public class TestViewModel
    {
        public Guid TestId { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<QuestionForTestViewModel> QuestionForTestViewModels { get; set; } = new List<QuestionForTestViewModel>();
        public bool IsDeleted { get; set; }
    }
    public class QuestionForTestViewModel
    {
        public Guid QuestionForTestId { get; set; }
        public Guid TestId { get; set; }
        public virtual QuestionViewModel? Question { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public int QuestionNo { get; set; }
        public string? QuestionDetail { get; set; }
        public ICollection<AnswerViewModel> AnswerViewModels { get; set; } = new List<AnswerViewModel>();
        public bool IsDeleted { get; set; }
    }
    public class AnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string? AnswerDetail { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsDeleted { get; set; }
    }
}
