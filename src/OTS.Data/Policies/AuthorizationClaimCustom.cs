using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace OTS.Data.Policies
{
    public class AuthorizationClaimCustom : TypeFilterAttribute
    {
        public AuthorizationClaimCustom(string claimValue) : base(typeof(AuthorizeClaimRequirementFilter))
        {
            Arguments = [new Claim(string.Empty, claimValue)];
        }
    }
}
