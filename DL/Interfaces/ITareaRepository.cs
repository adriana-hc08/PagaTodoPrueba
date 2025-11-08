using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface ITareaRepository
    {
        IEnumerable<ML.Tarea> GetAll();
        ML.Tarea GetById(int id);
        void Add(ML.Tarea tarea);
        void Update(ML.Tarea tarea);
        void Delete(int id);
    }
    
    public class TareaRepository : ITareaRepository
    {
        private readonly AHernandezPruebaContex _context;

        public TareaRepository(AHernandezPruebaContex context)
        {
            _context = context;
        }

        public IEnumerable<ML.Tarea> GetAll()
        {
            return _context.Tareas
                .Select(t => new ML.Tarea
                {
                    IdTarea = t.IdTarea,
                    Title = t.Title,
                    Description = t.Description,
                    //Status = t.Status,
                    CreationDate = t.CreationDate
                }).ToList();
        }

        public ML.Tarea GetById(int id)
        {
            var t = _context.Tareas.FirstOrDefault(x => x.IdTarea == id);
            if (t == null) return null;

            return new ML.Tarea
            {
                IdTarea = t.IdTarea,
                Title = t.Title,
                Description = t.Description,
                //Status = t.Status,
                CreationDate = t.CreationDate
            };
        }

        public void Add(ML.Tarea tarea)
        {
            var entity = new DL.Tarea
            {
                Title = tarea.Title,
                Description = tarea.Description,
                //Status = tarea.Status,
                CreationDate = tarea.CreationDate
            };
            _context.Tareas.Add(entity);
        }

        public void Update(ML.Tarea tarea)
        {
            var entity = _context.Tareas.FirstOrDefault(x => x.IdTarea == tarea.IdTarea);
            if (entity != null)
            {
                entity.Title = tarea.Title;
                entity.Description = tarea.Description;
                //entity.Status = tarea.Status;
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Tareas.Find(id);
            if (entity != null)
                _context.Tareas.Remove(entity);
        }
    }
}


