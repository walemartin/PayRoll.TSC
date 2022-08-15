using PayRoll.TSC.Enums;
using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class Employees
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "staff number")]
        public string StaffNo { get; set; } = string.Empty;

        public int? TitleID { get; set; }
        public virtual Title Title { get; set; }

        [StringLength(100)]
        [Display(Name = "employee name")]
        public string EmployeeName { get; set; } = string.Empty;

        [Display(Name = "gender")]
        [DisplayFormat(NullDisplayText = "--select gender--")]
        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "contact address")]
        [DataType(DataType.MultilineText)]
        [StringLength(400, MinimumLength = 1)]
        public string Address { get; set; }


        public int? MaritalStatusID { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
       

        public int? StateOfOriginID { get; set; }
        public virtual StateOfOrigin StateOfOrigin { get; set; }

        public int? NationalityID { get; set; }
        public virtual Nationality Nationality { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime? PostedDate { get; set; }
    }
}
