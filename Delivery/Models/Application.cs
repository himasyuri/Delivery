
namespace Delivery.Models
{
    public class Application
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public int NumberOfCars { get; set; }
        public string StartedWay { get; set; }
        public string EndedWay { get; set; }
        public bool IsApproved { get; set; }
        public bool IsReeded { get; set; }
        public Comment Comment { get; set; }
    }
}
