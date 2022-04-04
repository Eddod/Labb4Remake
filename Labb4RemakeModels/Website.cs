using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4RemakeModels
{
    public class Website
    {
        [Key]
        public int WebsiteId { get; set; }
        public string Link { get; set; }
        
        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
