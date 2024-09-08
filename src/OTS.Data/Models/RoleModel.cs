using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Models
{
    public class RoleModel
    {
        public Guid RoleId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class RoleClaimModel
    {
        public Guid? RoleId { get; set; }
        public string? ClaimType { get; set; }
    }

    public class UserRoleModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }

    public class CreateRoleModel {
        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

    }
}
