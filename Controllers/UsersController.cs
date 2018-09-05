using System.Collections.Generic;
using System.Linq;
//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testCaseReact.Data;

namespace testCaseReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        //private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            //this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IList<BistroUser>> Get(){
            var result = _dbContext.BistroUser.ToList();

            return result;
        }

        [HttpPost]
        public IActionResult Create([FromBody] testCaseReact.DTO.BistroUser item)
        {
            if (item == null) return BadRequest();

            try
            {
                return Ok(item);
               //var entity = AutoMapper.Mapper.
               //_dbContext.BistroUser.Add(item);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}