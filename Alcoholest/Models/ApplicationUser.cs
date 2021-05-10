using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Alcoholest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.AlcoholBeverages = new HashSet<AlcoholBeverage>();

            this.Roles = new HashSet<IdentityUserRole<string>>();
        }

        public virtual ICollection<AlcoholBeverage> AlcoholBeverages { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
    }
}
