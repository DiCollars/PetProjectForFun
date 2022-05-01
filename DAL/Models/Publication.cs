using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Publication
    {
        [Key]
        public int Id { get; set; }

        public string? Description { get; set; }

        [Required]
        public string PicPath { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        /// <summary>
        /// Likes which users leave on publication
        /// </summary>
        public List<PublicationLike>? Likes { get; set; }
    }
}
