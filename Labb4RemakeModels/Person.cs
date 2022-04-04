using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Labb4RemakeModels
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public ICollection<PersonInterest> PersonInterest { get; set; }

    }
}
