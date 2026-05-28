using System.ComponentModel.DataAnnotations;

namespace Bank.Services.AccountAPI.Models.Dto
{
    public class AccountsDto
    {
       
        public int Id { get; set; }
        
        public string Number { get; set; } = string.Empty;

        public double Balance { get; set; }
        
        public int OwnerId { get; set; }

    }
}

