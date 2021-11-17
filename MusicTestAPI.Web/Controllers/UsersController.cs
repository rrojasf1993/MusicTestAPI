﻿using Microsoft.AspNetCore.Mvc;
using MusicTestAPI.Common.DataTransferObjects;
using MusicTestAPI.Data.Interfaces;
using MusicTestAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicTestAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public IUserService UserService { get; set; }

        public UsersController(IUserService userService, IUnitOfWork uow)
        {
            this.UnitOfWork = uow;
            this.UserService = userService;
        }

        [HttpPost]
        [Route("create-user")]
        public ActionResult CreateUser(Common.DataTransferObjects.User user)
        {
            OperationResult result;
            try
            {
                result = this.UserService.Create(user);
                if (result.IsSuccesfull){
                return Ok();
            }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception exc )
            {
                return BadRequest(exc);
            }
        }

      
    }
}