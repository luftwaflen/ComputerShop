using ComputerShopIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputerShopIdentity
{
    public class IdentityContext : IdentityDbContext<UserIdentityModel, IdentityRole<int>, int,
        IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) :
            base(options)
        {

        }
    }
}
