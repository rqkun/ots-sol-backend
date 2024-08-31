using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.ViewModels
{
    public class BlackListViewModel
    {
        public Guid BlacklistId { get; set; }
        public Guid? UserId { get; set; }
        public string? Username { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? Reason { get; set; }
    }
    public class BlackListEntriesViewModel
    {
        public int? TotalCount { get; set; }
        public virtual ICollection<BlackListViewModel>? EntryList { get; set; }
    }
}
