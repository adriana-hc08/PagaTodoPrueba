using DL;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("Api/Tasks/")]
    public class TareaController : Controller
    {
        private readonly DL.Interfaces.ITareaRepository _tareaRepository;
        private readonly DL.Interfaces.IStatusRepository _statusRepository;
        public TareaController(DL.Interfaces.ITareaRepository tareaRepository, DL.Interfaces.IStatusRepository statusRepository)
        {
            _tareaRepository = tareaRepository;
            _statusRepository = statusRepository;
        }
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = _tareaRepository.GetAll();
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
            ML.Result result = _tareaRepository.Add(tarea);
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
            ML.Result result = _tareaRepository.Update(tarea);
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
            ML.Result result = _tareaRepository.GetById(IdTarea);
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
            ML.Result result = _tareaRepository.Delete(IdTarea);
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
