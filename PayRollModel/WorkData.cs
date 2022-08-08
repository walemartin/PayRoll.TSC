using PayRoll.TSC.Enums;
using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class WorkData
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "staff number")]
        public string StaffNo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "hire date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "employee type")]
        [DisplayFormat(NullDisplayText = "--select type--")]
        public EmployeeType? EmployeeType { get; set; }

        public int? JobTitleID { get; set; }
        public virtual JobTitle JobTitle { get; set; }

        public int? BankBranchID { get; set; }
        public virtual BankBranch BankBranch { get; set; }

        [Display(Name = "currency")]
        [DisplayFormat(NullDisplayText = "--select currency--")]
        public Currency? Currency { get; set; }

        [Display(Name = "salary")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public int? PensionID { get; set; }
        public virtual Pension Pension { get; set; }

        public int? NHFID { get; set; }
        public virtual NHF NHF { get; set; }

        [Display(Name = "NHIS monthly amount")]
        [DataType(DataType.Currency)]
        public decimal NHISMonthlyAmt { get; set; }



    }
}
