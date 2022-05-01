using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
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

        public bool IsPrivate { get; set; } = false;

        /// <summary>
        /// Likes which he leave on publications
        /// </summary>
        public List<PublicationLike>? Likes {get;set;}

        /// <summary>
        /// His publications
        /// </summary>
        public List<Publication>? Publications { get; set; }

        public List<Subscriber>? Subscribers { get; set; }

        [InverseProperty("UserSubscriber")]
        public Subscriber? Subscriber { get; set; }

        public List<Subscription>? Subscriptions { get; set; }

        [InverseProperty("UserSubscription")]
        public Subscription? Subscripter { get; set; }

        public List<SubscribeRequest>? SubscribeRequests { get; set; }

        [InverseProperty("SubscribeUser")]
        public SubscribeRequest? SubscribeRequest { get; set; }
    }
}
