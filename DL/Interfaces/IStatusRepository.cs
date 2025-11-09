using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IStatusRepository
    {
        ML.Result GetAll();
        ML.Result Add(ML.Status status);
        
    }
    public class StatusRepository : IStatusRepository
    {
        private readonly AHernandezPruebaContex _context;

        public StatusRepository(AHernandezPruebaContex context)
        {
            _context = context;
        }

        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                var query = from status in _context.Statuses
                            select new ML.Status
                            {
                                IdStatus = status.IdStatus,
                                Nombre = status.Nombre
                            };

                result.Objects = query.ToList<object>();
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ML.Result Add(ML.Status status)
        {
            ML.Result result = new ML.Result();

            try
            {
                var entity = new DL.Status
                {
                    Nombre = status.Nombre
                };

                _context.Statuses.Add(entity);
                _context.SaveChanges();

                result.Correct = true;
                result.ErrorMessage = "Status agregado correctamente";
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
