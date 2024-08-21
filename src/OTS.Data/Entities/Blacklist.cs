using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Entities
{
    [Table("Blacklist")]
    public class Blacklist
    {
        [Key]
        [Column("BlacklistId")]
        public Guid BlacklistId { get; set; }

        public Guid? UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public string? Reason { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
