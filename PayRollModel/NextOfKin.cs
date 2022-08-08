using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class NextOfKin
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "staff number")]
        public string StaffNo { get; set; } = string.Empty;

        [Display(Name = "next of kin")]
        public string Name { get; set; }

        [Display(Name = "next of kin phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "address of next of kin")]
        [DataType(DataType.MultilineText)]
        [StringLength(400, MinimumLength = 1)]
        public string Address { get; set; }
    }
}
