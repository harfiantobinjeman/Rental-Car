using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalCar.Data;
using RentalCar.Dto;
using RentalCar.Dto.BranchRent;
using RentalCar.Models;
using RentalCar.Models.BranchRental;
using RentalCar.Repository.IRepositories;
using System.Xml.Linq;

namespace RentalCar.Repository
{
    public class BranchRentRepo : IBranchRepo
    {
        private readonly RentalCarDataContext _rentalCarDataContext;

        public BranchRentRepo(RentalCarDataContext rentalCarDataContext)
        {
            _rentalCarDataContext = rentalCarDataContext;
        }
        public async Task<CreateCategoryDto> Create(CreateCategoryDto createCategory )
        {
            var createBranch = new CategoriBranch()
            {
                Name = createCategory.Name,
                CreatedDate = DateTime.Now,
                IdUser = createCategory.IdUser,
                UserCreated = createCategory.UserCreated,
                UserModif = " ",
                ModifDate= DateTime.Now,
            };
            await _rentalCarDataContext.CategoriBranches.AddAsync(createBranch);
            await _rentalCarDataContext.SaveChangesAsync();
            return createCategory;
        }

        public async Task<CategoriBranchDto> DelateCategory(int id)
        {
            var deleteBranch = _rentalCarDataContext.CategoriBranches.Find(id);
            if (deleteBranch != null)
            {
                _rentalCarDataContext.Remove(deleteBranch);
                _rentalCarDataContext.SaveChanges();
            }
            return null;
        }

        public async Task<CategoriBranchDto> EditCategory(int id, EditBrancRentDto editBrancRentDto)
        {
            var categoriid = await _rentalCarDataContext.CategoriBranches.FindAsync(id);
            if (categoriid != null)
            {
                categoriid.Name= editBrancRentDto.Name;
                categoriid.CreatedDate= categoriid.CreatedDate;
                categoriid.UserCreated = categoriid.UserCreated;
                categoriid.ModifDate= DateTime.Now;
                categoriid.UserModif = editBrancRentDto.UserModif;
                categoriid.IdUser = categoriid.IdUser;
                await _rentalCarDataContext.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<CategoriBranchDto>> GetAllCategory()
        {
            var getcategori =  await _rentalCarDataContext.CategoriBranches.ToListAsync();
            var result = (from cate in getcategori
                          select new CategoriBranchDto
                          {
                              Name=cate.Name
                          });
            return result;
        }

        public async Task<IEnumerable<CategoriBranchDto>> GetCategoryId(int id)
        {
            var getcategori = await _rentalCarDataContext.CategoriBranches.ToListAsync();
            var result = (from cate in getcategori
                          select new CategoriBranchDto
                          {
                              Id=cate.Id,
                              Name = cate.Name
                          }).Where(x=>x.Id == id).ToList();
            return result;
        }

        public async Task<IEnumerable<CategoriBranchDto>> GetCategoryName(string name)
        {
            var getcategori = await _rentalCarDataContext.CategoriBranches.ToListAsync();
            var result = (from cate in getcategori
                          select new CategoriBranchDto
                          {
                              Id = cate.Id,
                              Name = cate.Name
                          }).Where(x => x.Name == name).ToList();
            return result;
        }
    }
}
