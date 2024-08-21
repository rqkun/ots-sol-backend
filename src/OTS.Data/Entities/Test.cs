using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace OTS.Data.Entities
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public bool IsDeleted { get; set; }
    }

    [Table("Question")]
    public class Question
    {
        [Key]
        public Guid QuestionId { get; set; }

        public int QuestionNo { get; set; }

        public string? Detail { get; set; }
        
        public bool IsDeleted { get; set; }
    }

    [Table("QuestionForTest")]
    public class QuestionForTest
    {
        [Key]
        public Guid QuestionForTestId { get; set; }

        [Required]
        public Guid TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test? Test { get; set; }

        [Required]
        public Guid QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question? Question { get; set; }

        public bool IsDeleted { get; set; }
    }

    [Table("Answer")]
    public class Answer
    {
        [Key]
        public Guid AnswerId { get; set;}

        [Required]
        public int QuestionId { get;set; }
        [ForeignKey("QuestionId")]
        public virtual Question? Question { get; set; }

        [Required]
        public string? AnswerDetail { get; set; }

        public bool IsCorrect { get; set; }

        public bool IsDeleted { get; set; }
    }

    [Table("Submit")]
    public class Submit
    {
        [Key]
        public Guid SubmitId { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]

        [Required]
        public Guid TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test? Tests { get; set; }

        public double Score { get; set; }

        public bool IsDeleted { get; set; }
    }

    [Table("SubmittedAnswer")]
    public class SubmittedAnswer
    {
        [Key]
        public Guid SubmittedAnswerId { get; set; }

        [Required]
        public Guid SubmitId { get; set; }
        [ForeignKey("SubmitId")]
        public virtual Submit? Submit { get; set; }

        [Required]
        public Guid AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public virtual Answer? Answer { get; set; }

        public bool IsDeleted { get; set; }
    }
}
