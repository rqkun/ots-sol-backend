using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Entities
{
    public class Role : IdentityRole<Guid>
    {
        [Column("Description")]
        public string? Description { get; set; }
    }

    public class RoleClaim : IdentityRoleClaim<Guid>{ }
    public class UserRole : IdentityUserRole<Guid> { }
}
