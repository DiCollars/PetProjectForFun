using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class RegistrationRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string ProfileName { get; set; }

        [Required]
        public string ProfilePhotoPath { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public bool IsPrivate { get; set; } = false;

        public bool AcceptedDataByAdmin { get; set; }

        public int AdminId { get; set; }

        public DateTime CreatedRequestDate { get; set; }

        public DateTime AcceptionRequestDate { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
