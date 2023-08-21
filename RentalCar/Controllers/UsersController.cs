using Microsoft.AspNetCore.Mvc;
using RentalCar.Dto;
using RentalCar.Repository.IRepositories;

namespace RentalCar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpDelete]
        [Route("DeleteUsers/{id:guid}")]
        public async Task<ActionResult<UserDto>> DeleteUser(string id)
        {
            var delete = await _userRepo.DelateUser(id);
            return Ok(delete);
        }
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUser()
        {
            var gajiKaryawanDto = await _userRepo.GetAllUser();
            return Ok(gajiKaryawanDto);
        }

        [HttpPut("EditUser/{idUser:guid}")]
        public async Task<ActionResult<UserDto>> UpdateUser(string idUser, UserDto user)
        {
            var updateUser = await _userRepo.EditUser(idUser, user);
            return Ok(updateUser);
        }
        [HttpGet]
        [Route("GetIdGaji/{id:guid}")]
        public async Task<ActionResult<UserDto>> GetIdGaji(string name)
        {
            var idUser = await _userRepo.GetUserId(name);
            return Ok(idUser);
        }
    }
}
