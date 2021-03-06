//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfEmployeeRecord.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployee()
        {
            this.tblManagers = new HashSet<tblManager>();
            this.tblReports = new HashSet<tblReport>();
        }
    
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public string BankAccountNumber { get; set; }
        public string Email { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Position { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblManager> tblManagers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReport> tblReports { get; set; }
    }
}
