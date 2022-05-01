using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class SubscribeRequest
    {
        [Key]
        public int Id { get; set; }

        public bool IsAccepted { get; set; } = false;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int SubscribeUserId { get; set; }

        [InverseProperty("SubscribeRequest")]
        [ForeignKey("SubscribeUserId")]
        public User SubscribeUser { get; set; }
    }
}
