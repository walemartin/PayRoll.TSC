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

        [Display(Name = "status")]
        [DisplayFormat(NullDisplayText = "--select--")]
        public Question? Question { get; set; }

        [Display(Name = "percentage (2.5% of Basic Salary)")]
        public double NHFpercentage { get; set; }
        public virtual ICollection<WorkData> WorkDatas { get; set; }
    }
    public class Pension
    {
        public int Id { get; set; }

        [Display(Name = "8% Employee | 10% Employer ")]
        public string Category { get; set; }

        [Display(Name = "status")]
        [DisplayFormat(NullDisplayText = "--select--")]
        public Question? Question { get; set; }

        [Display(Name = "pension (8% Employee | 10% Employer)")]
        public double PensionPercentage { get; set; }
        public virtual ICollection<WorkData> WorkDatas { get; set; }
    }
    public class SalaryBreakdown
    {
        public int Id { get; set; }

        [Display(Name = "Salary breakdown")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "% of Basic")]
        public double BasicPercentage { get; set; }

    }
    }
