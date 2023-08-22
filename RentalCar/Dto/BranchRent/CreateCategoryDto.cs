namespace RentalCar.Dto.BranchRent
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid IdUser { get; set; }
        public string UserCreated { get; set; }
    }
}
