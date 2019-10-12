using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EducationalSoft.Model.BaseEntities
{
    public class NamedEntity
    {
        public virtual int Id { get; set; }


        [ReadOnly(true)]
        public DateTime CreationDate { get; set; }

        [Editable(false)]
        public DateTime LastUpdate { get; set; }
    }
}