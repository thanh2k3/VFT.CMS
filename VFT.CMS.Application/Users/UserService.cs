using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
		private readonly IHostingEnvironment _environment;

		public UserService(UserManager<User> userManager, IMapper mapper, IHostingEnvironment environment)
        {
            _userManager = userManager;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public async Task<bool> Create(CreateUserDto model, IFormFile? image)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists == null)
            {
                if (image != null)
                {
                    var imageName = "user_" + Guid.NewGuid().ToString() + "_" + image.FileName;

                    var name = Path.Combine(_environment.WebRootPath + "/image/user", imageName);
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    model.Avatar = "image/user/" + imageName;
                }
                else
                {
                    model.Avatar = "image/user/avatar-default-man.png";
                }

                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FullName = model.FullName,
                    CreatedDate = DateTime.Now,
                    Birthday = model.Birthday,
                    Avatar = model.Avatar,
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

        public async Task Update(EditUserDto model, IFormFile? image)
        {
            var data = _mapper.Map<User>(model);
            var user = await _userManager.FindByIdAsync(data.Id.ToString());
            if (user != null)
            {
                if (image != null)
                {
                    var imageName = "user_" + Guid.NewGuid().ToString() + "_" + image.FileName;

                    var name = Path.Combine(_environment.WebRootPath + "/image/user", imageName);
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    data.Avatar = "image/user/" + imageName;
                }
                else
                {
                    data.Avatar = user.Avatar;
                }

                user.Email = data.Email;
                user.FullName = data.FullName;
                user.Birthday = data.Birthday;
                user.ModifiedDate = DateTime.Now;
                user.Avatar = data.Avatar;

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
