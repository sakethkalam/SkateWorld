using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _dbContext;
        public BuggyController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("notfound")]
        public ActionResult GetNoFoundRequest()
        {
            var item = _dbContext.Products.Find();

            if(item == null)
            {
                return NotFound(new ApiResponses(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var item = _dbContext.Products.Find();

            var itemtoreturn = item.ToString();

            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponses(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}