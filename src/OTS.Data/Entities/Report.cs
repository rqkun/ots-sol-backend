using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace OTS.Data.Entities
{
    [Table("Report")]
    public class Report
    {
        [Key]
        public Guid ReportId { get; set; }

        //[Required]
        //[ForeignKey("UserId")]
        //public Guid UserId { get; set; }

        //public virtual User? User { get; set; }

        [Required]
        [ForeignKey("TestId")]
        public Guid TestId { get; set; }

        public virtual Test? Test { get; set; }

        public DateTime ReportDate { get; set; }

        public string? Reason { get; set; }

        public bool IsDeleted { get; set; }
    }
}
