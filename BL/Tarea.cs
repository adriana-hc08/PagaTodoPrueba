using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Tarea
    {
        public readonly AHernandezPruebaContex _context;

        public Tarea(AHernandezPruebaContex context)
        {
            _context = context;
        }
        public ML.Result GetAll()
        {
            Result result = new ML.Result();

            try
            {

                var listTareas = _context.Tareas
                        .Select(tarea => new ML.Tarea
                        {
                            IdTarea = tarea.IdTarea,
                            Title = tarea.Title,
                            Description = tarea.Description,
                            Status = tarea.Status,
                            CreationDate = tarea.CreationDate
                        }).ToList();
                if (listTareas != null && listTareas.Count > 0)
                {
                    result.Objects = new List<object>();

                    foreach (var obj in listTareas)
                    {
                        ML.Tarea tarea = new ML.Tarea();
                        tarea.IdTarea = obj.IdTarea;
                        tarea.Title = obj.Title;
                        tarea.Description = obj.Description;
                        tarea.Status = obj.Status;
                        tarea.CreationDate = obj.CreationDate;
                        result.Objects.Add(tarea);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
                }

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
                var tareaEF = new DL.Tarea
                {
                    Title = tarea.Title,
                    Description = tarea.Description,
                    Status = tarea.Status,
                    CreationDate = tarea.CreationDate,
                };

                _context.Tareas.Add(tareaEF);
                int filasAfectadas = _context.SaveChanges();

                if (filasAfectadas > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                }

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
                var tareaExistente = _context.Tareas.FirstOrDefault(t => t.IdTarea == tarea.IdTarea);

                if (tareaExistente != null)
                {
                    tareaExistente.Title = tarea.Title;
                    tareaExistente.Description = tarea.Description;
                    tareaExistente.Status = tarea.Status;

                    int filasAfectadas = _context.SaveChanges();
                    result.Correct = filasAfectadas > 0;

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
        public ML.Result Delete(int IdTarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                var tarea = _context.Tareas.Find(IdTarea);

                _context.Tareas.Remove(tarea);
                int filasAfectadas = _context.SaveChanges();

                if (filasAfectadas > 0)
                {
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public ML.Result GetById(int IdTarea)
        {
            ML.Result result = new ML.Result();
            try
            {
                var tarea = _context.Tareas
             .Where(t => t.IdTarea == IdTarea)
             .Select(t => new ML.Tarea
             {
                 IdTarea = t.IdTarea,
                 Title = t.Title,
                 Description = t.Description,
                 Status = t.Status,
                 CreationDate = t.CreationDate
             }).FirstOrDefault();

                if (tarea != null)
                {

                    ML.Tarea tareaGuardar = new ML.Tarea();
                    tareaGuardar.IdTarea = tarea.IdTarea;
                    tareaGuardar.Title = tarea.Title;
                    tareaGuardar.Description = tarea.Description;
                    tareaGuardar.Status = tarea.Status;
                    tareaGuardar.CreationDate = tarea.CreationDate;
                    result.Object = tareaGuardar;

                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron registros";
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
