//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xul.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Leaves = new HashSet<Leave>();
        }
    
        public int Id { get; set; }
        public string EmployNumber { get; set; }
        public int SchoolId { get; set; }
        public System.DateTime EnlistedDate { get; set; }
    
        public virtual School School { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
    }
}
