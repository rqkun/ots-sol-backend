namespace OTS.Data.Models
{
    // SUBMIT
    public class SubmitModel
    {
        public Guid SubmitId { get; set; }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string? Answers { get; set; }
        public double Score { get; set; }
    }
    public class SubmitCreateModel
    {
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public string? Answers { get; set; }
        public double Score { get; set; }
    }

    //// SUBMITTED ANSWER
    //public class SubmittedAnswerModel
    //{
    //    public Guid SubmittedAnswerId { get; set; }
    //    public Guid SubmitId { get; set; }
    //    public Guid AnswerId { get; set; }
    //}
    //public class SubmittedAnswerCreateModel
    //{
    //    public Guid SubmitId { get; set; }
    //    public Guid AnswerId { get; set; }
    //}

}
