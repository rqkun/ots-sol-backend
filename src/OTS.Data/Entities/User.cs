using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Column("AvatarSeed")]
        public string? AvatarSeed {  get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted {  get; set; }

    }
}
