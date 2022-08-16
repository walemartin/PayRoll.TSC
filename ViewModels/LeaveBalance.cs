using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.ViewModels
{
    public class LeaveBalance
    {

        //
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "staff number")]
        public string StaffNo { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "employee name")]
        public string EmployeeName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "most recent leave date")]
        public DateTime? LeaveDates { get; set; }

        // on the view page add a logic for passing status of leave for active and non active based on the date. 
    }
    public class LeaveServiceReport
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "staff number")]
        public string StaffNo { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "employee name")]
        public string EmployeeName { get; set; } = string.Empty;

      
        [Display(Name = "total leave days")]
        public byte TotalLeaveDays { get; set; }
    }
}
