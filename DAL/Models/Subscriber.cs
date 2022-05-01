using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User{ get; set; }

        [Required]
        public int UserSubscriberId { get; set; }

        [InverseProperty("Subscriber")]
        [ForeignKey("UserSubscriberId")]
        public User UserSubscriber { get; set; }
    }
}
