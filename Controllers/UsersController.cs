using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testCaseReact.Data;

namespace testCaseReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IList<BistroUser>> Get(){
            var result = new List<BistroUser>();

            result.Add(new BistroUser{
                Name = "Eu",
                Surname = "Rodrigues",
                Id = 1,
                Description = "Dono"
            });
            

            return result;
        }

        [HttpPost]
        public ActionResult Create([FromBody] BistroUser item)
        {
            if (item == null) return BadRequest();

            try
            {
                _dbContext.BistroUser.Add(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}