using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class LeaveType
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "leave type")]
        public string Leave { get; set; } = string.Empty;

        [Display(Name = "No. Of Days Annually")]
        public byte NoOfDaysAnnually { get; set; }
    }
    public class LeaveAllowance
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "leave type")]
        public string LeaveType { get; set; } = string.Empty;

       
    }
    public class LeaveRequest
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "leave type")]
        public string StaffNo { get; set; } = string.Empty;

        [Display(Name = "status of leave days available")]
        public byte LeaveDaysAvailable { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "leave start date")]
        public DateTime? LeaveStartDate { get; set; }

        [Display(Name = "No. of days for leave")]
        public byte NoOfDays { get; set; }

        public int? LeaveAllowanceID { get; set; }
        public virtual LeaveAllowance LeaveAllowance { get; set; }

        [Display(Name = "allowance amount")]
        [DataType(DataType.Currency)]
        public decimal AllowanceAmount { get; set; }

        [Display(Name = "reason for leave")]
        [DataType(DataType.MultilineText)]
        [StringLength(400, MinimumLength = 1)]
        public string ReasonForLeave { get; set; } = string.Empty;
    }
}
