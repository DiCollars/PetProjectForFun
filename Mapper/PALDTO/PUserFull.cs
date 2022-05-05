namespace Mapper.PALDTO
{
    public class PUserFull
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string ProfileName { get; set; }

        public string ProfilePhotoPath { get; set; }

        public string EmailAddress { get; set; }

        public bool IsPrivate { get; set; }
    }
}
