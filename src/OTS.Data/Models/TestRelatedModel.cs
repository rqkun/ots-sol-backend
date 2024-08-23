namespace OTS.Data.Models
{
    // TEST
    public class TestModel
    {
        public Guid TestId { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class TestCreateModel
    {
        public Guid CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class TestUpdateModel
    {
        public Guid TestId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    // QUESTION
    public class QuestionModel
    {
        public Guid QuestionId { get; set; }
        public int QuestionNo { get; set; }
        public string? Detail { get; set; }
    }
    public class QuestionCreateModel
    {
        public int QuestionNo { get; set; }
        public string? Detail { get; set; }
    }
    public class QuestionUpdateModel
    {
        public Guid QuestionId { get; set; }
        public string? Detail { get; set; }
    }

    // QUESTION FOR TEST
    public class QuestionForTestModel
    {
        public Guid QuestionForTestId { get; set; }
        public Guid TestId { get; set; }
        public Guid QuestionId { get; set; }
    }
    public class QuestionForTestCreateModel
    {
        public Guid TestId { get; set; }
        public Guid QuestionId { get; set; }
    }

    // ANSWER
    public class AnswerModel
    {
        public Guid AnswerId { get; set; }
        public Guid QuestionId { get; set; }
        public string? AnswerDetail { get; set; }
        public bool IsCorrect {  get; set; }
    }
    public class AnswerCreateModel
    {
        public Guid QuestionId { get; set; }
        public string? AnswerDetail { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class AnswerUpdateModel
    {
        public Guid AnswerId { get; set; }
        public string? AnswerDetail { get; set; }
        public bool IsCorrect { get; set; }
    }
}
