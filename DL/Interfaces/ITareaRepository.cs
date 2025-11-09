using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface ITareaRepository
    {
        ML.Result GetAll();
        ML.Result GetById(int id);
        ML.Result Add(ML.Tarea tarea);
        ML.Result Update(ML.Tarea tarea);
        ML.Result Delete(int id);
    }
    
    public class TareaRepository : ITareaRepository
    {
        private readonly AHernandezPruebaContex _context;

        public TareaRepository(AHernandezPruebaContex context)
        {
            _context = context;
        }

        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                var query = from tarea in _context.Tareas
                            join status in _context.Statuses
                            on tarea.IdStatus equals status.IdStatus
                            select new ML.Tarea
                            {
                                IdTarea = tarea.IdTarea,
                                Title = tarea.Title,
                                Description = tarea.Description,
                                Status = new ML.Status
                                {
                                    IdStatus = status.IdStatus,
                                    Nombre = status.Nombre
                                }
                            };

                var lista = query.ToList();
                result.Objects = lista.Cast<object>().ToList();
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ML.Result GetById(int id)
        {
            ML.Result result = new ML.Result();

            try
            {
                var query = from tarea in _context.Tareas
                            join status in _context.Statuses
                            on tarea.IdStatus equals status.IdStatus
                            where tarea.IdTarea == id
                            select new ML.Tarea
                            {
                                IdTarea = tarea.IdTarea,
                                Title = tarea.Title,
                                Description = tarea.Description,
                                CreationDate = tarea.CreationDate,
                                Status = new ML.Status
                                {
                                    IdStatus = status.IdStatus,
                                    Nombre = status.Nombre
                                }
                            };

                result.Object = query.FirstOrDefault();
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ML.Result Add(ML.Tarea tarea)
        {
            ML.Result result = new ML.Result();

            try
            {
                var entity = new DL.Tarea
                {
                    Title = tarea.Title,
                    Description = tarea.Description,
                    IdStatus = tarea.Status.IdStatus,
                    CreationDate = tarea.CreationDate
                };
                _context.Tareas.Add(entity);
                _context.SaveChanges(); // Importante guardar cambios

                result.Correct = true;
                result.ErrorMessage = "Tarea agregada correctamente";
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ML.Result Update(ML.Tarea tarea)
        {
            ML.Result result = new ML.Result();

            try
            {
                var entity = _context.Tareas.FirstOrDefault(x => x.IdTarea == tarea.IdTarea);
                if (entity != null)
                {
                    entity.Title = tarea.Title;
                    entity.Description = tarea.Description;
                    entity.IdStatus = tarea.Status.IdStatus;
                    _context.SaveChanges(); // Guardar cambios

                    result.Correct = true;
                    result.ErrorMessage = "Tarea actualizada correctamente";
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Tarea no encontrada";
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ML.Result Delete(int id)
        {
            ML.Result result = new ML.Result();

            try
            {
                var entity = _context.Tareas.Find(id);
                if (entity != null)
                {
                    _context.Tareas.Remove(entity);
                    _context.SaveChanges(); // Guardar cambios

                    result.Correct = true;
                    result.ErrorMessage = "Tarea eliminada correctamente";
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Tarea no encontrada";
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


