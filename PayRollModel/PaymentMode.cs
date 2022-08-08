using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class PaymentMode
    {
        public int ID { get; set; }

        [Display(Name = "payment mode")]
        public string Name { get; set; }
        public virtual ICollection<StaffProfile> Staffprofile { get; set; }
    }
}