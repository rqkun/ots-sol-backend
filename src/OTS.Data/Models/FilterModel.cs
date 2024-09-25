using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Models
{
    public class FilterModel
    {
        public string? Key { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public bool IsDeleted { get; set; }
    }
}
