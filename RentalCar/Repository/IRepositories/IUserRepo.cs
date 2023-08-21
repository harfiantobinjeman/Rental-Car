using RentalCar.Dto;

namespace RentalCar.Repository.IRepositories
{
    public interface IUserRepo
    {
        Task<IEnumerable<UserDto>> GetAllUser();
        Task<IEnumerable<RolesUserDto>> GetAllRoles();
        Task<IEnumerable<UserAndRolesDto>> GetAllUserAndRole();
        Task<UserDto> EditUser(string idUser, UserDto userDto);
        Task<UserDto> DelateUser(string id);
        Task<IEnumerable<UserDto>> GetUserId(string name);
    }
}
