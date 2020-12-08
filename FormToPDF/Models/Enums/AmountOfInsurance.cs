using System.ComponentModel.DataAnnotations;

namespace FormToPDF.Models
{
    public enum AmountOfInsurance
    {
        [Display(Name = "1")]
        One = 1,
        [Display(Name = "2")]
        Two = 2,
        [Display(Name = "3")]
        Three = 3,
        [Display(Name = "4")]
        Four = 4,
        [Display(Name = "5")]
        Five = 5,
        [Display(Name = "10")]
        Ten = 10,
    }
}
