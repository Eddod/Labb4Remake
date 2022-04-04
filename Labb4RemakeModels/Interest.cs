using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4RemakeModels
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string InterestTitle { get; set; }
        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
