using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xul.Common.Base
{
  public  class UserLoggingInfo
    {
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Edited By")]
        public string EditedBy { get; set; }

        [Display(Name = "Date last edited")]
        public DateTime? EditedDate { get; set; }
    }
}
