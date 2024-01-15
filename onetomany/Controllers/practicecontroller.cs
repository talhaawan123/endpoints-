using Microsoft.AspNetCore.Mvc;
using onetomany.Data;
using onetomany.Models;

namespace onetomany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class practicecontroller : ControllerBase
    {
        private readonly dbcontext _context;

        public practicecontroller(dbcontext context)
        {
            _context = context;
        }
        [HttpPost("post-email")]
        public IActionResult PostEmail([FromBody] Person person)
        {
            try
            {
                
                return Ok(new { Message = $"Email '{person.email}' successfully received!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to post email: {ex.Message}");
            }
        }
        [HttpPost("post-phone-number")]
        public IActionResult PostPhoneNumber([FromBody] Person person)
        {
            try
            {
                
                return Ok(new { Message = $"Phone number '{person.phoneno}' successfully received!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to post phone number: {ex.Message}");
            }
        }

        [HttpPost ("add/person") ]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            try
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();

                return Ok(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.InnerException?.ToString());

                return BadRequest($"Failed to add person: {ex.Message}");
            }


        }


    }
}
