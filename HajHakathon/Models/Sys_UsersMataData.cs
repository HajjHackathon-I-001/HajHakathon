using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HajHakathon.Models
{
    [MetadataType(typeof(MataData))]
    public partial class Sys_Users
    {
        sealed class MataData
        {
            [Display(Name = "DeviceStatuesID1", ResourceType = typeof(Resources.DisplayNameResourses))]
            public int ID { get; set; }
            public string NameAr { get; set; }
            public string NameEn { get; set; }
            public Nullable<System.DateTime> BirthDate { get; set; }
            public string Gender { get; set; }
            public Nullable<int> CountaryID { get; set; }
            public string MobileNumber { get; set; }
            public string IdentityNumber { get; set; }
            public string Email { get; set; }
            public string Passport { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public Nullable<System.DateTime> CreatedDate { get; set; }
            public Nullable<int> CreatedUserID { get; set; }
            public Nullable<System.DateTime> LastUpdatedDate { get; set; }
            public Nullable<int> LastUpdatedUserID { get; set; }
            public string UsrName { get; set; }
            public string Password { get; set; }
        }
    }
}