using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Models
{
    public class BlacklistModel
    {
        public Guid BlacklistId { get; set; }
        public Guid UserId { get; set; }
        public string? Reason { get; set; }
        public DateTime? EntryDate { get; set; }
        public bool? IsActive { get; set; }
    }
    public class CreateBlackListModel
    {
        public Guid UserId { get; set; }
        public string? Reason { get; set; }
    }
    public class BlacklistUpdateModel
    {
        public string? Reason { get; set; }
        public bool? IsActive { get; set; }
    }
}
