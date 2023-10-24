using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFT.CMS.Application.Roles.Dto;
using VFT.CMS.Application.Users.Dto;
using VFT.CMS.Core;

namespace VFT.CMS.Application.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public async Task<bool> Create(CreateUserDto model)
        {
            //var user = _mapper.Map<User>(model);
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists == null)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FullName = model.FullName,
                    CreatedDate = model.CreatedDate,
                    Birthday = model.Birthday
                };

                IdentityResult res = await _userManager.CreateAsync(user, model.Password);
                if (res.Succeeded)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task Update(EditUserDto model)
        {
            var data = _mapper.Map<User>(model);
            var user = await _userManager.FindByIdAsync(data.Id.ToString());
            if (user != null)
            {
                user.Email = model.Email;
                user.FullName = data.FullName;
                user.Birthday = data.Birthday;
                user.ModifiedDate = DateTime.Now;

                await _userManager.UpdateAsync(user);
            }
        }

        public async Task Delete(int id)
        {
            var product = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(product);
        }
    }
}
