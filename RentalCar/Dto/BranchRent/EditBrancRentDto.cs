namespace RentalCar.Dto.BranchRent
{
    public class EditBrancRentDto
    {
        public string Name { get; set; }
        public Guid IdUser { get; set; }
        public DateTime? ModifDate { get; set; }
        public string UserModif { get; set; }
    }
}
