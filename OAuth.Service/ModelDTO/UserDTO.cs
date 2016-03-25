
using OAuth.Domain.Model;

namespace OAuth.Service.ModelDto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DigitalCertificate { get; set; }

        public byte Status { get; set; }

        public bool IsDisabled { get; set; }
    }
}
