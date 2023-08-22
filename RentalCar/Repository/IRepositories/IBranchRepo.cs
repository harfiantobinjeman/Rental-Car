

using RentalCar.Dto.BranchRent;
using RentalCar.Models.BranchRental;

namespace RentalCar.Repository.IRepositories
{
    public interface IBranchRepo
    {
        Task<IEnumerable<CategoriBranchDto>> GetAllCategory();
        Task<CreateCategoryDto> Create(CreateCategoryDto createCategoryDto);
        Task<CategoriBranchDto> EditCategory(int id, EditBrancRentDto editBrancRentDto);
        Task<CategoriBranchDto> DelateCategory(int id);
        Task<IEnumerable<CategoriBranchDto>> GetCategoryId(int id);
        Task<IEnumerable<CategoriBranchDto>> GetCategoryName(string name);
    }
}
