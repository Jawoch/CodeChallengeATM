using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeChallengeATM.Models
{
    public class InputForm
    {
        [Required]
        [Range(10, double.MaxValue, ConvertValueInInvariantCulture = false, ErrorMessage = "Requested amount must be positive and grater than 10$")]
        [RegularExpression(@"[0-9]{1,}?0{1}$", ErrorMessage = "Requested amount must be multiples of 10$")]
        public decimal? ImputedAmount { get; set; }
        public List<decimal> Results { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
