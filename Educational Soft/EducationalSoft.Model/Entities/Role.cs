using EducationalSoft.Model.BaseEntities;
using System.Collections.Generic;

namespace EducationalSoft.Model.Entities
{
    public class Role: NamedEntity
    {
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}