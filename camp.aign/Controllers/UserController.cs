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
        [HttpPut("donation/{userId}")]
        public IActionResult UpdateDonationAmount(int userId)
        {
            var repo = new UserRepository();
            var user = repo.getUserById(userId);
            var addtionalDonationAmount = 1;
            user.donationTotal += addtionalDonationAmount;
            var userThatGotUpdated = repo.UPDATE(user, userId);
            return Ok(userThatGotUpdated.donationTotal);
        }

        [HttpGet("{userId}")]
        public ActionResult<User> getUserById(int userId)
        {
            var repo = new UserRepository();
            return repo.getUserById(userId);
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var repo = new UserRepository();
            var users = repo.GetAll();
            return users;
        }
    }
}
