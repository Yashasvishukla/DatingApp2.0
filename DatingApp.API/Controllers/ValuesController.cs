using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController: ControllerBase
    {
        public readonly DataContext _dbContext;
        public ValuesController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Get(){
            var values =await _dbContext.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id){
            var value = await _dbContext.Values.FirstOrDefaultAsync(x=>x.Id == id);
            if(value==null){
                return NoContent();
            }

            return Ok(value);
        }
        
    }
}