using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xul.Common.Enums;
using Xul.Domain.Entities;

namespace Xul.Common.Base
{
  public  class StudentItems:UserLoggingInfo
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return DateTime.Now.Year - this.DateOfBirth.Year; } }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

    }
}
