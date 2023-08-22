using Microsoft.AspNetCore.Mvc;
using RentalCar.Dto;
using RentalCar.Dto.BranchRent;
using RentalCar.Models;
using RentalCar.Repository;
using RentalCar.Repository.IRepositories;
using System.Xml.Linq;

namespace RentalCar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalCarController : ControllerBase
    {
        private readonly IBranchRepo _branchRepo;

        public RentalCarController(IBranchRepo branchRepo)
        {
            _branchRepo = branchRepo;
        }
        [HttpPost("CreateBranc")]
        public async Task<ActionResult<CreateCategoryDto>> CreateBranch(CreateCategoryDto createCategory)
        {
            var cekName = await _branchRepo.GetCategoryName(createCategory.Name);
            if (cekName.Count() >= 1)
            {
                return Ok(new Response { Status = "Error", Message = "Name is Created in database!" });
            }
            var createBranch = await _branchRepo.Create(createCategory);
            return Ok(new Response { Status = "Success", Message = "Created successfully!" });
        }
        [HttpDelete]
        [Route("DeleteCaregory/{id:int}")]
        public async Task<ActionResult<CategoriBranchDto>> DeleteCategory(int id)
        {
            var delete = await _branchRepo.DelateCategory(id);
            return Ok(new Response { Status = "Success", Message = "Delete successfully!" });
        }
        [HttpPut("EditCategori/{id:int}")]
        public async Task<ActionResult<CreateCategoryDto>> UpdateUser(int id, EditBrancRentDto editBrancRentDto)
        {
            var updateCategori = await _branchRepo.EditCategory (id,editBrancRentDto);
            return Ok(new Response { Status = "Success", Message = "Delete successfully!" });
        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<IEnumerable<CategoriBranchDto>>> GetAllUser()
        {
            var Category = await _branchRepo.GetAllCategory();
            return Ok(Category);
        }
        [HttpGet]
        [Route("GetIdGaji/{id:int}")]
        public async Task<ActionResult<CategoriBranchDto>> GetId(int id)
        {
            var category = await _branchRepo.GetCategoryId(id);
            return Ok(category);
        }
    }
}
