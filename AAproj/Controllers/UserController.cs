using AAproj.Data;
using AAproj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AAproj.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : Controller
        {
            private readonly RLAPIDbContext dbContext;
            public UserController(RLAPIDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            [HttpGet]

            public async Task<IActionResult> RegisterGet()
            {
                return Ok(await dbContext.Registers.ToListAsync());
            }

        [Route("Register")]
        [HttpPost]

        public async Task<IActionResult> RegisterAdd(AddRegister addRegister)
        {
            var addreg = new Register()
            {
                Id = Guid.NewGuid(),
                FirstName = addRegister.FirstName,
                LastName = addRegister.LastName,
                Username = addRegister.Username,
                Password = addRegister.Password,
                date = addRegister.date
            };

            await dbContext.Registers.AddAsync(addreg);
            await dbContext.SaveChangesAsync();

            return Ok(addreg);
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Loggin(Login login)
        {
            var log = dbContext.Registers.Where(x => x.Username.Equals(login.Username) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            else {
                return StatusCode(StatusCodes.Status200OK);
            }
        }
    }


}
