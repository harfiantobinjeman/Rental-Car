using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.BranchRental
{
    public class DetailBranch
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdBranch { get; set; }
        public Guid IdFoto { get; set; }
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Tahun { get; set; }
        public decimal Harga { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifDatw { get; set; }
        public string UserCreated { get; set; }
        public string UserModif { get; set; }
    }
}
