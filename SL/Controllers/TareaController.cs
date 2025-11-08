using DL;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("Api/Tasks/")]
    public class TareaController : Controller
    {

        public readonly AHernandezPruebaContex _context;
        public readonly BL.Tarea _tarea;

        public TareaController(AHernandezPruebaContex context,BL.Tarea tarea)
        {
            _context = context;
            _tarea = tarea;
        }
        [Route("GetAll")]
        [HttpGet]
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

        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody]ML.Tarea tarea)
        {
            ML.Result result = _tarea.Add(tarea);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [Route("Update")]
        [HttpPut]
        public IActionResult GetAll([FromBody] ML.Tarea tarea)
        {
            ML.Result result = _tarea.Update(tarea);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetByid(int IdTarea)
        {
            ML.Result result = _tarea.GetById(IdTarea);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int IdTarea)
        {
            ML.Result result = _tarea.Delete(IdTarea);
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
