using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TempusHiring.DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        public bool IsDeleted { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
