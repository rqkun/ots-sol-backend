using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OTS.Data.Entities
{
    [Table("Submit")]
    public class Submit
    {
        [Key]
        public Guid SubmitId { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [Required]
        public Guid TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test? Tests { get; set; }

        public double Score { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<SubmittedAnswer> SubmittedAnswers { get; set; } = new List<SubmittedAnswer>();
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
