using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int UserSubscriptionId { get; set; }

        [InverseProperty("Subscripter")]
        [ForeignKey("UserSubscriptionId")]
        public User UserSubscription { get; set; }
    }
}
