using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.BranchRental
{
    public class CategoriBranch
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifDate { get; set; }
        public Guid IdUser { get; set; }
        public string UserCreated { get; set; }
        public string UserModif { get; set; }
    }
}
