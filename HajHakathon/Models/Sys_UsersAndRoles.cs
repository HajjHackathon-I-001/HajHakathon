//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HajHakathon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sys_UsersAndRoles
    {
        public int ID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> MenueID { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Regdate { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedUserID { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<int> LastUpdateUserID { get; set; }
    
        public virtual Sys_Menues Sys_Menues { get; set; }
        public virtual Sys_Roles Sys_Roles { get; set; }
    }
}