using DL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TareaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BL.Status _status;
        public TareaController(IConfiguration configuration, IHttpClientFactory httpClientFactory, BL.Status status)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _status = status;
            _status = status;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Tarea tarea = new ML.Tarea();

            ML.Result result = GetAllApi();

            if (result.Correct)
            {
                tarea.Tareas=result.Objects;
            }
            else
            {
                tarea.Tareas = new List<object>();
            }
                return View(tarea);
        }
        [HttpGet]
        public IActionResult Formulario(int? IdTarea)
        {
            ML.Tarea tarea = new ML.Tarea();
            tarea.Status =new ML.Status();
            ML.Result resultStatus=_status.GetAll();
            if (resultStatus.Correct)
            {
                tarea.Status.Statuses=resultStatus.Objects;
            }
            else
            {
                tarea.Status.Statuses = new List<object>();
            }
            if (IdTarea ==0)
            {
                
            }
            else if (IdTarea > 0)
            {
                ML.Result result = GetByIdWebAPI(IdTarea.Value);
                if (result.Correct)
                {
                    tarea = (ML.Tarea)result.Object;
                    tarea.Status.Statuses = resultStatus.Objects;
                }
            }
            return View(tarea);
        }
        [HttpPost]
        public IActionResult Formulario(ML.Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                ML.Result result = new ML.Result();

                if (tarea.IdTarea == 0)
                {
                    result = AddApi(tarea);
                    TempData["Mensaje"] = "Tarea agregada correctamente.";
                }
                else
                {
                    result = UpdateApi(tarea);
                    TempData["Mensaje"] = "Tarea actualizada correctamente.";
                }
                if (result.Correct)
                {
                    TempData.Keep("Mensaje");
                    return RedirectToAction("GetAll");
                }
            }
            else
            {
                tarea.Status.Statuses = new List<object>();
                return View(tarea);
            }
                return View();
        }
        public ActionResult Delete(int IdTarea)
        {
            ML.Result result = DeleteApi(IdTarea);
            if (result.Correct)
            {
                TempData["Mensaje"] = "Tarea eliminada correctamente.";
                return RedirectToAction("GetAll");
            }
            else
            {
                TempData["Mensaje"] = "No se pudo eliminar";
                return View("Error");
            }

        }


        public ML.Result GetAllApi()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            using (var client = new HttpClient())
            {
                var endpoint = _configuration["EndpointsApi:GetAll"];
                var responseTask = client.GetAsync(endpoint);

                responseTask.Wait();

                var resultTask = responseTask.Result;

                if (resultTask.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)

                    {

                        ML.Tarea resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Tarea>(resultItem.ToString());

                        result.Objects.Add(resultItemList);

                    }

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se pudieron obtener las tareas desde la API.";
                }
            }

            return result;
        }
        public ML.Result GetByIdWebAPI(int IdTarea)
        {
            ML.Result result = new ML.Result();

            try
            {
                var endpoint = _configuration["EndpointsApi:GetById"];

                using (var client = new HttpClient())
                {

                    var urlCompleta = $"{endpoint}={IdTarea}";
                    var responseTask = client.GetAsync(urlCompleta);

                    responseTask.Wait();
                    var resultAPI = responseTask.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Tarea resultItemList = new ML.Tarea();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Tarea>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Departamento";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public ML.Result DeleteApi(int IdTarea)
        {

            ML.Result result = new ML.Result();

            try
            {
                var endpoint = _configuration["EndpointsApi:Delete"];
                using (var client = new HttpClient())
                {

                    var urlCompleta = $"{endpoint}={IdTarea}";
                    var responseTask = client.DeleteAsync(urlCompleta);
                    responseTask.Wait();

                    var resultApi = responseTask.Result;
                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }                  
            return result;
        }
        public ML.Result AddApi(ML.Tarea tarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                var endpoint = _configuration["EndpointsApi:Create"];

                using (var client = new HttpClient())
                {
                    
                    var responseTask = client.PostAsJsonAsync<ML.Tarea>(endpoint,tarea);
                    responseTask.Wait();

                    var resultApi = responseTask.Result;

                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public ML.Result UpdateApi(ML.Tarea tarea)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (var client = new HttpClient())
                {
                    var endpoint = _configuration["EndpointsApi:Update"];
                    var responseTask = client.PutAsJsonAsync<ML.Tarea>(endpoint, tarea);
                    responseTask.Wait();

                    var resultApi = responseTask.Result;

                    if (resultApi.IsSuccessStatusCode)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            
            return result;
        }
    }

}


