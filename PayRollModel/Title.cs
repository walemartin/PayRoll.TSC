using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class Title
    {
        public int ID { get; set; }

        [Display(Name = "title")]
        public string Name { get; set; }


        public virtual ICollection<StaffProfile> Staffprofile { get; set; }
    }
}