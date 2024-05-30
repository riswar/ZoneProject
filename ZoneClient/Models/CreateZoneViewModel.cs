using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZoneClient.Models
{
    public class CreateZoneViewModel
    {
        [DisplayName("Zone")]
        [MaxLength(100)]
        [MinLength(10)]
        public string Name { get; set; }
    }
}
