using PayRoll.TSC.Enums;
using System.ComponentModel.DataAnnotations;

namespace PayRoll.TSC.PayRollModel
{
    public class StatutoryContribution
    {
        
    }
    public class NHF 
    {
        public int Id { get; set; }

        [Display(Name = "NHF")]
        [DisplayFormat(NullDisplayText = "--select--")]
        public Question? Question { get; set; }

        public double NHFpercentage { get; set; }
    }
    public class Pension
    {
        public int Id { get; set; }

        [Display(Name = "Pension")]
        [DisplayFormat(NullDisplayText = "--select--")]
        public Question? Question { get; set; }

        public double PensionPercentage { get; set; }
    }
 }
