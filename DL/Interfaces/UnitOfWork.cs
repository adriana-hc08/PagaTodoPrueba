using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITareaRepository TareaRepository { get; }
        IStatusRepository StatusRepository { get; }
        int Save();
    }

    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AHernandezPruebaContex _context;
        public ITareaRepository TareaRepository { get; }
        public IStatusRepository StatusRepository { get; }

        public UnitOfWork(AHernandezPruebaContex context)
        {
            _context = context; // Variable correcta
            TareaRepository = new TareaRepository(_context);
            StatusRepository = new StatusRepository(_context);
        }

        public int Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }

}
