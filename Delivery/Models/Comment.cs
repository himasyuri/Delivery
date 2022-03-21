

namespace Delivery.Models
{
    public class Comment
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string ApplicationId { get; set; }

        public Application Application { get; set; }
    }
}
