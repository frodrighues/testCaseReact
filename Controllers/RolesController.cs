using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using testCaseReact.Data;

namespace testCaseReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RolesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IList<BistroRole>> Get()
        {
            return Ok(_dbContext.BistroRole.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<BistroRole> GetSpecificRole(int id)
        {
            var entity = _dbContext.BistroRole.Find(id);

            if(entity == null) return NotFound();

            return Ok(entity);
        } 

        [HttpPost]
        public IActionResult Post([FromBody] BistroRole item)
        {
            if(item == null) return BadRequest();

            try
            {
                var newItem = _dbContext.BistroRole.Add(item).Entity;
                _dbContext.SaveChanges();
                return Ok(newItem);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}