using System.ComponentModel.DataAnnotations;

namespace TicketingSolution.Domain.BaseModels
{
    public abstract class TicketBookingBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string Family { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Date <= DateTime.Now.Date)
            {
                yield return new ValidationResult("Date Must be In The Future", new[] { nameof(Date) });
            }
        }
    }
}
