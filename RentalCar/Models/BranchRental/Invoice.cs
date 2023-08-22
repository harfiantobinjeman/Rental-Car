namespace RentalCar.Models.BranchRental
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public Guid IdBranch { get; set; }
        public Guid IdUser { get; set; }
        public string NoInvoice { get; set; }
        public int DayRent { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
