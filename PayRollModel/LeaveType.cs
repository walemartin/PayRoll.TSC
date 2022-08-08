using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class LeaveType
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "leave type")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "No. Of Days Annually")]
        public byte NoOfDaysAnnually { get; set; }
    }
}
