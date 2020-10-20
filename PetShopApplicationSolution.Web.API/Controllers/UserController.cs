﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShopApplication.Core.Entities;
using PetShopApplicationSolution.Infrastructure.Data.Helpers;
using PetShopApplicationSolution.Infrastructure.Data.Repositories;

namespace PetShopApplicationSolutionRestAPI.Controllers
{
    [Route("/token")]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepo;
        private readonly AuthenticationHelper _authenHelper;

        public UserController(UserRepository userRepo, AuthenticationHelper authenHelper)
        {
            _userRepo = userRepo;
            _authenHelper = authenHelper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.Username == model.Username);
            // check if username exists
            if (user == null)
                return Unauthorized();

            if (!_authenHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = _authenHelper.GenerateToken(user)
            });
        }

    }
}
