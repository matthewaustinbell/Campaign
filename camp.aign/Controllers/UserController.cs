using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using camp.aign.DataAccess;
using camp.aign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace camp.aign.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPut("{userId}" )]

        public IActionResult updateUser(User newUserCommand, int userId)
        {

            var repo = new UserRepository();
            var userThatGotUpdated = repo.UPDATE(newUserCommand, userId);

            return Created($"api/users/{userThatGotUpdated.donationTotal}", userThatGotUpdated);
        }
    }
}
