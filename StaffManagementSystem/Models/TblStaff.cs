using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StaffManagementSystem.Models
{
    public partial class TblStaff
    {
        public int StaffId { get; set; }
        [Required]
        [Display(Name ="Staff Name:")]
        public string StaffName { get; set; }
        [Required]
        [Display(Name ="Phone number:")]
        public string PhoneNumber { get; set; }
        public int? SkillId { get; set; }
        [Required]
        [Display(Name ="Years of Experience")]
        public int? YearsExperience { get; set; }
    }
}
