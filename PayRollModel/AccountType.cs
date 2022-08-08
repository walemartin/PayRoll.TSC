using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class AccountType
    {
        public int ID { get; set; }

        [Display(Name = "account type")]
        public string Name { get; set; }
        public virtual ICollection<StaffProfile> Staffprofile { get; set; }
    }
}