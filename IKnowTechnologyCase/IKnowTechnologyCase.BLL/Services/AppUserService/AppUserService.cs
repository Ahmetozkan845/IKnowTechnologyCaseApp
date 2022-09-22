using AutoMapper;
using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.CORE.Entities;
using IKnowTechnologyCase.CORE.IRepositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.BLL.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
        }


        public async Task<SignInResult> Login(LoginDTO model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            var user = new AppUser();
            user = mapper.Map(model, user);
            var result = await userManager.CreateAsync(user,model.Password);
            if (result.Succeeded) await signInManager.SignInAsync(user,false);
            return result;

        }
    }
}
