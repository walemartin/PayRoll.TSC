using PayRoll.TSC.Enums;
using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class StaffProfile
    {
        public int ID { get; set; }

        [Display(Name = "transaction ID")]
        public string TrxnID { get; set; }

        [StringLength(100)]
        [Display(Name = "staff number")]
        public string StaffNo { get; set; }
       
        public int? TitleID { get; set; }
        public virtual Title Title { get; set; }

        [Display(Name = "full name")]
        public string FullName
        {
            get { return Surname + " " + FirstName + " " +OtherName; }
        }

       

        [StringLength(100)]
        [Display(Name = "first name")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "last name")]
        public string Surname { get; set; }

        [StringLength(100)]
        [Display(Name = "middle name")]
        public string OtherName { get; set; }

        [Display(Name = "gender")]
        [DisplayFormat(NullDisplayText = "--select gender--")]
        public Gender? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "date of birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        [Display(Name = "maiden name")]
        public string MaidenName { get; set; }


        [Display(Name = "phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "phone number 2")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber2 { get; set; }

        [Display(Name = "email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "address")]
        [DataType(DataType.MultilineText)]
        [StringLength(400, MinimumLength = 1)]
        public string Address { get; set; }



        public int? StateOfOriginID { get; set; }
        public virtual StateOfOrigin StateOfOrigin { get; set; }

        public int? NationalityID { get; set; }
        public virtual Nationality Nationality { get; set; }

        public int? MaritalStatusID { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "No. of children")]
        public sbyte NoOfChildren { get; set; }

        public int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public int? JobTitleID { get; set; }
        public virtual JobTitle JobTitle { get; set; }


        public int? SalaryGradeID { get; set; }
        public virtual SalaryGrade SalaryGrade { get; set; }


        [Display(Name = "currency")]
        [DisplayFormat(NullDisplayText = "--select currency--")]
        public Currency? Currency { get; set; }

        [Display(Name = "annual basic salary")]
        [DataType(DataType.Currency)]
        public decimal AnnualBasicSalary { get; set; }

        public int? BankBranchID { get; set; }
        public virtual BankBranch BankBranch { get; set; }

        public int? PaymentModeID { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }

        public int? AccountTypeID { get; set; }
        public virtual AccountType AccountType { get; set; }


        [Display(Name = "transport allowance")]
        public bool? TransportAllowance { get; set; }


        [Display(Name = "probation period")]
        public sbyte ProbationPeriod { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "appointment date")]
        public DateTime? AppointmentDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "first appointment date")]
        public DateTime? FirstAppointment { get; set; }

        

        [Display(Name = "status")]
        [DisplayFormat(NullDisplayText = "--select status--")]
        public IsActive? IsActive { get; set; }

       

        [Display(Name = "posted by")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "posted date")]
        public DateTime PostedDate { get; set; }
    }
}
