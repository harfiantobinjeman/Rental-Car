using Microsoft.EntityFrameworkCore;
using RentalCar.Data;
using RentalCar.Dto;
using RentalCar.Repository.IRepositories;

namespace RentalCar.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly RentalCarDataContext _adaptiveTestDbContect;

        public UserRepo(RentalCarDataContext adaptiveTestDbContect)
        {
            _adaptiveTestDbContect = adaptiveTestDbContect;
        }

        public async Task<UserDto> DelateUser(string id)
        {

            var user = await _adaptiveTestDbContect.Users.FindAsync(id);
            if (user != null)
            {
                _adaptiveTestDbContect.Remove(user);
                _adaptiveTestDbContect.SaveChanges();
            }
            return null;
        }

        public async Task<UserDto> EditUser(string idUser, UserDto userDto)
        {
            var user = await _adaptiveTestDbContect.Users.FindAsync(idUser);
            if (user != null)
            {
                user.UserName = userDto.Name;
                user.Email = userDto.Email;
                user.NormalizedEmail = userDto.NormalizedEmail;
                await _adaptiveTestDbContect.SaveChangesAsync();
            }
            return null;
        }

        public Task<IEnumerable<RolesUserDto>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUser()
        {
            var user = await _adaptiveTestDbContect.Users.ToListAsync();
            var result = (from usr in user
                          select new UserDto
                          {
                              Id = user.First().Id,
                              Name = user.First().UserName,
                              Email = user.First().Email,
                          }).ToList();
            return result;
        }

        public Task<IEnumerable<UserAndRolesDto>> GetAllUserAndRole()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetUserId(string name)
        {
            var user = await _adaptiveTestDbContect.Users.ToListAsync();
            if (user != null)
            {
                var result = (from usr in user
                              select new UserDto
                              {
                                  Id = user.First().Id,
                                  Name = user.First().UserName,
                                  Email = user.First().Email,
                              }).Where(x => x.Name == name)
                              .ToList();
                return result;
            }
            return null;
        }
    }
}
