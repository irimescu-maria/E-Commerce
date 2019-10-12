using EducationalSoft.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationalSoft.Model.Entities
{
    public class User: NamedEntity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}