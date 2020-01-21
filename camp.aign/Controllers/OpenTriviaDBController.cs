using camp.aign.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace camp.aign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenTriviaDBController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var repo = new QuestionRepository();
            var qeustions = repo.GetAPIQuestions();
            return Ok(qeustions.First());
        }
    }
}