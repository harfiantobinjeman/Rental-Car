using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    public class StatusProduct
    {
        [Key]
        public int IdStatus { get; set; }

        public string line { get; set; }
        public string pull { get; set; }
        public string delp { get; set; }
        public string informatio { get; set; }
    }
}
