using Microsoft.AspNetCore.Mvc;
using MonolithAPI.DTO;
using MonolithAPI.Services.Implementation;

namespace MonolithAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalenderController : Controller
    {
        private CalenderService calenderService;
        public CalenderController(CalenderService calenderService) { 
           this.calenderService = calenderService;
        }
        public async Task<ActionResult> AddCalenderEvent(AddCalenderEventDTO addCalenderEventDTO)
        {
            try {

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model");
                }
                else {


                    await calenderService.addCalenderEvent(addCalenderEventDTO);
                    return Ok();

                }
            
            }
            catch(Exception e) { 
            
                 return BadRequest(e.Message);
            
            }
        
        }
    }
}
