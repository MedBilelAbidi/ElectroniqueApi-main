using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ElectroniqueApi.Model
{
    public class User:IdentityUser
    {

        [Required,MaxLength(50)]
       public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }

    }
}
