using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.ViewModels
{
    public class RoleViewModel
    {
        public Guid? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class RoleClaimsViewModel
    {
        public int? RoleClaimsId { get; set; }
        public Guid? RoleId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

}
