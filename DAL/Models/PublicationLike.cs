using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class PublicationLike
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime{ get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int PublicstionId { get; set; }

        [ForeignKey("PublicstionId")]
        public Publication Publicstion { get; set; }
    }
}
