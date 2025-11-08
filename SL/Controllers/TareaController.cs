using DL;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class TareaController : Controller
    {
        public readonly AHernandezPruebaContex _context;
        public readonly BL.Tarea _tarea;

        public TareaController(AHernandezPruebaContex context,BL.Tarea tarea)
        {
            _context = context;
            _tarea = tarea;
        }
        [HttpPost]
        public IActionResult GetAll()
        {
            ML.Result result = _tarea.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
                
        }
    }
}
