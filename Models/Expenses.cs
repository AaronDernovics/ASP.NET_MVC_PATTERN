using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than zero!")]
        public int Amount { get; set; }
    }
}
