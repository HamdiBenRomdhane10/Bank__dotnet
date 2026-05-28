using System.ComponentModel.DataAnnotations;

namespace Bank.Services.AccountAPI.Models
{
    public class Accounts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; } = string.Empty;
        [Required]
        public double Balance { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }

}
